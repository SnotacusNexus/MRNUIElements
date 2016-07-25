using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MRNNexus_Model;
using static MRNUIElements.Models.Appointments;
using System.Collections.ObjectModel;
using System.Windows;

namespace MRNUIElements.Controllers
{
	internal class Scheduler
	{
		public ObservableCollection<MappedAppointment> MappedAppointments = new ObservableCollection<MappedAppointment>();
		public ObservableCollection<TodaysAppointment> TodaysAppointments = new ObservableCollection<TodaysAppointment>();

		public async  Task<int>  GetEmployeeAppointments()
		{
			ServiceLayer s = ServiceLayer.getInstance();

			//await s.MakeRequest(new DTO_User { Username = usernameBox.Text, Pass = passwordBox.Text }, typeof(DTO_Employee), "Login");
			await s.MakeRequest(s.LoggedInEmployee, typeof(List<DTO_CalendarData>), "GetCalendarDataByEmployeeID");

			foreach (var calData in s.CalendarDataList)
			{

				await s.MakeRequest(new DTO_Lead { LeadID = (int)calData.LeadID }, typeof(DTO_Lead), "GetLeadByLeadID");
				await s.MakeRequest(new DTO_Address { AddressID = (int)s.Lead.AddressID }, typeof(DTO_Address), "GetAddressByID");
				MappedAppointments.Add(new MappedAppointment
				{
					MappedSubject = s.AppointmentTypes[calData.AppointmentTypeID - 1].AppointmentType,
					MappedStartTime = calData.StartTime,
					MappedEndTime = calData.EndTime,
					MappedNote = calData.Note,
					MappedLocation = "Some Location",
					CalendarDataID = calData.EntryID,
					LeadID = (int) calData.LeadID,
					AddressID = s.Lead.AddressID


					
				});


				/* TODAYS APPOINTMENTS*/
				DateTime time = new DateTime(calData.StartTime.Year, calData.StartTime.Month, calData.StartTime.Day);
				//if(time == DateTime.Today)
				if (time == new DateTime(2016, 5, 10))
				{

					await s.MakeRequest(new DTO_Lead { LeadID = (int)calData.LeadID }, typeof(DTO_Lead), "GetLeadByLeadID");
					await s.MakeRequest(new DTO_Address { AddressID = (int)s.Lead.AddressID }, typeof(DTO_Address), "GetAddressByID");
					
					TodaysAppointments.Add(new TodaysAppointment
					{
						AppointmentType = s.AppointmentTypes[calData.AppointmentTypeID - 1].AppointmentType,
						StartTime = calData.StartTime.ToString("h:mm tt"), //calData.StartTime.TimeOfDay.ToString("tt"),
						EndTime = calData.EndTime.ToString("h:mm tt"), //calData.EndTime.TimeOfDay.ToString(),
						Note = calData.Note,
						Address = s.Address1.Address + " " + s.Address1.Zip,
						CalendarDataID = calData.EntryID,
						LeadID = (int)calData.LeadID,
						AddressID = s.Lead.AddressID
					});
				}
			}
			return s.CalendarDataList.Count();
		}

		public async Task UpdateCalendarData(Syncfusion.UI.Xaml.Schedule.AppointmentEditorClosedEventArgs e)
		{
			MappedAppointment appointment = e.EditedAppointment as MappedAppointment;
			MappedAppointment original = e.OriginalAppointment as MappedAppointment;

			appointment.CalendarDataID = original.CalendarDataID;
			appointment.LeadID = original.LeadID;
			

			ServiceLayer s = ServiceLayer.getInstance();
			s.CalendarData = s.CalendarDataList.Find (c => c.EntryID == appointment.CalendarDataID);
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

		//public async Task AddCalendarData()
		//{

		//}
	}
}
