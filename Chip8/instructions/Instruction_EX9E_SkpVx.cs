using System;

namespace Chip8
{
	public class Instruction_EX9E_SkpVx : Instruction
	{
		private static string CODE = "EX9E";
		private static string ASSEMBLER = "SKP V{1}";
		private static string DESCRIPTION = "Skip the following instruction if the key corresponding to the hex value currently stored in register VX is pressed";

		public Instruction_EX9E_SkpVx() : base(CODE, ASSEMBLER, DESCRIPTION)	{}
		
		public override void Execute(Chip8 chip8)
		{
			int x = (chip8.opcode & 0x0F00) >> 8;
			int code = chip8.v[x];
			if(chip8.Keypad.Get(code) != 0)
			{
				chip8.programCounter += 2;
			}
			chip8.programCounter += 2;			
		}
	}
}

