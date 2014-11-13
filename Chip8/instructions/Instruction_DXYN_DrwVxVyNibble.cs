using System;

namespace Chip8
{
	//http://laurencescotford.co.uk/?p=304
	public class Instruction_DXYN_DrwVxVyNibble : Instruction
	{
		private static string CODE = "DXYN";
		private static string ASSEMBLER = "DRW V{1}, V{2}, 0x{3}";
		private static string DESCRIPTION = "Draw a sprite at position VX, VY with N bytes of sprite data starting at the address stored in I Set VF to 01 if any set pixels are changed to unset, and 00 otherwise";

		public Instruction_DXYN_DrwVxVyNibble() : base(CODE, ASSEMBLER, DESCRIPTION)	{}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int y = (chip8.opcode & 0x00F0) >> 4;
			int height = chip8.opcode & 0x000F;
			ushort xx = chip8.v[x];
			ushort yy = chip8.v[y];

			chip8.v[0xF] = 0; // no colision
			for (int h = 0; h < height; h++)
			{
				byte spriteLine = chip8.memory[chip8.indexRegister + h];
				for(int w = 0; w < 8; w++)
				{
					int xw = xx + w;
					int yh = yy + h;
					// if (xw > 63) //Console.WriteLine("xw = " + xw);
					xw = Sanitize(xw, 64);
					// if (yh > 31) //Console.WriteLine("yh = " + yh);
					yh = Sanitize(yh, 32);
					
					if((spriteLine & (0x80 >> w)) != 0)
					{
						byte state = chip8.Display.Get(xw, yh);
						if (state == 1)
						{
							chip8.v[0xF] = 1; // colision  
							//Console.WriteLine("collision@" + xw + "," + yh);
							chip8.Display.Set(xw, yh , 0);
						} else {
						chip8.Display.Set(xw, yh , 1);//(byte)(state ^ 1));
						}
					} 
					else 
					{
						//chip8.Display.Set(xw, yh , 0);
					}
				}
			}
			chip8.programCounter += 2;			
		}
		
		private int Sanitize(int v, int k)
		{
			while (v >= k)
			{
				v -= k;
			}
			while (v < 0)
			{
				v += k;
			}
			//Console.WriteLine("@" + v);
			return v;
		}
	}
}

