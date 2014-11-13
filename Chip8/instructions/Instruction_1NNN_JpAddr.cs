using System;

namespace Chip8
{
	public class Instruction_1NNN_JpAddr : Instruction
	{
		private static string CODE = "1NNN";
		private static string ASSEMBLER = "JP 0x{1}{2}{3}";
		private static string DESCRIPTION = "Jump to address NNN";
		
		public Instruction_1NNN_JpAddr () : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int address = chip8.opcode & 0x0FFF;
			chip8.programCounter = (ushort)address;
		}
	}
}

