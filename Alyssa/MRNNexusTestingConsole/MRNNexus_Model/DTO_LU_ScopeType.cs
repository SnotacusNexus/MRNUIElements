using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_LU_ScopeType
    {
        [DataMember]
        public int ScopeTypeID { get; set; }
        [DataMember]
        public string ScopeType { get; set; }
    }
}
