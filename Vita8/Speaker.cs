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
			bool status = soundPlayer.Status == SoundStatus.Playing;
			// B S P
			// 0 0 -
			// 0 1 off
			// 1 1 -
			// 1 0 on
			if ((beep ^ status) & beep)
			{
				soundPlayer.Play();
			}
			else
			{
				soundPlayer.Stop();
			}
		}
	}
}

