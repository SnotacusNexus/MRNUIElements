using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Controls.Primitives;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using MRNNexus_Model;
using System.Collections.ObjectModel;

namespace MRNUIElements
{
	/// <summary>
	/// Interaction logic for CalendarPage.xaml
	/// </summary>
	public partial class MRNCalendar : System.Web.UI.WebControls.Calendar
	{
		public static Syncfusion.UI.Xaml.Schedule.SfSchedule cal = new Syncfusion.UI.Xaml.Schedule.SfSchedule();
		//System.Windows.Controls.Calendar cal2 = new System.Windows.Controls.Calendar();
		public ObservableCollection<DTO_CalendarData> cd = new ObservableCollection<DTO_CalendarData>();
		public MRNCalendar(ObservableCollection<DTO_CalendarData> c)
		{
			cd = c;


			//cal.VisibleDate = DateTime.Today;
			FillAppointmentDaysDataset();
		}
		protected List<DateTime> AppointmentDays;








		protected void FillAppointmentDaysDataset()
		{
			DateTime firstDate = new DateTime(SelectedDate.Year,
				SelectedDate.Month, 1);
			DateTime lastDate = GetFirstDayOfNextMonth();
			AppointmentDays = GetCurrentMonthData(firstDate, lastDate);
		}

		protected DateTime GetFirstDayOfNextMonth()
		{
			int monthNumber, yearNumber;
			if (SelectedDate.Month == 12)
			{
				monthNumber = 1;
				yearNumber = SelectedDate.Year + 1;
			}
			else
			{
				monthNumber = SelectedDate.Month + 1;
				yearNumber = SelectedDate.Year;
			}
			DateTime lastDate = new DateTime(yearNumber, monthNumber, 1);
			return lastDate;
		}

		protected List<DateTime> GetCurrentMonthData(DateTime firstDate,
			 DateTime lastDate)
		{

			/* DataSet dsMonth = new DataSet();
    ConnectionStringSettings cs;
    cs = ConfigurationManager.ConnectionStrings["ConnectionString1"];
    String connString = cs.ConnectionString;
    SqlConnection dbConnection = new SqlConnection(connString);
    String query;
    query = "SELECT HolidayDate FROM Holidays " + _
        " WHERE HolidayDate >= @firstDate AND HolidayDate < @lastDate";
    SqlCommand dbCommand = new SqlCommand(query, dbConnection);
    dbCommand.Parameters.Add(new SqlParameter("@firstDate", 
        firstDate));
    dbCommand.Parameters.Add(new SqlParameter("@lastDate", lastDate));

    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(dbCommand);
    try
    {
        sqlDataAdapter.Fill(dsMonth);
    }
    catch {}
    return dsMonth;*/
			List<DateTime> dtMonth = new List<DateTime>();

			//if (cd != null) cd.Clear();
			foreach (DTO_CalendarData c in cd)
			{
				if (c.StartTime >= firstDate && c.EndTime <= lastDate)
					dtMonth.Add(c.StartTime.Date);
			}
			return dtMonth;
		}

		protected void cal_DayRender(object sender, DayRenderEventArgs e)
		{
			DateTime nextDate;
			if (AppointmentDays != null)
			{
				int i = 0, j = cd.Count - 1;
				foreach (DTO_CalendarData dr in cd)
				{
					nextDate = (DateTime)cd[i].StartTime.Date;
					if (nextDate == e.Day.Date && cd[i].AppointmentTypeID == 1)
					{
						e.Cell.BackColor = System.Drawing.Color.Pink;
					}
					else if (nextDate == e.Day.Date && cd[i].AppointmentTypeID == 2)
					{
						e.Cell.BackColor = System.Drawing.Color.RoyalBlue;
					}
					else e.Cell.BackColor = System.Drawing.Color.Purple;
				}
			}
		}
		protected void Calendar1_VisibleMonthChanged(object sender,
			MonthChangedEventArgs e)
		{
			FillAppointmentDaysDataset();
		}



	}
}