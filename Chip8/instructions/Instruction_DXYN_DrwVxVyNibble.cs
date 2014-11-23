using System;

namespace Chip8
{
	//http://laurencescotford.co.uk/?p=304
	
	// http://omokute.blogspot.com/2012/06/emulation-basics-write-your-own-chip-8.html
	
	//http://code.google.com/p/pythonchip8/source/browse/chip8.py
	
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
			int coordx = chip8.v[x];
			int coordy = chip8.v[y];
			int height = chip8.opcode & 0x000F;
			
			coordx = coordx % chip8.Display.Width;
			coordy = coordy % chip8.Display.Height;


			chip8.v[0xF] = 0; // no colision
			
			for (int yline = 0; yline < height; yline++)
			{
				byte data = chip8.memory[chip8.indexRegister + yline];
				
				int xpixelinv = 0x7;
				for(int xpixel = 0; xpixel < 8; xpixel++, xpixelinv--)
				{
					int mask = 1 << xpixelinv;
					
					int xx = coordx + xpixel;
					int yy = coordy + yline;
					
					//start fix
					//xx = xx % chip8.Display.Width;
					//yy = yy % chip8.Display.Height;
					//end fix
					if ((xx >= chip8.Display.Width) || (yy >= chip8.Display.Height)) continue;
					
					if ((data & mask) != 0)
					{
						byte state = chip8.Display.Get(xx, yy);
						if (state != 0)
						{
							chip8.v[0xF] = 1;
						}
						state ^=1;
						chip8.Display.Set(xx, yy, state);
					}
				}
			}
			chip8.programCounter += 2;			
		}
	}
}

