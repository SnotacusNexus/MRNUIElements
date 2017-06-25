using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRNNexus_Model;
using MRNUIElements.Controllers;

namespace MRNUIElements.Models
{
	class DetailedClaimModel

	{

		static public ServiceLayer s1 = ServiceLayer.getInstance();
		public DTO_Claim Claim { get; set; }
		public int ClaimID { get; set; }
		public string MRNNumber { get; set; }
		public string Salesperson { get; set; }
		public int No_Of_Squares { get; set; }
		public double Deductible_Amount { get; set; }
		public string Ins_Claim_Number { get; set; }
		public string CurrentStatus { get; set; }
		public string CustomerName { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string INS_CO { get; set; }
		public string KNOCK_REF { get; set; }
		public DateTime SIGNED_DATE { get; set; }
		public DateTime ADJ_DATE { get; set; }
		public bool BOUGHT { get; set; }
		public double ORIG_SCOPE_AMT { get; set; }
		public double ACV { get; set; }
		public double MRN_EST_AMT { get; set; }
		public double _1ST_CK_AMT_Received { get; set; }
		public bool FirstCheckAtMaterialDrop { get; set; }
		public DateTime Supplement_Sent { get; set; }
		public bool Conf { get; set; }
		public double Supplement_Amount { get; set; }
		public bool Supplement_Received { get; set; }
		public double Settlement_Amount { get; set; }
		public DateTime Settlement_Date { get; set; }
		public DateTime Roof_Date { get; set; }
		public bool RoofComp { get; set; }
		public DateTime Interior { get; set; }
		public bool IntComp { get; set; }
		public DateTime Ext_Gutter { get; set; }
		public bool Ext_GutterComp { get; set; }
		public DateTime MAT_PICKUP_Date { get; set; }
		public DateTime CoC_Date { get; set; }
		public bool COC_Conf_Rcd { get; set; }
		public bool COC_Accepted { get; set; }
		public DateTime Final_Check_Release_Date { get; set; }
		public bool Final_Check_Release_Date_Confirmed { get; set; }
		public double Final_Check_Amount { get; set; }
		public DateTime FinalFundsPUDate { get; set; }
		public double Other_Funds_Collected { get; set; }
		public double Projected_Mat_Cost { get; set; }
		public double Projected_Labor_Cost { get; set; }
		public double BottomLine { get; set; }
		public double Bought_Due { get; set; }
		public double DedCollected { get; set; }
		public double AmountDue_less_Ded { get; set; }
		public double Ded_Split { get; set; }
		public double MRN_Split { get; set; }
		public double Overhead_Split { get; set; }
		public double SalesPercent { get; set; }
		public double ProjectedSalesSplit { get; set; }
		public double TotalProfit { get; set; }
		public double TotalCost { get; set; }
		public double OverHead { get; set; }
		public double Mat_Labor { get; set; }
		public double AfterLabor { get; set; }
		public double AfterMaterial { get; set; }
		public double AfterKnock { get; set; }
		public double CurrentClaimAmount { get; set; }
		public double TotalPayments { get; set; }
		public double AmountDue { get; set; }
		public double ProfitMargin { get; set; }
		public string Region { get; set; }
		public ObservableCollection<RoofOrder.RoofOrder> RoofOrder { get; set; }
		public ObservableCollection<Inspection> Inspection { get; set; }
		public ObservableCollection<DTO_ClaimDocument> Claim_Documents { get; set; }
		public ObservableCollection<DTO_Payment> Payments { get; set; }
		public ObservableCollection<DTO_Invoice> VendorInvoices { get; set; }
		public ObservableCollection<DTO_Scope> Scopes { get; set; }
		public ObservableCollection<DTO_CallLog> ClaimMessages { get; set; }


		public void BuildDCM()
		{
			var _claim = new DTO_Claim();

			if (this.Claim == null && this.ClaimID > 0)
				_claim.ClaimID = this.ClaimID;
			Init(_claim);



		}

		async void Init(DTO_Claim Claim, int ClaimID = 0)
		{
			try
			{


				await s1.GetClaimByClaimID(Claim);
				await s1.GetAllCallLogs();
				await s1.GetAllScopes();
				await s1.GetAllInvoices();
				await s1.GetAllPayments();
				await s1.GetAllClaimDocuments();
				await s1.GetAllClaimContacts();
				await s1.GetAllClaimStatuses();
				await s1.GetAllOrders();

			}
			catch (Exception)
			{

				throw;
			}


		}
		class ClaimMessage
		{

			static public ServiceLayer s1 = ServiceLayer.getInstance();

			public int ClaimMessageID { get; set; }
			public int MessageTo { get; set; }
			public int MessageFrom { get; set; }
			public string From { get; set; }
			public string To { get; set; }
			public string MessageSubject { get; set; }
			public string Message { get; set; }
			public int MessageStatus { get; set; }
			public string messageResolution { get; set; }
			public string MessageAttachmentPath { get; set; }

			public ObservableCollection<DTO_CallLog> CallLogEntries { get; set; }

			private string str = "";
			public void claimMessage()
			{

			}
			async void lookUpEmpInfo(int EmpID)
			{
				var empLU = new DTO_Employee { EmployeeID = EmpID };
				try
				{
					await s1.GetEmployeeByID(empLU);
				}
				catch (Exception ex)
				{

					System.Windows.Forms.MessageBox.Show(ex.ToString());
				}

				str = empLU.FirstName + " " + empLU.LastName;

			}
			public async void MessageToCallLog(DTO_Claim ClaimID, int messageFrom, string messageSubject,
				string message, int messageTo = 0, int messageStatus = 0, string messageAttachmentPath = "")
			{
				lookUpEmpInfo(messageFrom);
				string from = str;
				string setMessageFlag = "$#$";
				if (messageTo != 0)
					lookUpEmpInfo(messageTo);
				else str = "Info Only";
				string to = str;
				var statuses = new List<string>();
				statuses.Add("Information Only");
				statuses.Add("Reply Needed");

				var sb = new StringBuilder();

				if (sb.Length > 0)
					sb.Clear();
				sb.AppendLine("MF:" + setMessageFlag);
				sb.AppendLine("FROM:" + from);
				sb.AppendLine("TO:" + to);
				sb.AppendLine("SUBJECT:" + messageSubject);
				sb.AppendLine("MESSAGE:" + message);
				sb.AppendLine("MS:" + statuses[messageStatus]);
				if (!string.IsNullOrEmpty(messageAttachmentPath))
					sb.AppendLine("ATTACHMENT:" + messageAttachmentPath);

				var callLogEntry = new DTO_CallLog
				{
					ClaimID = ClaimID.ClaimID,
					EmployeeID = messageFrom,
					WhoWasCalled = to,
					WhoAnswered = to,
					ReasonForCall = sb.ToString(),
					CallResults = messageResolution

				};

				try
				{
					await s1.AddCallLog(callLogEntry);
					if (callLogEntry.Message == null)
						System.Windows.Forms.MessageBox.Show("Successfully added " + callLogEntry.CallLogID + " for Claim " + callLogEntry.ClaimID.ToString() + ".");

				}
				catch (Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.ToString());

				}
			}

			public async void GetCallLogEntries(DTO_Claim Claim)
			{
				var cle = new ObservableCollection<DTO_CallLog>();
				try
				{
					await s1.GetCallLogsByClaimID(Claim);

				}
				catch (Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.ToString());
				}

				foreach (var cll in s1.CallLogsList.Where(x => x.ClaimID == Claim.ClaimID))
					CallLogEntries.Add(cll);


			}
			public bool IsClaimMessage(int EntryID)
			{
				var cm = new DTO_CallLog();
				cm = this.CallLogEntries[EntryID];
				string s = cm.ReasonForCall;
				if (s.IndexOf("MF:") > -1)
				{
					DecodeCallLogEntry(EntryID);

					return true;
				}
				return false;
			}
			private ClaimMessage DecodeCallLogEntry(int EntryID)
			{



				var cm = new DTO_CallLog();
				cm = this.CallLogEntries[EntryID];
				string s = cm.ReasonForCall;
				string to = s.Substring(s.IndexOf("TO:" + 3), s.IndexOf("SUBJECT:") - s.IndexOf("TO:" + 3));
				string from = s.Substring(s.IndexOf("FROM:" + 5), s.IndexOf("TO:") - s.IndexOf("FROM:" + 5));
				string subject = s.Substring(s.IndexOf("SUBJECT:" + 8), s.IndexOf("MESSAGE:") - s.IndexOf("SUBJECT:" + 8));
				string mess = s.Substring(s.IndexOf("MESSAGE:" + 8), s.IndexOf("MS:") - s.IndexOf("MESSAGE:" + 8));
				string mesStat = "";
				string attachmentpath = "";
				if (s.IndexOf("ATTACHMENT:") > -1)
				{
					mesStat = s.Substring(s.IndexOf("MS:" + 3), s.IndexOf("ATTACHMENT:") - s.IndexOf("MS:+3"));
					attachmentpath = s.Substring(s.IndexOf("ATTACHMENT:") + 11);
				}
				else mesStat = s.Substring(s.IndexOf("MS:" + 3));

				this.ClaimMessageID = EntryID;
				this.To = to;
				this.From = from;
				this.MessageSubject = subject;
				this.Message = mess;
				this.messageResolution = mesStat;
				if (!string.IsNullOrEmpty(attachmentpath))
					MessageAttachmentPath = attachmentpath;
				return this;



			}

		}


	}
}
