namespace AsciiPumper
{
	partial class MainForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.PaintPanel = new System.Windows.Forms.Panel();
            this.AsciiPaintCanvas = new AsciiPumper.PaintCanvas();
            this.txtWatermark = new System.Windows.Forms.TextBox();
            this.chkWatermark = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioRemoveFormatting = new System.Windows.Forms.RadioButton();
            this.radioUnderline = new System.Windows.Forms.RadioButton();
            this.radioBold = new System.Windows.Forms.RadioButton();
            this.radioFill = new System.Windows.Forms.RadioButton();
            this.radioPaintBrush = new System.Windows.Forms.RadioButton();
            this.btnCopy = new System.Windows.Forms.Button();
            this.checkRMBfg = new System.Windows.Forms.CheckBox();
            this.colorRMB = new System.Windows.Forms.PictureBox();
            this.lblRMB = new System.Windows.Forms.Label();
            this.checkMMBfg = new System.Windows.Forms.CheckBox();
            this.colorMMB = new System.Windows.Forms.PictureBox();
            this.lblMMB = new System.Windows.Forms.Label();
            this.lblForeground = new System.Windows.Forms.Label();
            this.checkLMBfg = new System.Windows.Forms.CheckBox();
            this.colorLMB = new System.Windows.Forms.PictureBox();
            this.lblLeftMouseButton = new System.Windows.Forms.Label();
            this.colorSelector1 = new AsciiPumper.ColorSelector();
            this.numColumns = new System.Windows.Forms.NumericUpDown();
            this.lblColumns = new System.Windows.Forms.Label();
            this.numRows = new System.Windows.Forms.NumericUpDown();
            this.lblRows = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.PaintPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorRMB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorMMB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorLMB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).BeginInit();
            this.SuspendLayout();
            // 
            // fontDialog1
            // 
            this.fontDialog1.FixedPitchOnly = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.PaintPanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.txtWatermark);
            this.splitContainer.Panel2.Controls.Add(this.chkWatermark);
            this.splitContainer.Panel2.Controls.Add(this.panel1);
            this.splitContainer.Panel2.Controls.Add(this.btnCopy);
            this.splitContainer.Panel2.Controls.Add(this.checkRMBfg);
            this.splitContainer.Panel2.Controls.Add(this.colorRMB);
            this.splitContainer.Panel2.Controls.Add(this.lblRMB);
            this.splitContainer.Panel2.Controls.Add(this.checkMMBfg);
            this.splitContainer.Panel2.Controls.Add(this.colorMMB);
            this.splitContainer.Panel2.Controls.Add(this.lblMMB);
            this.splitContainer.Panel2.Controls.Add(this.lblForeground);
            this.splitContainer.Panel2.Controls.Add(this.checkLMBfg);
            this.splitContainer.Panel2.Controls.Add(this.colorLMB);
            this.splitContainer.Panel2.Controls.Add(this.lblLeftMouseButton);
            this.splitContainer.Panel2.Controls.Add(this.colorSelector1);
            this.splitContainer.Panel2.Controls.Add(this.numColumns);
            this.splitContainer.Panel2.Controls.Add(this.lblColumns);
            this.splitContainer.Panel2.Controls.Add(this.numRows);
            this.splitContainer.Panel2.Controls.Add(this.lblRows);
            
            this.splitContainer.Size = new System.Drawing.Size(978, 438);
            this.splitContainer.Panel2MinSize = 220;
            this.splitContainer.SplitterDistance = 751;
            this.splitContainer.TabIndex = 2;
            // 
            // PaintPanel
            // 
            this.PaintPanel.AutoScroll = true;
            this.PaintPanel.Controls.Add(this.AsciiPaintCanvas);
            this.PaintPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PaintPanel.Location = new System.Drawing.Point(0, 0);
            this.PaintPanel.Name = "PaintPanel";
            this.PaintPanel.Size = new System.Drawing.Size(751, 438);
            this.PaintPanel.TabIndex = 2;
            // 
            // AsciiPaintCanvas
            // 
            this.AsciiPaintCanvas.BackColor = System.Drawing.Color.White;
            this.AsciiPaintCanvas.CausesValidation = false;
            this.AsciiPaintCanvas.CellHeight = 20;
            this.AsciiPaintCanvas.CellWidth = 10;
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.White);
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.Black);
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(127))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(0))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(156))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(127)))), ((int)(((byte)(0))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(252)))), ((int)(((byte)(0))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(147))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(252))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210))))));
            this.AsciiPaintCanvas.Columns = 60;
            this.AsciiPaintCanvas.DontRepaint = false;
            this.AsciiPaintCanvas.Font = new System.Drawing.Font("Consolas", 10F);
            this.AsciiPaintCanvas.HighlightColor = System.Drawing.Color.Salmon;
            this.AsciiPaintCanvas.HighlightWidth = 2;
            this.AsciiPaintCanvas.LeftMouseColor = ((byte)(0));
            this.AsciiPaintCanvas.LeftMouseIsForeground = false;
            this.AsciiPaintCanvas.Location = new System.Drawing.Point(0, 0);
            this.AsciiPaintCanvas.MiddleMouseColor = ((byte)(4));
            this.AsciiPaintCanvas.MiddleMouseIsForeground = true;
            this.AsciiPaintCanvas.Modified = false;
            this.AsciiPaintCanvas.MostRecentForegroundColor = ((byte)(4));
            this.AsciiPaintCanvas.Name = "AsciiPaintCanvas";
            this.AsciiPaintCanvas.PaintMode = AsciiPumper.PaintCanvas.PaintModes.PaintBrush;
            this.AsciiPaintCanvas.RightMouseColor = ((byte)(1));
            this.AsciiPaintCanvas.RightMouseIsForeground = false;
            this.AsciiPaintCanvas.Rows = 20;
            this.AsciiPaintCanvas.SelectedCellPosition = new System.Drawing.Point(0, 0);
            this.AsciiPaintCanvas.SeperatorColor = System.Drawing.Color.DimGray;
            this.AsciiPaintCanvas.SeperatorWidth = 1;
            this.AsciiPaintCanvas.Size = new System.Drawing.Size(600, 400);
            this.AsciiPaintCanvas.TabIndex = 0;
            // 
            // txtWatermark
            // 
            this.txtWatermark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWatermark.Location = new System.Drawing.Point(2, 345);
            this.txtWatermark.Name = "txtWatermark";
            this.txtWatermark.Size = new System.Drawing.Size(218, 22);
            this.txtWatermark.TabIndex = 18;
            this.txtWatermark.Text = "http://code.google.com/p/asciipumper/ ";
            this.txtWatermark.Enter += new System.EventHandler(this.txtWatermark_Enter);
            // 
            // chkWatermark
            // 
            this.chkWatermark.AutoSize = true;
            this.chkWatermark.Location = new System.Drawing.Point(3, 322);
            this.chkWatermark.Name = "chkWatermark";
            this.chkWatermark.Size = new System.Drawing.Size(166, 17);
            this.chkWatermark.TabIndex = 17;
            this.chkWatermark.Text = "Hardspace with watermark:";
            this.chkWatermark.UseVisualStyleBackColor = true;
            this.chkWatermark.CheckedChanged += new System.EventHandler(this.chkWatermark_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioRemoveFormatting);
            this.panel1.Controls.Add(this.radioUnderline);
            this.panel1.Controls.Add(this.radioBold);
            this.panel1.Controls.Add(this.radioFill);
            this.panel1.Controls.Add(this.radioPaintBrush);
            this.panel1.Location = new System.Drawing.Point(3, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 73);
            this.panel1.TabIndex = 16;
            // 
            // radioRemoveFormatting
            // 
            this.radioRemoveFormatting.AutoSize = true;
            this.radioRemoveFormatting.Location = new System.Drawing.Point(4, 50);
            this.radioRemoveFormatting.Name = "radioRemoveFormatting";
            this.radioRemoveFormatting.Size = new System.Drawing.Size(123, 17);
            this.radioRemoveFormatting.TabIndex = 4;
            this.radioRemoveFormatting.Text = "Remove formatting";
            this.radioRemoveFormatting.UseVisualStyleBackColor = true;
            this.radioRemoveFormatting.CheckedChanged += new System.EventHandler(this.radioRemoveFormatting_CheckedChanged);
            // 
            // radioUnderline
            // 
            this.radioUnderline.AutoSize = true;
            this.radioUnderline.Location = new System.Drawing.Point(118, 27);
            this.radioUnderline.Name = "radioUnderline";
            this.radioUnderline.Size = new System.Drawing.Size(76, 17);
            this.radioUnderline.TabIndex = 3;
            this.radioUnderline.Text = "Underline";
            this.radioUnderline.UseVisualStyleBackColor = true;
            this.radioUnderline.CheckedChanged += new System.EventHandler(this.radioUnderline_CheckedChanged);
            // 
            // radioBold
            // 
            this.radioBold.AutoSize = true;
            this.radioBold.Location = new System.Drawing.Point(118, 4);
            this.radioBold.Name = "radioBold";
            this.radioBold.Size = new System.Drawing.Size(49, 17);
            this.radioBold.TabIndex = 2;
            this.radioBold.Text = "Bold";
            this.radioBold.UseVisualStyleBackColor = true;
            this.radioBold.CheckedChanged += new System.EventHandler(this.radioBold_CheckedChanged);
            // 
            // radioFill
            // 
            this.radioFill.AutoSize = true;
            this.radioFill.Location = new System.Drawing.Point(4, 27);
            this.radioFill.Name = "radioFill";
            this.radioFill.Size = new System.Drawing.Size(40, 17);
            this.radioFill.TabIndex = 1;
            this.radioFill.Text = "Fill";
            this.radioFill.UseVisualStyleBackColor = true;
            this.radioFill.CheckedChanged += new System.EventHandler(this.radioFill_CheckedChanged);
            // 
            // radioPaintBrush
            // 
            this.radioPaintBrush.AutoSize = true;
            this.radioPaintBrush.Checked = true;
            this.radioPaintBrush.Location = new System.Drawing.Point(4, 4);
            this.radioPaintBrush.Name = "radioPaintBrush";
            this.radioPaintBrush.Size = new System.Drawing.Size(84, 17);
            this.radioPaintBrush.TabIndex = 0;
            this.radioPaintBrush.TabStop = true;
            this.radioPaintBrush.Text = "Paint brush";
            this.radioPaintBrush.UseVisualStyleBackColor = true;
            this.radioPaintBrush.CheckedChanged += new System.EventHandler(this.radioPaintBrush_CheckedChanged);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Location = new System.Drawing.Point(0, 292);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(218, 23);
            this.btnCopy.TabIndex = 15;
            this.btnCopy.Text = "Copy art to clipboard";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkRMBfg
            // 
            this.checkRMBfg.AutoSize = true;
            this.checkRMBfg.Location = new System.Drawing.Point(164, 193);
            this.checkRMBfg.Name = "checkRMBfg";
            this.checkRMBfg.Size = new System.Drawing.Size(15, 14);
            this.checkRMBfg.TabIndex = 14;
            this.checkRMBfg.UseVisualStyleBackColor = true;
            this.checkRMBfg.CheckedChanged += new System.EventHandler(this.checkRMBfg_CheckedChanged);
            // 
            // colorRMB
            // 
            this.colorRMB.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colorRMB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorRMB.Location = new System.Drawing.Point(121, 187);
            this.colorRMB.Name = "colorRMB";
            this.colorRMB.Size = new System.Drawing.Size(20, 20);
            this.colorRMB.TabIndex = 13;
            this.colorRMB.TabStop = false;
            // 
            // lblRMB
            // 
            this.lblRMB.AutoSize = true;
            this.lblRMB.Location = new System.Drawing.Point(1, 194);
            this.lblRMB.Name = "lblRMB";
            this.lblRMB.Size = new System.Drawing.Size(115, 13);
            this.lblRMB.TabIndex = 12;
            this.lblRMB.Text = "Right Mouse Button:";
            // 
            // checkMMBfg
            // 
            this.checkMMBfg.AutoSize = true;
            this.checkMMBfg.Checked = true;
            this.checkMMBfg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkMMBfg.Location = new System.Drawing.Point(164, 167);
            this.checkMMBfg.Name = "checkMMBfg";
            this.checkMMBfg.Size = new System.Drawing.Size(15, 14);
            this.checkMMBfg.TabIndex = 11;
            this.checkMMBfg.UseVisualStyleBackColor = true;
            this.checkMMBfg.CheckedChanged += new System.EventHandler(this.checkMMBfg_CheckedChanged);
            // 
            // colorMMB
            // 
            this.colorMMB.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colorMMB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorMMB.Location = new System.Drawing.Point(121, 161);
            this.colorMMB.Name = "colorMMB";
            this.colorMMB.Size = new System.Drawing.Size(20, 20);
            this.colorMMB.TabIndex = 10;
            this.colorMMB.TabStop = false;
            // 
            // lblMMB
            // 
            this.lblMMB.AutoSize = true;
            this.lblMMB.Location = new System.Drawing.Point(1, 168);
            this.lblMMB.Name = "lblMMB";
            this.lblMMB.Size = new System.Drawing.Size(123, 13);
            this.lblMMB.TabIndex = 9;
            this.lblMMB.Text = "Middle Mouse Button:";
            // 
            // lblForeground
            // 
            this.lblForeground.AutoSize = true;
            this.lblForeground.Location = new System.Drawing.Point(140, 118);
            this.lblForeground.Name = "lblForeground";
            this.lblForeground.Size = new System.Drawing.Size(74, 13);
            this.lblForeground.TabIndex = 8;
            this.lblForeground.Text = "Foreground?";
            // 
            // checkLMBfg
            // 
            this.checkLMBfg.AutoSize = true;
            this.checkLMBfg.Location = new System.Drawing.Point(164, 140);
            this.checkLMBfg.Name = "checkLMBfg";
            this.checkLMBfg.Size = new System.Drawing.Size(15, 14);
            this.checkLMBfg.TabIndex = 7;
            this.checkLMBfg.UseVisualStyleBackColor = true;
            this.checkLMBfg.CheckedChanged += new System.EventHandler(this.checkLMBfg_CheckedChanged);
            // 
            // colorLMB
            // 
            this.colorLMB.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colorLMB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorLMB.Location = new System.Drawing.Point(121, 134);
            this.colorLMB.Name = "colorLMB";
            this.colorLMB.Size = new System.Drawing.Size(20, 20);
            this.colorLMB.TabIndex = 6;
            this.colorLMB.TabStop = false;
            // 
            // lblLeftMouseButton
            // 
            this.lblLeftMouseButton.AutoSize = true;
            this.lblLeftMouseButton.Location = new System.Drawing.Point(1, 141);
            this.lblLeftMouseButton.Name = "lblLeftMouseButton";
            this.lblLeftMouseButton.Size = new System.Drawing.Size(106, 13);
            this.lblLeftMouseButton.TabIndex = 5;
            this.lblLeftMouseButton.Text = "Left Mouse Button:";
            // 
            // colorSelector1
            // 
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.White);
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.Black);
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(127))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(0))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(156))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(127)))), ((int)(((byte)(0))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(252)))), ((int)(((byte)(0))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(147))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(252))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127))))));
            new AsciiPumper.ColorPalette().Add(System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210))))));
            this.colorSelector1.Location = new System.Drawing.Point(3, 51);
            this.colorSelector1.Name = "colorSelector1";
            this.colorSelector1.Size = new System.Drawing.Size(209, 54);
            this.colorSelector1.TabIndex = 4;
            this.colorSelector1.ButtonColorChanged += new System.EventHandler<AsciiPumper.ColorSelector.ButtonColorChangedEventArgs>(this.colorSelector1_ButtonColorChanged);
            // 
            // numColumns
            // 
            this.numColumns.Location = new System.Drawing.Point(106, 16);
            this.numColumns.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numColumns.Name = "numColumns";
            this.numColumns.Size = new System.Drawing.Size(46, 22);
            this.numColumns.TabIndex = 3;
            this.numColumns.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numColumns.ValueChanged += new System.EventHandler(this.numColumns_ValueChanged);
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Location = new System.Drawing.Point(103, 0);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(55, 13);
            this.lblColumns.TabIndex = 2;
            this.lblColumns.Text = "Columns:";
            // 
            // numRows
            // 
            this.numRows.Location = new System.Drawing.Point(44, 23);
            this.numRows.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRows.Name = "numRows";
            this.numRows.Size = new System.Drawing.Size(46, 22);
            this.numRows.TabIndex = 1;
            this.numRows.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numRows.ValueChanged += new System.EventHandler(this.numRows_ValueChanged);
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(6, 25);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(38, 13);
            this.lblRows.TabIndex = 0;
            this.lblRows.Text = "Rows:";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.Filter = "Text files|*.txt|All files|*.*";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            this.openFileDialog.Filter = "Text files|*.txt|All files|*.*";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(978, 438);
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Ascii Pumper";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            this.PaintPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorRMB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorMMB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorLMB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.Panel PaintPanel;
		private PaintCanvas AsciiPaintCanvas;
		private System.Windows.Forms.NumericUpDown numColumns;
		private System.Windows.Forms.Label lblColumns;
		private System.Windows.Forms.NumericUpDown numRows;
		private System.Windows.Forms.Label lblRows;
		private ColorSelector colorSelector1;
		private System.Windows.Forms.Label lblLeftMouseButton;
		private System.Windows.Forms.PictureBox colorLMB;
		private System.Windows.Forms.CheckBox checkRMBfg;
		private System.Windows.Forms.PictureBox colorRMB;
		private System.Windows.Forms.Label lblRMB;
		private System.Windows.Forms.CheckBox checkMMBfg;
		private System.Windows.Forms.PictureBox colorMMB;
		private System.Windows.Forms.Label lblMMB;
		private System.Windows.Forms.Label lblForeground;
		private System.Windows.Forms.CheckBox checkLMBfg;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton radioFill;
		private System.Windows.Forms.RadioButton radioPaintBrush;
		private System.Windows.Forms.CheckBox chkWatermark;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TextBox txtWatermark;
		private System.Windows.Forms.RadioButton radioRemoveFormatting;
		private System.Windows.Forms.RadioButton radioUnderline;
		private System.Windows.Forms.RadioButton radioBold;
	}
}

