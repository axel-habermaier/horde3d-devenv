using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace Infrastructure.UserInterface.WinForms
{
	public partial class SavePendingChangesDialog : KryptonForm
	{
		public SavePendingChangesDialog()
		{
			InitializeComponent();
		}

		public List<string> ModifiedDocuments
		{
			set
			{
				documentsList.DataSource = value;
			}
		}
	}
}
