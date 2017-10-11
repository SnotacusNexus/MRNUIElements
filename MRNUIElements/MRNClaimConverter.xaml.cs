using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MRNNexus_Model;
using MRNUIElements.Controllers;
using System.IO;
using static MRNUIElements.Csv;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Windows.Forms;
using static MRNUIElements.RoofMeasurmentsPage;
namespace MRNUIElements
{
	/// <summary>
	/// Interaction logic for MRNClaimConverter.xaml
	/// </summary>
	public partial class MRNClaimConverter : Page
	{
		static ServiceLayer s1 = ServiceLayer.getInstance();
		static RoofMeasurmentsPage rmp;
		string theFile = "";
		const string QUOTE = "\"";
		const string ESCAPEDCOMMA = ", ";
		string cvsData = "";
		int claimID = 0;
		int docTypeID = 0;
		public MRNClaimConverter()
		{
			InitializeComponent();

			TextReader tr = new StreamReader("file.txt");
			cvsData = textBox.Text = tr.ReadToEnd();

		}

		private void BrowseBtn_Click(object sender, RoutedEventArgs e)
		{

		}

		private void StartBtn_Click(object sender, RoutedEventArgs e)
		{
			MakeData(cvsData);
		}
		int getcomma(int instancenumber, string stringtosearch, int thiscomma, char charg)
		{
			int i = 0;
			int w = 0;
			while (i < instancenumber)
			{
				w = stringtosearch.IndexOf(charg, thiscomma);

			}
			return w;
		}
		string CleanString(string row)
		{
			bool signal = false;
			while (row.Count(x => x == '\"') > 0)//until no quotes are left
			{
				if (row.Contains('\"'))
				{
					row = row.Remove(row.IndexOf('\"'), 1);
					signal = !signal;
				}
				if (row.Contains(",") && signal)
					row = row.Remove(row.IndexOf(", "), 2);


				//int beg = 0, end = 0;//set very volitile temp vars
				//beg = row.IndexOf('\"');//lets get the index of the first quote found
				//end = row.IndexOf('\"', beg);//lets get the index or closing quote that folows the first quote we just found, we add 1 to it to guarantee it doesnt select the same quote
				//while (row.IndexOf(',', beg) < end)//do this while the index of the of the comma is greater than beg and less than end
				//	row=row.Remove(row.IndexOf(',', beg));//for every comma that is between the quotes we say bye bye
				//row = row.Remove(row.IndexOf('\"'));//now remove first quote to make the second quote the first quote to be found 
				//row.Contains("/"")
				//row = row.Remove(row.IndexOf('\"'));// now remove the first quote that was made the first quote to be found after the last quote that was the first quote was removed from the previous command  
				//									// FYI: why couldnt we just use beg and end to delete the quotes that is because if there was multiple commas the the index for end is off by more than a predictible one so its easier to let the runtime find the index and remove it that way since we know there were 1 pair of quotes that was used to delimit the comma from the csv
				//									//the next line reinitalizes the volitile temp vars just like that


			}


			//get rid of the dollar signs
			while (row.Count(x => x == '$') > 0)
				row = row.Remove(row.IndexOf('$'));
			return row;
		}
		async void MakeData(string csvData)
		{
			char[] rows = { '\r' };
			char[] delimiter = { ',' };
			char[] quote = { '\"' };
			char delimitedcomma = '#';
			List<string> suffix = new List<string> { "Jr", "III", "II", "Sr", "IV" };
			List<string> states = new List<string> { "Ga", "GA", "Georgia", "NC", "North Carolina" };
			List<string> roadtypeabbr = new List<string> { "Rd", "Road", "Place", "Pl", "Way", "Cir", "Circle", "Ave", "Avenue", "Drive", "Dr", "Blvd", "Lane", "Ln", "Tr", "Trail", "Terrace", "Ter" };
			string numbers = "0123456789";
			var targetnumbers = numbers.ToArray();
			//create data structures to use to add data to database
			var plane = new DTO_Plane();//holds roof measure data
			var origscope = new DTO_Scope();//scopetype 1
			var estimate = new DTO_Scope();//scopetype 2
			var newscope = new DTO_Scope();//scopetype 3
			var customer = new DTO_Customer(); //holds customer info
			var address = new DTO_Address();//holds addresses associated with claims
			var inspection = new DTO_Inspection();
			var claimdocs = new ObservableCollection<DTO_ClaimDocument>();
			var claimstatuses = new ObservableCollection<DTO_ClaimStatus>();
			var signedDate = new DTO_ClaimStatus();
			var adjustment = new DTO_ClaimStatus();
			var roofsched = new DTO_ClaimStatus();
			var roofcomp = new DTO_ClaimStatus();
			var suppsent = new DTO_ClaimStatus();
			var supprecd = new DTO_ClaimStatus();
			var firstcheckdate = new DTO_ClaimStatus();
			var cocsentdate = new DTO_ClaimStatus();

			var order = new DTO_Order();
			var rooforder = new ObservableCollection<DTO_OrderItem>();
			var firstCheck = new DTO_Payment();
			var depreciation = new DTO_Payment();
			var deductiblePayment = new DTO_Payment();
			var salesperson = new DTO_Employee();
			var knocker = new DTO_Employee();
			bool team = false;
			var othersalesmember = new DTO_Employee();
			var schedule = new DTO_CalendarData();
			var lead = new DTO_Lead();
			var referrer = new DTO_Referrer();
			var claim = new DTO_Claim();
			var adjustmentdate = new DTO_Adjustment();
			var adjustmentresult = new DTO_LU_AdjustmentResult();
			csvData = csvData.Remove('\n', csvData.Count(x => x == '\n'));
			List<string> rowData = csvData.Split(rows, StringSplitOptions.None).ToList();



			foreach (var row in rowData)
			{
				if (!CheckRow(row))
					await SortData(MakeDataEntry(CleanString(row)), row);

			}
			bool CheckRow(string row)
			{
				List<bool> rowcheck = new List<bool>();
				//Get Rid of commas surrounded by quotes and the quotes that surrounded them
				var a = row.Substring(0, 2).ToCharArray();//checks row for data present
				foreach (var Char in a)
				{
					int i = 0;


					rowcheck.Add(Char == ',' || Char == '\n' ? true : false);




				}
				return (rowcheck.All(x => x == true));
			}




			List<string> MakeDataEntry(string row)
			{

				return row.Split(delimiter, StringSplitOptions.None).ToList();//now that the file is split into rows and all delimited commas are removed and other symbols that will create insertion errors now we will split the row into 47 pieces preserving the blank columns so we can count them and keep our data congruent
			}


			async Task<bool> SortData(List<string> listData, string row)
			{

				int rowwidth = row.Count(x => x == ',') + 2;
				int counter = 0;


				foreach (var item in listData)//item is each column in listdata is the row in columns as a list
				{

					if (((counter > 4 && counter < rowwidth - 5) || counter != 21) && listData[counter + rowwidth - 1] != null)//if column 6 - column 42 except column 22




						switch (counter)
						{
							case 5:
								{

									if (!string.IsNullOrEmpty(item))
										plane.SquareFootage = double.Parse(item);
									else
									{
										PDFTextExtractor pdfExtract = new PDFTextExtractor();
										var ofd = new Microsoft.Win32.OpenFileDialog() { Filter = "PDF Files (*.pdf)|*.pdf" };
										var result = ofd.ShowDialog();
										if (result == false) return false;
										//textbox.Text = pdfExtract.Extract(ofd.FileName, true);
										rmp.FillVariables(pdfExtract.Extract(new FileStream(ofd.FileName, FileMode.Open), true));
										plane = rmp.Plane;
									}
									break;
								}

							case 6:
								{
									if (!string.IsNullOrEmpty(item))
										origscope.Deductible = estimate.Deductible = newscope.Deductible = double.Parse(item);
									break;
								}
							case 7:
								{
									if (!string.IsNullOrEmpty(item))
									{
										item.Trim();
										char[] space = { ' ' };
										var b = item.Split(space, StringSplitOptions.RemoveEmptyEntries).ToList();

										if (b.Count == 2)
										{
											customer.FirstName = b[0];
											customer.LastName = b[1];
										}
									}
									break;
								}

							case 8:
								{






									//find street type e.g. Road, Rd and substring from the beginning to that point plus the length of the street type found plus 1 to move beyond the end of string
									if (!string.IsNullOrEmpty(item))
										foreach (var roadabbr in roadtypeabbr)
										{
											if (item.IndexOf(roadabbr) > -1)
												address.Address = item.Substring(0, item.IndexOf(roadabbr) + roadabbr.Length + 1);//assign address
										}
									// same spot now we go to the other end of item and work backwards first we trim any white space and the we substring from the last space that contains the last numbers in the item til the end
									if (!string.IsNullOrEmpty(item))
										address.Zip = item.Substring(item.IndexOfAny(targetnumbers, item.LastIndexOf(' '))); //assign zipcode
									break;


								}

							case 9:
								{
									if (!string.IsNullOrEmpty(item))
										customer.PrimaryNumber = MakePhoneNumber(item);
									customer.Email = "info@mrncontracting.com";
									customer.MailPromos = false;



									break;


								}
							case 10:
								{
									if (!string.IsNullOrEmpty(item))
										claim.InsuranceCompanyID = s1.InsuranceCompaniesList.Where(x => x.CompanyName == item).ToList()[0].InsuranceCompanyID;
									break;
								}
							case 11:
								{
									if (!string.IsNullOrEmpty(item))
										claim.InsuranceClaimNumber = item;
									break;
								}
							case 12:
								{
									if (!string.IsNullOrEmpty(item))
									{
										var name = item.Split(' '.ToString().ToCharArray(), StringSplitOptions.None).ToList();
										lead.LeadTypeID = item == null ? 5 : s1.EmployeesList.Where(x => x.LastName == name[1] && x.FirstName == name[0]) != null ? 1 : s1.CustomersList.Where(y => y.LastName == name[1] && y.FirstName == name[0]) != null ? 3 : 2;
										lead.CreditToID = lead.LeadTypeID == 1 ? s1.EmployeesList.Find(x => x.FirstName == name[0] && x.LastName == name[1]).EmployeeID : lead.LeadTypeID == 2 ? await AddDataObject(referrer) : lead.LeadTypeID == 3 ? s1.CustomersList.Find(x => x.FirstName == name[0] && x.LastName == name[1]).CustomerID : s1.EmployeesList.Find(y => y.FirstName == name[0] && y.LastName == name[1]).EmployeeID;
										referrer.FirstName = name[0];
										referrer.LastName = name[1];
										referrer.MailingAddress = "196 Old Loganville Rd";
										referrer.Zip = "30052";
									}
									break;
								}
							case 13:
								{
									if (!string.IsNullOrEmpty(item))
									{
										string temp = item + "/2017";
										signedDate.ClaimStatusDate = DateTime.Parse(temp);
										signedDate.ClaimStatusTypeID = 1;
										claimstatuses.Add(signedDate);
									}
									break;
								}
							case 14:
								{
									if (!string.IsNullOrEmpty(item))
									{
										string temp = item + "/2017";
										firstCheck.PaymentDate = adjustment.ClaimStatusDate = DateTime.Parse(temp);
										adjustment.ClaimStatusTypeID = 5;
										claimstatuses.Add(adjustment);
									}
									break;

								}


							case 15:
								{
									if (!string.IsNullOrEmpty(item))
										adjustmentdate.AdjustmentDate = adjustment.ClaimStatusDate;
									adjustmentresult.AdjustmentResultID = item == "Yes" || item == "yes" ? 1 : 2;
									break;
								}
							case 16:
								{
									if (!string.IsNullOrEmpty(item))
										origscope.Total = origscope.RCV = double.Parse(item);

									break;
								}
							case 17:
								{
									if (!string.IsNullOrEmpty(item))
										estimate.ACV = newscope.ACV = origscope.ACV = double.Parse(item);

									break;
								}
							case 18:
								{
									if (!string.IsNullOrEmpty(item))

										estimate.Total = estimate.RCV = double.Parse(item);

									break;
								}
							case 19:
								{
									if (!string.IsNullOrEmpty(item))
									{
										firstCheck.Amount = double.Parse(item);
										firstCheck.PaymentDescriptionID = 1;
										firstCheck.PaymentTypeID = 1;

										string temp = item + "/2017";
										firstcheckdate.ClaimStatusDate = DateTime.Parse(temp);
										firstcheckdate.ClaimStatusTypeID = 7;
										claimstatuses.Add(firstcheckdate);
									}
									break;
								}

							case 20:
								{
									if (!string.IsNullOrEmpty(item))
									{
										string temp = item + "/2017";
										suppsent.ClaimStatusDate = DateTime.Parse(temp);
										suppsent.ClaimStatusTypeID = 9;
										claimstatuses.Add(suppsent);
									}
									break;
								}
							case 22:
								{
									if (!string.IsNullOrEmpty(item))
									{
										string temp = item + "/2017";
										supprecd.ClaimStatusDate = DateTime.Parse(temp);
										supprecd.ClaimStatusTypeID = 9;
										claimstatuses.Add(supprecd);
									}
									break;
								}

							case 23:
								{
									//skip
									break;
								}
							case 24:
								{
									if (!string.IsNullOrEmpty(item))
										newscope.Total = newscope.RCV = double.Parse(item);

									break;
								}
							case 25:
								{//skip
									break;
								}
							case 26:
								{
									if (!string.IsNullOrEmpty(item))
									{
										string temp = item + "/2017";
										roofsched.ClaimStatusDate = DateTime.Parse(temp);
										roofsched.ClaimStatusTypeID = 11;
										claimstatuses.Add(roofsched);
									}
									break;
								}
							case 27:
								{
									if (!string.IsNullOrEmpty(item))
									{
										string temp = item + "/2017";
										roofcomp.ClaimStatusDate = DateTime.Parse(temp);

										roofcomp.ClaimStatusTypeID = 12;
										claimstatuses.Add(roofcomp);
									}
									break;
								}
							case 28:
								{//skip
									break;
								}
							case 29:
								{//skip
									break;
								}


							case 30:
								{//skip
									break;
								}
							case 31:
								{//skip
									break;
								}
							case 32:
								{//skip
									break;
								}
							case 33:
								{
									if (!string.IsNullOrEmpty(item))
									{
										string temp = item + "/2017";
										roofcomp.ClaimStatusDate = DateTime.Parse(temp);
										roofcomp.ClaimStatusTypeID = 16;
										claimstatuses.Add(roofcomp);
									}
									break;
								}
							case 34:
								{//skip
									break;
								}
							case 35:
								{//skip
									break;
								}
							case 36:
								{//skip
									break;
								}
							case 37:
								{
									break;
								}
							case 38:
								{
									if (!string.IsNullOrEmpty(item))
										depreciation.Amount = double.Parse(item);
									break;

								}


							case 39:
								{//calllog
									break;
								}
							case 40:
								{//calllog
									break;
								}

							case 41:
								{
									item.Trim();



									claim.CustomerID = lead.CustomerID = address.CustomerID = await AddDataObject(customer);
									claim.PropertyID = claim.BillingID = lead.AddressID = await AddDataObject(address);
									lead.SalesPersonID = salesperson.EmployeeID = s1.EmployeesList.Find(x => x.LastName == item.Substring(item.IndexOf(' ') + 1)).EmployeeID;
									lead.Temperature = "w";
									claim.IsOpen = true;
									claim.LeadID = await AddDataObject(lead);
									newscope.Exterior = newscope.Interior = newscope.Gutter = newscope.Tax = 0;
									origscope.Exterior = origscope.Interior = origscope.Gutter = origscope.Tax = 0;
									estimate.Exterior = estimate.Interior = estimate.Gutter = estimate.Tax = 0;
									inspection.ClaimID = depreciation.ClaimID = firstCheck.ClaimID = deductiblePayment.ClaimID = newscope.ClaimID = origscope.ClaimID = estimate.ClaimID = await AddDataObject(claim);
									foreach (var status in claimstatuses)
									{
										status.ClaimID = claim.ClaimID;
										await s1.AddClaimStatus(status);
									}

									foreach (var docs in claimdocs)
									{
										docs.ClaimID = claim.ClaimID;
										await s1.AddClaimDocument(docs);
									}
									inspection.CoverPool = inspection.InteriorDamage = inspection.LightningProtection = inspection.QualityControl = inspection.RemoveTrash = inspection.Satellite = inspection.SkyLights = inspection.SolarPanels = inspection.TearOff = inspection.Valley = inspection.ProtectLandscaping = inspection.IceWaterShield = inspection.FurnishPermit = inspection.ExteriorDamage = inspection.Leaks = inspection.GutterDamage = inspection.DrivewayDamage = inspection.MagneticRollers = inspection.EmergencyRepair = false;
									plane.InspectionID = await AddDataObject(inspection);




									await AddDataObject(plane);

									//	 plane // new DTO_Plane();//holds roof measure data
									//	 origscope // new DTO_Scope();//scopetype 1
									//	 estimate // new DTO_Scope();//scopetype 2
									//	 newscope // new DTO_Scope();//scopetype 3
									//	 customer // new DTO_Customer(); //holds customer info
									// address // new DTO_Address();//holds addresses associated with claims
									// inspection // new DTO_Inspection();
									//		 claimdocs // new ObservableCollection<DTO_ClaimDocument>();
									//	 claimstatuses // new ObservableCollection<DTO_ClaimStatus>();
									//		 signedDate // new DTO_ClaimStatus();
									//		 adjustment // new DTO_ClaimStatus();
									//			 roofsched // new DTO_ClaimStatus();
									//			 roofcomp // new DTO_ClaimStatus();
									//				 suppsent // new DTO_ClaimStatus();
									//				 supprecd // new DTO_ClaimStatus();
									//				 firstcheckdate // new DTO_ClaimStatus();
									//				 cocsentdate // new DTO_ClaimStatus();

									//order // new DTO_Order();
									// rooforder // new ObservableCollection<DTO_OrderItem>();
									//			 firstCheck // new DTO_Payment();
									//			 depreciation // new DTO_Payment();
									//			 deductiblePayment // new DTO_Payment();
									//			 salesperson // new DTO_Employee();
									//			 knocker // new DTO_Employee();
									//				bool team // false;
									//	 othersalesmember // new DTO_Employee();
									// schedule // new DTO_CalendarData();
									//	 lead // new DTO_Lead();
									//	 referrer // new DTO_Referrer();
									//	 claim // new DTO_Claim();
									//	 adjustmentdate // new DTO_Adjustment();
									//	 adjustmentresult // new DTO_LU_AdjustmentResult();


									break;
								}
							default: break;
						}

					else return true;
				
				}
				return false;
			}


			async Task<int> AddDataObject(object dataObjectToAdd)
			{
				if (dataObjectToAdd.GetType() == typeof(DTO_Customer))
				{
					await s1.AddCustomer((DTO_Customer)dataObjectToAdd);
					if (((DTO_Customer)dataObjectToAdd).Message == null)
						return ((DTO_Customer)dataObjectToAdd).CustomerID;
				}
				else if (dataObjectToAdd.GetType() == typeof(DTO_Address))
				{
					await s1.AddAddress((DTO_Address)dataObjectToAdd);
					if (((DTO_Address)dataObjectToAdd).Message == null)
						return ((DTO_Address)dataObjectToAdd).AddressID;
				}
				else if (dataObjectToAdd.GetType() == typeof(DTO_Lead))
				{
					await s1.AddLead((DTO_Lead)dataObjectToAdd);
					if (((DTO_Lead)dataObjectToAdd).Message == null)
						return ((DTO_Lead)dataObjectToAdd).LeadID;
				}
				else if (dataObjectToAdd.GetType() == typeof(DTO_Claim))
				{
					await s1.AddClaim((DTO_Claim)dataObjectToAdd);
					if (((DTO_Claim)dataObjectToAdd).Message == null)
						return ((DTO_Claim)dataObjectToAdd).ClaimID;


				}
				else if (dataObjectToAdd.GetType() == typeof(DTO_Referrer))
				{
					await s1.AddReferrer((DTO_Referrer)dataObjectToAdd);
					if (((DTO_Referrer)dataObjectToAdd).Message == null)
						return ((DTO_Referrer)dataObjectToAdd).ReferrerID;
				}
				else if (dataObjectToAdd.GetType() == typeof(DTO_Payment))
				{
					await s1.AddPayment((DTO_Payment)dataObjectToAdd);
					if (((DTO_Payment)dataObjectToAdd).Message == null)
						return ((DTO_Payment)dataObjectToAdd).PaymentID;
				}
				else if (dataObjectToAdd.GetType() == typeof(DTO_Order))
				{
					await s1.AddOrder((DTO_Order)dataObjectToAdd);
					if (((DTO_Order)dataObjectToAdd).Message == null)
						return ((DTO_Order)dataObjectToAdd).OrderID;
				}
				else if (dataObjectToAdd.GetType() == typeof(DTO_OrderItem))
				{
					await s1.AddOrderItem((DTO_OrderItem)dataObjectToAdd);
					if (((DTO_OrderItem)dataObjectToAdd).Message == null)
						return ((DTO_OrderItem)dataObjectToAdd).OrderItemID;
				}
				else if (dataObjectToAdd.GetType() == typeof(DTO_ClaimStatus))
				{
					await s1.AddClaimStatus((DTO_ClaimStatus)dataObjectToAdd);
					if (((DTO_ClaimStatus)dataObjectToAdd).Message == null)
					{
						switch (((DTO_ClaimStatus)dataObjectToAdd).ClaimStatusTypeID)
						{

							case 1:
								{
									docTypeID = 5; break;
								}

							case 2:
								{
									docTypeID = 2; break;
								}

							case 3:
								{
									docTypeID = 3; break;
								}

							case 4:
								{
									docTypeID = 6; break;
								}

							case 5:
								{
									docTypeID = 0; break;
								}
							case 6:
								{
									docTypeID = 7; break;
								}
							case 7:
								{
									docTypeID = 13; break;
								}
							case 8:
								{
									docTypeID = 9; break;
								}
							case 9:
								{
									docTypeID = 0; break;
								}
							case 10:
								{
									docTypeID = 8; break;
								}
							case 11:
								{
									docTypeID = 0; break;
								}
							case 12:
								{
									docTypeID = 20; break;
								}
							case 13:
								{
									docTypeID = 0; break;
								}
							case 14:
								{
									docTypeID = 0; break;
								}
							case 15:
								{
									docTypeID = 0; break;
								}
							case 16:
								{
									docTypeID = 0; break;
								}
							case 17:
								{
									docTypeID = 0; break;
								}
							case 18:
								{
									docTypeID = 16; break;
								}
							case 19:
								{
									docTypeID = 0; break;
								}
							case 20:
								{
									docTypeID = 15; break;
								}
							case 21:
								{
									docTypeID = 14; break;
								}
							case 22:
								{
									docTypeID = 19; break;
								}
							case 23:
								{
									docTypeID = 24; break;
								}
							case 24:
								{
									docTypeID = 0; break;
								}
							case 25:
								{
									docTypeID = 0; break;
								}
							case 26:
								{
									docTypeID = 0; break;
								}
							case 27:
								{
									docTypeID = 0; break;
								}
							case 28:
								{
									docTypeID = 0; break;
								}
							case 29:
								{
									docTypeID = 0; break;
								}
							case 30:
								{
									docTypeID = 0; break;
								}
							default:
								break;

						}

						var ofd = new System.Windows.Forms.OpenFileDialog();

						ofd.Title = "Select File Upload";
						ofd.InitialDirectory = @"%UserProfile%\Documents";
						ofd.Multiselect = docTypeID == 2 ? true : false;


						if (ofd.ShowDialog() == DialogResult.OK)
							UploadDocuments(claimID, docTypeID, ofd.FileName);

						//Call File Open Dialog to upload document to verify status


						else
							return ((DTO_ClaimStatus)dataObjectToAdd).ClaimStatusID;
					}
					else if (dataObjectToAdd.GetType() == typeof(DTO_ClaimDocument))
					{
						await s1.AddClaimDocument((DTO_ClaimDocument)dataObjectToAdd);
						if (((DTO_ClaimDocument)dataObjectToAdd).Message == null)
							return ((DTO_ClaimDocument)dataObjectToAdd).DocumentID;
					}
					else if (dataObjectToAdd.GetType() == typeof(DTO_Inspection))
					{
						await s1.AddInspection((DTO_Inspection)dataObjectToAdd);
						if (((DTO_Inspection)dataObjectToAdd).Message == null)
							return ((DTO_Inspection)dataObjectToAdd).InspectionID;
					}

				}
				return 0;
			}

			string MakePhoneNumber(string incomingstring)
			{

				var tchararg = incomingstring.ToCharArray();
				return tchararg.TakeWhile(x => char.IsDigit(x)).ToString();

			}

			bool checkEmailFormat(string incomingstring)
			{

				return (incomingstring.IndexOf('@') < incomingstring.LastIndexOf('.')) && ((incomingstring.Length - incomingstring.LastIndexOf('.')) < 4);
			}


			bool isEmployeeByName(string fullname)
			{
				var token = new DTO_Employee();
				var tempstringarg = fullname.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);



				switch (tempstringarg.Count())
				{
					case 2:
						{
							token.FirstName = tempstringarg[0];
							token.LastName = tempstringarg[1];
							break;
						}

					case 3:
						{
							token.FirstName = tempstringarg[0];

							token.Suffix = suffix.FirstOrDefault(x => x == tempstringarg[2]);
							token.LastName = token.Suffix != null ?
							tempstringarg[1] : tempstringarg[2]; token.MiddleName = tempstringarg[1];

							break;
						}
					case 4:
						{
							token.FirstName = tempstringarg[0];
							token.MiddleName = tempstringarg[1];
							token.LastName = tempstringarg[2];
							token.Suffix = tempstringarg[3];

							break;
						}

					default:
						break;
				}

				return s1.EmployeesList.Exists(x => x.LastName == token.LastName) ? s1.EmployeesList.Exists(x => x.FirstName == token.FirstName) ? token.Suffix != null ? s1.EmployeesList.Exists(x => x.Suffix == token.Suffix) ? !string.IsNullOrEmpty(token.MiddleName) ? s1.EmployeesList.Exists(x => x.MiddleName == token.MiddleName) ? true : false ? !string.IsNullOrEmpty(token.MiddleName) ? s1.EmployeesList.Exists(x => x.MiddleName == token.MiddleName) : true : false : false : false : false : false : false;



			}



		}


