using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNUIElements.Models.Structure
{
  
        public class Point3d
        {
        public static Point3d O1;
            static public ObservableCollection<Point3d> points { get; set; }
            public string PointID { get; set; }
            public decimal X { get; set; }
            public decimal Y { get; set; }
            public decimal Z { get; set; }
            public void point3d()
            {

            }
        public static Point3d getInstance()
        {
            if (O1 == null)
            {
                O1 = new Point3d();
            }

            return O1;
        }
        public static ObservableCollection<Point3d> lgetInstance()
        {
            if (points == null)
            {
                points = new ObservableCollection<Point3d>();
            }

            return points;
        }
    }
    }

