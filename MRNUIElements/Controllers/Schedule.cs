﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRNUIElements;
using MRNNexus_Model;
using static MRNUIElements.Models.Appointments;
using System.Collections.ObjectModel;
using System.Windows;
using MRNUIElements.Controllers;
using MRNUIElements.Models;
namespace MRNUIElements.Controllers
{
	partial class Schedule
	{
		static ServiceLayer s = ServiceLayer.getInstance();
		public ObservableCollection<Appointments.MappedAppointment> MappedAppointments = new ObservableCollection<Appointments.MappedAppointment>();
		public ObservableCollection<Appointments.TodaysAppointment> TodaysAppointments = new ObservableCollection<Appointments.TodaysAppointment>();

		public async Task GetEmployeeAppointments()
		{


			//await s.MakeRequest(new DTO_User { Username = usernameBox.Text, Pass = passwordBox.Text }, typeof(DTO_Employee), "Login");
			await s.MakeRequest(s.LoggedInEmployee, typeof(List<DTO_CalendarData>), "GetCalendarDataByEmployeeID");

			foreach (var calData in s.CalendarDataList)
			{

				await s.MakeRequest(new DTO_Lead { LeadID = (int)calData.LeadID }, typeof(DTO_Lead), "GetLeadByLeadID");
				await s.MakeRequest(new DTO_Address { AddressID = (int)s.Lead.AddressID }, typeof(DTO_Address), "GetAddressByID");
				MappedAppointments.Add(new Appointments.MappedAppointment
				{
					MappedSubject = s.AppointmentTypes[calData.AppointmentTypeID - 1].AppointmentType,
					MappedStartTime = calData.StartTime,
					MappedEndTime = calData.EndTime,
					MappedNote = calData.Note,
					MappedLocation = "Some Location",
					CalendarDataID = calData.EntryID,
					LeadID = (int)calData.LeadID,
					AddressID = s.Lead.AddressID


				});


				/* TODAYS APPOINTMENTS*/
				DateTime time = new DateTime(calData.StartTime.Year, calData.StartTime.Month, calData.StartTime.Day);
				//if(time == DateTime.Today)
				if (time >= new DateTime(2016, 5, 10))
				{

					await s.MakeRequest(new DTO_Lead { LeadID = (int)calData.LeadID }, typeof(DTO_Lead), "GetLeadByLeadID");
					await s.MakeRequest(new DTO_Address { AddressID = (int)s.Lead.AddressID }, typeof(DTO_Address), "GetAddressByID");

					TodaysAppointments.Add(new Appointments.TodaysAppointment
					{
						AppointmentType = s.AppointmentTypes[calData.AppointmentTypeID - 1].AppointmentType,
						StartTime = calData.StartTime.ToString("h:mm tt"), //calData.StartTime.TimeOfDay.ToString("tt"),
						EndTime = calData.EndTime.ToString("h:mm tt"), //calData.EndTime.TimeOfDay.ToString(),
						Note = calData.Note,
						Address = s.Address.Address + " " + s.Address.Zip,
						CalendarDataID = calData.EntryID,
						LeadID = (int)calData.LeadID,
						AddressID = s.Lead.AddressID
					});
				}
			}
		}

		public async Task UpdateCalendarData(Syncfusion.UI.Xaml.Schedule.AppointmentEditorClosedEventArgs e)
		{
            Appointments.MappedAppointment appointment = e.EditedAppointment as Appointments.MappedAppointment;
            Appointments.MappedAppointment original = e.OriginalAppointment as Appointments.MappedAppointment;

			appointment.CalendarDataID = original.CalendarDataID;
			appointment.LeadID = original.LeadID;


			ServiceLayer s = ServiceLayer.getInstance();
			s.CalendarData = s.CalendarDataList.Find(c => c.EntryID == appointment.CalendarDataID);
			s.CalendarData.StartTime = appointment.MappedStartTime;
			s.CalendarData.EndTime = appointment.MappedEndTime;
			s.CalendarData.Note = appointment.MappedNote;

			await s.MakeRequest(s.CalendarData, typeof(DTO_CalendarData), "UpdateCalendarData");

			if (s.CalendarData.SuccessFlag)
			{
				MessageBox.Show(s.CalendarData.SuccessFlag.ToString(), "Success", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			else
			{
				MessageBox.Show(s.CalendarData.SuccessFlag.ToString(), "Failure", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}
	}
}
