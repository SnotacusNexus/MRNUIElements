using System;
using System.Collections.Generic;
using System.Collections;
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
using System.Collections.ObjectModel;

namespace MRNUIElements.Models
{
	public partial class ClaimDetails
	{
		static ServiceLayer s = ServiceLayer.getInstance();


		public int ClaimID { get; set; }     //MRN Number
		public List<DTO_Invoice> ClaimInvoices = new List<DTO_Invoice>();
		public List<DTO_Payment> ClaimPayments = new List<DTO_Payment>();
		public double TotalClaimAmount { get; set; }
		public double TotalAmountCollected { get; set; }
		public double TotalClaimExpense { get; set; }
		public double RoofSquaresOff { get; set; }
		public List<DTO_Scope> ClaimScopes = new List<DTO_Scope>();
		public List<DTO_CallLog> ClaimCalls = new List<DTO_CallLog>();
		public DTO_NewRoof ClaimRoof = new DTO_NewRoof();
		public List<DTO_Order> ClaimOrders = new List<DTO_Order>();
		public List<DTO_OrderItem> OrderItems = new List<DTO_OrderItem>();
		public string Address { get; set; }
		public string CSZ { get; set; }
		public string STATE { get; set; }
		public double OH { get; set; }
		public double RawProfit { get; set; }
		public double SalesProfit { get; set; }
		public double MRNSP { get; set; }
		public double SalesMP { get; set; }
		public double CPSQ { get; set; }
		public double PPSQ { get; set; }
		public double MRNTP { get; set; }
		public double SalespersonSplit { get; set; }
		public double OverheadMultiplierAmount { get; set; }

		public void CapOut()
		{

			{
				FigureScopeDiff();


				if (RoofSquaresOff != 0)
					CapOutJob(TotalCollected(), TotalExpense(), RoofSquaresOff, SalespersonSplit, OverheadMultiplierAmount, (double)25);
			}
		}
		#region Math

		async public void ChecksTotal()
		{
			TotalAmountCollected = 0;
			await s.GetPaymentsByClaimID(new DTO_Claim { ClaimID = ClaimID });

			foreach (DTO_Payment p in s.PaymentsList)

			{
				TotalAmountCollected += p.Amount;
			}


		}

		async public void MiscCost()
		{
			TotalClaimExpense = 0;
			{
				await s.GetInvoicesByClaimID(new DTO_Claim { ClaimID = ClaimID });

				foreach (DTO_Invoice i in s.InvoicesList)

				{
					TotalClaimExpense += i.InvoiceAmount;
				}

			}
		}

		#endregion

		private double FigureScopeDiff()
		{

			if (ClaimScopes[0] == null) ClaimScopes[0].Total = 0;
			if (ClaimScopes[1] == null) ClaimScopes[1].Total = 0;
			if (ClaimScopes[2] == null) ClaimScopes[2].Total = 0;
			//if (((double)OriginalScopeAmountText.Value > 0 || OriginalScopeAmountText.Value != null) && ((double)FinalScopeAmount.Value > 0 || (FinalScopeAmount.Value != null)))
			return (double)ClaimScopes[2].Total - (double)ClaimScopes[1].Total;
			//	return 0;

		}

		private double TotalExpense()
		{

			return TotalClaimExpense;

		}
		private double TotalCollected()
		{

			return
			TotalAmountCollected;


		}


		private double TotalProfit()
		{
			//	if (ChecksTotal() > 0 || TotalExpense() > 0)
			return TotalCollected() - TotalExpense();


		}

		async private void GetClaimAddressByClaimID(DTO_Claim claim)
		{


			await s.GetAddressByID(new DTO_Address { AddressID = new DTO_Lead { LeadID = claim.LeadID }.AddressID });
			Address = s.Address1.Address + " " + new AddressZipcodeValidation().CityStateLookupRequest(s.Address1.Zip);

		}

		private bool IsState(string ABREVSTATE, string Zipcode)
		{
			string result = new AddressZipcodeValidation().CityStateLookupRequest(Zipcode, 1).Split(' ').ElementAt(1).Trim().ToString(); GetClaimAddressByClaimID(new DTO_Claim { ClaimID = ClaimID });
			if (result == ABREVSTATE)
				return true;
			else
				return false;
		}

		private double FigureRoofersBill(double RoofSquaresOff, string ST = "GA")
		{
			RoofSquaresOff *= 1.15d;
			if (IsState("NC", s.Address1.Zip))
				return ((RoofSquaresOff *= 1.15d) * 67.5);

			return ((RoofSquaresOff *= 1.15) * 56.25);

		}

