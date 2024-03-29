using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms;
using Infrastructure.Core.SceneNodes;
using Infrastructure.UserInterface;

namespace Client.Views.SceneNodes
{
	public partial class NodeView : DocumentView
	{
		public event RequestHandler ShowParentDetailsRequest;

		public NodeView()
		{
			InitializeComponent();
			Icon = Icon.FromHandle(Properties.Resources.SceneGraph.GetHicon());
		}

		string title = "Node";
		public override string Title
		{
			get
			{
				return title;
			}
		}

		public SceneNode SceneNode
		{
			set
			{
				if (value == null)
					return;

				title = value.ToString();
				this.Text = title;
				this.ToolTipText = title;
				this.TabText = title;

				bindingSource.DataSource = value;
			}
		}

		private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
		{
			Request(ShowParentDetailsRequest);
		}
	}
}
