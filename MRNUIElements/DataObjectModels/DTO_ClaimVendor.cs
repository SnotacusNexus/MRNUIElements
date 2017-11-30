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
    public class ClaimVendor : Base, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [DataMember]
        public int ClaimID { get; set; }
        [DataMember]
        public int VendorID { get; set; }
        [DataMember]
        public int ServiceTypeID { get; set; }

    }
}
