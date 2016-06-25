using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_ClaimContact
    {
        [DataMember]
        public int ClaimContactID { get; set; }
        [DataMember]
        public int ClaimID { get; set; }
        [DataMember]
        public int LeadID { get; set; }
        [DataMember]
        public int SalesPersonID { get; set; }
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public int InstallerID { get; set; }
        [DataMember]
        public int SupervisorID { get; set; }
        [DataMember]
        public int AdjusterID { get; set; }
    }
}
