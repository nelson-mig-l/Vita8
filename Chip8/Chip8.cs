using System;
using System.Collections.Generic;
using System.IO;

namespace Chip8
{
	public class Chip8
	{
		private byte[] chip8Fontset =
		{ 
		    0xF0, 0x90, 0x90, 0x90, 0xF0, //0
		    0x20, 0x60, 0x20, 0x20, 0x70, //1
		    0xF0, 0x10, 0xF0, 0x80, 0xF0, //2
		    0xF0, 0x10, 0xF0, 0x10, 0xF0, //3
		    0x90, 0x90, 0xF0, 0x10, 0x10, //4
		    0xF0, 0x80, 0xF0, 0x10, 0xF0, //5
		    0xF0, 0x80, 0xF0, 0x90, 0xF0, //6
		    0xF0, 0x10, 0x20, 0x40, 0x40, //7
		    0xF0, 0x90, 0xF0, 0x90, 0xF0, //8
		    0xF0, 0x90, 0xF0, 0x10, 0xF0, //9
		    0xF0, 0x90, 0xF0, 0x90, 0x90, //A
		    0xE0, 0x90, 0xE0, 0x90, 0xE0, //B
		    0xF0, 0x80, 0x80, 0x80, 0xF0, //C
		    0xE0, 0x90, 0x90, 0x90, 0xE0, //D
		    0xF0, 0x80, 0xF0, 0x80, 0xF0, //E
		    0xF0, 0x80, 0xF0, 0x80, 0x80  //F
		};
		
		internal Display display;
		internal Keypad keypad;
		
		internal ushort programCounter;
		internal ushort opcode;
		internal ushort indexRegister;
		
		internal byte[] v = new byte[16];
		internal Stack<ushort> stack; // capacity = 16
		internal byte[] memory = new byte[4096];
		
		internal byte delayTimer;
		internal byte soundTimer;
		
		internal Random rand = new Random(System.DateTime.Now.Millisecond);
		
		private System.Timers.Timer clock = new System.Timers.Timer(1000/60); // 60Hz
		
		public Chip8()
		{
			clock.Elapsed += delegate {
				// Update timers
				if (delayTimer > 0)
				{
					--delayTimer;
				}
				
				if (soundTimer > 0)
				{
					--soundTimer;
				}	
			};
			
			clock.Enabled = true;
			
			display = new Display();
			keypad = new Keypad(16);
			Reset();
		}
		
		public void EmulateCycle()
		{
			this.opcode = (ushort)(this.memory[this.programCounter] << 8 | this.memory[this.programCounter + 1]);
			
			//Instruction instruction = InstructionSet.GetInstruction(this.opcode);
			Instruction instruction = SuperInstructionSet.GetInstruction(this.opcode);
						
			int na = (opcode & 0xF000) >> 12;
			int nb = (opcode & 0x0F00) >> 8;
			int nc = (opcode & 0x00F0) >> 4;
			int nd = (opcode & 0x000F);
			//System.Console.WriteLine("0x" + programCounter.ToString("X4") + ": " + string.Format(instruction.Assembler(), na.ToString("X"), nb.ToString("X"), nc.ToString("X"), nd.ToString("X")));
			
			instruction.Execute(this);
		}
				
		public bool LoadApplication(string filename)
		{
			Reset();
			// load binary file
			byte[] buffer = File.ReadAllBytes(filename);
			var len = buffer.Length;
			
			if((4096-512) > len)
			{
				for(int i = 0; i < len; ++i)
					memory[i + 512] = buffer[i];
			}
			else throw new Exception("Error: ROM too big for memory");
			
			return true;
		}

		public Display Display 
		{
			get { return display; }
		}
		
		public Keypad Keypad
		{
			get { return keypad; }
		}
		
		public bool Beep
		{
			get { return soundTimer > 0; }
		}
		
		public void Reset()
		{
			this.programCounter = 0x200;
			this.opcode = 0;
			this.indexRegister = 0;

			display.Reset();
			keypad.Reset();
			
			this.stack = new Stack<ushort>(16);

			for (int i = 0; i < 4096; i++)
			{
				this.memory[i] = 0;
			}
			
			for (int i = 0; i < 80; i++)
			{
				this.memory[i] = this.chip8Fontset[i];
			}
			
			this.delayTimer = 0;
			this.soundTimer = 0;
			
		}
		
	}
}

