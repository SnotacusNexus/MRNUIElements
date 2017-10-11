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
using MRNUIElements.Controllers.Collection;

namespace MRNUIElements
{

	public class ClaimCustomerInfo
	{
		public DTO_Claim Claim { get; set; }
		public DTO_Address Address { get; set; }
		public DTO_Employee LeadKnocker { get; set; }
		public DTO_Employee Salesperson { get; set; }
		public DTO_Customer Customer { get; set; }
		public DTO_Inspection Inspection { get; set; }
		public List<DTO_ClaimStatus> LastStatus { get; set; }
		
		
	}
	/// <summary>
	/// Interaction logic for ViewClaimInfo.xaml
	/// </summary>
	public partial class ViewClaimInfo : Page
	{
		ServiceLayer s = ServiceLayer.getInstance();
		public static string CustomerName;
		public static string ClaimNumber;
		public static string CustomerAddress;
		public static string SalespersonName;
		public static string LeadName;
		public static string NextStepText;
		public ClaimCustomerInfo cci { get; set; }
		public DTO_ClaimContacts cc { get; set; }
		public ViewClaimInfo(DTO_Claim claim)
		{
			InitializeComponent();
			cci = new ClaimCustomerInfo();
			PopulateCCI(claim);
			
			
		}

		async void PopulateCCI(DTO_Claim claim)
		{
			claim = claim == null ? s.ClaimsList.Find(x => x.ClaimID == 19) : claim;

			await s.GetClaimContactsByClaimID(claim);
			if (s.ClaimContacts != null)
				cc = s.ClaimContacts;
			else return;


			if (s.EmployeesList != null)
				s.EmployeesList = null;
			await s.GetEmployeeByID(new DTO_Employee { EmployeeID = cc.SalesPersonID });
			if (s.Employee != null)
				cci.Salesperson = s.Employee;
			else return;
			
			if (s.CustomersList != null)
				s.CustomersList = null;


			await s.GetCustomerByID(new DTO_Customer { CustomerID = claim.CustomerID });
			if (s.Cust != null)
				cci.Customer = s.Cust;
			else return;


			await s.GetAddressByID(new DTO_Address { AddressID = (int)claim.PropertyID });
			if (s.AddressesList != null && s.AddressesList.Count > 0)
				cci.Address = s.Address;

			await s.GetLeadByLeadID(new DTO_Lead { LeadID = claim.LeadID });
            if (s.Lead.LeadTypeID == 1)
            {
                if (s.Employee != null)
                    s.Employee = null;
                await s.GetEmployeeByID(new DTO_Employee { EmployeeID = (int)s.Lead.CreditToID });
            }
			if (s.Employee.Message == null)
				cci.LeadKnocker = s.Employee;
			
			
			cci.Claim = claim;

			await s.GetClaimStatusByClaimID(claim);
		var ts = s.ClaimStatusList.Where(x => x.ClaimID == claim.ClaimID).ToList();
			cci.LastStatus = ts;
		DisplayResults(cci);
		}

		void DisplayResults(ClaimCustomerInfo cci)
		{
			CustomerName= cci.Customer.FirstName + " ";
			if (!string.IsNullOrEmpty(cci.Customer.MiddleName))
			CustomerName += cci.Customer.LastName + " ";
			if (!string.IsNullOrEmpty(cci.Customer.Suffix))
				CustomerName += cci.Customer.Suffix;
			if (!string.IsNullOrEmpty(CustomerName))
				CustomerNameTextBlock.Text = CustomerName;
			else return;

			SalespersonName = cci.Salesperson.FirstName + " ";
			SalespersonName += cci.Salesperson.LastName + " ";
			if (!string.IsNullOrEmpty(cci.Salesperson.Suffix))
				SalespersonName += cci.Salesperson.Suffix;
			else return;
			if (!string.IsNullOrEmpty(SalespersonName))
				SalespersonNameTextBlock.Text = SalespersonName;
			else return;
			if (cci.LeadKnocker != null)
			{
				LeadName = cci.LeadKnocker.FirstName + " ";
				LeadName += cci.LeadKnocker.LastName + " ";
				if (!string.IsNullOrEmpty(cci.LeadKnocker.Suffix))
					LeadName += cci.LeadKnocker.Suffix;
				if(!string.IsNullOrEmpty(LeadName))
				LeadNameTextBlock.Text = LeadName;

			}




			var zcv = new AddressZipcodeValidation();
			if ((cci.Address.Address + ", " + zcv.CityStateLookupRequest(cci.Address.Zip) + "  " + cci.Address.Zip) != null)
				CustomerAddressTextBlock.Text = cci.Address.Address + ", " + zcv.CityStateLookupRequest(cci.Address.Zip) + "  " + cci.Address.Zip;
			else return;
			if (cci.Claim!=null)
			ClaimNumberTextBlock.Text = cci.Claim.InsuranceClaimNumber + " /" + cci.Claim.MRNNumber;
			else return;
			var cs = new DTO_LU_ClaimStatusTypes();
			var cst = s.ClaimStatus.ClaimStatusTypeID;
			NextStepTextBlock.Text = ((DTO_LU_ClaimStatusTypes)cs).ClaimStatusType.ToString();





		}
	}
}
