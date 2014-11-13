using System;

namespace Chip8
{
	public class XorVxVy : Instruction
	{
		private static string CODE = "8xy3";
		private static string ASSEMBLER = "XOR V{1}, V{2}";
		private static string DESCRIPTION = "Set Vx = Vx XOR Vy";

		public XorVxVy() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int y = (chip8.opcode & 0x00F0) >> 4;
			chip8.v[x] ^= chip8.v[y];
			chip8.programCounter += 2;
		}
	}
}

