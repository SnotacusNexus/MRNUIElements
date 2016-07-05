using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_LU_Product
    {
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public int ProductTypeID { get; set; }
        [DataMember]
        public string ProductColor { get; set; }
        [DataMember]
        public double ProductLength { get; set; }
        [DataMember]
        public double ProductHeight { get; set; }
        [DataMember]
        public double ProductWidth { get; set; }
        [DataMember]
        public double ProductPrice { get; set; }
        [DataMember]
        public int ProductQuantity { get; set; }
        [DataMember]
        public string ProductInfo { get; set; }
        [DataMember]
        public string ProductSupplier { get; set; }
        [DataMember]
        public string ProductWarrenty { get; set; }
    }
}
