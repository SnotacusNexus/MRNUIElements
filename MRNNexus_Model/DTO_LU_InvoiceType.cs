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
    public class DTO_LU_InvoiceType : DTO_Base
    {
        [DataMember]
        public int InvoiceTypeID { get; set; }
        [DataMember]
        public string InvoiceType { get; set; }
    }
}
