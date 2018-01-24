
using System;

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

using System.IO;

using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;


using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

using static MRN_Claim_Services.MainWindow;
using MRNNexus_Model;
using Newtonsoft.Json.Linq;
using static Newtonsoft.Json.Linq.JToken;
using System.Collections;
using System.Net.Http.Formatting;//using System.Net.Http.Formatting;
using System.Windows.Controls;
using System.Collections.ObjectModel;

//using System.Web.Script.Serialization;
using System.Diagnostics;
using System.Web.Helpers;
using System.ServiceModel.Web;
using System.ComponentModel;

namespace MRN_Claim_Services.Controllers
{
	public partial class ServiceLayer
	{
      //  static MainWindow mw = MainWindow.getMainWindowInstance(); 
		//public TextBlock mw = (TextBlock)App.Current.MainWindow.TryFindResource("VerboseStatusDisplay");

		//	int errorcount = 0;
		public string hold = "";
		//private const string URL = @"http://services.mrncontracting.com/MRNNexus_Service.svc/";
		private const string URL = @"http://localhost/MRNNexus_Service/MRNNexus_Service.svc/";
		private HttpClient client = new HttpClient();
		public static ServiceLayer s1;
		//public DateTime serviceCreated;
		public static DTO_Claim CurrentClaim;

		public static bool DoneLoading;
		//	public static ObservableCollection<DTO_ClaimStatus> CurrentClaimStatus { get; set; }
		//	public static ObservableCollection<ClaimData> 
		private ServiceLayer()
		{
			//	var mw = App.Current.MainWindow.TryFindResource("VerboseStatusDisplay");
			
		//	getCurrentClaim();

		}

		public static DTO_Claim getCurrentClaim()
		{

			if (CurrentClaim == null)
				CurrentClaim = new DTO_Claim();

			return CurrentClaim;

		}

		public static ServiceLayer getInstance()
		{
			if (s1 == null)
			{
				try
				{
					s1 = new ServiceLayer();

				}
				catch (Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.ToString());
				}
			}

			return s1;
		}
		
			
		//public async Task<bool> GetData( DTO_Base token, Type type, string methodName)
		//{
		//	// Clear text of Output textbox 
	

		//		var httpClient = new HttpClient();
		
		
		//	try
		//	{
		//		string resourceAddress =URL+"/"+methodName;
							
		//		httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		//		string obody = JsonSerializer(token);
		//		var result = await httpClient.PostAsync(resourceAddress, new StringContent(obody, Encoding.UTF8, "application/json"));

		//		string results = await jsonresult.Content.ReadAsStringAsync().Result);
		//		setResults(results, type, methodName);

		//	}
		//	catch (HttpRequestException hre)
		//	{
		//		NotifyUser("Error:" + hre.Message);
		//	}
		//	catch (TaskCanceledException)
		//	{
		//		NotifyUser("Request canceled.");
		//	}
		//	catch (Exception ex)
		//	{
		//		NotifyUser(ex.Message);
		//	}
		//	finally
		//	{
				
		//		if (httpClient != null)
		//		{
		//			httpClient.Dispose();
		//			httpClient = null;
		//		}
				
		//	}
			
		//	return true;
		//}
		public void NotifyUser(string message)
		{
			System.Windows.Forms.MessageBox.Show(message);
		}


		public async Task<bool> MakeRequest(DTO_Base token, Type returnType, string methodName)
		{


            var client = new HttpClient
            {
                //		var client2 = new HttpClient();
                BaseAddress = new Uri(URL)
            };
            //		client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //		client2.Timeout = new TimeSpan(0, 5, 0);
            //		client2.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.Timeout = new TimeSpan(0, 5, 0);
			string results = "";

			try {
				//{

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, methodName),
					token);
				//HttpRequestMessage msg = new HttpRequestMessage(new HttpMethod("POST"), new Uri(URL + methodName));
				//msg.Content = new HttpStringContent(json);
				//msg.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("application/json");
				//HttpResponseMessage response = await client.SendRequestAsync(msg).AsTask();
				setResults(await response.Content.ReadAsStringAsync(), returnType, methodName);
			//	string resourceAddress = URL+ methodName;
				
				//	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				//	string obody = JsonSerializer(token);
					//var response = await client.PostAsJsonAsync(resourceAddress, obody);
		//		var response1 = await client.PostAsync(methodName, new StringContent(obody, Encoding.UTF8, "application/json"));
			//	JObject joblect = await response.Content.ReadAsAsync(returnType) as JObject;
		//		string result = await response.Content.ReadAsStringAsync();
			//	var result1 = await response1.Content.ReadAsStringAsync();
			//	//System.Windows.Forms.MessageBox.Show(result);
			//	//System.Windows.Forms.MessageBox.Show(result1);
			//	var c = joblect.ToObject(returnType);
	//		 var b =JsonConvert.DeserializeObject(result1);
			//		//System.Windows.Forms.MessageBox.Show(a.ToString());
			////	System.Windows.Forms.MessageBox.Show(b.ToString());


		//		results = GetJsonValue(result);

	//	var resultd =await client2.PostAsync(resourceAddress, new StringContent(JsonConvert.SerializeObject(token), Encoding.UTF8, "application/json"));
	//			string a = await resultd.Content.ReadAsStringAsync();

