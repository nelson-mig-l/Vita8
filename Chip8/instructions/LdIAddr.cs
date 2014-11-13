using System;

namespace Chip8
{
	public class LdIAddr : Instruction
	{
		private static string CODE = "Annn";
		private static string ASSEMBLER = "LD I, 0x{1}{2}{3}";
		private static string DESCRIPTION = "Set I = nnn";
		
		public LdIAddr() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int address = chip8.opcode & 0x0FFF;
			chip8.indexRegister = (ushort)address;
			chip8.programCounter += 2;
		}
	}
}

