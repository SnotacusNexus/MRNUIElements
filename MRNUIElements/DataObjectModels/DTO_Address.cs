using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;
using MRNNexus_Model;


namespace MRNUIElements.DataObjectModels
{
    [KnownType(typeof(DTO_Base))]
  
    public class Address : DTO_Address,INotifyPropertyChanged
    {

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

        private int customerID;

        public int CustomerID

        {
            get { return customerID; }
            set
            {
                customerID = value;
                OnPropertyChanged("CustomerID");
            }
            
        }

        private string _address;

        public string _Address
        {
            get { return _address; }
            set {
                _address = value;
                OnPropertyChanged("_Address");

            }
        }

        private string zip;

        public string Zip
        {
            get { return zip; }
            set {
                zip = value;
                OnPropertyChanged("Zip");
            }
        }

       private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)

            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

       
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
