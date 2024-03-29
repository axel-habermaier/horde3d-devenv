using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Horde3DNET;
using Server.NativeInterop;
using System.ComponentModel;
using Infrastructure.Core.Server;

namespace Infrastructure.Core.Resources
{
	[DataContract]
	public abstract class EditableResource : Resource, INotifyPropertyChanged, INotifyPropertyUpdated
	{
		internal EditableResource(int resHandle)
			: base(resHandle)
		{

		}

		private string fileContent;
		/// <summary>
		/// Gets or sets the content of the resource's definition file.
		/// </summary>
		[DataMember]
		public string FileContent
		{
			get { return fileContent; }
			set
			{
				if (fileContent != value)
				{
					var previousValue = fileContent;
					fileContent = value;
					OnPropertyChanged("FileContent");
					OnPropertyUpdated("FileContent", previousValue, fileContent, new PropertyAccessor<string>(f => FileContent = f, () => FileContent));
				}
			}
		}

		/// <summary>
		/// Unloads the resource currently used by Horde3D and reloads it immediately.
		/// </summary>
		internal virtual void UpdateHorde3D()
		{
			UpdateHorde3D(null);
		}

		/// <summary>
		/// Unloads the resource currently used by Horde3D and reloads it immediately.
		/// </summary>
		/// <param name="beforeReloadAction">The action that is performed before reloading the resource.</param>
		protected void UpdateHorde3D(Action beforeReloadAction)
		{
			if (String.IsNullOrEmpty(FileContent))
				throw new InvalidOperationException("Resource data is empty.");

			var type = (Horde3D.ResourceTypes)Horde3D.getResourceType(ResHandle);

			if (type != ResourceType)
				throw new InvalidOperationException("The resource with res handle '" + ResHandle + "' does not have the correct type. Expected '" + ResourceType + "' but found '" + type + "' instead.");

			var name = Horde3D.getResourceName(ResHandle);

			if (name != Name)
				throw new InvalidOperationException("The resource with res handle '" + ResHandle + "' does not have the correct name. Expected '" + Name + "' but found '" + name + "' instead.");

			Horde3D.unloadResource(ResHandle);

			if (beforeReloadAction != null)
				beforeReloadAction();

			var data = ASCIIEncoding.ASCII.GetBytes(FileContent);
			Horde3D.loadResource(ResHandle, data, data.Length);
			Interop.LoadResourcesFromDisk(Horde3DDebugger.Instance.Configuration.ContentDirectory);
		}

		/// <summary>
		/// Loads the resource from Xml stored in the FileContent property.
		/// </summary>
		public abstract void LoadFromXml();

		/// <summary>
		/// Generates the Xml content and updates the FileContent property.
		/// </summary>
		public abstract void GenerateXml();

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
