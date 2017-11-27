using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace   MRNUIElements.DataObjectModels
{
    [KnownType(typeof(Base))]
    [DataContract]
    public class InsuranceCompany : Base, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [DataMember]
        public int InsuranceCompanyID { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Zip { get; set; }
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
        public bool Independent { get; set; }
    }
}
