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
		// public used in scenes
		public static Emulator emulator;
		public static Configuration[] configurations;
		
		public static SceneManager sceneManager;
		
		public static void Main(string[] args)
		{
			Configuration configuration = new Configuration();
			configuration.Example();
			Configuration.SaveToXml(configuration, "");
			
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
			
			sceneManager = new SceneManager();
			
			SceneManager.ScenePair welcome = new SceneManager.ScenePair(new WelcomeSceneUI(), new Sce.PlayStation.HighLevel.GameEngine2D.Scene());
			sceneManager.RegisterScenePair(SceneManager.Vita8Scene.WELCOME, welcome);

			ConfigurationLoader loader = new ConfigurationLoader();
			configurations = loader.LoadConfigurations();
			
			SceneManager.ScenePair home  = new SceneManager.ScenePair(new HomeSceneUI(configurations), new Sce.PlayStation.HighLevel.GameEngine2D.Scene());
			sceneManager.RegisterScenePair(SceneManager.Vita8Scene.HOME, home);
			
			AppMain.emulator = new Emulator();

			SceneManager.ScenePair emulator  = new SceneManager.ScenePair(new Sce.PlayStation.HighLevel.UI.Scene(), new EmulatorScene());
			sceneManager.RegisterScenePair(SceneManager.Vita8Scene.EMULATOR, emulator);
			
			sceneManager.SetScene(SceneManager.Vita8Scene.HOME);//WELCOME);
			
		}

	}
	
}
