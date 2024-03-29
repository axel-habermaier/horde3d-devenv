using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.Resources
{
	/// <summary>
	/// Describes a pixel format.
	/// </summary>
	public enum PixelFormat
	{
		RGBA8,
		RGBA16F,
		RGBA32F
	}

	public static class PixelFormatStringConverter
	{
		public static string ConvertToString(PixelFormat format)
		{
			switch (format)
			{
				default:
				case PixelFormat.RGBA8:
					return "RGBA8";
				case PixelFormat.RGBA16F:
					return "RGBA16F";
				case PixelFormat.RGBA32F:
					return "RGBA32F";
			}
		}

		public static PixelFormat ConvertToPixelFormat(string format)
		{
			switch (format.ToUpper())
			{
				case "RGBA8":
				default:
					return PixelFormat.RGBA8;
				case "RGBA16F":
					return PixelFormat.RGBA16F;
				case "RGBA32F":
					return PixelFormat.RGBA32F;
			}
		}
	}
}
