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
	/// Interaction logic for AddClaimInspection.xaml
	/// </summary>
	public partial class AddClaimInspection
	{ static ServiceLayer s1 = ServiceLayer.getInstance();
		static MRNClaim MrnClaim;

		public AddClaimInspection(MRNClaim MrnClaim)
		{
			InitializeComponent();
			AddClaimInspection.MrnClaim = MrnClaim;
			this.DataContext = MrnClaim;
		}

		private void AddInspectPhotos_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new AddInspectionPhotos(MrnClaim));

		}

		private void AddInspectionMeasurements_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new AddInspectionMeasurments(MrnClaim));
		}

		private void ReqCashEst_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new ReqCashEst(MrnClaim));
		}

		private void Prevbutton_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}
	}
}
