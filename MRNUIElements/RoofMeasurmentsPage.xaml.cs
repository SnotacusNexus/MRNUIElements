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

namespace MRNUIElements
{
    /// <summary>
    /// Interaction logic for RoofMeasurmentsPage.xaml
    /// </summary>
    public partial class RoofMeasurmentsPage : Page
    {
        public double RidgeMeasurement { get; set; }
        public double HipMeasurement { get; set; }
        public double ValleyMeasurement { get; set; }
        public double RakeMeasurement { get; set; }
        public double EaveMeasurement { get; set; }
        public double StarterMeasurement { get; set; }
        public double TotalSQFTOFF { get; set; }
        public int PredPitch { get; set; }

        string startsubstring = "Lengths, Areas and Pitches";
        string ridgesubstring = "Ridges = ";
        string hipssubstring = "Hips = ";
        string valleyssubstring = "Valleys = ";
        string rakessubstring = "Rakes* = ";
        string EavesStartersubstring = "Eaves/Starter** = ";
        string DripEdgesubstring = "Drip Edge (Eaves + Rakes) = ";
        string totalAreasubstring = "Total Area = ";
        string predpitchsubstring = "Predominant Pitch = ";
        string latitude = "Latitude = ";
        string longitude = "Longitude = ";
        string PropertyAddressBlockStart = "Online map of property";
        string EndPropertyAddressBlock = "Directions from MRN Homes of Ga. to this property";


        public RoofMeasurmentsPage()
        {
            InitializeComponent();
            PDFTextExtractor pdfExtract = new PDFTextExtractor();
            var ofd = new Microsoft.Win32.OpenFileDialog() {Filter = "PDF Files (*.pdf)|*.pdf"};
            var result = ofd.ShowDialog();
            if (result == false) return;
            textbox.Text= pdfExtract.Extract(ofd.FileName, true);
            FillVariables(pdfExtract.Extract(ofd.FileName, true));

        }


        public double S2D(string str)
        {
            double dbl = 0;
            char[] chararg = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ',', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' ', '/', '(', ')', '+' };
            
           if (double.TryParse(str.Trim(chararg), out dbl))
                return dbl;
            return 0;        }


        public void FillVariables(string texttoparse)
        {
           char[] chararg = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ',', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' ', '/', '(', ')', '-', '+' };

            char[] cleanchar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ/!@#$%^&*()+_=\\|}{[],';: ".ToCharArray();
            char[] numbers = "1234567890.-".ToCharArray();


            string workingtext = texttoparse.Substring(texttoparse.IndexOf(startsubstring));
            
            string r = workingtext.Substring(workingtext.IndexOf(ridgesubstring) + 9, 5);
            string h = workingtext.Substring(workingtext.IndexOf(hipssubstring) + 7, 5);
            string v = workingtext.Substring(workingtext.IndexOf(valleyssubstring) + 10, 5);
            string ra = workingtext.Substring(workingtext.IndexOf(rakessubstring) + 8, 5);
            string E = workingtext.Substring(workingtext.IndexOf(EavesStartersubstring) + 17, 5);
            string D = workingtext.Substring(workingtext.IndexOf(DripEdgesubstring) + 28, 5);
            string TA= workingtext.Substring(workingtext.IndexOf(totalAreasubstring) + 12,7);
            string P= workingtext.Substring(workingtext.IndexOf(predpitchsubstring) + 20,5);
       

            Ridges.Text =S2D(r.Trim(chararg).Trim()).ToString();
            Hips.Text = h.Trim(chararg).Trim().ToString();
            Valleys.Text = v.Trim(chararg).Trim().ToString();
            Rakes.Text = ra.Trim(chararg).Trim().ToString();
            Eaves.Text = E.Trim(chararg).Trim().ToString();
            OrderDripEdge.Text = D.Trim(chararg).Trim().ToString();
            TotalAreaOFF.Text = TA.Trim(chararg).Trim().ToString();
            PrePitch.Text = P.Trim(chararg).Trim().ToString();

