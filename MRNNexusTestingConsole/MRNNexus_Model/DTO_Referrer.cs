﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_Referrer
    {
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
    }
}
