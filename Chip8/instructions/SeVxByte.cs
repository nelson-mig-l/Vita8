using System;

namespace Chip8
{
	public class SeVxByte : Instruction
	{
		private static string CODE = "3xkk";
		private static string ASSEMBLER = "SKEQ V{1}, {2}{3}";
		private static string DESCRIPTION = "Skip next instruction if Vx = kk";

		public SeVxByte() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int kk = chip8.opcode & 0x00FF;
			if (chip8.v[x] == kk)
			{
				chip8.programCounter +=2;
			}
			chip8.programCounter +=2;
		}
		
		public override string Assembler()
		{
			return ASSEMBLER;
		}
	}
}

