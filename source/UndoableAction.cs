using System;
using System.Collections.Generic;
using System.Text;

namespace AsciiPumper
{
	public interface IUndoableAction
	{
		void Undo( PaintCanvas canvas);
		void Redo( PaintCanvas canvas );

	}
}
