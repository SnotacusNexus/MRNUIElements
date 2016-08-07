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

        private double FigureRoofersBill(double RoofSquaresOff, string ST="GA")
        {
            RoofSquaresOff *= 1.15;
            if (IsState("NC", s.Address1.Zip))
                return ((RoofSquaresOff *= 1.15) * 67.5);

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
}
#endregion