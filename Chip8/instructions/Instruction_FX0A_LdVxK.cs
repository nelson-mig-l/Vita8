using System;

namespace Chip8
{
	public class Instruction_FX0A_LdVxK : Instruction
	{
		private static string CODE = "FX0A";
		private static string ASSEMBLER = "LD V{1}, K";
		private static string DESCRIPTION = "Wait for a keypress and store the result in register VX";
		
		public Instruction_FX0A_LdVxK() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			bool keyPress = false;
			int x = (chip8.opcode & 0x0F00) >> 8;

			for(int i = 0; i < 16; i++)
			{
				if(chip8.Keypad.Get(i) != 0)
				{
					chip8.v[x] = (byte)i;
					keyPress = true;
				}
			}

			// If we didn't received a keypress, skip this cycle and try again.
			if(keyPress)
			{
				chip8.programCounter += 2;			
			}
		}
	}
}

