using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace Infrastructure.Core.Resources
{
	public class FxSection
	{
		/// <summary>
		/// Gets all shader contexts.
		/// </summary>
		public List<ShaderContext> Contexts { get; private set;}

		/// <summary>
		/// Gets all shader uniforms.
		/// </summary>
		public List<ShaderUniform> Uniforms { get; private set; }

		/// <summary>
		/// Gets all shader samplers.
		/// </summary>
		public List<ShaderSampler> Samplers { get; private set; }

		/// <summary>
		/// Gets the shader resource this FX section belongs to.
		/// </summary>
		public ShaderResource Shader { get; private set; }

		/// <summary>
		/// Loads the FX section from the given xml string.
		/// </summary>
		/// <param name="shader">The shader this FX section belongs to.</param>
		/// <param name="shaderSections">The shader sections.</param>
		/// <param name="xmlContent">The xml content.</param>
		internal void LoadFromXml(ShaderResource shader, List<ShaderSection> shaderSections, string xmlContent)
		{
			if (shader == null)
				throw new ArgumentNullException("shader");

			if (String.IsNullOrEmpty(xmlContent))
				throw new ArgumentNullException("xmlContent");

			Shader = shader;

			if (Contexts == null)
				Contexts = new List<ShaderContext>();
			if (Uniforms == null)
				Uniforms = new List<ShaderUniform>();
			if (Samplers == null)
				Samplers = new List<ShaderSampler>();

			var newUniforms = new List<ShaderUniform>();
			var newSamplers = new List<ShaderSampler>();
			var newContexts = new List<ShaderContext>();

			foreach (var xmlContext in LinqToXml.GetElements(xmlContent, "Context"))
			{
				var contextName = xmlContext.Attribute("id");
				if (contextName == null)
					return;

				var context = Contexts.Where(c => c.Name == contextName.Value).SingleOrDefault();

				if (context == null)
					context = new ShaderContext();

				newContexts.Add(context);
				context.LoadFromXml(shader, shaderSections, xmlContext);
			}

			foreach (var xmlSampler in LinqToXml.GetElements(xmlContent, "Sampler"))
			{
				var samplerName = xmlSampler.Attribute("id");
				if (samplerName == null)
					return;

				var sampler = Samplers.Where(s => s.Name == samplerName.Value).SingleOrDefault();

				if (sampler == null)
					sampler = new ShaderSampler();

				newSamplers.Add(sampler);
				sampler.LoadFromXml(xmlSampler);
			}

			foreach (var xmlUniform in LinqToXml.GetElements(xmlContent, "Uniform"))
			{
				var uniformName = xmlUniform.Attribute("id");
				if (uniformName == null)
					return;

				var uniform = Uniforms.Where(u => u.Name == uniformName.Value).SingleOrDefault();

				if (uniform == null)
					uniform = new ShaderUniform();

				newUniforms.Add(uniform);
				uniform.LoadFromXml(xmlUniform);
			}

			Contexts.Clear();
			Contexts.AddRange(newContexts);

			Uniforms.Clear();
			Uniforms.AddRange(newUniforms);

			Samplers.Clear();
			Samplers.AddRange(newSamplers);
		}

		/// <summary>
		/// Generates the Xml content.
		/// </summary>
		/// <returns>Returns the generated Xml elements.</returns>
		internal IEnumerable<XElement> GenerateXml()
		{
			var elements = new List<XElement>();

			Uniforms.Foreach(u => elements.Add(u.GenerateXml()));
			Samplers.Foreach(s => elements.Add(s.GenerateXml()));
			Contexts.Foreach(c => elements.Add(c.GenerateXml()));

			return elements;
		}
	}
}
