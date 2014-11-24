using System;
using System.Collections.Generic;

namespace Chip8
{
	public enum DisplayMode
	{
		LOWRES, HIGHRES
	}
	
	public class DisplayResolution
	{
		public struct Resolution
		{
			public int Width;
			public int Height;
		}
		
		public static Dictionary<DisplayMode, Resolution> SUPPORTED_RESOLUTIONS = new Dictionary<DisplayMode, Resolution>()
		{
			{ DisplayMode.LOWRES, new Resolution() {Width = 64, Height = 32} },	
			{ DisplayMode.HIGHRES, new Resolution() {Width = 128, Height = 64} }	
		};
		
	}
}

