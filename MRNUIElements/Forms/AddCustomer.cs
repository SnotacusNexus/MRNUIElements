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
        static AddClaim NewClaim = AddClaim.getAddClaimInstance();
        public AddCustomer()
        {
            InitializeComponent();
        }

    private void CustomerNextButtonbtn_Click(object sender, EventArgs e)
        {
           Add_Customer();
        }
        bool Add_Customer()
        {
            Cust = new DTO_Customer();

            bool result = false;
           
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
            try
            {
                NewClaim.Cust = Cust;

                if (s1.CustomersList != null && s1.CustomersList.Exists(x => x == Cust))
                {
                    var sb = new StringBuilder();
                    sb.Append(Cust.FirstName);
                    if (!string.IsNullOrEmpty(Cust.MiddleName))
                    {
                        sb.Append(" " + Cust.MiddleName);
                    }
                    sb.Append(" " + Cust.LastName);
                    if (!string.IsNullOrEmpty(Cust.Suffix))
                    {
                        sb.Append(" " + Cust.Suffix);
                    }

                    if (DialogResult.Yes == MessageBox.Show(sb.ToString() + "is already in the database as Customer ID # " + s1.CustomersList.Find(x => x == Cust).CustomerID.ToString(), "Customer Already Exist", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                        Cust.CustomerID = s1.CustomersList.Find(x => x == Cust).CustomerID;
                    if (Cust.CustomerID == 0)
                        return false;






                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.ToString());
               
            }
            finally
            {
                NewClaim.Cust = Cust;
                result = true;
               
                this.DialogResult = DialogResult.OK;

            }

            return result;

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
