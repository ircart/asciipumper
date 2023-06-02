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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Printing;


namespace AsciiPumper
{
	public partial class PaintCanvas : UserControl
	{
		public PaintCanvas()
		{
			InitializeComponent();

			CellRows = new List<List<CellInfo>>();
			ResizeCellRows();


			UpdateSeperatorPen();
			PaintCanvas_SizeChanged(this, EventArgs.Empty);
			PaintIntoBackground();
			Program.Settings.PropertyChanged += new PropertyChangedEventHandler(Settings_PropertyChanged);

		}


		public Stack<IUndoableAction> UndoList = new Stack<IUndoableAction>();
		public Stack<IUndoableAction> RedoList = new Stack<IUndoableAction>();
		public IUndoableAction CurrentAction;

		private bool m_Modified;

		/// <summary>
		/// Gets or sets the Modified.
		/// </summary>
		public bool Modified
		{
			get { return m_Modified; }
			set
			{
				if (m_Modified != value)
				{
					if (value == true)
						OnCanvasModified(CanvasModifiedEventArgs.Empty);
					m_Modified = value;
				}
			}
		}

		public class CanvasModifiedEventArgs : EventArgs
		{
			public static readonly new CanvasModifiedEventArgs Empty = new CanvasModifiedEventArgs();
		}

		public event EventHandler<CanvasModifiedEventArgs> CanvasModified;

		protected virtual void OnCanvasModified(CanvasModifiedEventArgs e)
		{
			EventHandler<CanvasModifiedEventArgs> handler = CanvasModified;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		public void CompleteRepaint()
		{
			this.PaintIntoBackground();
			this.Invalidate();
		}

		void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			bool invalidate = false;

			if ( e.PropertyName == "PaintFontName" )
			{
				this.Font = new Font((string) Program.Settings["PaintFontName"], (float) Program.Settings["PaintFontSize"]);
				invalidate = true;
			}
			if (e.PropertyName == "PaintFontSize")
			{
				this.Font = new Font((string) Program.Settings["PaintFontName"], (float) Program.Settings["PaintFontSize"]);
				invalidate = true;
			}
			if (e.PropertyName == "CellWidth")
			{
				this.CellWidth = Program.Settings.CellWidth;
				invalidate = true;
			}
			if (e.PropertyName == "CellHeight")
			{
				this.CellHeight = Program.Settings.CellHeight;
				invalidate = true;
			}
			if (e.PropertyName == "SeperatorColor")
				this.SeperatorColor = Program.Settings.SeperatorColor;
			if (e.PropertyName == "HighlightColor")
				this.HighlightColor = Program.Settings.HighlightColor;

			if (invalidate)
			{
			//	this.PaintIntoBackground();
			//	this.Invalidate();
			}
		}

		private void ResizeCellRows( )
		{
			for (int rows = 0; rows < this.Rows; rows++)
			{
				if ( CellRows.Count < rows + 1 ) 
					CellRows.Add(new List<CellInfo>(this.Columns));
				for (int cols = 0; cols < this.Columns; cols++)
				{
					if ( CellRows[rows].Count < cols + 1 )
						CellRows[rows].Add( new CellInfo() );
				}
			}
		}
    

		private void PaintCanvas_Paint(object sender, PaintEventArgs e)
		{
#if false
			// test
			Font consolas = new Font("Consolas", 18);
			m_PaintBuffer.DrawString("Test", consolas, Brushes.BlueViolet, 10, consolas.Height);
			SizeF size = m_PaintBuffer.MeasureString("Test", consolas);
			m_PaintBuffer.DrawString(size.Width.ToString(), consolas, Brushes.Blue, size.Width + 10, consolas.Height);
			// test
			Font arial = new Font("Arial", 10);
			m_PaintBuffer.DrawString("Test", arial, Brushes.BlueViolet, 10, 40);
			size = m_PaintBuffer.MeasureString("Test", arial);
			m_PaintBuffer.DrawString(size.Width.ToString(), arial, Brushes.Blue, size.Width + 10, 40);
#endif
		}

		private Image m_PaintImage;

		private Graphics m_PaintBuffer;


		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			// PaintIntoBackground();
			e.Graphics.DrawImage(m_PaintImage, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel); // DrawImageUnscaledAndClipped(m_PaintImage., e.ClipRectangle);


		}

		public void PrintToGraphicDevice(Graphics graphics, PrintPageEventArgs e )
		{
			Rectangle printRect = new Rectangle(
				e.MarginBounds.Top, e.MarginBounds.Left ,
				Math.Min(m_PaintImage.Width, e.MarginBounds.Right - e.MarginBounds.Left),
				Math.Min(m_PaintImage.Height, e.MarginBounds.Bottom - e.MarginBounds.Top)
				);
			
			graphics.DrawImage(m_PaintImage, printRect, new Rectangle(0, 0, m_PaintImage.Width, m_PaintImage.Height), GraphicsUnit.Pixel);
		}

