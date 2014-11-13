using System;

namespace Chip8
{
	public class JpV0Addr : Instruction
	{
		private static string CODE = "Bnnn";
		private static string ASSEMBLER = "JP V0, 0x{1}{2}{3}";
		private static string DESCRIPTION = "Jump to location nnn + V0";

		public JpV0Addr() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int address = (chip8.opcode & 0x0FFF) + chip8.v[0];
			chip8.programCounter = (ushort)address;
		}
	}
}

