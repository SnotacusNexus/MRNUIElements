using MRNNexus_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace MRNUIElements.Controllers
{
	/// <summary>
	/// Interaction logic for InvoiceView.xaml
	/// </summary>
	public partial class InvoiceView : Page
	{

		static ServiceLayer s1 = ServiceLayer.getInstance();
		public static List<DTO_Invoice> InvoiceList;
		public static ObservableCollection<ClaimInvoice> ClaimInvoices;


		
		public InvoiceView()
		{
			InitializeComponent();


			ClaimInvoices = new ObservableCollection<ClaimInvoice>();
			InvoiceList = s1.InvoicesList.FindAll(x => x.ClaimID == 19);
		
			foreach (var item in InvoiceList)
			{
				var a = new ClaimInvoice();
				
				a.VendorCompanyName = s1.VendorsList.Find(x=> x.VendorID ==7).CompanyName;
				a.InvoiceAmount = item.InvoiceAmount;
				a.InvoiceDate = item.InvoiceDate;
				a.InvoiceType = s1.InvoiceTypes.Find(x => x.InvoiceTypeID == item.InvoiceTypeID).InvoiceType;
				ClaimInvoices.Add(a);
			}
			ListView.ItemsSource = ClaimInvoices;
					
		}
	}
}