		private void ResizeByCellSize()
		{
			this.Height = /*(m_Rows * ( m_SeperatorWidth / 2)) +*/ (m_Rows * m_CellHeight);
			this.Width = (m_Columns * (m_SeperatorWidth / 2)) + (m_Columns * m_CellWidth);

		} 

		private Point m_SelectedCellPosition = new Point(0,0);

		/// <summary>
		/// Gets or sets the SelectedCellPosition.
		/// </summary>
		public Point SelectedCellPosition
		{
			get { return m_SelectedCellPosition; }
			set { RepaintSingleCell(m_SelectedCellPosition); m_SelectedCellPosition = value; RepaintSingleCell(m_SelectedCellPosition); }
		}

		#region Highlight Properties and methods
		private void UpdateHighlightPen()
		{
			m_HighlightPen = new Pen(m_HighlightColor, m_HighlightWidth);
			
		}

		private Pen m_HighlightPen = Pens.OldLace;

		private Color m_HighlightColor = Color.OldLace;

		/// <summary>
		/// Gets or sets the HighlightColor.
		/// </summary>
		public Color HighlightColor
		{
			get { return m_HighlightColor; }
			set { m_HighlightColor = value; UpdateHighlightPen(); PaintIntoBackground();  this.Invalidate(); }
		}

		private int m_HighlightWidth = 2;

		/// <summary>
		/// Gets or sets the HighlightWidth.
		/// </summary>
		public int HighlightWidth
		{
			get { return m_HighlightWidth; }
			set { m_HighlightWidth = value; UpdateHighlightPen(); PaintIntoBackground(); this.Invalidate(); }
		}
		#endregion

		private int m_SeperatorWidth = 1;

		/// <summary>
		/// Gets or sets the SeperatorWidth.
		/// </summary>
		public int SeperatorWidth
		{
			get { return m_SeperatorWidth; }
			set { m_SeperatorWidth = value; UpdateSeperatorPen(); ResizeByCellSize(); PaintIntoBackground();  this.Invalidate(); }
		}

		private int m_CellWidth = 5;

		/// <summary>
		/// Gets or sets the CellWidth.
		/// </summary>
		public int CellWidth
		{
			get { return m_CellWidth; }
			set { m_CellWidth = value; ResizeByCellSize(); PaintIntoBackground(); this.Invalidate(); }
		}

		private int m_CellHeight = 10;

		/// <summary>
		/// Gets or sets the CellHeight.
		/// </summary>
		public int CellHeight
		{
			get { return m_CellHeight; }
			set { m_CellHeight = value; ResizeByCellSize(); PaintIntoBackground(); this.Invalidate(); }
		}

		private int m_Columns = 60;

		/// <summary>
		/// Gets or sets the Columns.
		/// </summary>
		public int Columns 
		{
			get { return m_Columns; }
			set { m_Columns = value; ResizeCellRows(); ResizeByCellSize(); PaintIntoBackground(); this.Invalidate(); }
		}

		private int m_Rows = 20;

		/// <summary>
		/// Gets or sets the Rows.
		/// </summary>
		public int Rows
		{
			get { return m_Rows; }
			set { m_Rows = value; ResizeCellRows(); ResizeByCellSize(); PaintIntoBackground();  this.Invalidate(); }
		}


		private Color m_SeperatorColor = Color.DarkGray;

		/// <summary>
		/// Gets or sets the SeperatorColor.
		/// </summary>
		public Color SeperatorColor
		{
			get { return m_SeperatorColor; }
			set { m_SeperatorColor = value; UpdateSeperatorPen(); this.Invalidate(); }
		}

		private Pen m_SeperatorPen;

		private void UpdateSeperatorPen()
		{
			m_SeperatorPen = new Pen(m_SeperatorColor, m_SeperatorWidth);
		}

