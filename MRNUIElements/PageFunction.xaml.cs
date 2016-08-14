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
    /// Interaction logic for PageFunction1.xaml
    /// </summary>
    public partial class PageFunction : PageFunction<String>
    {
        public PageFunction()
        {
            InitializeComponent();
        }
        static public PageFunction PF;

        public static PageFunction getInstance()
        {
            if (PF == null)
            {
                PF = new PageFunction();
            }

            return PF;
        }
        public void Navigate(object p)
        {
            Page o = new Page();
            if (p is Page)
                o = (Page)p;
			this.Navigate(o as Page);// NavigationService.Navigate(p as Page);

        }

    }
}
