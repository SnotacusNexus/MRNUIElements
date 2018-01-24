using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRN_Claim_Services.Models.Structure
{
	class Stucture
	{
		public int StructureID { get; set; }
		public ObservableCollection<Sub_Stucture> Sub_Structures { get; set; }
	}
}
