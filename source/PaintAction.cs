using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AsciiPumper
{
	public class PaintAction : IUndoableAction
	{
		
		public List<Point> PaintedPoints = new List<Point>();
		public byte OldPaintColor = 0;
		public byte NewPaintColor = 1;
		public bool IsForeground = false;

		public bool PointExists(Point point)
		{
			foreach (Point p in PaintedPoints)
			{
				if (p.X == point.X && p.Y == point.Y)
					return true;
			}
			return false;
		}

		#region IUndoableAction Members
		public void Undo(PaintCanvas canvas)
		{
			foreach (Point p in PaintedPoints)
			{
				if (IsForeground)
					canvas.CellRows[p.Y][p.X].ForeColor = OldPaintColor;
				else
					canvas.CellRows[p.Y][p.X].BackColor = OldPaintColor;
			}
			canvas.RepaintAll();
		}

		public void Redo(PaintCanvas canvas)
		{
			foreach (Point p in PaintedPoints)
			{
				if (IsForeground)
					canvas.CellRows[p.Y][p.X].ForeColor = NewPaintColor;
				else
					canvas.CellRows[p.Y][p.X].BackColor = NewPaintColor;
			}
			canvas.RepaintAll();
		}

		#endregion
	}
}
