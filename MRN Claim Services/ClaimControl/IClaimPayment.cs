using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MRNNexus_Model;

namespace MRN_Claim_Services.Controllers
{
	public interface IClaimPayment
	{
		string PaymentDateS { get; set; }
		string PaymentDescription { get; set; }
		string PaymentType { get; set; }

		event PropertyChangedEventHandler OnPropertyChanged;

		ObservableCollection<ClaimPayment> GetClaimPayments();
		List<DTO_LU_PaymentDescription> GetPaymentDescriptions();
		List<DTO_LU_PaymentType> GetPaymentTypes();
	}
}