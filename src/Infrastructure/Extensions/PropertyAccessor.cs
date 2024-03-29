using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// An interface that allows access to a property without knowing its type or name.
/// </summary>
public interface IPropertyAccessor
{
	/// <summary>
	/// Sets the value of the property. The type of the given value must match the property's type.
	/// </summary>
	/// <param name="value">The new value that should be set.</param>
	void SetValue(object value);

	/// <summary>
	/// Gets the value of the property.
	/// </summary>
	/// <returns></returns>
	object GetValue();

	/// <summary>
	/// Gets a value that indicates whether the property accessor supports getting the property's value.
	/// </summary>
	bool SupportsGet { get; }

	/// <summary>
	/// Gets a value that indicates whether the property accessor supports setting the property's value.
	/// </summary>
	bool SupportsSet { get; }
}

/// <summary>
/// Allows access to a property without knowing its name.
/// </summary>
/// <typeparam name="TProperty">The type of the property.</typeparam>
public class PropertyAccessor<TProperty> : IPropertyAccessor
{
	/// <summary>
	/// A delegate that sets the property's value.
	/// </summary>
	Action<TProperty> setAccessor;

	/// <summary>
	/// A delegate that gets the property's value.
	/// </summary>
	Func<TProperty> getAccessor;

	/// <summary>
	/// Gets a value that indicates whether the property accessor supports getting the property's value.
	/// </summary>
	public bool SupportsGet 
	{
		get { return getAccessor != null; }
	}

	/// <summary>
	/// Gets a value that indicates whether the property accessor supports setting the property's value.
	/// </summary>
	public bool SupportsSet
	{
		get { return setAccessor != null; }
	}

	/// <summary>
	/// Initializes a new instance.
	/// </summary>
	/// <param name="setAccessor">A delegate that sets the property's value.</param>
	/// <param name="getAccessor">A delegate that gets the property's value.</param>
	public PropertyAccessor(Action<TProperty> setAccessor, Func<TProperty> getAccessor)
	{
		this.setAccessor = setAccessor;
		this.getAccessor = getAccessor;
	}

	/// <summary>
	/// Sets the value of the property. The type of the given value must match the property's type.
	/// </summary>
	/// <param name="value">The new value that should be set.</param>
	public void SetValue(object value)
	{
		if (!SupportsSet)
			throw new InvalidOperationException("This property accessor does not support setting the value of the property.");

		setAccessor((TProperty)value);
	}

	/// <summary>
	/// Gets the value of the property.
	/// </summary>
	/// <returns></returns>
	public object GetValue()
	{
		if (!SupportsGet)
			throw new InvalidOperationException("This property accessor does not support getting the value of the property.");

		return getAccessor();
	}
}

