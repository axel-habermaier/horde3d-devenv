using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.Resources
{
	/// <summary>
	/// The blend mode used when blending.
	/// </summary>
	public enum BlendMode
	{
		Replace,
		Blend,
		Add,
		AddBlended,
		Mult
	}

	public static class BlendModeStringConverter
	{
		public static string ConvertToString(BlendMode mode)
		{
			switch (mode)
			{
				default:
				case BlendMode.Replace:
					return "REPLACE";
				case BlendMode.Mult:
					return "MULT";
				case BlendMode.Blend:
					return "BLEND";
				case BlendMode.AddBlended:
					return "ADD_BLENDED";
				case BlendMode.Add:
					return "ADD";					
			}
		}

		public static BlendMode ConvertToBlendMode(string mode)
		{
			switch (mode.ToUpper())
			{
				case "REPLACE":
				default:
					return BlendMode.Replace;
				case "MULT":
					return BlendMode.Mult;
				case "BLEND":
					return BlendMode.Blend;
				case "ADD_BLENDED":
					return BlendMode.AddBlended;
				case "ADD":
					return BlendMode.Add;
			}
		}
	}
}
