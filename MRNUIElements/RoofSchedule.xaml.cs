using System;
using System.Collections.Generic;
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
using Syncfusion.UI.Xaml.Schedule;
namespace MRNUIElements
{
    /// <summary>
    /// Interaction logic for RoofSchedule.xaml
    /// </summary>
    public partial class RoofSchedule : Page
    {

        public DateTime currentDate { get; set; }
        public DateTime nextDate { get; set; }
        public RoofSchedule()
        {
            currentDate = DateTime.Today;
            nextDate = DateTime.Today.AddDays(3);
            InitializeComponent();
            CreateRoofScheduleItems();

        }

        void CreateRoofScheduleItems()
        {

            ScheduleAppointment app = new ScheduleAppointment() { StartTime = currentDate, EndTime = currentDate.AddHours(1), Subject = "Roof", Location = "Customer Name1", AppointmentBackground = Brushes.AliceBlue };

            app.ResourceCollection.Add(new Resource() { ResourceName = "Roofs", TypeName = "RoofOrders" });



            ScheduleAppointment app1 = new ScheduleAppointment() { StartTime = nextDate, EndTime = nextDate.AddHours(3), Subject = "Inspection", Location = "Potential Customer1", AppointmentBackground = Brushes.Gold };

            app1.ResourceCollection.Add(new Resource() { ResourceName = "Inspections", TypeName = "Inspections" });

            Schedule1.Appointments.Add(app);

            Schedule1.Appointments.Add(app1);

        }
    }
}
