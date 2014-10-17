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
		
		//private static System.Timers.Timer refreshRate = new System.Timers.Timer(1000/60); // 60Hz
		
		public static void Main (string[] args)
		{
			Initialize();
			
			chip8.LoadApplication("/Application/roms/pong.rom");
			
			//Thread newThread = new Thread(Update);
			//newThread.Start();
			/*
			System.Timers.Timer refreshRate = new System.Timers.Timer(1000/60);
			refreshRate.Elapsed += delegate {
				Render();
				System.Console.WriteLine("RENDER");
			};
			refreshRate.Enabled = true;
			*/
			while (true) {
				SystemEvents.CheckEvents ();
				Update ();
				Render ();
			}
		}

		public static void Initialize ()
		{
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
			
				keyboard.Update(chip8);
			//	Thread.Sleep(1000/1000);
			//}
		}
		
		
		public static void Render ()
		{

			if (chip8.DrawFlag) {

				screen.Render(chip8.Gfx());
				keyboard.Render();
	
				// Present the screen
				graphics.SwapBuffers ();
				
				//System.Console.WriteLine("RENDER");
				
				chip8.DrawFlag = false;
			}
		}
	}
}
