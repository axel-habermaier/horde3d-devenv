using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.ComponentModel;

namespace Infrastructure.Core.Resources
{
	public class ShaderRenderConfig : INotifyPropertyChanged, INotifyPropertyUpdated
	{
		#region Properties
		private bool writeDepth;
		/// <summary>
		/// Gets or sets a value indicating whether writing to the depth buffer is enabled.
		/// </summary>
		public bool WriteDepth
		{
			get { return writeDepth; }
			set
			{
				if (writeDepth != value)
				{
					var previousValue = writeDepth;
					writeDepth = value;
					OnPropertyChanged("WriteDepth");
					OnPropertyUpdated("WriteDepth", previousValue, writeDepth,
						new PropertyAccessor<bool>(propertyValue => WriteDepth = propertyValue, () => WriteDepth));
				}
			}
		}

		private BlendMode blendMode;
		/// <summary>
		/// Gets or sets the blend mode.
		/// </summary>
		public BlendMode BlendMode
		{
			get { return blendMode; }
			set
			{
				if (blendMode != value)
				{
					var previousValue = blendMode;
					blendMode = value;
					OnPropertyChanged("BlendMode");
					OnPropertyUpdated("BlendMode", previousValue, blendMode,
						new PropertyAccessor<BlendMode>(propertyValue => BlendMode = propertyValue, () => BlendMode));
				}
			}
		}

		private TestFunction depthTest;
		/// <summary>
		/// Gets or sets the function used for depth testing.
		/// </summary>
		public TestFunction DepthTest
		{
			get { return depthTest; }
			set
			{
				if (depthTest != value)
				{
					var previousValue = depthTest;
					depthTest = value;
					OnPropertyChanged("DepthTest");
					OnPropertyUpdated("DepthTest", previousValue, depthTest,
						new PropertyAccessor<TestFunction>(propertyValue => DepthTest = propertyValue, () => DepthTest));
				}
			}
		}

		private TestFunction alphaTest;
		/// <summary>
		/// Gets or sets the function used for alpha testing.
		/// </summary>
		public TestFunction AlphaTest
		{
			get { return alphaTest; }
			set
			{
				if (alphaTest != value)
				{
					var previousValue = alphaTest;
					alphaTest = value;
					OnPropertyChanged("AlphaTest");
					OnPropertyUpdated("AlphaTest", previousValue, alphaTest,
						new PropertyAccessor<TestFunction>(propertyValue => AlphaTest = propertyValue, () => AlphaTest));
				}
			}
		}

		private float alphaReferenceValue;
		/// <summary>
		/// Gets or sets the reference value used by the alpha test.
		/// </summary>
		public float AlphaReferenceValue
		{
			get { return alphaReferenceValue; }
			set
			{
				if (alphaReferenceValue != value)
				{
					var previousValue = alphaReferenceValue;
					alphaReferenceValue = value;
					OnPropertyChanged("AlphaReferenceValue");
					OnPropertyUpdated("AlphaReferenceValue", previousValue, alphaReferenceValue,
						new PropertyAccessor<float>(propertyValue => AlphaReferenceValue = propertyValue, () => AlphaReferenceValue));
				}
			}
		}

		private bool alphaToCoverage;
		/// <summary>
		/// Gets or sets a value indicating whether alpha to coverage is enabled.
		/// </summary>
		public bool AlphaToCoverage
		{
			get { return alphaToCoverage; }
			set
			{
				if (alphaToCoverage != value)
				{
					var previousValue = alphaToCoverage;
					alphaToCoverage = value;
					OnPropertyChanged("AlphaToCoverage");
					OnPropertyUpdated("AlphaToCoverage", previousValue, alphaToCoverage,
						new PropertyAccessor<bool>(propertyValue => AlphaToCoverage = propertyValue, () => AlphaToCoverage));
				}
			}
		}

		/// <summary>
		/// Gets the default instance.
		/// </summary>
		public static ShaderRenderConfig Default { get; private set; }
		#endregion

		/// <summary>
		/// Initializes the default instance.
		/// </summary>
		static ShaderRenderConfig()
		{
			Default = new ShaderRenderConfig(true);
		}

		/// <summary>
		/// Initializes the default instance.
		/// </summary>
		private ShaderRenderConfig(bool setDefaultValues)
		{
			WriteDepth = true;
			BlendMode = BlendMode.Replace;
			DepthTest = TestFunction.LessEqual;
			AlphaTest = TestFunction.Always;
			AlphaReferenceValue = 0.0f;
			AlphaToCoverage = false;
		}

