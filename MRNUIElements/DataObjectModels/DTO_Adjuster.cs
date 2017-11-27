using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace MRNUIElements.DataObjectModels
{
    [KnownType(typeof(Base))]
    [DataContract]
    public class Adjuster : Base,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [DataMember]
        public int AdjusterID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Suffix { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string PhoneExt { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int InsuranceCompanyID { get; set; }
        [DataMember]
        public string Comments { get; set; }
    }
}
