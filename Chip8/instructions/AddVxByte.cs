using System;

namespace Chip8
{
	public class AddVxByte : Instruction
	{
		private static string CODE = "7xkk";
		private static string ASSEMBLER = "ADD V{1}, 0x{2}{3}";
		private static string DESCRIPTION = "Set Vx = Vx + kk";

		public AddVxByte () : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int kk = chip8.opcode & 0x00FF;
			chip8.v[x] += (byte)kk;
			chip8.programCounter += 2;
		}
		
		public override string Assembler()
		{
			return ASSEMBLER;
		}
	}
}

