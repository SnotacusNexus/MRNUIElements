using MRNNexus_Model;
using MRNUIElements.Controllers;
using MRNUIElements.Forms;
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
    public partial class AddAddress : Form
    {

        ServiceLayer s1 = ServiceLayer.getInstance();
        public DTO_Customer Cust { get; set; }
        public DTO_Address Address { get; set; }
        bool zip = false, address = false;
        static AddClaim ac = AddClaim.getAddClaimInstance();
        public AddAddress()
        {
            InitializeComponent();


            if (Cust == null)
                return;

            customerNameTextBox.Text = ac.Cust.FirstName + " " + ac.Cust.LastName;
            customerIDTextBox.Text = ac.Cust.CustomerID.ToString();
        }

        async private void button1_Click(object sender, EventArgs e)
        {
           await Add_Address();
        }

        async Task<DTO_Address> Add_Address()
        {
            await s1.AddAddress(((DTO_Address)dTO_AddressBindingSource.Current));
            ac.Address = Address = s1.Address1;
            return Address;
        }

        private void addressTextBox_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(addressTextBox.Text))
                address = true;
            else
                address = false;
            button1.Enabled = IsEnabled();
        }

        private void zipTextBox_TextChanged(object sender, EventArgs e)
        { AddressZipcodeValidation azv = new AddressZipcodeValidation();
            if (!string.IsNullOrEmpty(zipTextBox.Text))
                zip = true; 
            else
                zip = false;
            if (zipTextBox.TextLength == 5)
            {
                sTTextBox.Text = azv.CityStateLookupRequest(zipTextBox.Text, 4);
                cityTextBox.Text = azv.CityStateLookupRequest(zipTextBox.Text, 3);
             button1.Enabled = IsEnabled();
            }

          

        }

        bool IsEnabled()
        {
            if (zip && address)
                return true;
            else return false;
        }
    }
}