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
    internal class Schedule
    {
        static public ServiceLayer s = ServiceLayer.getInstance();
        public ObservableCollection<MappedAppointment> MappedAppointments = new ObservableCollection<MappedAppointment>();
        public ObservableCollection<TodaysAppointment> TodaysAppointments = new ObservableCollection<TodaysAppointment>();
        public ObservableCollection<FutureAppointment> FutureAppointments = new ObservableCollection<FutureAppointment>();

        public async Task GetEmployeeAppointments()
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
                    MappedLocation = new AddressZipcodeValidation().CityStateLookupRequest(s.Address1.Zip, 1),
                    CalendarDataID = calData.EntryID,
                    LeadID = (int)calData.LeadID,
                    AddressID = s.Lead.AddressID



                });


                /* TODAYS APPOINTMENTS*/

                DateTime time = new DateTime(calData.StartTime.Year, calData.StartTime.Month, calData.StartTime.Day);
                DateTime today = DateTime.Today;

                if (time == DateTime.Today)
                    await s.MakeRequest(new DTO_Lead { LeadID = (int)calData.LeadID }, typeof(DTO_Lead), "GetLeadByLeadID");
                await s.MakeRequest(new DTO_Address { AddressID = (int)s.Lead.AddressID }, typeof(DTO_Address), "GetAddressByID");
               
                TodaysAppointments.Add(new TodaysAppointment
                {
                    AppointmentType = s.AppointmentTypes[calData.AppointmentTypeID - 1].AppointmentType,
                    StartTime = calData.StartTime.ToString("h:mm tt"), //calData.StartTime.TimeOfDay.ToString("tt"),
                    EndTime = calData.EndTime.ToString("h:mm tt"), //calData.EndTime.TimeOfDay.ToString(),
                    Note = calData.Note,
                    Address = s.Address1.Address + " " + new AddressZipcodeValidation().CityStateLookupRequest(s.Address1.Zip,1),
                    CalendarDataID = calData.EntryID,
                    LeadID = (int)calData.LeadID,
                    AddressID = s.Lead.AddressID,
                 

                });
                /* TODAYS APPOINTMENTS*/

                DateTime ftime = new DateTime(calData.StartTime.Year, calData.StartTime.Month, calData.StartTime.Day);


                if (time >= today.Date)
                    await s.MakeRequest(new DTO_Lead { LeadID = (int)calData.LeadID }, typeof(DTO_Lead), "GetLeadByLeadID");
                await s.MakeRequest(new DTO_Address { AddressID = (int)s.Lead.AddressID }, typeof(DTO_Address), "GetAddressByID");
                await GetCustomerDetailsByLeadID();
                //string city = new AddressZipcodeValidation().CityStateLookupRequest(s.Address1.Zip,1).ToString();
                //int i = city.IndexOf("<City>")+6;
                //int l = city.LastIndexOf("<City>");
                //int k = city.IndexOf("</City>");
                //int j = city.IndexOf("</City>") - city.IndexOf("<City>")-6;
                FutureAppointments.Add(new FutureAppointment
                {
                    AppointmentType = s.AppointmentTypes[calData.AppointmentTypeID - 1].AppointmentType,
                    Date = calData.StartTime.Date.ToString("MM/dd/yyyy"),
                    Time = calData.StartTime.ToString("h:mm tt"), //calData.StartTime.TimeOfDay.ToString("tt"),
                    Address = new AddressZipcodeValidation().CityStateLookupRequest(s.Address1.Zip, 1).ToString(),
                    CalendarDataID = calData.EntryID,
                    LeadID = (int)calData.LeadID,
                    AddressID = s.Lead.AddressID,
                    CustomerName =  CustomerName,
                    CustomerPhone1 = CustomerPhone1,
                    CustomerPhone2 = CustomerPhone2,
                    CustomerEmail = CustomerEmail
                });
            }
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
        string CustomerName = "", CustomerPhone1 = "", CustomerPhone2 = "", CustomerEmail = "";
        
        public async Task GetCustomerDetailsByLeadID(int leadID=0)
        {
            if (leadID == 0)
                leadID = s.Lead.LeadID;
           
                DTO_Lead ld = new DTO_Lead();
                ld.LeadID = leadID;
           
                DTO_Customer cu = new DTO_Customer();
                DTO_Address ad = new DTO_Address();
                
                await s.GetLeadByLeadID(ld);
                ld = s.Lead;
                ad.AddressID = ld.AddressID;
                cu.CustomerID = ld.CustomerID;
            
			await s.GetCustomerByID(cu);
        await s.GetAddressByID(ad);
        cu = s.Cust;
			ad = s.Address1;
                  if (cu.PrimaryNumber != string.Empty)
                    CustomerPhone1= cu.PrimaryNumber;
                    
                 if (cu.SecondaryNumber != string.Empty)
                    CustomerPhone2= cu.SecondaryNumber;
                   
                 if (cu.Email != string.Empty)
                      CustomerEmail = cu.Email;
                 string FinishedName = "";
                    if (cu.FirstName != string.Empty)
                        FinishedName += cu.FirstName + " ";

                    if (cu.MiddleName != string.Empty)
                        FinishedName += cu.MiddleName + " ";

                    if (cu.LastName != string.Empty)
                        FinishedName += cu.LastName + " ";

                    if (cu.Suffix != string.Empty)
                        FinishedName += cu.Suffix;
                    CustomerName= FinishedName;
            
            
		}
	}
}
