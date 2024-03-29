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

namespace Client.Views.Resources
{
	public partial class TextureView : DocumentView
	{
		public TextureView()
		{
			InitializeComponent();

			Icon = Icon.FromHandle(Properties.Resources.TextureResource.GetHicon());
		}

		string title = "Texture Resource";
		public override string Title
		{
			get
			{
				return title;
			}
		}

		public TextureResource Texture
		{
			set
			{
				title = FileSystem.TruncatePath(value.Name, MaxTitleLength);
				bindingSource.DataSource = value;
			}
		}

		public string TexturePreviewUri
		{
			set
			{
				if (String.IsNullOrEmpty(value) || (!value.EndsWith(".jpg") && !value.EndsWith(".bmp") && !value.EndsWith(".png") && !value.EndsWith(".tga")))
					unsupportedFormatLabel.Visible = true;
				else
				{
					Image image = null;
					if (value.EndsWith(".tga"))
						image = Paloma.TargaImage.LoadTargaImage(value);
					else
						image = Image.FromFile(value);
					pictureBox.Image = image;
					pictureBox.Visible = true;
				}
			}
		}
	}
}
