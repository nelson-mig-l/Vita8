using System;

namespace Chip8
{
	public class SknpVx : Instruction
	{
		private static string CODE = "ExA1";
		private static string ASSEMBLER = "SKNP V{1}";
		private static string DESCRIPTION = "Skip next instruction if key with the value of Vx is not pressed";
		
		public SknpVx() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
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

