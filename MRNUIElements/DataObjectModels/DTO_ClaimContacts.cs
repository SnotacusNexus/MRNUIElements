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
    
    public class ClaimContacts : DTO_ClaimContacts,INotifyPropertyChanged
    {
        private int _ClaimContactID;
        public int ClaimContactID
        {
            get { return _ClaimContactID; }
            set
            {
                if (value != _ClaimContactID)
                {
                    _ClaimContactID = value;
                    OnPropertyChanged("ClaimContactID");
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
        private int? _KnockerID;
        public int? KnockerID
        {
            get { return _KnockerID; }
            set
            {
                if (value != _KnockerID)
                {
                    _KnockerID = value;
                    OnPropertyChanged("KnockerID");
                }
            }
        }
        private int _SalesPersonID;
        public int SalesPersonID
        {
            get { return _SalesPersonID; }
            set
            {
                if (value != _SalesPersonID)
                {
                    _SalesPersonID = value;
                    OnPropertyChanged("SalesPersonID");
                }
            }
        }
        private int _SalesManagerID;
        public int SalesManagerID
        {
            get { return _SalesManagerID; }
            set
            {
                if (value != _SalesManagerID)
                {
                    _SalesManagerID = value;
                    OnPropertyChanged("SalesManagerID");
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
        private int? _SupervisorID;
        public int? SupervisorID
        {
            get { return _SupervisorID; }
            set
            {
                if (value != _SupervisorID)
                {
                    _SupervisorID = value;
                    OnPropertyChanged("SupervisorID");
                }
            }
        }
        private int? _AdjusterID;
        public int? AdjusterID
        {
            get { return _AdjusterID; }
            set
            {
                if (value != _AdjusterID)
                {
                    _AdjusterID = value;
                    OnPropertyChanged("AdjusterID");
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
