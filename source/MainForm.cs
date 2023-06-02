#region Copyright (c) 2007, PP4L Software
/************************************************************************************

Copyright  2007, PP4L Software
Author:	Lampiasis <lampiasis@dvolker.com>

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

'***********************************************************************************/
#endregion


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime;
using System.Diagnostics;
using System.IO;
using System.Drawing.Printing;


namespace AsciiPumper
{
	public partial class MainForm : Form
	{

		public void Undo()
		{
			AsciiPaintCanvas.Undo();
		}

		public void Redo()
		{
			AsciiPaintCanvas.Redo();
		}

		public Stack<IUndoableAction> UndoList
		{
			get { return AsciiPaintCanvas.UndoList; }
		}

		public Stack<IUndoableAction> RedoList
		{
			get { return AsciiPaintCanvas.RedoList; }
		}

		private string m_FileName = "(Untitled)";

		/// <summary>
		/// Gets or sets the FileName.
		/// </summary>
		public string FileName
		{
			get { return m_FileName; }
			set { m_FileName = value; this.Text = m_FileName + (m_FileModified ? "" : "*"); } 
		}

		private bool m_FileModified = false;

		/// <summary>
		/// Gets or sets the FileModified.
		/// </summary>
		public bool FileModified
		{
			get { return m_FileModified; }
			set {
				m_FileModified = value;
				if (value == true)
					this.Text = m_FileName + "*";
				else
				{
					this.Text = m_FileName;
					AsciiPaintCanvas.Modified = false;
				}
			}
		}

		public void LoadStream(Stream stream)
		{
			m_LoadingFile = true;
			
			AsciiPaintCanvas.DontRepaint = true;
			try
			{
				AsciiPaintCanvas.LoadStream(stream);
				numColumns.Value = AsciiPaintCanvas.Columns;
				numRows.Value = AsciiPaintCanvas.Rows;
				m_LoadingFile = false;
			}
			finally
			{
				AsciiPaintCanvas.DontRepaint = false;
				AsciiPaintCanvas.CompleteRepaint();

			}
			
		}



