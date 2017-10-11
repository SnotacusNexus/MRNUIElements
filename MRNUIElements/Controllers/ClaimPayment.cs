using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using MRNNexus_Model;
using static MRNUIElements.Controllers.ClaimView;


using System.ComponentModel;
using PropertyChanged;

namespace MRNUIElements.Controllers
{
	[AddINotifyPropertyChangedInterface]
	public class ClaimPayment : DTO_Payment, INotifyPropertyChanged, IClaimPayment
	{
		public string PaymentDescription { get; set; }
		public string PaymentDateS { get; set; }

		public string PaymentType { get; set; }

		public static ObservableCollection<ClaimPayment> ClaimPayments;

		public event PropertyChangedEventHandler PropertyChanged;
		ServiceLayer s1 = ServiceLayer.getInstance();
		public ObservableCollection<ClaimPayment> GetClaimPayments()
		{
			ClaimPayments = new ObservableCollection<ClaimPayment>();
			var PaymentsList = new ObservableCollection<DTO_Payment>(s1.PaymentsList.Where(x => x.ClaimID == _Claim.ClaimID));
			//	PaymentsList.Add(item);
			try
			{
				foreach (var item in PaymentsList)
				{
					var a = new ClaimPayment();

					a.PaymentDescription = s1.PaymentDescriptions.Find(x => x.PaymentDescriptionID == item.PaymentDescriptionID).PaymentDescription;
					a.Amount = item.Amount;
					a.PaymentDate = item.PaymentDate;
					a.PaymentType = s1.PaymentTypes.Find(x => x.PaymentTypeID == item.PaymentTypeID).PaymentType;
					ClaimPayments.Add(a);
				}
				
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			return ClaimPayments;
		}
		public List<DTO_LU_PaymentDescription> GetPaymentDescriptions()
		{
			return new List<DTO_LU_PaymentDescription>(s1.PaymentDescriptions.ToList());
		}

		public List<DTO_LU_PaymentType> GetPaymentTypes()
		{
			return new List<DTO_LU_PaymentType>(s1.PaymentTypes.ToList());
		}

		public ClaimPayment()
		{

		}

	}

}




//}
//}
