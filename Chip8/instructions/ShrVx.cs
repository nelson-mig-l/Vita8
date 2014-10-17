using System;

namespace Chip8
{
	public class ShrVx : Instruction
	{
		private static string CODE = "8x06"; // "8xy6"
		private static string ASSEMBLER = "SHR V{1}"; // "SHR V{1}, V{2}"
		private static string DESCRIPTION = "Set Vx = Vx SHR 1";
		
		public ShrVx() : base(CODE, ASSEMBLER, DESCRIPTION)	{}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int carry = chip8.v[x] & 0x1;
			chip8.v[0xF] = (byte)carry;
			chip8.v[x] >>= 1;
			chip8.programCounter += 2;			
		}
		
		public override string Assembler()
		{
			return ASSEMBLER;
		}
	}
}

