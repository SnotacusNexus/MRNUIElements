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

namespace MRNUIElements
{
    /// <summary>
    /// Interaction logic for ContestPage.xaml
    /// </summary>
    public partial class ContestPage : Page
    {
        public ContestPage()
        {
            InitializeComponent();
        }
        private void LogOut(object sender, RoutedEventArgs e)
        {
            Login Page = new Login();
            this.NavigationService.Navigate(Page);
        }
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			tab1.Visibility = Visibility.Collapsed;
			tab2.Visibility = Visibility.Collapsed;
			tab3.Visibility = Visibility.Collapsed;
			var tab = (sender as Button).Tag as TabControl;
			if (null != tab) tab.Visibility = Visibility.Visible;
		}
	}
}