	//			setResults(a, returnType, methodName);

			}
			catch (HttpRequestException hre)
			{
				NotifyUser("Error:" + hre.Message);
			}
			catch (TaskCanceledException)
			{
				NotifyUser("Request canceled.");
			}
			catch (Exception ex)
			{
				NotifyUser(ex.Message);
			}
			finally
			{

				//if (client2 != null)
				//{
				//	client2.Dispose();
				//	client2 = null;
				//}
				if (client != null)
				{
					client.Dispose();
					client = null;
				}
			}
		
			return true;
		}
	
		

		/// <summary>
		/// Serialize Person object to Json string
		/// </summary>
		/// <param name="objectToSerialize">Person object instance</param>
		/// <returns>return Json String</returns>
		public string JsonSerializer(Object objectToSerialize)
		{
			if (objectToSerialize == null)
			{
				throw new ArgumentException("objectToSerialize must not be null");
			}
			MemoryStream ms = null;

			DataContractJsonSerializer serializer = new DataContractJsonSerializer(objectToSerialize.GetType());
			ms = new MemoryStream();
			serializer.WriteObject(ms, objectToSerialize);
			ms.Seek(0, SeekOrigin.Begin);
			StreamReader sr = new StreamReader(ms);
			return sr.ReadToEnd();
		}

		

		/// <summary>
		/// Get Result from Json String
		/// </summary>
		/// <param name="jsonString">Json string which returns from WCF Service</param>
		/// <returns>Result string</returns>
		public string GetJsonValue(string jsonString)
		{
		
					
				int ValueLength = jsonString.LastIndexOf("\"") - (jsonString.IndexOf(":") + 2);
				string value = jsonString.Substring(jsonString.IndexOf(":") + 2, ValueLength);

		
				return value;
			
			
		

		}


		async public Task<bool> buildLUs(object sender, BackgroundWorker myWorker)
		{

            int j = 0;
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_AdjustmentResult>), "GetAdjustmentResults");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_AppointmentTypes>), "GetAppointmentTypes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ClaimDocumentType>), "GetClaimDocumentTypes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ClaimStatusTypes>), "GetClaimStatusTypes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_DamageTypes>), "GetDamageTypes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_EmployeeType>), "GetEmployeeTypes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Invoice>), "GetAllInvoices");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_InvoiceType>), "GetInvoiceTypes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_KnockResponseType>), "GetKnockResponseTypes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_LeadType>), "GetLeadTypes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PayFrequncy>), "GetPayFrequencies");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PaymentDescription>), "GetPayDescriptions");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PaymentType>), "GetPaymentTypes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PayType>), "GetPayTypes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_Permissions>), "GetPermissions");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PlaneTypes>), "GetPlaneTypes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ProductType>), "GetProductTypes");
            // mw.Text = "Building Ridge Material Types Lookup Table";
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_RidgeMaterialType>), "GetRidgeMaterialTypes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ScopeType>), "GetScopeTypes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ServiceTypes>), "GetServiceTypes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ShingleType>), "GetShingleTypes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_UnitOfMeasure>), "GetUnitsOfMeasure");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_VendorTypes>), "GetVendorTypes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_InsuranceCompany>), "GetAllInsuranceCompanies");
            // //Non LU
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Inspection>), "GetAllInspections");
            //	 Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetOpenClaimsBySalespersonID");
            // Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Vendor>), "GetAllVendors");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_ClaimDocument>), "GetAllClaimDocuments");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Payment>), "GetAllPayments");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Employee>), "GetAllEmployees");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_ClaimContacts>), "GetAllClaimContacts");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Address>), "GetAllAddresses");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Customer>), "GetAllCustomers");
            // Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_EmployeeDetail>), "GetAllEmployeeDetail");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_Product>), "GetAllProducts");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Scope>), "GetAllScopes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_ClaimStatus>), "GetAllClaimStatuses");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Lead>), "GetAllLeads");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Plane>), "GetAllPlanes");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_User>), "GetAllUsers");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_AdditionalSupply>), "GetAllAdditionalSupplies");
            myWorker.ReportProgress(j++);

           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_SurplusSupplies>), "GetAllSurplusSupplies");
            myWorker.ReportProgress(j++);

           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Referrer>), "GetAllReferrers");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Damage>), "GetAllDamages");
            // Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetAllClaimsToSchedule");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetAllClaims");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_CallLog>), "GetAllCallLogs");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Adjustment>), "GetAllAdjustments");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Adjuster>), "GetAllAdjusters");
            // Task.Run(async()=>await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_AdjustmentResult>), "GetAdjustmentResults");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_NewRoof>), "GetAllNewRoofs");
            myWorker.ReportProgress(j++);
           /* Task.Run(async () =>*/ await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_KnockerResponse>), "GetAllKnockerResponses");
            //Task.Run(async () => await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetAllInactiveClaims");
            //Task.Run(async () => await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetAllClosedClaims");
            if (s1.OpenClaimsList == null)
                s1.OpenClaimsList = s1.getOpenClaims();
            if (s1.ClosedClaimsList == null)
                s1.ClosedClaimsList = s1.getClosedClaims();
            if (s1.InactiveClaimsList == null)
                s1.InactiveClaimsList = s1.getInactiveClaims();
            /* Task.Run(async () =>*/
           return( await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Vendor>), "GetAllVendors"));


            #region OldEnumcode

            //int j = 0;
            //myWorker.ReportProgress(j++);
            ////mw.Text = "Building Adjustment Results Lookup Table";
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_AdjustmentResult>), "GetAdjustmentResults");
            //myWorker.ReportProgress(j++);
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_AppointmentTypes>), "GetAppointmentTypes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ClaimDocumentType>), "GetClaimDocumentTypes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ClaimStatusTypes>), "GetClaimStatusTypes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_DamageTypes>), "GetDamageTypes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_EmployeeType>), "GetEmployeeTypes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Invoice>), "GetAllInvoices");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_InvoiceType>), "GetInvoiceTypes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_KnockResponseType>), "GetKnockResponseTypes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_LeadType>), "GetLeadTypes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PayFrequncy>), "GetPayFrequencies");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PaymentDescription>), "GetPayDescriptions");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PaymentType>), "GetPaymentTypes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PayType>), "GetPayTypes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_Permissions>), "GetPermissions");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PlaneTypes>), "GetPlaneTypes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ProductType>), "GetProductTypes");
            ////	mw.Text = "Building Ridge Material Types Lookup Table";
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_RidgeMaterialType>), "GetRidgeMaterialTypes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ScopeType>), "GetScopeTypes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ServiceTypes>), "GetServiceTypes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ShingleType>), "GetShingleTypes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_UnitOfMeasure>), "GetUnitsOfMeasure");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_VendorTypes>), "GetVendorTypes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_InsuranceCompany>), "GetAllInsuranceCompanies");
            ////	//Non LU
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Inspection>), "GetAllInspections");
            ////	await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetOpenClaimsBySalespersonID");
            ////await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Vendor>), "GetAllVendors");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_ClaimDocument>), "GetAllClaimDocuments");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Payment>), "GetAllPayments");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Employee>), "GetAllEmployees");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_ClaimContacts>), "GetAllClaimContacts");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Address>), "GetAllAddresses");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Customer>), "GetAllCustomers");
            ////await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_EmployeeDetail>), "GetAllEmployeeDetail");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_Product>), "GetAllProducts");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Scope>), "GetAllScopes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_ClaimStatus>), "GetAllClaimStatuses");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Lead>), "GetAllLeads");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Plane>), "GetAllPlanes");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_User>), "GetAllUsers");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_AdditionalSupply>), "GetAllAdditionalSupplies");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_SurplusSupplies>), "GetAllSurplusSupplies");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Referrer>), "GetAllReferrers");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Damage>), "GetAllDamages");
            ////await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetAllClaimsToSchedule");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetAllClaims");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_CallLog>), "GetAllCallLogs");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Adjustment>), "GetAllAdjustments");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Adjuster>), "GetAllAdjusters");
            ////await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_AdjustmentResult>), "GetAdjustmentResults");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_NewRoof>), "GetAllNewRoofs");
            //await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_KnockerResponse>), "GetAllKnockerResponses");
            ////await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetAllInactiveClaims");
            ////await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Claim>), "GetAllClosedClaims");
            //if (OpenClaimsList == null)
            //    OpenClaimsList = getOpenClaims();
            //if (ClosedClaimsList == null)
            //    ClosedClaimsList = getClosedClaims();
            //if (InactiveClaimsList == null)
            //    InactiveClaimsList = getInactiveClaims();
            // DoneLoading = await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_Vendor>), "GetAllVendors");

            #endregion



        }
		public List<DTO_Claim> getOpenClaims()
		{
			var a = new List<DTO_Claim>();
			foreach (var item in ClaimStatusList.Where(x => x.ClaimStatusTypeID < 23))
			{ 
				if (a.Exists(x => x.ClaimID == item.ClaimID))
					a.Add(ClaimsList.Find(x => x.ClaimID == item.ClaimID));
			}

			if (a == null)
			a.Add(new DTO_Claim());
			return a;
		}
		public List<DTO_Claim> getClosedClaims()
		{
			var a = new List<DTO_Claim>();
			foreach (var item in ClaimStatusList.Where(x => x.ClaimStatusTypeID == 23))
			{
				if (a.Exists(x => x.ClaimID == item.ClaimID))
					a.Add(ClaimsList.Find(x => x.ClaimID == item.ClaimID));
			}
			if (a == null)
				a.Add(new DTO_Claim());

			return a;
		}
		public List<DTO_Claim> getInactiveClaims()
		{
			var a = new List<DTO_Claim>();

			foreach (var item in ClaimStatusList.Where(x => x.ClaimStatusTypeID < 23 && x.ClaimStatusDate.AddDays(14) < DateTime.Today))
			{

				if (a.Exists(x => x.ClaimID == item.ClaimID))
				{
					a.Add(ClaimsList.Find(x => x.ClaimID == item.ClaimID));
				}
				else
				{
					//Do Nothing
				}

			}

			if (a == null)
				a.Add(new DTO_Claim());

			return a;
		}
		//GetRecentInspectionsBySalesPersonIDGetRecentLeadsBySalesPersonIDGetRecentClaimsBySalesPersonID

	     



		public void setResults(string json, Type type, string methodName)
		{
			

			if (methodName == "Login")
			{
				Type a = type.GetType();
				//LoggedInEmployee = ((DTO_Employee)JsonConvert.DeserializeObject((string)json, a));
				LoggedInEmployee = JsonConvert.DeserializeObject<DTO_Employee>(json);
				return;
			}            
			if (type == typeof(DTO_AdditionalSupply))
			{
				AdditionalSupply = JsonConvert.DeserializeObject<DTO_AdditionalSupply>(json);
				return;
			}
			if (type == typeof(DTO_Address))
			{
				Address = JsonConvert.DeserializeObject<DTO_Address>(json);
				return;
			}
			if (type == typeof(DTO_Customer))
			{
				Cust = JsonConvert.DeserializeObject<DTO_Customer>(json);
				return;
			}
			if (type == typeof(DTO_ClaimContacts))
			{
				ClaimContacts = JsonConvert.DeserializeObject<DTO_ClaimContacts>(json);
				return;
			}
			if (type == typeof(DTO_Claim))
			{
				Claim = JsonConvert.DeserializeObject<DTO_Claim>(json);
				CurrentClaim = Claim;
				return;
			}
			if (type == typeof(DTO_Employee))
			{
				Employee = JsonConvert.DeserializeObject<DTO_Employee>(json);
				return;
			}

			if (type == typeof(List<DTO_InsuranceCompany>))
			{
				InsuranceCompaniesList = JsonConvert.DeserializeObject<List<DTO_InsuranceCompany>>(json);
				return;
			}
			if (type == typeof(List<DTO_CallLog>))
			{
				CallLogsList = JsonConvert.DeserializeObject<List<DTO_CallLog>>(json);
				return;
			}

			if (type == typeof(DTO_Lead))
			{
				Lead = JsonConvert.DeserializeObject<DTO_Lead>(json);
				return;
			}
			if (type == typeof(DTO_SurplusSupplies))
			{
				SurplusSupplies = JsonConvert.DeserializeObject<DTO_SurplusSupplies>(json);
				return;
			}
			if (type == typeof(List<DTO_CalendarData>))
			{
				CalendarDataList = JsonConvert.DeserializeObject<List<DTO_CalendarData>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_AdjustmentResult>))
			{
				AdjustmentResults = JsonConvert.DeserializeObject<List<DTO_LU_AdjustmentResult>>(json);
				//	mw.Text = "Building Adjustment Results Lookup Table...Completed";
				return;
			}

			if (type == typeof(List<DTO_LU_AppointmentTypes>))
			{
				AppointmentTypes = JsonConvert.DeserializeObject<List<DTO_LU_AppointmentTypes>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_ClaimDocumentType>))
			{
				ClaimDocTypes = JsonConvert.DeserializeObject<List<DTO_LU_ClaimDocumentType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_ClaimStatusTypes>))
			{
				ClaimStatusTypes = JsonConvert.DeserializeObject<List<DTO_LU_ClaimStatusTypes>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_DamageTypes>))
			{
				DamageTypes = JsonConvert.DeserializeObject<List<DTO_LU_DamageTypes>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_EmployeeType>))
			{
				EmployeeTypes = JsonConvert.DeserializeObject<List<DTO_LU_EmployeeType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_InvoiceType>))
			{
				InvoiceTypes = JsonConvert.DeserializeObject<List<DTO_LU_InvoiceType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_KnockResponseType>))
			{
				KnockResponseTypes = JsonConvert.DeserializeObject<List<DTO_LU_KnockResponseType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_LeadType>))
			{
				LeadTypes = JsonConvert.DeserializeObject<List<DTO_LU_LeadType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_PayFrequncy>))
			{
				PayFrequencies = JsonConvert.DeserializeObject<List<DTO_LU_PayFrequncy>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_PaymentDescription>))
			{
				PaymentDescriptions = JsonConvert.DeserializeObject<List<DTO_LU_PaymentDescription>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_PaymentType>))
			{
				PaymentTypes = JsonConvert.DeserializeObject<List<DTO_LU_PaymentType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_PayType>))
			{
				PayTypes = JsonConvert.DeserializeObject<List<DTO_LU_PayType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_Permissions>))
			{
				Permissions = JsonConvert.DeserializeObject<List<DTO_LU_Permissions>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_PlaneTypes>))
			{
				PlaneTypes = JsonConvert.DeserializeObject<List<DTO_LU_PlaneTypes>>(json);
				return;
			}
			if (type == typeof(List<DTO_Adjuster>))
			{
				AdjustersList = JsonConvert.DeserializeObject<List<DTO_Adjuster>>(json);
				return;
			}

			if (type == typeof(List<DTO_Adjustment>))
			{
				AdjustmentsList = JsonConvert.DeserializeObject<List<DTO_Adjustment>>(json);
				return;
			}

			if (type == typeof(List<DTO_NewRoof>))
			{
				NewRoofsList = JsonConvert.DeserializeObject<List<DTO_NewRoof>>(json);
				return;
			}
			if (type == typeof(List<DTO_KnockerResponse>))
			{
				KnockerResponsesList = JsonConvert.DeserializeObject<List<DTO_KnockerResponse>>(json);
				return;
			}
			if (type == typeof(List<DTO_LU_ProductType>))
			{
				ProductTypes = JsonConvert.DeserializeObject<List<DTO_LU_ProductType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_RidgeMaterialType>))
			{
				RidgeMaterialTypes = JsonConvert.DeserializeObject<List<DTO_LU_RidgeMaterialType>>(json);
				//mw.Text = "Building Ridge Material Types Lookup Table";
				return;
			}

			if (type == typeof(List<DTO_LU_ScopeType>))
			{
				ScopeTypes = JsonConvert.DeserializeObject<List<DTO_LU_ScopeType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_ServiceTypes>))
			{
				ServiceTypes = JsonConvert.DeserializeObject<List<DTO_LU_ServiceTypes>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_ShingleType>))
			{
				ShingleTypes = JsonConvert.DeserializeObject<List<DTO_LU_ShingleType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_UnitOfMeasure>))
			{
				UnitsOfMeasure = JsonConvert.DeserializeObject<List<DTO_LU_UnitOfMeasure>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_VendorTypes>))
			{
				VendorTypes = JsonConvert.DeserializeObject<List<DTO_LU_VendorTypes>>(json);
				return;
			}
			if (type == typeof(List<DTO_Referrer>))
			{
				ReferrersList = JsonConvert.DeserializeObject<List<DTO_Referrer>>(json);
				return;
			}
			if (type == typeof(List<DTO_Vendor>))
			{
				VendorsList = JsonConvert.DeserializeObject<List<DTO_Vendor>>(json);
				return;
			}
			if (type == typeof(List<DTO_ClaimDocument>))
			{
				ClaimDocumentsList = JsonConvert.DeserializeObject<List<DTO_ClaimDocument>>(json);
				return;
			}
			if (type == typeof(List<DTO_Invoice>))
			{
				InvoicesList = JsonConvert.DeserializeObject<List<DTO_Invoice>>(json);
				return;
			}
			if (type == typeof(List<DTO_ClaimStatus>))
			{
				ClaimStatusList = JsonConvert.DeserializeObject<List<DTO_ClaimStatus>>(json);
				return;
			}
			if (type == typeof(List<DTO_Payment>))
			{
				PaymentsList = JsonConvert.DeserializeObject<List<DTO_Payment>>(json);

				return;
			}
			if (type == typeof(List<DTO_Employee>))
			{
				EmployeesList = JsonConvert.DeserializeObject<List<DTO_Employee>>(json);
				return;
			}
			if (type == typeof(List<DTO_ClaimContacts>))
			{
				ClaimContactsList = JsonConvert.DeserializeObject<List<DTO_ClaimContacts>>(json);
				return;
			}
			if (type == typeof(List<DTO_Address>))
			{
				AddressesList = JsonConvert.DeserializeObject<List<DTO_Address>>(json);
				return;
			}
			if (type == typeof(List<DTO_Customer>))
			{
				CustomersList = JsonConvert.DeserializeObject<List<DTO_Customer>>(json);
				return;
			}
			if (type == typeof(List<DTO_Scope>))
			{
				ScopesList = JsonConvert.DeserializeObject<List<DTO_Scope>>(json);


			}
			if (type == typeof(List<DTO_Plane>))
			{
				PlanesList = JsonConvert.DeserializeObject<List<DTO_Plane>>(json);
			}
			if (type == typeof(List<DTO_Order>))
			{
				OrdersList = JsonConvert.DeserializeObject<List<DTO_Order>>(json);

			}
			if (type == typeof(List<DTO_User>))
			{
				UsersList = JsonConvert.DeserializeObject<List<DTO_User>>(json);

			}
			if (type == typeof(List<DTO_AdditionalSupply>))
			{
				AdditionalSuppliesList = JsonConvert.DeserializeObject<List<DTO_AdditionalSupply>>(json);

			}
			if (type == typeof(List<DTO_SurplusSupplies>))
			{
				SurplusSuppliesList = JsonConvert.DeserializeObject<List<DTO_SurplusSupplies>>(json);

			}
			if (type == typeof(List<DTO_Lead>))
			{
				LeadsList = JsonConvert.DeserializeObject<List<DTO_Lead>>(json);

			}
			if (type == typeof(List<DTO_Inspection>))
			{
				InspectionsList = JsonConvert.DeserializeObject<List<DTO_Inspection>>(json);

			}

		}


		public async Task Login(DTO_User token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "Login"),
					token);
				response.EnsureSuccessStatusCode();
				LoggedInEmployee = await response.Content.ReadAsAsync<DTO_Employee>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task RegisterUser(DTO_User token)
		{
			try
			{
				//DTO_User token = new DTO_User
				//{
				//	EmployeeID = 50,
				//	PermissionID = 1
				//};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "RegisterUser"),
					token);
				response.EnsureSuccessStatusCode();
				User = await response.Content.ReadAsAsync<DTO_User>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
			if (User.Message == null)
				System.Windows.Forms.MessageBox.Show("Active Status: " + User.Active.ToString() + ", Username: " + User.Username.ToString() + ", Password: " + User.Pass.ToString() + ", EmployeeID: " + User.EmployeeID.ToString());
			else System.Windows.Forms.MessageBox.Show(User.Message.ToString());
		}

		#region Adds
		public async Task AddAdditionalSupply(DTO_AdditionalSupply token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddAdditionalSupply"),
					token);
				response.EnsureSuccessStatusCode();
				AdditionalSupply = await response.Content.ReadAsAsync<DTO_AdditionalSupply>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request AddAdditionalSupply Task" + ex.ToString());
			}
		}

		public async Task AddAddress(DTO_Address token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddAddress"),
					token);
				response.EnsureSuccessStatusCode();
				Address1 = await response.Content.ReadAsAsync<DTO_Address>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request AddAddress Task" + ex.ToString());
			}
		}

		public async Task AddAdjuster(DTO_Adjuster token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddAdjuster"),
					token);
				response.EnsureSuccessStatusCode();
				Adjuster = await response.Content.ReadAsAsync<DTO_Adjuster>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request AddAdjuster Task" + ex.ToString());
			}
		}

		public async Task AddAdjustment(DTO_Adjustment token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddAdjustment"),
					token);
				response.EnsureSuccessStatusCode();
				Adjustment = await response.Content.ReadAsAsync<DTO_Adjustment>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request AddAdjustment Task" + ex.ToString());
			}
		}

		public async Task AddCalendarData(DTO_CalendarData token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddCalendarData"),
					token);
				response.EnsureSuccessStatusCode();
				CalendarData = await response.Content.ReadAsAsync<DTO_CalendarData>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request AddCalendarData Task" + ex.ToString());
			}
		}

		public async Task AddCallLog(DTO_CallLog token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddCallLog"),
					token);
				response.EnsureSuccessStatusCode();
				CallLog = await response.Content.ReadAsAsync<DTO_CallLog>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request AddCallLog Task" + ex.ToString());
			}
		}

		public async Task AddClaim(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddClaim"),
					token);
				response.EnsureSuccessStatusCode();
				Claim = await response.Content.ReadAsAsync<DTO_Claim>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request AddClaim Task" + ex.ToString());
			}
		}

		public async Task AddClaimContacts(DTO_ClaimContacts token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddClaimContacts"),
					token);
				response.EnsureSuccessStatusCode();
				ClaimContacts = await response.Content.ReadAsAsync<DTO_ClaimContacts>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task AddClaimStatus(DTO_ClaimStatus token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddClaimStatus"),
					token);
				response.EnsureSuccessStatusCode();
				ClaimStatus = await response.Content.ReadAsAsync<DTO_ClaimStatus>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request AddClaimStatus Task" + ex.ToString());
			}
		}

		public async Task AddClaimVendor(DTO_ClaimVendor token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddClaimVendor"),
					token);
				response.EnsureSuccessStatusCode();
				ClaimVendor = await response.Content.ReadAsAsync<DTO_ClaimVendor>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
		}

		public async Task AddCustomer(DTO_Customer token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddCustomer"),
					token);
				response.EnsureSuccessStatusCode();
				Cust = await response.Content.ReadAsAsync<DTO_Customer>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request AddCustomer Task" + ex.ToString());
			}
		}

		public async Task AddDamage(DTO_Damage token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddDamage"),
					token);
				response.EnsureSuccessStatusCode();
				Damage = await response.Content.ReadAsAsync<DTO_Damage>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request AddDamage Task" + ex.ToString());
			}
		}

		public async Task AddEmployee(DTO_Employee token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddEmployee"),
					token);
				response.EnsureSuccessStatusCode();
				Employee = await response.Content.ReadAsAsync<DTO_Employee>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task AddInspection(DTO_Inspection token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddInspection"),
					token);
				response.EnsureSuccessStatusCode();
				Inspection = await response.Content.ReadAsAsync<DTO_Inspection>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request AddInspection Task" + ex.ToString());
			}
		}

		public async Task AddInsuranceCompany(DTO_InsuranceCompany token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddInsuranceCompany"),
					token);
				response.EnsureSuccessStatusCode();
				InsuranceCompany = await response.Content.ReadAsAsync<DTO_InsuranceCompany>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request AddAddress Task" + ex.ToString());
			}
		}

		public async Task AddInvoice(DTO_Invoice token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddInvoice"),
					token);
				response.EnsureSuccessStatusCode();
				Invoice = await response.Content.ReadAsAsync<DTO_Invoice>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task AddKnockerResponse(DTO_KnockerResponse token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddKnockerResponse"),
					token);
				response.EnsureSuccessStatusCode();
				KnockerResponse = await response.Content.ReadAsAsync<DTO_KnockerResponse>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request AddAddress Task" + ex.ToString());
			}
		}

		public async Task AddLead(DTO_Lead token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddLead"),
					token);
				response.EnsureSuccessStatusCode();
				Lead = await response.Content.ReadAsAsync<DTO_Lead>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request AddAddress Task" + ex.ToString());
			}
		}

		public async Task AddNewRoof(DTO_NewRoof token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddNewRoof"),
					token);
				response.EnsureSuccessStatusCode();
				NewRoof = await response.Content.ReadAsAsync<DTO_NewRoof>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task AddOrder(DTO_Order token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddOrder"),
					token);
				response.EnsureSuccessStatusCode();
				Order = await response.Content.ReadAsAsync<DTO_Order>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task AddOrderItem(DTO_OrderItem token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddOrderItem"),
					token);
				response.EnsureSuccessStatusCode();
				OrderItem = await response.Content.ReadAsAsync<DTO_OrderItem>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task AddPayment(DTO_Payment token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddPayment"),
					token);
				response.EnsureSuccessStatusCode();
				Payment = await response.Content.ReadAsAsync<DTO_Payment>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task AddPlane(DTO_Plane token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddPlane"),
					token);
				response.EnsureSuccessStatusCode();
				Plane = await response.Content.ReadAsAsync<DTO_Plane>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task AddReferrer(DTO_Referrer token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddReferrer"),
					token);
				response.EnsureSuccessStatusCode();
				Referrer = await response.Content.ReadAsAsync<DTO_Referrer>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request AddReferrer Task" + ex.ToString());
			}
		}

		public async Task AddScope(DTO_Scope token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddScope"),
					token);
				response.EnsureSuccessStatusCode();
				Scope = await response.Content.ReadAsAsync<DTO_Scope>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request AddScope Task" + ex.ToString());
			}
		}

		public async Task AddSurplusSupplies(DTO_SurplusSupplies token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddSurplusSupplies"),
					token);
				response.EnsureSuccessStatusCode();
				SurplusSupplies = await response.Content.ReadAsAsync<DTO_SurplusSupplies>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task AddVendor(DTO_Damage token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddVendor"),
					token);
				response.EnsureSuccessStatusCode();
				Vendor = await response.Content.ReadAsAsync<DTO_Vendor>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request AddVendor Task" + ex.ToString());
			}
		}

		#endregion

		#region Gets

		public async Task GetAdditionalSuppliesByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAdditionalSuppliesByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				AdditionalSuppliesList = await response.Content.ReadAsAsync<List<DTO_AdditionalSupply>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAdditionalSuppliesByClaimID Task" + ex.ToString());
			}
		}

		public async Task GetAddressByID(DTO_Address token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAddressByID"),
					token);
				response.EnsureSuccessStatusCode();
				Address1 = await response.Content.ReadAsAsync<DTO_Address>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAddressByID Task" + ex.ToString());
			}
		}

		public async Task GetAdjusterByID(DTO_Adjuster token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAdjusterByID"),
					token);
				response.EnsureSuccessStatusCode();
				Adjuster = await response.Content.ReadAsAsync<DTO_Adjuster>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAdjusterByID Task" + ex.ToString());
			}
		}

		public async Task GetAdjustmentsByAdjusterID(DTO_Adjuster token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAdjustmentsByAdjusterID"),
					token);
				response.EnsureSuccessStatusCode();
				AdjustmentsList = await response.Content.ReadAsAsync<List<DTO_Adjustment>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAdjustmentsByAdjusterID Task" + ex.ToString());
			}
		}

		public async Task GetAdjustmentsByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAdjustmentsByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				AdjustmentsList = await response.Content.ReadAsAsync<List<DTO_Adjustment>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAdjustmentsByClaimID Task" + ex.ToString());
			}
		}

		public async Task GetCalendarDataByEmployeeID(DTO_Employee token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetCalendarDataByEmployeeID"),
					token);
				response.EnsureSuccessStatusCode();
				CalendarDataList = await response.Content.ReadAsAsync<List<DTO_CalendarData>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetCalendarDataByEmployeeID Task" + ex.ToString());
			}
		}

		public async Task GetCallLogsByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetCallLogsByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				CallLogsList = await response.Content.ReadAsAsync<List<DTO_CallLog>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetCallLogsByClaimID Task" + ex.ToString());
			}
		}

		public async Task GetClaimByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetClaimByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				Claim = await response.Content.ReadAsAsync<DTO_Claim>();
			}
			catch (Exception)

			{
				//System.Windows.Forms.MessageBox.Show("Error Making Request GetClaimByClaimID Task" + ex.ToString());
			}
		}

		public async Task GetClaimContactsByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetClaimContactsByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				ClaimContacts = await response.Content.ReadAsAsync<DTO_ClaimContacts>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetClaimDocumentsByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetClaimDocumentsByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				ClaimDocumentsList = await response.Content.ReadAsAsync<List<DTO_ClaimDocument>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetClaimDocumentsByClaimID Task" + ex.ToString());

			}
		}

		public async Task GetClaimStatusByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetClaimStatusByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				ClaimStatusList = await response.Content.ReadAsAsync<List<DTO_ClaimStatus>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetClaimStatusByClaimID Task" + ex.ToString());
			}
		}

		public async Task GetClaimVendorsByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetClaimVendorsByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				ClaimVendorsList = await response.Content.ReadAsAsync<List<DTO_ClaimVendor>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetClaimVendorsByClaimID Task" + ex.ToString());
			}
		}

		public async Task GetCustomerByID(DTO_Customer token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetCustomerByID"),
					token);
				response.EnsureSuccessStatusCode();
				Cust = await response.Content.ReadAsAsync<DTO_Customer>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetCustomerByID Task" + ex.ToString());
			}
		}

		public async Task GetEmployeesByEmployeeTypeID(DTO_LU_EmployeeType token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetEmployeesByEmployeeTypeID"),
					token);
				response.EnsureSuccessStatusCode();
				EmployeesList = await response.Content.ReadAsAsync<List<DTO_Employee>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetEmployeesByEmployeeTypeID Task" + ex.ToString());
			}
		}

		public async Task GetEmployeeByID(DTO_Employee token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetEmployeeByID"),
					token);
				response.EnsureSuccessStatusCode();
				Employee = await response.Content.ReadAsAsync<DTO_Employee>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetEmployeeByID Task" + ex.ToString());
			}
		}

		public async Task GetInspectionByID(DTO_Inspection token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetInspectionByID"),
					token);
				response.EnsureSuccessStatusCode();
				Inspection = await response.Content.ReadAsAsync<DTO_Inspection>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetInspectionByID Task" + ex.ToString());
			}
		}

		public async Task GetInspectionsByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetInspectionsByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				InspectionsList = await response.Content.ReadAsAsync<List<DTO_Inspection>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetInspectionsByClaimID Task" + ex.ToString());
			}
		}

		public async Task GetInsuranceCompanyByID(DTO_InsuranceCompany token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetInsuranceCompanyByID"),
					token);
				response.EnsureSuccessStatusCode();
				InsuranceCompany = await response.Content.ReadAsAsync<DTO_InsuranceCompany>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetInsuranceCompanyByID Task" + ex.ToString());
			}
		}

		public async Task GetInvoicesByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetInvoicesByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				InvoicesList = await response.Content.ReadAsAsync<List<DTO_Invoice>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetInvoicesByClaimID Task" + ex.ToString());
			}
		}

		public async Task GetKnockerResponseByID(DTO_KnockerResponse token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetKnockerResponseByID"),
					token);
				response.EnsureSuccessStatusCode();
				KnockerResponse = await response.Content.ReadAsAsync<DTO_KnockerResponse>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetKnockerResponseByID Task" + ex.ToString());
			}
		}

		public async Task GetKnockerResponsesByKnockerID(DTO_Employee token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetKnockerResponsesByKnockerID"),
					token);
				response.EnsureSuccessStatusCode();
				KnockerResponsesList = await response.Content.ReadAsAsync<List<DTO_KnockerResponse>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetKnockerResponsesByKnockerID Task" + ex.ToString());
			}
		}

		public async Task GetKnockerResponsesByTypeID(DTO_LU_KnockResponseType token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetKnockerResponsesByTypeID"),
					token);
				response.EnsureSuccessStatusCode();
				KnockerResponsesList = await response.Content.ReadAsAsync<List<DTO_KnockerResponse>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetKnockerResponsesByTypeID Task" + ex.ToString());
			}
		}

		public async Task GetLeadByLeadID(DTO_Lead token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetLeadByLeadID"),
					token);
				response.EnsureSuccessStatusCode();
				Lead = await response.Content.ReadAsAsync<DTO_Lead>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetLeadByLeadID Task" + ex.ToString());
			}
		}

		public async Task GetLeadsBySalesPersonID(DTO_Employee token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetLeadsBySalesPersonID"),
					token);
				response.EnsureSuccessStatusCode();
				LeadsList = await response.Content.ReadAsAsync<List<DTO_Lead>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetLeadsBySalesPersonID Task" + ex.ToString());
			}
		}

		public async Task GetMostRecentDateByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetMostRecentDateByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				CalculatedResults = await response.Content.ReadAsAsync<DTO_CalculatedResults>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetMostRecentDateByClaimID Task" + ex.ToString());
			}
		}

		public async Task GetNewRoofByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetNewRoofByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				NewRoof = await response.Content.ReadAsAsync<DTO_NewRoof>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetNewRoofByClaimID Task" + ex.ToString());
			}
		}

		public async Task GetOrderItemsByOrderID(DTO_Order token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetOrderItemsByOrderID"),
					token);
				response.EnsureSuccessStatusCode();
				OrderItemsList = await response.Content.ReadAsAsync<List<DTO_OrderItem>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetOrderItemsByOrderID Task" + ex.ToString());
			}
		}

		public async Task GetOpenClaimsBySalespersonID(DTO_Employee token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetOpenClaimsBySalespersonID"),
					token);
				response.EnsureSuccessStatusCode();
				EmployeeOpenClaimsList = await response.Content.ReadAsAsync<List<DTO_Claim>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetOpenClaimsBySalespersonID Task" + ex.ToString());
			}
		}

		public async Task GetOrdersByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetOrdersByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				OrdersList = await response.Content.ReadAsAsync<List<DTO_Order>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetOrdersByClaimID Task" + ex.ToString());
			}
		}

		public async Task GetPaymentsByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetPaymentsByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				PaymentsList = await response.Content.ReadAsAsync<List<DTO_Payment>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetPaymentsByClaimID Task" + ex.ToString());
			}
		}

		public async Task GetPlanesByInspectionID(DTO_Inspection token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetPlanesByInspectionID"),
					token);
				response.EnsureSuccessStatusCode();
				PlanesList = await response.Content.ReadAsAsync<List<DTO_Plane>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetPlanesByInspectionID Task" + ex.ToString());
			}
		}

		public async Task GetReferrerByID(DTO_Referrer token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@URL + "GetReferrerByID"), token);
				response.EnsureSuccessStatusCode();
				Referrer = await response.Content.ReadAsAsync<DTO_Referrer>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetReferrerByID Task" + ex.ToString());
			}
		}

		public async Task GetScopesByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetScopesByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				ScopesList = await response.Content.ReadAsAsync<List<DTO_Scope>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetScopesByClaimID Task" + ex.ToString());
			}
		}

		public async Task GetSumOfInvoicesByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetSumOfInvoicesByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				CalculatedResults = await response.Content.ReadAsAsync<DTO_CalculatedResults>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetSumOfInvoicesByClaimID Task" + ex.ToString());
			}
		}

		public async Task GetSumOfPaymentsByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetSumOfPaymentsByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				CalculatedResults = await response.Content.ReadAsAsync<DTO_CalculatedResults>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetSumOfPaymentsByClaimID Task" + ex.ToString());
			}
		}

		public async Task GetSurplusSuppliesByClaimID(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetSurplusSuppliesByClaimID"),
					token);
				response.EnsureSuccessStatusCode();
				SurplusSuppliesList = await response.Content.ReadAsAsync<List<DTO_SurplusSupplies>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetSurplusSuppliesByClaimID Task" + ex.ToString());
			}
		}

		public async Task GetVendorByID(DTO_Vendor token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetVendorByID"),
					token);
				response.EnsureSuccessStatusCode();
				Vendor = await response.Content.ReadAsAsync<DTO_Vendor>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetVendorByID Task" + ex.ToString());
			}
		}

		#endregion

		#region Get Alls

		public async Task GetAllAdditionalSupplies()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllAdditionalSupplies"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				AdditionalSuppliesList = await response.Content.ReadAsAsync<List<DTO_AdditionalSupply>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllAdditionalSupplies Task" + ex.ToString());
			}
		}

		public async Task GetAllAddresses()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllAddresses"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				AddressesList = await response.Content.ReadAsAsync<List<DTO_Address>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllAddresses Task" + ex.ToString());
			}
		}

		public async Task GetAllAdjusters()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllAdjusters"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				AdjustersList = await response.Content.ReadAsAsync<List<DTO_Adjuster>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllAdjusters Task" + ex.ToString());

			}
		}

		public async Task GetAllAdjustments()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllAdjustments"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				AdjustmentsList = await response.Content.ReadAsAsync<List<DTO_Adjustment>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllAdjustments Task" + ex.ToString());
			}
		}

		public async Task GetAllCalendarData()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllCalendarData"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				CalendarDataList = await response.Content.ReadAsAsync<List<DTO_CalendarData>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllCalendarData Task" + ex.ToString());
			}
		}

		public async Task GetAllCallLogs()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllCallLogs"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				CallLogsList = await response.Content.ReadAsAsync<List<DTO_CallLog>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllCallLogs Task" + ex.ToString());
			}
		}

		public async Task GetAllClaims()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllClaims"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				ClaimsList = await response.Content.ReadAsAsync<List<DTO_Claim>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllClaims Task" + ex.ToString());
			}
		}

		public async Task GetAllClaimContacts()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllClaimContacts"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				ClaimContactsList = await response.Content.ReadAsAsync<List<DTO_ClaimContacts>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllClaimContacts Task" + ex.ToString());
			}
		}

		public async Task GetAllClaimDocuments()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllClaimDocuments"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				ClaimDocumentsList = await response.Content.ReadAsAsync<List<DTO_ClaimDocument>>();


			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllClaimDocuments Task" + ex.ToString());
			}
		}

		public async Task GetAllClaimStatuses()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllClaimStatuses"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				ClaimStatusList = await response.Content.ReadAsAsync<List<DTO_ClaimStatus>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllClaimStatuses Task" + ex.ToString());
			}
		}

		public async Task GetAllClaimVendors()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllClaimVendors"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				ClaimVendorsList = await response.Content.ReadAsAsync<List<DTO_ClaimVendor>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllClaimVendors Task" + ex.ToString());
			}
		}

		public async Task GetAllCustomers()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllCustomers"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				CustomersList = await response.Content.ReadAsAsync<List<DTO_Customer>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllCustomers Task" + ex.ToString());
			}
		}

		public async Task GetAllDamages()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllDamages"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				DamagesList = await response.Content.ReadAsAsync<List<DTO_Damage>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllDamages Task" + ex.ToString());
			}
		}

		public async Task GetAllEmployees()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllEmployees"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				EmployeesList = await response.Content.ReadAsAsync<List<DTO_Employee>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllEmployees Task" + ex.ToString());

			}
		}

		public async Task GetAllInspections()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllInspections"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				InspectionsList = await response.Content.ReadAsAsync<List<DTO_Inspection>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllInspections Task" + ex.ToString());
			}
		}

		public async Task GetAllInsuranceCompanies()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllInsuranceCompanies"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				InsuranceCompaniesList = await response.Content.ReadAsAsync<List<DTO_InsuranceCompany>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllInsuranceCompanies Task" + ex.ToString());
			}
		}

		public async Task GetAllInvoices()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllInvoices"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				InvoicesList = await response.Content.ReadAsAsync<List<DTO_Invoice>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllInvoices Task" + ex.ToString());
			}
		}

		public async Task GetAllKnockerResponses()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllKnockerResponses"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				KnockerResponsesList = await response.Content.ReadAsAsync<List<DTO_KnockerResponse>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllKnockerResponses Task" + ex.ToString());
			}
		}

		public async Task GetAllLeads()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllLeads"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				LeadsList = await response.Content.ReadAsAsync<List<DTO_Lead>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllLeads Task" + ex.ToString());
			}
		}

		public async Task GetAllNewRoofs()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllNewRoofs"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				NewRoofsList = await response.Content.ReadAsAsync<List<DTO_NewRoof>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllNewRoofs Task" + ex.ToString());
			}
		}

		public async Task GetAllOrderItems()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllOrderItems"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				OrderItemsList = await response.Content.ReadAsAsync<List<DTO_OrderItem>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllOrderItems Task" + ex.ToString());
			}
		}
		public async Task GetAllOpenClaims()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllOpenClaims"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				OpenClaimsList = await response.Content.ReadAsAsync<List<DTO_Claim>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllOpenClaims Task" + ex.ToString());
			}
		}

		public async Task GetAllOrders()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllOrders"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				OrdersList = await response.Content.ReadAsAsync<List<DTO_Order>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllOrders Task" + ex.ToString());
			}
		}

		public async Task GetAllPayments()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllPayments"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				PaymentsList = await response.Content.ReadAsAsync<List<DTO_Payment>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllPayments Task" + ex.ToString());
			}
		}

		public async Task GetAllPlanes()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllPlanes"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				PlanesList = await response.Content.ReadAsAsync<List<DTO_Plane>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllPlanes Task" + ex.ToString());
			}
		}

		public async Task GetAllReferrers()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllReferrers"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				ReferrersList = await response.Content.ReadAsAsync<List<DTO_Referrer>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllReferrers Task" + ex.ToString());
			}
		}

		public async Task GetAllScopes()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllScopes"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				ScopesList = await response.Content.ReadAsAsync<List<DTO_Scope>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllScopes Task" + ex.ToString());
			}
		}

		public async Task GetAllSurplusSupplies()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllSurplusSupplies"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				SurplusSuppliesList = await response.Content.ReadAsAsync<List<DTO_SurplusSupplies>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllSurplusSupplies Task" + ex.ToString());
			}
		}

		public async Task GetAllUsers()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllUsers"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				UsersList = await response.Content.ReadAsAsync<List<DTO_User>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllUsers Task" + ex.ToString());
			}
		}

		public async Task GetAllVendors()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAllVendors"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				VendorsList = await response.Content.ReadAsAsync<List<DTO_Vendor>>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request GetAllVendors Task" + ex.ToString());

			}
		}

		#endregion

		#region Updates

		public async Task UpdateAdditionalSupplies(DTO_AdditionalSupply token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateAdditionalSupplies"),
					token);
				response.EnsureSuccessStatusCode();
				AdditionalSupply = await response.Content.ReadAsAsync<DTO_AdditionalSupply>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateAdditionalSupplies Task" + ex.ToString());
			}
		}

		public async Task UpdateAddress(DTO_Address token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(String.Format(@"{0}{1}", URL, "/UpdateAddress"), token);
				response.EnsureSuccessStatusCode();
				Address1 = await response.Content.ReadAsAsync<DTO_Address>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateAddress Task" + ex.ToString());
			}
		}

		public async Task UpdateAdjuster(DTO_Adjuster token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(String.Format(@"{0}{1}", URL, "/UpdateAdjuster"), token);
				response.EnsureSuccessStatusCode();
				Adjuster = await response.Content.ReadAsAsync<DTO_Adjuster>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateAdjuster Task" + ex.ToString());
			}
		}

		public async Task UpdateAdjustment(DTO_Adjustment token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(String.Format(@"{0}{1}", URL, "/UpdateAdjustment"), token);
				response.EnsureSuccessStatusCode();
				Adjustment = await response.Content.ReadAsAsync<DTO_Adjustment>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateAdjustment Task" + ex.ToString());
			}
		}

		public async Task UpdateCalendarData(DTO_CalendarData token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateCalendarData"),
					token);
				response.EnsureSuccessStatusCode();
				CalendarData = await response.Content.ReadAsAsync<DTO_CalendarData>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateCalendarData Task" + ex.ToString());
			}
		}

		public async Task UpdateClaim(DTO_Claim token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(String.Format(@"{0}{1}", URL, "/UpdateClaim"), token);
				response.EnsureSuccessStatusCode();
				Claim = await response.Content.ReadAsAsync<DTO_Claim>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateClaim Task" + ex.ToString());
			}
		}

		public async Task UpdateClaimContacts(DTO_ClaimContacts token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(String.Format(@"{0}{1}", URL, "/UpdateClaimContacts"), token);
				response.EnsureSuccessStatusCode();
				ClaimContacts = await response.Content.ReadAsAsync<DTO_ClaimContacts>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateClaimContacts Task" + ex.ToString());
			}
		}

		public async Task UpdateClaimStatuses(DTO_ClaimStatus token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateClaimStatuses"),
					token);
				response.EnsureSuccessStatusCode();
				ClaimStatus = await response.Content.ReadAsAsync<DTO_ClaimStatus>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateClaimStatuses Task" + ex.ToString());
			}
		}

		public async Task UpdateCustomer(DTO_Customer token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateCustomer"),
					token);
				response.EnsureSuccessStatusCode();
				Cust = await response.Content.ReadAsAsync<DTO_Customer>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateCustomer Task" + ex.ToString());
			}
		}

		public async Task UpdateDamage(DTO_Damage token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(String.Format(@"{0}{1}", URL, "/UpdateDamage"), token);
				response.EnsureSuccessStatusCode();
				Damage = await response.Content.ReadAsAsync<DTO_Damage>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateDamage Task" + ex.ToString());
			}
		}

		public async Task UpdateEmployee(DTO_Employee token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateEmployee"),
					token);
				response.EnsureSuccessStatusCode();
				Employee = await response.Content.ReadAsAsync<DTO_Employee>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateEmployee Task" + ex.ToString());
			}
		}

		public async Task UpdateInspection(DTO_Inspection token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateInspection"),
					token);
				response.EnsureSuccessStatusCode();
				Inspection = await response.Content.ReadAsAsync<DTO_Inspection>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateInspection Task" + ex.ToString());
			}
		}

		public async Task UpdateInsuranceCompany(DTO_InsuranceCompany token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateInsuranceCompany"),
					token);
				response.EnsureSuccessStatusCode();
				InsuranceCompany = await response.Content.ReadAsAsync<DTO_InsuranceCompany>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateInsuranceCompany Task" + ex.ToString());
			}
		}

		public async Task UpdateInvoice(DTO_Invoice token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateInvoice"),
					token);
				response.EnsureSuccessStatusCode();
				Invoice = await response.Content.ReadAsAsync<DTO_Invoice>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateInvoice Task" + ex.ToString());
			}
		}

		public async Task UpdateKnockerResponse(DTO_KnockerResponse token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateKnockerResponse"),
					token);
				response.EnsureSuccessStatusCode();
				KnockerResponse = await response.Content.ReadAsAsync<DTO_KnockerResponse>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateKnockerResponse Task" + ex.ToString());
			}
		}

		public async Task UpdateLead(DTO_Lead token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateLead"),
					token);
				response.EnsureSuccessStatusCode();
				Lead = await response.Content.ReadAsAsync<DTO_Lead>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateLead Task" + ex.ToString());
			}
		}

		public async Task UpdateNewRoof(DTO_NewRoof token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateNewRoof"),
					token);
				response.EnsureSuccessStatusCode();
				NewRoof = await response.Content.ReadAsAsync<DTO_NewRoof>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateNewRoof Task" + ex.ToString());
			}
		}

		public async Task UpdateOrder(DTO_Order token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateOrder"),
					token);
				response.EnsureSuccessStatusCode();
				Order = await response.Content.ReadAsAsync<DTO_Order>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateOrder Task" + ex.ToString());
			}
		}

		public async Task UpdateOrderItem(DTO_OrderItem token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateOrderItem"),
					token);
				response.EnsureSuccessStatusCode();
				OrderItem = await response.Content.ReadAsAsync<DTO_OrderItem>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateOrderItem Task" + ex.ToString());
			}
		}

		public async Task UpdatePayment(DTO_Payment token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdatePayment"),
					token);
				response.EnsureSuccessStatusCode();
				Payment = await response.Content.ReadAsAsync<DTO_Payment>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdatePayment Task" + ex.ToString());
			}
		}

		public async Task UpdatePlane(DTO_Plane token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdatePlane"),
					token);
				response.EnsureSuccessStatusCode();
				Plane = await response.Content.ReadAsAsync<DTO_Plane>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdatePlane Task" + ex.ToString());
			}
		}

		public async Task UpdateReferrer(DTO_Referrer token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateReferrer"),
					token);
				response.EnsureSuccessStatusCode();
				Referrer = await response.Content.ReadAsAsync<DTO_Referrer>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateReferrer Task" + ex.ToString());
			}
		}

		public async Task UpdateScope(DTO_Scope token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateScope"),
					token);
				response.EnsureSuccessStatusCode();
				Scope = await response.Content.ReadAsAsync<DTO_Scope>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateScope Task" + ex.ToString());
			}
		}

		public async Task UpdateSurplusSupplies(DTO_SurplusSupplies token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateSurplusSupplies"),
					token);
				response.EnsureSuccessStatusCode();
				SurplusSupplies = await response.Content.ReadAsAsync<DTO_SurplusSupplies>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateSurplusSupplies Task" + ex.ToString());
			}
		}

		public async Task UpdateUser(DTO_User token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateUser"),
					token);
				response.EnsureSuccessStatusCode();
				User = await response.Content.ReadAsAsync<DTO_User>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateUser Task" + ex.ToString());
			}
		}

		public async Task UpdateVendor(DTO_Vendor token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateVendor"),
					token);
				response.EnsureSuccessStatusCode();
				Vendor = await response.Content.ReadAsAsync<DTO_Vendor>();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Making Request UpdateVendor Task" + ex.ToString());
			}
		}

		#endregion

		#region Get Methods for LookUp Lists
		public async Task GetAdjustmentResults()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAdjustmentResults"),
					token);
				response.EnsureSuccessStatusCode();
				AdjustmentResults = await response.Content.ReadAsAsync<List<DTO_LU_AdjustmentResult>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetAppointmentTypes()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetAppointmentTypes"),
					token);
				response.EnsureSuccessStatusCode();
				AppointmentTypes = await response.Content.ReadAsAsync<List<DTO_LU_AppointmentTypes>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetClaimDocumentTypes()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetClaimDocumentTypes"),
					token);
				response.EnsureSuccessStatusCode();
				ClaimDocTypes = await response.Content.ReadAsAsync<List<DTO_LU_ClaimDocumentType>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetClaimStatusTypes()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetClaimStatusTypes"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				ClaimStatusTypes = await response.Content.ReadAsAsync<List<DTO_LU_ClaimStatusTypes>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetDamageTypes()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetDamageTypes"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				DamageTypes = await response.Content.ReadAsAsync<List<DTO_LU_DamageTypes>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetEmployeeTypes()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetEmployeeTypes"),
					token);
				response.EnsureSuccessStatusCode();
				EmployeeTypes = await response.Content.ReadAsAsync<List<DTO_LU_EmployeeType>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetInvoiceTypes()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetInvoiceTypes"),
					token);
				response.EnsureSuccessStatusCode();
				InvoiceTypes = await response.Content.ReadAsAsync<List<DTO_LU_InvoiceType>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetKnockResponseTypes()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetKnockResponseTypes"),
					token);
				response.EnsureSuccessStatusCode();
				KnockResponseTypes = await response.Content.ReadAsAsync<List<DTO_LU_KnockResponseType>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetLeadTypes()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetLeadTypes"),
					token);
				response.EnsureSuccessStatusCode();
				LeadTypes = await response.Content.ReadAsAsync<List<DTO_LU_LeadType>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetPayFrequencies()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetPayFrequencies"),
					token);
				response.EnsureSuccessStatusCode();
				PayFrequencies = await response.Content.ReadAsAsync<List<DTO_LU_PayFrequncy>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetPayDescriptions()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetPayDescriptions"),
					token);
				response.EnsureSuccessStatusCode();
				PaymentDescriptions = await response.Content.ReadAsAsync<List<DTO_LU_PaymentDescription>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetPaymentTypes()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetPaymentTypes"),
					token);
				response.EnsureSuccessStatusCode();
				PaymentTypes = await response.Content.ReadAsAsync<List<DTO_LU_PaymentType>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetPayTypes()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetPayTypes"),
					token);
				response.EnsureSuccessStatusCode();
				PayTypes = await response.Content.ReadAsAsync<List<DTO_LU_PayType>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetPermissions()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetPermissions"),
					token);
				response.EnsureSuccessStatusCode();
				Permissions = await response.Content.ReadAsAsync<List<DTO_LU_Permissions>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetPlaneTypes()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetPlaneTypes"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				PlaneTypes = await response.Content.ReadAsAsync<List<DTO_LU_PlaneTypes>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetProducts()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetProducts"),
					token);
				response.EnsureSuccessStatusCode();
				Products = await response.Content.ReadAsAsync<List<DTO_LU_Product>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetProductTypes()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetProductTypes"),
					token);
				response.EnsureSuccessStatusCode();
				ProductTypes = await response.Content.ReadAsAsync<List<DTO_LU_ProductType>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetRidgeMaterialTypes()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetRidgeMAterialTypes"),
					token);
				response.EnsureSuccessStatusCode();
				RidgeMaterialTypes = await response.Content.ReadAsAsync<List<DTO_LU_RidgeMaterialType>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetScopeTypes()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetScopeTypes"),
					token);
				response.EnsureSuccessStatusCode();
				ScopeTypes = await response.Content.ReadAsAsync<List<DTO_LU_ScopeType>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetServiceTypes()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetServiceTypes"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				ServiceTypes = await response.Content.ReadAsAsync<List<DTO_LU_ServiceTypes>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetShingleTypes()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetShingleTypes"),
					token);
				response.EnsureSuccessStatusCode();
				ShingleTypes = await response.Content.ReadAsAsync<List<DTO_LU_ShingleType>>();

				//ShingleTypes = svc.GetShingleTypes().ToList();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetUnitsOfMeasure()
		{
			try
			{
				DTO_Employee token = new DTO_Employee
				{
					EmployeeID = 2,
				};

				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetUnitsOfMeasure"),
					token);
				response.EnsureSuccessStatusCode();
				UnitsOfMeasure = await response.Content.ReadAsAsync<List<DTO_LU_UnitOfMeasure>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task GetVendorTypes()
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetVendorTypes"),
					new DTO_Base());
				response.EnsureSuccessStatusCode();
				VendorTypes = await response.Content.ReadAsAsync<List<DTO_LU_VendorTypes>>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}
		#endregion

		//EVERYTHING BELOW THIS LINE NEEDS TESTING

		public async Task AddClaimDocument(DTO_ClaimDocument token)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddClaimDocument"),
					token);
				response.EnsureSuccessStatusCode();
				ClaimDocument = await response.Content.ReadAsAsync<DTO_ClaimDocument>();
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public async Task DoMoreWork(int leadIDSelection)
		{
			DTO_Lead token = new DTO_Lead
			{
				LeadID = leadIDSelection,
			};

			var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetLeadByLeadID"),
					token);
			response.EnsureSuccessStatusCode();
			Lead = await response.Content.ReadAsAsync<DTO_Lead>();

			response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetCustomerByID"),
					new DTO_Customer { CustomerID = Lead.CustomerID });
			response.EnsureSuccessStatusCode();
			Cust = await response.Content.ReadAsAsync<DTO_Customer>();
		}
	}
}




























