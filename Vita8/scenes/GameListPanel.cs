using System;
using System.Collections.Generic;
using Sce.PlayStation.HighLevel.UI;

namespace Vita8
{
	
	// http://community.eu.playstation.com/t5/UI-Toolkit/Is-it-really-so-hard-to-create-a-ListPanel-with-ListPanelItems/td-p/15831149
	public class GameListPanel : ListPanel
	{		
		private int selectedItemIndex = -1;
		
		private Configuration[] configurations;
		
		public GameListPanel(Configuration[] configurations)
		{
			this.configurations = configurations;

			this.SetListItemCreator(ListItemCreator);
			this.SetListItemUpdater(ListItemUpdator);
			this.ShowSection = false;
			this.Sections = new ListSectionCollection {
				new ListSection("Section1", configurations.Length)
			};
			
			this.SelectItemChanged += GameListPanelItemChanged;
		}
		
		private ListPanelItem ListItemCreator()
        {
            return new GameListPanelItem(this.Width, 50);
        }
		
		private void ListItemUpdator(ListPanelItem item)
        {
			if(item is GameListPanelItem)
			{
				GameListPanelItem gameListPanelItem = (item as GameListPanelItem);
				gameListPanelItem.Configuration = configurations[item.Index];
			}
        }
		
		private void GameListPanelItemChanged(object sender, ListPanelItemSelectChangedEventArgs e)
		{
			/*
			if (selectedItemIndex > -1) {
				GameListPanelItem gameListPanelItem1 = (this.GetListItem(selectedItemIndex) as GameListPanelItem);
				gameListPanelItem1.BackgroundColor = new UIColor(128.0f, 0.0f, 0.0f, 1.0f);
			}
			selectedItemIndex = e.Index;
			Console.WriteLine("Selected is " + selectedItemIndex);
			GameListPanelItem gameListPanelItem = (this.GetListItem(selectedItemIndex) as GameListPanelItem);
			gameListPanelItem.BackgroundColor = new UIColor(128.0f, 0.0f, 0.0f, 1.0f);
			*/
		}
	} // GameListPanel
}	


