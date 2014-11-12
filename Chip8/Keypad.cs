using System;

namespace Chip8
{
	public class Keypad
	{
		private byte[] state; 
		private int size;
		
		public Keypad(int size)
		{
			this.size = size;
			this.state = new byte[size];
			Reset();
		}
		
		public void Reset()
		{
			for (int i = 0; i < 16; i++)
			{
				this.state[i] = 0;
			}			
		}
		
		public void Set(int code, bool pressed)
		{
			state[code] = Convert.ToByte(pressed);
		}
		
		internal byte Get(int code)
		{
			Console.WriteLine("Reading key " + code.ToString("X"));
			return state[code];
		}
	}
}

