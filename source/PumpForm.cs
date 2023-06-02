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
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Drawing.Printing;

namespace AsciiPumper
{
	public partial class PumpForm : Form
	{
		private int childFormNumber = 0;

		public PumpForm()
		{
			InitializeComponent();
		}

		private void ShowNewForm(object sender, EventArgs e)
		{
			// Create a new instance of the child form.
			MainForm childForm = new MainForm();
			// Make it a child of this MDI form before showing it.
			childForm.MdiParent = this;
			//childForm.Text = "(Untitled)";
			childForm.FileName = "(Untitled " + ++childFormNumber + ")";
			childForm.FileModified = false;
			childForm.UndoChanged += new EventHandler<MainForm.UndoChangedEventArgs>(childForm_UndoChanged);
			childForm.RedoChanged += new EventHandler<MainForm.RedoChangedEventArgs>(childForm_RedoChanged);
			childForm.Show();
		}

		void childForm_RedoChanged(object sender, MainForm.RedoChangedEventArgs e)
		{
			if (sender is MainForm)
			{
				MainForm form = (MainForm)sender;

				if (form.RedoList.Count > 0)
					redoToolStripMenuItem.Enabled = true;
				else
					redoToolStripMenuItem.Enabled = false;
			}
		}

		void childForm_UndoChanged(object sender, MainForm.UndoChangedEventArgs e)
		{
			if (sender is MainForm)
			{
				MainForm form = (MainForm)sender;

				if (form.UndoList.Count > 0)
					undoToolStripMenuItem.Enabled = true;
				else
					undoToolStripMenuItem.Enabled = false;
			}
		}

		private void OpenFile(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				OpenFileByName(openFileDialog.FileName);
			}
		}

