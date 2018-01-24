using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static MRN_Claim_Services.Models.Structure.Point3d;
using System.Windows.Media.Media3D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRN_Claim_Services.Models.Structure
{
	public class Lines
	{
		public static Lines L1;
		static public ObservableCollection<Lines> lines;
		static public ObservableCollection<Planes> planes = Planes.lgetInstance();
		static public ObservableCollection<Point3d> points = Point3d.lgetInstance();

		public string LineID { get; set; }
		public string StartingPointID { get; set; }
		public string EndingPointID { get; set; }
		public string Type { get; set; }
		public void line()
		{

		}
		public static Lines getInstance()
		{
			if (L1 == null)
			{
				L1 = new Lines();
			}

			return L1;
		}
		public static ObservableCollection<Lines> lgetInstance()
		{
			if (lines == null)
			{
				lines = new ObservableCollection<Lines>();
			}

			return lines;
		}
		public void AddLine(Lines l)
		{
			ObservableCollection<Lines> liner = lgetInstance();
			Lines w = new Structure.Lines();
			w = l;
			liner.Add(w);
		}
		public static System.Windows.Media.Media3D.Point3D GetLinePoints(string LID, int count)
		{
			foreach (Lines l in lines.Where((l => l.LineID == LID)))
			{

				if (count == 0)
					return new System.Windows.Media.Media3D.Point3D((double)Point3d._X, (double)Point3d._Y, (double)Point3d._Z);
				if (count == 1)
					return new System.Windows.Media.Media3D.Point3D((double)Point3d._X, (double)Point3d._Y, (double)Point3d._Z);
			}
			return new System.Windows.Media.Media3D.Point3D(0, 0, 0);
			;


		}
		public static string GetLinePoints(string LID, bool count)
		{
			foreach (Lines l in lines.Where((l => l.LineID == LID)))
			{

				if (count)
					return l.StartingPointID;
				else
					return l.EndingPointID;
			}

			return LID;


		}
	}

}