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
using Sce.PlayStation.HighLevel.UI;

using Chip8;

namespace Vita8
{
	public class AppMain
	{
		// public?
		public static Emulator emulator;
		
		public static void Main(string[] args)
		{
			Initialize();
			
			while (true) {
				Director.Instance.Update();
			    Director.Instance.GL.Context.Clear();
			    Director.Instance.Render();
			    
			    UISystem.Update(Touch.GetData(0));
			    UISystem.Render();
			    
			    Director.Instance.GL.Context.SwapBuffers();
			    Director.Instance.PostSwap();
			}
		}
		
		public static void Initialize()
		{
			emulator = new Emulator();

			Director.Initialize();
			Director.Instance.RunWithScene(new Sce.PlayStation.HighLevel.GameEngine2D.Scene(), true);
			//scene.Camera.SetViewFromViewport();
			
			UISystem.Initialize(Director.Instance.GL.Context);
			UISystem.SetScene(new HomeScene(Director.Instance));
			
			//emulator.Load("/Application/roms/vbrix.rom");
			
			//EmulatorScene scene = new EmulatorScene(emulator);
			//HomeScene scene = new HomeScene();
			
		}

	}
	
}
