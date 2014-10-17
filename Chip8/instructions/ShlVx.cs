using System;

namespace Chip8
{
	public class ShlVx : Instruction
	{
		private static string CODE = "8x0E"; // "8xyE"
		private static string ASSEMBLER = "SHL V{1}"; // "SHL V{1}, V{2}"
		private static string DESCRIPTION = "Set Vx = Vx SHL 1";
		
		public ShlVx () : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
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

