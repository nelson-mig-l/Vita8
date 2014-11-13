using System;

namespace Chip8
{
	public class Instruction_2NNN_CallAddr : Instruction
	{
		private static string CODE = "2NNN";
		private static string ASSEMBLER = "CALL 0x{1}{2}{3}";
		private static string DESCRIPTION = "Execute subroutine starting at address NNN";
		
		public Instruction_2NNN_CallAddr () : base(CODE, ASSEMBLER, DESCRIPTION)	{}
		
		public override void Execute(Chip8 chip8)
		{
			chip8.stack.Push(chip8.programCounter);
			int address = chip8.opcode & 0x0FFF;
			chip8.programCounter = (ushort)address;
		}
	}
}