/*using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using MRNNexus_Model;


namespace MRN_Claim_Services.Controllers
{

	public partial class ServiceLayer
	{
		HttpClient httpClient = new HttpClient();



		private const string URL = @"http://services.mrncontracting.com/MRNNexus_Service.svc/";
		//private const string URL = @"http://localhost:50899/MRNNexus_Service.svc/";
		private HttpClient client = new HttpClient();
		public static ServiceLayer s1;

		public ServiceLayer()
		{
			client.BaseAddress = new Uri(URL);
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.Timeout = new TimeSpan(0, 5, 0);
		}

		public static ServiceLayer getInstance()
		{
			if (s1 == null)
			{
			   s1 = new ServiceLayer();
			}

			return s1;
		}

		public async Task MakeRequest(DTO_Base token, Type returnType, string methodName)
		{
			try
			{
				var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, methodName),
					token);
				//HttpRequestMessage msg = new HttpRequestMessage(new HttpMethod("POST"), new Uri(URL + methodName));
				//msg.Content = new HttpStringContent(json);
				//msg.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("application/json");
				//HttpResponseMessage response = await client.SendRequestAsync(msg).AsTask();
				setResults(await response.Content.ReadAsStringAsync(), returnType, methodName);
			}
			catch (Exception ex)
			{

			}
		}

		async public Task buildLUs()
		{
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_AdjustmentResult>), "GetAdjustmentResults");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_AppointmentTypes>), "GetAppointmentTypes");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ClaimDocumentType>), "GetClaimDocumentTypes");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ClaimStatusTypes>), "GetClaimStatusTypes");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_DamageTypes>), "GetDamageTypes");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_EmployeeType>), "GetEmployeeTypes");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_InvoiceType>), "GetInvoiceTypes");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_KnockResponseType>), "GetKnockResponseTypes");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_LeadType>), "GetLeadTypes");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PayFrequncy>), "GetPayFrequencies");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PaymentDescription>), "GetPayDescriptions");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PaymentType>), "GetPaymentTypes");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PayType>), "GetPayTypes");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_Permissions>), "GetPermissions");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_PlaneTypes>), "GetPlaneTypes");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ProductType>), "GetProductTypes");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_RidgeMaterialType>), "GetRidgeMaterialTypes");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ScopeType>), "GetScopeTypes");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ServiceTypes>), "GetServiceTypes");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_ShingleType>), "GetShingleTypes");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_UnitOfMeasure>), "GetUnitsOfMeasure");
			await s1.MakeRequest(new DTO_Base(), typeof(List<DTO_LU_VendorTypes>), "GetvendorTypes");
		}

		public void setResults(string json, Type type, string methodName)
		{

			if(methodName == "Login")
			{
				LoggedInEmployee = JsonConvert.DeserializeObject<DTO_Employee>(json);
			
				return;
			}

			if (type == typeof(DTO_Address))
			{
				Address = JsonConvert.DeserializeObject<DTO_Address>(json);
				return;
			}

			if (type == typeof(DTO_Employee))
			{
				Employee = JsonConvert.DeserializeObject<DTO_Employee>(json);
				return;
			}

			if (type == typeof(List<DTO_InsuranceCompany>))
			{
				InsuranceCompaniesList = JsonConvert.DeserializeObject<List<DTO_InsuranceCompany>>(json);
				return;
			}

			if (type == typeof(DTO_Lead))
			{
				Lead = JsonConvert.DeserializeObject<DTO_Lead>(json);
				return;
			}

			if (type == typeof(List<DTO_CalendarData>))
			{
				CalendarDataList = JsonConvert.DeserializeObject<List<DTO_CalendarData>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_AdjustmentResult>))
			{
				AdjustmentResults = JsonConvert.DeserializeObject<List<DTO_LU_AdjustmentResult>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_AppointmentTypes>))
			{
				AppointmentTypes = JsonConvert.DeserializeObject<List<DTO_LU_AppointmentTypes>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_ClaimDocumentType>))
			{
				ClaimDocTypes = JsonConvert.DeserializeObject<List<DTO_LU_ClaimDocumentType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_ClaimStatusTypes>))
			{
				ClaimStatusTypes = JsonConvert.DeserializeObject<List<DTO_LU_ClaimStatusTypes>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_DamageTypes>))
			{
				DamageTypes = JsonConvert.DeserializeObject<List<DTO_LU_DamageTypes>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_EmployeeType>))
			{
				EmployeeTypes = JsonConvert.DeserializeObject<List<DTO_LU_EmployeeType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_InvoiceType>))
			{
				InvoiceTypes = JsonConvert.DeserializeObject<List<DTO_LU_InvoiceType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_KnockResponseType>))
			{
				KnockResponseTypes = JsonConvert.DeserializeObject<List<DTO_LU_KnockResponseType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_LeadType>))
			{
				LeadTypes = JsonConvert.DeserializeObject<List<DTO_LU_LeadType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_PayFrequncy>))
			{
				PayFrequencies = JsonConvert.DeserializeObject<List<DTO_LU_PayFrequncy>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_PaymentDescription>))
			{
				PaymentDescriptions = JsonConvert.DeserializeObject<List<DTO_LU_PaymentDescription>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_PaymentType>))
			{
				PaymentTypes = JsonConvert.DeserializeObject<List<DTO_LU_PaymentType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_PayType>))
			{
				PayTypes = JsonConvert.DeserializeObject<List<DTO_LU_PayType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_Permissions>))
			{
				Permissions = JsonConvert.DeserializeObject<List<DTO_LU_Permissions>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_PlaneTypes>))
			{
				PlaneTypes = JsonConvert.DeserializeObject<List<DTO_LU_PlaneTypes>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_ProductType>))
			{
				ProductTypes = JsonConvert.DeserializeObject<List<DTO_LU_ProductType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_RidgeMaterialType>))
			{
				RidgeMaterialTypes = JsonConvert.DeserializeObject<List<DTO_LU_RidgeMaterialType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_ScopeType>))
			{
				ScopeTypes = JsonConvert.DeserializeObject<List<DTO_LU_ScopeType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_ServiceTypes>))
			{
				ServiceTypes = JsonConvert.DeserializeObject<List<DTO_LU_ServiceTypes>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_ShingleType>))
			{
				ShingleTypes = JsonConvert.DeserializeObject<List<DTO_LU_ShingleType>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_UnitOfMeasure>))
			{
				UnitsOfMeasure = JsonConvert.DeserializeObject<List<DTO_LU_UnitOfMeasure>>(json);
				return;
			}

			if (type == typeof(List<DTO_LU_VendorTypes>))
			{
				VendorTypes = JsonConvert.DeserializeObject<List<DTO_LU_VendorTypes>>(json);
				return;
			}


		}
	}
}

	*/
