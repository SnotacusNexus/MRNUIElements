using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_Lead
    {
        [DataMember]
        public int LeadID { get; set; }
        [DataMember]
        public int LeadTypeID { get; set; }
        [DataMember]
        public DateTime LeadDate { get; set; }
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public int CreditToID { get; set; }
    }
}
