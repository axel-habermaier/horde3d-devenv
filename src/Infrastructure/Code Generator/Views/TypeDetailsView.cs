using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms;
using Infrastructure.CodeGenerator.Logic;
using Infrastructure.CodeGenerator.Logic.TypeConversions;
using Infrastructure.UserInterface;
using ICSharpCode.TextEditor;

namespace Infrastructure.CodeGenerator.Views
{
	public partial class TypeDetailsView : UserControlView
	{
		public event RequestHandler<TypeConversion> SetTypeConversionRequest;
		public event RequestHandler<bool> SetProblemResolved;
		public event RequestHandler UserModified;
		public event RequestHandler FunctionChanged;

		private Infrastructure.CodeGenerator.Logic.Type type;

		public TypeDetailsView()
		{
			InitializeComponent();
			conversionCode.SetHighlighting("C++.NET");
		}

		public Infrastructure.CodeGenerator.Logic.Type Type
		{
			set
			{
				type = value;
				typeNameLabel.Text = value.CppType;

				var conversionTypes = new List<TypeConversion>();
				AddTypeConversion(conversionTypes, value.TypeConversion, new CodeConversion());
				AddTypeConversion(conversionTypes, value.TypeConversion, new DereferencePointerConversion());
				AddTypeConversion(conversionTypes, value.TypeConversion, new DirectConversion());
				AddTypeConversion(conversionTypes, value.TypeConversion, new InlineCodeConversion());
				AddTypeConversion(conversionTypes, value.TypeConversion, new ToEnumConversion());
				AddTypeConversion(conversionTypes, value.TypeConversion, new ToStringConversion());

				conversionComboBox.DataSource = conversionTypes;
				conversionComboBox.SelectedItem = value.TypeConversion;

				var csharpTypes = new List<System.Type>();
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(void));
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(int));
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(bool));
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(float));
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(double));
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(char));
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(byte));
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(string));
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(byte[]));
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(float[]));
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(int[]));
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(double[]));
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(float[][]));
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(System.IntPtr));
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(Horde3DNET.Horde3D.EngineOptions));
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(Horde3DNET.Horde3D.EngineStats));
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(Horde3DNET.Horde3D.ResourceTypes));
				AddCSharpType(csharpTypes, value.TypeConversion.CSharpType, typeof(Horde3DNET.Horde3D.SceneNodeTypes));

				csharpTypeComboBox.DataSource = csharpTypes;
				csharpTypeComboBox.SelectedItem = value.TypeConversion.CSharpType;

				if (value.TypeConversion is CodeConversion)
					conversionCode.Text = ((CodeConversion)value.TypeConversion).Code;
				else if (value.TypeConversion is InlineCodeConversion)
					conversionCode.Text = ((InlineCodeConversion)value.TypeConversion).Code;

				problemSolvedCheckBox.Checked = value.ProblemIsResolved;
				problemSolvedCheckBox.Enabled = value.Problematic;
				conversionSettingsGroup.Visible = value.TypeConversion is CodeConversion || value.TypeConversion is InlineCodeConversion;

				conversionComboBox.SelectedIndexChanged += new EventHandler(conversionComboBox_SelectedIndexChanged);
				conversionCode.TextChanged += new EventHandler(conversionCode_TextChanged);
				csharpTypeComboBox.SelectedIndexChanged += new EventHandler(csharpTypeComboBox_SelectedIndexChanged);
				problemSolvedCheckBox.CheckedChanged += new EventHandler(problemSolvedCheckBox_CheckedChanged);

				settingsPanel.Visible = type.Problematic || type.UserModified;
				noProblemsLinkLabel.Visible = !type.Problematic && !type.UserModified;
				noProblemsLabel.Visible = !type.Problematic && !type.UserModified;
			}
		}

		void AddCSharpType(List<System.Type> list, System.Type currentType, System.Type type)
		{
			if (currentType.FullName == type.FullName)
				list.Add(currentType);
			else
				list.Add(type);
		}

		void AddTypeConversion(List<TypeConversion> list, TypeConversion currentConversion, TypeConversion typeConversion)
		{
			if (currentConversion.GetType() == typeConversion.GetType())
				list.Add(currentConversion);
			else
				list.Add(typeConversion);
		}

		private void conversionComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var item = conversionComboBox.SelectedItem as TypeConversion;

			if (item == null)
				return;

			if (item.GetType() == type.TypeConversion.GetType())
				return;

			conversionSettingsGroup.Visible = item is CodeConversion || item is InlineCodeConversion;
			if (csharpTypeComboBox.SelectedItem is System.Type)
				item.CSharpType = (System.Type)csharpTypeComboBox.SelectedItem;

			if (item is CodeConversion)
				conversionCode.Text = ((CodeConversion)item).Code;
			else if (item is InlineCodeConversion)
				conversionCode.Text = ((InlineCodeConversion)item).Code;

			conversionCode.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));

			Request(SetTypeConversionRequest, item as TypeConversion);
			Request(UserModified);
			Request(FunctionChanged);
		}

		private void conversionCode_TextChanged(object sender, EventArgs e)
		{
			var codeConversion = type.TypeConversion as CodeConversion;
			if (codeConversion != null)
				codeConversion.Code = conversionCode.Text;

			var inlineCodeConversion = type.TypeConversion as InlineCodeConversion;
			if (inlineCodeConversion != null)
				inlineCodeConversion.Code = conversionCode.Text;

			Request(UserModified);
			Request(FunctionChanged);
		}

		private void problemSolvedCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			Request(SetProblemResolved, problemSolvedCheckBox.Checked);
			Request(FunctionChanged);
		}

		private void noProblemsLinkLabel_LinkClicked(object sender, EventArgs e)
		{
			noProblemsLinkLabel.Visible = false;
			noProblemsLabel.Visible = false;
			settingsPanel.Visible = true;
		}

		private void csharpTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (csharpTypeComboBox.SelectedItem == null || !(csharpTypeComboBox.SelectedItem is System.Type))
				return;

			type.TypeConversion.CSharpType = (System.Type)csharpTypeComboBox.SelectedItem;
			Request(UserModified);
			Request(FunctionChanged);
		}
	}
}
