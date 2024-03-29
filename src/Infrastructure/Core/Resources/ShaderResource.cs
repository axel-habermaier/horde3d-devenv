using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Horde3DNET;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace Infrastructure.Core.Resources
{
	[DataContract]
	public class ShaderResource : EditableResource
	{
		internal ShaderResource(int resHandle) 
			: base(resHandle)
		{

		}

		public ShaderResource(string name) : base (0) 
		{
			Name = name;
		}

		public override Horde3D.ResourceTypes ResourceType
		{
			get { return Horde3D.ResourceTypes.Shader; }
		}

		/// <summary>
		/// Gets the FX section.
		/// </summary>
		public FxSection FxSection { get; private set; }

		/// <summary>
		/// Gets the shader sections.
		/// </summary>
		public List<ShaderSection> ShaderSections { get; private set; }

		/// <summary>
		/// Unloads the resource currently used by Horde3D and reloads it immediately.
		/// </summary>
		internal override void UpdateHorde3D()
		{
			base.UpdateHorde3D(() =>
			{
				// Unload the shader's code resources. Unfortunately, the shader's code resources are not 
				// unloaded automatically when the shader resource is unloaded.
				var resHandle = 0;
				var reload = new List<int>();
				while ((resHandle = Horde3D.getNextResource((int)Horde3D.ResourceTypes.Code, resHandle)) != 0)
				{
					if (Horde3D.getResourceName(resHandle).Contains(Name))
						reload.Add(resHandle);
				}

				reload.Foreach(r => Horde3D.unloadResource(r));
			});
		}

		/// <summary>
		/// Loads the resource from Xml stored in the FileContent property.
		/// </summary>
		public override void LoadFromXml()
		{
			if (String.IsNullOrEmpty(FileContent))
				throw new InvalidOperationException("Cannot load the shader from an empty xml file. Make sure the xml file has been loaded correctly.");

			if (FxSection == null)
				FxSection = new FxSection();
			if (ShaderSections == null)
				ShaderSections = new List<ShaderSection>();

			var lines = FileContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
			var fxSectionBuilder = new StringBuilder();
			var newShaderSections = new List<ShaderSection>();

			for (int i = 0; i < lines.Length;)
			{
				if (lines[i].Contains("[[FX]]"))
				{
					++i;
					while (i < lines.Length && !lines[i].Contains("[["))
						fxSectionBuilder.AppendLine(lines[i++]);
				}
				else if (lines[i].Contains("[["))
				{
					var sectionName = lines[i].Replace("[[", "").Replace("]]", "").Trim();

					var shaderSection = ShaderSections.Where(s => s.Name == sectionName).SingleOrDefault();
					if (shaderSection == null)
					{
						shaderSection = new ShaderSection(this);
						shaderSection.Name = sectionName;
					}

					newShaderSections.Add(shaderSection);

					++i;
					var shaderSectionBuilder = new StringBuilder();

					while (i < lines.Length && !lines[i].Contains("[["))
						shaderSectionBuilder.AppendLine(lines[i++]);

					shaderSection.Code = shaderSectionBuilder.ToString();
				}
				else
					++i;
			}

			ShaderSections.Clear();
			ShaderSections.AddRange(newShaderSections);

			if (fxSectionBuilder.Length > 0)
				FxSection.LoadFromXml(this, ShaderSections, fxSectionBuilder.ToString());
		}

		/// <summary>
		/// Generates the Xml content and updates the FileContent property.
		/// </summary>
		public override void GenerateXml()
		{
			var builder = new StringBuilder();
			builder.AppendLine("[[FX]]");

			using (var stringWriter = new StringWriter(builder))
			{
				var settings = new XmlWriterSettings();
				settings.Indent = true;
				settings.OmitXmlDeclaration = true;

				foreach (var element in FxSection.GenerateXml())
				{
					using (var writer = XmlWriter.Create(stringWriter, settings))
						element.Save(writer);

					builder.AppendLine().AppendLine();
				}
			}

			foreach (var shaderSection in ShaderSections)
			{
				builder.AppendLine();
				builder.AppendLine("[[" + shaderSection.Name + "]]");
				builder.AppendLine(shaderSection.Code);
			}

			FileContent = builder.ToString();
		}
	}
}
