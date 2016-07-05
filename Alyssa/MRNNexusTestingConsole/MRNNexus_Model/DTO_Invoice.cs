using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_Invoice
    {
        [DataMember]
        public int InvoiceID { get; set; }
        [DataMember]
        public int ClaimID { get; set; }
        [DataMember]
        public int InvoiceTypeID { get; set; }
        [DataMember]
        public double InvoiceAmount { get; set; }
        [DataMember]
        public DateTime InvoiceDate { get; set; }
        [DataMember]
        public bool Paid { get; set; }
    }
}
