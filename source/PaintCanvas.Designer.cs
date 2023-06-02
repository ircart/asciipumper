namespace AsciiPumper
{
	partial class PaintCanvas
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
			this.SuspendLayout();
			// 
			// PaintCanvas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "PaintCanvas";
			this.Size = new System.Drawing.Size(666, 413);
			this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.PaintCanvas_PreviewKeyDown);
			this.Load += new System.EventHandler(this.PaintCanvas_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PaintCanvas_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PaintCanvas_MouseMove);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PaintCanvas_KeyPress);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PaintCanvas_MouseUp);
			this.SizeChanged += new System.EventHandler(this.PaintCanvas_SizeChanged);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PaintCanvas_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion
	}
}
