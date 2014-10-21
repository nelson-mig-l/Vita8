using System;

namespace Chip8
{
	public class DrwVxVyNibble : Instruction
	{
		private static string CODE = "Dxyn";
		private static string ASSEMBLER = "DRW V{1}, V{2}, 0x{3}";
		private static string DESCRIPTION = "Display n-byte sprite starting at memory location I at (Vx, Vy), set VF = collision";

		public DrwVxVyNibble() : base(CODE, ASSEMBLER, DESCRIPTION)	{}
		
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
				ushort pixel = chip8.memory[chip8.indexRegister + h];
				for(int w = 0; w < 8; w++)
				{
					if((pixel & (0x80 >> w)) != 0)
					{
						int xw = xx + w;
						int yh = yy + h;
						if (xw > 63) continue;
						if (yh > 31) continue;
						byte state = chip8.Display.Get(xw, yh);
						if (state == 1)
						{
							chip8.v[0xF] = 1; // colision                                  
						}
						chip8.Display.Set(xw, yh , (byte)(state ^ 1));
					}
				}
			}
			chip8.programCounter += 2;			
		}
		
		public override string Assembler()
		{
			return ASSEMBLER;
		}
	}
}

