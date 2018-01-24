using MRNNexus_Model;
using MRN_Claim_Services.ClaimHandling;
using MRN_Claim_Services.Controllers;
using MRN_Claim_Services.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRN_Claim_Services
{
    public partial class AddClaim : Form
    {
        ServiceLayer s1 = ServiceLayer.getInstance();
        static AddClaim NewClaim;
      public static AddClaim getAddClaimInstance()
        {
            if (NewClaim == null)
                NewClaim = new AddClaim();
            return NewClaim;
        }
        public string Refname { get; set; }
        public DTO_Lead Lead { get; set; }
        public DTO_Claim Claim { get; set; }
        public DTO_Address Address { get; set; }
        public DTO_Referrer Referrer { get; set; }
        public DTO_Customer Cust { get; set; }
        public string LeadSource { get; set; }

        bool l = false, a = false, c= false;
        bool cont = false;

        public AddClaim()
        {
            InitializeComponent();
            Claim = new DTO_Claim();
                     
        }

        async Task<DTO_Claim> Add_Claim(DTO_Claim claim)
        {

            
            try
            {

                await s1.AddClaim(claim);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                NewClaim.Claim = s1.Claim;
                claim.ClaimID = s1.Claim.ClaimID;
                cont = true;
            }
            
            return claim;
        }

      async private void button1_Click(object sender, EventArgs e)
        {

            var claim = new DTO_Claim();
            try
            {
                //the order is 
                //Add Customer Object
                //Get CustomerID from added object and apply it to the address object ie Address.CustomerID, Lead.CustomerID, Claim.CustomerID
                //add the address object
                // and get its addressID and apply it to lead and claim ie Lead.AddressID, Claim.PropertyID, Claim.BillingID 
                // HERE is where the check for Referral happens at the latest and that is so that we can get appropriate CreditToID for the claim
                //Once the referrer is figured out and leadtype and credittoID
                //Add the referrer if necessary to get referrerid to submit it as credittoid but
                //now we can add lead to get lead id and finish creating claim to get the beloved claimid which is what pacante sauce is made of
                //add claim code here
                //check for errors
                //handle errors 
                //get claimid and use where ever needed to handle claim responsibilities



                //await s1.AddCustomer(NewClaim.Cust);
                //NewClaim.Cust = s1.Cust;
                //NewClaim.Address.CustomerID = s1.Cust.CustomerID;
                //await s1.AddAddress(NewClaim.Address);
                //NewClaim.Address = s1.Address == null ? s1.Address1: s1.Address ;
                //Referrer = NewClaim.Referrer == null ? s1.Referrer : NewClaim.Referrer;
                //NewClaim.Lead = NewClaim.Lead == null ? s1.Lead : NewClaim.Lead;
                //NewClaim.Lead.AddressID = NewClaim.Address.AddressID;
                //claim.PropertyID = claim.BillingID = NewClaim.Address.AddressID;
                //claim.LeadID = NewClaim.Lead.LeadID;
                claim.LossDate = lossDateDateTimePicker.Value;
                claim.CustomerID = NewClaim.Cust.CustomerID;
                claim.InsuranceCompanyID = (int)comboBox2.SelectedValue;
                claim.InsuranceClaimNumber = insuranceClaimNumberTextBox.Text;
                claim.IsOpen = isOpenCheckBox.Checked;
                claim.ContractSigned = contractSignedCheckBox.Checked;
                claim.MortgageCompany = mortgageCompanyTextBox.Text;
                claim.MortgageAccount = mortgageAccountTextBox.Text;
                claim.MRNNumber = "a";
            }
            catch(NullReferenceException nre)
            {
                MessageBox.Show(nre.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            //if(((DTO_Claim) await Add_Claim(claim)).ClaimID>0)
            //      this.DialogResult = DialogResult.OK;
            var IC = new InitializeClaim();
            IC.Address = NewClaim.Address;
            IC.Cust = NewClaim.Cust;
            IC.Lead = NewClaim.Lead;
            IC.Claim = claim;
            if(await IC.Initialize_Claim(NewClaim.Cust,NewClaim.Address,NewClaim.Lead,NewClaim.Referrer)>0)
               this.DialogResult = DialogResult.OK; ;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddLead al = new AddLead();
            al.Address = NewClaim.Address;
            al.Cust = NewClaim.Cust;
           
           
            comboBox2.DataSource = s1.InsuranceCompaniesList;
            if (DialogResult.OK == al.ShowDialog())
               
            if (NewClaim.Lead != null)
                {
                    NewClaim.Lead = al.Lead;
               Refname = al.CreditForID;
                    leadIDTextBox.Text = Referrer != null ? Referrer.FirstName + " " + Referrer.LastName : Refname;
                                l = true;
            }
            
            AddClaimBtn.Enabled = isEnabled();
        }
        void EnableButton(int btn)
        {
            switch (btn)
            {
                case 1:
                    {
                        button2.Enabled = true;
                        break;
                    }
                case 2:
                    {
                        button5.Enabled = true;
                        break;
                    }

                default:
                    break;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AddAddress ad = new AddAddress();
            ad.Cust = NewClaim.Cust;
            if (DialogResult.OK != ad.ShowDialog())
                NewClaim.Address = ad.Address;
            if (NewClaim.Address != null)
            {
                a = true;
                addressTextBox.Text = NewClaim.Address.Address+" "+ NewClaim.Address.Zip;
                this.Claim.BillingID = NewClaim.Address.AddressID;
                this.Claim.PropertyID = NewClaim.Address.AddressID;
            }
            AddClaimBtn.Enabled = isEnabled();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Add_Inspection ai = new Add_Inspection();
        }

        bool isEnabled()
        {
            if (l && a && c)
                return true;
            else return false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            AddCustomer ac = new AddCustomer();
            if (DialogResult.OK == ac.ShowDialog())
                NewClaim.Cust = ac.Cust;

            if (NewClaim.Cust != null)
            {
                customerIDTextBox.Text = NewClaim.Cust.FirstName + " " + NewClaim.Cust.LastName;

               c = true;
               

            } AddClaimBtn.Enabled = isEnabled();
        }
    }
}

namespace MRN_Claim_Services.ClaimHandling
{

    public class InitializeClaim
    {
        ServiceLayer s1 = ServiceLayer.getInstance();
        static AddClaim NewClaim;
        public static AddClaim getAddClaimInstance()
        {
            if (NewClaim == null)
                NewClaim = new AddClaim();
            return NewClaim;
        }
        public string Refname { get; set; }
        public DTO_Lead Lead { get; set; }
        public DTO_Claim Claim { get; set; }
        public DTO_Address Address { get; set; }
        public DTO_Referrer Referrer { get; set; }
        public DTO_Customer Cust { get; set; }
        public string LeadSource { get; set; }

        bool l = false, a = false, c = false;
        bool cont = false;

       
          

        public InitializeClaim()
        {
          //  Claim = new DTO_Claim();
          

        }
        bool checkIngredients()
        {
            bool value = false;
          
            if (Cust == null)
            {
                MessageBox.Show("No Customer");
                return value;
            }

            if (Address == null)
            {
                MessageBox.Show("No Address");
                return value;
            }
            value = true;
            return value;
        }


       async public Task<int> Initialize_Claim(DTO_Customer cust, DTO_Address addy, DTO_Lead lead, DTO_Referrer referrer = null)
        {
  //MessageBox.Show("Claim # "+Initialize_Claim(Cust,Address,Lead,Referrer).ToString());
                
            if (Claim == null)
            {
                MessageBox.Show("No Claim!");
                return 0;
            }
          
                await s1.AddCustomer(cust);
                Claim.CustomerID = lead.CustomerID = addy.CustomerID = s1.Cust.CustomerID;
                Cust = s1.Cust;
                await s1.AddAddress(addy);
                Claim.BillingID = Claim.PropertyID = lead.AddressID = s1.Address1.AddressID;
                Address = s1.Address1;
                if (Referrer != null)
                    await s1.AddReferrer(referrer);
                try
                {
                    lead.CreditToID = s1.Referrer == null || s1.Referrer.ReferrerID < 1 ? lead.CreditToID : s1.Referrer.ReferrerID;
                    Referrer = s1.Referrer;
                }
                catch (NullReferenceException nre)
                {

                }
                lead.Status = 'a';
                await s1.AddLead(lead);
                try
                {
                    Claim.LeadID = s1.Lead.LeadID;
                }
                catch (NullReferenceException nre)
                {
                    MessageBox.Show("Couldnt Insert Lead check info and try again");
                    return 0;
                }
                try
                {
                    await s1.AddClaim(Claim);
                    Claim = s1.Claim;
                }
                catch (NullReferenceException nre)
                {
                    MessageBox.Show("Couldnt Insert Claim check info and try again");
                    return 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                



            
            //while (Claim.ClaimID < 1)
            //    Thread.Yield();
            //MessageBox.Show("Claim # " + Claim.ClaimID.ToString());
            return Claim.ClaimID;
            
        }



    }


}