using System;
using Sce.PlayStation.Core.Audio;

namespace Vita8
{
	public class Speaker 
	{
		private Sound sound;
        private SoundPlayer soundPlayer;

		public Speaker()
		{
			sound = new Sound("/Application/assets/Square_500Hz_-10dBFS_1s.wav");
            soundPlayer = sound.CreatePlayer();
			soundPlayer.Loop = true;
		}
		
		public void Render(Chip8.Chip8 chip8)
		{
			bool beep = chip8.Beep;
			bool playing = soundPlayer.Status == SoundStatus.Playing;
			
			if (!beep && playing)
			{
				soundPlayer.Stop();
			}
			
			if (beep && !playing) 
			{
				soundPlayer.Play();
			}
			
		}
	}
}

