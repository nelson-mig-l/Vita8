using System;

namespace Chip8
{
	public class CallAddr : Instruction
	{
		private static string CODE = "2nnn";
		private static string ASSEMBLER = "CALL {1}{2}{3}";
		private static string DESCRIPTION = "Call subroutine at nnn";
		
		public CallAddr () : base(CODE, ASSEMBLER, DESCRIPTION)	{}
		
		public override void Execute(Chip8 chip8)
		{
			chip8.stack[chip8.stackPointer] = chip8.programCounter;
			chip8.stackPointer++;
			int address = chip8.opcode & 0x0FFF;
			chip8.programCounter = (ushort)address;
		}
		
		public override string Assembler()
		{
			return ASSEMBLER;
		}
	}
}

