using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MRNNexus_Model;
using MRNUIElements.Controllers;

namespace MRNUIElements.Viewers
{
	/// <summary>
	/// Interaction logic for PdfViewer.xaml
	/// </summary>
	public partial class PdfViewer : UserControl
	{
		public string DocumentPath { get; set; }
		public static ServiceLayer s1 = ServiceLayer.getInstance();
		
		#region Constructor
		public PdfViewer()
		{
			InitializeComponent();

			pdfviewer1.Load(DocumentPath);
		  
		}
		#endregion

	
	  
	}
}

