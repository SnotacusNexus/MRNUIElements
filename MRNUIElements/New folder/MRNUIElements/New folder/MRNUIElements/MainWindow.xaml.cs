#region Using
using System;
using System.IO;
using System.Linq;
using System.Windows;
using Awesomium.Core;
using System.Diagnostics;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using Awesomium.Windows.Controls;
using System.Text;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
#endregion



namespace MRNUIElements
  
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		
		public MainWindow()
        {

			if (!WebCore.IsRunning)
				WebCore.Initialize(new WebConfig() { UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/50.0.2661.102 m Safari/537.11" });//23.0.1271.97
			InitializeComponent();
		   
		Login loginpage = new Login();
		
		this.MRNClaimNexusMainFrame.NavigationService.Navigate(loginpage);
        }

      
    }
}
