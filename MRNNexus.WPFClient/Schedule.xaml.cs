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

using MRNNexus.WPFClient.Models;
using MRNNexus.WPFClient.Controllers;
using Syncfusion.UI.Xaml.Grid;

namespace MRNNexus.WPFClient
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : Page
    {
        MRNNexusDTOs.DTO_CalendarData calData;

        GridRowSizingOptions gridRowSizingOptions = new GridRowSizingOptions();

        double autoHeight;

        public Schedule()
        {
            InitializeComponent();

            setUp();

            
            this.appointments.QueryRowHeight += appointments_QueryRowHeight;
;


        }

        void appointments_QueryRowHeight(object sender, QueryRowHeightEventArgs e)
        {
            if(this.appointments.GridColumnSizer.GetAutoRowHeight(e.RowIndex, gridRowSizingOptions, out autoHeight))
            {
                if(autoHeight > 24)
                {
                    e.Height = autoHeight;
                    e.Handled = true;
                }
            }
        }

        async private void setUp()
        {
            Controllers.Schedule schedule = new Controllers.Schedule();
            await schedule.GetEmployeeAppointments();
            this.calendar.ItemsSource = schedule.MappedAppointments;
            this.appointments.ItemsSource = schedule.TodaysAppointments;
        }

        private void appointments_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {
            var record = this.appointments.SelectedItem;
            var calDataInt = ((Appointments.TodaysAppointment)record).CalendarDataID;

            foreach(var cd in ServiceLayer.getInstance().CalendarDataList)
            {
                if(cd.EntryID == calDataInt)
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
			Controllers.Schedule schedule = new Controllers.Schedule();

		}

		private async void calendar_AppointmentEditorClosed(object sender, Syncfusion.UI.Xaml.Schedule.AppointmentEditorClosedEventArgs e)
		{

			if (e.EditedAppointment != null && e.Action == Syncfusion.UI.Xaml.Schedule.EditorClosedAction.Save)
				
			{
				if (e.IsNew )
				{
					//create new record
				}
				else if(!e.OriginalAppointment.Equals(e.EditedAppointment))
				{

					

					Controllers.Schedule schedule = new Controllers.Schedule();
					await schedule.UpdateCalendarData(e);
				}
			}
		}
	}
}
