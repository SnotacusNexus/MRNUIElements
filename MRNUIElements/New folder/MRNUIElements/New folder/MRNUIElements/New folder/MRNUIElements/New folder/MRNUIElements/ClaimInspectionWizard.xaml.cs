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
	/// Interaction logic for ClaimInspectionWizard.xaml
	/// </summary>
	public partial class ClaimInspectionWizard : Page
	{
		private string claimType;
		public ClaimInspectionWizard(int ClaimInspectionType)
		{
			if (ClaimInspectionType == 1) { claimType = "Gutter"; }
			if (ClaimInspectionType ==2) { claimType = "Exterior"; }
			if (ClaimInspectionType == 3) { claimType = "Interior"; }
			InitializeComponent();

		}

	


	}
}
