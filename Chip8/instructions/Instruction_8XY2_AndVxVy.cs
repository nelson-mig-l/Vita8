using System;

namespace Chip8
{
	public class Instruction_8XY2_AndVxVy : Instruction
	{
		private static string CODE = "8XY2";
		private static string ASSEMBLER = "AND V{1}, V{2}";
		private static string DESCRIPTION = "Set VX to VX AND VY";

		public Instruction_8XY2_AndVxVy() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int y = (chip8.opcode & 0x00F0) >> 4;
			chip8.v[x] &= chip8.v[y];
			chip8.programCounter += 2;
		}
	}
}

