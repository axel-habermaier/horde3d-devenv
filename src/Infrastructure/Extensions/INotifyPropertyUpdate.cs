using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Supplements the INotifyPropertyChanged and INotifyPropertyChanging interfaces. These interfaces
/// have events that are raised immediately before or after the value of a property has changed. However,
/// when handling such an event, it is not possible to get the previous or the current value of the property.
/// 
/// This interface has an event that is raised immediately after the value of a property has changed and
/// passes the previous and the current value to the event handlers.
/// </summary>
public interface INotifyPropertyUpdated
{
	/// <summary>
	/// Raised after a property has been updated.
	/// </summary>
	event PropertyUpdatedEventHandler PropertyUpdated;
}

/// <summary>
/// The delegate used by the PropertyUpdated event.
/// </summary>
/// <param name="sender">The source of the event.</param>
/// <param name="e">Additional information about the event.</param>
public delegate void PropertyUpdatedEventHandler(object sender, PropertyUpdatedEventArgs e);

/// <summary>
/// Contains additional information about the PropertyUpdated event.
/// </summary>
public class PropertyUpdatedEventArgs : EventArgs
{
	/// <summary>
	/// Gets the name of the property that was updated.
	/// </summary>
	public string PropertyName { get; private set;}

	/// <summary>
	/// Gets the value of the property before the update.
	/// </summary>
	public object PreviousValue { get; private set; }

	/// <summary>
	/// Gets the value of the property after the update.
	/// </summary>
	public object CurrentValue { get; private set; }

	/// <summary>
	/// Gets the property accessor.
	/// </summary>
	public IPropertyAccessor PropertyAccessor { get; private set; }

	/// <summary>
	/// Initializes a new instance.
	/// </summary>
	/// <param name="propertyName">The name of the property that was updated.</param>
	/// <param name="previousValue">The value of the property before the update.</param>
	/// <param name="currentValue">The value of the property after the update.</param>
	/// <param name="propertyAccessor">The property accessor.</param>
	public PropertyUpdatedEventArgs(string propertyName, object previousValue, object currentValue, IPropertyAccessor propertyAccessor)
	{
		PropertyName = propertyName;
		PreviousValue = previousValue;
		CurrentValue = currentValue;
		PropertyAccessor = propertyAccessor;
	}
}
