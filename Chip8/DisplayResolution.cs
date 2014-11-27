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
			public int Size() 
			{
				return Width * Height;
			}
		}
		
		public static Dictionary<DisplayMode, Resolution> SUPPORTED_RESOLUTIONS = new Dictionary<DisplayMode, Resolution>()
		{
			{ DisplayMode.LOWRES, new Resolution() {Width = 64, Height = 32} },	
			{ DisplayMode.HIGHRES, new Resolution() {Width = 128, Height = 64} }	
		};
		
		public static Resolution GetResolution(int size)
		{
			foreach(Resolution resolution in SUPPORTED_RESOLUTIONS.Values)
			{
				if (resolution.Size() == size)
				{
					return resolution;
				}
			}
			throw new ArgumentOutOfRangeException();			
		}
		
		public static DisplayMode GetDisplayMode(int size) 
		{
			foreach(KeyValuePair<DisplayMode, Resolution> item in SUPPORTED_RESOLUTIONS)
			{
				if (item.Value.Size() == size)
				{
					return item.Key;
				}
			}
			throw new ArgumentOutOfRangeException();
		}
		
		public static DisplayMode GetDisplayMode(int width, int height)
		{
			foreach(KeyValuePair<DisplayMode, Resolution> item in SUPPORTED_RESOLUTIONS)
			{
				if (item.Value.Width == width && item.Value.Height == height)
				{
					return item.Key;
				}
			}
			throw new ArgumentOutOfRangeException();			
		}
	}
}

