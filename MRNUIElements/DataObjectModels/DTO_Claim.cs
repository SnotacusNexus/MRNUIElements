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
    [KnownType(typeof(Base))]
    [DataContract]
    public class Claim : DTO_Claim,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
        private int? _BillingID;
        public int? BillingID
        {
            get { return _BillingID; }
            set
            {
                if (value != _BillingID)
                {
                    _BillingID = value;
                    OnPropertyChanged("BillingID");
                }
            }
        }
        private int? _PropertyID;
        public int? PropertyID
        {
            get { return _PropertyID; }
            set
            {
                if (value != _PropertyID)
                {
                    _PropertyID = value;
                    OnPropertyChanged("PropertyID");
                }
            }
        }
        private string _MRNNumber;
        public string MRNNumber
        {
            get { return _MRNNumber; }
            set
            {
                if (value != _MRNNumber)
                {
                    _MRNNumber = value;
                    OnPropertyChanged("MRNNumber");
                }
            }
        }
        private DateTime _LossDate;
        public DateTime LossDate
        {
            get { return _LossDate; }
            set
            {
                if (value != _LossDate)
                {
                    _LossDate = value;
                    OnPropertyChanged("LossDate");
                }
            }
        }

        public string MortgageCompany { get; set; } = " ";


        public string MortgageAccount { get; set; } = " ";

        private int _InsuranceCompanyID;
        public int InsuranceCompanyID
        {
            get { return _InsuranceCompanyID; }
            set
            {
                if (value != _InsuranceCompanyID)
                {
                    _InsuranceCompanyID = value;
                    OnPropertyChanged("InsuranceCompanyID");
                }
            }
        }
        private string _InsuranceClaimNumber;
        public string InsuranceClaimNumber
        {
            get { return _InsuranceClaimNumber; }
            set
            {
                if (value != _InsuranceClaimNumber)
                {
                    _InsuranceClaimNumber = value;
                    OnPropertyChanged("InsuranceClaimNumber");
                }
            }
        }
        private bool _IsOpen;
        public bool IsOpen
        {
            get { return _IsOpen; }
            set
            {
                if (value != _IsOpen)
                {
                    _IsOpen = value;
                    OnPropertyChanged("IsOpen");
                }
            }
        }

        private bool _ContractSigned;
        public bool ContractSigned
        {
            get { return _ContractSigned; }
            set
            {
                if (value != _ContractSigned)
                {
                    _ContractSigned = value;
                    OnPropertyChanged("ContractSigned");
                }
            }
        }



    }
}
