using System;

namespace Chip8
{
	public class Instruction_ANNN_LdIAddr : Instruction
	{
		private static string CODE = "ANNN";
		private static string ASSEMBLER = "LD I, 0x{1}{2}{3}";
		private static string DESCRIPTION = "Store memory address NNN in register I";
		
		public Instruction_ANNN_LdIAddr() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int address = chip8.opcode & 0x0FFF;
			chip8.indexRegister = (ushort)address;
			chip8.programCounter += 2;
		}
	}
}

