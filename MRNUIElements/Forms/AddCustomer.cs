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
    { ServiceLayer s1 = ServiceLayer.getInstance();
        bool cp = false, fn = false, ln = false, ea = false, ma = false;
        public DTO_Customer Cust { get; set; }
        public AddCustomer()
        {
            InitializeComponent();
        }

       async private void CustomerNextButtonbtn_Click(object sender, EventArgs e)
        {
            await Add_Customer();
        }
        async Task<DTO_Customer> Add_Customer()
        {
            await s1.AddCustomer(((DTO_Customer)dTO_CustomerBindingSource.DataSource));
                Cust = s1.Cust;
            return Cust;

        }

       
private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(emailTextBox.Text))
                cp = true;
            else
                cp = false;
            CustomerNextButtonbtn.Enabled = IsEnabled();

        }

        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(firstNameTextBox.Text))
                cp = true;
            else
                cp = false;
            CustomerNextButtonbtn.Enabled = IsEnabled();

        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lastNameTextBox.Text))
                cp = true;
            else
                cp = false;
            CustomerNextButtonbtn.Enabled = IsEnabled();
        }

        private void primaryNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lastNameTextBox.Text))
                cp = true;
            else
                cp = false;
            CustomerNextButtonbtn.Enabled = IsEnabled();
        }
        bool IsEnabled()
        {
            if (cp && fn && ln && ma && ea) 
                return true;
            else
                return false;
        }


    }
}
