using System;

namespace Chip8
{
	public class LdIVx : Instruction
	{
		private static string CODE = "Fx55";
		private static string ASSEMBLER = "LD [I], V{1}";
		private static string DESCRIPTION = "Store registers V0 through Vx in memory starting at location I";
		
		public LdIVx() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
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
		
		public override string Assembler()
		{
			return ASSEMBLER;
		}
	}
}

