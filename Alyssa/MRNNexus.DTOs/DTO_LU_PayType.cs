﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus.DTOs
{
    [KnownType(typeof(DTO_Base))]
    [DataContract]
    public class DTO_LU_PayType : DTO_Base
    {
        [DataMember]
        public int PayTypeID { get; set; }
        [DataMember]
        public string PayType { get; set; }
    }
}