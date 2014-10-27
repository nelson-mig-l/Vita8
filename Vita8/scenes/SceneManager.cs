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
			WELCOME, HOME, EMULATOR
		}
		
		public class ScenePair : Tuple<Sce.PlayStation.HighLevel.UI.Scene, Sce.PlayStation.HighLevel.GameEngine2D.Scene>
		{
			public ScenePair(Sce.PlayStation.HighLevel.UI.Scene uiScene, Sce.PlayStation.HighLevel.GameEngine2D.Scene engineScene) : base(uiScene, engineScene)
			{
			}
		}
		
		private Dictionary<Vita8Scene, ScenePair> scenes = new Dictionary<Vita8Scene, ScenePair>();
		
		public SceneManager()
		{
		}
		
		public void SetScene(Vita8Scene vita8scene)
		{
			ScenePair scene = scenes[vita8scene];
			UISystem.SetScene(scene.Item1);
			Director.Instance.ReplaceScene(scene.Item2);
		}
		
		public void RegisterScenePair(Vita8Scene scene, ScenePair pair)
		{
			if (scenes.ContainsKey(scene))
			{
				throw new Exception("You can do that.");
			}
			else
			{
				scenes.Add(scene, pair);	
			}
		}
	}
}

