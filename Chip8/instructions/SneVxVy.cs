using System;

namespace Chip8
{
	public class SneVxVy : Instruction
	{
		private static string CODE = "9xy0";
		private static string ASSEMBLER = "SNE V{1}, V{2}";
		private static string DESCRIPTION = "Skip next instruction if Vx != Vy";
		
		public SneVxVy() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
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
		
		public override string Assembler()
		{
			return ASSEMBLER;
		}
	}
}

