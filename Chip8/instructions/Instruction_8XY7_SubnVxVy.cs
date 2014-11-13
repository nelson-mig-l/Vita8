using System;

namespace Chip8
{
	public class Instruction_8XY7_SubnVxVy : Instruction
	{
		private static string CODE = "8XY7";
		private static string ASSEMBLER = "SUBN V{1}, V{2}";
		private static string DESCRIPTION = "Set register VX to the value of VY minus VX. Set VF to 00 if a borrow occurs. Set VF to 01 if a borrow does not occur";
		
		public Instruction_8XY7_SubnVxVy() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int y = (chip8.opcode & 0x00F0) >> 4;
			bool carry = chip8.v[x] > chip8.v[y];
			chip8.v[0xF] = Convert.ToByte(!carry);
			chip8.v[x] = (byte)(chip8.v[y] - chip8.v[x]);				
			chip8.programCounter += 2;
		}
	}
}

