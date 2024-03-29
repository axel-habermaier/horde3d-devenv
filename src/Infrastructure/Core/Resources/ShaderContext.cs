using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.ComponentModel;

namespace Infrastructure.Core.Resources
{
	public class ShaderContext : INotifyPropertyChanged, INotifyPropertyUpdated
	{
		#region Properties
		private ShaderSection vertexShader;
		/// <summary>
		/// Gets or sets the context's vertex shader.
		/// </summary>
		public ShaderSection VertexShader
		{
			get { return vertexShader; }
			set
			{
				if (vertexShader != value)
				{
					var previousValue = vertexShader;
					vertexShader = value;
					OnPropertyChanged("VertexShader");
					OnPropertyUpdated("VertexShader", previousValue, vertexShader,
						new PropertyAccessor<ShaderSection>(propertyValue => VertexShader = propertyValue, () => VertexShader));
				}
			}
		}

		private ShaderSection fragmentShader;
		/// <summary>
		/// Gets or sets the context's fragment shader.
		/// </summary>
		public ShaderSection FragmentShader
		{
			get { return fragmentShader; }
			set
			{
				if (fragmentShader != value)
				{
					var previousValue = fragmentShader;
					fragmentShader = value;
					OnPropertyChanged("FragmentShader");
					OnPropertyUpdated("FragmentShader", previousValue, fragmentShader,
						new PropertyAccessor<ShaderSection>(propertyValue => FragmentShader = propertyValue, () => FragmentShader));
				}
			}
		}

		private string name;
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		public string Name
		{
			get { return name; }
			set
			{
				if (name != value)
				{
					var previousValue = name;
					name = value;
					OnPropertyChanged("Name");
					OnPropertyUpdated("Name", previousValue, name,
						new PropertyAccessor<string>(propertyValue => Name = propertyValue, () => Name));
				}
			}
		}

		/// <summary>
		/// Gets or sets the context's render config.
		/// </summary>
		public ShaderRenderConfig RenderConfig { get; set; }

		/// <summary>
		/// Gets the shader resource this context belongs to.
		/// </summary>
		public ShaderResource Shader { get; private set; }
		#endregion

		/// <summary>
		/// Loads the context from the given xml.
		/// </summary>
		/// <param name="shader">The shader this context belongs to.</param>
		/// <param name="shaderSections">The shader sections.</param>
		/// <param name="xml">The xml content.</param>
		internal void LoadFromXml(ShaderResource shader, List<ShaderSection> shaderSections, XElement xml)
		{
			if (shader == null)
				throw new ArgumentNullException("shader");

			if (xml == null)
				throw new ArgumentNullException("xmlContent");

			Shader = shader;
			Name = xml.Attribute("id").Value;

			var shadersElement = xml.Element("Shaders");
			var xmlFragmentShader = shadersElement.Attribute("fragment");
			var xmlVertexShader = shadersElement.Attribute("vertex");
			var xmlRenderConfig = xml.Element("RenderConfig");

			if (xmlVertexShader != null)
				VertexShader = shaderSections.Where(s => s.Name == xmlVertexShader.Value).SingleOrDefault();
			else 
				VertexShader = null;

			if (xmlFragmentShader != null)
				FragmentShader = shaderSections.Where(s => s.Name == xmlFragmentShader.Value).SingleOrDefault();
			else 
				FragmentShader = null;

			if (RenderConfig == null)
				RenderConfig = new ShaderRenderConfig();

			if (xmlRenderConfig != null)
				RenderConfig.LoadFromXml(xmlRenderConfig);
			else
				RenderConfig.Reset();
		}

		/// <summary>
		/// Generates the Xml content.
		/// </summary>
		/// <returns>Returns the generated Xml element.</returns>
		internal XElement GenerateXml()
		{
			return new XElement("Context",
				new XAttribute("id", Name),
				RenderConfig.GenerateXml(),
				new XElement("Shaders",
					new XAttribute("vertex", VertexShader.Name),
					new XAttribute("fragment", FragmentShader.Name)));
		}

		#region INotifyPropertyChanged Implementation
		/// <summary>
		/// Raised when the value of a property was changed.
		/// <summary/>		
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Raises the PropertyChanged event.
		/// </summary>
		/// <param name="propertyName">The name of the property that was changed.</param>
		protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion

		#region INotifyPropertyUpdated Implementation
		/// <summary>
		/// Raised when the value of a property was updated.
		/// <summary/>		
		public event PropertyUpdatedEventHandler PropertyUpdated;

		/// <summary>
		/// Raises the PropertyUpdated event.
		/// </summary>
		/// <param name="propertyName">The name of the property that was changed.</param>
		/// <param name="previousValue">The value of the property before the update.</param>
		/// <param name="currentValue">The value of the property after the update.</param>
		/// <param name="propertyAccessor">The property accessor.</param>
		protected void OnPropertyUpdated(string propertyName, object previousValue, object currentValue, IPropertyAccessor propertyAccessor)
		{
			if (PropertyUpdated != null)
				PropertyUpdated(this, new PropertyUpdatedEventArgs(propertyName, previousValue, currentValue, propertyAccessor));
		}
		#endregion
	}
}
