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
            


            if (ac.Cust == null)
                return;

            customerNameTextBox.Text = ac.Cust.FirstName + " " + ac.Cust.LastName;
            customerIDTextBox.Text = ac.Cust.CustomerID.ToString();
        }

        async private void button1_Click(object sender, EventArgs e)
        {
           await Add_Address();
        }

        async Task<bool> Add_Address()
        {
            bool result = false;
            //dTO_AddressBindingSource.GetItemProperties
            try
            {
             ac.Address = new DTO_Address { Address = addressTextBox.Text, Zip = zipTextBox.Text, CustomerID = Cust.CustomerID };
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                
                result = true;
            }

            this.DialogResult = DialogResult.OK;
            return result;
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
                textBox3.Text = azv.CityStateLookupRequest(zipTextBox.Text, 5);
                textBox2.Text = azv.CityStateLookupRequest(zipTextBox.Text, 3);
             button1.Enabled = IsEnabled();
            }

          

        }

        private void AddAddress_Load(object sender, EventArgs e)
        {


        }

        bool IsEnabled()
        {
            if (zip && address)
                return true;
            else return false;
        }
    }
}