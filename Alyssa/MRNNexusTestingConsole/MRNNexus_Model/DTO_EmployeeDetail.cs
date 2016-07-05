using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_EmployeeDetail
    {
        [DataMember]
        public int EmployeeDetailsID { get; set; }
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string MailingAddress { get; set; }
        [DataMember]
        public string Zip { get; set; }
        [DataMember]
        public string SSN { get; set; }
        [DataMember]
        public DateTime DateHired { get; set; }
        [DataMember]
        public DateTime DateReleased { get; set; }
        [DataMember]
        public string ShirtSize { get; set; }
        [DataMember]
        public double PayRate { get; set; }
        [DataMember]
        public int PayTypeID { get; set; }
        [DataMember]
        public int PayFrequencyID { get; set; }
        [DataMember]
        public bool PreviousEmployee { get; set; }
        [DataMember]
        public string DLPhotoPath { get; set; }
        [DataMember]
        public string CompanyPhotoPath { get; set; }
        [DataMember]
        public string SignaturePath { get; set; }
    }
}
