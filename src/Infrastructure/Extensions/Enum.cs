using System;

/// <summary>
/// This methods make converting strings, shorts, integers and other types to 
/// their enum representation easier.
/// </summary>
/// <typeparam name="T">Type of the enum the given input will be converted to.</typeparam>
public static class Enum<T>
{
	/// <summary>
	/// Tries to convert the given string to an enum instance. If the conversion fails, an exception is thrown.
	/// </summary>
	/// <param name="stringValue">The string to convert.</param>
	/// <returns>Returns the enum instance.</returns>
	public static T Parse(String stringValue)
	{
		return (T)Enum.Parse(typeof(T), stringValue);
	}

	/// <summary>
	/// Tries to convert the given string to an enum instance. If the conversion fails, null is returned.
	/// </summary>
	/// <param name="stringValue">The string to convert.</param>
	/// <returns>Returns the enum instance.</returns>
	public static T TryParse(String stringValue)
	{
		try { return (T)Enum.Parse(typeof(T), stringValue); }
		catch (Exception) { return default(T); }
	}

	/// <summary>
	/// Tries to convert the given value to an enum instance.
	/// </summary>
	/// <param name="value">The value to convert.</param>
	/// <returns>Returns the enum instance.</returns>
	public static T Cast(Object value)
	{
		return (T)Enum.ToObject(typeof(T), value);
	}
}
