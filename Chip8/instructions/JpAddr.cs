using System;

namespace Chip8
{
	public class JpAddr : Instruction
	{
		private static string CODE = "1nnn";
		private static string ASSEMBLER = "JP {1}{2}{3}";
		private static string DESCRIPTION = "Jump to location nnn";
		
		public JpAddr () : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int address = chip8.opcode & 0x0FFF;
			chip8.programCounter = (ushort)address;
		}
		
		public override string Assembler()
		{
			return ASSEMBLER;
		}
	}
}

