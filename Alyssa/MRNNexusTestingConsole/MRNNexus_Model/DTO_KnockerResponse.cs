using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_KnockerResponse
    {
        [DataMember]
        public int KnockerResponseID { get; set; }
        [DataMember]
        public int KnockerID { get; set; }
        [DataMember]
        public int KnockResponseTypeID { get; set; }
        [DataMember]
        public int CustomerID { get; set; }
    }
}
