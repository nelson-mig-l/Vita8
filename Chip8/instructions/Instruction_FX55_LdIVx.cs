using System;

namespace Chip8
{
	public class Instruction_FX55_LdIVx : Instruction
	{
		private static string CODE = "FX55";
		private static string ASSEMBLER = "LD [I], V{1}";
		private static string DESCRIPTION = "Store the values of registers V0 to VX inclusive in memory starting at address I. I is set to I + X + 1 after operation";
		
		public Instruction_FX55_LdIVx() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			for (int i = 0; i <= x; i++)
			{
				chip8.memory[chip8.indexRegister + i] = chip8.v[i];	
			}
			// On the original interpreter, when the operation is done, I = I + X + 1.
			chip8.indexRegister += (ushort)(x + 1);
			chip8.programCounter += 2;			
		}
	}
}

