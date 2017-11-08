using MRNNexus_Model;
using MRNUIElements.Controllers;
using PropertyChanged;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MRNUIElements.ViewModels
{
	[AddINotifyPropertyChangedInterface]
	class MRNClaim : INotifyPropertyChanged

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
		static MRNClaim mrnClaim;
		public DTO_Claim Claim { get; set; } = new DTO_Claim();
		public DTO_Customer ClaimCustomer { get; set; } = new DTO_Customer();
		public DTO_Address ClaimAddress { get; set; } = new DTO_Address();
		public ObservableCollection<DTO_Payment> ClaimIncome { get; set; }
		public DTO_Payment ClaimPayment { get; set; } = new DTO_Payment();
		public DTO_Invoice ClaimInvoice { get; set; } = new DTO_Invoice();
		public ObservableCollection<DTO_Invoice> ClaimExpenses { get; set; }
		public DTO_ClaimContacts ClaimContacts { get; set; } = new DTO_ClaimContacts();
		public DTO_Order ClaimOrder { get; set; } = new DTO_Order();
		public ObservableCollection<DTO_Scope> Scopes { get; set; }
		public ObservableCollection<DTO_Inspection> ClaimInspections { get; set; }
		public bool JobSplit { get; set; } = false;
		public bool TakesFirstDraw { get; set; } = true;
		public ObservableCollection<DTO_Lead> Leads { get; set; }
		public ObservableCollection<DTO_AdditionalSupply> TakeOuts { get; set; }
		public ObservableCollection<DTO_SurplusSupplies> BringBacks { get; set; }
		public ObservableCollection<DTO_Plane> ClaimMeasurements { get; set; }
		public DTO_Plane ClaimPlane { get; set; } = new DTO_Plane();
		public BusyIndicator BusyIndicator { get; set; } = new BusyIndicator();
		public ObservableCollection<DTO_Damage> ClaimDamages { get; set; }
		public DTO_Damage ClaimDamage { get; set; } = new DTO_Damage();
		public InspectionImage InspectionImage { get; set; } = new InspectionImage();
		public ObservableCollection<InspectionImage> InspectionImages { get; set; }
		public DTO_Lead ClaimLead { get; set; } = new DTO_Lead();
		public DTO_Referrer Referral { get; set; } = new DTO_Referrer();
		public DTO_Inspection ClaimInspection { get; set; } = new DTO_Inspection();
		public ObservableCollection<DTO_ClaimDocument> ClaimDocuments { get; set; }
		public DTO_ClaimDocument ClaimDocument { get; set; } = new DTO_ClaimDocument();
		public ObservableCollection<DTO_CallLog> CallLogs { get; set; }
		public DTO_CallLog CallLog { get; set; } = new DTO_CallLog();
		public bool NeedsUpdate { get; set; } = false;
		public ObservableCollection<DTO_OrderItem> OrderItems { get; set; }
		public DTO_OrderItem OrderItem { get; set; } = new DTO_OrderItem();
		public DTO_Adjustment Adjustment { get; set; } = new DTO_Adjustment();
		public Schedule ClaimSchedule { get; set; } = new Schedule();
		public ObservableCollection<ScheduleAppointment> ClaimAppointments { get; set; }
		public ScheduleAppointment ClaimAppointment { get; set; } = new ScheduleAppointment();
		public bool HasRefferal { get; set; } = false;
		public DTO_NewRoof NewRoofColor { get; set; } = new DTO_NewRoof();
		public bool ReadyToOrderRoof { get; set; } = false;
		public bool IsAdjustmentDateSet { get; set; } = false;
		public bool HasFirstCheckCollected { get; set; } = false;
		public bool PassesMeansTest { get; set; } = false;
		public bool AllInvoicesIn { get; set; } = false;
		public bool AllFundsCollected { get; set; } = false;
		public bool FundPickUpScheduled { get; set; } = false;
		public bool IsRoofBought { get; set; } = false;
		public bool IsClaimEstimated { get; set; } = false;
		public bool IsClaimSupplemented { get; set; } = false;
		public bool IsClaimSettled { get; set; } = false;
		public int ClaimAge { get; set; } = 0;
		public bool IsRoofScheduledToGoOn { get; set; } = false;
		public bool IsRoofCompleted { get; set; } = false;
		public bool HasMaterialBeenAdjusted { get; set; } = false;
		public bool HasPendingNotifications { get; set; } = false;
		public bool NeedsMaterialAdjusted { get; set; } = false;
		public bool NeedsApproval { get; set; } = false;
		public bool CocSent { get; set; } = false;
		public bool COCReceived { get; set; } = false;
		public bool HasUpgrade { get; set; } = false;
		public bool HasOtherWorkRefund { get; set; } = false;
		public bool HasOtherWork { get; set; } = false;
		public bool HasInterior { get; set; } = false;
		public bool HasGutters { get; set; } = false;
		public bool HasDeductibleCollected { get; set; }
		public bool IsHouseDeal { get; set; } = false;
		public double PreCapAmount { get; set; } = 0d;
		public bool CountsTowardBonus { get; set; } = false;
		public bool WarrantySent { get; set; } = false;
		public string ClaimSplitWith { get; set; } = "";
		public bool StatusFiguringComplete { get; set; } = false;
		public bool HasInspection { get; set; } = false;
		public bool HasSignature { get; set; } = false;
		public bool NeedsReinspect { get; set; } = false;
		public bool NeedsSupplement { get; set; } = false;
		public bool IsRush { get; set; } = false;
		public bool IsOverride { get; set; } = false;
		public bool UnderReview { get; set; } = false;
		public bool NeedsMortgageEndorsement { get; set; } = false;
		public bool NeedsEagleviewOrdered { get; set; } = false;
		public int ClaimProgress { get; set; } = 0;


		
		ObservableCollection<decimal> inv = new ObservableCollection<decimal>();
		ObservableCollection<decimal> pay = new ObservableCollection<decimal>();

		#region Constructor
		public MRNClaim(DTO_Claim claim)
		{
			if (claim == null)
				claim = Claim;
		}
		#endregion

		#region Helper Functions
		public static MRNClaim getInstance()
		{
			if (mrnClaim == null)
				mrnClaim = new MRNClaim(getInstance().Claim);

			return mrnClaim;
		}

		public ObservableCollection<object> ListToCollection (List<object> listOfObjects)
		{

			var b = new ObservableCollection<object>();
			listOfObjects.ForEach(x => b.Add(x));
			return b;

		}
		
		
		#endregion

		#region Data objects



		#endregion


		#region FigureClaimStatus

		#endregion


	}
}
