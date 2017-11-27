using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using MRNNexus_Model;
namespace   MRNUIElements.DataObjectModels
{
    [KnownType(typeof(DTO_Base))]
    
    public class ClaimStatus : DTO_ClaimStatus, INotifyPropertyChanged
    {

        private int _ClaimStatusID;
        public int ClaimStatusID
        {
            get { return _ClaimStatusID; }
            set
            {
                if (value != _ClaimStatusID)
                {
                    _ClaimStatusID = value;
                    OnPropertyChanged("ClaimStatusID");
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

        private int _ClaimStatusTypeID;
        public int ClaimStatusTypeID
        {
            get { return _ClaimStatusTypeID; }
            set
            {
                if (value != _ClaimStatusTypeID)
                {
                    _ClaimStatusTypeID = value;
                    OnPropertyChanged("ClaimStatusTypeID");
                }
            }
        }






        private DateTime _ClaimStatusDate;
        public DateTime ClaimStatusDate
        {
            get { return _ClaimStatusDate; }
            set
            {
                if (value != _ClaimStatusDate)
                {
                    _ClaimStatusDate = value;
                    OnPropertyChanged("ClaimStatusDate");
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
