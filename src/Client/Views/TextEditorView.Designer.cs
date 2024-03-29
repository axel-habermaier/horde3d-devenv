namespace Client.Views
{
	partial class TextEditorView
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textEditor = new ICSharpCode.TextEditor.TextEditorControl();
			this.SuspendLayout();
			// 
			// textEditor
			// 
			this.textEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textEditor.IsReadOnly = false;
			this.textEditor.Location = new System.Drawing.Point(0, 0);
			this.textEditor.Name = "textEditor";
			this.textEditor.ShowVRuler = false;
			this.textEditor.Size = new System.Drawing.Size(484, 316);
			this.textEditor.TabIndex = 1;
			// 
			// TextEditorView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.textEditor);
			this.Name = "TextEditorView";
			this.Size = new System.Drawing.Size(484, 316);
			this.ResumeLayout(false);

		}

		#endregion

		private ICSharpCode.TextEditor.TextEditorControl textEditor;
	}
}
