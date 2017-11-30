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
    public class Referrer : Base, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [DataMember]
        public int ReferrerID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Suffix { get; set; }
        [DataMember]
        public string MailingAddress { get; set; }
        [DataMember]
        public string Zip { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string CellPhone { get; set; }

       
		public override string ToString()
		{
			return FirstName + " " + LastName.ToString();
		}
	}
}
