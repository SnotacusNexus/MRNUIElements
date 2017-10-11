using MRNNexus_Model;
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

namespace MRNUIElements
{
	/// <summary>
	/// Interaction logic for Working.xaml
	/// </summary>
	public partial class PageFunction : PageFunction<object>
	{
		DTO_Scope scope = new DTO_Scope();
		DTO_Payment payment = new DTO_Payment();
		DTO_Invoice invoice = new DTO_Invoice();
		DTO_Claim claim = new DTO_Claim();
		public PageFunction()
		{
			InitializeComponent();
			

		}
	
		private void button2_Click(object sender, RoutedEventArgs e)
		{
			scope.ClaimID = claim.ClaimID;
			scope.Deductible = 1000;
			scope.Exterior = 600;
			scope.Gutter = 995;
			scope.Interior = 2040;
			scope.OandP = 900;
			scope.ScopeTypeID = 2;
			scope.Tax = 345.87;
			scope.Total = 80021.35;
			scope.RoofAmount = scope.Total - scope.Tax - scope.OandP - scope.Interior - scope.Gutter - scope.Exterior;
		}

		private void Button3_Click(object sender, RoutedEventArgs e)
		{
			

			//Create instance of ReturnEventArgs to pass data back to caller page
			ReturnEventArgs<object> returnObject = new ReturnEventArgs<object>((object)scope);

			//Call to PageFunction's OnReturn method and pass selected List 
			//This will be handled by apage_Return on HomePage.xaml
			OnReturn(returnObject);
		}
		
		

	}
}