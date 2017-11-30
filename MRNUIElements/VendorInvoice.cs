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
    public partial class VendorInvoice : Form
    {
        public ImageViewer imageViewer = new ImageViewer();
       
        public VendorInvoice()
        {
            InitializeComponent();
            imageViewer.Path = openFileDialog1.FileName;
           
            elementHost1.Child = imageViewer;
        }
    }
}
