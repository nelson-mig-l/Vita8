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
	public class Vita8ShaderHelper
	{
		private const String DEFAULT_COLOR_SHADER = "Vita8.shaders.Simple.cgx";
		private const String DEFAULT_TEXTURE_SHADER = "Vita8.shaders.Texture.cgx";
		
		public static ShaderProgram CreateDefaultColorShader()
		{
			ShaderProgram shader = CreateShaderFromResource(DEFAULT_COLOR_SHADER);
			
			shader.SetAttributeBinding(0, "a_Position");
	        shader.SetUniformBinding(0, "WorldViewProj");
			
			return shader;
		}
		
		public static ShaderProgram CreateDefaultTextureShader()
		{
			ShaderProgram shader = CreateShaderFromResource(DEFAULT_TEXTURE_SHADER);
			
			shader.SetAttributeBinding(0, "a_Position");
        	shader.SetAttributeBinding(1, "a_TexCoord");
        	shader.SetUniformBinding(0, "WorldViewProj");
			
			return shader;
		}
		
		private static ShaderProgram CreateShaderFromResource(String resourceName)
		{
			Assembly resourceAssembly = Assembly.GetExecutingAssembly();
	        if (resourceAssembly.GetManifestResourceInfo(resourceName) == null)
	        {
	            throw new FileNotFoundException("File not found.", resourceName);
	        }
	
	        Stream fileStreamVertex = resourceAssembly.GetManifestResourceStream(resourceName);
	        Byte[] dataBufferVertex = new Byte[fileStreamVertex.Length];
	        fileStreamVertex.Read(dataBufferVertex, 0, dataBufferVertex.Length);
	            
	        return new ShaderProgram(dataBufferVertex);
		}

	}
}

