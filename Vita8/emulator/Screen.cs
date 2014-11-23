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
		
		private uint[] ponlo = new uint[10*10];
		private uint[] poflo = new uint[10*10];
		
		private uint[] ponhi = new uint[5*5];
		private uint[] pofhi = new uint[5*5];
		
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
			
			for(int index = 0; index < 10*10; index++)
			{
				if (pixelOnPattern[index])
				{
					ponlo[index] = COLOR_ON;
				}
				else
				{
					ponlo[index] = COLOR_OFF;
				}
				if (pixelOffPattern[index])
				{
					poflo[index] = COLOR_ON;
				}
				else
				{
					poflo[index] = COLOR_OFF;
				}
			}
			
			for(int index = 0; index < 5*5; index++)
			{
				if (pixelOnPattern[index])
				{
					ponhi[index] = COLOR_ON;
				}
				else
				{
					ponhi[index] = COLOR_OFF;
				}
				if (pixelOffPattern[index])
				{
					pofhi[index] = COLOR_ON;
				}
				else
				{
					pofhi[index] = COLOR_OFF;
				}
			}
			
		}
		
		public void Render(Chip8.Display display, Texture2D texture) 
		{
			if (display.Changed)
			{
				this.height = display.Height;
				this.width = display.Width;
			}
			
			byte[,] gfx = display.GetAll();
			
			int index = 0;
			for (int row = 0; row < height; row++)
			{
				for (int col = 0; col < width; col++)
				{
					if (gfx[col, row] == 0)
					{
						if (display.Mode.Equals(Chip8.DisplayMode.LOWRES))
						{
							texture.SetPixels(0, poflo, col*pixelSize, row*pixelSize, pixelSize, pixelSize);
						} 
						else
						{
							texture.SetPixels(0, pofhi, col*pixelSize/2, row*pixelSize/2, pixelSize/2, pixelSize/2);
						}
					}
					else
					{
						if (display.Mode.Equals(Chip8.DisplayMode.LOWRES))
						{
							texture.SetPixels(0, ponlo, col*pixelSize, row*pixelSize, pixelSize, pixelSize);
						}
						else
						{
							texture.SetPixels(0, ponhi, col*pixelSize/2, row*pixelSize/2, pixelSize/2, pixelSize/2);
						}
					}
					index++;
				}
			}			
		} 

	}
}

