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
                knockerResponseIDComboBox.DataSource = s1.KnockerResponsesList;
            else knockerResponseIDComboBox.Text = "No Knocker";
            Add_Lead.Enabled = IsEnabled();

        }

        public DTO_Customer Cust { get; set; }

        private void creditToIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DTO_LU_KnockResponseType)creditToIDComboBox.SelectedItem) == null)
                c2i = false;
            else c2i = true;
            Add_Lead.Enabled = IsEnabled();
        }

        private void customerIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (((DTO_Lead)customerIDComboBox.SelectedItem) == null)
            //    LTI = false;
            //else LTI = true;
            Add_Lead.Enabled = IsEnabled();
        }

        private void knockerResponseIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            Add_Lead.Enabled = IsEnabled();
        }

        List<DTO_Referrer> ReferrersList = new List<DTO_Referrer>();
        List<DTO_Customer> CustomersList = new List<DTO_Customer>();
        List<DTO_Employee> SalesPersonList = new List<DTO_Employee>();
        List<DTO_Employee> KnockersList = new List<DTO_Employee>();
        public DTO_Referrer Referrer { get; set; }
        public DTO_Lead Lead { get; set; }
        ServiceLayer s1 = ServiceLayer.getInstance();
        public AddLead()
        {
            InitializeComponent();


            if ((Address == null && ac.Address==null) || (ac.Cust == null && Cust == null))
                return;

            Task.Run(async () =>
            {
                await s1.GetAllCustomers();
                await s1.GetAllReferrers();


            });

            knockerResponseIDComboBox.DataSource = s1.KnockResponseTypes;

            SalesPersonList = s1.EmployeesList.FindAll(x => x.EmployeeTypeID == 13);
            salesPersonIDComboBox.DataSource = SalesPersonList;
            KnockersList = s1.EmployeesList.FindAll(x => x.EmployeeTypeID == 14);


            ReferrersList = s1.ReferrersList;
            CustomersList = s1.CustomersList;
            customerIDComboBox.SelectedIndex = CustomersList.IndexOf(Cust);
            addressIDComboBox.SelectedIndex = s1.AddressesList.IndexOf(Address);

            ci = true;
            addressIDComboBox.Text = Address.AddressID.ToString();
            ai = true;
            temperatureComboBox.SelectedIndex = 2;
            temp = true;
            Add_Lead.Enabled = IsEnabled();
        }

        List<string> CreditToListResolver(int ComboBoxSelectIndex, int AssociatedIDOf = -1)
        {
            var ReturnList = new List<string>();
            switch (ComboBoxSelectIndex)
            {
                case 0:
                    {

                        foreach (var item in KnockersList)
                        {
                            ReturnList.Add(item.FirstName + " " + item.LastName);
                            if (AssociatedIDOf > -1 && item.EmployeeID == AssociatedIDOf)
                            {
                                ((DTO_Lead)dTO_LeadBindingSource.Current).CreditToID = item.EmployeeID;
                                ReturnList.Clear();
                                ReturnList.Add(item.FirstName + " " + item.LastName);
                            }
                        }

                        break;
                    }
                case 1:
                    {
                        foreach (var item in ReferrersList)
                        {
                            ReturnList.Add(item.FirstName + " " + item.LastName);
                            if (AssociatedIDOf > -1 && item.ReferrerID == AssociatedIDOf)
                            {
                                ((DTO_Lead)dTO_LeadBindingSource.Current).CreditToID = item.ReferrerID;
                                ReturnList.Clear();
                                ReturnList.Add(item.FirstName + " " + item.LastName);

                            }
                        }

                        break;

                    }
                case 2:
                    {
                        foreach (var item in CustomersList)
                        {
                            ReturnList.Add(item.FirstName + " " + item.LastName);
                            if (AssociatedIDOf > -1 && item.CustomerID == AssociatedIDOf)
                            {
                                ((DTO_Lead)dTO_LeadBindingSource.Current).CreditToID = item.CustomerID;
                                ReturnList.Clear();
                                ReturnList.Add(item.FirstName + " " + item.LastName);
                            }
                        }
                        break;

                    }

                default:
                    {
                        foreach (var item in SalesPersonList)
                        {
                            ReturnList.Add(item.FirstName + " " + item.LastName);
                            if (AssociatedIDOf > -1 && item.EmployeeID == AssociatedIDOf)
                            {
                                ((DTO_Lead)dTO_LeadBindingSource.Current).CreditToID = item.EmployeeID;
                                ReturnList.Clear();
                                ReturnList.Add(item.FirstName + " " + item.LastName);
                            }
                        }
                        break;
                    }

            }
            return ReturnList;


        }

        async private void Add_Lead_Click(object sender, EventArgs e)
        {
            await aDD_Lead();

        }

        async Task<DTO_Lead> aDD_Lead()
        {

            await s1.AddLead(((DTO_Lead)dTO_LeadBindingSource.Current));
            Lead = s1.Lead;
            return Lead;
        }

        bool IsEnabled()
        {

            if (ai && ci && c2i && KRI && LD && LTI && spi && temp)
                return true;
            else return false;
        }

    }
}
