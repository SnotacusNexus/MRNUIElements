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
  
    public class AdditionalSupply : DTO_AdditionalSupply,INotifyPropertyChanged
    {
        private int _AdditionalSuppliesID;
        public int AdditionalSuppliesID
        {
            get { return _AdditionalSuppliesID; }
            set
            {
                if (value != _AdditionalSuppliesID)
                {
                    _AdditionalSuppliesID = value;
                    OnPropertyChanged("AdditionalSuppliesID");
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
        private DateTime _PickUpDate;
        public DateTime PickUpDate
        {
            get { return _PickUpDate; }
            set
            {
                if (value != _PickUpDate)
                {
                    _PickUpDate = value;
                    OnPropertyChanged("PickUpDate");
                }
            }
        }
        private DateTime _DropOffDate;
        public DateTime DropOffDate
        {
            get { return _DropOffDate; }
            set
            {
                if (value != _DropOffDate)
                {
                    _DropOffDate = value;
                    OnPropertyChanged("DropOffDate");
                }
            }
        }
        private double _Cost;
        public double Cost
        {
            get { return _Cost; }
            set
            {
                if (value != _Cost)
                {
                    _Cost = value;
                    OnPropertyChanged("Cost");
                }
            }
        }
        private string _Items;
        public string Items
        {
            get { return _Items; }
            set
            {
                if (value != _Items)
                {
                    _Items = value;
                    OnPropertyChanged("Items");
                }
            }
        }
        private string _ReceiptImagePath;
        public string ReceiptImagePath
        {
            get { return _ReceiptImagePath; }
            set
            {
                if (value != _ReceiptImagePath)
                {
                    _ReceiptImagePath = value;
                    OnPropertyChanged("ReceiptImagePath");
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
