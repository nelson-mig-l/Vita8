using System;

namespace Chip8
{
	public class LdStVx : Instruction
	{
		private static string CODE = "Fx18";
		private static string ASSEMBLER = "LD ST, V{1}";
		private static string DESCRIPTION = "Set sound timer = Vx";

		public LdStVx() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			chip8.soundTimer = chip8.v[x];
			chip8.programCounter += 2;
		}
	}
}

