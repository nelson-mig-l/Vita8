using System;
using System.IO;

namespace Vita8
{
	public class ConfigurationLoader
	{
		private static string PATH = "/Application/roms/";
		private static string FILTER = "*.xml";
		
		public ConfigurationLoader()
		{
		}
		
		public Configuration[] LoadConfigurations() 
		{
			string [] fileEntries = Directory.GetFiles(PATH, FILTER);
			Configuration[] configurations = new Configuration[fileEntries.Length];
			int index = 0;
        	foreach(string fileName in fileEntries)
			{
				Console.WriteLine("Loading... " + fileName);
				Configuration configuration = Configuration.LoadFromXml(fileName);
				configurations[index] = configuration;
				index++;
			}
			return configurations;
		}
	}
}

