using System;

/// <summary>
/// Base class for all classes implementing the Singleton design pattern.
/// </summary>
/// <typeparam name="T">The type of the singleton class.</typeparam>
public class Singleton<T>
{
	/// <summary>
	/// Gets the singleton instance.
	/// </summary>
	public static T Instance { get; protected set; }

	/// <summary>
	/// Creates the singleton instance. A static constructor is called only once during the 
	/// lifetime of an AppDomain and is guaranteed to be thread-safe.
	/// </summary>
	static Singleton()
	{
		Instance = Activator.CreateInstance<T>();
	}

	/// <summary>
	/// Constructs a new instance.
	/// </summary>
	protected Singleton()
	{

	}
}
