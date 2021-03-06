﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexusDTOs
{
    [KnownType(typeof(DTO_Base))]
    [DataContract]
    public class DTO_ClaimVendor : DTO_Base
    {
        [DataMember]
        public int ClaimID { get; set; }
        [DataMember]
        public int VendorID { get; set; }
        [DataMember]
        public int ServiceTypeID { get; set; }

    }
}
