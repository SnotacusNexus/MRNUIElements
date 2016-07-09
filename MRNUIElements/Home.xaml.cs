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
using System.Globalization;
using MRNNexus_Model;
using Awesomium.Windows.Controls;
using Awesomium.Core.Data;
using Awesomium.Core;
using Syncfusion.Windows.Controls.Schedule;
using Syncfusion.UI.Xaml.Grid;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace MRNUIElements
{

	/// <summary>
	/// Interaction logic for CustomGroupControl.xaml
	/// </summary>
	public partial class NexusHome : Page
	{
		
		
		

		
		List<DTO_CalendarData> cd = new List<DTO_CalendarData>();
		private string FinishedName;
		ServiceLayer s1 = ServiceLayer.getInstance();
		DTO_CalendarData caldata;
		bool b = false;
		public NexusHome()
		{

			InitializeComponent();


			GetLeadsByEmployeeAsSalepersonID(s1.LoggedInEmployee.EmployeeID);
		}





		private void LogOut(object sender, RoutedEventArgs e)
		{
			Login Page = new Login();
			this.NavigationService.Navigate(Page);
		}



		async private void GetLeadsByEmployeeAsSalepersonID(int iemployeeID)
		{





			//await s1.GetLeadsBySalesPersonID(s1.LoggedInEmployee);
			await s1.GetCalendarDataByEmployeeID(s1.LoggedInEmployee);

			foreach (DTO_CalendarData c in s1.CalendarDataList)
			{
				c.AppointmentText = ConvertLookUpToString(c.AppointmentTypeID);
			}

			foreach (DTO_CalendarData d in s1.CalendarDataList)
			{
				if ((int?)d.LeadID != null)
				{
					cd.Add(d);

				}

			}
			MRNCalendar cal = new MRNCalendar(cd);

			//	this.dTO_LeadDataGrid.ItemsSource = s1.LeadsList;
			this.dTO_CalendarDataDataGrid.ItemsSource = cd;


		}

		private string ConvertLookUpToString(int i)
		{
			foreach (DTO_LU_AppointmentTypes ap in s1.AppointmentTypes)
			{
				if (i == ap.AppointmentTypeID)
					return ap.AppointmentType;
			}
			return "No appointment type found for that ID";
		}





		private void dTO_CalendarDataDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (dTO_CalendarDataDataGrid.SelectedIndex > -1)
			{
				DTO_CalendarData a = (DTO_CalendarData)dTO_CalendarDataDataGrid.SelectedItem;
				int b = (int)a.LeadID;
				GetCustomerDetailsByLeadID(b);

				//	GetCustomerDetailsByLeadID((DTO_Lead)dTO_CalendarDataDataGrid.SelectedItem);
			}
			else
			{
				//	MessageBox.Show("Invalid Selection");
				return;
			}

		}





		async private void GetCustomerDetailsByLeadID(int leadID)
		{
			DTO_Lead ld = new DTO_Lead();
			DTO_Customer cu = new DTO_Customer();
			DTO_Address ad = new DTO_Address();
			ld.LeadID = leadID;
			await s1.GetLeadByLeadID(ld);
			ld = s1.Lead;
			ad.AddressID = ld.AddressID;
			cu.CustomerID = ld.CustomerID;
			await s1.GetCustomerByID(cu);
			await s1.GetAddressByID(ad);
			cu = s1.Cust;
			ad = s1.Address1;
			FinishedName = "";
			if (cu.FirstName != string.Empty)
				FinishedName += cu.FirstName + " ";

			if (cu.MiddleName != string.Empty)
				FinishedName += cu.MiddleName + " ";

			if (cu.LastName != string.Empty)
				FinishedName += cu.LastName + " ";

			if (cu.Suffix != string.Empty)
				FinishedName += cu.Suffix;

			if (cu.PrimaryNumber != string.Empty)
				leadPriPhoneText.Text = cu.PrimaryNumber;

			if (cu.SecondaryNumber != string.Empty)
				leadSecPhoneText.Text = cu.SecondaryNumber;

			if (cu.Email != string.Empty)
				leadEmailAddressText.Text = cu.Email;

			//MessageBox.Show(FinishedName);
			leadNameText.Text = FinishedName;

			AddressZipcodeValidation citystatefromzip = new AddressZipcodeValidation();
			string citystate  =  citystatefromzip.CityStateLookupRequest(ad.Zip);

			string city = citystate.Substring(citystate.IndexOf("<City>") + 6, citystate.IndexOf("</City>") - citystate.IndexOf("<City>")-6);
			
			string state = AddressZipcodeValidation.ConvertStateToAbbreviation(citystate.Substring(citystate.IndexOf("<State>") + 7, citystate.IndexOf("</State>") - citystate.IndexOf("<State>")-7));
			leadAddressText.Text = ad.Address.ToString();
			string[] w = city.Split(' ');
			city = "";
			int i = 0;

			foreach (string t in w)
			{
				city += t.Substring(0, 1).ToUpper();
				city += t.Substring(1, t.Length-1).ToLower();
				if (i > 0)
					city += " ";
				
			}

			
				
		//	city.ToLower();
		//	TextInfo textinfo = new CultureInfo("en-US", false).TextInfo;
		//	textinfo.ToTitleCase(city);
			//city = Regex.Replace(city, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
			leadCitySTZipText.Text = city+", " + state +"  "+ ad.Zip.ToString();


			ShowOnMap(null, MakeAddress(ad.Address.ToString(), city, state, ad.Zip.ToString()));


			//	this.dTO_LeadDataGrid.ItemsSource = s1.LeadList;



		}



		private void ShowOnMap(string from = null, string to = null)
		{

			try
			{
				StringBuilder queryaddress = new StringBuilder();
				queryaddress.Append("http://maps.google.com/maps");
				/*	if (to == string.Empty)
					{
						queryaddress.Append("?q=");
					}
					else
					{
					*/
				queryaddress.Append("/dir/196 Old Loganville Road,Loganville,Georgia,30052/" + to);
				/*	}  */

				ShowWeatherforZipcode(queryaddress.ToString());
				//GoogleMap.Navigate();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), "Custom Error Message");
				//throw;
			}
		}

		private void TabItem_GotFocus(object sender, RoutedEventArgs e)
		{
			/*	if (MessageBoxResult.Yes == MessageBox.Show("Do you want directions?", "Directions", MessageBoxButton.YesNo))
				{ */

			ShowOnMap(null, MakeAddress(leadAddressText.Text, "", "", leadCitySTZipText.Text));
			/*	} 
				else
				{
					ShowOnMap(null, leadAddressText.Text);
				}
				  */
		}

		private void ShowWeatherforZipcode(string webaddress)
		{

			AppointmentWebView.Source = new Uri(webaddress.ToString());

		}

		private string MakeAddress(string street, string city, string state, string zipcode)
		{



			StringBuilder queryaddress = new StringBuilder();


			if (street != string.Empty)
			{
				queryaddress.Append(street + "," + "+");
			}
			if (city != string.Empty)
			{
				queryaddress.Append(city + "," + "+");
			}
			if (state != string.Empty)
			{
				queryaddress.Append(state + "," + "+");
			}
			if (zipcode != string.Empty)
			{
				queryaddress.Append(zipcode + "," + "+");
			}

			return queryaddress.ToString();
		}


		private void DocumentUpload_Click(object sender, RoutedEventArgs e)
		{
			//AnalogFileUploadPage page = new AnalogFileUploadPage();
			AddClaimDocumentation page = new AddClaimDocumentation();
			this.NavigationService.Navigate(page);
		}

		private void InvoicePageBtn(object sender, RoutedEventArgs e)
		{
			InvoicePage page = new InvoicePage();
			this.NavigationService.Navigate(page);

		}

		private void ScopeEntryButton(object sender, RoutedEventArgs e)
		{
			ScopeViewer page = new ScopeViewer();
			this.NavigationService.Navigate(page);
		}

		private void PaymentEntryPagebtn(object sender, RoutedEventArgs e)
		{
			PaymentEntryPage page = new PaymentEntryPage();
			this.NavigationService.Navigate(page);
		}

		private void ViewCapOutButton(object sender, RoutedEventArgs e)
		{
			CapOutSheet Page = new CapOutSheet();
			this.NavigationService.Navigate(Page);
		}

		private void AppointmentWebView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (b == true)
			{
				ShowWeatherforZipcode("https://weather.com/weather/today/l/" + leadCitySTZipText.Text + ":4:US");
				b = false;
			}
			else {
				ShowOnMap(null, MakeAddress(leadAddressText.Text, "", "", leadCitySTZipText.Text));
				b = true; 
			}
		}

		private void appointments_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void appointments_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void calendar_AppointmentEditorClosed(object sender, Syncfusion.UI.Xaml.Schedule.AppointmentEditorClosedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void calendar_AppointmentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void AppointmentWebView_MouseEnter(object sender, MouseEventArgs e)
		{
			AppointmentWebView.Height = this.Height;
			AppointmentWebView.Width = this.Width;
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			Page page = new RoofMeasurmentsPage();
			NavigationService.Navigate(page);
		}
	}
}



/* For Each loop for list of dto object retrieval*/

//foreach (DTO_CalendarData c in s1.CalDataList)
//{
//	string d = "Appointment # " + i.ToString() + " From: " + c.StartTime.ToString() + " To: " + c.EndTime.ToString();
//	MessageBox.Show(d);
//	i++;
//}