		private double FigureKnockerReferralFee(double RoofSquaresOff)
		{


			if (RoofSquaresOff < 40)
				return 250;
			else
				return 500;

		}


		#region WorkFunctions



		private void CapOutJob(double TotChk = 0, double TotExp = 0, double NoSq = .01, double splitvar = 50, double ohvar = 10, double smp = 25)
		{
			if (RoofSquaresOff != 0)
				NoSq = (RoofSquaresOff *= 1.15);
			double SalespersonDraw = 500;
			if (NoSq != 0)
			{
				OH = TotalClaimAmount * (ohvar * .01);
				RawProfit = TotalProfit();
				SalesProfit = RawProfit - (RawProfit * ((100 - splitvar) * .01));
				MRNSP = RawProfit - SalesProfit;
				SalesMP = OH * (smp * .01);
				MRNTP = MRNSP - SalesMP;
				CPSQ = 0;
				PPSQ = 0;


				CPSQ = TotExp / NoSq;

				PPSQ = RawProfit / NoSq;
				double SalespersonAmountDue = SalesProfit - SalespersonDraw;

			}

			else
				MessageBox.Show("You can't divide by Zero (0) that's just retarded!", "Stupid People Doing Stupid Shit!", MessageBoxButton.OK, MessageBoxImage.Exclamation);

		}



	}
	public class CapoutResult
	{
		public double CompanyProfit { get; set; }
		public double SalesmanPay { get; set; }
		public double Overhead { get; set; }
		public double SupervisorPay { get; set; }
		public double InvoiceTotal { get; set; }
		public double Draw { get; set; }
		public double PayableOverhead { get; set; }
		public double PaymentTotal { get; set; }

	}
	public class CapoutQuestion
	{

