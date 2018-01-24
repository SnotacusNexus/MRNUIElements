using MRNNexus_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNUIElements.Controllers.Claim.Function
{
    public class CapOut
    {
        public List<DTO_Scope> Scopes { get; set; }
        //OriginalScopeAmountText1.Value = (decimal)Scopes[1].Total;
        //  FinalScopeAmount1.Value = (decimal)Scopes[2].Total;
        public DTO_ClaimContacts ClaimContacts { get; set; }
        // SalespersonName1.Text = ((DTO_Employee)s1.EmployeesList.Find(y=>y.EmployeeID == (int)((DTO_Employee)s1.EmployeesList.Find(z=>z.EmployeeID==(DTO_Lead)s1.LeadsList.Find(x=>x.LeadID ==_Claim.LeadID).LeadID
        //  SupervisorNameText
        //  CustomerNameText

        public DTO_Address Address { get; set; }//  CustomerAddressText1
                                                //  ZipcodeText1
                                                //   RecruiterText1
                                                //   ReferralKnockerText1

        //SettlementDifferenceAmount1
        //  OverheadOverride1
        // OverheadMultiplierAmountText1
        //checkBox2//NC Checkbox --> not necessary now that we have ability to get location from zipcode

        // NumberOfSquaresAmountText1//comes from roof bill not scope
        // OverheadAmountText1

        //KnockerReferralAmountText1
        //////////AdjustedRoofSubtotalAmountText1
        //RoofLaborBillAmountText1 //Labor
        //MiscBillAmount1 //Labor&|Material
        //GutterForgiven//use these check boxes to keep claim payout consistent
        //GutterBillAmountText1//invice
        //InteriorBillAmountText1//invoice
        public List<DTO_Payment> ClaimIncome { get; set; }
        public List<DTO_Invoice> ClaimExpense { get; set; }
        public List<double> ClaimLabor { get; set; } //InteriorForgiven//use these check boxes to keep claim payout consistent
        public List<double> ClaimMaterial { get; set; }
        //       ExteriorBillAmountText1//invoice
        //ExteriorForgiven//use these check boxes to keep claim payout consistent
        ////////////TotalAmountCollectedText1
        ///////////TotalExpenseText1
        //FirstCheckvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvfddddddddddddAmountText1// checks 
        //SupplementCheckAmountText1//check
        //DeductibleCheckAmountText1//check
        //DepreciationAmountText1//check
        //UpgradeCheckAmountText1//check
        /////////////AmountCollectedSubTotal1//sub total=++
        //////////////MaterialBillAmountText1//invoice
        //BringBackAmountText1//credit balance amount
        //Material//RoofMaterialExpenseSubtotalText1-=+=++
        //ReceiptAmount1Text1
        //ReceiptAmount2Text1
        //ReceiptAmount3Text1
        //ReceiptAmount4Text1
        //ReceiptAmount5Text1
        #region The Capout Churn
        //ProfitPerSquareAmount1
        //ProfitAmountText1
        //CostPerSquareAmount1
        //SplitOverride1
        //SalespersonSplitText1   Figuring
        //MRNAmountDueText1
        //SalespersonSplitAmountText1
        //TakesFirstChkBox1
        //InitialDrawAmountText1
        //SalespersonAmountDueText1

        #endregion
    }


    public class Status
    {

    }


    enum PossibleStatuses
    {
        //MacroClaimView

         //questions to answer
         //outstanding $$$$ owed to MRN
         //Priority
         //Depreciation && Deductibles Higher priority than 1st checks
    }
}