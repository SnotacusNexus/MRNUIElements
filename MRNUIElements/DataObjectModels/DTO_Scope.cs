using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;
using MRNNexus_Model;

namespace   MRNUIElements.DataObjectModels
{
    [KnownType(typeof(DTO_Base))]
    
    public class Scope : DTO_Scope, INotifyPropertyChanged
    {
        private int _ScopeID;
        public int ScopeID
        {
            get { return _ScopeID; }
            set
            {
                if (value != _ScopeID)
                {
                    _ScopeID = value;
                    OnPropertyChanged("ScopeID");
                }
            }
        }
        private int _ScopeTypeID;
        public int ScopeTypeID
        {
            get { return _ScopeTypeID; }
            set
            {
                if (value != _ScopeTypeID)
                {
                    _ScopeTypeID = value;
                    OnPropertyChanged("ScopeTypeID");
                }
            }
        }
        private int _ClaimID;
        public int ClaimID
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
        private double _Interior;
        public double Interior
        {
            get { return _Interior; }
            set
            {
                if (value != _Interior)
                {
                    _Interior = value;
                    OnPropertyChanged("Interior");
                }
            }
        }
        private double _Exterior;
        public double Exterior
        {
            get { return _Exterior; }
            set
            {
                if (value != _Exterior)
                {
                    _Exterior = value;
                    OnPropertyChanged("Exterior");
                }
            }
        }
        private double _Gutter;
        public double Gutter
        {
            get { return _Gutter; }
            set
            {
                if (value != _Gutter)
                {
                    _Gutter = value;
                    OnPropertyChanged("Gutter");
                }
            }
        }
        private double _Tax;
        public double Tax
        {
            get { return _Tax; }
            set
            {
                if (value != _Tax)
                {
                    _Tax = value;
                    OnPropertyChanged("Tax");
                }
            }
        }
        private double _Deductible;
        public double Deductible
        {
            get { return _Deductible; }
            set
            {
                if (value != _Deductible)
                {
                    _Deductible = value;
                    OnPropertyChanged("Deductible");
                }
            }
        }
        private double _Total;
        public double Total
        {
            get { return _Total; }
            set
            {
                if (value != _Total)
                {
                    _Total = value;
                    OnPropertyChanged("Total");
                }
            }
        }
        private double _OandP;
        public double OandP
        {
            get { return _OandP; }
            set
            {
                if (value != _OandP)
                {
                    _OandP = value;
                    OnPropertyChanged("OandP");
                }
            }
        }
        private double _RoofAmount;
        public double RoofAmount
        {
            get { return _RoofAmount; }
            set
            {
                if (value != _RoofAmount)
                {
                    _RoofAmount = value;
                    OnPropertyChanged("RoofAmount");
                }
            }
        }
        private bool _Accepted;
        public bool Accepted
        {
            get { return _Accepted; }
            set
            {
                if (value != _Accepted)
                {
                    _Accepted = value;
                    OnPropertyChanged("Accepted");
                }
            }
        }
        private double _ACV;
        public double ACV
        {
            get { return _ACV; }
            set
            {
                if (value != _ACV)
                {
                    _ACV = value;
                    OnPropertyChanged("ACV");
                }
            }
        }
        private double _RCV;
        public double RCV
        {
            get { return _RCV; }
            set
            {
                if (value != _RCV)
                {
                    _RCV = value;
                    OnPropertyChanged("RCV");
                }
            }
        }
        private double _Depreciation;
        public double Depreciation
        {
            get { return _Depreciation; }
            set
            {
                if (value != _Depreciation)
                {
                    _Depreciation = value;
                    OnPropertyChanged("Depreciation");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
