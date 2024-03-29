using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.ComponentModel;

namespace Infrastructure.Core.Resources
{
	public class ShaderUniform : INotifyPropertyChanged, INotifyPropertyUpdated
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

		private float a;
		/// <summary>
		/// Gets or sets the value for the A channel.
		/// </summary>
		public float A
		{
			get { return a; }
			set
			{
				if (a != value)
				{
					var previousValue = a;
					a = value;
					OnPropertyChanged("A");
					OnPropertyUpdated("A", previousValue, a,
						new PropertyAccessor<float>(propertyValue => A = propertyValue, () => A));
				}
			}
		}

		private float b;
		/// <summary>
		/// Gets or sets the value for the B channel.
		/// </summary>
		public float B
		{
			get { return b; }
			set
			{
				if (b != value)
				{
					var previousValue = b;
					b = value;
					OnPropertyChanged("B");
					OnPropertyUpdated("B", previousValue, b,
						new PropertyAccessor<float>(propertyValue => B = propertyValue, () => B));
				}
			}
		}

		private float c;
		/// <summary>
		/// Gets or sets the value for the C channel.
		/// </summary>
		public float C
		{
			get { return c; }
			set
			{
				if (c != value)
				{
					var previousValue = c;
					c = value;
					OnPropertyChanged("C");
					OnPropertyUpdated("C", previousValue, c,
						new PropertyAccessor<float>(propertyValue => C = propertyValue, () => C));
				}
			}
		}

		private float d;
		/// <summary>
		/// Gets or sets the value for the D channel.
		/// </summary>
		public float D
		{
			get { return d; }
			set
			{
				if (d != value)
				{
					var previousValue = d;
					d = value;
					OnPropertyChanged("D");
					OnPropertyUpdated("D", previousValue, d,
						new PropertyAccessor<float>(propertyValue => D = propertyValue, () => D));
				}
			}
		}
		#endregion

		/// <summary>
		/// Initializes a new instance with default values.
		/// </summary>
		public ShaderUniform()
		{
			Name = String.Empty;
			A = 0.0f;
			B = 0.0f;
			C = 0.0f;
			D = 0.0f;
		}

		/// <summary>
		/// Loads the uniform from the given xml content.
		/// </summary>
		/// <param name="xml">The xml content.</param>
		internal void LoadFromXml(XElement xml)
		{
			if (xml == null)
				throw new ArgumentNullException("xml");

			var xmlName = xml.Attribute("id");
			if (xmlName != null)
				Name = xmlName.Value;
			else
				Name = String.Empty;

			var xmlA = xml.Attribute("a");
			var xmlB = xml.Attribute("b");
			var xmlC = xml.Attribute("c");
			var xmlD = xml.Attribute("d");

			float a = 0.0f;
			if (xmlA != null)
				Single.TryParse(xmlA.Value, out a);
			A = a;

			float b = 0.0f;
			if (xmlB != null)
				Single.TryParse(xmlB.Value, out b);
			B = b;

			float c = 0.0f;
			if (xmlC != null)
				Single.TryParse(xmlC.Value, out c);
			C = c;

			float d = 0.0f;
			if (xmlD != null)
				Single.TryParse(xmlD.Value, out d);
			D = d;
		}

		/// <summary>
		/// Generates the Xml content.
		/// </summary>
		/// <returns>Returns the generated Xml element.</returns>
		internal XElement GenerateXml()
		{
			var aAttribute = A == 0.0f ? null : new XAttribute("a", A);
			var bAttribute = B == 0.0f ? null : new XAttribute("b", B);
			var cAttribute = C == 0.0f ? null : new XAttribute("c", C);
			var dAttribute = D == 0.0f ? null : new XAttribute("d", D);

			return new XElement("Uniform",
				new XAttribute("id", Name),
				aAttribute,
				bAttribute,
				cAttribute,
				dAttribute);
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
