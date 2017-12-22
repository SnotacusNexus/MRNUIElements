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
    public partial class AddClaim : Form
    {
        ServiceLayer s1 = ServiceLayer.getInstance();
        public DTO_Lead Lead { get; set; }
        public DTO_Claim Claim { get; set; }
        public DTO_Address Address { get; set; }
        public DTO_Referrer Referrer { get; set; }
        public DTO_Customer Cust { get; set; }
        public AddClaim()
        {
            InitializeComponent();
            Claim = new DTO_Claim();
                     
        }

        async Task<DTO_Claim> Add_Claim()
        {
            await s1.AddClaim(((DTO_Claim)dTO_ClaimBindingSource.DataSource));
            Claim = s1.Claim;
            return Claim;
        }

       async private void button1_Click(object sender, EventArgs e)
        {
            await Add_Claim();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddLead al = new AddLead();
            if (DialogResult.OK == al.ShowDialog())
                Lead = al.Lead;
            if (al.Lead != null)
                AddClaimBtn.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddAddress ad = new AddAddress();
            if (DialogResult.OK == ad.ShowDialog())
                Address = ad.Address;
            if (ad.Address != null)
                AddClaimBtn.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            AddCustomer ac = new AddCustomer();
            if (DialogResult.OK == ac.ShowDialog())
                Cust = ac.Cust;
            if (ac.Cust != null)
                AddClaimBtn.Enabled = true;
        }
    }
}
