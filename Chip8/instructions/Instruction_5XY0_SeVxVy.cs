using System;

namespace Chip8
{
	public class Instruction_5XY0_SeVxVy : Instruction
	{
		private static string CODE = "5XY0";
		private static string ASSEMBLER = "SE V{1}, V{2}";
		private static string DESCRIPTION = "Skip the following instruction if the value of register VX is equal to the value of register VY";
		
		public Instruction_5XY0_SeVxVy () : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int y = (chip8.opcode & 0x00F0) >> 4;
			if (chip8.v[x] == chip8.v[y])
			{
				chip8.programCounter +=2;
			}
			chip8.programCounter +=2;
		}
	}
}

