using System;

namespace Chip8
{
	public class SuperInstruction_FX75_LdRVx : Instruction
	{
		private static string CODE = "FX75";
		private static string ASSEMBLER = "LD [R], V{1}";
		private static string DESCRIPTION = "";

		public SuperInstruction_FX75_LdRVx() : base(CODE, ASSEMBLER, DESCRIPTION) {}
		
		public override void Execute(Chip8 chip8)
		{
			/* 0xfX75 - move_register_host */
			/* put v[0] until v[X] into the host's flags, X<8 */
			// static BYTE host_flags[16];
			// static BYTE reg_v[16];
			// #define OPV2 ((op & 0x0f00) >> 8)
			// memcpy(host_flags, reg_v, OPV2 + 1);
		}
	}
}

