using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [KnownType(typeof(DTO_Base))]
    [DataContract]
    public class DTO_LU_LeadType : DTO_Base
    {
        [DataMember]
        public int LeadTypeID { get; set; }
        [DataMember]
        public string LeadType { get; set; }

		public override string ToString()
		{
			return LeadType.ToString();	
		}
	}
}
