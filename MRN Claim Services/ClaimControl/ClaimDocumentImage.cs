using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRN_Claim_Services.Controllers
{
	class ClaimDocumentImage
	{
		public string Path { get; set; }
		public string  Name { get; set; }
		public string Commment {get; set; }

		public static ObservableCollection<ClaimDocumentImage> ClaimDocImage;
		public ClaimDocumentImage CDI = new ClaimDocumentImage();
		public ClaimDocumentImage ClaimDocImgProp { get; set; }


	}
}
