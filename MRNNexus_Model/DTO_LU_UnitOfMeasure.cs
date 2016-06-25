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
    public class DTO_LU_UnitOfMeasure : DTO_Base
    {
        [DataMember]
        public int UnitOfMeasureID { get; set; }
        [DataMember]
        public string UnitOfMeasure { get; set; }
    }
}
