using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

using Newtonsoft.Json;
using MRNNexus.DTOs;


namespace MRNNexus.WPFClient.Controllers
{
    internal partial class ServiceLayer
    {
        HttpClient httpClient = new HttpClient();



        private const string URL = @"http://services.mrncontracting.com/MRNNexus_Service.svc/";
        //private const string URL = @"http://localhost:50899/MRNNexus_Service.svc/";
        private HttpClient client = new HttpClient();
        public static ServiceLayer s1;

        private ServiceLayer()
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

