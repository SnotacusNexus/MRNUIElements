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
    /// Interaction logic for NewInspection.xaml
    /// </summary>
    public partial class NewInspection : Page
    {
        public NewInspection()
        {
            InitializeComponent();

            setUp();

            this.ridgeMaterialCbo.ItemsSource = ServiceLayer.getInstance().RidgeMaterialTypes;
            this.shingleTypeCbo.ItemsSource = ServiceLayer.getInstance().ShingleTypes;
        }

        async private void setUp()
        {
            Controllers.Inspection inspection = new Controllers.Inspection();
            await inspection.GetInsuranceCompanies();
            insuranceCompanyCbo.ItemsSource = ServiceLayer.getInstance().InsuranceCompaniesList;
        }
    }
}
