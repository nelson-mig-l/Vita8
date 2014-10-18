using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Input;

namespace Vita8
{
	public class Screen
	{
		private static uint COLOR_OFF = 0xFF000066;
		private static uint COLOR_ON = 0xFF0066FF;
		
		private int pixelSize;
		private int x;
		private int y;
		
		public Screen(int x, int y, int pixelSize)
		{
			this.pixelSize = pixelSize;
			this.x = x;
			this.y = y;
		}
		
		public void Render(Chip8.Display display) 
		{
			if (display.Modified)
			{
				int[] modified = display.GetModified();
				uint color;
				if (modified.Length > 0) Console.WriteLine(modified.Length);
				foreach (int index in modified)
				{
					int col = index % display.Columns;
					int row = index / display.Columns;
					if (display.Get(index) == 0)
					{
						color = COLOR_OFF;	
					}
					else
					{
						color = COLOR_ON;
					}
					Vita8Graphics.FillRect(color, x+col*pixelSize, y+row*pixelSize, pixelSize, pixelSize);
				}
			}
		}
	}
}

