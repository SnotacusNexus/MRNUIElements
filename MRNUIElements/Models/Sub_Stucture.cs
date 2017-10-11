using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MRNUIElements.Models.Structure
{
	class Sub_Stucture
	{
		public int SubStructureID { get; set; }
		public ObservableCollection<Planes> Planes { get; set; }
		public int Level { get; set; }
	}
}
