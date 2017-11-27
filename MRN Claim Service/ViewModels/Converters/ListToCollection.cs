using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNUIElements.ViewModels.Converters
{
	class ListToCollection
	{



		private ObservableCollection<Type> list;
		public ObservableCollection<Type> Collection
		{
			get { return list; }

			set { list = value; }
		}


		public ListToCollection()
		{

		}
		
		public ObservableCollection<object> Convert(List<object> listToConvert)
		{
			if (listToConvert == null)
				return new ObservableCollection<object>();
			if (listToConvert.Count < 1)
				return new ObservableCollection<object>();	  
			ObservableCollection<object> b = new ObservableCollection<object>();
			foreach (var a in listToConvert)
						b.Add(a);
				   return b;
			
		}


	}
}

	
