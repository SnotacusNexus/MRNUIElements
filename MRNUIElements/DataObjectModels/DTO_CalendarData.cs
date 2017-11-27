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
   
    public class CalendarData : DTO_CalendarData,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
     
        public int EntryID { get; set; }
     
        public int EmployeeID { get; set; }
       
        public int AppointmentTypeID { get; set; }
       
        public Nullable<int> LeadID { get; set; }

        public DateTime StartTime { get; set; }
		

        public DateTime EndTime { get; set; }
		
		
        public Nullable<int> ClaimID { get; set; }
       
        public string Note { get; set; }

		public string AppointmentText { get; set; }
		
	}
}
