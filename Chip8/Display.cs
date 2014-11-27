using System;
using System.Collections.Generic;

namespace Chip8
{
	public class Display
	{		
		private DisplayMode mode;
		
		private byte[,] gfx = new byte[1,1];
		private int width;
		private int height;
		private bool modified = false;
		private bool changed = false;
		
		public Display()
		{
			this.Reset();
		}
		
		public DisplayMode Mode {
			set {
				lock (this.gfx) {
					this.mode = value;
					DisplayResolution.Resolution resolution = DisplayResolution.SUPPORTED_RESOLUTIONS[this.mode];
					this.width = resolution.Width;
					this.height = resolution.Height;
					this.gfx = new byte[this.width, this.height];
				}
			}
			get {
				return this.mode;	
			}
		}
		
		public void Clear()
		{
			this.Mode = DisplayMode.LOWRES;
			
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
			lock(this.gfx) {
				modified = false;
				return this.gfx;
			}
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

