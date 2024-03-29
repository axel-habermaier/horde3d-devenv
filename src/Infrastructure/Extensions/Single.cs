using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Single extension methods for various classes.
/// </summary>
public static class SingleExtension
{
	/// <summary>
	/// Calls func for the first element of source. If there is no such element or if there are
	/// more elements in source, func is not called and this method silently returns.
	/// </summary>
	/// <typeparam name="T">Type of the objects.</typeparam>
	/// <param name="source">The source collection.</param>
	/// <param name="func">The method to call.</param>
	public static void Single<T>(this IEnumerable<T> source, Action<T> func)
	{
		if (source == null)
			return;

		T element = source.SingleOrDefault();

		if (element != null)
			func(element);
	}

	/// <summary>
	/// Calls func for the first element of source. If there is no such element or if there are
	/// more elements in source, func is not called and this method silently returns.
	/// </summary>
	/// <typeparam name="T">Type of the objects.</typeparam>
	/// <param name="source">The source collection.</param>
	/// <param name="func">The method to call.</param>
	public static void Single<T>(this IQueryable<T> source, Action<T> func)
	{
		if (source == null)
			return;

		T element = source.SingleOrDefault();

		if (element != null)
			func(element);
	}

	/// <summary>
	/// Calls func for the first element's value of source. If there is no such element or if there are
	/// more elements in source, func is not called and this method silently returns.
	/// </summary>
	/// <typeparam name="T">Type of the keys.</typeparam>
	/// <typeparam name="U">Type of the objects.</typeparam>
	/// <param name="source">The source collection.</param>
	/// <param name="func">The method to call.</param>
	public static void Single<T, U>(this IDictionary<T, U> source, Action<U> func)
	{
		if (source == null)
			return;

		U element = source.SingleOrDefault().Value;

		if (element != null)
			func(element);
	}
}
