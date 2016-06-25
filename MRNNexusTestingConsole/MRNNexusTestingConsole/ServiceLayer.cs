using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


using MRNNexus_Model;

namespace MRNNexusTestingConsole
{
    public class ServiceLayer
    {
        private const string URL = @"http://localhost:50899/MRNNexus_Service.svc/";
        private HttpClient client = new HttpClient();
        public DTO_Employee employee;
        public DTO_User user;
		public DTO_CalendarData calData;

        public ServiceLayer()
        {
            client.BaseAddress = new Uri(URL);
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			//client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
				//System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "aharvey0812@gmail.com", "Harvey9565"))));
            client.Timeout = new TimeSpan(0, 1, 0);
			
        }

        public async Task DoWork()
        {
            try
            {
				DTO_CalendarData token = new DTO_CalendarData
				{
					EmployeeID = 3,
					StartTime = new DateTime(2016, 8, 12, 13, 0, 0),
					EndTime = new DateTime(2016, 8, 12, 14, 0, 0),
					Note = "Appointment @123 BrokenRoof Lane with John Doe"
				};

                //string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(token);

                var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddCalendarData"), 
                    token);
                response.EnsureSuccessStatusCode();
                //DTO_Employee message = await response.Content.ReadAsAsync<DTO_Employee>();
                DTO_CalendarData returndata = await response.Content.ReadAsAsync<DTO_CalendarData>();



                //token = JsonConvert.DeserializeObject<DTO_Employee>(message);

                //Console.WriteLine(message.EmployeeID);
                calData = returndata; 

            }catch (Exception e)
            {
				Console.Write(e.StackTrace);
            }
        }
    }
}
