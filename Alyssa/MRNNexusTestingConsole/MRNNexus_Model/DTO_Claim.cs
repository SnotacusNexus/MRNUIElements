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
    public class DTO_Claim
    {
        [DataMember]
        public int ClaimID { get; set; }
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public string ClaimNumber { get; set; }
        [DataMember]
        public int InspectionID { get; set; }
        [DataMember]
        public string DamageType { get; set; }
        
        public DateTime LossDate { get; set; }
		[DataMember(Name = "LossDate")]
		private string LossDateForSerialization { get; set; }
		[OnSerializing]
		void onSerializing(StreamingContext context)
		{
			this.LossDateForSerialization = JsonConvert.SerializeObject(this.LossDate);
		}
		[OnDeserialized]
		void OnDeserialized(StreamingContext context)
		{
			this.LossDate = DateTime.Parse(this.LossDateForSerialization);
		}


		[DataMember]
        public bool Gutters { get; set; }
        [DataMember]
        public bool Exterior { get; set; }
        [DataMember]
        public bool Interior { get; set; }
        [DataMember]
        public string ReferralName { get; set; }
        [DataMember]
        public string MortgageCompany { get; set; }
        [DataMember]
        public string MortgageAccount { get; set; }
        [DataMember]
        public bool LeedType { get; set; }
        [DataMember]
        public int InsuranceCompanyID { get; set; }
        [DataMember]
        public string InsuranceClaimNumber { get; set; }
    }
}
