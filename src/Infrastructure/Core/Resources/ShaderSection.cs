using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Infrastructure.Core.Resources
{
	public class ShaderSection : INotifyPropertyChanged, INotifyPropertyUpdated
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

		private string code;
		/// <summary>
		/// Gets or sets the code.
		/// </summary>
		public string Code
		{
			get { return code; }
			set
			{
				if (code != value)
				{
					var previousValue = code;
					code = value;
					OnPropertyChanged("Code");
					OnPropertyUpdated("Code", previousValue, code,
						new PropertyAccessor<string>(propertyValue => Code = propertyValue, () => Code));
				}
			}
		}

		/// <summary>
		/// Gets the shader resource this shader section belongs to.
		/// </summary>
		public ShaderResource Shader { get; private set; }
		#endregion

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		/// <param name="shader">The shader resource this shader section belongs to.</param>
		public ShaderSection(ShaderResource shader)
		{
			if (shader == null)
				throw new ArgumentNullException("shader");

			Shader = shader;
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
