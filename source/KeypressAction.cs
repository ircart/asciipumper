using System;
using System.Collections.Generic;
using System.Text;

namespace AsciiPumper
{
	public class KeypressAction : IUndoableAction
	{

		private struct CharChangeInfo
		{
			public int x;
			public int y;
			public char origchar;
			public char newchar;

		}
		private List<CharChangeInfo> ChangedCharacters = new List<CharChangeInfo>();

		public void AddCharacter(int x, int y, char origchar, char newchar)
		{
			foreach (CharChangeInfo info in ChangedCharacters)
			{
				if (info.x == x && info.y == y)
				{
					ChangedCharacters.Remove(info);
					break;
				}
			}
			CharChangeInfo newinfo = new CharChangeInfo();
			newinfo.x = x;
			newinfo.y = y;
			newinfo.origchar = origchar;
			newinfo.newchar = newchar;
			ChangedCharacters.Add(newinfo);
		}

		#region IUndoableAction Members

		public void Undo(PaintCanvas canvas)
		{
			foreach (CharChangeInfo info in ChangedCharacters)
			{
				canvas.CellRows[info.y][info.x].Character = info.origchar;
			}
			canvas.CompleteRepaint();
		}

		public void Redo(PaintCanvas canvas)
		{
			foreach (CharChangeInfo info in ChangedCharacters)
			{
				canvas.CellRows[info.y][info.x].Character = info.newchar;
			}
			canvas.CompleteRepaint();
		}

		#endregion
	}
}
