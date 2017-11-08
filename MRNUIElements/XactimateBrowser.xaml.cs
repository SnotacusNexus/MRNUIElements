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
using System.Windows.Shapes;

namespace MRNUIElements
{
    /// <summary>
    /// Interaction logic for XactimateBrowser.xaml
    /// </summary>
    public partial class XactimateBrowser : Page
    {
        public XactimateBrowser()
        {
             InitializeComponent();
                XactimateView.Navigate("https://xactimate.com/xo");
            }

            private void txtUrl_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Enter)
                    XactimateView.Navigate(txtUrl.Text);
            }

            private void XactimateView_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
            {
                txtUrl.Text = e.Uri.OriginalString;
            }

            private void BrowseBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute = ((XactimateView != null) && (XactimateView.CanGoBack));
            }

            private void BrowseBack_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                XactimateView.GoBack();
            }

            private void BrowseForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute = ((XactimateView != null) && (XactimateView.CanGoForward));
            }

            private void BrowseForward_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                XactimateView.GoForward();
            }

            private void GoToPage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute = true;
            }

            private void GoToPage_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                XactimateView.Navigate(txtUrl.Text);
            }

        }
    }
