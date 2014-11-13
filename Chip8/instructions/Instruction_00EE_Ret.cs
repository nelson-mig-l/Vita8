using System;

namespace Chip8
{

	public class Instruction_00EE_Ret : Instruction
	{
		private static string CODE = "00EE";
		private static string ASSEMBLER = "RET";
		private static string DESCRIPTION = "Return from a subroutine";
		
		public Instruction_00EE_Ret() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			chip8.programCounter = chip8.stack.Pop();
			chip8.programCounter += 2;
		}	
	}
}

