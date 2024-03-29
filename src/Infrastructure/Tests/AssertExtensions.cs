using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	public static class AssertExtensions
	{
		/// <summary>
		/// Verifies that there is only one element that satisfies the predicate.
		/// </summary>
		/// <typeparam name="T">The type of the list items.</typeparam>
		/// <param name="list">The list that should satisfy the predicate.</param>
		/// <param name="predicate">The predicate that must be satisfied.</param>
		/// <param name="message">The error message to display if the test failed.</param>
		public static void SingleListElementSatisfies<T>(IEnumerable<T> list, Func<T, bool> predicate, string message)
		{
			Assert.IsNotNull(list.Where(predicate).SingleOrDefault(), message);
		}

		/// <summary>
		/// Verifies that all elements of the list satisfy the predicate.
		/// </summary>
		/// <typeparam name="T">The type of the list items.</typeparam>
		/// <param name="list">The list that should satisfy the predicate.</param>
		/// <param name="predicate">The predicate that must be satisfied.</param>
		/// <param name="identifier">Gets an identifier for a list element. Used when printing the fail message.</param>
		/// <param name="message">The error message to display if the test failed.</param>
		public static void ListSatisfies<T>(IEnumerable<T> list, Func<T, bool> predicate, Func<T, string> identifier, string message)
		{
			list.Foreach(element => Assert.IsTrue(predicate(element), identifier(element) + ": " + message));
		}
	}
}
