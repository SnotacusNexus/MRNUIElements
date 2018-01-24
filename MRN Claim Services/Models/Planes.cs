using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media.Media3D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRN_Claim_Services.Models.Structure
{
	public class Planes
	{
		public static Planes P1;
		static public ObservableCollection<Lines> lines = Lines.lgetInstance();
		static public ObservableCollection<Planes> planes;
		static public ObservableCollection<Point3d> points = Point3d.lgetInstance();

		public string PlaneID { get; set; }
		public string LineId { get; set; }
		public string Orientation { get; set; }
		public string Pitch { get; set; }
		public Planes()
		{

		}

		public static IList<System.Windows.Media.Media3D.Point3D> GetPlaneCoords(string PlaneId)
		{
			List<string> pointlist = new List<string>();
			// List<string> linelist = new List<string>();
			bool firsttime = true;
			int i = 1; string v = "";
			foreach (Planes p in planes.Where(p => p.PlaneID == PlaneId))
			{
				//     linelist.Add(Planes.LineId);
			}
			int j = 0; //linecounter
			foreach (Lines l in lines)
			{
				//    if (l.LineID == linelist[j])
				{

					string t = lines[j].StartingPointID; //GetStartPointID
					string u = lines[j].EndingPointID; //GetEndPointID
					pointlist.Add(t);
					pointlist.Add(u);
					j++;            //advanceLineCounter set in for next Line available 

				}

			}
			IList<System.Windows.Media.Media3D.Point3D> pt3D = new List<System.Windows.Media.Media3D.Point3D>();

			foreach (string s in pointlist)
			{
				if (Point3d._PointID == s)
				{
					pt3D.Add(new System.Windows.Media.Media3D.Point3D((double)Point3d._X, (double)Point3d._Y, (double)Point3d._Z));
				}
			}
			return pt3D;
		}
		public static Planes getInstance()
		{
			if (P1 == null)
			{
				P1 = new Planes();
			}

			return P1;
		}
		public static ObservableCollection<Planes> lgetInstance()
		{
			if (planes == null)
			{
				planes = new ObservableCollection<Planes>();
			}

			return planes;
		}

	}
}
