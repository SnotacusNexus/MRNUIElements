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

namespace MRN_Claim_Services.Controllers
{
	/// <summary>
	/// Interaction logic for GetMeasurments.xaml
	/// </summary>
	public partial class GetMeasurments : PageFunction<Object>
	{
		public   MRNNexus_Model.DTO_Claim Claim { get; set; }
		public GetMeasurments()
		{


			//would like to autopoulate controls when available
			InitializeComponent();


		


		}

		private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void button_Copy_Click(object sender, RoutedEventArgs e)
		{

			//ok
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			//cancel
		}

		private void textBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
	}
}
