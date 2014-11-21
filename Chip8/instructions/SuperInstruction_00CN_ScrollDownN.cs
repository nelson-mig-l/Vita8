using System;

namespace Chip8
{
	public class SuperInstruction_00CN_ScrollDownN : Instruction
	{
		private static string CODE = "00CN";
		private static string ASSEMBLER = "";
		private static string DESCRIPTION = "";

		public SuperInstruction_00CN_ScrollDownN () : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			/* move yres-N rows down */
			/* empty N rows at the top */
		}
		
	}
}

