using System;

namespace Chip8
{
	public class Instruction_3XNN_SeVxByte : Instruction
	{
		private static string CODE = "3XNN";
		private static string ASSEMBLER = "SE V{1}, 0x{2}{3}";
		private static string DESCRIPTION = "Skip the following instruction if the value of register VX equals NN";

		public Instruction_3XNN_SeVxByte() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int nn = chip8.opcode & 0x00FF;
			if (chip8.v[x] == nn)
			{
				chip8.programCounter +=2;
			}
			chip8.programCounter +=2;
		}
	}
}

