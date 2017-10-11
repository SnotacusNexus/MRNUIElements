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
	/// Interaction logic for PageFunction1.xaml
	/// </summary>
	public partial class ClaimPickerDialog : PageFunction<Object>
	{
		ServiceLayer s1 = ServiceLayer.getInstance();


		public DTO_Claim Claim { get; set; }

		public ClaimPickerDialog()
		{
			InitializeComponent();
			if (Claim == null)
				Claim = new DTO_Claim();
			ClaimsList.Focus();
			ClaimsList.IsEnabled = false;
			DBInit();
			this.DataContext = this;
			while (s1.OpenClaimsList != null)
				ClaimsList.ItemsSource = s1.OpenClaimsList;

		}
		private async void DBInit()
		{
			if (s1.ClaimsList == null)
			{
				await s1.GetAllClaims();
				while (s1.ClaimsList == null)
					Thread.Sleep(10);
			}

			if (s1.OpenClaimsList == null)
			{
				await s1.GetAllOpenClaims();
				while (s1.OpenClaimsList == null)
					Thread.Sleep(10);
			}
			
		}
		private void SelectBtn_Click(object sender, RoutedEventArgs e)
		{
			ReturnEventArgs<object> returnObject = new ReturnEventArgs<object>(Claim);
			OnReturn(returnObject);

		}

		private void CancelBtn_Click(object sender, RoutedEventArgs e)
		{
			ReturnEventArgs<object> returnObject = new ReturnEventArgs<object>((object)null);
			OnReturn(returnObject);
		}
		private async Task<List<DTO_Claim>> claimSearchMatch(string matchCriteria)
		{
			var clmlst = new List<DTO_Claim>();
			var objlst = new List<Object>();

			if (s1.AddressesList == null)
				await s1.GetAllAddresses();
			if (s1.CustomersList == null)
				await s1.GetAllCustomers();
			if (s1.EmployeesList == null)
				await s1.GetAllEmployees();
			if (s1.AdjustersList == null)
				await s1.GetAllAdjusters();
			if (s1.ClaimContactsList == null)
				await s1.GetAllClaimContacts();

			
			var adlst = s1.AddressesList.FindAll(x => x.Address.Contains(matchCriteria));
			var cuslst = s1.CustomersList.FindAll(x => x.Email.Contains(matchCriteria) || x.FirstName.Contains(matchCriteria) || x.MiddleName.Contains(matchCriteria) || x.LastName.Contains(matchCriteria));
			var emplst = s1.EmployeesList.FindAll(x => x.Email.Contains(matchCriteria) || x.FirstName.Contains(matchCriteria) || x.LastName.Contains(matchCriteria));
			var adjlst = s1.AdjustersList.FindAll(x => x.Email.Contains(matchCriteria) || x.FirstName.Contains(matchCriteria) || x.LastName.Contains(matchCriteria));
			List<DTO_Employee> empl = new List<DTO_Employee>();
			foreach (var c in s1.ClaimContactsList.Where(x=> EmployeeFromID(x.SalesPersonID).Result.Email.Contains(matchCriteria)|| EmployeeFromID(x.SalesManagerID).Result.Email.Contains(matchCriteria)|| EmployeeFromID(x.SalesPersonID).Result.FirstName.Contains(matchCriteria) || EmployeeFromID(x.SalesManagerID).Result.FirstName.Contains(matchCriteria)|| EmployeeFromID(x.SalesPersonID).Result.LastName.Contains(matchCriteria) || EmployeeFromID(x.SalesManagerID).Result.LastName.Contains(matchCriteria)))
			{
				emplst.ForEach(x => clmlst.Add(new DTO_Claim { ClaimID=c.ClaimID }));
			}
			foreach (var c in s1.ClaimContactsList.Where(x => AdjusterFromID((int)x.AdjusterID).Result.Email.Contains(matchCriteria) || AdjusterFromID((int)x.AdjusterID).Result.FirstName.Contains(matchCriteria) || AdjusterFromID((int)x.AdjusterID).Result.LastName.Contains(matchCriteria)))
			{
				adjlst.ForEach(x => clmlst.Add(new DTO_Claim { ClaimID = c.ClaimID }));
			}

			adlst.ForEach(x => clmlst.Add(new DTO_Claim { PropertyID = x.AddressID }));
			cuslst.ForEach(x => clmlst.Add(new DTO_Claim { CustomerID = x.CustomerID }));
		
			return await ClaimListFromPartialClaimInfoList(clmlst);
		}
		private async Task<DTO_Employee> EmployeeFromID(int empID)
		{
			var emp = new DTO_Employee();
			if (s1.EmployeesList == null)
				await s1.GetAllEmployees();
			if (s1.Employee != null)
				s1.Employee = null;
			await s1.GetEmployeeByID(new DTO_Employee { EmployeeID = (int)empID });
			emp = s1.Employee;
			return emp;
		}
		private async Task<DTO_Adjuster> AdjusterFromID(int adjID)
		{
			var adj = new DTO_Adjuster();
			if (s1.AdjustersList == null)
				await s1.GetAllAdjusters();
			if (s1.Adjuster != null)
				s1.Adjuster = null;
			await s1.GetAdjustmentsByAdjusterID(new DTO_Adjuster { AdjusterID = (int)adjID });
			adj = s1.Adjuster;
			return adj;
		}
		private async Task<List<DTO_Claim>> ClaimListFromPartialClaimInfoList(List<DTO_Claim> clmlst)
		{
			var claimlist = new List<DTO_Claim>();
			if (s1.ClaimsList == null)
				await s1.GetAllClaims();
			if (s1.Claim != null)
				s1.Claim = null;
			foreach (var c in clmlst) {
				if (c.CustomerID > 0)
					claimlist.Add((DTO_Claim)s1.ClaimsList.Where(x => x.CustomerID == c.CustomerID));
				if (c.PropertyID>0)
					claimlist.Add((DTO_Claim)s1.ClaimsList.Where(x => x.PropertyID == c.PropertyID));
				if (c.ClaimID > 0)
					claimlist.Add((DTO_Claim)s1.ClaimsList.Where(x => x.ClaimID == c.ClaimID));

			}
			return claimlist;
		}
		private async void ClaimSearchBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			List<string> claimNumberList = new List<string>();
			List<DTO_Claim> claimlist = new List<DTO_Claim>();

			if (!string.IsNullOrEmpty(ClaimSearchBox.Text))
				claimlist = await claimSearchMatch(ClaimSearchBox.Text);

			foreach (var a in claimlist)
				claimNumberList.Add(a.InsuranceClaimNumber.ToString());

			ClaimsList.ItemsSource = claimNumberList;


		}

		private void ClaimsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (ClaimsList.SelectedIndex > -1)
			{
				Claim = (DTO_Claim)ClaimsList.SelectedItem;
				SelectBtn.IsEnabled = true;
			}

			else 				
				SelectBtn.IsEnabled = false;
		}
	}
}
