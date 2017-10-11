using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRNNexus_Model;
using MRNUIElements.Controllers;
using static MRNUIElements.Controllers.ClaimView;
using System.ComponentModel;
using PropertyChanged;
namespace MRNUIElements
{
	
	[AddINotifyPropertyChangedInterface]

	public class Utilities : INotifyPropertyChanged
	{
		


		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
#endregion
		public static ServiceLayer s1 = ServiceLayer.getInstance();
		public static int ClaimID { get; set; }
		

		
		
		public static DTO_Inspection Inspection { get; set; }
		public static DTO_Customer Customer { get; set; }
		public static ObservableCollection<DTO_ClaimDocument> ClaimDocuments { get; set; }
		public static ObservableCollection<DTO_ClaimVendor> ClaimVendors { get; set; }
		public static ObservableCollection<DTO_Scope> Scopes { get; set; }
		public static ObservableCollection<DTO_ClaimContacts> ClaimContacts { get; set; }
		public static ObservableCollection<DTO_Payment> ClaimPayments { get; set; }
		public static ObservableCollection<DTO_Invoice> ClaimInvoices { get; set; } 
		public static ObservableCollection<DTO_CallLog> ClaimCallLogs { get; set; }
		public static ObservableCollection<DTO_OrderItem> ClaimOrderItems { get; set; }
	//	public static ObservableCollection<ClaimIndexOrder> OrderIndices { get; set; }

public static async Task<DTO_Claim> GetClaimByClaimID(int _claimID)
		{
			if(_claimID >0)
			await Task.Run(() => s1.GetClaimByClaimID(new DTO_Claim { ClaimID = _claimID }));
			while (s1.Claim == null)
				await Task.Delay(100);
			return s1.Claim;

		}


	}
	
}
