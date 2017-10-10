using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static MRNUIElements.Controllers.ClaimHandling;
namespace MRNUIElements
{

    /// <summary>
    /// Interaction logic for CustomerAgreement.xaml
    /// </summary>
    public partial class CustomerAgreement : Page
    {
        static ServiceLayer s = ServiceLayer.getInstance();
        ObservableCollection<DTO_InsuranceCompany> insco = new ObservableCollection<DTO_InsuranceCompany>();
        //  ObservableCollection<DTO_InsuranceCompany> INSCO = new ObservableCollection<DTO_InsuranceCompany>();
        int i = 1;

        public CustomerAgreement()
        {
            InitializeComponent();
            Getem();
            // InsuranceLU.ItemsSource = s.InsuranceCompaniesList;
        }

        async public void Getem()
        {

            await s.GetAllReferrers();
            await s.GetAllInsuranceCompanies();
            await s.GetLeadTypes();
            LeadType.ItemsSource = s.LeadTypes;
            foreach (DTO_InsuranceCompany item in s.InsuranceCompaniesList)
            {
                insco.Add(item);

            }
            InsuranceLU.ItemsSource = insco;

        }


        private void Customer_MouseEnter(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
        }


        private void Customer_MouseLeave(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Background = null;
        }
        #region Navigation
        private void PrevStep(object sender, RoutedEventArgs e)
        {
            if (this.CustomeerAgreement.SelectedItem == Finalize_Agreement)
                Upgrades.Focus();
            else if (this.CustomeerAgreement.SelectedItem == Upgrades)
                Project_At_Hand.Focus();
            else if (this.CustomeerAgreement.SelectedItem == Project_At_Hand)
                Claim_Process.Focus();
            else if (this.CustomeerAgreement.SelectedItem == Claim_Process)
                Damage_Assessment.Focus();
            else if (this.CustomeerAgreement.SelectedItem == Damage_Assessment)
                Site_Survey.Focus();
            else if (this.CustomeerAgreement.SelectedItem == Site_Survey)
                Insurance.Focus();
            else if (this.CustomeerAgreement.SelectedItem == Insurance)
                Customer_Info.Focus();
            else if (this.CustomeerAgreement.SelectedItem == Customer_Info)
                Lead_Generation.Focus();





        }

        private void NextStep(object sender, RoutedEventArgs e)
        {

            if (this.CustomeerAgreement.SelectedItem == Lead_Generation)
                Customer_Info.Focus();
            else if (this.CustomeerAgreement.SelectedItem == Customer_Info)
                Insurance.Focus();
            else if (this.CustomeerAgreement.SelectedItem == Insurance)
                Site_Survey.Focus();
            else if (this.CustomeerAgreement.SelectedItem == Site_Survey)
                Damage_Assessment.Focus();
            else if (this.CustomeerAgreement.SelectedItem == Damage_Assessment)
                Claim_Process.Focus();
            else if (this.CustomeerAgreement.SelectedItem == Claim_Process)
                Project_At_Hand.Focus();
            else if (this.CustomeerAgreement.SelectedItem == Project_At_Hand)
                Upgrades.Focus();
            else if (this.CustomeerAgreement.SelectedItem == Upgrades)
                Finalize_Agreement.Focus();

            // if (Finalize_Agreement.IsFocused)
            // Finalize_Agreement.Focus();

        }

        private void Home(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new NexusHome());

        }

