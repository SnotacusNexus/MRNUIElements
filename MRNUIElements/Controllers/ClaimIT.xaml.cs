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
	/// Interaction logic for ClaimIT.xaml
	/// </summary>
	public partial class ClaimIT : Page
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
		static MRNClaim MrnClaim;
		public ClaimIT(MRNClaim MrnClaim)
		{
			InitializeComponent();
			ClaimIT.MrnClaim = MrnClaim;
		}

		private void Prevbutton_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}

		private void InspectionButton_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new AddClaimInspection(MrnClaim));
		}

		private void ClaimItbutton_Copy_Click(object sender, RoutedEventArgs e)
		{
			//NavigationService.Navigate(//This should point to ScheduleAdjustment)
		}
	}
}
