using System;

namespace Chip8
{
	public class Instruction_8X06_ShrVx_Quirk : Instruction
	{
		private static string CODE = "8X06"; // "8xy6"
		private static string ASSEMBLER = "SHR V{1}"; // "SHR V{1}, V{2}"
		private static string DESCRIPTION = "Store the value of register VY shifted right one bit in register VX. Set register VF to the least significant bit prior to the shift";
		
		public Instruction_8X06_ShrVx_Quirk() : base(CODE, ASSEMBLER, DESCRIPTION)	{}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int carry = chip8.v[x] & 0x1;
			chip8.v[0xF] = (byte)carry;
			chip8.v[x] >>= 1;
			chip8.programCounter += 2;			
		}
	}
}

