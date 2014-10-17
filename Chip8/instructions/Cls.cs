using System;

namespace Chip8
{
	public class Cls : Instruction
	{
		private static string CODE = "00E0";
		private static string ASSEMBLER = "CLS";
		private static string DESCRIPTION = "Clear the screen";
		
		public Cls() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			chip8.Display.Clear();
			chip8.programCounter += 2;			
		}
		
		public override string Assembler()
		{
			return ASSEMBLER;
		}
	}
}