		void UploadDocuments(int claimID, int docType, string filePath)
		{

			UploadImage(claimID, docType, filePath);


		}
		public string GenerateMRNClaimNumber(int SalesPersonID, int CustomerID)
		{
			return SalesPersonID.ToString() + "-" + CustomerID.ToString() + "-" + DateTime.UtcNow;
		}

		static async public void UploadImage(int claimID, int docType, string filepathtoupload)
		{


			var onlyFileName = System.IO.Path.GetFileNameWithoutExtension(filepathtoupload);

			onlyFileName = onlyFileName.Replace(" ", "_");
			byte[] imageBytes = System.IO.File.ReadAllBytes(filepathtoupload);
			string ext = System.IO.Path.GetExtension(filepathtoupload);
			DTO_ClaimDocument documentUploadRequest = new DTO_ClaimDocument
			{
				FileBytes = Convert.ToBase64String(imageBytes),
				FileName = onlyFileName,
				FileExt = ext,
				ClaimID = claimID,
				DocTypeID = docType,
				DocumentDate = DateTime.Today

			};
			try
			{
				await s1.AddClaimDocument(documentUploadRequest);

				if (documentUploadRequest.Message != null)
				{
					System.Windows.Forms.MessageBox.Show(documentUploadRequest.Message.ToString());
				}
				//SAVING FILES TO DISK
				//string filename = fileDialog.FileName = @"newfile" + ext;
				//using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
				//{
				//    saveFileDialog1.FileName = filename;
				//    if (System.Windows.Forms.DialogResult.OK != saveFileDialog1.ShowDialog())
				//        return;
				//    System.IO.File.WriteAllBytes(saveFileDialog1.FileName,Convert.FromBase64String(s1.ClaimDocument.FileBytes));
				//}
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());

			}



		}


	}
}
