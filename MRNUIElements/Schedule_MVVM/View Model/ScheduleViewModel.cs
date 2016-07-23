using Syncfusion.UI.Xaml.Schedule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_MVVM
{
    public class ScheduleViewModel : INotifyPropertyChanged
    {
        #region Properties

        #region ScheduleAppointmentCollection
        private ObservableCollection<ScheduleAppointmentModel> scheduleAppointmentCollection = new ObservableCollection<ScheduleAppointmentModel>();

        public ObservableCollection<ScheduleAppointmentModel> ScheduleAppointmentCollection
        {
            get
            {
                return scheduleAppointmentCollection;
            }
            set
            {
                this.scheduleAppointmentCollection = value;
                OnPropertyChanged("ScheduleAppointmentCollection");
            }
        }
        #endregion

        #endregion

        #region Constructor

        public ScheduleViewModel()
        {
            var startDate = DateTime.Now.Date.StartOfWeek(DayOfWeek.Monday);
            ScheduleAppointmentModel appointment1 = new ScheduleAppointmentModel()
            {
                StartTime = startDate.AddHours(5),
                EndTime = startDate.AddHours(6),
                Subject = "Johny's Appointment",
            };

            ScheduleAppointmentModel appointment2 = new ScheduleAppointmentModel()
            {
                StartTime = startDate.AddDays(1).AddHours(6),
                EndTime = startDate.AddDays(1).AddHours(7),
                Subject = "Neal's Appointment"
            };

            ScheduleAppointmentModel appointment3 = new ScheduleAppointmentModel()
            {
                StartTime = startDate.AddDays(2).AddHours(7),
                EndTime = startDate.AddDays(2).AddHours(8),
                Subject = "Peter's Appointment"
            };

            ScheduleAppointmentModel appointment4 = new ScheduleAppointmentModel()
            {
                StartTime = startDate.AddDays(3).AddHours(8),
                EndTime = startDate.AddDays(3).AddHours(9),
                Subject = "Morgan's Appointment"
            };

            ScheduleAppointmentModel appointment5 = new ScheduleAppointmentModel()
            {
                StartTime = startDate.AddDays(4).AddHours(9),
                EndTime = startDate.AddDays(4).AddHours(10),
                Subject = "Smith's Appointment"
            };

            scheduleAppointmentCollection.Add(appointment1);
            scheduleAppointmentCollection.Add(appointment2);
            scheduleAppointmentCollection.Add(appointment3);
            scheduleAppointmentCollection.Add(appointment4);
            scheduleAppointmentCollection.Add(appointment5);
        }

        #endregion

        #region PropertyChanged Event

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));

        }

        #endregion
    }
}
