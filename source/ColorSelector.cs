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

namespace AsciiPumper
{
	public partial class ColorSelector : UserControl
	{
		public ColorSelector()
		{
			InitializeComponent();
			LoadColorPalette(new ColorPalette());
		}

		public void LoadColorPalette(ColorPalette colors)
		{
			m_Colors = colors; 
			color0.BackColor = colors[0];
			color1.BackColor = colors[1];
			color2.BackColor = colors[2];
			color3.BackColor = colors[3];
			color4.BackColor = colors[4];
			color5.BackColor = colors[5];
			color6.BackColor = colors[6];
			color7.BackColor = colors[7];
			color8.BackColor = colors[8];
			color9.BackColor = colors[9];
			color10.BackColor = colors[10];
			color11.BackColor = colors[11];
			color12.BackColor = colors[12];
			color13.BackColor = colors[13];
			color14.BackColor = colors[14];
			color15.BackColor = colors[15];
		}

		private ColorPalette m_Colors = new ColorPalette();

		/// <summary>
		/// Gets or sets the Colors.
		/// </summary>
		public ColorPalette Colors
		{
			get { return m_Colors; }
			set { LoadColorPalette(value); }
		}

		public class ButtonColorChangedEventArgs : EventArgs
		{
			public static readonly new ButtonColorChangedEventArgs Empty = new ButtonColorChangedEventArgs(0, new MouseEventArgs(MouseButtons.None, 1, 0, 0, 0));

			public ButtonColorChangedEventArgs(byte colorindex, MouseEventArgs e )
			{
				ColorIndex = colorindex;
				MouseEvent = e;
			}

			public MouseEventArgs MouseEvent;
			public byte ColorIndex;
		}

		public event EventHandler<ButtonColorChangedEventArgs> ButtonColorChanged;

		protected virtual void OnButtonColorChanged(ButtonColorChangedEventArgs e)
		{
			EventHandler<ButtonColorChangedEventArgs> handler = ButtonColorChanged;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		private void color0_MouseClick(object sender, MouseEventArgs e)
		{
			OnButtonColorChanged(new ButtonColorChangedEventArgs(0, e));

		}

		private void color1_Click(object sender, EventArgs e)
		{

		}

		private void color1_MouseClick(object sender, MouseEventArgs e)
		{
			OnButtonColorChanged(new ButtonColorChangedEventArgs(1, e));
		}

		private void color2_MouseClick(object sender, MouseEventArgs e)
		{
			OnButtonColorChanged(new ButtonColorChangedEventArgs(2, e));
		}

		private void color3_MouseClick(object sender, MouseEventArgs e)
		{
			OnButtonColorChanged(new ButtonColorChangedEventArgs(3, e));
		}

		private void color4_MouseClick(object sender, MouseEventArgs e)
		{
			OnButtonColorChanged(new ButtonColorChangedEventArgs(4, e));
		}

		private void color5_MouseClick(object sender, MouseEventArgs e)
		{
			OnButtonColorChanged(new ButtonColorChangedEventArgs(5, e));
		}

		private void color6_MouseClick(object sender, MouseEventArgs e)
		{
			OnButtonColorChanged(new ButtonColorChangedEventArgs(6, e));
		}

		private void color7_MouseClick(object sender, MouseEventArgs e)
		{
			OnButtonColorChanged(new ButtonColorChangedEventArgs(7, e));
		}

		private void color8_MouseClick(object sender, MouseEventArgs e)
		{
			OnButtonColorChanged(new ButtonColorChangedEventArgs(8, e));
		}

		private void color9_MouseClick(object sender, MouseEventArgs e)
		{
			OnButtonColorChanged(new ButtonColorChangedEventArgs(9, e));
		}

		private void color10_MouseClick(object sender, MouseEventArgs e)
		{
			OnButtonColorChanged(new ButtonColorChangedEventArgs(10, e));
		}

		private void color11_Click(object sender, EventArgs e)
		{
			
		}

		private void color11_MouseClick(object sender, MouseEventArgs e)
		{
			OnButtonColorChanged(new ButtonColorChangedEventArgs(11, e));
		}

		private void color12_MouseClick(object sender, MouseEventArgs e)
		{
			OnButtonColorChanged(new ButtonColorChangedEventArgs(12, e));
		}

		private void color13_MouseClick(object sender, MouseEventArgs e)
		{
			OnButtonColorChanged(new ButtonColorChangedEventArgs(13, e));
		}

		private void color14_MouseClick(object sender, MouseEventArgs e)
		{
			OnButtonColorChanged(new ButtonColorChangedEventArgs(14, e));
		}

		private void color15_MouseClick(object sender, MouseEventArgs e)
		{
			OnButtonColorChanged(new ButtonColorChangedEventArgs(15, e));
		}
	}
}
