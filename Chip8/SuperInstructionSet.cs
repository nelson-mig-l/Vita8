using System;

namespace Chip8
{
	// http://www.multigesture.net/wp-content/uploads/mirror/goldroad/chip8_instruction_set.shtml
	
	// http://devernay.free.fr/hacks/chip8/schip.txt
	
	public class SuperInstructionSet
	{
		private static Instruction LD_HF_VX = new SuperInstruction_FX30_LdHfVx();
		private static Instruction LD_R_VX = new SuperInstruction_FX75_LdRVx();
		private static Instruction LD_VX_R = new SuperInstruction_FX85_LdVxR();
		private static Instruction HIGH = new SuperInstruction_00FF_High();
		private static Instruction LOW = new SuperInstruction_00FE_Low();
		
		private static ushort MASK_X_XX = 0xF0FF;
		
		public static Instruction GetInstruction(ushort opcode)
		{
			if ((opcode & MASK_X_XX) == 0xF030) return LD_HF_VX;	
			if ((opcode & MASK_X_XX) == 0xF075) return LD_R_VX;	
			if ((opcode & MASK_X_XX) == 0xF085) return LD_VX_R;	
			
			if (opcode == 0x00FF) return HIGH;
			if (opcode == 0x00FE) return LOW;
			
			return InstructionSet.GetInstruction(opcode);
		}
	}
}

