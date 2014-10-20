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
			
			internal bool IsInside(TouchData touchData)
		    {
				int pixelX = Vita8Graphics.TouchPixelX(touchData);
				int pixelY = Vita8Graphics.TouchPixelY(touchData);
		        if (xo <= pixelX && xi >= pixelX && yo <= pixelY && yi >= pixelY) 
				{
		            return true;
		        }
		        return false;
		    }
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

		public Keyboard (int x, int y, int buttonSize)
		{
			//this.buttonSize = buttonSize;
			this.x = x;
			this.y = y;
			
			for (int row = 0; row < 4; row++)
			{
				for (int col = 0; col < 4; col++)
				{
					Btn btn = new Btn();
					btn.id = IDS[row, col];
					btn.xo = x + col * buttonSize + MARGIN;
					btn.yo = y + row * buttonSize + MARGIN;
					this.buttonSize = buttonSize - MARGIN * 2;
					btn.xi = btn.xo + this.buttonSize;
					btn.yi = btn.yo + this.buttonSize;
					
					btns.Add(btn);
				}
			}
		}
		
		public void Render() 
		{
			foreach(Btn btn in btns)
			{
				Vita8Graphics.FillRect(0xFFFFFFFF, btn.xo, btn.yo, this.buttonSize, this.buttonSize);	
			}
		}
		
		public void Update(Chip8.Chip8 chip8)
		{
			List<TouchData> touchDataList = Touch.GetData(0);
			foreach (TouchData touchData in touchDataList) 
			{
				foreach (Btn btn in btns) 
				{
					if (btn.IsInside(touchData))
					{
						switch (touchData.Status)
						{
						case TouchStatus.Up:
							System.Console.WriteLine(btn.id + " is pressed");
							chip8.Keypad.Set(btn.id, false);
							//chip8.key[btn.id] = 0;
							//System.Console.WriteLine("UP" + btn.id);
							break;
							
						case TouchStatus.Down:
							chip8.Keypad.Set(btn.id, true);
							//chip8.key[btn.id] = 1;
							//System.Console.WriteLine("DOWN" + btn.id);
							break;
						}
					}
				}
			}
			//var gamePadData = GamePad.GetData(0);
			
			//Input2.GamePad.GetData(0).Left.Down;
		}
	}
}

