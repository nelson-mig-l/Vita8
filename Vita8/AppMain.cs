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
		
		public static SceneManager sceneManager;
		
		public static void Main(string[] args)
		{
			Initialize();
			
			while (true) {
				SystemEvents.CheckEvents();
				
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
			Director.Initialize();
			UISystem.Initialize(Director.Instance.GL.Context);
			Director.Instance.RunWithScene(new Sce.PlayStation.HighLevel.GameEngine2D.Scene(), true);
			UISystem.SetScene(new Sce.PlayStation.HighLevel.UI.Scene());
			
			emulator = new Emulator();
			sceneManager = new SceneManager();
			
			sceneManager.SetScene(SceneManager.Vita8Scene.HOME);
		}

	}
	
}
