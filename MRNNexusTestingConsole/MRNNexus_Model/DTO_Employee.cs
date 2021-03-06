﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_Employee
    {
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public int EmployeeTypeID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
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
    }
}
