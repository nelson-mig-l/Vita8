using System;

namespace Chip8
{
	// http://www.multigesture.net/wp-content/uploads/mirror/goldroad/chip8_instruction_set.shtml
	
	// http://devernay.free.fr/hacks/chip8/C8TECH10.HTM#00E0
	
	// http://devernay.free.fr/hacks/chip8/chip8.html
	
	// http://mattmik.com/chip8.html
	
	public class InstructionSet
	{
		private static Instruction CLS = new Cls();
		private static Instruction RET = new Ret();
		private static Instruction JP_ADDR = new JpAddr();
		private static Instruction CALL_ADDR = new CallAddr();
		private static Instruction SE_VX_BYTE = new SeVxByte();
		private static Instruction SNE_VX_BYTE = new SneVxByte();
		private static Instruction SE_VX_VY = new SeVxVy();
		private static Instruction LD_VX_BYTE = new LdVxByte();		
		private static Instruction ADD_VX_BYTE = new AddVxByte();
		private static Instruction LD_VX_VY = new LdVxVy();
		private static Instruction OR_VX_VY = new OrVxVy();
		private static Instruction AND_VX_VY = new AndVxVy();
		private static Instruction XOR_VX_VY = new XorVxVy();
		private static Instruction ADD_VX_VY = new AddVxVy();
		private static Instruction SUB_VX_VY = new SubVxVy();
		private static Instruction SHR_VX = new ShrVx();
		private static Instruction SUBN_VX_VY = new SubnVxVy();
		private static Instruction SHL_VX = new ShlVx();
		private static Instruction SNE_VX_VY = new SneVxVy();
		private static Instruction LD_I_ADDR = new LdIAddr();
		private static Instruction JP_V0_ADDR = new JpV0Addr();
		private static Instruction RND_VX_BYTE = new RndVxByte();
		private static Instruction DRW_VX_VY_NIBBLE = new DrwVxVyNibble();		
		private static Instruction SKP_VX = new SkpVx();
		private static Instruction SKNP_VX = new SknpVx();
		private static Instruction LD_VX_DT = new LdVxDt();
		private static Instruction LD_VX_K = new LdVxK();
		private static Instruction LD_DT_VX = new LdDtVx();
		private static Instruction LD_ST_VX = new LdStVx();
		private static Instruction ADD_I_VX = new AddIVx();
		private static Instruction LD_F_VX = new LdFVx();
		private static Instruction LD_B_VX = new LdBVx();
		private static Instruction LD_I_VX = new LdIVx();
		private static Instruction LD_VX_I = new LdVxI();
		
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
			if ((opcode & MASK_X_XX) == 0x8006) return SHR_VX;
			if ((opcode & MASK_X__X) == 0x8007) return SUBN_VX_VY;
			if ((opcode & MASK_X_XX) == 0x800E) return SHL_VX;
			
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
			
			throw new Exception("opcode not recognized" + opcode.ToString("X"));
		}
	}
}

