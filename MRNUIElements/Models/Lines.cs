using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNUIElements.Models.Structure
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
        public static Point3d GetLinePoints(int l,int count)
        {
            
           
            string t = lines[l].StartingPointID;
            string u = lines[l].EndingPointID;

           
            if(count == 0)
                return points.Single(b => b.PointID == t);
            if (count == 1)
                return points.Single(b => b.PointID == u);
            
            return null;
            

        }
    }

}