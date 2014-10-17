using System;

namespace Chip8
{
	public class Cls : Instruction
	{
		private static string CODE = "00E0";
		private static string ASSEMBLER = "CLS";
		private static string DESCRIPTION = "Clear the screen";
		
		public Cls() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			for (int i = 0; i < 2048; ++i)
				chip8.gfx[i] = 0x0;
			chip8.drawFlag = true;
			chip8.programCounter += 2;			
		}
	}
}

