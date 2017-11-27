using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;

namespace   MRNUIElements.DataObjectModels
{
    [KnownType(typeof(Base))]
    [DataContract]
    public class SurplusSupplies : Base, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [DataMember]
        public int SurplusSuppliesID { get; set; }
        [DataMember]
        public int ClaimID { get; set; }
        [DataMember]
        public int UnitOfMeasureID { get; set; }
        [DataMember]
        public int Quantity { get; set; }

        public DateTime PickUpDate { get; set; }
       
        public DateTime DropOffDate { get; set; }
    
        [DataMember]
        public string Items { get; set; }

    }
}
