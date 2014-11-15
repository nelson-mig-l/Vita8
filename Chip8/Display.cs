using System;
using System.Collections.Generic;

namespace Chip8
{
	public class Display
	{
		private byte[,] gfx;
		private int width;
		private int height;
		private bool modified = false;
		
		public Display(int width, int height)
		{
			this.width = width;
			this.height = height;
			this.gfx = new byte[width, height];
			this.Reset();
		}
		
		public void Clear()
		{
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					this.gfx[x, y] = 0;
				}
			}
			modified = true;
		}
		
		public void Reset()
		{
			Clear();
		}
		
		internal void Set(int index, byte v)
		{
			int col = index % width;
			int row = (index - col) / width;
			Set(col, row, v);
		}

		internal void Set(int col, int row, byte v)
		{
			this.gfx[col, row] = v;
			modified = true;
		}
		
		public byte Get(int col, int row)
		{
			return this.gfx[col, row];
		}
		
		public byte[,] GetAll()
		{
			modified = false;
			return this.gfx;
		}
		
		public int Width 
		{
			get { return width; }
		}
		
		public int Height
		{
			get { return height; }
		}
		
		public bool Modified
		{
			get { return modified; }
		}
	}
}

