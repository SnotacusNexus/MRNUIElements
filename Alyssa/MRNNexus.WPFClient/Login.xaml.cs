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
using MRNNexus.WPFClient.Controllers;

namespace MRNNexus.WPFClient
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        async private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            loginBtn.IsEnabled = false;
            Controllers.Login login = new Controllers.Login();

            await login.UserLogin(userNameBox, passwordBox);

            if (login.IsEmployeeLoggedIn)
            {
                var menuBar = ((MainWindow)Application.Current.MainWindow).menuBar.IsEnabled = true;
                Schedule homePage = new Schedule();
                this.NavigationService.Navigate(homePage);
            }
            else
            {
                
                loginBtn.IsEnabled = true;
                MessageBox.Show(ServiceLayer.getInstance().LoggedInEmployee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
