﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [KnownType(typeof(DTO_Base))]
    [DataContract]
    public class DTO_LU_EmployeeType : DTO_Base
    {
        [DataMember]
        public int EmployeeTypeID { get; set; }
        [DataMember]
        public string EmployeeType { get; set; }
    }
}
