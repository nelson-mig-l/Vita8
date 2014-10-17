using System;

namespace Chip8
{
	public class LdVxK : Instruction
	{
		private static string CODE = "Fx0A";
		private static string ASSEMBLER = "LD V{1}, K";
		private static string DESCRIPTION = "All execution stops until a key is pressed, then the value of that key is stored in Vx";
		
		public LdVxK() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
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
		
		public override string Assembler()
		{
			return ASSEMBLER;
		}
	}
}

