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

using MRNUIElements.Models;
using static MRNUIElements.Models.Appointments;
using MRNUIElements.Controllers;
using Syncfusion.UI.Xaml.Grid;
namespace MRNUIElements
{
    /// <summary>
    /// Interaction logic for InspectionSchedule.xaml
    /// </summary>
    public partial class InspectionSchedule : Page
    {
        
        MRNNexus_Model.DTO_CalendarData calData;

        GridRowSizingOptions gridRowSizingOptions = new GridRowSizingOptions();

        double autoHeight;

        public InspectionSchedule()
        {
            InitializeComponent();
      
            setUp();


            this.appointments.QueryRowHeight += appointments_QueryRowHeight;
            


        }

        void appointments_QueryRowHeight(object sender, QueryRowHeightEventArgs e)
        {
            if (this.appointments.GridColumnSizer.GetAutoRowHeight(e.RowIndex, gridRowSizingOptions, out autoHeight))
            {
                if (autoHeight > 24)
                {
                    e.Height = autoHeight;
                    e.Handled = true;
                }
            }
        }

        async private void setUp()
        {
            Schedule schedule = new Schedule();
           bool hasAppointments = await schedule.GetEmployeeAppointments();
          if (!hasAppointments)
            {
               await Task.Delay(10000);
                calendar.ItemsSource = schedule.MappedAppointments;
                appointments.ItemsSource = schedule.TodaysAppointments;
            }
        }

        private void appointments_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {
            Appointments.TodaysAppointment record = new Appointments.TodaysAppointment();
            record = (Appointments.TodaysAppointment)appointments.SelectedItem;
            int calDataInt = record.CalendarDataID;

            foreach (var cd in ServiceLayer.getInstance().CalendarDataList)
            {
                if (cd.EntryID == calDataInt)
                {
                    calData = cd;
                    break;
                }
            }
        }

        private void appointments_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (calData != null)
            {
                MessageBox.Show(calData.EntryID.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                calData = null;
            }
        }

        private void calendar_AppointmentCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //e holds the new record
            Schedule schedule = new Schedule();

        }

        private async void calendar_AppointmentEditorClosed(object sender, Syncfusion.UI.Xaml.Schedule.AppointmentEditorClosedEventArgs e)
        {

            if (e.EditedAppointment != null && e.Action == Syncfusion.UI.Xaml.Schedule.EditorClosedAction.Save)

            {
                if (e.IsNew)
                {
                    //create new record
                }
                else if (!e.OriginalAppointment.Equals(e.EditedAppointment))
                {



                    Schedule schedule = new Schedule();
                    await schedule.UpdateCalendarData(e);
                }
            }
        }
    }
}


  
