using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MRNUIElements.Controllers
{
  

    /// <summary>
    /// Interaction logic for RoofSchedulerPage.xaml
    /// </summary>
    public partial class RoofSchedulerPage : Page
    {
        public ObservableCollection<MappedAppointment> MappedAppointments { get; set; }
        public RoofSchedulerPage()
        {
            InitializeComponent();
            top.Navigate("http://www.google.com");
            mid.Navigate("http://www.weather.com");
            back.Navigate("http://www.yahoo.com");

            MappedAppointments = new ObservableCollection<MappedAppointment>

{

new MappedAppointment{MappedSubject = "Meeting", MappedStartTime = DateTime.Now.Date.AddHours(10),

                 MappedEndTime = DateTime.Now.Date.AddHours(11)},

new MappedAppointment{MappedSubject = "Conference", MappedStartTime = DateTime.Now.Date.AddHours(15),

                 MappedEndTime = DateTime.Now.Date.AddHours(16)},

};

            this.DataContext = this;

        }

    }



    public class MappedAppointment

    {

        public string MappedSubject { get; set; }

        public DateTime MappedStartTime { get; set; }

        public DateTime MappedEndTime { get; set; }

    }
}
   