        private void Roof_Inspection_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DrawPlanePage());
        }

        private void Exterior_Inspection_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClaimItPage());
        }

        private void Edit_Inspection_Click(object sender, RoutedEventArgs e)
        {
            ClaimInspectionWizard Page = new ClaimInspectionWizard(i);

        }

        private void Gutter_Inspection_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ContestPage());
        }

        private void Interior_Inspection_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InteriorInspectionWizard());
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddClaim();

        }
        #endregion
        #region Add a claim


        async public void AddClaim()
        {

            try
            {


                #region Create New Instance Of DTO's needed
                DTO_Lead lead = new DTO_Lead();
                DTO_Address address = new DTO_Address();
                DTO_Claim claim = new DTO_Claim();
                DTO_Customer customer = new DTO_Customer();
                DTO_Inspection inspection = new DTO_Inspection();
                DTO_ClaimStatus claimStatus = new DTO_ClaimStatus();
                DTO_NewRoof newRoof = new DTO_NewRoof();
                DTO_Order order = new DTO_Order();
                DTO_OrderItem orderItem = new DTO_OrderItem();
                DTO_Scope scope = new DTO_Scope();



                DTO_Referrer referral = new DTO_Referrer();
                #endregion
                #region Populate Customer

                customer.FirstName = FirstName1.Text;
                customer.MiddleName = MiddleName1.Text;
                customer.LastName = LastName1.Text;
                customer.Suffix = Suffix1.Text;
                customer.PrimaryNumber = Primary_Phone1.Text;
                customer.SecondaryNumber = Secondary_Phone1.Text;
                customer.Email = Email_Address1.Text;
                customer.MailPromos = false;


                #endregion
                #region Populate Address


                address.Address = Address1.Text;
                address.Zip = Zipcode1.Text;
                #endregion
                #region Populate Referrer
                int referrerID = 0;
                referral.FirstName = FirstName.Text;
                referral.Zip = Zipcode.Text;

                referral.LastName = Lastname.Text;
                referral.Suffix = suffix.Text;
                referral.CellPhone = Primary_Phone.Text;
                referral.MailingAddress = Address.Text;
                referral.Email = Email_Address.Text;
                //CheckIfTheyExist if so get the referralID

                if (s.ReferrersList.Count > 0)
                {
                    if (s.ReferrersList.Exists(x => x.FirstName == FirstName.Text && x.LastName == Lastname.Text))
                    {
                        referral.ReferrerID = s.ReferrersList.Find(x => x.FirstName == FirstName.Text && x.LastName == Lastname.Text).ReferrerID;
                        lead.LeadTypeID = 2;
                        lead.CreditToID = referral.ReferrerID;

                    }


                    if (s.CustomersList.Exists(x => x.FirstName == FirstName.Text && x.LastName == Lastname.Text))
                    {
                        lead.CreditToID = s.CustomersList.Find(x => x.FirstName == FirstName.Text && x.LastName == Lastname.Text).CustomerID;
                        lead.LeadTypeID = 3;
                    }
                    //
                    if (s.EmployeesList.Exists(x => x.FirstName == FirstName.Text && x.LastName == Lastname.Text))
                    {
                        lead.CreditToID = s.EmployeesList.Find(x => x.FirstName == FirstName.Text && x.LastName == Lastname.Text).EmployeeID;
                        lead.LeadTypeID = 1;
                    }

                    if (!s.ReferrersList.Exists(x => x.FirstName == FirstName.Text && x.LastName == Lastname.Text))
                    {
                        await s.AddReferrer(referral);
                    }
                }
                #endregion
                #region Populate Lead
                lead.Temperature = "W";
                lead.CreditToID = referral.ReferrerID;
                lead.SalesPersonID = s.LoggedInEmployee.EmployeeID;
                lead.KnockerResponseID = null;
                lead.LeadDate = ContractDate.SelectedDate.Value;
                lead.LeadTypeID = lead.LeadTypeID==0?5:5;
                #endregion
                #region Claim Addition Underway

                await s.AddCustomer(customer);
                if (s.Cust.Message == null)
                {
                    lead.CustomerID = s.Cust.CustomerID;
                    address.CustomerID = s.Cust.CustomerID;
                    claim.CustomerID = s.Cust.CustomerID;
                    System.Windows.Forms.MessageBox.Show(s.Cust.CustomerID.ToString());
                }

                else System.Windows.Forms.MessageBox.Show(s.Cust.Message.ToString());

                #endregion
                #region Add Address
                await s.AddAddress(address);


                if (s.Address1.Message == null)
                {
                    lead.AddressID = s.Address1.AddressID;
                    System.Windows.Forms.MessageBox.Show(s.Address1.AddressID.ToString());
                }
                else
                    System.Windows.Forms.MessageBox.Show(s.Address1.Message.ToString());
                await s.AddLead(lead);
                #endregion
                #region AddLead
                if (s.Lead.Message == null)
                {
                    claim.LeadID = s.Lead.LeadID;
                    System.Windows.Forms.MessageBox.Show(s.Lead.LeadID.ToString());
                }
                else
                    System.Windows.Forms.MessageBox.Show(s.Lead.Message.ToString());

                #endregion
                #region Popuate Claim
                claim.MRNNumber = "MRN-" + s.Lead.SalesPersonID + "-" + s.Cust.CustomerID;
                claim.PropertyID = s.Address1.AddressID;
                claim.BillingID = claim.PropertyID;
                claim.LossDate = DateTime.Now.Date;
                claim.InsuranceCompanyID = InsuranceLU.SelectedIndex;


                //claim.InsuranceCompanyID = ((DTO_InsuranceCompany)InsuranceLU.SelectedItem).InsuranceCompanyID;
                if (MortgageHolder.Text != string.Empty)
                    claim.MortgageCompany = MortgageHolder.Text;
                if (MortgageAcctNumber.Text != string.Empty)
                    claim.MortgageAccount = MortgageAcctNumber.Text;

                #endregion
                #region Doing the damn thang

                await s.AddClaim(claim);
                if (s.Claim.Message == null)
                {
                    claim.LeadID = s.Lead.LeadID;
                    System.Windows.Forms.MessageBox.Show("Congratulations You Have Successfully became a statistic! Your Claim and Experience is now associated with " + s.Claim.MRNNumber.ToString());
                }
                else
                    System.Windows.Forms.MessageBox.Show(s.Lead.Message.ToString());
                #endregion

                //bool hasscope = false;


                ////scope?
                //if (hasscope)
                //{
                //    scope.ClaimID = claim.ClaimID;
                //    scope.Deductible = 1000;
                //    scope.Exterior = 600;
                //    scope.Gutter = 995;
                //    scope.Interior = 2040;
                //    scope.OandP = 900;
                //    scope.ScopeTypeID = 2;
                //    scope.Tax = 345.87;
                //    scope.Total = 80021.35;
                //    scope.RoofAmount = scope.Total - scope.Tax - scope.OandP - scope.Interior - scope.Gutter - scope.Exterior;

                //    await s.AddScope(scope);

                //}

                //// claimStatus


                ////scope?

                //// inspection


                ////order?
                //bool hasorder = false;
                //if (hasorder)
                //{
                //    order.ClaimID = claim.ClaimID;
                //    order.DateDropped = DateTime.Today.Date;
                //    order.DateOrdered = DateTime.Today.Subtract(TimeSpan.FromDays(1));
                //    order.ScheduledInstallation = DateTime.Today.AddDays(1);
                //    order.VendorID = 7;

                //    await s.AddOrder(order);

                //}
                //ObservableCollection<DTO_OrderItem> orderitems = new ObservableCollection<DTO_OrderItem>();


                //orderItem.OrderID = s.Order.OrderID;
                //orderItem.ProductID = 1;
                //orderItem.Quantity = 99;



                ////orderitems?

            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region OrderRoofSupplies




        #endregion




        #region Update Claims Number on comboBox Selection Change
        private void InsuranceLU_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InsuranceLU.SelectedIndex > -1 && InsuranceLU.SelectedIndex < insco.Count())
                if (!string.IsNullOrEmpty(insco[InsuranceLU.SelectedIndex].ClaimPhoneNumber))
                    ClaimsPhoneNumber.Text = insco[InsuranceLU.SelectedIndex].ClaimPhoneNumber;
                else ClaimsPhoneNumber.Text = "No Number Available";
            else ClaimsPhoneNumber.Text = "No Number Available";

        }
        #endregion
    }
}









