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
		
		public EmulatorScene(Emulator emulator)
		{
			this.sprite = new SpriteUV();
			this.texture = new Texture2D(64*10, 32*10, false, PixelFormat.Rgba);
			TextureInfo texture_info = new TextureInfo(texture);
			sprite.TextureInfo = texture_info;		
			sprite.Quad.S = texture_info.TextureSizef; 
			//sprite.CenterSprite();
			sprite.Position = new Vector2(0.5f, 0.5f);//this.Camera.CalcBounds().Center;
			this.AddChild( sprite );
			
			this.timer.Elapsed += delegate {
				Console.WriteLine("fps: " + fps + "/" + realfps);
				fps = 0;
				realfps = 0;
			};
			this.timer.Enabled = true;
			
			this.emulator = emulator;
			
			this.emulator.Resume();
			
			Label label = new Label() 
			{ 
				Text="Top Left",
				Position=new Vector2(5, 5) 
			};
			this.AddChild(label);
			Scheduler.Instance.ScheduleUpdateForTarget(this, 1, false);
		}
		
		public override void Update(float dt)
		{
			emulator.Update();
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
	}
}

