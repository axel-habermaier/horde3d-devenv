using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WpfClient.UserInterface.Converters
{
	public class ApplicationNameToWindowTitleValueConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value == null || String.IsNullOrEmpty(value.ToString()))
				return "Horde3D Debugger";

			return "Horde3D Debugger - " + value.ToString();	
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
