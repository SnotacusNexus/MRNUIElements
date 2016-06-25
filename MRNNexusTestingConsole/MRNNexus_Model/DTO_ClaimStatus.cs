using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_ClaimStatus
    {
        [DataMember]
        public int ClaimStatusID { get; set; }
        [DataMember]
        public int ClaimID { get; set; }
        [DataMember]
        public DateTime ContractSigned { get; set; }
        [DataMember]
        public DateTime InspectionDate { get; set; }
        [DataMember]
        public DateTime RoofMeasurementsRecieved { get; set; }
        [DataMember]
        public DateTime AdjustmentDate { get; set; }
        [DataMember]
        public DateTime OriginalScopeRecieved { get; set; }
        [DataMember]
        public DateTime FirstCheckRecieved { get; set; }
        [DataMember]
        public DateTime RoofOrdered { get; set; }
        [DataMember]
        public DateTime SupplementSent { get; set; }
        [DataMember]
        public DateTime SupplementSettled { get; set; }
        [DataMember]
        public DateTime RoofCompleted { get; set; }
        [DataMember]
        public DateTime GuttersScheduled { get; set; }
        [DataMember]
        public DateTime InteriorScheduled { get; set; }
        [DataMember]
        public DateTime ExteriorScheduled { get; set; }
        [DataMember]
        public DateTime CoCSent { get; set; }
        [DataMember]
        public DateTime SupCheckRecieved { get; set; }
        [DataMember]
        public DateTime SupCheckCollected { get; set; }
        [DataMember]
        public DateTime DepCheckRecieved { get; set; }
        [DataMember]
        public DateTime DepCheckCollected { get; set; }
        [DataMember]
        public DateTime DeductCheckCollect { get; set; }
        [DataMember]
        public DateTime WarrantySent { get; set; }
        [DataMember]
        public DateTime CappedOut { get; set; }
    }
}
