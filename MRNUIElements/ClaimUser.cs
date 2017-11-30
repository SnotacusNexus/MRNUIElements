using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MRNNexus_Model;
using MRNUIElements.Controllers;

namespace  MRNUIElements.ClaimDataService
{


	public class AccessableClaimsList : ObservableCollection<DTO_Claim>
	{

		public static DTO_Claim Claim { get; set; }
		public static DTO_Employee Employee {
			get {
				if (Employee == null)
					Employee = (DTO_Employee)Application.Current.Properties["CurrentUser"];
				return Employee;
				
			}
			set
			{
				Employee = value;
			}
		}
		public static bool AccessGranted{
			get {
				return (s1.EmployeeOpenClaimsList.Exists(x => x.ClaimID == Claim.ClaimID));

			}
			set {

				AccessGranted = value;

			}

		}
		static ServiceLayer s1 = ServiceLayer.getInstance();
		DTO_Employee emp = (DTO_Employee)Application.Current.Properties["CurrentUser"];
		DTO_Claim claim  = (DTO_Claim)Application.Current.Properties["CurrentClaim"];
		bool waitforme = true;

		public AccessableClaimsList()
		{
			s1.EmployeeOpenClaimsList.Clear();
			s1.ClaimsList.Clear();
			CreateAccessableClaimsList(Employee, Claim);
		}

		async void CreateAccessableClaimsList(DTO_Employee Employee, DTO_Claim Claim, int ClaimScope=0)
		{
			Clear();

			if (ClaimScope < 1)
			{


				if (Employee.EmployeeTypeID < 13)
				{
					await s1.GetAllOpenClaims();

					foreach (var c in s1.OpenClaimsList)
					{
						Add(c);
					}
				}
				else
				{
					await s1.GetOpenClaimsBySalespersonID(Employee);

					foreach (var c in s1.EmployeeOpenClaimsList)
					{
						Add(c);
					}
				}

			}
			else
			{
				await s1.GetAllClaims();
				
				if (Employee.EmployeeTypeID < 13)
					foreach (var c in s1.ClaimsList)
						Add(c);
				else
					foreach (var c in ((from p in s1.ClaimsList join a in s1.LeadsList on p.LeadID equals a.LeadID select new DTO_Claim()).ToList()))
					{
						Add(c);
					}





			}

			 





				  

			
		}
	}

}
													