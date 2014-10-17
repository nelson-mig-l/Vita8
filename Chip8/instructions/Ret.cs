using System;

namespace Chip8
{

	public class Ret : Instruction
	{
		private static string CODE = "00EE";
		private static string ASSEMBLER = "RET";
		private static string DESCRIPTION = "Return from a subroutine";
		
		public Ret() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			chip8.stackPointer--;
			chip8.programCounter = chip8.stack[chip8.stackPointer];
			chip8.programCounter += 2;
		}	
	}
}

