using System;
using System.Collections.Generic;
using Sce.PlayStation.HighLevel.UI;

namespace Vita8
{
	// https://psm.playstation.net/static/general/all/psm_sdk/1/doc/en/classSce_1_1PlayStation_1_1HighLevel_1_1UI_1_1ListPanelItem.html#a7ed7877bc924a22a5c0be18e6e54966c
	public class GameListPanelItem : ListPanelItem 
	{

		private static readonly UIColor ITEM_COLOR = new UIColor(0.00f, 0.00f, 0.00f, 1.0f);
		private static readonly UIColor ITEM_COLOR_SELECTED = new UIColor(0.00f, 0.50f, 0.80f, 1.0f);
		
		private Configuration configuration;

		public GameListPanelItem(float width, float height)
    	{
    	    this.Width = width;
    	    this.Height = height;
    	    
			button = new Button();
    	    button.X = 0;
    	    button.Y = 0;
    	    button.Width = Width - 10;
    	    button.Height = Height;
    	    button.HorizontalAlignment = HorizontalAlignment.Center;
			
			button.TouchEventReceived += (sender, e) => {
				AppMain.emulator.Load(configuration);
				AppMain.sceneManager.SetScene(SceneManager.Vita8Scene.EMULATOR);
				AppMain.emulator.Start();
			};
			
    	    this.AddChildLast(button);
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
				button.Text = configuration.rom.name;
    	    }
    	}
		
	    protected override void OnPressStateChanged(PressStateChangedEventArgs e)
        {
            base.OnPressStateChanged(e);

            //if (PressState == PressState.Pressed)
                //this.BackgroundColor = ITEM_COLOR_SELECTED;
            //else
                //this.BackgroundColor = ITEM_COLOR;
        }

    	private Sce.PlayStation.HighLevel.UI.Button button;
    }
}
