using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Documents;
using System.Collections;

namespace Infrastructure.UserInterface.WinForms
{
	public class SortableBindingList<T> : BindingList<T>
	{
		public void AddRange(IEnumerable<T> collection)
		{
			collection.Foreach(item => base.Add(item));
			ApplySortCore(sortProperty, sortDirection);
		}

		public new void Add(T item)
		{
			base.Add(item);
			ApplySortCore(sortProperty, sortDirection);
		}

		protected override bool SupportsSortingCore
		{
			get { return true; }
		}

		private bool isSorted = false;
		protected override bool IsSortedCore
		{
			get { return isSorted; }
		}

		private ListSortDirection sortDirection;
		protected override ListSortDirection SortDirectionCore
		{
			get { return sortDirection; }
		}

		private PropertyDescriptor sortProperty;
		protected override PropertyDescriptor SortPropertyCore
		{
			get { return sortProperty; }
		}

		protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
		{
			isSorted = true;
			sortProperty = prop;
			sortDirection = direction;

			var list = (List<T>)Items;
			list.Sort((lhs, rhs) =>
			{
				if (sortProperty != null)
				{
					object lhsValue = lhs == null ? null : sortProperty.GetValue(lhs);
					object rhsValue = rhs == null ? null : sortProperty.GetValue(rhs);

					int result;

					if (lhsValue == null)
						result = -1;
					else if (rhsValue == null)
						result = 1;
					else
						result = Comparer.Default.Compare(lhsValue,	rhsValue);
					
					if (sortDirection == ListSortDirection.Descending)
						result = -result;

					return result;
				}
				else
					return 0;
			});
		}

		protected override void RemoveSortCore()
		{
			isSorted = false;
			sortDirection = ListSortDirection.Ascending;
			sortProperty = null;
		}
	}
}
