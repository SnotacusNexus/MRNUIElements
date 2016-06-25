using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Awesomium.Windows.Controls;

namespace MRNUIElements
{
    /// <summary>
    /// Interaction logic for RoofOrderPage.xaml
    /// </summary>
    public partial class RoofOrderPage : Page
    {
        public RoofOrderPage()
        {
            InitializeComponent();
			ProductionWebControl.Source= new Uri("https://weather.com/weather/tenday/l/30642:4:US");

		}

        private void LogOut(object sender, RoutedEventArgs e)
        {
            Login Page = new Login();
            this.NavigationService.Navigate(Page);
        }

		private void ProductionWebControl_MouseEnter(object sender, MouseEventArgs e)
		{
			ProductionWebControl.Width=MaxWidth;
			ProductionWebControl.Height = MaxHeight;
			
		}
	}
}
