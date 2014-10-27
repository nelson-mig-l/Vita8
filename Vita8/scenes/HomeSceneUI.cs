using System;
using System.Collections.Generic;
using Sce.PlayStation.HighLevel.UI;

namespace Vita8
{
	public class HomeSceneUI : Sce.PlayStation.HighLevel.UI.Scene
	{
		public HomeSceneUI(Configuration[] configurations)
		{
			Sce.PlayStation.HighLevel.UI.Panel dialog = new Panel();
			dialog.Width = Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.GL.Context.GetViewport().Width;
			dialog.Height = Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.GL.Context.GetViewport().Height;
			ListPanel gamePanel = new GameListPanel(configurations);
			gamePanel.SetSize(300, Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.GL.Context.GetViewport().Height);
			gamePanel.SetPosition(0, 0);
			dialog.AddChildLast(gamePanel);
			
			this.RootWidget.AddChildLast(dialog);
		}
	}
}

