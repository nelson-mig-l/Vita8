using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;

namespace Vita8
{
	public class EmulatorScene : Scene
	{
		private Emulator emulator;
		
		private System.Timers.Timer timer = new System.Timers.Timer(1000); 
		private int fps = 0;
		private int realfps = 0;
		
		private SpriteUV sprite;
		private Texture2D texture;
		
		private Label fpsLabel = new Label()
		{
			Position = new Vector2(5, 5)	
		};
		
		public EmulatorScene(Emulator emulator)
		{
			this.sprite = new SpriteUV();
			this.texture = new Texture2D(64*10, 32*10, false, PixelFormat.Rgba);
			TextureInfo texture_info = new TextureInfo(texture);
			sprite.TextureInfo = texture_info;		
			sprite.Quad.S = texture_info.TextureSizef; 
			int width = Director.Instance.GL.Context.Screen.Width;
			int height = Director.Instance.GL.Context.Screen.Height;
			sprite.Position = new Vector2((width - texture.Width)/2, (height - texture.Height)/2);
			this.AddChild( sprite );
			
			this.timer.Elapsed += delegate {
				fpsLabel.Text = "Frames per second: " + fps + "/" + realfps;
				fps = 0;
				realfps = 0;
			};
			this.timer.Enabled = true;
			
			this.emulator = emulator;
			
			this.AddChild(fpsLabel);
			Scheduler.Instance.ScheduleUpdateForTarget(this, 1, false);

			this.emulator.Start();
			
			this.emulator.Stop();
			
			RegisterDisposeOnExit(this.emulator);
		}
		
		public override void Update(float dt)
		{
			//emulator.Update();
			//elapsedTime += dt;
			base.Update(dt);
		}
		
		public override void Draw()
		{
			realfps++;
			if (emulator.Render(texture))
			{
				fps++;
				base.Draw();
			}
		}
		
		public override void OnExit()
		{
			this.emulator.Stop();
			base.OnExit();
		}
	}
}