		private void RepaintSingleCell(Point cellpos)
		{
			if ( m_DontRepaint )
				return;

			if (cellpos.X < 0 || cellpos.Y < 0 || cellpos.Y >= CellRows.Count || cellpos.X >= CellRows[0].Count)
				return;

			
			
			/* int max_x = cellpos.X + 1;
			int max_y = cellpos.Y + 1;
			for (cellpos.X--; cellpos.X < max_x; cellpos.X++)
			{
				for (cellpos.Y--; cellpos.Y < max_y; cellpos.Y++)
				{
					if (cellpos.Y < 0 || cellpos.X < 0)
						continue;
			 */
		
					CellInfo ci = CellRows[cellpos.Y][cellpos.X];
					//m_PaintBuffer.FillRectangle(new SolidBrush(this.BackColor), cellpos.X * m_CellWidth, cellpos.Y * m_CellHeight, m_CellWidth, m_CellHeight);
					m_PaintBuffer.FillRectangle(this.Colors.SolidBrushes[ci.BackColor], cellpos.X * m_CellWidth, cellpos.Y * m_CellHeight, m_CellWidth, m_CellHeight);
					if (CellRows[cellpos.Y][cellpos.X].Character != ' ')
					{
						FontStyle styles = new FontStyle();
						if (ci.Bold)
							styles |= FontStyle.Bold;
						if (ci.Underlined)
							styles |= FontStyle.Underline;
						Font font = new Font(this.Font, styles);
						m_PaintBuffer.DrawString(ci.Character.ToString(), font,this.Colors.SolidBrushes[ci.ForeColor], cellpos.X * m_CellWidth, cellpos.Y * m_CellHeight);

					}
					m_PaintBuffer.DrawLine(m_SeperatorPen, cellpos.X * m_CellWidth, (1 + cellpos.Y) * m_CellHeight, (1 + cellpos.X) * m_CellWidth, (1 + cellpos.Y) * m_CellHeight);
					m_PaintBuffer.DrawLine(m_SeperatorPen, (1 + cellpos.X) * m_CellWidth, (cellpos.Y) * m_CellHeight, (1 + cellpos.X) * m_CellWidth, (1 + cellpos.Y) * m_CellHeight);
					m_PaintBuffer.DrawLine(m_SeperatorPen, (cellpos.X) * m_CellWidth, (cellpos.Y) * m_CellHeight, (1 + cellpos.X) * m_CellWidth, (cellpos.Y) * m_CellHeight);
					m_PaintBuffer.DrawLine(m_SeperatorPen, (cellpos.X) * m_CellWidth, (cellpos.Y) * m_CellHeight, (cellpos.X) * m_CellWidth, (1 + cellpos.Y) * m_CellHeight);
					if (m_SelectedCellPosition.X == cellpos.X && m_SelectedCellPosition.Y == cellpos.Y)
					{
						m_PaintBuffer.DrawRectangle(m_HighlightPen, 1 + (m_SelectedCellPosition.X * (m_CellWidth + (m_SeperatorWidth / 2))), 1 + ( m_SelectedCellPosition.Y * (m_CellHeight + (m_SeperatorWidth / 2)) ),
										 m_CellWidth - 2, m_CellHeight - 2);
					}
			//	}
			//}
			int xpos = (cellpos.X * m_CellWidth) - 5;
			int ypos = (cellpos.Y * m_CellHeight) - 5;
			if ( xpos < 0 ) 
				xpos = 0;
			if ( ypos < 0 )
				ypos = 0;
			this.Invalidate(new Rectangle(new Point(xpos, ypos), new Size(m_CellWidth + 5, m_CellHeight + 5)));
		}

		private void PaintIntoBackground()
		{
			if ( m_DontRepaint )
				return;
			//m_PaintBuffer.FillRectangle(new SolidBrush(this.BackColor), 0, 0, this.Width, this.Height);

			Font boldfont = new Font(this.Font, FontStyle.Bold);
			Font underlinedfont = new Font(this.Font, FontStyle.Underline);
			Font bold_underlined_font = new Font(this.Font, FontStyle.Underline | FontStyle.Bold);

			CellInfo ci;
			for (int row = 0; row < m_Rows; row++)
			{
				for (int col = 0; col < m_Columns; col++)
				{
					ci = CellRows[row][col];
					m_PaintBuffer.FillRectangle(this.Colors.SolidBrushes[ci.BackColor], col * m_CellWidth, row * m_CellHeight, m_CellWidth, m_CellHeight);
					if (CellRows[row][col].Character != ' ')
					{
						Font font;
						if (ci.Bold && ci.Underlined)
							font = bold_underlined_font;
						else if (ci.Bold)
							font = boldfont;
						else if (ci.Underlined)
							font = underlinedfont;
						else
							font = this.Font;
						m_PaintBuffer.DrawString(ci.Character.ToString(), font, this.Colors.SolidBrushes[ci.ForeColor], col * m_CellWidth, row * m_CellHeight);

					}
				}
			}
			for (int i = 0; i < m_Rows; i++)
			{
				int ypos = (m_SeperatorWidth / 2) + i * m_CellHeight;
				m_PaintBuffer.DrawLine(m_SeperatorPen, 0, ypos, this.Width, ypos);

			}
			for (int i = 0; i < m_Columns; i++)
			{
				int xpos = (m_SeperatorWidth / 2) + i * m_CellWidth;
				m_PaintBuffer.DrawLine(m_SeperatorPen, xpos, 0, xpos, this.Height);

			}

			m_PaintBuffer.DrawRectangle(m_HighlightPen, m_SelectedCellPosition.X * (m_CellWidth + (m_SeperatorWidth / 2)), m_SelectedCellPosition.Y * (m_CellHeight + (m_SeperatorWidth / 2)),
				 m_CellWidth, m_CellHeight);

			
#if false
			// test
			Font consolas = new Font("Consolas", 18, GraphicsUnit.Pixel);
			m_PaintBuffer.DrawString("Test", consolas, Brushes.BlueViolet, 10, 0);
			SizeF size = m_PaintBuffer.MeasureString("Test", consolas);
			m_PaintBuffer.DrawString(size.Width.ToString(), consolas, Brushes.Blue, size.Width + 10, 0);
			m_PaintBuffer.DrawLine(new Pen(Brushes.AliceBlue), new Point(0, consolas.Height), new Point(this.Width, consolas.Height));
			// test
			Font arial = new Font("Arial", 10, GraphicsUnit.Pixel);
			
			m_PaintBuffer.DrawString("Test", arial, Brushes.BlueViolet, 10, consolas.Height);
			size = m_PaintBuffer.MeasureString("Test", arial);
			m_PaintBuffer.DrawString(size.Width.ToString(), arial, Brushes.Blue, size.Width + 10, consolas.Height);
			m_PaintBuffer.DrawLine(new Pen(Brushes.Peru), new Point(0, consolas.Height + arial.Height), new Point(this.Width, consolas.Height + arial.Height));
#endif
		}

