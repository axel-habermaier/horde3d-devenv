using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.ComponentModel;

namespace Infrastructure.Core.Resources
{
	public class ShaderSampler : INotifyPropertyChanged, INotifyPropertyUpdated
	{
		#region Properties
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

		private int texUnit;
		/// <summary>
		/// Gets or sets the texture unit.
		/// </summary>
		public int TexUnit
		{
			get { return texUnit; }
			set
			{
				if (texUnit != value)
				{
					var previousValue = texUnit;
					texUnit = value;
					OnPropertyChanged("TexUnit");
					OnPropertyUpdated("TexUnit", previousValue, texUnit,
						new PropertyAccessor<int>(propertyValue => TexUnit = propertyValue, () => TexUnit));
				}
			}
		}

		/// <summary>
		/// Gets or sets the sampler's stage config.
		/// </summary>
		public SamplerStageConfig StageConfig { get; set; }
		#endregion

		/// <summary>
		/// Initializes a new instance with default values.
		/// </summary>
		public ShaderSampler()
		{
			Name = String.Empty;
			TexUnit = -1;
		}

		/// <summary>
		/// Loads the sampler from the given xml content.
		/// </summary>
		/// <param name="xmlContent">The xml content.</param>
		internal void LoadFromXml(XElement xmlSampler)
		{
			if (xmlSampler == null)
				throw new ArgumentNullException("xmlSampler");

			var xmlName = xmlSampler.Attribute("id");
			if (xmlName != null)
				Name = xmlName.Value;
			else
				Name = String.Empty;

			int texUnit = -1;
			var xmlTexUnit = xmlSampler.Attribute("texUnit");
			if (xmlTexUnit != null)
				Int32.TryParse(xmlTexUnit.Value, out texUnit);
			TexUnit = texUnit;

			if (StageConfig == null)
				StageConfig = new SamplerStageConfig();

			var xmlStageConfig = xmlSampler.Element("StageConfig");
			if (xmlStageConfig != null)
				StageConfig.LoadFromXml(xmlStageConfig);
			else
				StageConfig.Reset();
		}

		/// <summary>
		/// Generates the Xml content.
		/// </summary>
		/// <returns>Returns the generated Xml element.</returns>
		internal XElement GenerateXml()
		{
			var texUnitAttribute = TexUnit == -1 ? null : new XAttribute("texUnit", TexUnit);

			return new XElement("Sampler",
				new XAttribute("id", Name),
				texUnitAttribute,
				StageConfig.GenerateXml());
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
