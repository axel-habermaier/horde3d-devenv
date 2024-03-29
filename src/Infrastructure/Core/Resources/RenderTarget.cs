using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Linq;

namespace Infrastructure.Core.Resources
{
	public class RenderTarget : INotifyPropertyUpdated, INotifyPropertyChanged
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

		private bool useDepthBuffer;
		/// <summary>
		/// Gets or sets a value indicating whether a depth buffer should be used for the render target.
		/// </summary>
		public bool UseDepthBuffer
		{
			get { return useDepthBuffer; }
			set
			{
				if (useDepthBuffer != value)
				{
					var previousValue = useDepthBuffer;
					useDepthBuffer = value;
					OnPropertyChanged("UseDepthBuffer");
					OnPropertyUpdated("UseDepthBuffer", previousValue, useDepthBuffer,
						new PropertyAccessor<bool>(propertyValue => UseDepthBuffer = propertyValue, () => UseDepthBuffer));
				}
			}
		}

		private int numColorBuffers;
		/// <summary>
		/// Gets or sets the amount of color buffers.
		/// </summary>
		public int NumColorBuffers
		{
			get { return numColorBuffers; }
			set
			{
				if (numColorBuffers != value)
				{
					var previousValue = numColorBuffers;
					numColorBuffers = value;
					OnPropertyChanged("NumColorBuffers");
					OnPropertyUpdated("NumColorBuffers", previousValue, numColorBuffers,
						new PropertyAccessor<int>(propertyValue => NumColorBuffers = propertyValue, () => NumColorBuffers));
				}
			}
		}

		private PixelFormat pixelFormat;
		/// <summary>
		/// Gets or sets the pixel format.
		/// </summary>
		public PixelFormat PixelFormat
		{
			get { return pixelFormat; }
			set
			{
				if (pixelFormat != value)
				{
					var previousValue = pixelFormat;
					pixelFormat = value;
					OnPropertyChanged("PixelFormat");
					OnPropertyUpdated("PixelFormat", previousValue, pixelFormat,
						new PropertyAccessor<PixelFormat>(propertyValue => PixelFormat = propertyValue, () => PixelFormat));
				}
			}
		}

		private int width;
		/// <summary>
		/// Gets or sets the width.
		/// </summary>
		public int Width
		{
			get { return width; }
			set
			{
				if (width != value)
				{
					var previousValue = width;
					width = value;
					OnPropertyChanged("Width");
					OnPropertyUpdated("Width", previousValue, width,
						new PropertyAccessor<int>(propertyValue => Width = propertyValue, () => Width));
				}
			}
		}

		private int height;
		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		public int Height
		{
			get { return height; }
			set
			{
				if (height != value)
				{
					var previousValue = height;
					height = value;
					OnPropertyChanged("Height");
					OnPropertyUpdated("Height", previousValue, height,
						new PropertyAccessor<int>(propertyValue => Height = propertyValue, () => Height));
				}
			}
		}

		private float scale;
		/// <summary>
		/// Gets or sets the scale.
		/// </summary>
		public float Scale
		{
			get { return scale; }
			set
			{
				if (scale != value)
				{
					var previousValue = scale;
					scale = value;
					OnPropertyChanged("Scale");
					OnPropertyUpdated("Scale", previousValue, scale,
						new PropertyAccessor<float>(propertyValue => Scale = propertyValue, () => Scale));
				}
			}
		}

		private int maxSamples;
		/// <summary>
		/// Gets or sets the maximum number of anti aliasing samples.
		/// </summary>
		public int MaxSamples
		{
			get { return maxSamples; }
			set
			{
				if (maxSamples != value)
				{
					var previousValue = maxSamples;
					maxSamples = value;
					OnPropertyChanged("MaxSamples");
					OnPropertyUpdated("MaxSamples", previousValue, maxSamples,
						new PropertyAccessor<int>(propertyValue => MaxSamples = propertyValue, () => MaxSamples));
				}
			}
		}

		/// <summary>
		/// Gets the default instance.
		/// </summary>
		public static RenderTarget Default { get; private set; }
		#endregion

		/// <summary>
		/// Initializes the default instance.
		/// </summary>
		static RenderTarget()
		{
			Default = new RenderTarget(true);
		}

		/// <summary>
		/// Initializes the default instance.
		/// </summary>
		private RenderTarget(bool setDefaultValues)
		{
			Name = String.Empty;
			UseDepthBuffer = false;
			NumColorBuffers = 1;
			PixelFormat = PixelFormat.RGBA8;
			Width = 0;
			Height = 0;
			Scale = 1.0f;
			MaxSamples = 0;
		}

		/// <summary>
		/// Initializes a new instance with default value.
		/// </summary>
		public RenderTarget()
		{
			Reset();
		}

		/// <summary>
		/// Resets the properties to their default values.
		/// </summary>
		public void Reset()
		{
			Name = Default.Name;
			UseDepthBuffer = Default.UseDepthBuffer;
			NumColorBuffers = Default.NumColorBuffers;
			PixelFormat = Default.PixelFormat;
			Width = Default.Width;
			Height = Default.Height;
			Scale = Default.Scale;
			MaxSamples = Default.MaxSamples;
		}

		/// <summary>
		/// Loads the render target from the given xml element.
		/// </summary>
		/// <param name="xml">The xml content.</param>
		internal void LoadFromXml(XElement xml)
		{
			if (xml == null)
				throw new ArgumentNullException("xml");

			Reset();

			var nameElement = xml.Attribute("id");
			if (nameElement != null)
				Name = nameElement.Value;

			var useDepthBufferElement = xml.Attribute("depthBuf");
			var useDepthBuf = false;
			if (useDepthBufferElement != null && Boolean.TryParse(useDepthBufferElement.Value, out useDepthBuf))
				UseDepthBuffer = useDepthBuf;

			var numColorBuffersElement = xml.Attribute("numColBufs");
			var colBufs = 0;
			if (numColorBuffersElement != null && Int32.TryParse(numColorBuffersElement.Value, out colBufs))
				NumColorBuffers = colBufs;

			var formatElement = xml.Attribute("format");
			if (formatElement != null)
				PixelFormat = PixelFormatStringConverter.ConvertToPixelFormat(formatElement.Value);

			var widthElement = xml.Attribute("width");
			int width = 0;
			if (widthElement != null && Int32.TryParse(widthElement.Value, out width))
				Width = width;

			var heightElement = xml.Attribute("height");
			int height = 0;
			if (heightElement != null && Int32.TryParse(heightElement.Value, out height))
				Height = height;

			var scaleElement = xml.Attribute("scale");
			float scale = 0.0f;
			if (scaleElement != null && Single.TryParse(scaleElement.Value, out scale))
				Scale = scale;

			var maxSamplesElement = xml.Attribute("maxSamples");
			int maxSamples = 0;
			if (maxSamplesElement != null && Int32.TryParse(maxSamplesElement.Value, out maxSamples))
				MaxSamples = maxSamples;

		}

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
	}
}
