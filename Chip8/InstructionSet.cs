using System;

namespace Chip8
{
	// http://www.multigesture.net/wp-content/uploads/mirror/goldroad/chip8_instruction_set.shtml
	
	// http://devernay.free.fr/hacks/chip8/C8TECH10.HTM#00E0
	
	// http://devernay.free.fr/hacks/chip8/chip8.html
	
	// http://mattmik.com/chip8.html
	
	public class InstructionSet
	{
		// Should be set for some games
		public static bool QuirkShift = false;
		
		private static Instruction INVALID = new Instruction_Invalid();
		private static Instruction CLS = new Instruction_00E0_Cls();
		private static Instruction RET = new Instruction_00EE_Ret();
		private static Instruction JP_ADDR = new Instruction_1NNN_JpAddr();
		private static Instruction CALL_ADDR = new Instruction_2NNN_CallAddr();
		private static Instruction SE_VX_BYTE = new Instruction_3XNN_SeVxByte();
		private static Instruction SNE_VX_BYTE = new Instruction_4XNN_SneVxByte();
		private static Instruction SE_VX_VY = new Instruction_5XY0_SeVxVy();
		private static Instruction LD_VX_BYTE = new Instruction_6XNN_LdVxByte();		
		private static Instruction ADD_VX_BYTE = new Instruction_7XNN_AddVxByte();
		private static Instruction LD_VX_VY = new Instruction_8XY0_LdVxVy();
		private static Instruction OR_VX_VY = new Instruction_8XY1_OrVxVy();
		private static Instruction AND_VX_VY = new Instruction_8XY2_AndVxVy();
		private static Instruction XOR_VX_VY = new Instruction_8XY3_XorVxVy();
		private static Instruction ADD_VX_VY = new Instruction_8XY4_AddVxVy();
		private static Instruction SUB_VX_VY = new Instruction_8XY5_SubVxVy();
		private static Instruction SHR_VX_VY = new Instruction_8XY6_ShrVxVy(); 
		private static Instruction SHR_VX_QUIRK = new Instruction_8X06_ShrVx_Quirk();
		private static Instruction SUBN_VX_VY = new Instruction_8XY7_SubnVxVy();
		private static Instruction SHL_VX_VY = new Instruction_8XYE_ShlVxVy();
		private static Instruction SHL_VX_QUIRK = new Instruction_8X0E_ShlVx_Quirk();
		private static Instruction SNE_VX_VY = new Instruction_9XY0_SneVxVy();
		private static Instruction LD_I_ADDR = new Instruction_ANNN_LdIAddr();
		private static Instruction JP_V0_ADDR = new Instruction_BNNN_JpV0Addr();
		private static Instruction RND_VX_BYTE = new Instruction_CXNN_RndVxByte();
		private static Instruction DRW_VX_VY_NIBBLE = new Instruction_DXYN_DrwVxVyNibble();		
		private static Instruction SKP_VX = new Instruction_EX9E_SkpVx();
		private static Instruction SKNP_VX = new Instruction_EXA1_SknpVx();
		private static Instruction LD_VX_DT = new Instruction_FX07_LdVxDt();
		private static Instruction LD_VX_K = new Instruction_FX0A_LdVxK();
		private static Instruction LD_DT_VX = new Instruction_FX15_LdDtVx();
		private static Instruction LD_ST_VX = new Instruction_FX18_LdStVx();
		private static Instruction ADD_I_VX = new Instruction_FX1E_AddIVx();
		private static Instruction LD_F_VX = new Instruction_FX29_LdFVx();
		private static Instruction LD_B_VX = new Instruction_FX33_LdBVx();
		private static Instruction LD_I_VX = new Instruction_FX55_LdIVx();
		private static Instruction LD_VX_I = new Instruction_FX65_LdVxI();
		
		private static ushort MASK_X___ = 0xF000;
		private static ushort MASK_X__X = 0xF00F;
		private static ushort MASK_X_XX = 0xF0FF;
		
		public static Instruction GetInstruction(ushort opcode)
		{
			if (opcode == 0x00E0) return CLS;
			if (opcode == 0x00EE) return RET;
			
			if ((opcode & MASK_X___) == 0x1000) return JP_ADDR;
			if ((opcode & MASK_X___) == 0x2000) return CALL_ADDR;
			
			if ((opcode & MASK_X___) == 0x3000) return SE_VX_BYTE;
			if ((opcode & MASK_X___) == 0x4000) return SNE_VX_BYTE;
			if ((opcode & MASK_X___) == 0x5000) return SE_VX_VY;
			
			if ((opcode & MASK_X___) == 0x6000) return LD_VX_BYTE;
			if ((opcode & MASK_X___) == 0x7000) return ADD_VX_BYTE;
			
			if ((opcode & MASK_X__X) == 0x8000) return LD_VX_VY;
			if ((opcode & MASK_X__X) == 0x8001) return OR_VX_VY;
			if ((opcode & MASK_X__X) == 0x8002) return AND_VX_VY;
			if ((opcode & MASK_X__X) == 0x8003) return XOR_VX_VY;
			if ((opcode & MASK_X__X) == 0x8004) return ADD_VX_VY;
			if ((opcode & MASK_X__X) == 0x8005) return SUB_VX_VY;
			
			if (QuirkShift)
			{
				if ((opcode & MASK_X_XX) == 0x8006) return SHR_VX_QUIRK;
			}
			else
			{
				if ((opcode & MASK_X__X) == 0x8006) return SHR_VX_VY;
			}
			
			if ((opcode & MASK_X__X) == 0x8007) return SUBN_VX_VY;
			
			if (QuirkShift)
			{
				if ((opcode & MASK_X_XX) == 0x800E) return SHL_VX_QUIRK;
			}
			else
			{
				if ((opcode & MASK_X__X) == 0x800E) return SHL_VX_VY;
			}
			
			
			if ((opcode & MASK_X__X) == 0x9000) return SNE_VX_VY;
			
			if ((opcode & MASK_X___) == 0xA000) return LD_I_ADDR;
			if ((opcode & MASK_X___) == 0xB000) return JP_V0_ADDR;
			if ((opcode & MASK_X___) == 0xC000) return RND_VX_BYTE;
			
			if ((opcode & MASK_X___) == 0xD000) return DRW_VX_VY_NIBBLE;
			
			if ((opcode & MASK_X_XX) == 0xE09E) return SKP_VX;
			if ((opcode & MASK_X_XX) == 0xE0A1) return SKNP_VX;
			
			if ((opcode & MASK_X_XX) == 0xF007) return LD_VX_DT;
			if ((opcode & MASK_X_XX) == 0xF00A) return LD_VX_K;
			if ((opcode & MASK_X_XX) == 0xF015) return LD_DT_VX;
			if ((opcode & MASK_X_XX) == 0xF018) return LD_ST_VX;
			
			if ((opcode & MASK_X_XX) == 0xF01E) return ADD_I_VX;
			if ((opcode & MASK_X_XX) == 0xF029) return LD_F_VX;
			if ((opcode & MASK_X_XX) == 0xF033) return LD_B_VX;
			if ((opcode & MASK_X_XX) == 0xF055) return LD_I_VX;
			if ((opcode & MASK_X_XX) == 0xF065) return LD_VX_I;
			
			return INVALID;
		}
	}
}

