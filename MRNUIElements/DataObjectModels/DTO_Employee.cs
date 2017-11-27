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
    public class Employee : Base,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public int EmployeeTypeID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
		[DataMember]
		public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Suffix { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string CellPhone { get; set; }
        [DataMember]
        public bool Active { get; set; }
    

        public override string ToString()
		{
           
            return FirstName+" "+LastName.ToString();
		}

	}
}
