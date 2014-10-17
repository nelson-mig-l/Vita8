using System;

namespace Chip8
{
	public class SkpVx : Instruction
	{
		private static string CODE = "Ex9E";
		private static string ASSEMBLER = "SKP V{1}";
		private static string DESCRIPTION = "Skip next instruction if key with the value of Vx is pressed";

		public SkpVx() : base(CODE, ASSEMBLER, DESCRIPTION)	{}
		
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
		
		public override string Assembler()
		{
			return ASSEMBLER;
		}
	}
}

