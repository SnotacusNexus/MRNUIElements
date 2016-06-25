using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_LU_Permissions
    {
        [DataMember]
        public int PermissionID { get; set; }

        [DataMember]
        public string PerssionLevel { get; set; }
    }
}
