using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus.DTOs
{
    [KnownType(typeof(DTO_Base))]
    [DataContract]
    public class DTO_LU_KnockResponseType : DTO_Base
    {
        [DataMember]
        public int KnockResponseTypeID { get; set; }
        [DataMember]
        public string KnockResponseType { get; set; }
    }
}
