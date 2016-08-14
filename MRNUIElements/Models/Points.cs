using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media.Media3D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNUIElements.Models.Structure
{
  
        public class Point3d 
        {
        public static Point3d O1;
            static public ObservableCollection<Point3d> points { get; set; }
        public  string PointID { get; set; }
        public static string _PointID { get; set; }
        public  decimal X { get; set; }
        public decimal Y { get; set; }
        public  decimal Z { get; set; }
        public static decimal _X { get; set; }
        public static decimal _Y { get; set; }
        public static decimal _Z { get; set; }
        public Point3d(decimal X, decimal Y, decimal Z)
            {

            }
        public static Point3d getInstance()
        {
            if (O1 == null)
            {
                O1 = new Point3d(0,0,0);
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
        public  System.Windows.Media.Media3D.Point3D GetPoint(string PointId)
        {
            foreach (Point3d p in points)
            {
                if (PointID == PointId)
                    return (new System.Windows.Media.Media3D.Point3D((double)_X, (double)_Y, (double)_Z));
            }
            return (new System.Windows.Media.Media3D.Point3D(0, 0, 0));
        }
    }
    }