		private void OpenFileByName(string fn)
		{
			
			Cursor cur = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				Stream stream = File.OpenRead(fn);
				MainForm form = new MainForm();

				form.LoadStream(stream);

				stream.Close();
				form.FileName = fn;
				form.MdiParent = this;
				form.FileModified = false;
				form.UndoChanged += new EventHandler<MainForm.UndoChangedEventArgs>(childForm_UndoChanged);
				form.RedoChanged += new EventHandler<MainForm.RedoChangedEventArgs>(childForm_RedoChanged);
				form.Show();

			}
			finally
			{
				Cursor.Current = cur;
			}
			AddFileToRecentFiles(fn);
		}

		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ActiveMdiChild == null)
			{
				MessageBox.Show(this, "No files are loaded.");
				return;
			}
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				Stream stream = saveFileDialog.OpenFile();
				StreamWriter writer = new StreamWriter(stream);
				if (this.ActiveMdiChild is MainForm)
				{
					((MainForm)this.ActiveMdiChild).FileName = saveFileDialog.FileName;
					((MainForm)this.ActiveMdiChild).FileModified = false;
					writer.Write(((MainForm)this.ActiveMdiChild).GetIRCString(false));
					writer.Close();
				}

				AddFileToRecentFiles(saveFileDialog.FileName);
			}
		}

		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void CutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
		}

		private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
		}

		private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// TODO: Use System.Windows.Forms.Clipboard.GetText() or System.Windows.Forms.GetData to retrieve information from the clipboard.
		}

		private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			toolStrip.Visible = toolBarToolStripMenuItem.Checked;
		}

		private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			statusStrip.Visible = statusBarToolStripMenuItem.Checked;
		}

		private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.ArrangeIcons);
		}

		private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (Form childForm in MdiChildren)
			{
				childForm.Close();
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			(new AboutBox1()).ShowDialog(this);
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OptionsForm optionsform = new OptionsForm();
			optionsform.SettingsSaved += new EventHandler<OptionsForm.SettingsSavedEventArgs>(optionsform_SettingsSaved);
			optionsform.ShowDialog(this);

		}

		private void AddFileToRecentFiles(string fn)
		{
			Program.Settings.RecentFiles.Remove(fn);
			Program.Settings.RecentFiles.Add(fn);
			while (Program.Settings.RecentFiles.Count > 10)
			{
				Program.Settings.RecentFiles.RemoveAt(0);
			}
			ReloadRecentFiles();
		}

		void optionsform_SettingsSaved(object sender, OptionsForm.SettingsSavedEventArgs e)
		{
			foreach (Form form in this.MdiChildren)
			{
				if (form is MainForm)
				{
					((MainForm)form).RepaintCanvas();
				}

			}
		}

		private void ReloadRecentFiles()
		{
			openRecentToolStripMenuItem.DropDownItems.Clear();
			if (Program.Settings.RecentFiles == null)
			{
				Program.Settings.RecentFiles = new System.Collections.Specialized.StringCollection();
			}
			for (int i = Program.Settings.RecentFiles.Count - 1; i >= 0; i--)
			{
				openRecentToolStripMenuItem.DropDownItems.Add(Program.Settings.RecentFiles[i], null, new EventHandler(OpenRecentHandler));
			}
			
		}

		private void PumpForm_Load(object sender, EventArgs e)
		{
			new Thread(new ThreadStart(this.CheckForNewVersion)).Start();

			ReloadRecentFiles();

			string[] args = Environment.GetCommandLineArgs();
			if ( args.Length > 1 )
				OpenFileByName(args[1]);
			else
				ShowNewForm(this, EventArgs.Empty);
		}

		private void OpenRecentHandler(object sender, EventArgs e)
		{
			ToolStripMenuItem menu = (ToolStripMenuItem) sender;

			// see if file is open already
			foreach (Form form in this.MdiChildren)
			{
				if (form is MainForm)
				{
					if (((MainForm)form).FileName == menu.Text)
					{
						form.Activate();
						return;
					}
				}
			}

			// open file
			OpenFileByName(menu.Text);
		}

		private void CheckForNewVersion()
		{
			// this is really non-critical code so let's discard all exceptions and go on with life ok?
			try
			{
				WebRequest request = WebRequest.Create("http://code.google.com/p/asciipumper");

				// Get the response.
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				// Get the stream containing content returned by the server.
				Stream dataStream = response.GetResponseStream();
				// Open the stream using a StreamReader for easy access.
				StreamReader reader = new StreamReader(dataStream);
				// Read the content.
				string responseFromServer = reader.ReadToEnd();
				Regex versionregex = new Regex(@"Latest release version: (\d+)\.(\d+)\.(\d+)\.(\d+)", RegexOptions.Multiline);
				MatchCollection matches = versionregex.Matches(responseFromServer);
				if (matches.Count >= 1 && matches[0].Captures.Count >= 1)
				{
					int v1, v2, v3, v4;
					v1 = int.Parse(matches[0].Groups[1].Value);
					v2 = int.Parse(matches[0].Groups[2].Value);
					v3 = int.Parse(matches[0].Groups[3].Value);
					v4 = int.Parse(matches[0].Groups[4].Value);

					Version v = Assembly.GetExecutingAssembly().GetName().Version;
					bool old = false;
					if (v.Major < v1)
						old = true;
					if (v.Major == v1 && v.Minor < v2)
						old = true;
					if (v.Major == v1 && v.Minor == v2 && v.Build < v3)
						old = true;
					if (v.Major == v1 && v.Minor == v2 && v.Build == v3 && v.Revision < v4)
						old = true;

					if (old)
					{
						DialogResult res = MessageBox.Show(string.Format("A new version of Ascii Pumper is available.\r\nYou have: {0}.\r\nLatest release: {1}.{2}.{3}.{4}.\r\n\r\nVisit homepage?", v.ToString(), v1, v2, v3, v4), "New Ascii Pumper version", MessageBoxButtons.YesNo);
						if (res == DialogResult.Yes)
						{
							ProcessStartInfo pi = new ProcessStartInfo("http://code.google.com/p/asciipumper/");
							Process.Start(pi);
						}
					}
				}

			}
			catch (Exception e)
			{
				// this is really non-critical code so let's discard all exceptions and go on with life ok?
			}


		}

		private void saveToolStripButton_Click(object sender, EventArgs e)
		{
			if (this.ActiveMdiChild == null)
			{
				MessageBox.Show(this, "No files are loaded.");
				return;
			}

			if (this.ActiveMdiChild is MainForm)
			{
				((MainForm)this.ActiveMdiChild).SaveDocument();
				AddFileToRecentFiles(((MainForm)this.ActiveMdiChild).FileName );
			}

		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			saveToolStripButton_Click(sender, e);
		}

		private void imageImporterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Supported images (*.bmp, *.jpeg, *.jpg, *.png, *.gif)|*.bmp;*.jpeg;*.jpg;*.png;*.gif|Bitmaps (*.bmp)|*.bmp|GIFs (*.gif)|*.gif|JPEGs (*.jpg,*.jpeg)|*.jpeg;*.jpg|PNGs (*.png)|*.png|All Files (*.*)|*.*";
			DialogResult res = ofd.ShowDialog(this);
			if (res == DialogResult.OK)
			{
				
				// Create a new instance of the child form.
				MainForm childForm = new MainForm();
				// Make it a child of this MDI form before showing it.
				childForm.MdiParent = this;
				//childForm.Text = "(Untitled)";
				childForm.FileName = "(Imported image " + ++childFormNumber + ")";
				childForm.FileModified = false;
				childForm.Show();
				childForm.ImportImage(ofd.FileName);
				
			}
		}

		private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PrintPreviewDialog previewdlg = new PrintPreviewDialog();
			previewdlg.Document = new System.Drawing.Printing.PrintDocument();
			previewdlg.Document.PrintPage += new PrintPageEventHandler(Document_PrintPage);
			previewdlg.ShowDialog(this);
		}

		void Document_PrintPage(object sender, PrintPageEventArgs e)
		{
			if (this.ActiveMdiChild is MainForm)
			{
				((MainForm)this.ActiveMdiChild).PrintToGraphicDevice(e.Graphics, e);
			}
		}

		private void printToolStripButton_Click(object sender, EventArgs e)
		{
			PrintDialog printdlg = new PrintDialog();
			printdlg.Document = new PrintDocument();
			printdlg.Document.PrintPage += new PrintPageEventHandler(Document_PrintPage);
			if (printdlg.ShowDialog(this) == DialogResult.OK)
				printdlg.Document.Print();

		}

		private void printPreviewToolStripButton_Click(object sender, EventArgs e)
		{
			printPreviewToolStripMenuItem_Click(sender, e);
		}

		private void printSetupToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void printToolStripMenuItem_Click(object sender, EventArgs e)
		{
			printToolStripButton_Click(sender, e);
		}

		private void redoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ActiveMdiChild is MainForm)
			{
				MainForm form = (MainForm)this.ActiveMdiChild;

				form.Redo();
			}
		}

		private void undoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ActiveMdiChild is MainForm)
			{
				MainForm form = (MainForm)this.ActiveMdiChild;

				form.Undo();
			}
		}

		private void PumpForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Program.Settings.Save();
		}

		private void rEADMETXTToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ProcessStartInfo pi = new ProcessStartInfo( /*Assembly.GetExecutingAssembly().Location*/ "README.TXT");
			Process.Start(pi);
		}

		private void PumpForm_MdiChildActivate(object sender, EventArgs e)
		{
			childForm_UndoChanged(this.ActiveMdiChild, MainForm.UndoChangedEventArgs.Empty);
			childForm_RedoChanged(this.ActiveMdiChild, MainForm.RedoChangedEventArgs.Empty);

		}
	}
}
