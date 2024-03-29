using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Infrastructure.CodeGenerator.Logic
{
	public class CodeGenerationSettings
	{
		#region Properties
		/// <summary>
		/// The path to the C# code file that should be generated.
		/// </summary>
		public string GeneratedCSharpCodeFilePath { get; set; }

		/// <summary>
		/// The path to the C++ code file that should be generated.
		/// </summary>
		public string GeneratedCppCodeFilePath { get; set; }

		/// <summary>
		/// The Horde3D version for which the code is generated.
		/// </summary>
		public string Horde3DVersion { get; set; }

		/// <summary>
		/// The path to this instance's file on the disk.
		/// </summary>
		[XmlIgnore]
		public string SettingsFilePath { get; set; }

		/// <summary>
		/// The Horde3D header file's content.
		/// </summary>
		public string Horde3DHeaderFileContent { get; set; }

		/// <summary>
		/// Gets the "name" of the settings, i.e. the filename without the extension.
		/// </summary>
		[XmlIgnore]
		public string Name 
		{
			get { return Path.GetFileNameWithoutExtension(SettingsFilePath ?? "unnamed"); }
		}
		#endregion

		#region Events
		/// <summary>
		/// Raised when the Functions property has changed.
		/// </summary>
		public event EventHandler FunctionsChanged;
		#endregion

		#region System Operation Properties
		List<Function> functions;
		/// <summary>
		/// Gets all functions.
		/// </summary>
		public List<Function> Functions 
		{
			get { return functions; }
			set
			{
				functions = value;
				if (FunctionsChanged != null)
					FunctionsChanged(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Gets all problematic functions.
		/// </summary>
		[XmlIgnore]
		public List<Function> ProblematicFunctions 
		{
			get 
			{
				return (from f in Functions
					   where f.Problematic || f.OldFunction != null
					   select f).ToList();
			}
		}
		#endregion

		#region System Operations
		/// <summary>
		/// Parses the given horde3D file.
		/// </summary>
		/// <param name="horde3DFilePath">The path to the Horde3D file.</param>
		public void ParseHorde3DFunctions(string horde3DFilePath)
		{
			if (String.IsNullOrEmpty(horde3DFilePath))
				throw new ArgumentNullException("horde3DFilePath", "You must specify a Horde3D header file.");

			var parser = new Horde3DHeaderFileParser(horde3DFilePath);
			UpdateFunctions(parser.Parse());
			Horde3DHeaderFileContent = parser.HeaderFileContent;
		}

		/// <summary>
		/// Loads a CodeGenerationSettings object and all associated functions 
		/// (and their associated TypeConversion) from the given file.
		/// </summary>
		/// <param name="filePath">The path to load the object from.</param>
		/// <returns>Returns the deserialized object.</returns>
		public static CodeGenerationSettings LoadCodeGenerationSettings(string filePath)
		{
			var settings = XmlSerializer<CodeGenerationSettings>.Deserialize(filePath);
			settings.SettingsFilePath = filePath;
			return settings;
		}

		/// <summary>
		/// Stores the given CodeGenerationSettings object and all associated functions 
		/// (and their associated TypeConversion) in the given file. 
		/// If no filePath was given, the previously used filePath is used again.
		/// </summary>
		/// <param name="filePath">The file path used to save the object. If null, the previously used
		/// file path is used again.</param>
		public void SaveCodeGenerationSettings(string filePath)
		{
			if (String.IsNullOrEmpty(filePath))
				filePath = SettingsFilePath;

			if (String.IsNullOrEmpty(filePath))
				throw new ArgumentNullException("filePath", "If the settings have never been saved before, you have to specify a file path.");

			XmlSerializer<CodeGenerationSettings>.Serialize(this, filePath);

			SettingsFilePath = filePath;
		}

		/// <summary>
		/// Generates the code.
		/// </summary>
		public void GenerateCode()
		{
			var codeGenerator = new CodeGenerator(this);
			codeGenerator.GenerateCode();
		}
		#endregion

		#region Update Functions
		/// <summary>
		/// Updates the current function list with the new parsed functions.
		/// </summary>
		/// <param name="newFunctions">The new functions.</param>
		private void UpdateFunctions(List<Function> newFunctions)
		{
			if (Functions != null && Functions.Count > 0)
			{
				var modifiedFunctions = from f in Functions
										where f.ReturnType.UserModified
										|| f.Parameters.Any(p => p.Type.UserModified)
										select f;

				modifiedFunctions.Foreach(oldFunction =>
				{
					var newFunction = (from newF in newFunctions
									   where newF.Name == oldFunction.Name
									   select newF).SingleOrDefault();

					if (newFunction != null)
					{
						bool updateSuccessful = true;
						updateSuccessful = updateSuccessful && UpdateType(oldFunction.ReturnType, newFunction.ReturnType);

						var modifiedParameters = from p in oldFunction.Parameters
												 where p.Type.UserModified
												 select p;

						modifiedParameters.Foreach(oldParameter =>
						{
							var newParameter = (from newP in newFunction.Parameters
												where newP.Name == oldParameter.Name
												select newP).SingleOrDefault();

							if (newParameter != null)
								updateSuccessful = updateSuccessful && UpdateType(oldParameter.Type, newParameter.Type);
						});

						if (!updateSuccessful)
						{
							newFunction.OldFunction = oldFunction;
							oldFunction.Name = "(before update) " + oldFunction.Name;
							oldFunction.CppDefinition = "(before update) " + oldFunction.CppDefinition;
						}
					}
				});

				ProblematicFunctions.Foreach(oldFunction =>
				{
					var newFunction = (from newF in newFunctions
									   where newF.Name == oldFunction.Name
									   select newF).SingleOrDefault();

					if (newFunction != null)
					{
						if (!oldFunction.ReturnType.UserModified && oldFunction.ReturnType.Problematic && oldFunction.ReturnType.ProblemIsResolved
							&& oldFunction.ReturnType.CppType == newFunction.ReturnType.CppType && newFunction.ReturnType.Problematic
							&& oldFunction.ReturnType.TypeConversion.GetType() == newFunction.ReturnType.TypeConversion.GetType())
							newFunction.ReturnType.ProblemIsResolved = true;

						oldFunction.Parameters.Foreach(oldParameter =>
						{
							var newParameter = (from newP in newFunction.Parameters
												where newP.Name == oldParameter.Name
												select newP).SingleOrDefault();

							if (newParameter != null && !oldParameter.Type.UserModified && oldParameter.Type.Problematic && oldParameter.Type.ProblemIsResolved
								&& oldParameter.Type.CppType == newParameter.Type.CppType && newParameter.Type.Problematic
								&& oldParameter.Type.TypeConversion.GetType() == newParameter.Type.TypeConversion.GetType())
								newParameter.Type.ProblemIsResolved = true;
						});
					}
				});
			}

			Functions = newFunctions;
		}

		/// <summary>
		/// Updates the type's conversion settings.
		/// </summary>
		/// <param name="oldType">The old type settings.</param>
		/// <param name="newType">The new type settings.</param>
		/// <returns>Returns true if the update was successful, otherwise false.</returns>
		private bool UpdateType(Infrastructure.CodeGenerator.Logic.Type oldType, Infrastructure.CodeGenerator.Logic.Type newType)
		{
			if (!oldType.UserModified)
				return true;

			if (oldType.CppType == newType.CppType)
			{
				newType.TypeConversion = oldType.TypeConversion;
				newType.Problematic = oldType.Problematic;
				newType.ProblemIsResolved = oldType.ProblemIsResolved;
				newType.UserModified = true;
				return true;
			}
			else
			{
				newType.Problematic = true;
				newType.ProblemIsResolved = false;
				return false;
			}
		}
		#endregion
	}
}
