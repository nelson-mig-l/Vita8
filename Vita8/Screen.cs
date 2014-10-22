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
		private static uint COLOR_OFF = 0xFF660000;
		private static uint COLOR_ON = 0xFFFF6600;
		
		private int pixelSize;
		private int width;
		private int height;
		private Texture2D texture;
		
		private uint[] pon = {
			COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,
			COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,
			COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,
			COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,
			COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,
			
			COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,
			COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,
			COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,
			COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,
			COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON
		};
		
		private uint[] pof = {
			COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,COLOR_ON,
			COLOR_ON,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,
			COLOR_ON,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,
			COLOR_ON,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,
			COLOR_ON,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,
			
			COLOR_ON,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,
			COLOR_ON,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,
			COLOR_ON,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,
			COLOR_ON,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,
			COLOR_ON,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,COLOR_OFF,
		};
		
		public Screen(int width, int height, int pixelSize)
		{
			this.width = width;
			this.height = height;
			this.pixelSize = pixelSize;
			
			this.texture = new Texture2D(width*pixelSize, height*pixelSize, false, PixelFormat.Rgba);
		}
		
		public void Render(Chip8.Display display) 
		{
			Vita8Graphics.Clear();
			
			byte[,] gfx = display.GetAll();
			uint[] pixels = new uint[gfx.Length*pixelSize];
			
			int index = 0;
			for (int row = 0; row < height; row++)
			{
				for (int col = 0; col < width; col++)
				{
					if (gfx[col, row] == 0)
					{
						pixels[index] = COLOR_OFF;
						texture.SetPixels(0, pof, col*pixelSize, row*pixelSize, pixelSize, pixelSize);
					}
					else
					{
						pixels[index] = COLOR_ON;
						texture.SetPixels(0, pon, col*pixelSize, row*pixelSize, pixelSize, pixelSize);
					}
					index++;
				}
			}
			int upperLeftX = (Vita8Graphics.Width - width * pixelSize) / 2;
			int upperLeftY = (Vita8Graphics.Height - height * pixelSize) / 2;
			Vita8Graphics.FillTexture(texture, upperLeftX, upperLeftY, width*pixelSize, height*pixelSize);
			
			Vita8Graphics.SwapBuffers();
		}
	}
}

