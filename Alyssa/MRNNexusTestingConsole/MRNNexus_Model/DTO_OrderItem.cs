using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_OrderItem
    {
        [DataMember]
        public int OrderItemID { get; set; }
        [DataMember]
        public int OrderID { get; set; }
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public int UnitOfMeasureID { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }
}
