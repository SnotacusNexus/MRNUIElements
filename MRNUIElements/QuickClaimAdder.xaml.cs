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
using MRNUIElements.Controllers;
using MRNNexus_Model;
using MRNNexus_Model;
using System.Collections.ObjectModel;


namespace MRNUIElements
{
	/// <summary>
	/// Interaction logic for QuickClaimAdder.xaml
	/// </summary>
	public partial class QuickClaimAdder : UserControl
	{
		static DTO_Claim Claim;
		public DTO_Claim claim { get; set; }
		public QuickClaimAdder()
		{
			InitializeComponent();
			if (claim != null)
				Claim = claim;
		}



		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{

			// Do not load your data at design time.
			// if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
			// {
			// 	//Load your data here and assign the result to the CollectionViewSource.
			// 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
			// 	myCollectionViewSource.Source = your data
			// }
		}
	}
}
