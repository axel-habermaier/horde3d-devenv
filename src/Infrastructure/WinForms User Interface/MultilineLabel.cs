using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ComponentFactory.Krypton.Toolkit;

namespace Infrastructure.UserInterface.WinForms
{
	public class MultilineLabel : RichTextBox
	{
		[DllImport("user32.dll", EntryPoint = "HideCaret")]
		public static extern long HideCaret(IntPtr hwnd);

		public MultilineLabel()
		{
			BorderStyle = BorderStyle.None;
			Cursor = Cursors.Arrow;

			IPalette palette = KryptonManager.CurrentGlobalPalette;
			ForeColor = palette.GetContentShortTextColor1(PaletteContentStyle.LabelNormalControl, PaletteState.Normal);
			Font = palette.GetContentShortTextFont(PaletteContentStyle.LabelNormalControl, PaletteState.Normal);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			HideCaret(this.Handle);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			HideCaret(this.Handle);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			HideCaret(this.Handle);
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// MultilineLabel
			// 
			this.Multiline = true;
			this.ResumeLayout(false);

		}
	}
}
