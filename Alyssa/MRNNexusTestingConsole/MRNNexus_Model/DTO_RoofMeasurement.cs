using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_RoofMeasurement
    {
        [DataMember]
        public int RoofMeasurementsID { get; set; }
        [DataMember]
        public int ClaimID { get; set; }
        [DataMember]
        public double SqOff { get; set; }
        [DataMember]
        public double SqOn { get; set; }
        [DataMember]
        public double Ridges { get; set; }
        [DataMember]
        public double Hips { get; set; }
        [DataMember]
        public double StepFlashing { get; set; }
        [DataMember]
        public double Valleys { get; set; }
        [DataMember]
        public double Rakes { get; set; }
        [DataMember]
        public double Eaves { get; set; }
        [DataMember]
        public double Starter { get; set; }
        [DataMember]
        public int Pitch { get; set; }
    }
}
