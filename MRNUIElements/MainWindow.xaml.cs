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





#endregion



namespace MRNUIElements

{

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();

		static public Syncfusion.Windows.Controls.Notification.SfBusyIndicator _busyindicator;
		public Syncfusion.Windows.Controls.Notification.SfBusyIndicator busyindicator { get; set; }

		static public DTO_Claim Claim { get; set; }
		public MainWindow()
		{
			_busyindicator = this.busyIndicator;

			//	WebCore.Initialize(new WebConfig() { UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/50.0.2661.102 m Safari/537.11" });//23.0.1271.97

			preprocessing();

			InitializeComponent();
           
        }

		async private void preprocessing()
		{
		
			await s1.buildLUs();
         
			bool doneLoading = false;

			while (!doneLoading)
			{
				if (s1.VendorTypes != null)
				{
					doneLoading = true;
					
					busyIndicator.IsBusy = false;
					// moved to login.xaml.cs menuBar.IsEnabled = true;

					Login loginpage = new Login();


					this.MRNClaimNexusMainFrame.NavigationService.Navigate(loginpage);
				}
			}
		}

		private void Inspections_Click(object sender, RoutedEventArgs e)
		{
			CustomerAgreement inspectionspage = new CustomerAgreement();
			this.MRNClaimNexusMainFrame.NavigationService.Navigate(inspectionspage);
		}

		private void calendar_Click(object sender, RoutedEventArgs e)
		{
			Schedule inspectionspage = new Schedule();
			this.MRNClaimNexusMainFrame.NavigationService.Navigate(inspectionspage);
		}

		async private void Claim_Click(object sender, RoutedEventArgs e)
		{

			string str;
			try
			{
				if (Claim == null)
					System.Windows.Forms.MessageBox.Show("No Claim Currently Selected into Memory");
			
					await s1.GetClaimByClaimID(Claim);
					if (string.IsNullOrEmpty(Claim.InsuranceClaimNumber))
						str = "No Insurance Company Claim Number Associated";
					else str = Claim.InsuranceClaimNumber;
					System.Windows.Forms.MessageBox.Show(Claim.MRNNumber.ToString()+" Is Selected AKA "+ str );
				

			}
			catch (Exception)
			{
				try
				{
					
						await s1.GetAllOpenClaims();
				}
				catch (Exception)
				{
					try
					{
						await s1.GetAllClaims();
					}
					catch (Exception)
					{

						throw;
					}

					MRNClaimNexusMainFrame.NavigationService.Navigate(new NexusHome());
				}
				
				
			}
			finally
			{
				
				
				MRNClaimNexusMainFrame.NavigationService.Navigate(new NexusHome());
			}
			
		}
	}
}

	 