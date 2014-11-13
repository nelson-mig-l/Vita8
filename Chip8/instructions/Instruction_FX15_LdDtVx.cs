using System;

namespace Chip8
{
	public class Instruction_FX15_LdDtVx : Instruction
	{
		private static string CODE = "FX15";
		private static string ASSEMBLER = "LD DT, V{1}";
		private static string DESCRIPTION = "Set the delay timer to the value of register VX";
		
		public Instruction_FX15_LdDtVx() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			chip8.delayTimer = chip8.v[x];
			chip8.programCounter += 2;
		}
	}
}

