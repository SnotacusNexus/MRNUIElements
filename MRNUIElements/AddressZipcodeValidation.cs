using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

namespace MRNUIElements
{
	class AddressZipcodeValidation
	{
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address1 { get; set; }
        public string Zip9 { get; set; }
        public string Address2 { get; set; }
        public string ST { get; set; }
      



        //Base URL for USPS Address and Zip Code validation API.
        private const string BaseURL = "http://testing.shippingapis.com/ShippingAPITest.dll";
//Web client instance.
private WebClient wsClient = new WebClient();
//User ID obtained from USPS.
public string USPS_UserID = "573NEXUS4738";


		//Default constructor.
		public AddressZipcodeValidation()
		{
		}

		//Constructor with User ID parameter.
		public AddressZipcodeValidation(string New_UserID)
		{
			USPS_UserID = New_UserID;
		}

		/*******************************************************
 * Send request to remote site. Return reply data.
 ******************************************************/
		private string GetDataFromSite(string USPS_Request)
		{
			string strResponse = "";

			//Send the request to USPS.
			byte[] ResponseData = wsClient.DownloadData(USPS_Request);
			//Convert byte stream to string data.
			foreach (byte oItem in ResponseData)
				strResponse += (char)oItem;

			return strResponse;
		}

		/****************************************************
 * This method provides an interface to the USPS
 * WebTools Address Validation API.
 ***************************************************/
		public string AddressValidateRequest(string Address1,
											 string Address2,
											 string City,
											 string State,
											 string Zip5,
											 string Zip4)
		{
			//http://production.shippingapis.com/ShippingAPITest.dll?API=Verify
			//  &XML=<AddressValidateRequest USERID="xxxxxxx"><Address ID="0"><Address1></Address1>
			//  <Address2>6406 Ivy Lane</Address2><City>Greenbelt</City><State>MD</State>
			//  <Zip5></Zip5><Zip4></Zip4></Address></AddressValidateRequest>

			string strResponse = "", strUSPS = "";

			strUSPS = BaseURL + "?API=Verify&XML=<AddressValidateRequest USERID=\"" + USPS_UserID + "\">";
			strUSPS += "<Address ID=\"0\">";
			strUSPS += "<Address1>" + Address1 + "</Address1>";
			strUSPS += "<Address2>" + Address2 + "</Address2>";
			strUSPS += "<City>" + City + "</City>";
			strUSPS += "<State>" + State + "</State>";
			strUSPS += "<Zip5>" + Zip5 + "</Zip5>";
			strUSPS += "<Zip4>" + Zip4 + "</Zip4>";
			strUSPS += "</Address></AddressValidateRequest>";

			//Send the request to USPS.
			strResponse = GetDataFromSite(strUSPS);

			return strResponse;
		}


		/***************************************************
 * This function provides an interface to the USPS
 * WebTools City and State Lookup API.
 **************************************************/
		public string CityStateLookupRequest(string ZipCode, int AbbST=0)
		{
			//http://production.shippingapis.com/ShippingAPITest.dll?API=CityStateLookup
			//  &XML=<CityStateLookupRequest USERID="xxxxxxx"><ZipCode ID= "0">
			//  <Zip5>90210</Zip5></ZipCode></CityStateLookupRequest>
			string strResponse = "", strUSPS = "";

			strUSPS = BaseURL + "?API=CityStateLookup&XML=<CityStateLookupRequest USERID=\"" + USPS_UserID + "\">";
			strUSPS += "<ZipCode ID=\"0\">";
			strUSPS += "<Zip5>" + ZipCode + "</Zip5>";
			strUSPS += "</ZipCode></CityStateLookupRequest>";

			//Send the request to USPS.
			strResponse = GetDataFromSite(strUSPS);

          string  City=strResponse.Substring(strResponse.LastIndexOf("<City>") + 6, strResponse.IndexOf("</City>") - strResponse.LastIndexOf("<City>") - 6);
            string State = strResponse.Substring(strResponse.LastIndexOf("<State>") + 7, strResponse.IndexOf("</State>") - strResponse.LastIndexOf("<State>") - 7);
            string ST = ConvertStateToAbbreviation(State);
            string[] sCity = City.Split(' ');
            int i = sCity.Count();
            string s = "";
            foreach (string t in sCity)
            {
                
                s += t.Substring(0, 1).ToUpper();
                s += t.Substring(1, t.Length - 1).ToLower();
                if (i > 0)
                    s += " ";
            }
            City = s;

            string CSZ = City + ", " + State + "  " + ZipCode;
            string CSTZ = City + ", " + ST + "  " + ZipCode;

            if (AbbST >0)
                if (AbbST == 1)
                    return CSTZ;
                else
                    return CSZ;
            else
                return strResponse;




		}

