using System;

namespace Chip8
{
	public class SuperInstruction_FX85_LdVxI : Instruction
	{
		private static string CODE = "FX85";
		private static string ASSEMBLER = "LD V{1}, [I]";
		private static string DESCRIPTION = "";

		public SuperInstruction_FX85_LdVxI() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			/* 0xfX85 - move_host_register */
			/* put host's flags into v[0] until v[X], X<8 */
			// static BYTE host_flags[16];
			// static BYTE reg_v[16];
			// #define OPV2 ((op & 0x0f00) >> 8)
			// memcpy(reg_v, host_flags, OPV2 + 1);
		}
	}
}

