using System;

namespace Chip8
{
	public class LdBVx : Instruction
	{
		private static string CODE = "Fx33";
		private static string ASSEMBLER = "LD B, V{1}";
		private static string DESCRIPTION = "Store BCD representation of Vx in memory locations I, I+1, and I+2";

		public LdBVx () : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			chip8.memory[chip8.indexRegister] = (byte)(chip8.v[x] / 100);
			chip8.memory[chip8.indexRegister+ 1] = (byte)((chip8.v[x] / 10) % 10);
			chip8.memory[chip8.indexRegister+ 2] = (byte)((chip8.v[x] % 100) % 10);					
			chip8.programCounter += 2;			
		}
		
		public override string Assembler()
		{
			return ASSEMBLER;
		}
	}
}

