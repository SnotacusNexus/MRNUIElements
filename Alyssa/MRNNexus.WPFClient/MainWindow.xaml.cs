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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            preprocessing();

            InitializeComponent();
            
        }

        async private void preprocessing()
        {
            ServiceLayer s1 = ServiceLayer.getInstance();
            await s1.buildLUs();

            bool doneLoading = false;

            while (!doneLoading)
            {
                if(s1.VendorTypes != null)
                {
                    doneLoading = true;
                    busyIndicator.IsBusy = false;
                    // moved to login.xaml.cs menuBar.IsEnabled = true;

                    Login loginpage = new Login();
                    this.MRNNexusMainFrame.NavigationService.Navigate(loginpage);
                }
            }
        }

        private void Inspections_Click(object sender, RoutedEventArgs e)
        {
            NewInspection inspectionspage = new NewInspection();
            this.MRNNexusMainFrame.NavigationService.Navigate(inspectionspage);
        }

        private void calendar_Click(object sender, RoutedEventArgs e)
        {
            Schedule inspectionspage = new Schedule();
            this.MRNNexusMainFrame.NavigationService.Navigate(inspectionspage);
        }
    }
}