		private void PaintCanvas_SizeChanged(object sender, EventArgs e)
		{
			m_PaintImage = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb565); //.Format32bppRgb);
			m_PaintBuffer = Graphics.FromImage(m_PaintImage);
			PaintIntoBackground();
		}

		public enum PaintModes
		{
			PaintBrush,
			Fill,
			Bold,
			Underline,
			RemoveFormatting
		};

		private PaintModes m_PaintMode;

		/// <summary>
		/// Gets or sets the PaintMode.
		/// </summary>
		public PaintModes PaintMode
		{
			get { return m_PaintMode; }
			set { m_PaintMode = value; }
		}

		private void PaintCanvas_MouseDown(object sender, MouseEventArgs e)
		{
			if (CurrentAction is KeypressAction)
			{
				CurrentAction = null;
			}

			if (CurrentAction == null)
			{
				if ( m_PaintMode == PaintModes.PaintBrush || m_PaintMode == PaintModes.Fill )
					CurrentAction = new PaintAction();
			}
			SelectAppropriateCell(e.X, e.Y);
			if (m_PaintMode == PaintModes.PaintBrush || m_PaintMode == PaintModes.Fill)
				PaintCellByMouseArgs(this.m_SelectedCellPosition, e);
			else if (m_PaintMode == PaintModes.Bold)
			{
				BoldSelectedCell();
			}
			else if (m_PaintMode == PaintModes.Underline)
			{
				UnderlineSelectedCell();
			}
			else if (m_PaintMode == PaintModes.RemoveFormatting)
			{
				RemoveFormattingSelectedCell();
			}
		}

		private void RemoveFormattingSelectedCell()
		{
			SelectedCell.Underlined = false;
			SelectedCell.Bold = false;
			RepaintSingleCell(SelectedCellPosition);
		}

		public void UnderlineSelectedCell()
		{
			SelectedCell.Underlined = true;
			RepaintSingleCell(SelectedCellPosition);
		}

		public void BoldSelectedCell()
		{
			SelectedCell.Bold = true; //  (SelectedCell.Bold ? false : true); 
			RepaintSingleCell(SelectedCellPosition);
		}

		private void StartFillCell( Point point, byte origcolor, byte color, bool foreground)
		{
			if (CurrentAction is PaintAction)
			{
				//CurrentAction = new PaintAction();
				((PaintAction)CurrentAction).IsForeground = foreground;
				((PaintAction)CurrentAction).NewPaintColor = color;
				((PaintAction)CurrentAction).OldPaintColor = origcolor;
			}
			FillCell(  point,  origcolor,  color,  foreground);
			if (CurrentAction is PaintAction)
			{
				AddUndoAction(CurrentAction);
				CurrentAction = null;
			}
		}

		private void PaintCellByMouseArgs(Point point, MouseEventArgs e)
		{


			switch (e.Button)
			{
				case MouseButtons.Left:
					if ( m_PaintMode == PaintModes.Fill )
					{
						if ( m_LeftMouseIsForeground )
							StartFillCell(point, CellRows[point.Y][point.X].ForeColor, m_LeftMouseColor, m_LeftMouseIsForeground);
						else
							StartFillCell(point, CellRows[point.Y][point.X].BackColor, m_LeftMouseColor, m_LeftMouseIsForeground);
						this.Invalidate();
					}
					else
						PaintCell(point, m_LeftMouseColor, m_LeftMouseIsForeground);
					if (m_LeftMouseIsForeground)
						this.MostRecentForegroundColor = m_LeftMouseColor;
					break;
				case MouseButtons.Right:
					if (m_PaintMode == PaintModes.Fill)
					{
						if (m_RightMouseIsForeground)
							StartFillCell(point, CellRows[point.Y][point.X].ForeColor, m_RightMouseColor, m_RightMouseIsForeground);
						else
							StartFillCell(point, CellRows[point.Y][point.X].BackColor, m_RightMouseColor, m_RightMouseIsForeground);
						this.Invalidate();
					}
					else
						PaintCell(point, m_RightMouseColor, m_RightMouseIsForeground);
					if (m_RightMouseIsForeground)
						this.MostRecentForegroundColor = m_RightMouseColor;
					break;
				case MouseButtons.Middle:
					if (m_PaintMode == PaintModes.Fill)
					{
						if (m_MiddleMouseIsForeground)
							StartFillCell(point, CellRows[point.Y][point.X].ForeColor, m_MiddleMouseColor, m_MiddleMouseIsForeground);
						else
							StartFillCell(point, CellRows[point.Y][point.X].BackColor, m_MiddleMouseColor, m_MiddleMouseIsForeground);
						this.Invalidate();
					}
					else
						PaintCell(point, m_MiddleMouseColor, m_MiddleMouseIsForeground);
					if (m_MiddleMouseIsForeground)
						this.MostRecentForegroundColor = m_MiddleMouseColor;
					break;
				default:
					break;
			}
		}

		private bool m_DontRepaint = false;

		/// <summary>
		/// Gets or sets the DontRepaint = false.
		/// </summary>
		public bool DontRepaint 
		{
			get { return m_DontRepaint; }
			set { m_DontRepaint = value; }
		}

		private void FillCell(Point point, byte origcolor, byte color, bool foreground)
		{

			Point curpoint = new Point();
			if (foreground)
			{
				if (CellRows[point.Y][point.X].ForeColor == color)
					return;
				CellRows[point.Y][point.X].ForeColor = color;
			}
			else
			{
				if (CellRows[point.Y][point.X].BackColor == color)
					return;
				CellRows[point.Y][point.X].BackColor = color;
			}



			if (CurrentAction is PaintAction)
			{
				((PaintAction)CurrentAction).PaintedPoints.Add(point);
			}
		

			RepaintSingleCell(point);
			

			if (point.Y - 1 >= 0) // up
			{
				curpoint.Y = point.Y - 1;
				curpoint.X = point.X;
				if (foreground)
				{
					if (CellRows[curpoint.Y][curpoint.X].ForeColor == origcolor)
						FillCell(curpoint, origcolor, color, foreground);
				}
				else
					if (CellRows[curpoint.Y][curpoint.X].BackColor == origcolor)
						FillCell(curpoint, origcolor, color, foreground);
			}
			if ( point.X + 1 < m_Columns ) // right
			{
				curpoint.Y = point.Y;
				curpoint.X = point.X + 1;
				if (foreground)
				{
					if (CellRows[curpoint.Y][curpoint.X].ForeColor == origcolor)
						FillCell(curpoint, origcolor, color, foreground);
				}
				else
					if (CellRows[curpoint.Y][curpoint.X].BackColor == origcolor)
						FillCell(curpoint, origcolor, color, foreground);
			}

			if (point.X - 1 >= 0) // left
			{
				curpoint.Y = point.Y;
				curpoint.X = point.X - 1;
				if (foreground)
				{
					if (CellRows[curpoint.Y][curpoint.X].ForeColor == origcolor)
						FillCell(curpoint, origcolor, color, foreground);
				}
				else
					if (CellRows[curpoint.Y][curpoint.X].BackColor == origcolor)
						FillCell(curpoint, origcolor, color, foreground);
			}
			if (point.Y + 1 < m_Rows)	// down
			{
				curpoint.Y = point.Y + 1;
				curpoint.X = point.X;
				if (foreground)
				{
					if (CellRows[curpoint.Y][curpoint.X].ForeColor == origcolor)
						FillCell(curpoint, origcolor, color, foreground);
				}
				else
					if (CellRows[curpoint.Y][curpoint.X].BackColor == origcolor)
						FillCell(curpoint, origcolor, color, foreground);
			}

			if ( m_Modified == false )
				Modified = true;


		}

		private void PaintCell(Point point, byte color, bool foreground)
		{
			if (CurrentAction is PaintAction)
			{
				PaintAction act = (PaintAction)CurrentAction;
				act.IsForeground = foreground;
				act.NewPaintColor = color;
				if (foreground)
					act.OldPaintColor = CellRows[point.Y][point.X].ForeColor;
				else
					act.OldPaintColor = CellRows[point.Y][point.X].BackColor;
				act.PaintedPoints.Add(new Point(point.X, point.Y));
			}


			if ( foreground )
				CellRows[point.Y][point.X].ForeColor = color;
			else
				CellRows[point.Y][point.X].BackColor = color;
			RepaintSingleCell(point);
	
			if (m_Modified == false)
				Modified = true;


		}

		private void PaintCanvas_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.None )
			{
				Point newpos = FindCellCoords(e.X, e.Y);
				if ( newpos.X != SelectedCellPosition.X || newpos.Y != SelectedCellPosition.Y)
				{
					SelectAppropriateCell(e.X, e.Y);
					if (m_PaintMode == PaintModes.Bold)
					{
						BoldSelectedCell();
						RepaintSingleCell(newpos);
					}
					else if (m_PaintMode == PaintModes.Underline)
					{
						UnderlineSelectedCell();
						RepaintSingleCell(newpos);
					}
					else if (m_PaintMode == PaintModes.RemoveFormatting)
					{
						RemoveFormattingSelectedCell();
						RepaintSingleCell(newpos);
					}
					else if (CurrentAction is PaintAction)			
					{
						if (!((PaintAction)CurrentAction).PointExists(m_SelectedCellPosition))
							PaintCellByMouseArgs(this.m_SelectedCellPosition, e);
					}
				}
			}

		}

		private Point FindCellCoords(int x, int y)
		{
			// Find the cell we need to highlight.
			int xpos = x / this.m_CellWidth;
			int ypos = y / this.m_CellHeight;
			if (xpos < 0)
				xpos = 0;
			if (ypos < 0)
				ypos = 0;
			if (ypos >= CellRows.Count)
				ypos = CellRows.Count - 1;
			if (xpos >= CellRows[ypos].Count)
				xpos = CellRows[ypos].Count - 1;
			return new Point(xpos, ypos);
		}

		private void SelectAppropriateCell(int x, int y)
		{
			Point oldpos = m_SelectedCellPosition;

			SelectedCellPosition = FindCellCoords(x, y);
			
			RepaintSingleCell(oldpos); 
			RepaintSingleCell(m_SelectedCellPosition); 
		} 

		private ColorPalette m_Colors = new ColorPalette(); 

		/// <summary> 
		/// Gets or sets the Colors.
		/// </summary>
		public ColorPalette Colors
		{
			get { return m_Colors; }
			set { m_Colors = value; this.Invalidate(); }
		}

		public List<List<CellInfo>> CellRows;
		 
		private byte m_LeftMouseColor = 0;

		/// <summary>
		/// Gets or sets the LeftMouseColor .
		/// </summary>
		public byte LeftMouseColor 
		{
			get { return m_LeftMouseColor ; }
			set { m_LeftMouseColor  = value; }
		}

		private byte m_MiddleMouseColor = 4;

		/// <summary>
		/// Gets or sets the MiddleMouseColor.
		/// </summary>
		public byte MiddleMouseColor
		{
			get { return m_MiddleMouseColor; }
			set { m_MiddleMouseColor = value; }
		}

		private byte m_RightMouseColor = 1;

		/// <summary>
		/// Gets or sets the RightMouseColor.
		/// </summary>
		public byte RightMouseColor
		{
			get { return m_RightMouseColor; }
			set { m_RightMouseColor = value; }
		}
		 
		private bool m_LeftMouseIsForeground = true;

		/// <summary>
		/// Gets or sets the LeftMouseIsForeground.
		/// </summary>
		public bool LeftMouseIsForeground
		{
			get { return m_LeftMouseIsForeground; }
			set { m_LeftMouseIsForeground = value; }
		} 

		private bool m_MiddleMouseIsForeground = false;

		/// <summary>
		/// Gets or sets the MiddleMouseIsForeground.
		/// </summary>
		public bool MiddleMouseIsForeground
		{
			get { return m_MiddleMouseIsForeground; }
			set { m_MiddleMouseIsForeground = value; }
		} 

		private bool m_RightMouseIsForeground = false;

		/// <summary>
		/// Gets or sets the RightMouseIsForeground.
		/// </summary>
		public bool RightMouseIsForeground
		{
			get { return m_RightMouseIsForeground; }
			set { m_RightMouseIsForeground = value; }
		}

		public CellInfo SelectedCell
		{
			get { return CellRows[m_SelectedCellPosition.Y][m_SelectedCellPosition.X]; }
		}
	

		private void PaintCanvas_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
			Point oldpos = m_SelectedCellPosition;
			if (!char.IsControl((char)e.KeyChar) ) // && e.KeyChar != (char)Keys.Up && e.KeyChar != (char)Keys.Down && e.KeyChar != (char)Keys.Left && e.KeyChar != (char)Keys.Right && e.KeyChar != (char)Keys.Return)
			{
				AddCharacterChangeToKeypressAction(m_SelectedCellPosition.X, m_SelectedCellPosition.Y, SelectedCell.Character, (char)e.KeyChar);
				SelectedCell.Character = (char)e.KeyChar;
				SelectedCell.ForeColor = m_MostRecentForegroundColor;

				if (m_SelectedCellPosition.X + 1 < m_Columns)
					m_SelectedCellPosition.X++;
				else
				{
					m_SelectedCellPosition.X = 0;
					m_SelectedCellPosition.Y++;
				}
				RepaintSingleCell(oldpos);
				RepaintSingleCell(m_SelectedCellPosition);

			}
			
		}


		private int ParseChar(char c)
		{
			return (int)(c - 0x30);
		}

		private const char ColorControl = '\x0003';
		private const char UnderlineControl = '\x001F';
		private const char BoldControl = '\x0002';
		private const char PlainControl = '\x000F';
		private const char ReverseControl = '\x0016';

		internal void LoadStream(System.IO.Stream stream)
		{

			StreamReader reader = new StreamReader(stream);

			CellRows.Clear();
			CellRows = new List<List<CellInfo>>();


			//int col = 0;
			int row = 0;
			while(reader.Peek() >= 0 )
			{
				int bc = 100;
				int fc = 100;
				CellRows.Add(new List<CellInfo>());
				string strline = reader.ReadLine();
				char[] str = strline.ToCharArray();
				bool bold = false;
				bool underlined = false;
				for(int i = 0; i < str.Length; i++)
				{
					
					if (IsControlCode(str[i]))
					{
						if (str[i] == BoldControl)
						{
							bold = (bold ? false : true);
							continue;
						}
						else if (str[i] == UnderlineControl)
						{
							underlined = (underlined ? false : true);
							continue;
						}
						else if (str[i] == ReverseControl)
						{
							continue;
						}
						else if (str[i] == PlainControl)
						{
							bold = false;
							underlined = false;
							continue;
						}
						else if (str[i] == ColorControl)
						{
							//bc = 100;
							fc = 100;


							if (i + 1 == str.Length)
								break;
							i++;

							if (Char.IsDigit(str[i]))
							{
								// forecolor += str[i];
								fc = ParseChar(str[i]);

								if (i + 1 == str.Length)
									break;
								i++;
								if (Char.IsDigit(str[i]))
								{
									fc = ((fc * 10)) + ParseChar(str[i]);

									if (i + 1 == str.Length)
										break;
									i++;

								}

							}

							if (fc > 15 && fc != 100)
								fc = 0;

							if (str[i] == ',')
							{
								if (++i == str.Length)
									break;

								if (Char.IsDigit(str[i]))
								{
									bc = ParseChar(str[i]);
									if (++i == str.Length)
										break;

									if (Char.IsDigit(str[i]))
									{
										bc = (bc * 10) + ParseChar(str[i]);
										if (++i == str.Length)
											break;
									}
								}
							}

							if (bc > 15 && bc != 100)
								bc = 1;


							/*for (; i < str.Length && IsControlCode(str[i]); i++)
							{
							}
							 */

						}
					}
					CellInfo ci = new CellInfo();
					ci.Character = str[i];
					if (fc != 100)
						ci.ForeColor = (byte)fc;
					if (bc != 100)
						ci.BackColor = (byte)bc;
					ci.Bold = bold;
					ci.Underlined = underlined;
					CellRows[row].Add(ci);


				}
				row++;
				
			}


			// find longest row.
			int longest = 0;
			foreach (List<CellInfo> cellrow in CellRows)
			{
				if (cellrow.Count > longest)
					longest = cellrow.Count;
			}
			this.m_Columns = longest;
			this.m_Rows = CellRows.Count;
			ResizeCellRows(); 
			ResizeByCellSize(); 
			PaintIntoBackground();
		}

		private bool IsControlCode(char c)
		{
			return
				c == '\x0003' ||
				c == '\x001F' ||
				c == '\x0002' ||
				c == '\x000F' ||
				c == '\x0016';
		}

		private void PaintCanvas_Load(object sender, EventArgs e)
		{
			this.Font = new Font(Program.Settings.PaintFontName, Program.Settings.PaintFontSize);
			this.CellHeight = Program.Settings.CellHeight;
			this.CellWidth = Program.Settings.CellWidth;
			this.HighlightColor = Program.Settings.HighlightColor;
			this.LeftMouseColor = Program.Settings.LMBColor;
			this.LeftMouseIsForeground = Program.Settings.LMBIsForeground;
			
			this.RightMouseColor = Program.Settings.RMBColor;
			this.RightMouseIsForeground = Program.Settings.RMBIsForeground;
			this.MiddleMouseColor = Program.Settings.MMBColor;
			this.MiddleMouseIsForeground = Program.Settings.MMBIsForeground;
			this.SeperatorColor = Program.Settings.SeperatorColor;
			this.HighlightColor = Program.Settings.HighlightColor;

			if (this.RightMouseIsForeground)
				this.MostRecentForegroundColor = this.RightMouseColor;
			if (this.MiddleMouseIsForeground)
				this.MostRecentForegroundColor = this.MiddleMouseColor;
			if (this.LeftMouseIsForeground)
				this.MostRecentForegroundColor = this.LeftMouseColor;
			
		}

		private byte m_MostRecentForegroundColor = 0;

		/// <summary>
		/// Gets or sets the MostRecentForegroundColor.
		/// </summary>
		public byte MostRecentForegroundColor
		{
			get { return m_MostRecentForegroundColor; }
			set { m_MostRecentForegroundColor = value; }
		}

		private void PaintCanvas_KeyDown(object sender, KeyEventArgs e)
		{
			
		}

		public void ImportImage(string filename)
		{
			Bitmap bmp = new Bitmap(filename);

			this.Columns = bmp.Width * 2;
			this.Rows = bmp.Height;
			for (int y = 0; y < bmp.Height; y++)
			{
				for (int x = 0; x < bmp.Width * 2; x++)
				{
					byte newcolor = this.Colors.FindClosestColor(bmp.GetPixel(x/2, y));
					this.CellRows[y][x++].BackColor = newcolor;
					this.CellRows[y][x].BackColor = newcolor;
				}
			}
			this.PaintIntoBackground();
			this.Invalidate();
		}

		private void PaintCanvas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			//e.Handled = true;
			bool repaint = false;
			Point oldpos = m_SelectedCellPosition;

			if (e.KeyCode == Keys.Up)
			{
				if (m_SelectedCellPosition.Y > 0)
				{
					m_SelectedCellPosition.Y--;
				}
				repaint = true;
			}
			else if (e.KeyCode == Keys.Right)
			{
				if (m_SelectedCellPosition.X < CellRows[0].Count)
					m_SelectedCellPosition.X++;
				repaint = true;
			}
			else if (e.KeyCode == Keys.Down)
			{
				if (m_SelectedCellPosition.Y < CellRows.Count)
					m_SelectedCellPosition.Y++;
				repaint = true;
			}
			else if (e.KeyCode == Keys.Left)
			{
				if (m_SelectedCellPosition.X > 0)
					m_SelectedCellPosition.X--;
				repaint = true;
			}
			else if (e.KeyCode == Keys.Return)
			{
				if (m_SelectedCellPosition.Y < CellRows.Count)
					m_SelectedCellPosition.Y++;
				m_SelectedCellPosition.X = 0;
				repaint = true;
			}
			else if (e.KeyCode == Keys.Back)
			{
				if (m_SelectedCellPosition.X > 0)
					m_SelectedCellPosition.X--;
				AddCharacterChangeToKeypressAction(m_SelectedCellPosition.X, m_SelectedCellPosition.Y, SelectedCell.Character, ' ');
				SelectedCell.Character = ' ';
				
				repaint = true;
			}
			else if (e.KeyCode == Keys.Delete)
			{
				AddCharacterChangeToKeypressAction(m_SelectedCellPosition.X, m_SelectedCellPosition.Y, SelectedCell.Character, ' ');
				SelectedCell.Character = ' ';
				repaint = true;
			}

			if (repaint)
			{
				RepaintSingleCell(oldpos);
				RepaintSingleCell(m_SelectedCellPosition);
			}
		}

		public void AddCharacterChangeToKeypressAction(int x, int y, char origchar, char newchar)
		{
			if (CurrentAction == null)
			{
				CurrentAction = new KeypressAction();
				AddUndoAction(CurrentAction);
			}

			if (CurrentAction is KeypressAction)
			{
				((KeypressAction)CurrentAction).AddCharacter(x, y, origchar, newchar);
			}
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

		public void AddUndoAction(IUndoableAction action)
		{
			UndoList.Push(action);
			if (RedoList.Count > 0)
			{
				RedoList.Clear();
				OnRedoChanged(RedoChangedEventArgs.Empty);
			}
			OnUndoChanged(UndoChangedEventArgs.Empty);
		}

		public void AddRedoAction(IUndoableAction action)
		{
			RedoList.Push(action);
			OnRedoChanged(RedoChangedEventArgs.Empty);
		}

		public void Undo()
		{
			if (UndoList.Count > 0)
			{
				IUndoableAction act = UndoList.Pop();
				act.Undo(this);
				OnUndoChanged(UndoChangedEventArgs.Empty);
				RedoList.Push(act);
				OnRedoChanged(RedoChangedEventArgs.Empty);
			}
		}

		public void Redo()
		{
			if (RedoList.Count > 0)
			{
				IUndoableAction act = RedoList.Pop();
				act.Redo(this);
				OnRedoChanged(RedoChangedEventArgs.Empty);
				//UndoList.Clear();
				UndoList.Push(act);
				OnUndoChanged(UndoChangedEventArgs.Empty);
			}
		}

		private void PaintCanvas_MouseUp(object sender, MouseEventArgs e)
		{
			if (CurrentAction is PaintAction)
			{
				AddUndoAction(CurrentAction);
				CurrentAction = null;
				
			}
		}

		public void RepaintAll()
		{
			this.PaintIntoBackground();
			this.Invalidate();
		}
	}
}
