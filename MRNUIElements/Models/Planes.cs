using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNUIElements.Models.Structure
{
    public class Planes
    {
        public static Planes P1;
        static public ObservableCollection<Planes> planes;
        public string PlaneID { get; set; }
        public string Lines { get; set; }
        public string Orientation { get; set; }
        public void plane()
        {

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
