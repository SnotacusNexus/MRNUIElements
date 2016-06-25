using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MRNNexus_Model
{
    [DataContract]
    public class DTO_Inspection
    {
        [DataMember]
        public int InspectionID { get; set; }
        [DataMember]
        public int ClaimID { get; set; }
        [DataMember]
        public bool SkyLights { get; set; }
        [DataMember]
        public bool Leaks { get; set; }
        [DataMember]
        public bool GutterDamage { get; set; }
        [DataMember]
        public bool DrivewayDamage { get; set; }
        [DataMember]
        public bool MagneticRollers { get; set; }
        [DataMember]
        public bool IceWaterShield { get; set; }
        [DataMember]
        public bool EmergencyRepair { get; set; }
        [DataMember]
        public bool QualityControl { get; set; }
        [DataMember]
        public bool ProtectLanescaping { get; set; }
        [DataMember]
        public bool RemoveTrash { get; set; }
        [DataMember]
        public bool TwoStories { get; set; }
        [DataMember]
        public bool FurnishPermit { get; set; }
        [DataMember]
        public bool CoverPool { get; set; }
        [DataMember]
        public string InteriorDamage { get; set; }
        [DataMember]
        public string ExteriorDamage { get; set; }
        [DataMember]
        public string Comments { get; set; }
    }
}
