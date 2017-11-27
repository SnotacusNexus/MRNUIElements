#region Using
using System;
using System.IO;
using System.Linq;
using System.Windows;
//using Awesomium.Core;
using System.Diagnostics;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
//using Awesomium.Windows.Controls;
using System.Text;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using MRNUIElements.Controllers;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using MRNUIElements.ViewModels;
using MRNUIElements.ViewModels.Commands;
using MRNUIElements.Models;
using MRNNexus_Model;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System.Threading;






#endregion



namespace MRNUIElements

{

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static ServiceLayer s1 = ServiceLayer.getInstance();
		static NavigationService ns;
        static MainWindow mw;
		static DTO_Claim claim { get; set; }
		public static Syncfusion.Windows.Controls.Notification.SfBusyIndicator _busyindicator;
		static public string Status = "Loading...!!!";
		static public bool DoneLoading;
	//	public static Syncfusion.Windows.Controls.Notification.SfBusyIndicator busyindicator { get; set; }

	
		public MainWindow()
		{
		
		
			preprocessing();

			InitializeComponent();
			//Binding exitBinding = new Binding();
			//exitBinding.Path = new PropertyPath("Exit");
			//exitBinding.Mode = BindingMode.TwoWay;
			//SetBinding(ExitProperty, exitBinding);
			//Binding ZoomInBinding = new Binding();
			//ZoomInBinding.Path = new PropertyPath("ZoomIn");
			//SetBinding(ZoomInProperty, ZoomInBinding);
			//Binding ZoomOutBinding = new Binding();
			//ZoomOutBinding.Path = new PropertyPath("ZoomOut");
			//SetBinding(ZoomOutProperty, ZoomOutBinding);
			//Exit = new Command(OnExitCommand);
			//ZoomIn = new Command(OnZoomInCommand);
			//ZoomOut = new Command(OnZoomOutCommand);
			_busyindicator = getBusyIndicator();
			Application.Current.Properties["NavigationService"] = this.MRNClaimNexusMainFrame.NavigationService;
			//	WebCore.Initialize(new WebConfig() { UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/50.0.2661.102 m Safari/537.11" });//23.0.1271.97
			ns = this.MRNClaimNexusMainFrame.NavigationService;

		}
        static public MainWindow getMainWindowInstance()
        {
            if (mw == null)
                mw = new MainWindow();

            return mw;
        }

		static public DTO_Claim Claim
		{
			get
			{
				return claim;
			}
			set { }

		}
		static public void GetBusy(bool busy=true)
		{

			if (busy)
			{
				if (!_busyindicator.IsVisible)
					_busyindicator.Visibility = Visibility.Visible;
				_busyindicator.IsBusy = true;
			}
			else { if (_busyindicator.IsVisible)
					_busyindicator.Visibility = Visibility.Collapsed;
				_busyindicator.IsBusy = false;
			}


		}
		async private void preprocessing()
		{

			await s1.buildLUs();

			bool DoneLoading = false;

			while (!DoneLoading)
			{

				//if (s1.VendorsList != null)
				//{
					
					//	await Task.Run(async()=> await Task.Delay(500));
					//	doneLoading = true;
					DoneLoading = ServiceLayer.DoneLoading;
					//	busyIndicator.IsBusy = true;
					
					// moved to login.xaml.cs menuBar.IsEnabled = true;
					//	if (s1.InvoicesList != null)
					//	System.Windows.Forms.MessageBox.Show("Invoices Loaded");
					//	if (s1.VendorsList != null)
					//		System.Windows.Forms.MessageBox.Show("Vendors Loaded");
				//}
			}
				busyIndicator.IsBusy = false;
            VerboseStatusDisplay.Visibility = Visibility.Collapsed;
				Login loginpage = new Login();
					

					this.MRNClaimNexusMainFrame.NavigationService.Navigate(loginpage);
				
			
		}
		public static Syncfusion.Windows.Controls.Notification.SfBusyIndicator getBusyIndicator()
		{
			if (_busyindicator == null)
				_busyindicator = new Syncfusion.Windows.Controls.Notification.SfBusyIndicator();
			return _busyindicator;
		}

		public static NavigationService getNavigationService()
		{
			
			return ns;
		}

		private void Inspections_Click(object sender, RoutedEventArgs e)
		{
			//CustomerAgreement inspectionspage = new CustomerAgreement();
			//this.MRNClaimNexusMainFrame.NavigationService.Navigate(inspectionspage);
		}

        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            ns.Navigate(new LoginAs());
            //CustomerAgreement inspectionspage = new CustomerAgreement();
            //this.MRNClaimNexusMainFrame.NavigationService.Navigate(inspectionspage);
        }


        private void calendar_Click(object sender, RoutedEventArgs e)
		{
		//	Schedule inspectionspage = new Schedule();
		//	this.MRNClaimNexusMainFrame.NavigationService.Navigate(inspectionspage);
		}

		async private void Claim_Click(object sender, RoutedEventArgs e)
		{


            ns.Navigate(new AddPropertyAddress());
        }

        public bool UpdateStatusBarText(string textToDisplay)
        {

            VerboseStatusDisplay.Items.Add(textToDisplay);

            return true;
        }
      

        private void ModifyClaim_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CPD = new ClaimPickerPopUp();
                if ((bool)CPD.ShowDialog())

                    //	var claim = s1.ClaimsList.Single(x => x.ClaimID == 37);
                    ns.Navigate(new Controllers.ClaimView(CPD.Claim));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void Add_Invoice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Payment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveClaim_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Inspection_Click(object sender, RoutedEventArgs e)
        {
            var f = new Form1();
            f.ShowDialog();

            //ns.Navigate(new Form1());
        }

        private void Adjustment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Contests_Click(object sender, RoutedEventArgs e)
        {
            ns.Navigate(new Controllers.WebBrowser());
          
        }

        private void AddCycle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ThisCycle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextCycle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ScheduleRoof_Click(object sender, RoutedEventArgs e)
        {
            ns.Navigate(new RoofMeasurmentsPage());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void View_Console_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Generate_Supplement_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Settle_Claim_Click(object sender, RoutedEventArgs e)
        {

        }

        private void View_Order_Console_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Material_Adjustment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Inspection_Photos_Click(object sender, RoutedEventArgs e)
        {
            var f2 = new Form2();
            f2.ShowDialog();
        }
    }
}

