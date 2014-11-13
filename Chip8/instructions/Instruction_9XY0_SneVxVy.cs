using System;

namespace Chip8
{
	public class Instruction_9XY0_SneVxVy : Instruction
	{
		private static string CODE = "9XY0";
		private static string ASSEMBLER = "SNE V{1}, V{2}";
		private static string DESCRIPTION = "Skip the following instruction if the value of register VX is not equal to the value of register VY";
		
		public Instruction_9XY0_SneVxVy() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int y = (chip8.opcode & 0x00F0) >> 4;
			if (chip8.v[x] != chip8.v[y])
			{
				chip8.programCounter += 2;
			}
			chip8.programCounter += 2;
		}
	}
}

