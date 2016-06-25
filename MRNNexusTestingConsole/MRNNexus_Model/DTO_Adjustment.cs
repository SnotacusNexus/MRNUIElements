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
    public class DTO_Adjustment
    {
        [DataMember]
        public int AdjustmentID { get; set; }
        [DataMember]
        public int AdjusterID { get; set; }
        [DataMember]
        public int ClaimID { get; set; }
        
        public DateTime AdjustmentDate { get; set; }
		[DataMember(Name = "AdjustmentDate")]
		private string AdjustmentDateForSerialization { get; set; }
		[OnSerializing]
		void OnSerializing(StreamingContext context)
		{
			this.AdjustmentDateForSerialization = JsonConvert.SerializeObject(this.AdjustmentDate);
		}
		[OnDeserializing]
		void OnDeserialized(StreamingContext context)
		{
			this.AdjustmentDate = DateTime.Parse(this.AdjustmentDateForSerialization);
		}

		[DataMember]
        public string AdjustmentResult { get; set; }
        [DataMember]
        public string AdjustmentComment { get; set; }
    }
}
