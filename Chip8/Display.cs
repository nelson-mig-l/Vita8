using System;
using System.Collections.Generic;

namespace Chip8
{
	public class Display
	{
		private byte[] gfx; //= new byte[64*32]
		private int columns;
		private int rows;
		private bool modified = false;
		private List<int> modifiedPixels;
		
		public Display(int columns, int rows)
		{
			this.columns = columns;
			this.rows = rows;
			this.gfx = new byte[columns * rows];
			this.modifiedPixels = new List<int>(columns * rows);
			this.Reset();
		}
		
		public void Clear()
		{
			for (int i = 0; i < columns * rows; i++)
			{
				this.gfx[i] = 0;
				this.modifiedPixels.Add(i);
			}
			modified = true;
		}
		
		public void Reset()
		{
			Clear();
		}
		
		internal void Set(int i, byte v)
		{
			this.gfx[i] = v;
			modified = true;
		}
		
		public byte Get(int i)
		{
			return this.gfx[i];
		}
		
		public int Columns 
		{
			get { return columns; }
		}
		
		public int Rows
		{
			get { return rows; }
		}
		
		public bool Modified
		{
			get { return modified; }
		}
		
		public int[] GetModified()
		{
			int[] rv = modifiedPixels.ToArray();
			modified = false;
			return rv;
		}
	}
}

