using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_Customer
    {
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Suffix { get; set; }
        [DataMember]
        public string CustomerAddress { get; set; }
        [DataMember]
        public string Zip { get; set; }
        [DataMember]
        public string PrimaryNumber { get; set; }
        [DataMember]
        public string SecondaryNumber { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public bool MailPromos { get; set; }
    }
}
