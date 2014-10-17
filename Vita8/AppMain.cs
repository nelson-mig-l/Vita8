#define DEBUG
using System;
using System.Collections.Generic;
using System.Timers;
using System.Threading;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Chip8;

namespace Vita8
{
	public class AppMain
	{
		private static GraphicsContext graphics;
		
		private static Chip8.Chip8 chip8 = new Chip8.Chip8();
		
		private static Screen screen = new Screen(160, 0, 10);
		private static Keyboard keyboard = new Keyboard(368, 320, 56);
		
		private static System.Timers.Timer refreshRate = new System.Timers.Timer(1000);
		
		public static void Main (string[] args)
		{
			Initialize();
			
			chip8.LoadApplication("/Application/roms/tetris.rom");
			
			while (true) {
				SystemEvents.CheckEvents ();
				Update ();
				Render ();
			}
		}
		
		private static int realfps = 0;
		private static int fps = 0;
		private static int ips = 0;
		public static void Initialize ()
		{			
#if DEBUG
			refreshRate.Enabled = true;
			refreshRate.Elapsed += delegate {
				System.Console.WriteLine("FPS(" + fps + "/" + realfps + ") IPS=" + ips + "");	
				realfps = 0;
				fps = 0;
				ips = 0;
			};
#endif
			// Set up the graphics system
			graphics = new GraphicsContext ();
			
			Vita8Graphics.Initialize(graphics);
		}

		public static void Update ()
		{
			// Query gamepad for current state
			// var gamePadData = GamePad.GetData (0);
			//while (true) {
				chip8.EmulateCycle();
				ips++;
				keyboard.Update(chip8);
			//	Thread.Sleep(1000/1000);
			//}
		}
		
		
		public static void Render ()
		{
			realfps++;
			if (chip8.Display.Modified) {
				fps++;
				screen.Render(chip8.Display);
				keyboard.Render();
	
				// Present the screen
				graphics.SwapBuffers ();
			}
		}
	}
}
