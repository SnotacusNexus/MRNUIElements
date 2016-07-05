using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNNexus_Model
{
    public class DTO_Scope
    {
        public int ScopeID { get; set; }
        public int ScopeType { get; set; }
        public int ClaimID { get; set; }
        public double Interior { get; set; }
        public double Exterior { get; set; }
        public double Gutter { get; set; }
        public double Tax { get; set; }
        public double Deductable { get; set; }
        public double Total { get; set; }
        public double OandP { get; set; }
    }
}
