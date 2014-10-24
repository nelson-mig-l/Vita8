using System;
using System.Threading;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.HighLevel.GameEngine2D;

namespace Vita8
{
	public class Emulator : IDisposable 
	{
		private Chip8.Chip8 chip8;
		private Keyboard keyboard;
		private Speaker speaker;
		private Screen screen;
		
		private bool running;
		
		private long next = 0;
		
		private Thread thread = null;
		
		public Emulator()
		{
			this.chip8 = new Chip8.Chip8();
			this.keyboard = new Keyboard();
			this.speaker = new Speaker();
			this.screen = new Screen(64, 32, 10);
			
			this.running = false;
		}
		
		public void Load(string rom) 
		{
			Stop();
			
			chip8.LoadApplication(rom);
		}
		
		private void Update()
		{
			if (running)
			{
				keyboard.Update(chip8);
					
				speaker.Render(chip8);
				
				long current = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

				if (current > next)
				{
					next = current + 1;
					chip8.EmulateCycle();
				}
			}
		}
		
		public bool Render(Texture2D texture) {
			bool modified = chip8.Display.Modified;
			if (modified) {
				screen.Render(chip8.Display, texture);
			}
			return modified;
		}

		public void Stop()
		{
			running = false;
			if (thread != null && thread.IsAlive)
			{
				thread.Abort();
				thread.Join();
				thread = null;
			}
		}
		
		public void Start()
		{
			running = true;
			thread = new Thread(new ThreadStart(this.UpdateThread));
			thread.IsBackground = false;
			thread.Start();
		}
		
		private void UpdateThread() {
			while (true) {
				this.Update();
			}
		}
		
		public void Reset()
		{
			chip8.Reset();
		}
		
		public void Dispose() 
		{
			Console.WriteLine("Dispose Emulator");
			this.Stop();
		}
		
	}
}

