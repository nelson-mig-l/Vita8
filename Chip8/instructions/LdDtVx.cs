using System;

namespace Chip8
{
	public class LdDtVx : Instruction
	{
		private static string CODE = "Fx15";
		private static string ASSEMBLER = "LD DT, V{1}";
		private static string DESCRIPTION = "DT is set equal to the value of Vx";
		
		public LdDtVx() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			chip8.delayTimer = chip8.v[x];
			chip8.programCounter += 2;
		}		
		
		public override string Assembler()
		{
			return ASSEMBLER;
		}
	}
}

