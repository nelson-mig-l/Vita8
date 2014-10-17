using System;

namespace Chip8
{
	public class DrwVxVyNibble : Instruction
	{
		private static string CODE = "Dxyn";
		private static string ASSEMBLER = "DRW V{1}, V{2}, {3}";
		private static string DESCRIPTION = "Display n-byte sprite starting at memory location I at (Vx, Vy), set VF = collision";

		public DrwVxVyNibble() : base(CODE, ASSEMBLER, DESCRIPTION)	{}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int y = (chip8.opcode & 0x00F0) >> 4;
			int height = chip8.opcode & 0x000F;
			ushort row = chip8.v[x];
			ushort col = chip8.v[y];
			
			ushort pixel;

			chip8.v[0xF] = 0;
			for (int yline = 0; yline < height; yline++)
			{
				pixel = chip8.memory[chip8.indexRegister + yline];
				for(int xline = 0; xline < 8; xline++)
				{
					if((pixel & (0x80 >> xline)) != 0)
					{
						int index = row + xline + ((col + yline) * 64);
						if(chip8.Display.Get(index) == 1)
						{
							chip8.v[0xF] = 1;                                    
						}
						chip8.Display.Set(index, (byte)(chip8.Display.Get(index) ^ 1));
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

