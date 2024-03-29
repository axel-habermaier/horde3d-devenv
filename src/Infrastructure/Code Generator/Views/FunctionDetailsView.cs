using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms;
using WeifenLuo.WinFormsUI.Docking;
using Infrastructure.CodeGenerator.Logic;
using Infrastructure.UserInterface;
using ICSharpCode.TextEditor;

namespace Infrastructure.CodeGenerator.Views
{
	public partial class FunctionDetailsView : DocumentView
	{
		public event RequestHandler SetUpdateProblemIsResolved;
		public event RequestHandler ShowOldFunctionDetails;

		private List<TypeTabPage> typeTabPages = new List<TypeTabPage>();

		public FunctionDetailsView()
			: base()
		{
			InitializeComponent();
			Icon = Icon.FromHandle(Properties.Resources.Method.GetHicon());

			SetStandardTextFont(tabControl);
			noProfilingProxyPreview.SetHighlighting("C++.NET");
			noProfilingProxyPreview.Document.ReadOnly = true;
			profilingProxyPreview.SetHighlighting("C++.NET");
			profilingProxyPreview.Document.ReadOnly = true;
			csharpPreview.SetHighlighting("C#");
			csharpPreview.Document.ReadOnly = true;
		}

		string title = "Function Details";
		public override string Title
		{
			get { return title; }
		}

		public Function Function
		{
			set
			{
				title = value.Name;
				this.TabText = title;

				if (value.Problematic && value.AllProblemsResolved)
					Icon = Icon.FromHandle(Properties.Resources.ResolvedMethod.GetHicon());
				else if (value.Problematic && !value.AllProblemsResolved)
					Icon = Icon.FromHandle(Properties.Resources.ProblematicMethod.GetHicon());

				functionLabel.Text = value.CppDefinition;
				UpdateCodePreview(value);

				typeTabPages.Foreach(t => SetTabPageImage(t.TabPage, t.Type));
			}
		}

		public void AddReturnTypeView(Infrastructure.CodeGenerator.Logic.Type type, UserControlView view)
		{
			if (type == null || view == null)
				return;

			returnTypePage.Controls.Add(view);
			SetTabPageImage(returnTypePage, type);
			typeTabPages.Add(new TypeTabPage { Type = type, TabPage = returnTypePage });
		}

		public void AddParameterView(Parameter parameter, ParameterDetailsView view)
		{
			if (view == null || parameter == null)
				return;

			var page = new TabPage(parameter.Name);
			page.Controls.Add(view);
			tabControl.TabPages.Add(page);

			SetTabPageImage(page, parameter.Type);
			typeTabPages.Add(new TypeTabPage { Type = parameter.Type, TabPage = page });
		}

		private void SetTabPageImage(TabPage page, Infrastructure.CodeGenerator.Logic.Type type)
		{
			if (type.Problematic && !type.ProblemIsResolved)
				page.ImageIndex = 1;
			else if (type.Problematic && type.ProblemIsResolved)
				page.ImageIndex = 2;
			else
				page.ImageIndex = 0;
		}

		public bool EnableOldFunctionElements
		{
			set
			{
				showOldFunctionButton.Enabled = value;
				removeOldFunctionLinkLabel.Enabled = value;
			}
		}

		private void showOldFunctionButton_Click(object sender, EventArgs e)
		{
			Request(ShowOldFunctionDetails);
		}

		private void removeOldFunctionLinkLabel_LinkClicked(object sender, EventArgs e)
		{
			Request(SetUpdateProblemIsResolved);
		}

		private void UpdateCodePreview(Function function)
		{
			noProfilingProxyPreview.Text = new CppFunctionCodeGenerator(function).GenerateNoProfilingProxyFunction();
			noProfilingProxyPreview.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));

			profilingProxyPreview.Text = new CppFunctionCodeGenerator(function).GenerateProfilingProxyFunction();
			profilingProxyPreview.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));

			csharpPreview.Text = new CSharpFunctionCodeGenerator(function).CodePreview;
			csharpPreview.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));
		}

		struct TypeTabPage
		{
			public TabPage TabPage { get; set; }
			public Infrastructure.CodeGenerator.Logic.Type Type { get; set; }
		}
	}
}
