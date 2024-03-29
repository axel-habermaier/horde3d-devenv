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
using Infrastructure.UserInterface;

namespace Infrastructure.CodeGenerator.Views
{
	public partial class FunctionListView : DockView
	{
		TreeNode allFunctionsNode = new TreeNode("All Functions (0)", 0, 0);
		TreeNode problematicFunctionsNode = new TreeNode("Problematic Functions (0)", 1, 1);

		public event RequestHandler<Function> FunctionDetailsRequest;

		public FunctionListView()
		{
			InitializeComponent();
			Icon = Icon.FromHandle(Properties.Resources.List.GetHicon());

			SetStandardTextFont(treeView);
			treeView.Nodes.Add(problematicFunctionsNode);
			treeView.Nodes.Add(allFunctionsNode);
			treeView.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(treeView_NodeMouseDoubleClick);
		}

		void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			var function = e.Node.Tag as Function;

			if (function != null)
				Request(FunctionDetailsRequest, function);
		}

		public override string Title
		{
			get { return "Function List"; }
		}

		private void AddFunctions(TreeNode parent, List<Function> functions)
		{
			parent.Nodes.Clear();
			var expanded = parent.IsExpanded;

			foreach (var f in functions)
			{
				var node = new TreeNode(f.CppDefinition, GetImageIndex(f), GetImageIndex(f));
				node.Tag = f;
				parent.Nodes.Add(node);
			}

			parent.Text = parent.Text.Substring(0, parent.Text.LastIndexOf(" ")) + " (" + functions.Count + ")";

			if (expanded)
				parent.Expand();
		}

		public List<Function> Functions
		{
			set { AddFunctions(allFunctionsNode, value); }
		}

		public List<Function> ProblematicFunctions
		{
			set 
			{
				var expand = problematicFunctionsNode.Nodes.Count == 0;
				AddFunctions(problematicFunctionsNode, value);

				if (expand)
					problematicFunctionsNode.Expand();
			}
		}

		public void ClearFunctions()
		{
			allFunctionsNode.Nodes.Clear();
			problematicFunctionsNode.Nodes.Clear();

			allFunctionsNode.Text = "All Functions (0)";
			problematicFunctionsNode.Text = "Problematic Functions (0)";

			allFunctionsNode.Collapse();
			problematicFunctionsNode.Expand();
		}

		public void UpdateFunction(Function function)
		{
			UpdateFunction(allFunctionsNode, function);
			UpdateFunction(problematicFunctionsNode, function);
		}

		void UpdateFunction(TreeNode startNode, Function function)
		{
			foreach (TreeNode node in startNode.Nodes)
			{
				if (node.Tag == function)
				{
					node.ImageIndex = GetImageIndex(function);
					node.SelectedImageIndex = GetImageIndex(function);
				}
			}
		}

		int GetImageIndex(Function function)
		{
			int imageIndex = function.Problematic ? 3 : 2;
			if (function.Problematic && function.AllProblemsResolved)
				imageIndex = 4;

			if (function.OldFunction != null)
				imageIndex = 3;

			return imageIndex;
		}
	}
}
