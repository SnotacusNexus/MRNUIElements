using MRNNexus_Model;
using MRNUIElements.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRNUIElements.Forms
{
    public partial class AddLead : Form
    {
        bool ai = false, ci = false, c2i = false, KRI = false, LD = false, LTI = false, spi = false, temp = false;
        public DTO_Address Address { get; set; }
        static AddClaim ac = AddClaim.getAddClaimInstance();
        List<DTO_Referrer> ReferrersList = new List<DTO_Referrer>();
        List<DTO_Customer> CustomersList = new List<DTO_Customer>();
        List<DTO_Employee> SalesPersonList = new List<DTO_Employee>();
        List<DTO_Employee> KnockersList = new List<DTO_Employee>();
        public DTO_Referrer Referrer { get; set; }
        public int refnum = 0;
        public DTO_Lead Lead { get; set; }
        ServiceLayer s1 = ServiceLayer.getInstance();
        public string RefName = "";
        private void leadTypeIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DTO_LU_LeadType)leadTypeIDComboBox.SelectedItem) == null)
                LTI = false;
            else LTI = true;
            creditToIDComboBox.DataSource = CreditToListResolver(leadTypeIDComboBox.SelectedIndex);
            //if (((DTO_LU_LeadType)creditToIDComboBox.SelectedValue).LeadTypeID == 1)
            //    creditToIDComboBox.DataSource = KnockersList;
            //else if (((DTO_LU_LeadType)creditToIDComboBox.SelectedValue).LeadTypeID == 2)
            //    creditToIDComboBox.DataSource = s1.CustomersList.FindAll(x => x.CustomerID
            //     == Cust.CustomerID);
            //else if (((DTO_LU_LeadType)creditToIDComboBox.SelectedValue).LeadTypeID == 3)
            //    creditToIDComboBox.DataSource = s1.ReferrersList;
            //else
            //    creditToIDComboBox.DataSource = s1.EmployeesList.FindAll(x => x.EmployeeTypeID == 13);
            if (leadTypeIDComboBox.SelectedIndex == 0)
                knockerResponseIDComboBox.DataSource = s1.KnockResponseTypes;
            else knockerResponseIDComboBox.Text = "No Knocker";
            Add_Lead.Enabled = IsEnabled();

        }

        public DTO_Customer Cust { get; set; }

        private void creditToIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

          
               


            try
            {
                RefName = CreditToListResolver(((DTO_LU_LeadType)leadTypeIDComboBox.SelectedItem).LeadTypeID, refnum)[0].ToString();

            }
            catch (Exception ex)
            {

             
            }
          

            if (creditToIDComboBox.SelectedItem == null)
                c2i = false;
            else c2i = true;
            Add_Lead.Enabled = IsEnabled();
        }

        private void customerIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customerIDComboBox.SelectedItem == null)
                LTI = false;
            else LTI = true;
            Add_Lead.Enabled = IsEnabled();
        }

       

        private void knockerResponseIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            Add_Lead.Enabled = IsEnabled();
        }
        public string CreditForID = "";
       
        public AddLead()
        {
            InitializeComponent();


            if ((Address == null && ac.Address==null) || (ac.Cust == null && Cust == null))
                return;
            Address = Address == null ? ac.Address : Address;
            Cust = Cust == null ? ac.Cust : Cust;

            Task.Run(async () =>
            {
                await s1.GetAllCustomers();
                await s1.GetAllReferrers();


            });

            knockerResponseIDComboBox.DataSource = s1.KnockResponseTypes;
            leadTypeIDComboBox.DataSource = s1.LeadTypes;
            SalesPersonList = s1.EmployeesList.FindAll(x => x.EmployeeTypeID == 13);
            salesPersonIDComboBox.DataSource = SalesPersonList;
            KnockersList = s1.EmployeesList.FindAll(x => x.EmployeeTypeID == 14);
            ReferrersList = s1.ReferrersList;
            CustomersList = s1.CustomersList;
            customerIDComboBox.DataSource = s1.CustomersList;
           
            customerIDComboBox.SelectedItem = CustomersList.Find(x=>x.CustomerID == Cust.CustomerID);
            addressIDComboBox.SelectedItem = s1.AddressesList.Find(x=>x.AddressID == Address.AddressID);
            spi = true;
            KRI = true;
            LD = true;
            ci = true;
            addressIDComboBox.Text = Address.AddressID.ToString();
            ai = true;
            temperatureComboBox.SelectedIndex = 0;
            temp = true;
            Add_Lead.Enabled = IsEnabled();
        }

        List<CreditToIdResolution> CreditToListResolver(int ComboBoxSelectIndex, int AssociatedIDOf = -1)
        {
           

            switch (ComboBoxSelectIndex)
            {
                case 1:
                    {

                        return CreditToIDResolver.QualifiedCreditToRequestors.FindAll(x => x.TypeID == 1);
                         
                    }
                case 2:
                    {

                        return CreditToIDResolver.QualifiedCreditToRequestors.FindAll(x => x.TypeID == 2);

                    }
                case 3:
                    {

                        return CreditToIDResolver.QualifiedCreditToRequestors.FindAll(x => x.TypeID == 3);

                    }

                default:
                    {
                        return CreditToIDResolver.QualifiedCreditToRequestors.FindAll(x => x.TypeID == 5);
                    }

            }
          


        }

        async private void Add_Lead_Click(object sender, EventArgs e)
        {
            await aDD_Lead();

        }

        async Task<bool> aDD_Lead()
        {
            bool result = false;
            
            

                Lead = new DTO_Lead();

                Lead.LeadTypeID = leadTypeIDComboBox.SelectedIndex + 1;
                Lead.AddressID = ac.Address.AddressID;
            Lead.CreditToID = ((CreditToIdResolution)creditToIDComboBox.SelectedItem).ID;
                Lead.CustomerID = ac.Cust.CustomerID;
                Lead.KnockerResponseID = 2;
                Lead.LeadDate = leadDateDateTimePicker.Value;
            Lead.Status = 'a'; 
                Lead.SalesPersonID = ((DTO_Employee)salesPersonIDComboBox.SelectedItem).EmployeeID;
                Lead.Temperature = "Hot";
            CreditForID = ((CreditToIdResolution)creditToIDComboBox.SelectedItem).Name==null?" " : ((CreditToIdResolution)creditToIDComboBox.SelectedItem).Name;

            try
            {
                ac.Referrer = Referrer;
                ac.Lead = Lead;


               
            }
            
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }
            finally
            {
               
                ac.Refname = CreditForID;
                result = true;
            }
            if (result)
                this.DialogResult = DialogResult.OK;
            return result;
        }

        bool IsEnabled()
        {

            if (ai && ci && KRI && LD && LTI && spi && temp)
                return true;
            else return false;
        }

    }
    public class CreditToIdResolution
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int TypeID { get; set; }
        public override string ToString()
        {
            return Name.ToString();     
        }
    }

    public class CreditToIDResolver : BindingSource
    {
        public CreditToIDResolver()
        {
            Task.Run(async () => { await RefreshLists(); });
        }
        public static List<DTO_LU_LeadType> LeadTypes => ServiceLayer.getInstance().LeadTypes;
        public static List<DTO_Customer> Customers => ServiceLayer.getInstance().CustomersList;
        public static List<DTO_Referrer> Referrers => ServiceLayer.getInstance().ReferrersList;
        public static List<DTO_Employee> Knockers => ServiceLayer.getInstance().EmployeesList.FindAll(x=>x.EmployeeTypeID==13);
        public static List<DTO_Employee> Salespersons => ServiceLayer.getInstance().EmployeesList.FindAll(x => x.EmployeeTypeID == 14);
        static CreditToIDResolver resolver;
      
        public static List<CreditToIdResolution> QualifiedCreditToRequestors= BuildList();
             async static Task<bool> RefreshLists()
        {
            bool result = false;
          await  Task.Run(async () =>
            {
                await ServiceLayer.getInstance().GetAllCustomers();
                await ServiceLayer.getInstance().GetAllReferrers();
                await ServiceLayer.getInstance().GetAllEmployees();
            });
                result = true;
           
            return result;
        }

     static List<CreditToIdResolution> BuildList()
        {
            Task.Run(async () => {
                await RefreshLists();
            });

            List<CreditToIdResolution> objList = new List<CreditToIdResolution>();
            Customers.ForEach(x => objList.Add(new CreditToIdResolution { Name = x.FirstName + " " + x.LastName, ID = x.CustomerID, TypeID = 3 }));
            Referrers.ForEach(x => objList.Add(new CreditToIdResolution { Name = x.FirstName + " " + x.LastName, ID = x.ReferrerID, TypeID = 2 }));
            Knockers.ForEach(x => objList.Add(new CreditToIdResolution { Name = x.FirstName + " " + x.LastName, ID = x.EmployeeID, TypeID = 1 }));
            Salespersons.ForEach(x => objList.Add(new CreditToIdResolution { Name = x.FirstName + " " + x.LastName, ID = x.EmployeeID, TypeID = 5 }));
            return objList;
        }
      
        CreditToIDResolver GetResolverInstance()
        {
            if (resolver == null)
                resolver = new CreditToIDResolver();
            return resolver;
            
        }

    }


}
