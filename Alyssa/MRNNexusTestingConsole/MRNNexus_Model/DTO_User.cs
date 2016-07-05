using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_User
    {
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Pass { get; set; }
        [DataMember]
        public bool Active { get; set; }
    }
}