		public static Dictionary<string, string> stateToAbbrev = new Dictionary<string, string>() { { "alabama", "AL" }, { "alaska", "AK" }, { "arizona", "AZ" }, { "arkansas", "AR" }, { "california", "CA" }, { "colorado", "CO" }, { "connecticut", "CT" }, { "delaware", "DE" }, { "district of columbia", "DC" }, { "florida", "FL" }, { "georgia", "GA" }, { "hawaii", "HI" }, { "idaho", "ID" }, { "illinois", "IL" }, { "indiana", "IN" }, { "iowa", "IA" }, { "kansas", "KS" }, { "kentucky", "KY" }, { "louisiana", "LA" }, { "maine", "ME" }, { "maryland", "MD" }, { "massachusetts", "MA" }, { "michigan", "MI" }, { "minnesota", "MN" }, { "mississippi", "MS" }, { "missouri", "MO" }, { "montana", "MT" }, { "nebraska", "NE" }, { "nevada", "NV" }, { "new hampshire", "NH" }, { "new jersey", "NJ" }, { "new mexico", "NM" }, { "new york", "NY" }, { "north carolina", "NC" }, { "north dakota", "ND" }, { "ohio", "OH" }, { "oklahoma", "OK" }, { "oregon", "OR" }, { "pennsylvania", "PA" }, { "rhode island", "RI" }, { "south carolina", "SC" }, { "south dakota", "SD" }, { "tennessee", "TN" }, { "texas", "TX" }, { "utah", "UT" }, { "vermont", "VT" }, { "virginia", "VA" }, { "washington", "WA" }, { "west virginia", "WV" }, { "wisconsin", "WI" }, { "wyoming", "WY" } };
		public static Dictionary<string, string> abbrevToState = new Dictionary<string, string>() { { "AK", "alaska" }, { "AL", "alabama" }, { "AR", "arkansas" }, { "AZ", "arizona" }, { "CA", "california" }, { "CO", "colorado" }, { "CT", "connecticut" }, { "DC", "district of columbia" }, { "DE", "delaware" }, { "FL", "florida" }, { "GA", "georgia" }, { "HI", "hawaii" }, { "IA", "iowa" }, { "ID", "idaho" }, { "IL", "illinois" }, { "IN", "indiana" }, { "KS", "kansas" }, { "KY", "kentucky" }, { "LA", "louisiana" }, { "MA", "massachusetts" }, { "MD", "maryland" }, { "ME", "maine" }, { "MI", "michigan" }, { "MN", "minnesota" }, { "MO", "missouri" }, { "MS", "mississippi" }, { "MT", "montana" }, { "NC", "north carolina" }, { "ND", "north dakota" }, { "NE", "nebraska" }, { "NH", "new hampshire" }, { "NJ", "new jersey" }, { "NM", "new mexico" }, { "NV", "nevada" }, { "NY", "new york" }, { "OH", "ohio" }, { "OK", "oklahoma" }, { "OR", "oregon" }, { "PA", "pennsylvania" }, { "RI", "rhode island" }, { "SC", "south carolina" }, { "SD", "south dakota" }, { "TN", "tennessee" }, { "TX", "texas" }, { "UT", "utah" }, { "VA", "virginia" }, { "VT", "vermont" }, { "WA", "washington" }, { "WI", "wisconsin" }, { "WV", "west virginia" }, { "WY", "wyoming" } };

		public static string ConvertStateToAbbreviation(string st=null,string state=null)
		{
			if (string.IsNullOrEmpty(st)&&string.IsNullOrEmpty(state))
			{
				return "You must supply either a state name or abbreviation to use this tool.";
			}
			else if (st.Length == 2)
			{
				if (abbrevToState.ContainsKey(st.ToUpper()))
				{
					string s = abbrevToState[st.ToUpper()];


					string[] w = s.Split(' ');
					s = "";
					int i = w.Count();

					foreach (string t in w)
					{
						s+=t.Substring(0, 1).ToUpper();
						s+=t.Substring(1, t.Length - 1).ToLower();
						if (i > 0)
							s += " ";
						
					}
					return s;
				}
				else
					return "Non resolvable state abbreviation";
			}
			else if (stateToAbbrev.ContainsKey(state.ToLower()))
			{
				return stateToAbbrev[state.ToLower()];
			
			}
			return "Not a valid state name.";
		}


	}


}
