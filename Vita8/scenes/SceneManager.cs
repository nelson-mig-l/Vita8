using System;
using System.Collections.Generic;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using Sce.PlayStation.HighLevel.UI;

namespace Vita8
{
	public class SceneManager
	{
		public enum Vita8Scene
		{
			HOME, EMULATOR
		}
		
		private static Sce.PlayStation.HighLevel.UI.Scene EMPTY_UI_SCENE = new Sce.PlayStation.HighLevel.UI.Scene();
		private static Sce.PlayStation.HighLevel.GameEngine2D.Scene EMPTY_SCENE = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
		
		private class ScenePair : Tuple<Sce.PlayStation.HighLevel.UI.Scene, Sce.PlayStation.HighLevel.GameEngine2D.Scene>
		{
			public ScenePair(Sce.PlayStation.HighLevel.UI.Scene uiScene, Sce.PlayStation.HighLevel.GameEngine2D.Scene engineScene) : base(uiScene, engineScene)
			{
				
			}
		}
		
		private Dictionary<Vita8Scene, ScenePair> scenes = new Dictionary<Vita8Scene, ScenePair>();
		
		public SceneManager()
		{
			ScenePair home  = new ScenePair(new HomeSceneUI(), EMPTY_SCENE);
			scenes.Add(Vita8Scene.HOME, home);
			
			ScenePair emulator  = new ScenePair(EMPTY_UI_SCENE, new EmulatorScene());
			scenes.Add(Vita8Scene.EMULATOR, emulator);
		}
		
		public void SetScene(Vita8Scene vita8scene)
		{
			ScenePair scene = scenes[vita8scene];
			UISystem.SetScene(scene.Item1);
			Director.Instance.ReplaceScene(scene.Item2);
		}
	}
}

