#region Using
using System;
using System.IO;
using System.Linq;
using System.Windows;
//using Awesomium.Core;
using System.Diagnostics;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
//using Awesomium.Windows.Controls;
using System.Collections.ObjectModel;

using System.Text;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using Jarloo.Calendar;
using MRNNexus_Model;

//using Awesomium.Core.Data;

#endregion




namespace MRNUIElements
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
	{
	 
	
	public class RedLetterDayConverter : IValueConverter
	{
		static Dictionary<DateTime, string> dict = new Dictionary<DateTime, string>(); static RedLetterDayConverter() { dict.Add(new DateTime(2009, 3, 17), "St. Patrick's Day"); dict.Add(new DateTime(2009, 3, 20), "First day of spring"); dict.Add(new DateTime(2009, 4, 1), "April Fools"); dict.Add(new DateTime(2009, 4, 22), "Earth Day"); dict.Add(new DateTime(2009, 5, 1), "May Day"); dict.Add(new DateTime(2009, 5, 10), "Mother's Day"); dict.Add(new DateTime(2009, 6, 21), "First Day of Summer"); }
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string text; if (!dict.TryGetValue((DateTime)value, out text)) text = null; return text;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
}

