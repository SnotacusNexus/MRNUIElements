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


namespace MRNUIElements.Controllers
{
    /// <summary>
    /// Interaction logic for WebBrowser.xaml
    /// </summary>
    public partial class WebBrowser : Page
    {
        public WebBrowser()
        {
            InitializeComponent();
          
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            MainBrowser7.WebView.Url = @"chrome - extension://hehijbfgiekmjfkfjpbkbammjbdenadd/nhc.htm#url=https://xactimate.com/xo/#/Login";

            MainBrowser7.WebView.CustomUserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.62 Safari/537.36";
           // this.MainBrowser = new EO.WebBrowser.Wpf.WebControl();
            this.MainBrowser2.WebView.LoadUrl("http://gmail.com");
            this.MainBrowser1.WebView.LoadUrl("file://c:\\");
            this.MainBrowser3.WebView.LoadUrl("http://www.dropbox.com");
            this.MainBrowser4.WebView.LoadUrl("http://drive.google.com");
            this.MainBrowser5.WebView.LoadUrl("file://%USERPROFILE%\\");
            this.MainBrowser6.WebView.LoadUrl("http://suntrust.com/");
        //    https://chrome.google.com/webstore/detail/ie-tab/hehijbfgiekmjfkfjpbkbammjbdenadd/nbc.htm#url=https://xactimate.com/xo/#/Login"
            this.MainBrowser7.WebView.LoadUrl(@"chrome-extension://hehijbfgiekmjfkfjpbkbammjbdenadd/nhc.htm#url=https://xactimate.com/xo/");
            this.MainBrowser8.WebView.LoadUrl("http://www.google.com");
        }
    }
}
