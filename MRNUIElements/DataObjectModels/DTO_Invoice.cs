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
    public class Invoice : Base,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [DataMember]
        public int InvoiceID { get; set; }
        [DataMember]
        public int ClaimID { get; set; }
        [DataMember]
        public int InvoiceTypeID { get; set; }
        [DataMember]
        public int VendorID { get; set; }
        [DataMember]
        public double InvoiceAmount { get; set; }
        
        public DateTime InvoiceDate { get; set; }
		[DataMember(Name = "InvoiceDate")]
		private string InvoiceDateForSerialization { get; set; }
		[OnSerializing]
		void onSerializing(StreamingContext context)
		{
            if(InvoiceDate != null)
			    this.InvoiceDateForSerialization = JsonConvert.SerializeObject(this.InvoiceDate).Replace('"', ' ').Trim();
		}
		[OnDeserialized]
		void OnDeserialized(StreamingContext context)
		{
            if(InvoiceDateForSerialization != null)
			    this.InvoiceDate = DateTime.Parse(this.InvoiceDateForSerialization);
		}

		[DataMember]
        public bool Paid { get; set; }
    }
}
