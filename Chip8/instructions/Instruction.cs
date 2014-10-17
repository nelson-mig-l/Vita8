using System;

namespace Chip8
{
	// http://www.multigesture.net/wp-content/uploads/mirror/goldroad/chip8_instruction_set.shtml
	public abstract class Instruction
	{
		private string code;
		private string assembler;
		private string description;
		
		protected Instruction(string code, string assembler, string description)
		{
			this.code = code;
			this.assembler = assembler;
			this.description = description;
		}
		
		public override string ToString ()
		{
			return string.Format("[0x{0}] {1} - {2}.", code, assembler, description);
		}
		
		public abstract void Execute(Chip8 chip8);
	}
}

