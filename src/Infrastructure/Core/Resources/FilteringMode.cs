using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.Resources
{
	/// <summary>
	/// The filtering mode used by a sampler.
	/// </summary>
	public enum FilteringMode
	{
		None,
		Bilinear,
		Trilinear
	}

	public static class FilteringModeStringConverter
	{
		public static string ConvertToString(FilteringMode mode)
		{
			switch (mode)
			{
				default:
				case FilteringMode.Trilinear:
					return "TRILINEAR";
				case FilteringMode.Bilinear:
					return "BILINEAR";
				case FilteringMode.None:
					return "NONE";
			}
		}

		public static FilteringMode ConvertToFilteringMode(string mode)
		{
			switch (mode.ToUpper())
			{
				case "TRILINEAR":
				default:
					return FilteringMode.Trilinear;
				case "BILINEAR":
					return FilteringMode.Bilinear;
				case "NONE":
					return FilteringMode.None;
			}
		}
	}
}
