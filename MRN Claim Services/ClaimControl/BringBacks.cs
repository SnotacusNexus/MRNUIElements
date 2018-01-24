using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRNNexus_Model;
using System.Collections.ObjectModel;

namespace MRN_Claim_Services.Controllers
{
	public class BringBacks : DTO_AdditionalSupply
	{

		public static BringBacks _BringBacks;
		public static DTO_Order Order;
		public ObservableCollection<DTO_OrderItem> Products { get; set; }
		public bool ToJob { get; set; } = false;

	}
}
