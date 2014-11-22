using System;

namespace Chip8
{
	public class Instruction_8X0E_ShlVx_Quirk : Instruction
	{
		private static string CODE = "8X0E"; // "8xyE"
		private static string ASSEMBLER = "SHL V{1}"; // "SHL V{1}, V{2}"
		private static string DESCRIPTION = "Store the value of register VY shifted left one bit in register VX. Set register VF to the most significant bit prior to the shift";
		
		public Instruction_8X0E_ShlVx_Quirk () : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int carry = chip8.v[x] >> 7;
			chip8.v[0xF] = (byte)carry;
			chip8.v[x] <<= 1;
			chip8.programCounter += 2;			
		}
	}
}