		public MainForm()
		{
			InitializeComponent();
			//this.Icon = new Icon(typeof(MainForm), "MainIcon");

			AsciiPaintCanvas.Columns = (int)numColumns.Value;
			AsciiPaintCanvas.Rows = (int)numRows.Value;
			ColorPalette pal = AsciiPaintCanvas.Colors;
			colorLMB.BackColor = pal[AsciiPaintCanvas.LeftMouseColor];
			colorMMB.BackColor = pal[AsciiPaintCanvas.MiddleMouseColor];
			colorRMB.BackColor = pal[AsciiPaintCanvas.RightMouseColor];
			//AsciiPumper.Properties.Settings.Default.

			/*AsciiPaintCanvas.Font = new Font("Consolas", 10);
			if (AsciiPaintCanvas.Font.Name != "Consolas")
				AsciiPaintCanvas.Font = new Font("Fixedsys", 9);
			*/
			this.AsciiPaintCanvas.Font = new Font((string) Program.Settings["PaintFontName"] , (float) Program.Settings["PaintFontSize"]);
			AsciiPaintCanvas.CellWidth = (int)Program.Settings["CellWidth"];
			AsciiPaintCanvas.CellHeight = (int)Program.Settings["CellHeight"];
			numColumns.Value = (int)Program.Settings["Columns"];
			numRows.Value = (int)Program.Settings["Rows"];
			ColorSelector.ButtonColorChangedEventArgs ea = new ColorSelector.ButtonColorChangedEventArgs((byte)Program.Settings["LMBColor"], new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
			this.colorSelector1_ButtonColorChanged(this, ea);
			ea = new ColorSelector.ButtonColorChangedEventArgs((byte)Program.Settings["MMBColor"], new MouseEventArgs(MouseButtons.Middle, 0, 0, 0, 0));
			this.colorSelector1_ButtonColorChanged(this, ea);
			ea = new ColorSelector.ButtonColorChangedEventArgs((byte)Program.Settings["RMBColor"], new MouseEventArgs(MouseButtons.Right, 0, 0, 0, 0));
			this.colorSelector1_ButtonColorChanged(this, ea);
			

			this.checkLMBfg.Checked = Program.Settings.LMBIsForeground;
			this.checkMMBfg.Checked = Program.Settings.MMBIsForeground;
			this.checkRMBfg.Checked = Program.Settings.RMBIsForeground;
			//P//rogram.Settings.PropertyChanged += new PropertyChangedEventHandler(Settings_PropertyChanged);

			this.chkWatermark.Checked = Program.Settings.ShouldWatermark;

			AsciiPaintCanvas.CanvasModified += new EventHandler<PaintCanvas.CanvasModifiedEventArgs>(AsciiPaintCanvas_CanvasModified);
			AsciiPaintCanvas.UndoChanged += new EventHandler<PaintCanvas.UndoChangedEventArgs>(AsciiPaintCanvas_UndoChanged);
			AsciiPaintCanvas.RedoChanged += new EventHandler<PaintCanvas.RedoChangedEventArgs>(AsciiPaintCanvas_RedoChanged);
		}

		void AsciiPaintCanvas_RedoChanged(object sender, PaintCanvas.RedoChangedEventArgs e)
		{
			OnRedoChanged(RedoChangedEventArgs.Empty);
		}

		void AsciiPaintCanvas_UndoChanged(object sender, PaintCanvas.UndoChangedEventArgs e)
		{
			OnUndoChanged(UndoChangedEventArgs.Empty);
		}

		public class UndoChangedEventArgs : EventArgs
		{
			public static readonly new UndoChangedEventArgs Empty = new UndoChangedEventArgs();
		}

		public event EventHandler<UndoChangedEventArgs> UndoChanged;

		protected virtual void OnUndoChanged(UndoChangedEventArgs e)
		{
			EventHandler<UndoChangedEventArgs> handler = UndoChanged;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		public class RedoChangedEventArgs : EventArgs
		{
			public static readonly new RedoChangedEventArgs Empty = new RedoChangedEventArgs();
		}

		public event EventHandler<RedoChangedEventArgs> RedoChanged;

		protected virtual void OnRedoChanged(RedoChangedEventArgs e)
		{
			EventHandler<RedoChangedEventArgs> handler = RedoChanged;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		void AsciiPaintCanvas_CanvasModified(object sender, PaintCanvas.CanvasModifiedEventArgs e)
		{
			FileModified = true;
		}

		void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			//AsciiPaintCanvas.CompleteRepaint();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			
		}

		private void numColumns_ValueChanged(object sender, EventArgs e)
		{
			if ( !this.m_LoadingFile )
				AsciiPaintCanvas.Columns = (int) numColumns.Value;

		}

		private void numRows_ValueChanged(object sender, EventArgs e)
		{
			if ( !this.m_LoadingFile )
				AsciiPaintCanvas.Rows = (int) numRows.Value;
		}

		private void colorSelector1_ButtonColorChanged(object sender, ColorSelector.ButtonColorChangedEventArgs e)
		{
			switch (e.MouseEvent.Button)
			{
							
				case MouseButtons.Left:
					AsciiPaintCanvas.LeftMouseColor = e.ColorIndex;
					colorLMB.BackColor = colorSelector1.Colors[e.ColorIndex];
					Program.Settings.LMBColor = e.ColorIndex;
					break;
				case MouseButtons.Middle:
					AsciiPaintCanvas.MiddleMouseColor = e.ColorIndex;
					colorMMB.BackColor = colorSelector1.Colors[e.ColorIndex];
					Program.Settings.MMBColor = e.ColorIndex;
					break;
				case MouseButtons.Right:
					AsciiPaintCanvas.RightMouseColor = e.ColorIndex;
					colorRMB.BackColor = colorSelector1.Colors[e.ColorIndex];
					Program.Settings.RMBColor = e.ColorIndex;
					break;
				default:
					throw new Exception("Invalid mouse button color changed.");
			}
		}

		public const string WaterMark = "http://code.google.com/p/asciipumper/ ";

		public char WatermarkCharAtPos(int pos)
		{
			string watermark = txtWatermark.Text;
			if (watermark == "")
				watermark = WaterMark;

			return watermark[pos % watermark.Length];
		}
		
		private const char ColorControl = '\x0003';
		private const char UnderlineControl = '\x001F';
		private const char BoldControl = '\x0002';
		private const char PlainControl = '\x000F';
		private const char ReverseControl = '\x0016';

		public string GetIRCString( bool watermark)
		{
			StringBuilder sb = new StringBuilder();
			CellInfo lastcell;
			int rowcount = 0;
			

			foreach (List<CellInfo> row in AsciiPaintCanvas.CellRows)
			{
				rowcount++;
				if (rowcount > AsciiPaintCanvas.Rows)
					break;

				// something that will not be used normally so that color is always printed at beginning of line
				lastcell = new CellInfo('z', 100, 100);

				int cellcount = 0;
				
				foreach (CellInfo cell in row)
				{	// FIXME: check for digits and use two digit color code.
					cellcount++;
					if (cellcount > AsciiPaintCanvas.Columns)
						break;
					if (lastcell.Bold != cell.Bold)
						sb.Append(BoldControl);
					if (lastcell.Underlined != cell.Underlined)
						sb.Append(UnderlineControl);
					if (cell.Character == ' ' && watermark)
					{
						cell.ForeColor = cell.BackColor;
						char character = WatermarkCharAtPos(cellcount - 1);
						if (lastcell.BackColor != cell.BackColor || lastcell.ForeColor != cell.BackColor)
						{
							if (cell.BackColor < 10 && char.IsDigit(character))
								sb.AppendFormat(ColorControl + "{0},0{1}{2}", cell.ForeColor, cell.BackColor, character);
							else
								sb.AppendFormat(ColorControl + "{0},{1}{2}", cell.ForeColor, cell.BackColor, character);
						}
						else
							sb.Append(character);
					}
					else if (lastcell.BackColor != cell.BackColor)
					{
						if (char.IsDigit(cell.Character) || cell.Character == ',' )
						{
							if (cell.BackColor < 10 && char.IsDigit(cell.Character))
								sb.AppendFormat(ColorControl + "{0},0{1}{2}", cell.ForeColor, cell.BackColor, cell.Character);
							else
								sb.AppendFormat(ColorControl + "{0},{1}{2}", cell.ForeColor, cell.BackColor, cell.Character);
						}
						else
							sb.AppendFormat(ColorControl + "{0},{1}{2}", cell.ForeColor, cell.BackColor, cell.Character);
					}
					else if (lastcell.ForeColor != cell.ForeColor)
					{
						if (char.IsDigit(cell.Character))
						{
							if (cell.ForeColor < 10 && char.IsDigit(cell.Character))
								sb.AppendFormat(ColorControl + "0{0}{1}", cell.ForeColor, cell.Character);
							else
								sb.AppendFormat(ColorControl + "{0}{1}", cell.ForeColor, cell.Character);
						}
						else if (cell.Character == ',')
						{
							if (cell.BackColor < 10 && char.IsDigit(cell.Character))
								sb.AppendFormat(ColorControl + "{0},0{1}{2}", cell.ForeColor, cell.BackColor, cell.Character);
							else
								sb.AppendFormat(ColorControl + "{0},{1}{2}", cell.ForeColor, cell.BackColor, cell.Character);
						}
						else
							sb.AppendFormat(ColorControl + "{0}{1}", cell.ForeColor, cell.Character);
					}
					else
						sb.Append(cell.Character);
					lastcell = cell;
				}
				sb.Append("\r\n");
			}
			return sb.ToString();
		}
    

		private void button1_Click(object sender, EventArgs e)
		{

			Cursor cur = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				Clipboard.SetText(GetIRCString(chkWatermark.Checked), TextDataFormat.Text);
			}
			finally
			{
				Cursor.Current = cur;
			}
			
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutBox1 about = new AboutBox1();
			about.ShowDialog(this);
		}

		public void SaveDocument()
		{
			if ( File.Exists(m_FileName) )
			{
				Stream stream = File.OpenWrite(m_FileName);
				StreamWriter writer = new StreamWriter(stream);
				writer.WriteLine(GetIRCString(false));

				writer.Close();
				this.FileModified = false;
			}
			else
				saveAsToolStripMenuItem_Click(this, EventArgs.Empty);
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (AsciiPaintCanvas.Modified == true)
			{
				DialogResult res = MessageBox.Show(this, m_FileName + " has been modified. Would you like to save changes?", "Save changes?", MessageBoxButtons.YesNoCancel);
				if (res == DialogResult.Yes)
				{
					if ( File.Exists(m_FileName) )
					{
						Stream stream = File.OpenWrite(m_FileName);
						StreamWriter writer = new StreamWriter(stream);
						writer.WriteLine(GetIRCString(false));

						writer.Close();
						this.m_FileModified = false;
					}
					else
						saveAsToolStripMenuItem_Click(this, EventArgs.Empty);
				}
				else if (res == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
				else if (res == DialogResult.No)
				{

				}
			}

			Program.Settings.PropertyChanged -= new PropertyChangedEventHandler(Settings_PropertyChanged);

			Program.Settings.LMBIsForeground = checkLMBfg.Checked;
			Program.Settings.MMBIsForeground = checkMMBfg.Checked;
			Program.Settings.RMBIsForeground = checkRMBfg.Checked;

			Program.Settings.ShouldWatermark = chkWatermark.Checked;

			Program.Settings.Save();
		}

		private void checkLMBfg_CheckedChanged(object sender, EventArgs e)
		{
			AsciiPaintCanvas.LeftMouseIsForeground = checkLMBfg.Checked;

		}

		private void checkMMBfg_CheckedChanged(object sender, EventArgs e)
		{
			AsciiPaintCanvas.MiddleMouseIsForeground = checkMMBfg.Checked;
		}

		private void checkRMBfg_CheckedChanged(object sender, EventArgs e)
		{
			AsciiPaintCanvas.RightMouseIsForeground = checkRMBfg.Checked;
		}

		private void linklabelVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ProcessStartInfo pi = new ProcessStartInfo("http://code.google.com/p/asciipumper/");
			Process.Start(pi);
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult res = saveFileDialog.ShowDialog(this);
			if (res == DialogResult.OK)
			{
				Stream stream = saveFileDialog.OpenFile();
				FileName = saveFileDialog.FileName;
				StreamWriter writer = new  StreamWriter(stream);
				writer.WriteLine(GetIRCString(false));
				
				writer.Close();
				this.FileModified = false;
			
			}
		}

		private bool m_LoadingFile = false;

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult res = openFileDialog.ShowDialog(this);
			if (res == DialogResult.OK)
			{
				Cursor cur = Cursor.Current;
				Cursor.Current = Cursors.WaitCursor;
				try
				{
					m_LoadingFile = true;
					Stream stream = openFileDialog.OpenFile();
					AsciiPaintCanvas.LoadStream(stream);
					stream.Close();
					numColumns.Value = AsciiPaintCanvas.Columns;
					numRows.Value = AsciiPaintCanvas.Rows;
					m_LoadingFile = false;
				}
				finally
				{
					Cursor.Current = cur;
				}
				

			}
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			

		}

