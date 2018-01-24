using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MRNNexusDTOs;

namespace MRNNexus.WPFClient.Controllers
{
    public partial class ServiceLayer
    {
        public double SumOfInvoices { get; set; }
        public double SumOfPayments { get; set; }
        //Single Objects
        public DTO_Employee LoggedInEmployee { get; set; }
        public DTO_User LoggedInUser { get; set; }
        public DTO_CalculatedResults CalculatedResults { get; set; }

        public DTO_AdditionalSupply AdditionalSupply { get; set; }
        public DTO_Address Address { get; set; }
        public DTO_Address Address1 { get; set; }
        public DTO_Address Address2 { get; set; }
        public DTO_Adjuster Adjuster { get; set; }
        public DTO_Adjustment Adjustment { get; set; }
        public DTO_CalendarData CalendarData { get; set; }
        public DTO_CallLog CallLog { get; set; }
        public DTO_Claim Claim { get; set; }
        public DTO_ClaimContacts ClaimContacts { get; set; }
        public DTO_ClaimDocument ClaimDocument { get; set; }
        public DTO_ClaimStatus ClaimStatus { get; set; }
        public DTO_ClaimVendor ClaimVendor { get; set; }
        public DTO_Customer Cust { get; set; }
        public DTO_Damage Damage { get; set; }
        public DTO_Employee Employee { get; set; }
        public DTO_Inspection Inspection { get; set; }
        public DTO_InsuranceCompany InsuranceCompany { get; set; }
        public DTO_Invoice Invoice { get; set; }
        public DTO_KnockerResponse KnockerResponse { get; set; }
        public DTO_Lead Lead { get; set; }
        public DTO_NewRoof NewRoof { get; set; }
        public DTO_Order Order { get; set; }
        public DTO_OrderItem OrderItem { get; set; }
        public DTO_Payment Payment { get; set; }
        public DTO_Plane Plane { get; set; }
        public DTO_Referrer Referrer { get; set; }
        public DTO_Scope Scope { get; set; }
        public DTO_SurplusSupplies SurplusSupplies { get; set; }
        public DTO_User User { get; set; }
        public DTO_Vendor Vendor { get; set; }




        //Non LU Lists
        public List<DTO_AdditionalSupply> AdditionalSuppliesList { get; set; }
        public List<DTO_Address> AddressesList { get; set; }
        public List<DTO_Adjuster> AdjustersList { get; set; }
        public List<DTO_Adjustment> AdjustmentsList { get; set; }
        public List<DTO_CalendarData> CalendarDataList { get; set; }
        public List<DTO_CallLog> CallLogsList { get; set; }
        public List<DTO_Claim> ClaimsList { get; set; }
        public List<DTO_ClaimContacts> ClaimContactsList { get; set; }
        public List<DTO_ClaimDocument> ClaimDocumentsList { get; set; }
        public List<DTO_ClaimStatus> ClaimStatusList { get; set; }
        public List<DTO_ClaimVendor> ClaimVendorsList { get; set; }
        public List<DTO_Customer> CustomersList { get; set; }
        public List<DTO_Damage> DamagesList { get; set; }
        public List<DTO_Employee> EmployeesList { get; set; }
        public List<DTO_Inspection> InspectionsList { get; set; }
        public List<DTO_InsuranceCompany> InsuranceCompaniesList { get; set; }
        public List<DTO_Invoice> InvoicesList { get; set; }
        public List<DTO_KnockerResponse> KnockerResponsesList { get; set; }
        public List<DTO_Lead> LeadsList { get; set; }
        public List<DTO_NewRoof> NewRoofsList { get; set; }
        public List<DTO_Order> OrdersList { get; set; }
        public List<DTO_OrderItem> OrderItemsList { get; set; }
        public List<DTO_Payment> PaymentsList { get; set; }
        public List<DTO_Plane> PlanesList { get; set; }
        public List<DTO_Referrer> ReferrersList { get; set; }
        public List<DTO_Scope> ScopesList { get; set; }
        public List<DTO_SurplusSupplies> SurplusSuppliesList { get; set; }
        public List<DTO_User> UsersList { get; set; }
        public List<DTO_Vendor> VendorsList { get; set; }


        //LU Lists
        public List<DTO_LU_AdjustmentResult> AdjustmentResults { get; set; }
        public List<DTO_LU_AppointmentTypes> AppointmentTypes { get; set; }
        public List<DTO_LU_ClaimDocumentType> ClaimDocTypes { get; set; }
        public List<DTO_LU_ClaimStatusTypes> ClaimStatusTypes { get; set; }
        public List<DTO_LU_DamageTypes> DamageTypes { get; set; }
        public List<DTO_LU_EmployeeType> EmployeeTypes { get; set; }
        public List<DTO_LU_InvoiceType> InvoiceTypes { get; set; }
        public List<DTO_LU_KnockResponseType> KnockResponseTypes { get; set; }
        public List<DTO_LU_LeadType> LeadTypes { get; set; }
        public List<DTO_LU_PayFrequncy> PayFrequencies { get; set; }
        public List<DTO_LU_PaymentDescription> PaymentDescriptions { get; set; }
        public List<DTO_LU_PaymentType> PaymentTypes { get; set; }
        public List<DTO_LU_PayType> PayTypes { get; set; }
        public List<DTO_LU_Permissions> Permissions { get; set; }
        public List<DTO_LU_PlaneTypes> PlaneTypes { get; set; }
        public List<DTO_LU_Product> Products { get; set; }
        public List<DTO_LU_ProductType> ProductTypes { get; set; }
        public List<DTO_LU_RidgeMaterialType> RidgeMaterialTypes { get; set; }
        public List<DTO_LU_ScopeType> ScopeTypes { get; set; }
        public List<DTO_LU_ServiceTypes> ServiceTypes { get; set; }
        public List<DTO_LU_ShingleType> ShingleTypes { get; set; }
        public List<DTO_LU_UnitOfMeasure> UnitsOfMeasure { get; set; }
        public List<DTO_LU_VendorTypes> VendorTypes { get; set; }
    }
}
