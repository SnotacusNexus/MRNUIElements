using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_LU_PaymentDescription
    {
        [DataMember]
        public int PaymentDescriptionID { get; set; }
        [DataMember]
        public string PaymentDescription { get; set; }
    }
}
