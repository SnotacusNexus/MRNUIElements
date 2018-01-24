using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MRN_Claim_Services.ViewModels;
using MRNNexus_Model;
using static MRN_Claim_Services.ClaimPickerPopUp;
using static MRN_Claim_Services.AddClaimDocumentation;
using static MRN_Claim_Services.InvoicePage;
using static MRN_Claim_Services.PaymentEntryPage;
using static MRN_Claim_Services.Claim_Administration;
using static MRN_Claim_Services.MainWindow;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows;

namespace MRN_Claim_Services.Interface.Command
{
	public class CloseCommand : ICommand
	{
		public ViewModelBase SaveCommand { get; set; }


		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			App.Current.MainWindow.Close();
		}


	}
	public class AddInvoiceCommand : ICommand
	{
		private Frame parameter;
		private DTO_Claim claim;
		public AddInvoiceCommand(Frame parameter, DTO_Claim Claim = null)
		{
			this.parameter = parameter;
			claim = (DTO_Claim)Application.Current.Properties["CurrentClaim"];

		}



		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{

			this.parameter.Navigate(new InvoicePage(claim));


		}


	}
	public class AddPaymentCommand : ICommand
	{
		private Frame parameter;
		private DTO_Claim claim;
		public AddPaymentCommand(Frame parameter, DTO_Claim Claim = null)
		{
			this.parameter = parameter;
			if (Claim != null)
				claim = Claim;
		}

		public ViewModelBase addPaymentCommand { get; set; }


		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			//this.parameter.Navigate(new PaymentEntryPage(claim,0));

		}


	}

	public class SelectClaimCommand : ICommand
	{
		private Frame parameter;
		private DTO_Claim claim;
		static ClaimPickerPopUp Cpp = new ClaimPickerPopUp();
		public SelectClaimCommand(Frame parameter, DTO_Claim Claim = null)
		{
			//var Cpp = new ClaimPickerPopUp();
			Application.Current.Properties["NavigationService"] = NavigationService.GetNavigationService(parameter);
			ClaimPickerPopUp.ns = getNavigationService();
			this.parameter = parameter;
			if (Application.Current.Properties["CurrentClaim"] == null)
				if ((bool)Cpp.ShowDialog())
					parameter.Navigate(new ViewClaimInfo((DTO_Claim)Application.Current.Properties["CurrentClaim"]));





		}



		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{

		//	this.parameter.Navigate(new ShowList());


		}


	}

	public static class RoutedCommands
	{
		static RoutedUICommand addInvoice = new RoutedUICommand("Add Invoice",
				"AddInvoice", typeof(RoutedCommands));
		public static RoutedUICommand AddInvoice { get { return addInvoice; } }


		static RoutedUICommand addPayment = new RoutedUICommand("Add Payment",
				"AddPayment", typeof(RoutedCommands));
		public static RoutedUICommand AddPayment { get { return addPayment; } }

	}
	public class ClaimCommands : ICommand
	{


		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			new Claim_Administration().AddInvoicePage(parameter as DTO_Claim);
		}


	}
}

























//}