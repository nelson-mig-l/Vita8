using System;

namespace Chip8
{
	public class Instruction_FX65_LdVxI : Instruction
	{
		private static string CODE = "FX65";
		private static string ASSEMBLER = "LD V{1}, [I]";
		private static string DESCRIPTION = "Fill registers V0 to VX inclusive with the values stored in memory starting at address I. I is set to I + X + 1 after operation";
		
		public Instruction_FX65_LdVxI() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			for (int i = 0; i <= x; i++)
			{
				chip8.v[i] = chip8.memory[chip8.indexRegister + i];			
			}
			// On the original interpreter, when the operation is done, I = I + X + 1.
			chip8.indexRegister += (ushort)(x + 1);
			chip8.programCounter += 2;			
		}
	}
}

