using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Input;

namespace Vita8
{
	public class Vita8Graphics
	{
		private static GraphicsContext graphics;
		
		private static ShaderProgram textureShaderProgram;
    	private static ShaderProgram colorShaderProgram;
		
		private static Matrix4 projectionMatrix;
    	private static Matrix4 viewMatrix;
		
		private static VertexBuffer vertices; 
		
		public static void Initialize(GraphicsContext graphics) {
			Vita8Graphics.graphics = graphics;
			
			Vita8Graphics.textureShaderProgram = Vita8ShaderHelper.CreateDefaultTextureShader();
	        Vita8Graphics.colorShaderProgram = Vita8ShaderHelper.CreateDefaultColorShader();
			
			Vita8Graphics.projectionMatrix = Matrix4.Ortho(0, Width,
	                                         0, Height,
	                                         0.0f, 32768.0f);
	
	        Vita8Graphics.viewMatrix = Matrix4.LookAt(new Vector3(0, Height, 0),
	                                    new Vector3(0, Height, 1),
	                                    new Vector3(0, -1, 0));
			
			Vita8Graphics.vertices = new VertexBuffer(4, VertexFormat.Float3, VertexFormat.Float2);

			float[] positions = {
				0.0f, 0.0f, 0.0f,
				1.0f, 0.0f, 0.0f,
				1.0f, 1.0f, 0.0f,
				0.0f, 1.0f, 0.0f,
			};
			float[] texcoords = {
				0.0f, 0.0f,
				1.0f, 0.0f,
				1.0f, 1.0f,
				0.0f, 1.0f,				
			};
			
			Vita8Graphics.vertices.SetVertices(0, positions);
			Vita8Graphics.vertices.SetVertices(1, texcoords);
		}
		
	    public static void Terminate()
	    {
	        Vita8Graphics.colorShaderProgram.Dispose();
	        Vita8Graphics.textureShaderProgram.Dispose();
	        Vita8Graphics.graphics = null;
	    }		
		
		public static int Width
	    {
	        get {return Vita8Graphics.graphics.GetFrameBuffer().Width;}
	    }
	
	    public static int Height
	    {
	        get {return Vita8Graphics.graphics.GetFrameBuffer().Height;}
	    }
		
		public static int TouchPixelX(TouchData touchData)
	    {
	        return (int)((touchData.X + 0.5f) * Width);
	    }
	
	    public static int TouchPixelY(TouchData touchData)
	    {
	        return (int)((touchData.Y + 0.5f) * Height);
	    }

		
		public static void FillRect(uint argb, int positionX, int positionY, int rectW, int rectH)
    	{
        	FillVertices(vertices, argb, positionX, positionY, rectW, rectH);
    	}
	
	    private static void FillVertices(VertexBuffer vertices, uint argb, float positionX, float positionY, float scaleX, float scaleY)
	    {
	        var transMatrix = Matrix4.Translation(new Vector3(positionX, positionY, 0.0f));
	        var scaleMatrix = Matrix4.Scale(new Vector3(scaleX, scaleY, 1.0f));
	        var modelMatrix = transMatrix * scaleMatrix;
	
	        var worldViewProj = projectionMatrix * viewMatrix * modelMatrix;
	
	        colorShaderProgram.SetUniformValue(0, ref worldViewProj);
	
	        Vector4 color = new Vector4((float)((argb >> 16) & 0xff) / 0xff,
	                                    (float)((argb >> 8) & 0xff) / 0xff,
	                                    (float)((argb >> 0) & 0xff) / 0xff,
	                                    (float)((argb >> 24) & 0xff) / 0xff);
	        colorShaderProgram.SetUniformValue(colorShaderProgram.FindUniform("MaterialColor"), ref color);
	
	        graphics.SetShaderProgram(colorShaderProgram);
	        graphics.SetVertexBuffer(0, vertices);
	
	        graphics.DrawArrays(DrawMode.TriangleFan, 0, vertices.VertexCount);
	    }
		
		public static void FillTexture(Texture2D texture, int positionX, int positionY, int rectW, int rectH)
		{
	        var transMatrix = Matrix4.Translation(new Vector3(positionX, positionY, 0.0f));
	        var scaleMatrix = Matrix4.Scale(new Vector3(rectW, rectH, 1.0f));
	        var modelMatrix = transMatrix * scaleMatrix;
	
	        var worldViewProj = projectionMatrix * viewMatrix * modelMatrix;	
			
			Vita8Graphics.textureShaderProgram.SetUniformValue(0, ref worldViewProj);
			Vita8Graphics.graphics.SetShaderProgram(Vita8Graphics.textureShaderProgram);
			Vita8Graphics.graphics.SetVertexBuffer(0, Vita8Graphics.vertices);
			Vita8Graphics.graphics.SetTexture(0, texture);
			Vita8Graphics.graphics.DrawArrays(DrawMode.TriangleFan, 0, vertices.VertexCount);
		}
		
		public static void Clear()
		{
			Vita8Graphics.graphics.Clear();	
		}
		
		public static void SwapBuffers()
		{
			Vita8Graphics.graphics.SwapBuffers();
		}
		
		[Obsolete]
		private static Texture2D texture = new Texture2D(64, 32, false, PixelFormat.Rgba);
		[Obsolete]
		public static void FillTexture(uint[] pixels, int positionX, int positionY, int rectW, int rectH)
		{
	        var transMatrix = Matrix4.Translation(new Vector3(positionX, positionY, 0.0f));
	        var scaleMatrix = Matrix4.Scale(new Vector3(rectW, rectH, 1.0f));
	        var modelMatrix = transMatrix * scaleMatrix;
	
	        var worldViewProj = projectionMatrix * viewMatrix * modelMatrix;	
			
			Vita8Graphics.textureShaderProgram.SetUniformValue(0, ref worldViewProj);
			Vita8Graphics.graphics.SetShaderProgram(Vita8Graphics.textureShaderProgram);
			Vita8Graphics.graphics.SetVertexBuffer(0, Vita8Graphics.vertices);
			Vita8Graphics.graphics.SetTexture(0, texture);
			Vita8Graphics.texture.SetPixels(0, pixels, 0, 0, 64, 32);
			Vita8Graphics.graphics.DrawArrays(DrawMode.TriangleFan, 0, 4);
		}		
	}
}

