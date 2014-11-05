using System;
using System.Collections.Generic;
using Sce.PlayStation.HighLevel.UI;

namespace Vita8
{
	
	// http://community.eu.playstation.com/t5/UI-Toolkit/Is-it-really-so-hard-to-create-a-ListPanel-with-ListPanelItems/td-p/15831149
	public class GameListPanel : ListPanel
	{		
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
		}
		
		private ListPanelItem ListItemCreator()
        {
            return new GameListPanelItem(this.Width, 60);
        }
		
		private void ListItemUpdator(ListPanelItem item)
        {
			if(item is GameListPanelItem)
			{
				GameListPanelItem gameListPanelItem = (item as GameListPanelItem);
				gameListPanelItem.Configuration = configurations[item.Index];
			}
        }
	} 
}	


