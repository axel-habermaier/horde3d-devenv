using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms;
using Infrastructure.Core.Resources;
using ICSharpCode.TextEditor;
using ComponentFactory.Krypton.Toolkit;
using System.Runtime.InteropServices;
using ICSharpCode.TextEditor.Document;

namespace Client.Views.Resources
{
	public partial class ShaderSectionView : UserControlView
	{
		public ShaderSectionView()
		{
			InitializeComponent();
			textEditor.SetHighlighting("C++.NET");
		}

		ShaderSection section;
		public ShaderSection ShaderSection
		{
			set
			{
				if (value == null)
					return;

				section = value;

				bindingSource.DataSource = value;
				textEditor.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));
				SetGroupTitle();
				BuildContextMenu();
			}
		}

		private void BuildContextMenu()
		{
			var index = 1;
			foreach (var shaderSection in section.Shader.ShaderSections)
			{
				contextMenuItems.Items.Insert(index++, new KryptonContextMenuItem(shaderSection.Name));
				//removeSectionItems.Items.Add(new KryptonContextMenuItem(shaderSection.Name));
			}
		}

		private void SetGroupTitle()
		{
			var prefix = String.Empty;
			switch (shaderType)
			{
				default:
				case ShaderType.Unknown:
					break;
				case ShaderType.FragmentShader:
					prefix = "Fragment";
					break;
				case ShaderType.GeometryShader:
					prefix = "Geometry";
					break;
				case ShaderType.VertexShader:
					prefix = "Vertex";
					break;
			}

			var shaderName = section == null ? "unknown" : section.Name;
			group.ValuesPrimary.Heading = prefix + " Shader '" + shaderName + "'";
		}

		ShaderType shaderType = ShaderType.Unknown;
		public ShaderType ShaderType
		{
			set
			{
				shaderType = value;
				switch (value)
				{
					case ShaderType.Unknown:
						//group.HeaderPositionPrimary = ComponentFactory.Krypton.Toolkit.VisualOrientation.Top;
						//selectSectionButton.Visible = false;
						break;
					default:
						//group.HeaderPositionPrimary = ComponentFactory.Krypton.Toolkit.VisualOrientation.Left;
						//selectSectionButton.Visible = true;
						break;
				}
				SetGroupTitle();
			}
		}
	}
}
