using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.CodeGenerator.Logic.TypeConversions;
using Horde3DNET;

namespace Infrastructure.CodeGenerator.Logic
{
	class AutomaticTypeConverter
	{
		#region Singleton Design Pattern
		public static AutomaticTypeConverter Instance { get; private set; }

		protected AutomaticTypeConverter()
		{
			var rules = new List<ConversionRule>
			{
			    new ConversionRule { CppType = "const char*", Problematic = false, TypeConversion = new ToStringConversion { CSharpType = typeof(String) } },
			    new ConversionRule { CppType = "const float**", Problematic = true, TypeConversion = new CodeConversion { CSharpType = typeof(float) } },
			    new ConversionRule { CppType = "const float*", Problematic = true, TypeConversion = new DereferencePointerConversion { CSharpType = typeof(float) } },
			    new ConversionRule { CppType = "const void**", Problematic = true, TypeConversion = new CodeConversion { CSharpType = typeof(int) } },
			    new ConversionRule { CppType = "const void*", Problematic = true, TypeConversion = new CodeConversion { CSharpType = typeof(int) } },
				new ConversionRule { CppType = "int*", Problematic = true, TypeConversion = new DereferencePointerConversion { CSharpType = typeof(int) } },
				new ConversionRule { CppType = "float*", Problematic = true, TypeConversion = new DereferencePointerConversion { CSharpType = typeof(float) } },
				new ConversionRule { CppType = "EngineOptions::List", Problematic = false, TypeConversion = new ToEnumConversion { CSharpType = typeof(Horde3DNET.Horde3D.EngineOptions) } },
				new ConversionRule { CppType = "EngineStats::List", Problematic = false, TypeConversion = new ToEnumConversion { CSharpType = typeof(Horde3DNET.Horde3D.EngineStats) } },
				new ConversionRule { CppType = "ResourceTypes::List", Problematic = false, TypeConversion = new ToEnumConversion { CSharpType = typeof(Horde3DNET.Horde3D.ResourceTypes) } },
				new ConversionRule { CppType = "SceneNodeTypes::List", Problematic = false, TypeConversion = new ToEnumConversion { CSharpType = typeof(Horde3DNET.Horde3D.SceneNodeTypes) } },
				new ConversionRule { CppType = "NodeHandle*", Problematic = true, TypeConversion = new InlineCodeConversion { CSharpType = typeof(int), Code = "{paramName} == 0 ? 0 : (int)(*{paramName})" } },
				new ConversionRule { CppType = "NodeHandle", Problematic = false, TypeConversion = new InlineCodeConversion { CSharpType = typeof(int), Code = "(int){paramName}" } },
				new ConversionRule { CppType = "ResHandle", Problematic = false, TypeConversion = new InlineCodeConversion { CSharpType = typeof(int), Code = "(int){paramName}" } },
				new ConversionRule { CppType = "bool", Problematic = false, TypeConversion = new DirectConversion { CSharpType = typeof(bool) } },
				new ConversionRule { CppType = "int", Problematic = false, TypeConversion = new DirectConversion { CSharpType = typeof(int) } },
				new ConversionRule { CppType = "float", Problematic = false, TypeConversion = new DirectConversion { CSharpType = typeof(float) } },
				new ConversionRule { CppType = "double", Problematic = false, TypeConversion = new DirectConversion { CSharpType = typeof(double) } },
				new ConversionRule { CppType = "void", Problematic = false, TypeConversion = new DirectConversion { CSharpType = typeof(void) } },
			};

			ConversionRules = rules.ToDictionary(r => r.CppType, r => r);
		}

		static AutomaticTypeConverter()
		{
			Instance = new AutomaticTypeConverter();
		}
		#endregion

		private Dictionary<string, ConversionRule> ConversionRules { get; set; }

		public void GetTypeConversion(Type type)
		{
			ConversionRule rule = null;
			
			if (ConversionRules.TryGetValue(type.CppType, out rule))
			{
				type.TypeConversion = rule.TypeConversion.Copy;
				type.Problematic = rule.Problematic;
			}
			else
			{
				type.TypeConversion = new InlineCodeConversion { Code = "/* Unknown */ nullptr" };
				type.Problematic = true;
				type.TypeConversion.CSharpType = typeof(void);
			}
		}
	}
}
