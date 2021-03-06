﻿using System;
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
using MRNUIElements.Controllers;
using Syncfusion.UI.Xaml.Grid;

namespace MRNUIElements

{
	/// <summary>
	/// Interaction logic for Schedule.xaml
	/// </summary>
	public partial class Schedule : Page
	{
	   MRNNexus_Model.DTO_CalendarData calData;

		GridRowSizingOptions gridRowSizingOptions = new GridRowSizingOptions();

		double autoHeight;

		public Schedule()
		{
			InitializeComponent();

			setUp();

			
			this.fappointments.QueryRowHeight += fappointments_QueryRowHeight;
;


		}

		void fappointments_QueryRowHeight(object sender, QueryRowHeightEventArgs e)
		{
			if(this.fappointments.GridColumnSizer.GetAutoRowHeight(e.RowIndex, gridRowSizingOptions, out autoHeight))
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
		//	this.appointments.ItemsSource = schedule.TodaysAppointments;
			this.fappointments.ItemsSource = schedule.FutureAppointments;
		}

		private void fappointments_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
		{
			var record = this.fappointments.SelectedItem;
			var calDataInt = ((Appointments.FutureAppointment)record).CalendarDataID;

			foreach(var cd in ServiceLayer.getInstance().CalendarDataList)
			{
				if(cd.EntryID == calDataInt)
				{
					calData = cd;
					break;
				}
			}
		}

		private void fappointments_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
