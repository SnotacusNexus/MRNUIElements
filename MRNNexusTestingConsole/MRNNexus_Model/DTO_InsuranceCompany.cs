using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_InsuranceCompany
    {
        [DataMember]
        public int InsuranceCompanyID { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string CompanyAddress { get; set; }
        [DataMember]
        public string Zip { get; set; }
        [DataMember]
        public string TollFreeNumber { get; set; }
        [DataMember]
        public string ClaimPhoneNumber { get; set; }
        [DataMember]
        public string ClaimPhoneExt { get; set; }
        [DataMember]
        public string FaxNumber { get; set; }
        [DataMember]
        public string FaxExt { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public bool Independant { get; set; }
    }
}
