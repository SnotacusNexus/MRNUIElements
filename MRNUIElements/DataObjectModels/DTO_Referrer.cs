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
    
    public class Referrer : DTO_Referrer, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int  _ReferrerID;
        public int  ReferrerID
        {
            get { return _ReferrerID; }
            set
            {
                if (value != _ReferrerID)
                {
                    _ReferrerID = value;
                    OnPropertyChanged("ReferrerID");
                }
            }
        }
        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (value != _FirstName)
                {
                    _FirstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }
        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (value != _LastName)
                {
                    _LastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        private string _MailingAddress;
        public string MailingAddress
        {
            get { return _MailingAddress; }
            set
            {
                if (value != _MailingAddress)
                {
                    _MailingAddress = value;
                    OnPropertyChanged("MailingAddress");
                }
            }
        }
        private string _Suffix;
        public string Suffix
        {
            get { return _Suffix; }
            set
            {
                if (value != _Suffix)
                {
                    _Suffix = value;
                    OnPropertyChanged("Suffix");
                }
            }
        }
        private string _Zip;
        public string Zip
        {
            get { return _Zip; }
            set
            {
                if (value != _Zip)
                {
                    _Zip = value;
                    OnPropertyChanged("Zip");
                }
            }
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                if (value != _Email)
                {
                    _Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        private string _CellPhone;
        public string CellPhone
        {
            get { return _CellPhone; }
            set
            {
                if (value != _CellPhone)
                {
                    _CellPhone = value;
                    OnPropertyChanged("CellPhone");
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
        
		public override string ToString()
		{
			return FirstName + " " + LastName.ToString();
		}
	}
}
