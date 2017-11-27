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
    
    public class Lead : DTO_Lead,INotifyPropertyChanged
    {
        private int _LeadID;
        public int LeadID
        {
            get { return _LeadID; }
            set
            {
                if (value != _LeadID)
                {
                    _LeadID = value;
                    OnPropertyChanged("LeadID");
                }
            }
        }

        private int _LeadTypeID;
        public int LeadTypeID
        {
            get { return _LeadTypeID; }
            set
            {
                if (value != _LeadTypeID)
                {
                    _LeadTypeID = value;
                    OnPropertyChanged("LeadTypeID");
                }
            }
        }

        private int _KnockerResponseID;
        public int KnockerResponseID
        {
            get { return _KnockerResponseID; }
            set
            {
                if (value != _KnockerResponseID)
                {
                    _KnockerResponseID = value;
                    OnPropertyChanged("KnockerResponseID");
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

        private int _AddressID;
        public int AddressID
        {
            get { return _AddressID; }
            set
            {
                if (value != _AddressID)
                {
                    _AddressID = value;
                    OnPropertyChanged("AddressID");
                }
            }
        }

        private DateTime _LeadDate;
        public DateTime LeadDate
        {
            get { return _LeadDate; }
            set
            {
                if (value != _LeadDate)
                {
                    _LeadDate = value;
                    OnPropertyChanged("LeadDate");
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
        private bool _Success;
        public bool Success
        {
            get { return _Success; }
            set
            {
                if (value != _Success)
                {
                    _Success = value;
                    OnPropertyChanged("Success");
                }
            }
        }

        private int? _CreditToID;
        public int? CreditToID
        {
            get { return _CreditToID; }
            set
            {
                if (value != _CreditToID)
                {
                    _CreditToID = value;
                    OnPropertyChanged("CreditToID");
                }
            }
        }
        private string _Temperature;
        public string Temperature
        {
            get { return _Temperature; }
            set
            {
                if (value != _Temperature)
                {
                    _Temperature = value;
                    OnPropertyChanged("Temperature");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!=null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
