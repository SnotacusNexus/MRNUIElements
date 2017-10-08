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
        static ServiceLayer s1 = ServiceLayer.getInstance();
		public  DTO_OrderItem Shingle { get; set; }
		public  DTO_OrderItem StarterStrip { get; set; }
		public  DTO_OrderItem HipAndRidgeBdl { get; set; }
		public  DTO_OrderItem Underlayment { get; set; }
		public  DTO_OrderItem IceAndWater { get; set; }
		public  DTO_OrderItem TurtleBacks { get; set; }
		public  DTO_OrderItem Ridgevent { get; set; }
		public  DTO_OrderItem DripEdge { get; set; }
		public  DTO_OrderItem PJB3 { get; set; }
		public  DTO_OrderItem PJB4 { get; set; }
		public  DTO_OrderItem OSB { get; set; }
		public  DTO_OrderItem CoilNails { get; set; }
		public  DTO_OrderItem PlasticCaps { get; set; }
		public  DTO_OrderItem Caulk { get; set; }
		public  DTO_OrderItem Paint { get; set; }
        
        public RoofMaterialOrder()
		{

		}
        async Task<DTO_Inspection> getInspectionForClaim(DTO_Claim claim)
        {
            await s1.GetAllClaims();
            var _claim = new DTO_Claim();
            _claim = s1.ClaimsList.Find(x => x.ClaimID == claim.ClaimID); 

            List<DTO_Inspection> inspectionslist = new List<DTO_Inspection> ( s1.InspectionsList.FindAll(x => x.ClaimID == _claim.ClaimID));
            //TODO:inspection selector would be nice here


            return inspectionslist.FindLast(x => x.ClaimID == _claim.ClaimID);
        }

        async void init(DTO_Claim claim)
        {
            DTO_Inspection inspection =  await getInspectionForClaim(claim);
            var newroof = s1.NewRoofsList.Find(x => x.ClaimID == claim.ClaimID);
            var temprooforderitems = GenerateCompleteRoofOrder(inspection, newroof, new DTO_Order { OrderID = 0 });
            //TODO: Call Scheduler to Fillout OrderFinished Order
            var order = s1.OrdersList.Find(x => x.ClaimID == claim.ClaimID);//this can only becalled when the page return with valid data
            await GenerateCompleteRoofOrder(await getInspectionForClaim(claim),newroof,)
        }
		public async Task<List<DTO_OrderItem>> GenerateCompleteRoofOrder(DTO_Inspection inspection, DTO_NewRoof newRoofSpecs, DTO_Order order)
        {
            List<DTO_Plane> Measurements = new List<DTO_Plane>(s1.PlanesList.FindAll(x => x.InspectionID == inspection.InspectionID));
            
            await s1.GetAllClaims();

            DTO_Claim claim = s1.ClaimsList.Find(x => x.ClaimID == inspection.ClaimID);
            var orderlist = new List<DTO_OrderItem>();

            int TotalEaves = 0;
            int TotalRidges = 0;
            double TotalSquareFootage = 0;
            int pJB3 = 0;
            int pJB4 = 0;
            int Hips = 0;
            int Valleys = 0;
            int Rakes = 0;
            int Pitches = 0;
            int AveragePitch = 0;
            int AverageEaveHeight = 0;
            int LowestPlaneHeight = 0;
            int LowestPlaneID = 0;
            int HeighestPlaneHeight = 0;
            int HeighestPlaneID = 0;
            int NumberOfPlanes = 0;
            int TotEaveHeight = 0;
            int turtleBacks = 0; 


            int a = 0;
            foreach (var p in Measurements)
            {
                a++;

                TotalEaves += (int)p.EaveLength;
                pJB4 += (int)p.FourAndUp;
                p.GroupNumber = a;
                Hips += (int)p.Hip;
                Valleys += (int)p.Valley;
                p.ItemSpec = "";
                Pitches += (int)p.Pitch;
                Rakes += (int)p.RakeLength;
                TotalRidges += (int)p.RidgeLength;
                TotalSquareFootage += (double)p.SquareFootage;
                pJB3 += (int)p.ThreeAndOne;
                TotEaveHeight += (int)p.EaveHeight;
                AverageEaveHeight = (int)TotEaveHeight / a;
                AveragePitch = (int)Pitches / a;
                turtleBacks += (int)p.TurtleBacks;

            }
            int dripEdge = 0;
            if (newRoofSpecs.DripEdgeInstall)
                if (newRoofSpecs.RakesOnly)
                    dripEdge = Rakes;
                else
                    dripEdge = Rakes + TotalEaves;
            else
                dripEdge = 0;
            double pcDripEdge = dripEdge * .9 + 1;
            double bdlStarter = Math.Ceiling((double)(Rakes + TotalEaves) / 100);
            double bdlHRShingle = Math.Ceiling((double)(Hips + TotalRidges) / 26);
            double bdlShingles = Math.Ceiling((double)(TotalSquareFootage) / 100) * 3;
            double rollValleyFlashing = Math.Ceiling((double)(Valleys) / 68);
            double ridgevent = Math.Ceiling((double)(TotalRidges) / 4);
            
            Shingle.ProductID = newRoofSpecs.ProductID;
            Shingle.OrderID = order.OrderID;
            Shingle.Quantity = (int)bdlShingles;
            orderlist.Add(Shingle);
            StarterStrip.ProductID = 70;
            StarterStrip.OrderID = order.OrderID;
            StarterStrip.Quantity = (int)bdlStarter;
            orderlist.Add(StarterStrip);
            HipAndRidgeBdl.ProductID = newRoofSpecs.HipRidgePID;
            HipAndRidgeBdl.OrderID = order.OrderID;
            HipAndRidgeBdl.Quantity = (int)bdlHRShingle;
            orderlist.Add(HipAndRidgeBdl);
            Underlayment.ProductID = newRoofSpecs.UnderlaymentPID;
            Underlayment.OrderID = order.OrderID;
            Underlayment.Quantity = (int)((bdlShingles / 3)/((int)int.Parse((string)s1.Products.Find(x=>x.ProductID==Underlayment.ProductID).Info)));
            orderlist.Add(Underlayment);
            IceAndWater.ProductID = newRoofSpecs.ValleyUnderlaymentPID;
            IceAndWater.OrderID = order.OrderID;
            IceAndWater.Quantity = (int)rollValleyFlashing;
            orderlist.Add(IceAndWater);
            TurtleBacks.ProductID = 77;
            TurtleBacks.OrderID = order.OrderID;
            TurtleBacks.Quantity = newRoofSpecs.Comments.IndexOf("Fill")>0?0 : (int)turtleBacks;
            orderlist.Add(TurtleBacks);
            Ridgevent.ProductID = newRoofSpecs.RidgeVentPID;
            Ridgevent.OrderID = order.OrderID;
            Ridgevent.Quantity = (int)ridgevent;
            orderlist.Add(Ridgevent);
            DripEdge.ProductID = newRoofSpecs.DripEdgePID;
            DripEdge.OrderID = order.OrderID;
            DripEdge.Quantity = (int)pcDripEdge;
            orderlist.Add(DripEdge);
            PJB3.ProductID = 62;
            PJB3.OrderID = order.OrderID;
            PJB3.Quantity = pJB3;
            orderlist.Add(PJB3);
            PJB4.ProductID = 63;
            PJB4.OrderID = order.OrderID;
            PJB4.Quantity =pJB4;
            orderlist.Add(PJB4);
            OSB.ProductID = 75;
            OSB.OrderID = order.OrderID;
            OSB.Quantity = 2;
            orderlist.Add(OSB);
            CoilNails.ProductID = 71;
            CoilNails.OrderID = order.OrderID;
            CoilNails.Quantity = (int)Math.Ceiling((double)(Shingle.Quantity / 3) / 16);
            orderlist.Add(CoilNails);
            PlasticCaps.ProductID = 72;
            PlasticCaps.OrderID = order.OrderID;
            PlasticCaps.Quantity = (int)Math.Ceiling((double)(Shingle.Quantity / 3) / 20);
            orderlist.Add(PlasticCaps);
            Caulk.ProductID = 74;
            Caulk.OrderID = order.OrderID;
            Caulk.Quantity = 3;
            orderlist.Add(Caulk);
            Paint.ProductID = 73;
            Paint.OrderID = order.OrderID;
            Paint.Quantity = 3;
            orderlist.Add(Paint);
            return orderlist; 
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
