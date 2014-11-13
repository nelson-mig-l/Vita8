using System;

namespace Chip8
{
	public class LdVxByte : Instruction
	{
		private static string CODE = "6xkk";
		private static string ASSEMBLER = "LD V{1}, 0x{2}{3}";
		private static string DESCRIPTION = "Set Vx = kk";

		public LdVxByte () : base(CODE, ASSEMBLER, DESCRIPTION)	{}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int kk = chip8.opcode & 0x00FF;
			chip8.v[x] = (byte)kk;
			chip8.programCounter +=2;
		}
	}
}

