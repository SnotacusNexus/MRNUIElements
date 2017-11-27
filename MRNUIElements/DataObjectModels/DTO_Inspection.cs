using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;
using MRNNexus_Model;

namespace   MRNUIElements.DataObjectModels
{
    [KnownType(typeof(DTO_Base))]
    
    public class Inspection : DTO_Inspection, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
       
        private int _InspectionID;
        public int InspectionID
        {
            get { return _InspectionID; }
            set
            {
                if (value != _InspectionID)
                {
                    _InspectionID = value;
                    OnPropertyChanged("InspectionID");
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private int? _ClaimID;
        public int? ClaimID
        {
            get { return _ClaimID; }
            set
            {
                if (value != _ClaimID)
                {
                    _ClaimID = value;
                    OnPropertyChanged("ClaimID");
                }
            }
        }
        private int _CustomerID;
        public int CustomerID
        {
            get { return _CustomerID; }
            set
            {
                if (value != _CustomerID)
                {
                    _CustomerID = value;
                    OnPropertyChanged("CustomerID");
                }
            }
        }
        private DateTime _InspectionDate;
        public DateTime InspectionDate
        {
            get { return _InspectionDate; }
            set
            {
                if (value != _InspectionDate)
                {
                    _InspectionDate = value;
                    OnPropertyChanged("InspectionDate");
                }
            }
        }


        private int _RoofAge;
        public int RoofAge
        {
            get { return _RoofAge; }
            set
            {
                if (value != _RoofAge)
                {
                    _RoofAge = value;
                    OnPropertyChanged("RoofAge");
                }
            }
        }
        private bool _SkyLights;
        public bool SkyLights
        {
            get { return _SkyLights; }
            set
            {
                if (value != _SkyLights)
                {
                    _SkyLights = value;
                    OnPropertyChanged("SkyLights");
                }
            }
        }
        private bool _Leaks;
        public bool Leaks
        {
            get { return _Leaks; }
            set
            {
                if (value != _Leaks)
                {
                    _Leaks = value;
                    OnPropertyChanged("Leaks");
                }
            }
        }
        private bool _GutterDamage;
        public bool GutterDamage
        {
            get { return _GutterDamage; }
            set
            {
                if (value != _GutterDamage)
                {
                    _GutterDamage = value;
                    OnPropertyChanged("GutterDamage");
                }
            }
        }
        private bool _DrivewayDamage;
        public bool DrivewayDamage
        {
            get { return _DrivewayDamage; }
            set
            {
                if (value != _DrivewayDamage)
                {
                    _DrivewayDamage = value;
                    OnPropertyChanged("DrivewayDamage");
                }
            }
        }
        private bool _MagneticRollers;
        public bool MagneticRollers
        {
            get { return _MagneticRollers; }
            set
            {
                if (value != _MagneticRollers)
                {
                    _MagneticRollers = value;
                    OnPropertyChanged("MagneticRollers");
                }
            }
        }
        private bool _IceWaterShield;
        public bool IceWaterShield
        {
            get { return _IceWaterShield; }
            set
            {
                if (value != _IceWaterShield)
                {
                    _IceWaterShield = value;
                    OnPropertyChanged("IceWaterShield");
                }
            }
        }
        private bool _EmergencyRepair;
        public bool EmergencyRepair
        {
            get { return _EmergencyRepair; }
            set
            {
                if (value != _EmergencyRepair)
                {
                    _EmergencyRepair = value;
                    OnPropertyChanged("EmergencyRepair");
                }
            }
        }
        private double _EmergencyRepairAmount;
        public double EmergencyRepairAmount
        {
            get { return _EmergencyRepairAmount; }
            set
            {
                if (value != _EmergencyRepairAmount)
                {
                    _EmergencyRepairAmount = value;
                    OnPropertyChanged("EmergencyRepairAmount");
                }
            }
        }
        private bool _QualityControl;
        public bool QualityControl
        {
            get { return _QualityControl; }
            set
            {
                if (value != _QualityControl)
                {
                    _QualityControl = value;
                    OnPropertyChanged("QualityControl");
                }
            }
        }
        private bool _ProtectLandscaping;
        public bool ProtectLandscaping
        {
            get { return _ProtectLandscaping; }
            set
            {
                if (value != _ProtectLandscaping)
                {
                    _ProtectLandscaping = value;
                    OnPropertyChanged("ProtectLandscaping");
                }
            }
        }
        private bool _RemoveTrash;
        public bool RemoveTrash
        {
            get { return _RemoveTrash; }
            set
            {
                if (value != _RemoveTrash)
                {
                    _RemoveTrash = value;
                    OnPropertyChanged("RemoveTrash");
                }
            }
        }
        private bool _FurnishPermit;
        public bool FurnishPermit
        {
            get { return _FurnishPermit; }
            set
            {
                if (value != _FurnishPermit)
                {
                    _FurnishPermit = value;
                    OnPropertyChanged("FurnishPermit");
                }
            }
        }
        private bool _CoverPool;
        public bool CoverPool
        {
            get { return _CoverPool; }
            set
            {
                if (value != _CoverPool)
                {
                    _CoverPool = value;
                    OnPropertyChanged("CoverPool");
                }
            }
        }
        private bool _InteriorDamage;
        public bool InteriorDamage
        {
            get { return _InteriorDamage; }
            set
            {
                if (value != _InteriorDamage)
                {
                    _InteriorDamage = value;
                    OnPropertyChanged("InteriorDamage");
                }
            }
        }
        private bool _ExteriorDamage;
        public bool ExteriorDamage
        {
            get { return _ExteriorDamage; }
            set
            {
                if (value != _ExteriorDamage)
                {
                    _ExteriorDamage = value;
                    OnPropertyChanged("ExteriorDamage");
                }
            }
        }
        private bool _Valley;
        public bool Valley
        {
            get { return _Valley; }
            set
            {
                if (value != _Valley)
                {
                    _Valley = value;
                    OnPropertyChanged("Valley");
                }
            }
        }
        private int _RidgeMaterialType;
        public int RidgeMaterialType
        {
            get { return _RidgeMaterialType; }
            set
            {
                if (value != _RidgeMaterialType)
                {
                    _RidgeMaterialType = value;
                    OnPropertyChanged("RidgeMaterialType");
                }
            }
        }
        private int _ShingleTypeID;
        public int ShingleTypeID
        {
            get { return _ShingleTypeID; }
            set
            {
                if (value != _ShingleTypeID)
                {
                    _ShingleTypeID = value;
                    OnPropertyChanged("ShingleTypeID");
                }
            }
        }
        private bool _TearOff;
        public bool TearOff
        {
            get { return _TearOff; }
            set
            {
                if (value != _TearOff)
                {
                    _TearOff = value;
                    OnPropertyChanged("TearOff");
                }
            }
        }
        private bool _Satellite;
        public bool Satellite
        {
            get { return _Satellite; }
            set
            {
                if (value != _Satellite)
                {
                    _Satellite = value;
                    OnPropertyChanged("Satellite");
                }
            }
        }
        private bool _SolarPanels;
        public bool SolarPanels
        {
            get { return _SolarPanels; }
            set
            {
                if (value != _SolarPanels)
                {
                    _SolarPanels = value;
                    OnPropertyChanged("SolarPanels");
                }
            }
        }
        private string _Comments;
        public string Comments
        {
            get { return _Comments; }
            set
            {
                if (value != _Comments)
                {
                    _Comments = value;
                    OnPropertyChanged("Comments");
                }
            }
        }
        private bool _LightningProtection;
        public bool LightningProtection
        {
            get { return _LightningProtection; }
            set
            {
                if (value != _LightningProtection)
                {
                    _LightningProtection = value;
                    OnPropertyChanged("LightningProtection");
                }
            }
        }
        
	}
}
