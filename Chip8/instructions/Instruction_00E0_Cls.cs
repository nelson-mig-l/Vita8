using System;

namespace Chip8
{
	public class Instruction_00E0_Cls : Instruction
	{
		private static string CODE = "00E0";
		private static string ASSEMBLER = "CLS";
		private static string DESCRIPTION = "Clear the screen";
		
		public Instruction_00E0_Cls() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			chip8.Display.Clear();
			chip8.programCounter += 2;			
		}
	}
}

