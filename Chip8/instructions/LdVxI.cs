using System;

namespace Chip8
{
	public class LdVxI : Instruction
	{
		private static string CODE = "Fx65";
		private static string ASSEMBLER = "LD V{1}, [I]";
		private static string DESCRIPTION = "Read registers V0 through Vx from memory starting at location I";
		
		public LdVxI() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
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
		
		public override string Assembler()
		{
			return ASSEMBLER;
		}
	}
}

