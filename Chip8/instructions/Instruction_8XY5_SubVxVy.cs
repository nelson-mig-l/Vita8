using System;

namespace Chip8
{
	public class Instruction_8XY5_SubVxVy : Instruction
	{
		private static string CODE = "8XY5";
		private static string ASSEMBLER = "SUB V{1}, V{2}";
		private static string DESCRIPTION = "Subtract the value of register VY from register VX. Set VF to 00 if a borrow occurs. Set VF to 01 if a borrow does not occur";

		public Instruction_8XY5_SubVxVy() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int y = (chip8.opcode & 0x00F0) >> 4;
			bool carry = chip8.v[y] > chip8.v[x];
			chip8.v[0xF] = Convert.ToByte(!carry);					
			chip8.v[x] -= chip8.v[y];
			chip8.programCounter += 2;
		}
	}
}

