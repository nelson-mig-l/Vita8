using System;

namespace Chip8
{
	public class Instruction_8XY4_AddVxVy : Instruction
	{
		private static string CODE = "8XY4";
		private static string ASSEMBLER = "ADD V{1}, V{2}";
		private static string DESCRIPTION = "Add the value of register VY to register VX. Set VF to 01 if a carry occurs. Set VF to 00 if a carry does not occur";

		public Instruction_8XY4_AddVxVy() :  base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int y = (chip8.opcode & 0x00F0) >> 4;
			int res = chip8.v[x] + chip8.v[y];
			bool carry = res > 0xFF;
			chip8.v[0xF] = Convert.ToByte(carry);
			chip8.v[x] = (byte)res;
			chip8.programCounter += 2;					
		}
	}
}

