using System;

namespace Chip8
{
	public class Instruction_8XY0_LdVxVy : Instruction
	{
		private static string CODE = "8XY0";
		private static string ASSEMBLER = "LD V{1}, V{2}";
		private static string DESCRIPTION = "Store the value of register VY in register VX";
		
		public Instruction_8XY0_LdVxVy () : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int y = (chip8.opcode & 0x00F0) >> 4;
			chip8.v[x] = chip8.v[y];
			chip8.programCounter += 2;			
		}
	}
}

