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
		
		public Screen(int width, int height, int pixelSize)
		{
			this.width = width;
			this.height = height;
			this.pixelSize = pixelSize;
			
			this.texture = new Texture2D(width, height, false, PixelFormat.Rgba);
		}
		
		public void Render(Chip8.Display display) 
		{
			byte[,] gfx = display.GetAll();
			uint[] pixels = new uint[gfx.Length];
			
			int index = 0;
			for (int row = 0; row < 32; row++)
			{
				for (int col = 0; col < 64; col++)
				{
					if (gfx[col, row] == 0)
					{
						pixels[index] = COLOR_OFF;
					}
					else
					{
						pixels[index] = COLOR_ON;
					}
					index++;
				}
			}
			texture.SetPixels(0, pixels, 0, 0, width, height);
			Vita8Graphics.FillTexture(texture, 160, 0, 640, 320);
		}

	}
}

