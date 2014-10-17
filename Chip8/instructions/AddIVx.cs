using System;

namespace Chip8
{
	public class AddIVx : Instruction
	{
		private static string CODE = "Fx1E";
		private static string ASSEMBLER = "ADD I, V{1}";
		private static string DESCRIPTION = "The values of I and Vx are added, and the results are stored in I";
		
		public AddIVx() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			bool carry = (chip8.indexRegister + chip8.v[x]) > 0x0FFF;
			chip8.v[0xF] = Convert.ToByte(carry);
			chip8.indexRegister += chip8.v[x];
			chip8.programCounter += 2;
		}
	}
}

