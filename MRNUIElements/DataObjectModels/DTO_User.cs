﻿using System;
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
    public class User : Base,INotifyPropertyChanged
    {
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Pass { get; set; }
        [DataMember]
        public int PermissionID { get; set; }
        [DataMember]
        public bool Active { get; set; }
    }
}
