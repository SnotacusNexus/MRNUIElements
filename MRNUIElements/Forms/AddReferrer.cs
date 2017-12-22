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

namespace MRNUIElements
{
    public partial class AddReferrer : Form
    {
        bool cp = false, fn = false, ln=false,ea = false, ma = false, zip=false;

        public DTO_Referrer Referrer { get; set; }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cellPhoneTextBox.Text))
                cp = true;
            else
                cp = false;
            AddRef.Enabled = IsEnabled();

        }

        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(firstNameTextBox.Text))
                fn = true;
            else
                fn = false;
            AddRef.Enabled = IsEnabled();

        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lastNameTextBox.Text))
                ln = true;
            else
                ln = false;
            AddRef.Enabled = IsEnabled();
        }

        private void mailingAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mailingAddressTextBox.Text))
                ma = true;
            else
                ma = false;
            AddRef.Enabled = IsEnabled();
        }

        private void zipTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(zipTextBox.Text))
                zip = true;
            else
                zip = false;
            AddRef.Enabled = IsEnabled();
        }

        ServiceLayer s1 = ServiceLayer.getInstance();
        public AddReferrer()
        {

            InitializeComponent();
           

        }

       async private void AddRef_Click(object sender, EventArgs e)
        {
            await Add_Referrer();

        }

      async Task<DTO_Referrer> Add_Referrer()
        {
           await s1.AddReferrer(((DTO_Referrer)dTO_ReferrerBindingSource.DataSource));
            Referrer = s1.Referrer;
            return s1.Referrer;
        }

        private void cellPhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cellPhoneTextBox.Text))
                cp = true;
            else
                cp = false;
            AddRef.Enabled = IsEnabled();

        }
        bool IsEnabled()
        {
            if ((cp && fn && ln && zip && ma && ea)||checkBox1.Checked)
                return true;
            else
                return false;
        }
    }
}
