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
using MRNNexus_Model;
using MRNUIElements.Controllers;
using MRNUIElements.Models;
using MRNUIElements;

namespace MRNUIElements
{
    /// <summary>
    /// Interaction logic for PlanePopulationPage.xaml
    /// </summary>
    public partial class PlanePopulationPage : Page
    {
		MRNUIElements.Controllers.ServiceLayer s1 = ServiceLayer.getInstance();
		public DTO_Employee CurrentLoggedInEmployee { get; set; }
		public DTO_Claim CurrentClaim { get; set; }

		public PlanePopulationPage()
        {

            InitializeComponent();

			DTO_Employee ce = new DTO_Employee();
				if(CurrentLoggedInEmployee!=null)
					ce = CurrentLoggedInEmployee;
				if (s1.LoggedInEmployee != null)
					CurrentLoggedInEmployee = s1.LoggedInEmployee;
				if (ce!=CurrentLoggedInEmployee)
				//Send to get verified creds.
				System.Windows.Forms.MessageBox.Show("We would normally make you login now to verify your creds because at this time ");
			//TODO  Open Login Window
			
			if (true)  //TODO check here to allow only certain users to view certain things
			{
				this.DataContext = this;
				if (s1.ClaimsList != null)
					PlanePopComboBox.ItemsSource = s1.ClaimsList;
				if (this.CurrentClaim == null && ServiceLayer.CurrentClaim != null)
					this.CurrentClaim = ServiceLayer.CurrentClaim;
				else
					GetClaims(CurrentLoggedInEmployee);
			}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ManualEntry
            NavigationService.Navigate(new PlaneEntryPage((DTO_Claim)PlanePopComboBox.SelectedItem));
        }

        private void PlanePopulateExteriorSourceClick(object sender, RoutedEventArgs e)
        {
            //Eagleview
            this.NavigationService.Navigate(new RoofMeasurmentsPage((DTO_Claim)PlanePopComboBox.SelectedItem));
        }

        private void PlanePopulateInteriorSourceClick(object sender, RoutedEventArgs e)
        {
				  //TODO Create point to manual entry page
        }
		protected async void GetClaims(DTO_Employee emp) {
			try
			{
				if (CurrentLoggedInEmployee.EmployeeTypeID < 13)
					await s1.GetAllOpenClaims();
				else
				await s1.GetOpenClaimsBySalespersonID(emp);
				while (s1.OpenClaimsList == null)
					await Task.Delay(10);
				//TODO add Code for busy indicator
					PlanePopComboBox.ItemsSource = s1.OpenClaimsList;

			}
			catch (Exception ex)
			{
				if (MessageBox.Show("No open claims for this employee. Searching All Claims Now.", "No Claims Returned", MessageBoxButton.OK, MessageBoxImage.Hand,MessageBoxResult.OK) == MessageBoxResult.OK)	
				System.Windows.MessageBox.Show(ex.ToString());

					try
					{
					s1.ClaimsList.Clear();
					await s1.GetAllClaims();

					PlanePopComboBox.ItemsSource =s1.ClaimsList;
					}
					catch (Exception Ex)
					{
					System.Windows.MessageBox.Show("No Claims to be found. Now returning to where you came from.  The Error Code is "+Ex.ToString());
					this.NavigationService.GoBack();


					}


			}
		}



		private void PlanePopComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)

		{
			try
			{
				this.NavigationService.Navigate(new RoofMeasurmentsPage((DTO_Claim)PlanePopComboBox.SelectedItem));
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
				throw;
			}
			
			//MRNUIElements.NexusHome._frame.Navigate(new RoofMeasurmentsPage((DTO_Claim)PlanePopComboBox.SelectedItem));

		}
	}
}
