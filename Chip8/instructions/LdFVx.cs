using System;

namespace Chip8
{
	public class LdFVx : Instruction
	{
		private static string CODE = "Fx29";
		private static string ASSEMBLER = "LD F, V{1}";
		private static string DESCRIPTION = "Set I = location of sprite for digit Vx";
		
		public LdFVx() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int offset = chip8.v[x] * 0x5;
			chip8.indexRegister = (ushort)offset;
			chip8.programCounter += 2;			
		}		
		
		public override string Assembler()
		{
			return ASSEMBLER;
		}
	}
}