		static ServiceLayer s1 = ServiceLayer.getInstance();
		DTO_Claim Claim { get; set; }
		double NoSq { get; set; }
		double TotalInvoice { get; set; }
		double TotalPayment { get; set; }
		double LeadAmount { get; set; }
		double SalesmanMultiplier { get; set; }
		double OverheadMultiplier { get; set; }
		double BringBack { get; set; }
		double EstimateAmount { get; set; }
		double draw { get; set; }
		int salesmanID { get; set; }
		int customerID { get; set; }
		int leadID { get; set; }
		int supervisorID { get; set; }
		int addressID { get; set; }
		List<DTO_Invoice> invoices { get; set; }
		List<DTO_Payment> payments { get; set; }
		DTO_Order order { get; set; }
		List<DTO_AdditionalSupply> As { get; set; }
		DTO_Employee emp { get; set; }
		DTO_Lead lead { get; set; }
		List<DTO_ClaimContacts> claimContacts { get; set; }
		List<DTO_Scope> scopes { get; set; }
		public CapoutQuestion(DTO_Claim Claim)
		{
			CapOut(Claim);
		}
		public CapoutQuestion(double NoSq, double TotalInvoice, double TotalPayment, double SalesmanMultiplier, double OverheadMultiplier,
			double BringBack, double EstimateAmount, double draw, int salesmanID, int customerID, int addressID,
			int leadID = 0, int supervisorID = 0, double LeadAmount = 0)
		{
			this.NoSq = NoSq;
			this.TotalInvoice = TotalInvoice;
			this.TotalPayment = TotalPayment;
			this.SalesmanMultiplier = SalesmanMultiplier;
			this.OverheadMultiplier = OverheadMultiplier;
			this.BringBack = BringBack;
			this.EstimateAmount = EstimateAmount;
			this.draw = draw;
			this.salesmanID = salesmanID;
			this.customerID = customerID;
			this.addressID = addressID;
			this.leadID = leadID;
			this.supervisorID = supervisorID;
			this.LeadAmount = LeadAmount;

		}
		public CapoutResult CapoutSolution(object obj)
		{
			return CapOut(obj);
		}
		public CapoutResult CapOut(object obj)
		{
			var cr = new CapoutResult();

			FetchData(obj);
			double salesmanMultiplier = .5;
			double invoicetotal = s1.SumOfInvoices;
			double paymenttotal = s1.SumOfPayments;
			double additionalsuppliescost = 0;
			try
			{
				foreach (DTO_Scope ds in s1.ScopesList.Where(s => s.ScopeTypeID == 3))
					scopes.Add(ds);


				try
				{
					foreach (DTO_Scope ds in s1.ScopesList.Where(s => s.ScopeTypeID == 2))
						scopes.Add(ds);
				}
				catch
				{
					try
					{
						if (scopes.Count < 1)
							foreach (DTO_Scope ds in s1.ScopesList.Where(s => s.ScopeTypeID == 1))
								scopes.Add(ds);
					}
					catch (Exception)
					{

						System.Windows.Forms.MessageBox.Show("ERROR: There are no insurance scope or estimates associated with this claim " + Claim.MRNNumber.ToString());

					}

					finally
					{
						if (MessageBoxResult.Yes != (System.Windows.MessageBoxResult)System.Windows.Forms.MessageBox.Show("Is this the newest scope? The scope has an RCV Amount of " + scopes[0].Total.ToString(), "Scope Information Found", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question))

							try
							{
								if (MessageBoxResult.Yes != (System.Windows.MessageBoxResult)System.Windows.Forms.MessageBox.Show("Is this the newest scope? The scope has an RCV Amount of " + scopes[1].Total.ToString(), "Scope Information Found", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question)) ;//empty to keep moving

							}
							catch (Exception)
							{
								System.Windows.Forms.MessageBox.Show("ERROR: There are no suitable scopes to capout claim " + Claim.MRNNumber.ToString());

							}

					}

				}

				finally
				{
					try
					{
						foreach (DTO_AdditionalSupply a in s1.AdditionalSuppliesList.Where(x => x.Cost != 0))
							additionalsuppliescost += a.Cost;

					}
					catch (Exception ex)
					{

						System.Windows.Forms.MessageBox.Show(ex.ToString());
					}

				}
			}


			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			finally
			{
				double RCV = 0;
				double supervisorPay = 120;
				if (scopes.Count > 0)
					foreach (var s in scopes)
						if (s.Total > RCV)
							RCV = s.Total;
				double overhead = paymenttotal < RCV ? paymenttotal : RCV;
				overhead = overhead * .1;
				additionalsuppliescost = additionalsuppliescost * -1;
				double profit = (paymenttotal - overhead - invoicetotal - additionalsuppliescost - supervisorPay);
				double salesman = profit * salesmanMultiplier - draw;
				cr.CompanyProfit = profit - salesman;
				cr.Draw = draw;
				cr.InvoiceTotal = invoicetotal;
				cr.PayableOverhead = overhead;
				cr.SalesmanPay = salesman;
				cr.Overhead = RCV;
				cr.SupervisorPay = supervisorPay;
				cr.PaymentTotal = paymenttotal;



			}




			return cr;
		}
		async void FetchData(object obj)
		{
			await s1.GetAllLeads();

			await s1.GetAllClaims();
			if ((Type)obj == typeof(DTO_Claim))
				Claim = (DTO_Claim)obj;
			else if ((Type)obj == typeof(DTO_Scope))
				Claim = (DTO_Claim)s1.ClaimsList.Select(x => x.ClaimID == ((DTO_Scope)obj).ClaimID);
			else if ((Type)obj == typeof(DTO_Invoice))
				Claim = (DTO_Claim)s1.ClaimsList.Select(x => x.ClaimID == ((DTO_Invoice)obj).ClaimID);
			else if ((Type)obj == typeof(DTO_Payment))
				Claim = (DTO_Claim)s1.ClaimsList.Select(x => x.ClaimID == ((DTO_Payment)obj).ClaimID);
			else if ((Type)obj == typeof(DTO_AdditionalSupply))
				Claim = (DTO_Claim)s1.ClaimsList.Select(x => x.ClaimID == ((DTO_AdditionalSupply)obj).ClaimID);
			else if ((Type)obj == typeof(DTO_ClaimContacts))
				Claim = (DTO_Claim)s1.ClaimsList.Select(x => x.ClaimID == ((DTO_ClaimContacts)obj).ClaimID);
			//TODO Add a way to search using Search OBJECT to find one of the previous ids to get to one claim
			else
				System.Windows.Forms.MessageBox.Show("Unsupported Capout Request! Cant Find Method to Capout based on " + obj.ToString());

			await s1.GetInvoicesByClaimID(Claim);
			await s1.GetPaymentsByClaimID(Claim);
			await s1.GetClaimContactsByClaimID(Claim);
			await s1.GetAdditionalSuppliesByClaimID(Claim);
			await s1.GetOrdersByClaimID(Claim);
			await s1.GetScopesByClaimID(Claim);

		}


	}
}
#endregion