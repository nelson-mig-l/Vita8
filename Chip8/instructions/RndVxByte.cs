using System;

namespace Chip8
{
	public class RndVxByte : Instruction
	{
		private static string CODE = "Cxkk";
		private static string ASSEMBLER = "RND V{1}, {2}{3}";
		private static string DESCRIPTION = "Set Vx = random byte AND kk";

		public RndVxByte() : base(CODE, ASSEMBLER, DESCRIPTION) {}

		public override void Execute(Chip8 chip8)
		{
			byte[] buffer = new byte[1];
			chip8.rand.NextBytes(buffer);
			int x = (chip8.opcode & 0x0F00) >> 8;
			int kk = chip8.opcode & 0x00FF;
			chip8.v[x] = (byte)(buffer[0] & kk);
			chip8.programCounter += 2;
		}	

	}
}

