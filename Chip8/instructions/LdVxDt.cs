using System;

namespace Chip8
{
	public class LdVxDt : Instruction
	{
		private static string CODE = "Fx07";
		private static string ASSEMBLER = "LD V{1}, DT";
		private static string DESCRIPTION = "Set Vx = delay timer value";

		public LdVxDt() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			chip8.v[x] = chip8.delayTimer;
			chip8.programCounter += 2;
		}

	}
}

