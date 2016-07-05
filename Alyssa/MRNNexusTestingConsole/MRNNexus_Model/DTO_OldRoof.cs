using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_OldRoof
    {
        [DataMember]
        public int OldRoofID { get; set; }
        [DataMember]
        public int ClaimID { get; set; }
        [DataMember]
        public int ThreeAndOne { get; set; }
        [DataMember]
        public int FourAndUp { get; set; }
        [DataMember]
        public string Valley { get; set; }
        [DataMember]
        public int NumOfLayers { get; set; }
        [DataMember]
        public string RidgeMaterial { get; set; }
        [DataMember]
        public int Pitch { get; set; }
        [DataMember]
        public bool TearOff { get; set; }
        [DataMember]
        public int RoofAge { get; set; }
        [DataMember]
        public string Comments { get; set; }
    }
}
