using System;
using System.Xml;

namespace Vita8
{
	public class Configuration
	{
		
		private struct Rom {
			string name;
			string file;
		}
		
		private Rom rom = new Rom();
		
		public Configuration(string configurationFile)
		{
			using (XmlReader reader = XmlReader.Create("/Application/roms/tetris.xml"))
			{
				//reader.
			}
		}
		
		public void Write()
		{
			using (XmlWriter writer = XmlWriter.Create("/Application/roms/example.xml"))
			{
				writer.WriteStartDocument();
				writer.WriteStartElement("configuration");
				
				writer.WriteStartElement("rom");
				writer.WriteAttributeString("name", "Example");
				writer.WriteAttributeString("file", "example.rom");
				writer.WriteEndElement();
				
				
				
				writer.WriteEndElement();
				writer.WriteEndDocument();
			}
		}
		
		
	}
}

