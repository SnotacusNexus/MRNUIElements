using MRNNexus_Model;
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
	/// Interaction logic for AddEditEmployee.xaml
	/// </summary>
	public partial class AddEditEmployee : PageFunction<Object>
	{
		DTO_Employee emp = new DTO_Employee();
		public AddEditEmployee()
		{
			InitializeComponent();
		}

		private void Select_button_Click(object sender, RoutedEventArgs e)
		{
			//Return to Calling Page
			//Create instance of ReturnEventArgs to pass data back to caller page
			ReturnEventArgs<object> returnObject = new ReturnEventArgs<object>((object)SalespersoncomboBox.SelectedItem);

			//Call to PageFunction's OnReturn method and pass selected List 
			//This will be handled by apage_Return on HomePage.xaml
			OnReturn(returnObject);
		}

		private void AddEmployeeDetailsbutton_Click(object sender, RoutedEventArgs e)
		{
			//
			//	NavigationService.Navigate(AddEmployeeDetails());
			//Add the object and return the object to requestor for use
			
		}

		private void Sign3_Copy_Loaded(object sender, RoutedEventArgs e)
		{

		}
	}
}
