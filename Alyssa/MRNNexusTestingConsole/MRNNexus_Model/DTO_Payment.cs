using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_Payment
    {
        [DataMember]
        public int PaymentID { get; set; }
        [DataMember]
        public int InvoiceID { get; set; }
        [DataMember]
        public int PaymentTypeID { get; set; }
        [DataMember]
        public int PaymentDescriptionID { get; set; }
        [DataMember]
        public double Amount { get; set; }
        [DataMember]
        public DateTime PaymentDate { get; set; }
    }
}
