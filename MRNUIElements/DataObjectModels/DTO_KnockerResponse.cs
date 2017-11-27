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
    public class KnockerResponse : Base, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [DataMember]
        public int KnockerResponseID { get; set; }
        [DataMember]
        public int KnockerID { get; set; }
        [DataMember]
        public int KnockResponseTypeID { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Zip { get; set; }
        [DataMember]
        public double? Latitude { get; set; }
        [DataMember]
        public double? Longitude { get; set; }


    }
}
