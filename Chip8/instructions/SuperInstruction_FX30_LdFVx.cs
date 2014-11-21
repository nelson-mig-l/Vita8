using System;

namespace Chip8
{
	public class SuperInstruction_FX30_LdFVx : Instruction
	{
		private static string CODE = "FX30";
		private static string ASSEMBLER = "LD F, V{1}";
		private static string DESCRIPTION = "";
		
		public SuperInstruction_FX30_LdFVx() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		// this.i = ((this.v[x] & 0xF) * 10 + font.length);
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int offset = chip8.v[x] * 10;
			chip8.indexRegister = (ushort)offset;
			chip8.programCounter += 2;			
		}
	}
}

