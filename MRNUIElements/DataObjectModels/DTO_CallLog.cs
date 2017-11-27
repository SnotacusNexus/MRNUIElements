using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace   MRNUIElements.DataObjectModels
{
    [KnownType(typeof(Base))]
    [DataContract]
    public class CallLog : Base,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [DataMember]
        public int CallLogID { get; set; }
        [DataMember]
        public int ClaimID { get; set; }
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string WhoWasCalled { get; set; }
        [DataMember]
        public string ReasonForCall { get; set; }
        [DataMember]
        public string WhoAnswered { get; set; }
        [DataMember]
        public string CallResults { get; set; }
		[DataMember]
		public string AdditionalComments { get; set; }

	}
}
