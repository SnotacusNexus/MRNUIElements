using MRNNexus_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
	/// Interaction logic for SalespersonSelectionPage.xaml
	/// </summary>
	public partial class SalespersonSelectionPage : PageFunction<object>
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
		DTO_Employee emp = new DTO_Employee();

		public SalespersonSelectionPage()
		{
			InitializeComponent();

			if (s1.EmployeesList != null)
				s1.GetAllEmployees();

			while (s1.EmployeesList==null)
				Thread.Sleep(1);
			
				this.SalespersoncomboBox.ItemsSource = s1.EmployeesList;

		}

		private void AddEmployeebutton_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new AddEditEmployee());

		}

		private void SalespersoncomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			
		}

		private void Select_button_Click(object sender, RoutedEventArgs e)
		{
			//return the employee object in combo box
			//Create instance of ReturnEventArgs to pass data back to caller page
			ReturnEventArgs<object> returnObject = new ReturnEventArgs<object>((object)emp);

			//Call to PageFunction's OnReturn method and pass selected List 
			//This will be handled by apage_Return on HomePage.xaml
			OnReturn(returnObject);
		}
	}
}
