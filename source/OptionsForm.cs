using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AsciiPumper
{
	public partial class OptionsForm : Form
	{
		public OptionsForm()
		{
			InitializeComponent();
			fontdlgEditorFont.Font = new Font(Program.Settings.PaintFontName, Program.Settings.PaintFontSize);
			lblSampleText.Font = new Font(Program.Settings.PaintFontName, Program.Settings.PaintFontSize);
			colorSeperator.BackColor = Program.Settings.SeperatorColor;
			colorHighlight.BackColor = Program.Settings.HighlightColor;
			numCellHeight.Value = Program.Settings.CellHeight;
			numCellWidth.Value = Program.Settings.CellWidth;
			colordlgHighlight.Color = Program.Settings.HighlightColor;
			colordlgSeperator.Color = Program.Settings.SeperatorColor;


		}

		public class SettingsSavedEventArgs : EventArgs
		{
			public static readonly new SettingsSavedEventArgs Empty = new SettingsSavedEventArgs();
		}

		public event EventHandler<SettingsSavedEventArgs> SettingsSaved;

		protected virtual void OnSettingsSaved(SettingsSavedEventArgs e)
		{
			EventHandler<SettingsSavedEventArgs> handler = SettingsSaved;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		private void OptionsForm_Load(object sender, EventArgs e)
		{
			lbCategories.SelectedValue = "Editor";

		}

		private void ApplySettings()
		{
			Cursor cur = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				if (fontdlgEditorFont.Font.Name != Program.Settings.PaintFontName)
				{
					Program.Settings.PaintFontName = fontdlgEditorFont.Font.Name;
				}
				if (fontdlgEditorFont.Font.Size != Program.Settings.PaintFontSize)
				{
					Program.Settings.PaintFontSize = fontdlgEditorFont.Font.Size;
				}
				if (colordlgHighlight.Color != Program.Settings.HighlightColor)
					Program.Settings.HighlightColor = colordlgHighlight.Color;
				if (colordlgSeperator.Color != Program.Settings.SeperatorColor)
					Program.Settings.SeperatorColor = colordlgSeperator.Color;
				if (numCellHeight.Value != Program.Settings.CellHeight)
					Program.Settings.CellHeight = (int)numCellHeight.Value;
				if (numCellWidth.Value != Program.Settings.CellWidth)
					Program.Settings.CellWidth = (int) numCellWidth.Value;

				Program.Settings.Save();
				this.OnSettingsSaved(SettingsSavedEventArgs.Empty);
			}
			finally
			{
				Cursor.Current = cur;
			}
			
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			ApplySettings();
			this.DialogResult = DialogResult.OK;
			this.Close();

		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			ApplySettings();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();

		}

		private void btnEditorFont_Click(object sender, EventArgs e)
		{
			DialogResult res = fontdlgEditorFont.ShowDialog(this);
			if (res == DialogResult.OK)
			{
				lblSampleText.Font = fontdlgEditorFont.Font;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult res = colordlgSeperator.ShowDialog(this);
			if (res == DialogResult.OK)
				colorSeperator.BackColor = colordlgSeperator.Color;

		}

		private void button1_Click_1(object sender, EventArgs e)
		{

			DialogResult res = colordlgHighlight.ShowDialog(this);
			if (res == DialogResult.OK)
				colorHighlight.BackColor = colordlgHighlight.Color;

		}
	}
}