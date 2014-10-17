using System;

namespace Chip8
{
	public class SubnVxVy : Instruction
	{
		private static string CODE = "8xy7";
		private static string ASSEMBLER = "SUBN V{1}, V{2}";
		private static string DESCRIPTION = "Set Vx = Vy - Vx, set VF = NOT borrow";
		
		public SubnVxVy() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int y = (chip8.opcode & 0x00F0) >> 4;
			bool carry = chip8.v[x] > chip8.v[y];
			chip8.v[0xF] = Convert.ToByte(!carry);
			chip8.v[x] = (byte)(chip8.v[y] - chip8.v[x]);				
			chip8.programCounter += 2;
		}
		
		public override string Assembler()
		{
			return ASSEMBLER;
		}
	}
}

