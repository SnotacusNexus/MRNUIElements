using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_Order
    {
        [DataMember]
        public int OrderID { get; set; }
        [DataMember]
        public int SupplierID { get; set; }
        [DataMember]
        public DateTime DateOrdered { get; set; }
        [DataMember]
        public DateTime DateDropped { get; set; }
        [DataMember]
        public DateTime ScheduledInstallation { get; set; }
        [DataMember]
        public int ClaimID { get; set; }
    }
}
