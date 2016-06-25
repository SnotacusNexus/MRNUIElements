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
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class mScrollingText : UserControl
	{
		public mScrollingText(string messagetext=null)
		{
			InitializeComponent();
			
			if (messagetext == null) messagetext = "Set this to a list variable to populate all messages for this user.";
			SetValue(ContentProperty, messagetext);
		}
		
	}
}
