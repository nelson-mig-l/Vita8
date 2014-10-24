using System;
using System.Collections.Generic;

using Sce.PlayStation.Core.Input;

using Chip8;

namespace Vita8
{
	public class Keyboard
	{
		private class Btn
		{
			internal int id;
			internal int xo;
			internal int yo;
			internal int xi;
			internal int yi;
		}
		
		private static int[,] IDS = {
			{0x1, 0x2, 0x3, 0xC},
			{0x4, 0x5, 0x6, 0xD},
			{0x7, 0x8, 0x9, 0xE},
			{0xA, 0x0, 0xB, 0xF}
		};
		
		private static int MARGIN = 2;
		private int buttonSize;
		private int x;
		private int y;
		private List<Btn> btns = new List<Btn>();

		public Keyboard ()
		{
		}
		
		
		public void Update(Chip8.Chip8 chip8)
		{
			chip8.Keypad.Set(0x7, IsPressed(GamePadButtons.Cross));
			chip8.Keypad.Set(0x1, IsPressed(GamePadButtons.Up));
			chip8.Keypad.Set(0x4, IsPressed(GamePadButtons.Down));
		}
		
		private static bool IsPressed(GamePadButtons button) 
		{
			var gamePadData = GamePad.GetData(0);
			if((gamePadData.Buttons & button) == button) {
				return true;
			}
			return false;
		}
	}
}

