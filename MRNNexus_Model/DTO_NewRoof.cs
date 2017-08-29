using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [KnownType(typeof(DTO_Base))]
    [DataContract]
    public class DTO_NewRoof : DTO_Base
    {
        [DataMember]
        public int NewRoofID { get; set; }
        [DataMember]
        public int ClaimID { get; set; }
        [DataMember]
        public int ProductID { get; set; }
		[DataMember]
		public int UnderlaymentPID { get; set; }
		[DataMember]
		public int ValleyUnderlaymentPID { get; set; }
		[DataMember]
		public int DripEdgePID { get; set; }
		[DataMember]
		public int RidgeVentPID { get; set; }
		[DataMember]
		public bool DripEdgeInstall { get; set; } = true;
		[DataMember]
		public bool RakesOnly { get; set; } = true;
		[DataMember]
		public int HipRidgePID { get; set; }
		[DataMember]
		public double UpgradeCost { get; set; }
		
		[DataMember]
        public string Comments { get; set; }
    }
}
