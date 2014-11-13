using System;

namespace Chip8
{
	public class Instruction_6XNN_LdVxByte : Instruction
	{
		private static string CODE = "6XNN";
		private static string ASSEMBLER = "LD V{1}, 0x{2}{3}";
		private static string DESCRIPTION = "Store number NN in register VX";

		public Instruction_6XNN_LdVxByte () : base(CODE, ASSEMBLER, DESCRIPTION)	{}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int nn = chip8.opcode & 0x00FF;
			chip8.v[x] = (byte)nn;
			chip8.programCounter +=2;
		}
	}
}

