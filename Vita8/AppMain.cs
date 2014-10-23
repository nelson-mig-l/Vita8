using System;
using System.Collections.Generic;
using System.Timers;
using System.Threading;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using Chip8;

namespace Vita8
{
	public class AppMain
	{
		private static GraphicsContext graphics;
		
		private static Emulator emulator;
		
		public static void Main(string[] args)
		{
			Initialize();
		}
		
		private static int fps = 0;
		public static void Initialize()
		{
			// Set up the graphics system
			//graphics = new GraphicsContext();
			//Vita8Graphics.Initialize(graphics);
			
			Director.Initialize();
			
			emulator = new Emulator();
			emulator.Load("/Application/roms/vbrix.rom");
			EmulatorScene scene = new EmulatorScene(emulator);
			scene.Camera.SetViewFromViewport();
			
			Director.Instance.RunWithScene(scene);
		}

		public static void Update()
		{		
			//emulator.Update();
		}
		
		
		public static void Render ()
		{
			//emulator.Render();
			fps++;
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
