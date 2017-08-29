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

namespace MRNUIElements.Controllers
{
	/// <summary>
	/// Interaction logic for ReqCashEst.xaml
	/// </summary>
	public partial class ReqCashEst : Page
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
		static MRNClaim MrnClaim;
		public ReqCashEst(MRNClaim MrnClaim)
		{
			InitializeComponent();
			ReqCashEst.MrnClaim = MrnClaim;
		}
	}
}
