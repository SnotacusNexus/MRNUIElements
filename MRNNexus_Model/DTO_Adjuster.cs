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
    public class DTO_Adjuster : DTO_Base
    {
        [DataMember]
        public int AdjusterID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Suffix { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string PhoneExt { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int InsuranceCompanyID { get; set; }
        [DataMember]
        public string Comments { get; set; }
    }
}
