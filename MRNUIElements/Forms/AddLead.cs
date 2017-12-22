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

        private void leadTypeIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DTO_LU_LeadType)leadTypeIDComboBox.SelectedItem) == null)
                LTI = false;
            else LTI = true;
            if (((DTO_LU_LeadType)creditToIDComboBox.SelectedValue).LeadTypeID == 1)
                creditToIDComboBox.DataSource = s1.EmployeesList.FindAll(x => x.EmployeeTypeID == 13);
            else if (((DTO_LU_LeadType)creditToIDComboBox.SelectedValue).LeadTypeID == 2)
                creditToIDComboBox.DataSource = s1.CustomersList.FindAll(x => x.CustomerID
                 == Cust.CustomerID);
            else if (((DTO_LU_LeadType)creditToIDComboBox.SelectedValue).LeadTypeID == 3)
                creditToIDComboBox.DataSource = s1.ReferrersList;
            else 
                creditToIDComboBox.DataSource = s1.EmployeesList.FindAll(x => x.EmployeeTypeID == 13);
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
            if (((DTO_Lead)leadTypeIDComboBox.SelectedItem) == null)
                LTI = false;
            else LTI = true;
            Add_Lead.Enabled = IsEnabled();
        }

        private void knockerResponseIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public DTO_Referrer Referrer { get; set; }
        public DTO_Lead Lead { get; set; }
        ServiceLayer s1 = ServiceLayer.getInstance();
        public AddLead()
        {
            InitializeComponent();
            if (Address == null || Cust == null)
                return;
            customerIDComboBox.Text=Cust.CustomerID.ToString();
            ci = true;
          addressIDComboBox.Text=Address.AddressID.ToString();
            ai = true;

        }


        async private void Add_Lead_Click(object sender, EventArgs e)
        {
            await aDD_Lead();

        }

        async Task<DTO_Lead> aDD_Lead()
        {

            await s1.AddLead(((DTO_Lead)dTO_LeadBindingSource.DataSource));
            Lead = s1.Lead;
            return Lead;
        }

        bool IsEnabled()
        {

            if(ai && ci && c2i && KRI && LD && LTI && spi && temp)
            return true;
            else return false;
        }

    }
}
