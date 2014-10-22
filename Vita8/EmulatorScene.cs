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
		
		public EmulatorScene(Emulator emulator)
		{
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
			Texture2D texture = emulator.Render();
			if (texture != null)
			{
				
				var texture_info = new TextureInfo(texture);
				
				// create a new sprite
				var sprite = new SpriteUV() { TextureInfo = texture_info};
		
				// make the texture 1:1 on screen
				sprite.Quad.S = texture_info.TextureSizef; 
		
				// center the sprite around its own .Position 
				// (by default .Position is the lower left bit of the sprite)
				sprite.CenterSprite();
		
				// put the sprite at the center of the screen
				sprite.Position = this.Camera.CalcBounds().Center;
		
				// our scene only has 2 nodes: scene->sprite
				this.AddChild( sprite );
	
				base.Draw();
			}
		}
	}
}

