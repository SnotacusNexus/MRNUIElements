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
    public class ScheduleAppointmentModel : INotifyPropertyChanged
    {
        #region Properties

        #region StartTime
        private DateTime startTime;
        public DateTime StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                this.startTime = value;
                OnPropertyChanged("StarTime");

            }
        }
        #endregion

        #region EndTime
        private DateTime endTime;
        public DateTime EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                this.endTime = value;
                OnPropertyChanged("EndTime");

            }

        }
        #endregion

        #region Subject
        private string subject;
        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                this.subject = value;
                OnPropertyChanged("StarTime");

            }
        }
        #endregion

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
