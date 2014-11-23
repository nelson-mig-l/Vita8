using System;

namespace Chip8
{
	public class SuperInstruction_00FF_High : Instruction
	{
		private static string CODE = "00FF";
		private static string ASSEMBLER = "HIGH";
		private static string DESCRIPTION = "";
		
		public SuperInstruction_00FF_High() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			chip8.Display.Mode = DisplayMode.HIGHRES;
			chip8.programCounter += 2;			
		}
	}
}

