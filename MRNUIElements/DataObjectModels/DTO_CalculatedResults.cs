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
    public class CalculatedResults : Base, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [DataMember]
        public double SumOfInvoices { get; set; }

        [DataMember]
        public double SumOfPayments { get; set; }

        public DateTime MostRecentDate { get; set; }

       
       
    }
}
