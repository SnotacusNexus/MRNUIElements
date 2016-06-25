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
    public class DTO_ClaimDocumentPath
    {
        [DataMember]
        public int DocumentID { get; set; }
        [DataMember]
        public int ClaimID { get; set; }
        [DataMember]
        public string DocumentPath { get; set; }
        [DataMember]
        public string DocFileName { get; set; }
        [DataMember]
        public int DocTypeID { get; set; }
        
        public DateTime DocumentDate { get; set; }
		[DataMember(Name = "DocumentDate")]
		private string DocumentDateForSerialization { get; set; }
		[OnSerializing]
		void onSerializing(StreamingContext context)
		{
			this.DocumentDateForSerialization = JsonConvert.SerializeObject(this.DocumentDate);
		}
		[OnDeserialized]
		void OnDeserialized(StreamingContext context)
		{
			this.DocumentDate = DateTime.Parse(this.DocumentDateForSerialization);
		}



		[DataMember]
        public string SignatureImagePath { get; set; }
        [DataMember]
        public int NumSignatures { get; set; }
        [DataMember]
        public string InititalImagePath { get; set; }
        [DataMember]
        public int NumInititals { get; set; }
    }
}
