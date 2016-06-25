using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;



using MRNNexus_Model;
using Newtonsoft.Json.Linq;
using static Newtonsoft.Json.Linq.JToken;
using System.Collections;
using System.Net.Http.Formatting;

namespace MRNUIElements
{
    public partial class ServiceLayer
    {
        private const string URL = @"http://services.mrncontracting.com/MRNNexus_Service.svc/";
        //private const string URL = @"http://localhost:50899/MRNNexus_Service.svc/";
        private HttpClient client = new HttpClient();
        public static ServiceLayer s1;
        public DateTime serviceCreated;
        
        private ServiceLayer()
        {
            client.BaseAddress = new Uri(URL);
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(0, 5, 0);
        }

        public static ServiceLayer getInstance()
        {
            if(s1 == null)
            {
                s1 = new ServiceLayer();
            }

            return s1;
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

        public async Task RegisterUser()
        {
            try
            {
                DTO_User token = new DTO_User
                {
                    EmployeeID = 50,
                    PermissionID = 1
                };

                var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "RegisterUser"),
                    token);
                response.EnsureSuccessStatusCode();
                User = await response.Content.ReadAsAsync<DTO_User>();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
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

            }
        }

        public async Task AddCalendarData(DTO_CalendarData token)
        {
            try
            {
                var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddCalendarData"),
                    token);
                response.EnsureSuccessStatusCode();
                CalData = await response.Content.ReadAsAsync<DTO_CalendarData>();
            }
            catch (Exception ex)
            {

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

            }
        }

        public async Task AddClaimSupplier(DTO_ClaimSupplier token)
        {
            try
            {
                var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddClaimSupplier"),
                    token);
                response.EnsureSuccessStatusCode();
                ClaimSupplier = await response.Content.ReadAsAsync<DTO_ClaimSupplier>();
            }
            catch (Exception ex)
            {

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

            }
        }

        public async Task AddInstaller(DTO_Installer token)
        {
            try
            {
                var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddInstaller"),
                    token);
                response.EnsureSuccessStatusCode();
                Installer = await response.Content.ReadAsAsync<DTO_Installer>();
            }
            catch (Exception ex)
            {

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

            }
        }

        public async Task AddSupplier(DTO_Supplier token)
        {
            try
            {
                var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "AddSupplier"),
                    token);
                response.EnsureSuccessStatusCode();
                Supplier = await response.Content.ReadAsAsync<DTO_Supplier>();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
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

            }
        }

        public async Task GetCalendarDataByEmployeeID(DTO_Employee token)
        {
            try
            {
                var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetCalendarDataByEmployeeID"),
                    token);
                response.EnsureSuccessStatusCode();
                CalDataList = await response.Content.ReadAsAsync<List<DTO_CalendarData>>();
            }
            catch (Exception ex)
            {

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
            catch (Exception ex)
            {

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

            }
        }

        public async Task GetEmployeesByEmployeeTypeID(DTO_LU_EmployeeType token)
        {
            try
            {
                var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetEmployeesByEmployeeTypeID"),
                    token);
                response.EnsureSuccessStatusCode();
                EmployeeList = await response.Content.ReadAsAsync<List<DTO_Employee>>();
            }
            catch (Exception ex)
            {

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

            }
        }

        public async Task GetInstallerByID(DTO_Installer token)
        {
            try
            {
                var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetInstallerByID"), token);
                response.EnsureSuccessStatusCode();
                Installer = await response.Content.ReadAsAsync<DTO_Installer>();
            }
            catch(Exception ex)
            {

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

            }
        }

        public async Task GetLeadsBySalesPersonID(DTO_Employee token)
        {
            try
            {
                var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetLeadsBySalesPersonID"),
                    token);
                response.EnsureSuccessStatusCode();
                LeadList = await response.Content.ReadAsAsync<List<DTO_Lead>>();
            }
            catch (Exception ex)
            {

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

            }
        }

        public async Task GetOrdersByClaimID(DTO_Claim token)
        {
            try
            {
                var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "GetOrdersByClaimID"),
                    token);
                response.EnsureSuccessStatusCode();
                OrdersList = await response.Content.ReadAsAsync< List<DTO_Order>>();
            }
            catch (Exception ex)
            {

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

            }
        }

        public async Task GetSupplierByID(DTO_Supplier token)
        {
            try
            {
                var response = await client.PostAsJsonAsync(string.Format(@URL + "GetSupplierByID"), token);
                response.EnsureSuccessStatusCode();
                Supplier = await response.Content.ReadAsAsync<DTO_Supplier>();
            }
            catch(Exception ex)
            {

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

            }
        }

        public async Task UpdateCalendarData(DTO_CalendarData token)
        {
            try
            {
                var response = await client.PostAsJsonAsync(string.Format(@"{0}{1}", URL, "UpdateCalendarData"),
                    token);
                response.EnsureSuccessStatusCode();
                CalData = await response.Content.ReadAsAsync<DTO_CalendarData>();
            }
            catch (Exception ex)
            {

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
            }catch (Exception e)
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
