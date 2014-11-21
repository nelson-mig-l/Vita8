using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using Sce.PlayStation.Core.Input;

namespace Vita8
{
	public class Configuration
	{
		public struct Rom {
			public string name;
			public string file;
		}

		public struct ScreenConfiguration {
			public uint off;
			public uint on;
		}
		
		public struct KeyboardConfiguration
		{
			public struct Key
			{
				public int Code;
				public GamePadButtons Button;
			}
			public List<Key> Keys;
		}
		
		public Rom rom;
		public KeyboardConfiguration Keyboard;
		public ScreenConfiguration Screen;
		
		public Configuration()
		{
			// fill default values
			Screen.off = 0xFF660000;
			Screen.on = 0xFFFF6600;
			
			// not all roms need to define keyboard. eg test roms
			// so default is empty
			Keyboard = new KeyboardConfiguration();
			Keyboard.Keys = new List<KeyboardConfiguration.Key>();
		}
		
		public void Example() 
		{
			rom = new Rom();
			rom.name = "RomName";
			rom.file = "RomFile";
			
			Keyboard = new KeyboardConfiguration();
			Keyboard.Keys = new List<KeyboardConfiguration.Key>();
			KeyboardConfiguration.Key key1 = new KeyboardConfiguration.Key();
			key1.Code = 1;
			key1.Button = GamePadButtons.Cross;
			KeyboardConfiguration.Key key2 = new KeyboardConfiguration.Key();
			key2.Code = 2;
			key2.Button = GamePadButtons.Circle;
			Keyboard.Keys.Add(key1);
			Keyboard.Keys.Add(key2);
			
			Screen = new ScreenConfiguration();
			Screen.on = 0xFF00FFFF;
			Screen.off = 0xFF0000FF;			
		}
				
		public static void SaveToXml(Configuration configuration, string filename) {
			XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
			StringBuilder sb = new StringBuilder();
			XmlWriter writer = XmlWriter.Create(sb);
			serializer.Serialize(writer, configuration);
			
			Console.WriteLine(sb.ToString());
		}
		
		// http://msdn.microsoft.com/en-us/library/tz8csy73(v=vs.110).aspx
		public static Configuration LoadFromXml(string filename) {
			XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
			FileStream fs = File.OpenRead(filename);
        	XmlReader reader = XmlReader.Create(fs);
			return (Configuration)serializer.Deserialize(reader);
		}
	}
}

