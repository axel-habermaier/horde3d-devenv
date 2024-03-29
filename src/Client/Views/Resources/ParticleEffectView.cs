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
using ICSharpCode.TextEditor.Document;
using System.IO;

namespace Client.Views.Resources
{
	public partial class ParticleEffectView : SaveableDocumentView
	{
		public ParticleEffectView()
		{
			InitializeComponent();

			Icon = Icon.FromHandle(Properties.Resources.ParticleEffect.GetHicon());
		}

		string title = "Particle Effect Resource";
		public override string Title
		{
			get
			{
				return title;
			}
		}

		ParticleEffectResource particleEffect = null;
		public ParticleEffectResource ParticleEffect
		{
			get { return particleEffect; }
			set
			{
				particleEffect = value;
				title = FileSystem.TruncatePath(particleEffect.Name, MaxTitleLength);
			}
		}

		public TextEditorView TextEditorView
		{
			set
			{
				if (value == null)
					return;

				Controls.Add(value);
			}
		}
	}
}
