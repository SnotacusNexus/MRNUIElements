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
    
    public class Plane : DTO_Plane, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private int _PlaneID;
        public int PlaneID
        {
            get { return _PlaneID; }
            set
            {
                if (value != _PlaneID)
                {
                    _PlaneID = value;
                    OnPropertyChanged("PlaneID");
                }
            }
        }
        private int _PlaneTypeID;
        public int PlaneTypeID
        {
            get { return _PlaneTypeID; }
            set
            {
                if (value != _PlaneTypeID)
                {
                    _PlaneTypeID = value;
                    OnPropertyChanged("PlaneTypeID");
                }
            }
        }
      
        public int InspectionID { get; set; }
        
        public int GroupNumber { get; set; }
        
        public int? NumOfLayers { get; set; }
        
        public int? ThreeAndOne { get; set; }
        public int? FourAndUp { get; set; }
        
        public int? Pitch { get; set; }
        
		public int? Hip { get; set; }
		
		public int? Valley { get; set; }
        
        public int? RidgeLength { get; set; }
		
		public int? TurtleBacks { get; set; }
		
        public int? RakeLength { get; set; }
        
        public int? EaveHeight { get; set; }
        
        public int? EaveLength { get; set; }
        
        public int? NumberDecking { get; set; }
        
        public int? StepFlashing { get; set; }
        
        public double? SquareFootage { get; set; }
        
        public string ItemSpec { get; set; }
        
    }
}
