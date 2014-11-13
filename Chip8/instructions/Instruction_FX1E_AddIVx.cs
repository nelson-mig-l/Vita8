using System;

namespace Chip8
{
	public class Instruction_FX1E_AddIVx : Instruction
	{
		private static string CODE = "FX1E";
		private static string ASSEMBLER = "ADD I, V{1}";
		private static string DESCRIPTION = "Add the value stored in register VX to register I";
		
		public Instruction_FX1E_AddIVx() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			chip8.indexRegister += chip8.v[x];
			chip8.programCounter += 2;
		}
	}
}

