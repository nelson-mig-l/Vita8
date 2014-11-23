using System;

namespace Chip8
{
	public class SuperInstruction_00FE_Low : Instruction
	{
		private static string CODE = "00FE";
		private static string ASSEMBLER = "LOW";
		private static string DESCRIPTION = "";
		
		public SuperInstruction_00FE_Low() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			chip8.Display.Mode = DisplayMode.LOWRES;
			chip8.programCounter += 2;			
		}
	}
}

