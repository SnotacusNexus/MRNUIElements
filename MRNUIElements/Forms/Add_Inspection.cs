﻿using MRNNexus_Model;
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
    public partial class Add_Inspection : Form
    {


        static ServiceLayer s1 = ServiceLayer.getInstance();
        public DTO_Claim Claim { get; set; }

        public Add_Inspection()
        {
            InitializeComponent();
            ridgeMaterialTypeIDTextBox.DataSource = s1.RidgeMaterialTypes;
            shingleTypeIDTextBox.DataSource = s1.ShingleTypes;

        }
    }
}