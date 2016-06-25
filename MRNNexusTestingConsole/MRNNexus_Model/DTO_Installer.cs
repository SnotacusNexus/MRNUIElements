using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_Installer
    {
        [DataMember]
        public int InstallerID { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string EIN { get; set; }
        [DataMember]
        public string ContactFirstName { get; set; }
        [DataMember]
        public string ContactLastName { get; set; }
        [DataMember]
        public string Suffix { get; set; }
        [DataMember]
        public string InstallerAddress { get; set; }
        [DataMember]
        public string Zip { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string CompanyPhone { get; set; }
        [DataMember]
        public string Fax { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Website { get; set; }
        [DataMember]
        public bool HasSubContractAgreement { get; set; }
        [DataMember]
        public DateTime GLExpiration { get; set; }
        [DataMember]
        public string SubContractorAgreementPath { get; set; }
        [DataMember]
        public string GeneralLiabilityPath { get; set; }
    }
}
