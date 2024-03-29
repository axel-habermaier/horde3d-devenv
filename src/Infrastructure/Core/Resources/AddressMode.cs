using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.Resources
{
	/// <summary>
	/// The address mode of a sampler.
	/// </summary>
	public enum AddressMode
	{
		Clamp,
		Wrap
	}

	public static class AddressModeStringConverter
	{
		public static string ConvertToString(AddressMode mode)
		{
			switch (mode)
			{
				default:
				case AddressMode.Wrap:
					return "WRAP";
				case AddressMode.Clamp:
					return "CLAMP";				
			}
		}

		public static AddressMode ConvertToAddressMode(string mode)
		{
			switch (mode.ToUpper())
			{
				case "WRAP":
				default:
					return AddressMode.Wrap;
				case "CLAMP":
					return AddressMode.Clamp;				
			}
		}
	}
}
