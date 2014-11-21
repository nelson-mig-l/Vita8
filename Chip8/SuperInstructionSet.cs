using System;

namespace Chip8
{
	// http://www.multigesture.net/wp-content/uploads/mirror/goldroad/chip8_instruction_set.shtml
	
	// http://devernay.free.fr/hacks/chip8/schip.txt
	
	public class SuperInstructionSet
	{
		private static Instruction LD_F_VX = new SuperInstruction_FX30_LdFVx();
		private static Instruction LD_I_VX = new SuperInstruction_FX75_LdIVx();
		private static Instruction LD_VX_I = new SuperInstruction_FX85_LdVxI();
		
		private static ushort MASK_X_XX = 0xF0FF;
		
		public static Instruction GetInstruction(ushort opcode)
		{
			if ((opcode & MASK_X_XX) == 0xF030) return LD_F_VX;	
			if ((opcode & MASK_X_XX) == 0xF075) return LD_I_VX;	
			if ((opcode & MASK_X_XX) == 0xF085) return LD_VX_I;	
			
			return InstructionSet.GetInstruction(opcode);
		}
	}
}

