using System;

namespace Chip8
{
	public class Instruction_FX29_LdFVx : Instruction
	{
		private static string CODE = "FX29";
		private static string ASSEMBLER = "LD F, V{1}";
		private static string DESCRIPTION = "Set I to the memory address of the sprite data corresponding to the hexadecimal digit stored in register VX";
		
		public Instruction_FX29_LdFVx() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int offset = chip8.v[x] * 5;
			chip8.indexRegister = (ushort)offset;
			chip8.programCounter += 2;			
		}
	}
}

