using System;
using System.Collections.Generic;
using Sce.PlayStation.HighLevel.UI;

namespace Vita8
{
	// https://psm.playstation.net/static/general/all/psm_sdk/1/doc/en/classSce_1_1PlayStation_1_1HighLevel_1_1UI_1_1ListPanelItem.html#a7ed7877bc924a22a5c0be18e6e54966c
	public class GameListPanelItem : ListPanelItem 
	{
		private Configuration configuration;

		public GameListPanelItem(float width, float height)
    	{
    	    this.Width = width;
    	    this.Height = height;
    	    
			button = new Button();
    	    button.X = 5;
    	    button.Y = 5;
    	    button.Width = Height-10;
    	    button.Height = Height-10;
    	    button.HorizontalAlignment = HorizontalAlignment.Center;
			button.Text = "GO";
			
			label = new Label();
			label.X = Height + 10;
			label.Y = 0;
			label.Width = Width - Height - 10;
			label.Height = Height;
			label.HorizontalAlignment = HorizontalAlignment.Left;
			
			
			button.TouchEventReceived += (object sender, TouchEventArgs e) => {
				AppMain.emulator.Load(configuration);
				AppMain.sceneManager.SetScene(SceneManager.Vita8Scene.EMULATOR);
				AppMain.emulator.Start();
			};
			
    	    this.AddChildLast(button);
    	    this.AddChildLast(label);
    	}
		
    	public Configuration Configuration
    	{
    	    get
    	    {
    	        return configuration;
    	    }
    	    set
    	    {
    	        configuration = value;
				label.Text = configuration.rom.name;
    	    }
    	}
		
	    protected override void OnPressStateChanged(PressStateChangedEventArgs e)
        {
            base.OnPressStateChanged(e);
        }

    	private Sce.PlayStation.HighLevel.UI.Button button;
    	private Sce.PlayStation.HighLevel.UI.Label label;
    }
}

