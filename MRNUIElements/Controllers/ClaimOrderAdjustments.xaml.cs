using MRNNexus_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MRNUIElements.Controllers
{


	
	/// <summary>
	/// Interaction logic for ClaimOrderAdjustments.xaml
	/// </summary>
	public partial class ClaimOrderAdjustments : Page
	{


		ServiceLayer s1 = ServiceLayer.getInstance();
		public ObservableCollection<DTO_OrderItem> orderItem { get; set; }
		public ObservableCollection<BringBacks> adjustmentItems { get; set; }

		public ClaimOrderAdjustments()
		{
			adjustmentItems = new ObservableCollection<BringBacks>();
			InitializeComponent();
			Task.Run(async () => await getAdditionalSupplies());
			AdjustmentList.ItemsSource = adjustmentItems;
			
		}

		private async void Button_Click(object sender, RoutedEventArgs e)
		{

			var item = (DTO_OrderItem)OrderList.SelectedItem;
			var product = s1.Products.Find(x => x.ProductID == item.ProductID);
			var a = new BringBacks { Cost = (double)QuantityIntBox.Value * product.Price, PickUpDate = DateTime.Today, Items = product.Name, ReceiptImagePath = "", ClaimID = ClaimView._Claim.ClaimID, DropOffDate = DateTime.Today };
			//UploadPhotoOfReceipt
			var b = new DTO_AdditionalSupply { ClaimID = ClaimView._Claim.ClaimID, Cost = a.Cost, DropOffDate = DateTime.Today, ReceiptImagePath = "", Items = product.Name, PickUpDate = DateTime.Today };
			a.Products.Add(item);
			adjustmentItems.Add(a);
			try
			{
				await s1.AddAdditionalSupply(b);
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			if (b.Message == null)
				System.Windows.Forms.MessageBox.Show("Successful Upload");
		}

		private void OrderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (OrderList.SelectedItem != null && QuantityIntBox.Value != 0)
				ApplyBtn.IsEnabled = true;
			else ApplyBtn.IsEnabled = false;
		}
		private void addItem(DTO_OrderItem item)
		{
			var product = s1.Products.Find(x => x.ProductID == item.ProductID);
			var a = new BringBacks { Cost = (double)QuantityIntBox.Value * product.Price, PickUpDate=DateTime.Today, Items=product.Name, ReceiptImagePath="", ClaimID=ClaimView._Claim.ClaimID, DropOffDate=DateTime.Today};
			//UploadPhotoOfReceipt
			var b = new DTO_AdditionalSupply { ClaimID = ClaimView._Claim.ClaimID, Cost = a.Cost, DropOffDate = DateTime.Today, ReceiptImagePath = "", Items = product.Name, PickUpDate = DateTime.Today };
			a.Products.Add(item);
			adjustmentItems.Add(a);
			
		}

		private void QuantityIntBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (OrderList.SelectedItem != null && QuantityIntBox.Value != 0)
				ApplyBtn.IsEnabled = true;
			else ApplyBtn.IsEnabled = false;
		}
		private async Task<bool> getAdditionalSupplies()
		{
			await s1.GetAllAdditionalSupplies();
			if (s1.AdditionalSuppliesList != null)
				if (s1.AdditionalSuppliesList.Count > 0)
					return true;
			return false;
		}
	}

}