            RidgeMeasurement = S2D(r.Trim(chararg).Trim());
            HipMeasurement= S2D(h.Trim(chararg).Trim());
            ValleyMeasurement = S2D(v.Trim(chararg).Trim());
            RakeMeasurement = S2D(ra.Trim(chararg).Trim());
            EaveMeasurement = S2D(E.Trim(chararg).Trim());
            StarterMeasurement = S2D(D.Trim(chararg).Trim());
            TotalSQFTOFF = S2D(TA.Trim(chararg).Trim());
            PredPitch = (int)S2D(P.Trim(chararg).Trim());
            FigureWaste(15, TotalSQFTOFF);
            OrderRoofNails.Text = FigureRoofNails().ToString();
            OrderRidgeVent.Text = FigureRidgevent().ToString();
            OrderPaint.Text = "3";
            OrderCaulk.Text = "3";
            Valleys.Text = FigureIceAndWater().ToString();
            OrderHipandRidge.Text = FigureHipRidge().ToString();
            OrderDripEdge.Text = FigureDripedge().ToString();
            OrderStarter.Text = FigureStarter().ToString();
            OrderUnderlayment.Text = FigureUnderlayment(10).ToString();
            

             



        }
        public int FigureRoofNails()
        {
            return (int)Math.Ceiling(FigureWaste(Slider.Value, TotalSQFTOFF) / 16);
        }

        public int FigurePlasticCaps()
        {
            return (int)Math.Ceiling(FigureWaste(Slider.Value, TotalSQFTOFF) / 20);
        }

        public int FigureRidgevent()
        {
            if(RidgeMeasurement>0)
            return (int)Math.Ceiling(RidgeMeasurement / 4);
            return 0;
        }

        public int FigureUnderlayment(int underlaymentsqroll)
        {
            if(underlaymentsqroll >0)
            return (int)Math.Ceiling(FigureWaste(Slider.Value, TotalSQFTOFF) / underlaymentsqroll);
            return 0;
        }
        public int FigureIceAndWater()
        {
            if(ValleyMeasurement>0)
            return (int)Math.Ceiling(ValleyMeasurement / 62);
            return 0;
        }
        public int FigureHipRidge()
        {
            if (HipMeasurement + RidgeMeasurement>0)
                return (int)Math.Ceiling(HipMeasurement+RidgeMeasurement / 25);
            return 0;
        }
        public int FigureStarter()
        {
            if (StarterMeasurement > 0)
                return (int)Math.Ceiling(StarterMeasurement / 100);
            return 0;
        }
        public int FigureDripedge()
        {
            if (RakeMeasurement>0)
            return (int)Math.Ceiling((RakeMeasurement +(RakeMeasurement*.1)) / 10);
            return 0;
        }
        public double FigureWaste(double wastefactor, double sqftOff)
        {

            if (sqftOff > 0)
                return Math.Ceiling((sqftOff * (wastefactor * .01) / 100));
            else return sqftOff;

        }
        private void LogOut(object sender, RoutedEventArgs e)
        {
            Login Page = new Login();
            this.NavigationService.Navigate(Page);
        }

        private string MakeAddress(string street, string city, string state, string zipcode)
        {



            StringBuilder queryaddress = new StringBuilder();


            if (street != string.Empty)
            {
                queryaddress.Append(street + "," + "+");
            }
            if (city != string.Empty)
            {
                queryaddress.Append(city + "," + "+");
            }
            if (state != string.Empty)
            {
                queryaddress.Append(state + "," + "+");
            }
            if (zipcode != string.Empty)
            {
                queryaddress.Append(zipcode + "," + "+");
            }

            return queryaddress.ToString();
        }
        private void ShowWeatherforZipcode(string webaddress)
        {

            AppointmentWebView.Source = new Uri(webaddress.ToString());

        }

        private void GetJobInfo( string Latatitude, string longitudestring, string address, string zipcode="30052", bool b=true){
            if (b == true)
			{

                ShowWeatherforZipcode("https://weather.com/weather/today/l/" + zipcode + ":4:US");
        b = false;
			}
			else {

                ShowOnMap(null,address);
				b = true; 
			}
     }

        private void ShowOnMap(string from = null, string to = null)
        {

            try
            {
                StringBuilder queryaddress = new StringBuilder();
                queryaddress.Append("http://maps.google.com/maps");
                /*	if (to == string.Empty)
					{
						queryaddress.Append("?q=");
					}
					else
					{
					*/
                queryaddress.Append("/dir/196 Old Loganville Road,Loganville,Georgia,30052/" + to);
                /*	}  */

                ShowWeatherforZipcode(queryaddress.ToString());
                //GoogleMap.Navigate();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Custom Error Message");
                //throw;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (canvas.Visibility == Visibility.Visible)
            {
                canvas.Visibility = Visibility.Hidden;
                textbox.Visibility = Visibility.Visible;
            }
            else { textbox.Visibility = Visibility.Hidden;
                canvas.Visibility = Visibility.Visible;
            }
        }
    }
}
