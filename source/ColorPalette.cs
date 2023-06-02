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
using System.Text;
using System.Drawing;

namespace AsciiPumper
{
	public class ColorPalette : List<Color>
	{

		public SolidBrush [] SolidBrushes  = new SolidBrush[16];

		/* 
 0 white
 1 black
 2 blue     (navy)
 3 green
 4 red
 5 brown    (maroon)
 6 purple
 7 orange   (olive)
 8 yellow
 9 lt.green (lime)
 10 teal    (a kinda green/blue cyan)
 11 lt.cyan (cyan ?) (aqua)
 12 lt.blue (royal)
 13 pink    (light purple) (fuchsia)
 14 grey
 15 lt.grey (silver)
		 */
		public ColorPalette() : base(16)
		{
			

			this.Add(Color.White);
			this.Add(Color.Black);
			this.Add(Color.FromArgb(0, 0, 127)); // this.Add(Color.Blue);
			this.Add(Color.FromArgb(0, 147, 0)); // this.Add(Color.Green);
			this.Add(Color.FromArgb(255, 0, 0)); // this.Add(Color.Red);
			this.Add(Color.FromArgb(127, 0, 0)); // this.Add(Color.Brown);
			this.Add(Color.FromArgb(156, 0, 156)); // this.Add(Color.Purple);
			this.Add(Color.FromArgb(252, 127, 0)); // this.Add(Color.Orange);
			this.Add(Color.FromArgb(255, 255, 0)); // this.Add( Color.Yellow);
			this.Add(Color.FromArgb(0, 252, 0)); // this.Add( Color.LightGreen);
			this.Add(Color.FromArgb(0, 147, 147)); // this.Add( Color.Teal);
			this.Add(Color.FromArgb(0, 255, 255)); // this.Add( Color.LightCyan);
			this.Add(Color.FromArgb(0, 0, 252)); // this.Add( Color.LightBlue);
			this.Add(Color.FromArgb(255, 0, 255)); // this.Add( Color.Pink);
			this.Add(Color.FromArgb(127, 127, 127)); // this.Add( Color.Gray);
			this.Add(Color.FromArgb(210, 210, 210)); // this.Add(Color.LightGray);

			for(int i = 0; i < 16; i++)
				SolidBrushes[i] = new SolidBrush(this[i]);
		}

		public byte FindClosestColor(Color color)
		{
			byte smallestindex = 0;
			int smallestdistance = int.MaxValue;

			for (byte i = 0; i < this.Count; i++)
			{

				Color curcolor = this[i];
				int distance = (curcolor.R - color.R) * (curcolor.R - color.R) + (curcolor.G - color.G) * (curcolor.G - color.G) + (curcolor.B - color.B) * (curcolor.B - color.B);
				if (distance < smallestdistance)
				{
					smallestdistance = distance;
					smallestindex = i;
				}
			}

			return smallestindex;
		}
	}
}
