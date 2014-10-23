using System;
using Sce.PlayStation.Core.Input;


namespace Vita8
{
	public class Emulator
	{
		private Chip8.Chip8 chip8;
		private Keyboard keyboard;
		private Speaker speaker;
		private Screen screen;
		
		private bool running;
		
		private long next = 0;
		
		public Emulator()
		{
			this.chip8 = new Chip8.Chip8();
			this.keyboard = new Keyboard(368, 320, 56);
			this.speaker = new Speaker();
			this.screen = new Screen(64, 32, 10);
			
			this.running = false;
			
			Reset();
		}
		
		public void Load(string rom) 
		{
			this.running = false;

			chip8.LoadApplication(rom);
		}
		
		public void Update()
		{
			if (running)
			{
				keyboard.Update(chip8);
				
				chip8.Keypad.Set(0x7, IsPressed(GamePadButtons.Cross));
				chip8.Keypad.Set(0x1, IsPressed(GamePadButtons.Up));
				chip8.Keypad.Set(0x4, IsPressed(GamePadButtons.Down));
	
				long current = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

				if (current > next)
				{
					next = current + 1;
					chip8.EmulateCycle();
				}
			}
		}
		
		public bool Render()
		{
			speaker.Render(chip8);
			if (chip8.Display.Modified) {
				screen.Render(chip8.Display);
				return true;
			}
			return false;
		}
		
		public void Pause()
		{
			running = false;
		}
		
		public void Resume()
		{
			running = true;
		}
		
		public void Reset()
		{
			
		}
		
		private static bool IsPressed(GamePadButtons button) 
		{
			var gamePadData = GamePad.GetData(0);
			if((gamePadData.Buttons & button) == button) {
				return true;
			}
			return false;
		}
	}
}

