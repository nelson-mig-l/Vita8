using System;
using System.Collections.Generic;
using Sce.PlayStation.HighLevel.UI;

namespace Vita8
{
	public class HomeScene : Scene
	{
		private List<Button> buttons = new List<Button>();
		public HomeScene(Sce.PlayStation.HighLevel.GameEngine2D.Director director)
		{
			Sce.PlayStation.HighLevel.UI.Panel dialog = new Panel();
			dialog.Width = director.GL.Context.GetViewport().Width;
			dialog.Height = director.GL.Context.GetViewport().Height;
			Button buttonUI1 = new Button();
			buttonUI1.Name = "buttonGoSlow";
			buttonUI1.Text = "Tetris";
			buttonUI1.Width = 300;
			buttonUI1.Height = 50;
			buttonUI1.Alpha = 0.8f;
			buttonUI1.TouchEventReceived += (sender, e) => {
				UISystem.SetScene(new Scene());
				AppMain.emulator.Load("/Application/roms/tetris.rom");
				director.ReplaceScene(new EmulatorScene(AppMain.emulator));
				
				//director.ReplaceScene(new SlowVersion());
			};
			
			Button buttonUI2 = new Button();
			buttonUI2.Name = "buttonGoFase";
			buttonUI2.Text = "Vertical Brix";
			buttonUI2.Width = 300;
			buttonUI2.Height = 50;
			buttonUI2.SetPosition(0,55);
			buttonUI2.Alpha = 0.8f;
			buttonUI2.TouchEventReceived += (sender, e) => {
				UISystem.SetScene(new Scene());
				AppMain.emulator.Load("/Application/roms/vbrix.rom");
				director.ReplaceScene(new EmulatorScene(AppMain.emulator));
				//director.ReplaceScene(new FastVersion());
			};
			
			Button buttonUI3 = new Button();
			buttonUI3.Name = "buttonExit";
			buttonUI3.Text = "Brix";
			buttonUI3.Width = 300;
			buttonUI3.Height = 50;
			buttonUI3.SetPosition(0,110);
			buttonUI3.Alpha = 0.8f;
			buttonUI3.TouchEventReceived += (sender, e) => {
				UISystem.SetScene(new Scene());
				AppMain.emulator.Load("/Application/roms/brix.rom");
				director.ReplaceScene(new EmulatorScene(AppMain.emulator));
				//quit = true;
			};
			
			dialog.AddChildLast(buttonUI1);
			dialog.AddChildLast(buttonUI2);
			dialog.AddChildLast(buttonUI3);
			
			this.RootWidget.AddChildLast(dialog);
		}
	}
}

