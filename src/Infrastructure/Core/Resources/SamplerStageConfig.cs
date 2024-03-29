using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.ComponentModel;

namespace Infrastructure.Core.Resources
{
	public class SamplerStageConfig : INotifyPropertyChanged, INotifyPropertyUpdated
	{
		#region Properties
		private AddressMode addressMode;
		/// <summary>
		/// Gets or sets the address mode.
		/// </summary>
		public AddressMode AddressMode
		{
			get { return addressMode; }
			set
			{
				if (addressMode != value)
				{
					var previousValue = addressMode;
					addressMode = value;
					OnPropertyChanged("AddressMode");
					OnPropertyUpdated("AddressMode", previousValue, addressMode, 
						new PropertyAccessor<AddressMode>(propertyValue => AddressMode = propertyValue, () => AddressMode));
				}
			}
		}

		private FilteringMode filteringMode;
		/// <summary>
		/// Gets or sets the filtering mode.
		/// </summary>
		public FilteringMode FilteringMode
		{
			get { return filteringMode; }
			set
			{
				if (filteringMode != value)
				{
					var previousValue = filteringMode;
					filteringMode = value;
					OnPropertyChanged("FilteringMode");
					OnPropertyUpdated("FilteringMode", previousValue, filteringMode,
						new PropertyAccessor<FilteringMode>(propertyValue => FilteringMode = propertyValue, () => FilteringMode));
				}
			}
		}

		private int maxAnisotropy;
		/// <summary>
		/// Gets or sets the maximum anisotropy.
		/// </summary>
		public int MaxAnisotropy
		{
			get { return maxAnisotropy; }
			set
			{
				if (maxAnisotropy != value)
				{
					var previousValue = maxAnisotropy;
					maxAnisotropy = value;
					OnPropertyChanged("MaxAnisotropy");
					OnPropertyUpdated("MaxAnisotropy", previousValue, maxAnisotropy,
						new PropertyAccessor<int>(propertyValue => MaxAnisotropy = propertyValue, () => MaxAnisotropy));
				}
			}
		}

		/// <summary>
		/// Gets the default instance.
		/// </summary>
		public static SamplerStageConfig Default { get; private set; }
		#endregion

		/// <summary>
		/// Initializes the default instance.
		/// </summary>
		static SamplerStageConfig()
		{
			Default = new SamplerStageConfig(true);
		}

		/// <summary>
		/// Initializes the default instance.
		/// </summary>
		private SamplerStageConfig(bool setDefaultValues)
		{
			AddressMode = AddressMode.Wrap;
			FilteringMode = FilteringMode.Trilinear;
			MaxAnisotropy = 8;
		}

		/// <summary>
		/// Initializes a new instance with default value.
		/// </summary>
		public SamplerStageConfig()
		{
			Reset();
		}

		/// <summary>
		/// Resets the properties to their default values.
		/// </summary>
		public void Reset()
		{
			AddressMode = Default.AddressMode;
			FilteringMode = Default.FilteringMode;
			MaxAnisotropy = Default.MaxAnisotropy;
		}

		/// <summary>
		/// Loads the stage config from the given xml content.
		/// </summary>
		/// <param name="xml">The xml content.</param>
		internal void LoadFromXml(XElement xml)
		{
			if (xml == null)
				throw new ArgumentNullException("xml");

			var xmlAddressMode = xml.Attribute("addressMode");
			var xmlFiltering = xml.Attribute("filtering");
			var xmlMaxAnisotropy = xml.Attribute("maxAnisotropy");

			if (xmlAddressMode != null)
				AddressMode = AddressModeStringConverter.ConvertToAddressMode(xmlAddressMode.Value);
			else
				AddressMode = Default.AddressMode;

			if (xmlFiltering != null)
				FilteringMode = FilteringModeStringConverter.ConvertToFilteringMode(xmlFiltering.Value);
			else
				FilteringMode = Default.FilteringMode;

			int maxAnisotropy = Default.MaxAnisotropy;
			if (xmlMaxAnisotropy != null)
				Int32.TryParse(xmlMaxAnisotropy.Value, out maxAnisotropy);
			MaxAnisotropy = maxAnisotropy;
		}

		/// <summary>
		/// Generates the Xml content.
		/// </summary>
		/// <returns>Returns the generated Xml element.</returns>
		internal XElement GenerateXml()
		{
			if (AddressMode == Default.AddressMode &&
				FilteringMode == Default.FilteringMode &&
				MaxAnisotropy == Default.MaxAnisotropy)
				return null;

			var addressModeAttribute = AddressMode == Default.AddressMode ? null : new XAttribute("addressMode", AddressModeStringConverter.ConvertToString(AddressMode));
			var filteringAttribute = FilteringMode == Default.FilteringMode ? null : new XAttribute("filtering", FilteringModeStringConverter.ConvertToString(FilteringMode));
			var maxAnisotropyAttribute = MaxAnisotropy == Default.MaxAnisotropy ? null : new XAttribute("maxAnisotropy", MaxAnisotropy);

			return new XElement("StageConfig",
				addressModeAttribute,
				filteringAttribute,
				maxAnisotropyAttribute);
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
