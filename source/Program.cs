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
using System.Windows.Forms;

namespace AsciiPumper
{
	static class Program
	{
		public static AsciiPumper.Properties.Settings Settings = new AsciiPumper.Properties.Settings();

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new PumpForm()); //new MainForm());
		}
	}
}