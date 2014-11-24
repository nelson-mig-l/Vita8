using System;

namespace Chip8
{
	public class Instruction_Invalid : Instruction
	{
		private static string CODE = "ZZZZ";
		private static string ASSEMBLER = "_INVALID_";
		private static string DESCRIPTION = "Any instruction that is not recognized";
		
		public Instruction_Invalid() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			Console.WriteLine("opcode not recognized: " + chip8.programCounter.ToString("X4") + ":" + chip8.opcode.ToString("X4"));
			chip8.programCounter += 2;			
		}

	}
}