		/// <summary>
		/// Initializes a new render config with default values.
		/// </summary>
		public ShaderRenderConfig()
		{
			Reset();
		}

		/// <summary>
		/// Resets the properties to their default values.
		/// </summary>
		public void Reset()
		{
			WriteDepth = Default.WriteDepth;
			BlendMode = Default.BlendMode;
			DepthTest = Default.DepthTest;
			AlphaTest = Default.AlphaTest;
			AlphaReferenceValue = Default.AlphaReferenceValue;
			AlphaToCoverage = Default.AlphaToCoverage;
		}

		/// <summary>
		/// Loads the context from the given xml .
		/// </summary>
		/// <param name="xml">The xml content.</param>
		internal void LoadFromXml(XElement xml)
		{
			if (xml == null)
				throw new ArgumentNullException("xmlContent");

			var xmlWriteDepth = xml.Attribute("writeDepth");
			var xmlBlendMode = xml.Attribute("blendMode");
			var xmlDepthTest = xml.Attribute("depthTest");
			var xmlAlphaTest = xml.Attribute("alphaTest");
			var xmlAlphaRef = xml.Attribute("alphaRef");
			var xmlAlphaToCoverage = xml.Attribute("alphaToCoverage");

			var writeDepth = Default.WriteDepth;
			if (xmlWriteDepth != null)
				Boolean.TryParse(xmlWriteDepth.Value, out writeDepth);
			WriteDepth = writeDepth;

			if (xmlBlendMode != null)
				BlendMode = BlendModeStringConverter.ConvertToBlendMode(xmlBlendMode.Value);
			else
				BlendMode = Default.BlendMode;

			if (xmlDepthTest != null)
				DepthTest = TestFunctionStringConverter.ConvertToTestFunction(xmlDepthTest.Value);
			else
				DepthTest = Default.DepthTest;

			if (xmlAlphaTest != null)
				AlphaTest = TestFunctionStringConverter.ConvertToTestFunction(xmlAlphaTest.Value);
			else
				AlphaTest = Default.AlphaTest;

			float alphaRef = Default.AlphaReferenceValue;
			if (xmlAlphaRef != null)
				Single.TryParse(xmlAlphaRef.Value, out alphaRef);
			AlphaReferenceValue = alphaRef;

			var alphaToCoverage = Default.AlphaToCoverage;
			if (xmlAlphaToCoverage != null)
				Boolean.TryParse(xmlAlphaToCoverage.Value, out alphaToCoverage);
			AlphaToCoverage = alphaToCoverage;
		}

		/// <summary>
		/// Generates the Xml content.
		/// </summary>
		/// <returns>Returns the generated Xml element.</returns>
		internal XElement GenerateXml()
		{
			if (WriteDepth == Default.WriteDepth &&
				BlendMode == Default.BlendMode &&
				DepthTest == Default.DepthTest &&
				AlphaTest == Default.AlphaTest &&
				AlphaReferenceValue == Default.AlphaReferenceValue &&
				AlphaToCoverage == Default.AlphaToCoverage)
				return null;

			var writeDepthAttribute = WriteDepth == Default.WriteDepth ? null : new XAttribute("writeDepth", WriteDepth);
			var blendModeAttribute = BlendMode == Default.BlendMode ? null : new XAttribute("blendMode", BlendModeStringConverter.ConvertToString(BlendMode));
			var depthTestAttribute = DepthTest == Default.DepthTest ? null : new XAttribute("depthTest", TestFunctionStringConverter.ConvertToString(DepthTest));
			var alphaTestAttribute = AlphaTest == Default.AlphaTest ? null : new XAttribute("alphaTest", TestFunctionStringConverter.ConvertToString(AlphaTest));
			var alphaRefAttribute = AlphaReferenceValue == Default.AlphaReferenceValue ? null : new XAttribute("alphaRef", AlphaReferenceValue);
			var alphaToCoverageAttribute = AlphaToCoverage == Default.AlphaToCoverage ? null : new XAttribute("alphaToCoverage", AlphaToCoverage);

			return new XElement("RenderConfig",
				writeDepthAttribute,
				blendModeAttribute,
				depthTestAttribute,
				alphaTestAttribute,
				alphaRefAttribute,
				alphaToCoverageAttribute);
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
