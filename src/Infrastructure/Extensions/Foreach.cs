using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Foreach extension methods for various classes.
/// </summary>
public static class ForeachExtensions
{
	/// <summary>
	/// Calls func for each element of source.
	/// </summary>
	/// <typeparam name="T">Type of the objects.</typeparam>
	/// <param name="source">The source collection.</param>
	/// <param name="func">The method to call.</param>
	public static void Foreach<T>(this IEnumerable<T> source, Action<T> func)
	{
		if (source == null)
			return;

		foreach (var item in source)
			func(item);
	}

	/// <summary>
	/// Calls func for each element of source.
	/// </summary>
	/// <typeparam name="T">Type of the objects.</typeparam>
	/// <param name="source">The source collection.</param>
	/// <param name="func">The method to call.</param>
	public static void Foreach<T>(this IQueryable<T> source, Action<T> func)
	{
		if (source == null)
			return;

		foreach (var item in source)
			func(item);
	}

	/// <summary>
	/// Calls func for each element of source.
	/// </summary>
	/// <typeparam name="T">Type of the keys.</typeparam>
	/// <typeparam name="U">Type of the objects.</typeparam>
	/// <param name="source">The source collection.</param>
	/// <param name="func">The method to call.</param>
	public static void Foreach<T, U>(this IDictionary<T, U> source, Action<U> func)
	{
		if (source == null)
			return;

		foreach (var item in source)
			func(item.Value);
	}
}
