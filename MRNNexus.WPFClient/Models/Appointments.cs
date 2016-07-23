using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;

namespace MRNNexus.WPFClient.Models
{
	internal class Appointments
	{
		internal class MappedAppointment
		{
			public string MappedSubject { get; set; }
			public DateTime MappedStartTime { get; set; }
			public DateTime MappedEndTime { get; set; }
			public string MappedNote { get; set; }
			public string MappedLocation { get; set; }

			public int CalendarDataID { get; set; }
			public int LeadID { get; set; }
			public int AddressID { get; set; }

			public override bool Equals(object obj)
			{
				MappedAppointment mp = obj as MappedAppointment;
				if (string.Equals(this.MappedSubject, mp.MappedSubject) &&
					this.MappedStartTime == mp.MappedStartTime &&
					this.MappedEndTime == mp.MappedEndTime &&
					string.Equals(this.MappedNote, mp.MappedNote) &&
					string.Equals(this.MappedLocation, mp.MappedLocation))
					return true;
				else
					return false;
			}
		}

		public class TodaysAppointment
		{
			public string AppointmentType { get; set; }
			public string StartTime { get; set; }
			public string EndTime { get; set; }
			public string Note { get; set; }
			public string Address { get; set; }

			public int CalendarDataID { get; set; }
			public int LeadID { get; set; }
			public int AddressID { get; set; }
		}
	}
}
