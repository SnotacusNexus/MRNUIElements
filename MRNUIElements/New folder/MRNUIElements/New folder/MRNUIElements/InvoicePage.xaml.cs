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

namespace MRNUIElements
{


	/// <summary>
	/// Interaction logic for InvoicePage.xaml
	/// </summary>
	public partial class InvoicePage : Page
	{
		ServiceLayer s1 = ServiceLayer.getInstance();

		public InvoicePage()
		{
			InitializeComponent();
			this.comboBox.DataContext = s1.ClaimsList;
			this.comboBox1.DataContext = s1.InvoiceTypes;
			textBox_Copy4.Text = "0";
		}

		async private void SubmitScopeEntry_Click(object sender, RoutedEventArgs e)
		{
			if (comboBox.SelectedIndex > -1)
				if (comboBox1.SelectedIndex > -1)
					if (InvoiceDatePicker.SelectedDate != null)
					{
						DTO_Invoice i = new DTO_Invoice();

						i.InvoiceDate = InvoiceDatePicker.SelectedDate.Value;
						i.InvoiceTypeID = ((DTO_LU_InvoiceType)comboBox1.SelectedValue).InvoiceTypeID;
						i.InvoiceAmount = double.Parse(textBox_Copy4.Text);
						i.ClaimID = ((DTO_Claim)comboBox.SelectedValue).ClaimID;
						i.Paid = true;
						await s1.AddInvoice(i);



						if (s1.Invoice.Message == null)
						{
							MessageBox.Show(s1.Invoice.InvoiceID.ToString());
						}
						else
						{
							MessageBox.Show(s1.Invoice.Message);
						}
					}
					else MessageBox.Show("Select a date");
				else MessageBox.Show("Select an Invoice Type");
			else MessageBox.Show("Select a Claim Number");
		}

		private void CancelScopeEntry_Click(object sender, RoutedEventArgs e)
		{
			NexusHome Page = new NexusHome();
			this.NavigationService.Navigate(Page);
		}

	private void textBox_Copy4_TextChanged(object sender, TextChangedEventArgs e)
		{
			double d = 0;
			if (textBox_Copy4.Text == string.Empty) textBox_Copy4.Text = "0";
			if (textBox_Copy4.Text != string.Empty) SubmitScopeEntry.IsEnabled = true;
			if (!double.TryParse(textBox_Copy4.Text, out d)) MessageBox.Show("Not a valid value.");
			 
		}

		private void InvoiceDatePicker_CalendarClosed(object sender, RoutedEventArgs e)
		{
			
		}

		async private void UploadImage_Click(object sender, RoutedEventArgs e)
		{
			var fileDialog = new System.Windows.Forms.OpenFileDialog();
			var result = fileDialog.ShowDialog();
			switch (result)
			{
				case System.Windows.Forms.DialogResult.OK:
					var file = fileDialog.FileName;
					
					var onlyFileName = System.IO.Path.GetFileNameWithoutExtension(file);
					if (comboBox1.SelectedItem.ToString() == string.Empty || comboBox1.SelectedItem.ToString() == null)
						onlyFileName = comboBox1.SelectedItem.ToString();
					onlyFileName = onlyFileName.Replace(" ", "_");

					byte[] imageBytes = System.IO.File.ReadAllBytes(file);
					string ext = System.IO.Path.GetExtension(file);

					//	SaveTo(AddTextToImage(TextToOverlayPicture.Text, onlyFileName), onlyFileName + "TextAdded");      //Get Text overlay display pic rename image prepare for upload after modifications

					DTO_ClaimDocument documentUploadRequest = new DTO_ClaimDocument
					{
						FileBytes = Convert.ToBase64String(imageBytes),
						FileName = onlyFileName,
						FileExt = ext,
						ClaimID = int.Parse(comboBox.Text),
						DocTypeID = comboBox1.SelectedIndex,
						DocumentDate = DateTime.Now
					};


					await s1.AddClaimDocument(documentUploadRequest);

					//SAVING FILES TO DISK
					//string filename = fileDialog.FileName = @"newfile" + ext;

					//using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
					//{
					//    saveFileDialog1.FileName = filename;
					//    if (System.Windows.Forms.DialogResult.OK != saveFileDialog1.ShowDialog())
					//        return;
					//    System.IO.File.WriteAllBytes(saveFileDialog1.FileName,Convert.FromBase64String(s1.ClaimDocument.FileBytes));
					//}
					break;
				case System.Windows.Forms.DialogResult.Cancel:
				default: return;
					
			}
		}
	}
}
