using System;
using System.Collections.Generic;

using Sce.PlayStation.Core.Input;

using Chip8;

namespace Vita8
{
	public class Keyboard : IConfigurable
	{
		private static int[,] IDS = {
			{0x1, 0x2, 0x3, 0xC},
			{0x4, 0x5, 0x6, 0xD},
			{0x7, 0x8, 0x9, 0xE},
			{0xA, 0x0, 0xB, 0xF}
		};
		
		private Dictionary<GamePadButtons, int> keyMappings = new Dictionary<GamePadButtons, int>();
		
		public Keyboard()
		{
		}
		
		public void Configure(Configuration configuration) 
		{
			keyMappings.Clear();
			foreach (Configuration.KeyboardConfiguration.Key key in configuration.Keyboard.Keys)
			{
				keyMappings.Add(key.Button, key.Code);
			}
		}
		
		public void Update(Chip8.Chip8 chip8)
		{
			foreach(KeyValuePair<GamePadButtons, int> entry in keyMappings)
			{
				chip8.Keypad.Set(entry.Value, IsPressed(entry.Key));
			}
		}
		
		private static bool IsPressed(GamePadButtons button) 
		{
			var gamePadData = GamePad.GetData(0);
			if((gamePadData.Buttons & button) == button) {
				return true;
			}
			return false;
		}
	}
}

