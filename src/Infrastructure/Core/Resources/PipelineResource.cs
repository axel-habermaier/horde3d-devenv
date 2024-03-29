using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Horde3DNET;
using System.Xml.Linq;

namespace Infrastructure.Core.Resources
{
	[DataContract]
	public class PipelineResource : EditableResource
	{
		internal PipelineResource(int resHandle) 
			: base(resHandle)
		{

		}

		public override Horde3D.ResourceTypes ResourceType
		{
			get { return Horde3D.ResourceTypes.Pipeline; }
		}

		/// <summary>
		/// Gets the list of render targets used by the pipeline.
		/// </summary>
		public List<RenderTarget> RenderTargets { get; private set; }

		/// <summary>
		/// Loads the resource from Xml stored in the FileContent property.
		/// </summary>
		public override void LoadFromXml()
		{
			if (String.IsNullOrEmpty(FileContent))
				throw new InvalidOperationException("Cannot load the pipeline from an empty xml file. Make sure the xml file has been loaded correctly.");

			if (RenderTargets == null)
				RenderTargets = new List<RenderTarget>();

			var pipelineElement = XElement.Parse(FileContent, LoadOptions.PreserveWhitespace);
			var setupElement = pipelineElement.Element("Setup");

			if (setupElement != null)
			{
				var newRenderTargets = new List<RenderTarget>();

				setupElement.Elements("RenderTarget").Foreach(r =>
				{
					var renderTargetName = r.Attribute("id");
					if (renderTargetName == null)
						return;

					var renderTarget = RenderTargets.Where(rt => rt.Name == renderTargetName.Value).SingleOrDefault();

					if (renderTarget == null)
						renderTarget = new RenderTarget();

					newRenderTargets.Add(renderTarget);
					renderTarget.LoadFromXml(r);
				});

				RenderTargets.Clear();
				RenderTargets.AddRange(newRenderTargets);
			}
		}

		/// <summary>
		/// Generates the Xml content and updates the FileContent property.
		/// </summary>
		public override void GenerateXml()
		{

		}
	}
}
