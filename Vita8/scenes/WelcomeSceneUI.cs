using System;
using Sce.PlayStation.HighLevel.UI;

namespace Vita8
{
	public class WelcomeSceneUI : Scene
	{
		public WelcomeSceneUI ()
		{
			Panel dialog = new Panel();
			dialog.BackgroundColor = new UIColor(1.0f, 1.0f, 1.0f, 1.0f);
			dialog.Width = Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.GL.Context.GetViewport().Width;
			dialog.Height = Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.GL.Context.GetViewport().Height;
			this.RootWidget.AddChildLast(dialog);
		}
	}
}

