using System;
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
		// XXX: Public?
		//public byte[] key = new byte[16];
		
		internal ushort programCounter;
		internal ushort opcode;
		internal ushort indexRegister;
		internal ushort stackPointer;
		
		internal byte[] v = new byte[16];
		internal ushort[] stack = new ushort[16];
		internal byte[] memory = new byte[4096];
		
		internal byte delayTimer;
		internal byte soundTimer;
		
		internal Random rand = new Random();
		
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
					//if(soundTimer == 1)
					//	printf("BEEP!\n");
					--soundTimer;
				}	
				//System.Console.Write(".");
			};
			
			clock.Enabled = true;
			
			display = new Display(64, 32);
			keypad = new Keypad(16);
			//rand.NextBytes
			Init();
		}
		
		public void EmulateCycle()
		{
			this.opcode = (ushort)(this.memory[this.programCounter] << 8 | this.memory[this.programCounter + 1]);
			
			Instruction instruction = InstructionSet.GetInstruction(this.opcode);
						
			int na = (opcode & 0xF000) >> 12;
			int nb = (opcode & 0x0F00) >> 8;
			int nc = (opcode & 0x00F0) >> 4;
			int nd = (opcode & 0x000F);
			System.Console.WriteLine("0x" + programCounter.ToString("X4") + ": " + string.Format(instruction.Assembler(), na.ToString("X"), nb.ToString("X"), nc.ToString("X"), nd.ToString("X")));
			
			try 
			{
				instruction.Execute(this);
			}
			catch
			{
				for (int i = 0; i <= 0xF; i++)
					System.Console.WriteLine(string.Format("V[{0}]:{1}", i.ToString("X"), v[i]));
				throw new Exception();
			}
			
		}
				
		public bool LoadApplication(string filename)
		{
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
		
		private void Init()
		{
			this.programCounter = 0x200;
			this.opcode = 0;
			this.indexRegister = 0;
			this.stackPointer = 0;

			display.Reset();
			keypad.Reset();
			
			for (int i = 0; i < 16; i++)
			{
				this.stack[i] = 0;
			}
			

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

