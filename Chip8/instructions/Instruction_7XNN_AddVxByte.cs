using System;

namespace Chip8
{
	public class Instruction_7XNN_AddVxByte : Instruction
	{
		private static string CODE = "7XNN";
		private static string ASSEMBLER = "ADD V{1}, 0x{2}{3}";
		private static string DESCRIPTION = "Add the value NN to register VX";

		public Instruction_7XNN_AddVxByte () : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int nn = chip8.opcode & 0x00FF;
			int res = chip8.v[x] + nn;
			chip8.v[x] = (byte)res;
			chip8.programCounter += 2;
		}
	}
}

