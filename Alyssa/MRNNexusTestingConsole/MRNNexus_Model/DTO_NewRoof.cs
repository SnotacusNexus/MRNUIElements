using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_NewRoof
    {
        [DataMember]
        public int NewRoofID { get; set; }
        [DataMember]
        public int ClaimID { get; set; }
        [DataMember]
        public int ShingleColor { get; set; }
        [DataMember]
        public int NumberDecking { get; set; }
        [DataMember]
        public double UpgradeCost { get; set; }
        [DataMember]
        public string Comments { get; set; }
    }
}
