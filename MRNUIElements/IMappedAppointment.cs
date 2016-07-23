using System;

namespace MRNUIElements
{
    public interface IMappedAppointment
    {
        int AddressID { get; set; }
        int CalendarDataID { get; set; }
        int LeadID { get; set; }
        DateTime MappedEndTime { get; set; }
        string MappedLocation { get; set; }
        string MappedNote { get; set; }
        DateTime MappedStartTime { get; set; }
        string MappedSubject { get; set; }

        bool Equals(object obj);
    }
}