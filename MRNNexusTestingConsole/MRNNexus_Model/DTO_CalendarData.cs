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
    public class DTO_CalendarData
    {
        [DataMember]
        public int EntryID { get; set; }
        [DataMember]
        public int EmployeeID { get; set; }

        
        public DateTime StartTime { get; set; }
		[DataMember(Name = "StartTime")]
		private string StartTimeForSerialization { get; set; }
		[OnSerializing]
		void onSerializing(StreamingContext context)
		{
			this.StartTimeForSerialization = JsonConvert.SerializeObject(this.StartTime).Replace('"', ' ').Trim();
		}
		[OnDeserialized]
		void OnDeserialized(StreamingContext context)
		{
			this.StartTime = DateTime.Parse(this.StartTimeForSerialization);
		}

		
        public DateTime EndTime { get; set; }
		[DataMember(Name = "EndTime")]
		private string EndTimeForSerialization { get; set; }
		

		[DataMember]
        public int ClaimID { get; set; }
        [DataMember]
        public string Note { get; set; }
    }
}
