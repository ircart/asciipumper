namespace AsciiPumper
{
	partial class OptionsForm
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lbCategories = new System.Windows.Forms.ListBox();
			this.grpEditor = new System.Windows.Forms.GroupBox();
			this.tableEditor = new System.Windows.Forms.TableLayoutPanel();
			this.lblEditorFont = new System.Windows.Forms.Label();
			this.lblSampleText = new System.Windows.Forms.Label();
			this.btnEditorFont = new System.Windows.Forms.Button();
			this.lblCellWidth = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblPx1 = new System.Windows.Forms.Label();
			this.numCellWidth = new System.Windows.Forms.NumericUpDown();
			this.lblCellHeight = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblPx2 = new System.Windows.Forms.Label();
			this.numCellHeight = new System.Windows.Forms.NumericUpDown();
			this.lblSeperatorColor = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnSeperatorColor = new System.Windows.Forms.Button();
			this.colorSeperator = new System.Windows.Forms.PictureBox();
			this.lblHighlightColor = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnHighlightColor = new System.Windows.Forms.Button();
			this.colorHighlight = new System.Windows.Forms.PictureBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.fontdlgEditorFont = new System.Windows.Forms.FontDialog();
			this.colordlgSeperator = new System.Windows.Forms.ColorDialog();
			this.colordlgHighlight = new System.Windows.Forms.ColorDialog();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.grpEditor.SuspendLayout();
			this.tableEditor.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numCellWidth)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numCellHeight)).BeginInit();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.colorSeperator)).BeginInit();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.colorHighlight)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lbCategories);
			this.splitContainer1.Panel1MinSize = 85;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.grpEditor);
			this.splitContainer1.Size = new System.Drawing.Size(508, 330);
			this.splitContainer1.SplitterDistance = 95;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 0;
			// 
			// lbCategories
			// 
			this.lbCategories.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbCategories.FormattingEnabled = true;
			this.lbCategories.ItemHeight = 17;
			this.lbCategories.Items.AddRange(new object[] {
            "Editor"});
			this.lbCategories.Location = new System.Drawing.Point(0, 0);
			this.lbCategories.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.lbCategories.Name = "lbCategories";
			this.lbCategories.Size = new System.Drawing.Size(95, 327);
			this.lbCategories.TabIndex = 0;
			// 
			// grpEditor
			// 
			this.grpEditor.Controls.Add(this.tableEditor);
			this.grpEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpEditor.Location = new System.Drawing.Point(0, 0);
			this.grpEditor.Name = "grpEditor";
			this.grpEditor.Size = new System.Drawing.Size(408, 330);
			this.grpEditor.TabIndex = 1;
			this.grpEditor.TabStop = false;
			this.grpEditor.Text = "Editor";
			// 
			// tableEditor
			// 
			this.tableEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableEditor.ColumnCount = 3;
			this.tableEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.44586F));
			this.tableEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.55414F));
			this.tableEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
			this.tableEditor.Controls.Add(this.lblEditorFont, 0, 0);
			this.tableEditor.Controls.Add(this.lblSampleText, 1, 0);
			this.tableEditor.Controls.Add(this.btnEditorFont, 2, 0);
			this.tableEditor.Controls.Add(this.lblCellWidth, 0, 1);
			this.tableEditor.Controls.Add(this.panel1, 1, 1);
			this.tableEditor.Controls.Add(this.lblCellHeight, 0, 2);
			this.tableEditor.Controls.Add(this.panel2, 1, 2);
			this.tableEditor.Controls.Add(this.lblSeperatorColor, 0, 3);
			this.tableEditor.Controls.Add(this.panel3, 1, 3);
			this.tableEditor.Controls.Add(this.lblHighlightColor, 0, 4);
			this.tableEditor.Controls.Add(this.panel4, 1, 4);
			this.tableEditor.Location = new System.Drawing.Point(6, 24);
			this.tableEditor.Name = "tableEditor";
			this.tableEditor.RowCount = 6;
			this.tableEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.28571F));
			this.tableEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.71429F));
			this.tableEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 134F));
			this.tableEditor.Size = new System.Drawing.Size(396, 300);
			this.tableEditor.TabIndex = 0;
			// 
			// lblEditorFont
			// 
			this.lblEditorFont.AutoSize = true;
			this.lblEditorFont.Location = new System.Drawing.Point(3, 0);
			this.lblEditorFont.Name = "lblEditorFont";
			this.lblEditorFont.Size = new System.Drawing.Size(73, 17);
			this.lblEditorFont.TabIndex = 0;
			this.lblEditorFont.Text = "Editor font:";
			// 
			// lblSampleText
			// 
			this.lblSampleText.AutoSize = true;
			this.lblSampleText.Location = new System.Drawing.Point(130, 0);
			this.lblSampleText.Name = "lblSampleText";
			this.lblSampleText.Size = new System.Drawing.Size(76, 17);
			this.lblSampleText.TabIndex = 1;
			this.lblSampleText.Text = "Sample text";
			// 
			// btnEditorFont
			// 
			this.btnEditorFont.Location = new System.Drawing.Point(316, 3);
			this.btnEditorFont.Name = "btnEditorFont";
			this.btnEditorFont.Size = new System.Drawing.Size(25, 23);
			this.btnEditorFont.TabIndex = 2;
			this.btnEditorFont.Text = "...";
			this.btnEditorFont.UseVisualStyleBackColor = true;
			this.btnEditorFont.Click += new System.EventHandler(this.btnEditorFont_Click);
			// 
			// lblCellWidth
			// 
			this.lblCellWidth.AutoSize = true;
			this.lblCellWidth.Location = new System.Drawing.Point(3, 29);
			this.lblCellWidth.Name = "lblCellWidth";
			this.lblCellWidth.Size = new System.Drawing.Size(67, 17);
			this.lblCellWidth.TabIndex = 3;
			this.lblCellWidth.Text = "Cell width:";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblPx1);
			this.panel1.Controls.Add(this.numCellWidth);
			this.panel1.Location = new System.Drawing.Point(130, 32);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(180, 30);
			this.panel1.TabIndex = 4;
			// 
			// lblPx1
			// 
			this.lblPx1.AutoSize = true;
			this.lblPx1.Location = new System.Drawing.Point(85, 5);
			this.lblPx1.Name = "lblPx1";
			this.lblPx1.Size = new System.Drawing.Size(22, 17);
			this.lblPx1.TabIndex = 1;
			this.lblPx1.Text = "px";
			// 
			// numCellWidth
			// 
			this.numCellWidth.Location = new System.Drawing.Point(3, 3);
			this.numCellWidth.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numCellWidth.Name = "numCellWidth";
			this.numCellWidth.Size = new System.Drawing.Size(76, 25);
			this.numCellWidth.TabIndex = 0;
			this.numCellWidth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// lblCellHeight
			// 
			this.lblCellHeight.AutoSize = true;
			this.lblCellHeight.Location = new System.Drawing.Point(3, 65);
			this.lblCellHeight.Name = "lblCellHeight";
			this.lblCellHeight.Size = new System.Drawing.Size(72, 17);
			this.lblCellHeight.TabIndex = 5;
			this.lblCellHeight.Text = "Cell height:";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lblPx2);
			this.panel2.Controls.Add(this.numCellHeight);
			this.panel2.Location = new System.Drawing.Point(130, 68);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(180, 24);
			this.panel2.TabIndex = 6;
			// 
			// lblPx2
			// 
			this.lblPx2.AutoSize = true;
			this.lblPx2.Location = new System.Drawing.Point(85, 1);
			this.lblPx2.Name = "lblPx2";
			this.lblPx2.Size = new System.Drawing.Size(22, 17);
			this.lblPx2.TabIndex = 3;
			this.lblPx2.Text = "px";
			// 
			// numCellHeight
			// 
			this.numCellHeight.Location = new System.Drawing.Point(3, -1);
			this.numCellHeight.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numCellHeight.Name = "numCellHeight";
			this.numCellHeight.Size = new System.Drawing.Size(76, 25);
			this.numCellHeight.TabIndex = 2;
			this.numCellHeight.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// lblSeperatorColor
			// 
			this.lblSeperatorColor.AutoSize = true;
			this.lblSeperatorColor.Location = new System.Drawing.Point(3, 95);
			this.lblSeperatorColor.Name = "lblSeperatorColor";
			this.lblSeperatorColor.Size = new System.Drawing.Size(103, 17);
			this.lblSeperatorColor.TabIndex = 7;
			this.lblSeperatorColor.Text = "Seperator color:";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnSeperatorColor);
			this.panel3.Controls.Add(this.colorSeperator);
			this.panel3.Location = new System.Drawing.Point(130, 98);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(180, 29);
			this.panel3.TabIndex = 8;
			// 
			// btnSeperatorColor
			// 
			this.btnSeperatorColor.Location = new System.Drawing.Point(29, 3);
			this.btnSeperatorColor.Name = "btnSeperatorColor";
			this.btnSeperatorColor.Size = new System.Drawing.Size(25, 23);
			this.btnSeperatorColor.TabIndex = 3;
			this.btnSeperatorColor.Text = "...";
			this.btnSeperatorColor.UseVisualStyleBackColor = true;
			this.btnSeperatorColor.Click += new System.EventHandler(this.button1_Click);
			// 
			// colorSeperator
			// 
			this.colorSeperator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.colorSeperator.Location = new System.Drawing.Point(3, 3);
			this.colorSeperator.Name = "colorSeperator";
			this.colorSeperator.Size = new System.Drawing.Size(20, 20);
			this.colorSeperator.TabIndex = 0;
			this.colorSeperator.TabStop = false;
			// 
			// lblHighlightColor
			// 
			this.lblHighlightColor.AutoSize = true;
			this.lblHighlightColor.Location = new System.Drawing.Point(3, 130);
			this.lblHighlightColor.Name = "lblHighlightColor";
			this.lblHighlightColor.Size = new System.Drawing.Size(97, 17);
			this.lblHighlightColor.TabIndex = 9;
			this.lblHighlightColor.Text = "Highlight color:";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btnHighlightColor);
			this.panel4.Controls.Add(this.colorHighlight);
			this.panel4.Location = new System.Drawing.Point(130, 133);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(180, 29);
			this.panel4.TabIndex = 10;
			// 
			// btnHighlightColor
			// 
			this.btnHighlightColor.Location = new System.Drawing.Point(29, 3);
			this.btnHighlightColor.Name = "btnHighlightColor";
			this.btnHighlightColor.Size = new System.Drawing.Size(25, 23);
			this.btnHighlightColor.TabIndex = 5;
			this.btnHighlightColor.Text = "...";
			this.btnHighlightColor.UseVisualStyleBackColor = true;
			this.btnHighlightColor.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// colorHighlight
			// 
			this.colorHighlight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.colorHighlight.Location = new System.Drawing.Point(3, 3);
			this.colorHighlight.Name = "colorHighlight";
			this.colorHighlight.Size = new System.Drawing.Size(20, 20);
			this.colorHighlight.TabIndex = 4;
			this.colorHighlight.TabStop = false;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(213, 338);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(91, 29);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "&Ok";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.Location = new System.Drawing.Point(310, 338);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(91, 29);
			this.btnApply.TabIndex = 2;
			this.btnApply.Text = "&Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(407, 338);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(91, 29);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// OptionsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(510, 379);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.splitContainer1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "OptionsForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Ascii Pumper Options";
			this.Load += new System.EventHandler(this.OptionsForm_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.grpEditor.ResumeLayout(false);
			this.tableEditor.ResumeLayout(false);
			this.tableEditor.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numCellWidth)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numCellHeight)).EndInit();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.colorSeperator)).EndInit();
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.colorHighlight)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ListBox lbCategories;
		private System.Windows.Forms.GroupBox grpEditor;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TableLayoutPanel tableEditor;
		private System.Windows.Forms.Label lblEditorFont;
		private System.Windows.Forms.Label lblSampleText;
		private System.Windows.Forms.Button btnEditorFont;
		private System.Windows.Forms.FontDialog fontdlgEditorFont;
		private System.Windows.Forms.Label lblCellWidth;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblPx1;
		private System.Windows.Forms.NumericUpDown numCellWidth;
		private System.Windows.Forms.Label lblCellHeight;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblPx2;
		private System.Windows.Forms.NumericUpDown numCellHeight;
		private System.Windows.Forms.Label lblSeperatorColor;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.PictureBox colorSeperator;
		private System.Windows.Forms.Button btnSeperatorColor;
		private System.Windows.Forms.ColorDialog colordlgSeperator;
		private System.Windows.Forms.ColorDialog colordlgHighlight;
		private System.Windows.Forms.Label lblHighlightColor;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button btnHighlightColor;
		private System.Windows.Forms.PictureBox colorHighlight;
	}
}