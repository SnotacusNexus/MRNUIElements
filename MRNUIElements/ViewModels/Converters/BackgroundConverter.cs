using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Printing.Interop;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;
using System.Windows;

namespace MRNUIElements.ViewModels.Converters
{
	public class BackgroundConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value.ToString() != null)
				if (decimal.Parse(value.ToString()) < 1000)
					return new SolidColorBrush(Colors.Pink);
			if (decimal.Parse(value.ToString()) < 5000)
				return new SolidColorBrush(Colors.LightGreen);
			return new SolidColorBrush(Colors.Yellow);

		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
	public class NumberSign : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
				if ((double)value < 0)
					return Brushes.Red.ToString();
			if ((double)value > 0)
				return Brushes.Green.ToString();
			return Brushes.Black.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
	[ValueConversion(typeof(double), typeof(Duration))]
	public class DoubleToDurationConverter : IValueConverter
	{
		#region IValueConverter Members
		public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
		{
			double seconds = (Double)value;
			return new Duration(TimeSpan.FromSeconds(seconds));
		}
		/// <summary>
		/// This method does nothing.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="targetType"></param>
		/// <param name="parameter"></param>
		/// <param name="culture"></param>
		/// <returns></returns>
		public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
		{
			throw new Exception("The method or operation is not implemented.");
		}
		#endregion
	}
}
