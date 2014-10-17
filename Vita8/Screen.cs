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
		
		public void Render(byte[] gfx) 
		{
			for (int row = 0; row < 32; row++)
			{
				for (int col = 0; col < 64; col++)
				{
					if (gfx[row * 64 + col] == 0)
					{
						Vita8Graphics.FillRect(COLOR_OFF, x+col*pixelSize, y+row*pixelSize, pixelSize, pixelSize);	
					}
					else
					{
						Vita8Graphics.FillRect(COLOR_ON, x+col*pixelSize, y+row*pixelSize, pixelSize, pixelSize);	
					}
				}
			}
		}
		
	}
}

