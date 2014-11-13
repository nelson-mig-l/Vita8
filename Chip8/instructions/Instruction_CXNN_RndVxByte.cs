using System;

namespace Chip8
{
	public class Instruction_CXNN_RndVxByte : Instruction
	{
		private static string CODE = "CXNN";
		private static string ASSEMBLER = "RND V{1}, 0x{2}{3}";
		private static string DESCRIPTION = "Set VX to a random number with a mask of NN";

		public Instruction_CXNN_RndVxByte() : base(CODE, ASSEMBLER, DESCRIPTION) {}

		public override void Execute(Chip8 chip8)
		{
			byte[] buffer = new byte[1];
			chip8.rand.NextBytes(buffer);
			byte rand = buffer[0];
			int x = (chip8.opcode & 0x0F00) >> 8;
			int nn = chip8.opcode & 0x00FF;
			chip8.v[x] = (byte)(rand & nn);
			chip8.programCounter += 2;
		}	
	}
}

