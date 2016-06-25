using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_CallLog
    {
        [DataMember]
        public int CallLogID { get; set; }
        [DataMember]
        public int ClaimID { get; set; }
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string WhoWasCalled { get; set; }
        [DataMember]
        public string ReasonForCall { get; set; }
        [DataMember]
        public string WhoAnswered { get; set; }
        [DataMember]
        public string CallResults { get; set; }
    }
}
