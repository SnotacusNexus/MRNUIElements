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
    public partial class AddCustomer : Form
    {
        ServiceLayer s1 = ServiceLayer.getInstance();
        bool fn = false, ln = false, pn = false, ea = false, ma = false;
        public DTO_Customer Cust { get; set; }
        static AddClaim ac = AddClaim.getAddClaimInstance();
        public AddCustomer()
        {
            InitializeComponent();
        }

        async private void CustomerNextButtonbtn_Click(object sender, EventArgs e)
        {
            await Add_Customer();
        }
        async Task<bool> Add_Customer()
        {
            Cust = new DTO_Customer();
           
         
                // ac.Cust.CustomerID = ((DTO_Customer)dTO_CustomerBindingSource.DataSource).CustomerID;
                Cust.FirstName = firstNameTextBox.Text;
                Cust.LastName = lastNameTextBox.Text;
                Cust.MailPromos = mailPromosCheckBox.Checked;
                Cust.PrimaryNumber = primaryNumberTextBox.Text;
                try
                {
                    Cust.MiddleName = middleNameTextBox.Text;
                }
                catch (NullReferenceException nre) { }
                try
                { Cust.Suffix = suffixTextBox.Text; }
                catch (NullReferenceException nre) { }
                try
                {
                 Cust.SecondaryNumber = secondaryNumberTextBox.Text;
                }
                catch (NullReferenceException nre) { }
                try
                { Cust.Email = emailTextBox.Text; }
                catch (NullReferenceException nre) { }

                await s1.AddCustomer(Cust);
                ac.Cust = s1.Cust;
            return true;

        }


        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(emailTextBox.Text))
                ea = true;
            else
                ea = false;
            CustomerNextButtonbtn.Enabled = IsEnabled();

        }

        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(firstNameTextBox.Text))
                fn = true;
            else
                fn = false;
            CustomerNextButtonbtn.Enabled = IsEnabled();

        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lastNameTextBox.Text))
                ln = true;
            else
                ln = false;
            CustomerNextButtonbtn.Enabled = IsEnabled();
        }

        private void primaryNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(primaryNumberTextBox.Text))
                pn = true;
            else
                pn = false;
            CustomerNextButtonbtn.Enabled = IsEnabled();
        }
        bool IsEnabled()
        {
            if (pn && fn && ln && ea)
                return true;
            else
                return false;
        }


    }
}
