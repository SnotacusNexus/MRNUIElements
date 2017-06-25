using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using MRNNexus_Model;
using MRNUIElements.Controllers;
using MRNUIElements.Controllers.Collection;

using HelixToolkit.Wpf;
using HelixToolkit;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using static MRNUIElements.RoofMeasurmentsPage;
using MRNUIElements.RoofOrder;




namespace MRNUIElements.Models
{
	public class EagleViewPlaneMeasurement:DTO_Plane
	{
		public double SquaresOff { get; set; }
		public int RakesLength { get; set; }
		public int EavesLength { get; set; }
		public int RidgeLengths { get; set; }
		public int HipLenth { get; set; }
		public int  ValleyLength { get; set; }
		public int PredPitch { get; set; }
		
		public int DripEdge { get; set; }
		public int Starter { get; set; }
		public Uri ViewOnline { get; set; }
		public Uri Directions { get; set; }
		public int TotalPlanes { get; set; }

		public long Latitude { get; set; }
		public long Longitude { get; set; }

	}
	public class RoofMaterialOrder : ObservableCollection<DTO_OrderItem>
	{
		public static DTO_OrderItem Shingle { get; set; }
		public static DTO_OrderItem StarterStrip { get; set; }
		public static DTO_OrderItem HipAndRidgeBdl { get; set; }
		public static DTO_OrderItem Underlayment { get; set; }
		public static DTO_OrderItem IceAndWater { get; set; }
		public static DTO_OrderItem TurtleBacks { get; set; }
		public static DTO_OrderItem Ridgevent { get; set; }
		public static DTO_OrderItem DripEdge { get; set; }
		public static DTO_OrderItem PJB3 { get; set; }
		public static DTO_OrderItem PJB4 { get; set; }
		public static DTO_OrderItem OSB { get; set; }
		public static DTO_OrderItem CoilNails { get; set; }
		public static DTO_OrderItem PlasticCaps { get; set; }
		public static DTO_OrderItem Caulk { get; set; }
		public static DTO_OrderItem Paint { get; set; }

		public RoofMaterialOrder()
		{

		}
		
		

	}
	public class EagleViewPlaneMeasurementConverter : EagleViewPlaneMeasurement
	{

		public EagleViewPlaneMeasurementConverter(DTO_Inspection inspection)
		{
			Go(inspection);
		}

		async void Go(DTO_Inspection inspection)
		{
			new RoofMeasurmentsPage(new DTO_Claim { ClaimID = await GetClaimIDFromPlane(inspection) });
		}
		
		public async Task<int> GetClaimIDFromPlane(DTO_Inspection inspection)
		{
			await ServiceLayer.getInstance().GetAllInspections();
			return (int)((DTO_Inspection)ServiceLayer.getInstance().InspectionsList.Select(x => x.InspectionID == inspection.InspectionID)).ClaimID;




		}












	}
}