		void form_SettingsSaved(object sender, OptionsForm.SettingsSavedEventArgs e)
		{
			AsciiPaintCanvas.CompleteRepaint();
		}

		public void RepaintCanvas()
		{
			AsciiPaintCanvas.CompleteRepaint();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void radioPaintBrush_CheckedChanged(object sender, EventArgs e)
		{
			if (radioPaintBrush.Checked)
				AsciiPaintCanvas.PaintMode = PaintCanvas.PaintModes.PaintBrush;
		}

		private void radioFill_CheckedChanged(object sender, EventArgs e)
		{
			if (radioFill.Checked)
				AsciiPaintCanvas.PaintMode = PaintCanvas.PaintModes.Fill;
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{

		}

		private void chkWatermark_CheckedChanged(object sender, EventArgs e)
		{

		}

		public void ImportImage(string filename)
		{
			AsciiPaintCanvas.ImportImage(filename);
			numColumns.Value = AsciiPaintCanvas.Columns;
			numRows.Value = AsciiPaintCanvas.Rows;
		}

		private void txtWatermark_Enter(object sender, EventArgs e)
		{
			txtWatermark.SelectAll();
		}

		public void PrintToGraphicDevice(Graphics graphics, PrintPageEventArgs e)
		{
			AsciiPaintCanvas.PrintToGraphicDevice(graphics, e);
		}

		private void radioBold_CheckedChanged(object sender, EventArgs e)
		{
			if (radioBold.Checked == true)
				AsciiPaintCanvas.PaintMode = PaintCanvas.PaintModes.Bold;
		}

		private void radioUnderline_CheckedChanged(object sender, EventArgs e)
		{
			if (radioUnderline.Checked == true)
				AsciiPaintCanvas.PaintMode = PaintCanvas.PaintModes.Underline;
		}

		private void radioRemoveFormatting_CheckedChanged(object sender, EventArgs e)
		{
			if (radioRemoveFormatting.Checked == true)
				AsciiPaintCanvas.PaintMode = PaintCanvas.PaintModes.RemoveFormatting;
		}
	}
}