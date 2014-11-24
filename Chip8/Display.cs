using System;
using System.Collections.Generic;

namespace Chip8
{
	public enum DisplayMode
	{
		LOWRES, HIGHRES
	}
	
	public class Display
	{

		private static readonly Tuple<int, int> LOWRES_SIZE = new Tuple<int, int>(64, 32);
		private static readonly Tuple<int, int> HIRES_SIZE = new Tuple<int, int>(128, 64);
		
		private Dictionary<DisplayMode, Tuple<int, int>> supportedModes = new Dictionary<DisplayMode, Tuple<int, int>>()
		{
			{ DisplayMode.LOWRES, LOWRES_SIZE },
			{ DisplayMode.HIGHRES, HIRES_SIZE }
		};
		
		
		private DisplayMode mode;
		
		private byte[,] gfx = new byte[1,1];
		private int width;
		private int height;
		private bool modified = false;
		private bool changed = false;
		
		public Display()
		{
			this.Mode = DisplayMode.LOWRES;
			//this.width = width;
			//this.height = height;
			//this.gfx = new byte[width, height];
			this.Reset();
		}
		
		public DisplayMode Mode {
			set {
				lock (this.gfx) {
					this.mode = value;
					//
					Tuple<int, int> resolution = supportedModes[this.mode];
					this.width = resolution.Item1;
					this.height = resolution.Item2;
					this.gfx = new byte[this.width, this.height];
					this.changed = true;
				}
			}
			get {
				return this.mode;	
			}
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
		
		// are the contents modified?
		public bool Modified
		{
			get { return modified; }
		}
		
		public bool Changed
		{
			get { return changed; }
		}
	}
}

