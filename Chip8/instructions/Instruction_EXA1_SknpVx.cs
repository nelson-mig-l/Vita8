using System;

namespace Chip8
{
	public class Instruction_EXA1_SknpVx : Instruction
	{
		private static string CODE = "EXA1";
		private static string ASSEMBLER = "SKNP V{1}";
		private static string DESCRIPTION = "Skip the following instruction if the key corresponding to the hex value currently stored in register VX is not pressed";
		
		public Instruction_EXA1_SknpVx() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int code = chip8.v[x];
			if(chip8.Keypad.Get(code) == 0)
			{
				chip8.programCounter += 2;
			}
			chip8.programCounter += 2;			
		}
	}
}

