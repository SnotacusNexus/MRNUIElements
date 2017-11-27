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
    
    public class Payment : DTO_Payment,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private int _PaymentID;
        public int PaymentID
        {
            get { return _PaymentID; }
            set
            {
                if (value != _PaymentID)
                {
                    _PaymentID = value;
                    OnPropertyChanged("PaymentID");
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
        private int _PaymentTypeID;
        public int PaymentTypeID
        {
            get { return _PaymentTypeID; }
            set
            {
                if (value != _PaymentTypeID)
                {
                    _PaymentTypeID = value;
                    OnPropertyChanged("PaymentTypeID");
                }
            }
        }
        private int _PaymentDescriptionID;
        public int PaymentDescriptionID
        {
            get { return _PaymentDescriptionID; }
            set
            {
                if (value != _PaymentDescriptionID)
                {
                    _PaymentDescriptionID = value;
                    OnPropertyChanged("PaymentDescriptionID");
                }
            }
        }
        private double _Amount;
        public double Amount
        {
            get { return _Amount; }
            set
            {
                if (value != _Amount)
                {
                    _Amount = value;
                    OnPropertyChanged("Amount");
                }
            }
        }
        private DateTime _PaymentDate;
        public DateTime PaymentDate
        {
            get { return _PaymentDate; }
            set
            {
                if (value != _PaymentDate)
                {
                    _PaymentDate = value;
                    OnPropertyChanged("PaymentDate");
                }
            }
        }
       
	}
}
