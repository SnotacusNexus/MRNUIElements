using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static MRNUIElements.MainWindow;
using MRNNexus_Model;
using MRNUIElements.Controllers;
using System.Threading;

namespace MRNUIElements
{

	

	/// <summary>
	/// Interaction logic for ClaimPickerPopUp.xaml
	/// </summary>
	public partial class ClaimPickerPopUp : Window
	{
       
		static ServiceLayer s1 = ServiceLayer.getInstance();
		public DTO_Claim Claim { get; set; }
		public DTO_Employee Creds { get; set; }
		public DTO_Employee currentLoggedInUser = s1.LoggedInEmployee;
        public static NavigationService ns = MainWindow.getNavigationService();
		protected ObservableCollection<DTO_Claim> colOfClaims = new ObservableCollection<DTO_Claim>();
		protected ObservableCollection<DTO_Employee> colOfEmployees = new ObservableCollection<DTO_Employee>();
        protected bool joy { get; set; }
		public ClaimPickerPopUp(bool joy=true)
		{
			InitializeComponent();
            this.joy = joy;
			//System.Windows.Forms.MessageBox.Show(currentLoggedInUser.ToString());
			try
			{
				Task.Run(async()=>await GetActiveClaims());

			}
			catch (Exception ex)
			{
				
				if(!string.IsNullOrEmpty(s1.LoggedInEmployee.ToString()))
				System.Windows.Forms.MessageBox.Show(s1.LoggedInEmployee.ToString());
				else
					System.Windows.Forms.MessageBox.Show("No Current Logged In Employee to find an active Claim For.");
				if(!string.IsNullOrEmpty(Claim.ClaimID.ToString()))
					System.Windows.Forms.MessageBox.Show(Claim.ClaimID.ToString());
				else
					System.Windows.Forms.MessageBox.Show("No Claim to Fetch on Init");

				System.Windows.Forms.MessageBox.Show(ex.ToString());

			}
			
		}

		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);
			Claim = (DTO_Claim)Application.Current.Properties["CurrentClaim"];
			currentLoggedInUser = (DTO_Employee)Application.Current.Properties["CurrentUser"];

		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			System.Windows.Data.CollectionViewSource dTO_ClaimViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("dTO_ClaimViewSource")));
			// Load data by setting the CollectionViewSource.Source property:
			// dTO_ClaimViewSource.Source = [generic data source]
			dTO_ClaimViewSource.Source = this.DataContext;
		}

		private async Task<bool> GetActiveClaims(bool joy=true)
		{	
			await s1.GetAllClaims();
            //if (s1.OpenClaimsList == null)

            //	await s1.GetAllEmployees();

            // if (Admin(emp))
            //{
            //	if (colOfClaims.Count > 0)
            //		colOfClaims.Clear();

            //	foreach (var c in s1.OpenClaimsList)
            //	{

            //		colOfClaims.Add(c);
            //	}
            //}
            int k = 0;
            while (s1.ClaimsList == null)
                k++;
            //ClaimListView.DataContext = s1.ClaimsList;

            if (s1.ClaimsList.Count > 0)
                ClaimListView.ItemsSource = s1.ClaimsList;
            else
                return false;
            return true;
		}
		private bool Admin(DTO_Employee emp)
		{
			
			return true;
		}

		private void SelectBtn_Click(object sender, RoutedEventArgs e)
		{
			Claim = (DTO_Claim)ClaimListView.SelectedItem;
			Application.Current.Properties["CurrentClaim"] = Claim;


			DialogResult = true;
			Close();
            if(!joy)
            if (ClaimListView.SelectedItem != null)
                ns.Navigate(new ClaimView(Claim));

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
		{

			DialogResult = false;
			Close();
		}

		private void AddBtn_Click(object sender, RoutedEventArgs e)
		{
			
		}
		private void toggleButton_Checked(object sender, RoutedEventArgs e)
		{

		}

        //private void NewClaimViewSelectBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    Claim = (DTO_Claim)ClaimListView.SelectedItem;
        //    Application.Current.Properties["CurrentClaim"] = Claim;


        //    DialogResult = true;
        //    Close();
        //    if (ClaimListView.SelectedItem != null)
        //        ns.Navigate(new ClaimView(Claim));
        //}

       async private void ClaimListView_GotFocus(object sender, RoutedEventArgs e)
        {
           
        }

       async private void ClaimListView_Initialized(object sender, EventArgs e)
        {
 await s1.GetAllClaims();
            ClaimListView.ItemsSource = s1.ClaimsList;
        }
    }
}
