using System;
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
		private uint COLOR_OFF = 0xFF660000;
		private uint COLOR_ON = 0xFFFF6600;
		
		private int pixelSize;
		private int width;
		private int height;
		
		private bool[] pixelOnPattern = {
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true,
			true, true, true, true, true, true, true, true, true, true
		};
		
		private bool[] pixelOffPattern = {
			true, true, true, true, true, true, true, true, true, true,
			true, false, false, false, false, false, false, false, false, false,
			true, false, false, false, false, false, false, false, false, false,
			true, false, false, false, false, false, false, false, false, false,
			true, false, false, false, false, false, false, false, false, false,
			
			true, false, false, false, false, false, false, false, false, false,
			true, false, false, false, false, false, false, false, false, false,
			true, false, false, false, false, false, false, false, false, false,
			true, false, false, false, false, false, false, false, false, false,
			true, false, false, false, false, false, false, false, false, false
		};
		
		private uint[] pon = new uint[10*10];
	
		private uint[] pof = new uint[10*10];
		
		public Screen(int width, int height, int pixelSize)
		{
			this.width = width;
			this.height = height;
			this.pixelSize = pixelSize;
		}
		
		public void Configure(Configuration configuration) 
		{
			COLOR_ON = configuration.Screen.on;
			COLOR_OFF = configuration.Screen.off;
			
			for(int index = 0; index < 100; index++)
			{
				if (pixelOnPattern[index])
				{
					pon[index] = COLOR_ON;
				}
				else
				{
					pon[index] = COLOR_OFF;
				}
				if (pixelOffPattern[index])
				{
					pof[index] = COLOR_ON;
				}
				else
				{
					pof[index] = COLOR_OFF;
				}
			}
		}
		
		public void Render(Chip8.Display display, Texture2D texture) 
		{
			byte[,] gfx = display.GetAll();
			
			int index = 0;
			for (int row = 0; row < height; row++)
			{
				for (int col = 0; col < width; col++)
				{
					if (gfx[col, row] == 0)
					{
						texture.SetPixels(0, pof, col*pixelSize, row*pixelSize, pixelSize, pixelSize);
					}
					else
					{
						texture.SetPixels(0, pon, col*pixelSize, row*pixelSize, pixelSize, pixelSize);
					}
					index++;
				}
			}			
		} 

	}
}

