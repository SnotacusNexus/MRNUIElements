using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_AdditionalSupply
    {
        [DataMember]
        public int AdditionalSuppliesID { get; set; }
        [DataMember]
        public int ClaimID { get; set; }

        
        public DateTime PickUpDate { get; set; }
        [DataMember(Name = "PickUpDate")]
		private string PickUpDateForSerialization { get; set; }
		[OnSerializing]
		void OnSerializingPU(StreamingContext context)
		{
			this.PickUpDateForSerialization = JsonConvert.SerializeObject(this.PickUpDate);
		}
		[OnDeserialized]
		void OnDeserializedPU(StreamingContext context)
		{
			this.PickUpDate = DateTime.Parse(this.PickUpDateForSerialization);
		}

        public DateTime DropOffDate { get; set; }
		[DataMember(Name = "DropOffDate")]
		private string DropOffDateForSerialization { get; set; }
		[OnSerializing]
		void OnSerializingDO(StreamingContext context)
		{
			this.DropOffDateForSerialization = JsonConvert.SerializeObject(this.DropOffDate);
		}
		[OnDeserialized]
		void OnDeserializedDO(StreamingContext context)
		{
			this.DropOffDate = DateTime.Parse(this.DropOffDateForSerialization);
		}

		[DataMember]
        public string Items { get; set; }
        [DataMember]
        public double Cost { get; set; }
        [DataMember]
        public string ReceiptImagePath { get; set; }
    }
}
