using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public string googleAddress { get; set; }

        string startsubstring = "Lengths, Areas and Pitches";


        List<string> Lststg = new List<string>();
        string latitude = "";
        string longitude = "Longitude = ";
        string PropertyAddressBlockStart = "Online map of property";
        //    string PropertyAddressBlockEnd = "Directions from MRN Homes of Ga. to this property";


        public RoofMeasurmentsPage()
        {
            InitializeComponent();
            PDFTextExtractor pdfExtract = new PDFTextExtractor();
            var ofd = new Microsoft.Win32.OpenFileDialog() { Filter = "PDF Files (*.pdf)|*.pdf" };
            var result = ofd.ShowDialog();
            if (result == false) return;
            textbox.Text = pdfExtract.Extract(ofd.FileName, true);
            FillVariables(pdfExtract.Extract(ofd.FileName, true));

        }




        /*    private List<string> parseEageView(string str)
            {

                //  str = "Ridges = 58 ft (blahblah 4) Somethingelse = 32.4 ft andsomethingelse = 50/2 Logitude = -83.9456826 Online Maps Online Map of Property http://maps.google.com/skldfkljsf=sdfsdf_+sdfsdf Directions from MRN Contracting to this property http://maps.google.com/skldfkljsf=sdfsdf_+sdfsdfurl2";

                // GET THE DIRECTIONS FROM MRN URL
                int index = str.LastIndexOf("http://"); // Get the index for the beginning of the last occurance of http://            
                var directionsURL = str.Substring(index); // Get the substring starting from the index of the last http://

                var tempArr = directionsURL.Split(' '); // Split the directions URL on spaces (leaving jsut the url in ther first element)
                directionsURL = tempArr[0]; // Assign the first element (the URL) to directionsURL

                str = str.Substring(0, index); // Remove everything from the index of the last http:// form the string

                //GET THE PROPERTY MAP URL
                index = str.LastIndexOf("http://");
                var propertyMapURL = str.Substring(index);

                tempArr = propertyMapURL.Split(' ');
                propertyMapURL = tempArr[0];

                str = str.Substring(0, index);

                // GET THE NUMBERS FROM THE REMAINING TEXT
                var strWithNoLetters = Regex.Replace(str, @"[A-Za-z()=\\\r\\\n+]*", string.Empty); // Replace all letters, (), and = with empty strings

                var listOfNumericStrings = strWithNoLetters.Split(' ').ToList(); // Split the string on every space

                listOfNumericStrings.RemoveAll(c => c == ""); // remove all empty string objects from the list

                for (int i = 0; i < listOfNumericStrings.Count; i++)
                {
                    if (listOfNumericStrings[i] == "." || listOfNumericStrings[i] == ",")
                        listOfNumericStrings[i] = "";
                }

                listOfNumericStrings.RemoveAll(s => s == "");

                listOfNumericStrings.RemoveAt(listOfNumericStrings.FindIndex(c => c == "/"));

                for (int i = 0; i < listOfNumericStrings.Count; i++)
                {
                    if (i < 18)
                    {
                        if (!(i % 2 == 0))
                            listOfNumericStrings[i] = "";

                    }

                    if (listOfNumericStrings[i] == "/")
                    {
                        listOfNumericStrings[i - 1] += "/" + listOfNumericStrings[i + 1];
                        listOfNumericStrings.RemoveAt(i + 1);
                        listOfNumericStrings.RemoveAt(i);
                        i--;

                    }
                }

                listOfNumericStrings.RemoveAll(s => s == "");

                listOfNumericStrings.Add(propertyMapURL);
                listOfNumericStrings.Add(directionsURL);

                return listOfNumericStrings;


        }
        */
        /*    private List<string> GetRoofSpecs(string str)
            {
                string newstring = str;
                List<string> stringlist = new List<string>();
              string tempholder = string.Empty;
               int index = str.LastIndexOf("http://"); // Get the index for the beginning of the last occurance of http://          
                var directionsURL = str.Substring(index); // Get the substring starting from the index of the last http://

                var tempArr = directionsURL.Split(' '); // Split the directions URL on spaces (leaving jsut the url in ther first element)
                directionsURL = tempArr[0]; // Assign the first element (the URL) to directionsURL

                str = str.Substring(0, index); // Remove everything from the index of the last http:// form the string

                //GET THE PROPERTY MAP URL
                index = str.LastIndexOf("http://");
                var propertyMapURL = str.Substring(index);

                tempArr = propertyMapURL.Split(' ');
                propertyMapURL = tempArr[0].ToString();

                str = str.Substring(0, index);
                stringlist.Add(propertyMapURL);
                stringlist.Add(directionsURL);
                /*

                 while ((newstring.Contains("/12") || newstring.Contains(" sq ft") || newstring.Contains(" ft (")) && newstring.Length>0)
                 {
                     double a = 0;
                     if (newstring.Contains("/12"))
                         newstring = newstring.Remove(newstring.LastIndexOf("/12"));
                     else if (tempholder.Contains(" sq ft"))
                         newstring = newstring.Remove(newstring.LastIndexOf(" sq ft"));
                     else if (newstring.Contains(" ft ("))
                         newstring = newstring.Remove(newstring.LastIndexOf(" ft ("));
                     if (double.TryParse(newstring.Substring(newstring.LastIndexOf(' ')), out a))
                         stringlist.Add(newstring.Substring(newstring.LastIndexOf(' ')).ToString());



                 }
                 if (stringlist.Count > 0)
                 {
                    stringlist.Reverse();

                     return stringlist;
                 }
                 else
                 {
                     stringlist.Add("NOTHING TO RETURN");
                     return stringlist;
                 }

                return stringlist;


            }   */

        public List<string> URL(string str)
        {

            List<string> UrlList = new List<string>();
            char[] charseperatorarg = "\r\n".ToCharArray();
            List<string> stringlist = new List<string>();
            string w = "";
            stringlist = str.Split(charseperatorarg, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            //  stringlist.RemoveAll(s => s.Contains("http://", "+") != true);

            foreach (var l in stringlist)
            {
                var stringholder = "";
                if (l.Contains("http://"))
                    if (w == string.Empty)
                        w = l;
                stringholder = w + l;
                if (l.IndexOf("http://maps.google.com/maps?f=g&source=s_q") == 0 ||
                    (l.IndexOf("http://maps.google.com/maps?f=d&source=s_d") != 0 && l.Contains("+")))
                    UrlList.Add(stringholder);

            }

            return UrlList;
        }

        public double S2D(string str)
        {
            double dbl = -1;
            char[] cleanchar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*(\r\n)+_= \\|}{[\"],';:".ToCharArray();
            double.TryParse(str.Trim(cleanchar), out dbl);
            return dbl;
        }

        public List<double> FunWithStrings(string str = null, List<string> strarg = null)
        {
            char[] charseperatorarg = "=\r\n".ToCharArray();
            List<string> stringlist = new List<string>();
            List<double> dblList = new List<double>();
            try
            {
                if (str != null)
                    stringlist = str.Split(charseperatorarg, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                else if (strarg != null)
                    stringlist = strarg;
                else str = " ";

                foreach (var l in stringlist)
                {
                    double a = 0;
                    string t = string.Empty;
                    t = l.Trim();
                    if (t.Contains(' '))
                    {
                        t = t.Remove(t.IndexOf(" "));
                    }
                    if (double.TryParse(t, out a))
                        dblList.Add(a);
                    else //if (t.Contains('/') || t.Contains('(') || t.Contains(',') || t.Contains('-'))
                    {
                        if (t.IndexOf('(') > 0)
                            dblList.Add(S2D(t.Remove(t.IndexOf('(')).ToString()));
                        else if (t.IndexOf(',') > 0)
                            dblList.Add(S2D(t.Remove(t.IndexOf(','), 1)));
                        else if (t.IndexOf('/') > 0)
                            dblList.Add(S2D(t.Replace('/', '.')));
                        else if (t.IndexOf('-') > 0)
                            dblList.Add(-1 * S2D(t.Replace('-', ' ')));
                    }
                }
                dblList.RemoveAll(dbl => dbl == -1);
                return dblList;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                throw;
            }
        }

        public void FillVariables(string texttoparse)
        {
            List<double> MeasurementList2 = new List<double>();
            List<string> MeasurementList3 = new List<string>();
            string workingtext = texttoparse.Substring(texttoparse.IndexOf(startsubstring));
            string propertyaddress = URL(texttoparse.Substring(texttoparse.IndexOf(PropertyAddressBlockStart)))[0];
           // string directionsaddress = URL(texttoparse.Substring(texttoparse.IndexOf(PropertyAddressBlockStart)))[1];
            List<double> MeasurementList4 = new List<double>();
            List<string> MeasurementList5 = new List<string>();
            MeasurementList2 = FunWithStrings(workingtext);
            MeasurementList3 = URL(workingtext);
            List<string> list = MeasurementList3;
            MeasurementList4 = FunWithStrings(null, list);
            char[] cleanchar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()+_= \\|}{[\"],';:".ToCharArray();
            char[] charseperatorarg = "( )=\r\n".ToCharArray();
            List<string> stringlist1 = new List<string>();
            List<double> dblList = new List<double>();
            stringlist1 = workingtext.Split(charseperatorarg, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            stringlist1.RemoveAll(c => c.All(char.IsLetter));
            stringlist1.RemoveAll(c => c == "");
            MeasurementList5.RemoveAll(s => s == "-1");
            Ridges.Text = MeasurementList2[1].ToString();
            Hips.Text = MeasurementList2[2].ToString();
            Valleys.Text = MeasurementList2[3].ToString();
            Rakes.Text = MeasurementList2[4].ToString();
            Eaves.Text = MeasurementList2[6].ToString();
            OrderDripEdge.Text = MeasurementList2[7].ToString();
            TotalAreaOFF.Text = MeasurementList2[11].ToString();
            PrePitch.Text = MeasurementList2[12].ToString();
            latitude = MeasurementList2[13].ToString();
            longitude = MeasurementList2[14].ToString();

            RidgeMeasurement = S2D(MeasurementList2[1].ToString());
            HipMeasurement = S2D(MeasurementList2[2].ToString());
            ValleyMeasurement = S2D(MeasurementList2[3].ToString());
            RakeMeasurement = S2D(MeasurementList2[4].ToString());
            EaveMeasurement = S2D(MeasurementList2[6].ToString());
            StarterMeasurement = S2D(MeasurementList2[7].ToString());
            TotalSQFTOFF = S2D(MeasurementList2[11].ToString());
            PredPitch = (int)S2D(MeasurementList2[12].ToString());
            // Lststg = MeasurementList3;
            DoMath();


        }
        /// <summary>
        /// Takes Data in the form usually of string objects has the selector to identify which function to call with the data and 2 other control variables
        /// </summary>
        //Show Property On Map      S2D is cleaner string to double converter
        /// <param name="jlbArg"></param>
        //jlbArg[0] = latitude               //jlbArg[0] = MRNNumber 
        //jlbArg[1] = longitude              //jlbArg[1] = Customer Namw  
        //jlbArg[2] = Zoom                   //jlbArg[2] = Customer Street Address  
        //jlbArg[9] =  Zipcode 

        
        /// <param name="iOutputSelection"></param>
        /// <param name="bVarible"></param>
        /// <param name="ivariable"></param>





        /// <returns></returns>
        public Uri JobDataWebViewControl(string[] jlbArg, int iOutputSelection = 0, bool bVarible = true, int ivariable = 0)
        {
            string address = string.Empty;


            switch (iOutputSelection)
            {
                case 1:
                    {


                        
                        address = "https://www.google.com/maps/@" + jlbArg[0] + "," + jlbArg[1] + ",+" + jlbArg[2] + "m/data=!3m1!1e3?hl=en";//if satdata true 
                        break;

                    }

                case 2:                 //Show Eagle View        
                    {
                        address = "";
                        break;

                    }
                case 3:                 //Show Order
                    {
                        address = "";
                        break;

                    }
                case 4:                 //Show Scope
                    {
                        address = "";
                        break;

                    }
                case 5:                 //Show Sketch
                    {
                        address = "";
                        break;

                    }
                case 6:                 //Show Calendar
                    {
                        address = "";
                        break;

                    }
                case 7:                 //Show Weather
                    {
                        address = "";
                        break;

                    }

                case 8:                 //Show Authorization Form
                    {
                        address = "";
                        break;

                    }
                default:                        // Normal thing for this function to perform
                    address = "";
                    break;
            }

            StringBuilder sb = new StringBuilder();
            sb.Clear();





            return new Uri(sb.ToString());



        }





        public void DoMath()

        {

            OrderSqShingle.Text = FigureWaste(Slider.Value, TotalSQFTOFF).ToString();
            OrderRoofNails.Text = FigureRoofNails().ToString();
            OrderRidgeVent.Text = FigureRidgevent().ToString();
            OrderButtonCaps.Text = FigurePlasticCaps().ToString();
            Valleys.Text = FigureIceAndWater().ToString();
            OrderHipandRidge.Text = FigureHipRidge().ToString();
            OrderDripEdge.Text = FigureDripedge().ToString();
            OrderStarter.Text = FigureStarter().ToString();
            if (UnderlaymentCombo.SelectedIndex > 0) OrderUnderlayment.Text = FigureUnderlayment(10).ToString();
            else OrderUnderlayment.Text = FigureUnderlayment(4).ToString();
            OrderPaint.Text = "3";
            OrderCaulk.Text = "3";
        }


        public double FigureWaste(double wastefactor = 0, double sqftOff = 0)
        {

            if (sqftOff == 0 && wastefactor == 0)
                return Math.Ceiling((TotalSQFTOFF + (TotalSQFTOFF * (Slider.Value * .01))) / 100);
            else if (sqftOff > 0)
                return Math.Ceiling((sqftOff + (sqftOff * (Slider.Value * .01))) / 100);
            else return TotalSQFTOFF / 100;

        }

        public int FigureRoofNails()
        {
            return (int)Math.Ceiling(FigureWaste() / 16);
        }

        public int FigurePlasticCaps()
        {
            return (int)Math.Ceiling(FigureWaste() / 20);
        }

        public int FigureRidgevent()
        {
            if (RidgeMeasurement > 0)
                return (int)Math.Ceiling(RidgeMeasurement / 4);
            return 0;
        }

        public int FigureUnderlayment(int underlaymentsqroll = 4)
        {
            if (underlaymentsqroll > 0)
                return (int)Math.Ceiling((TotalSQFTOFF / 100) / underlaymentsqroll);
            return 0;
        }
        public int FigureIceAndWater()
        {
            if (ValleyMeasurement > 0)
                return (int)Math.Ceiling(ValleyMeasurement / 62);
            return 0;
        }

        public int FigureHipRidge()
        {
            if (HipMeasurement + RidgeMeasurement > 0)
                return (int)Math.Ceiling((HipMeasurement + RidgeMeasurement) / 25);
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
            if (RakeMeasurement > 0)
                return (int)Math.Ceiling((RakeMeasurement + (RakeMeasurement * .1)) / 10);
            return 0;
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

        private void GetJobInfo(string Latatitude, string longitudestring, string address, string zipcode = "30052", bool b = true)
        {
            if (b == true)
            {

                ShowWeatherforZipcode("https://weather.com/weather/today/l/" + zipcode + ":4:US");
                b = false;
            }
            else
            {

                ShowOnMap(null, address);
                b = true;
            }
        }

        private void ShowOnMap(string from = null, string to = null)
        {
            //  private void ShowOnMap(int ContentToShow)
            try
            {
                StringBuilder queryaddress = new StringBuilder();
                queryaddress.Append("http://maps.google.com/maps");

                queryaddress.Append("/dir/196 Old Loganville Road,Loganville,Georgia,30052/" + to);


                ShowWeatherforZipcode(queryaddress.ToString());


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Custom Error Message");
                //throw;
            }
        }



        private void PeekABoo(bool bVisible = false)
        {
            if (!bVisible)
            {
                // if (ReferralKnockerText.Text == string.Empty)
                //     ReferralKnockerText.Visibility = Visibility.Hidden;
                ///  OverheadOverride.Visibility = Visibility.Hidden;
                // OverheadMultiplierAmountText.Visibility = Visibility.Hidden;
                // label1_Copy15.Visibility = Visibility.Hidden;
                // OverheadLabel.Visibility = Visibility.Hidden;
                // SplitOverRideGroupbox.Visibility = Visibility.Hidden;
                // label1_Copy24.Visibility = Visibility.Hidden;
                // RecruiterText.Visibility = Visibility.Hidden;
                //     NextButton.Visibility = Visibility.Hidden;
                textBlock.Background = System.Windows.Media.Brushes.White;
                textBlock.Foreground = System.Windows.Media.Brushes.Black;
                canvas.Background = System.Windows.Media.Brushes.White;
                PrintButton.Visibility = Visibility.Hidden;
                //SplitOverride.Visibility = Visibility.Hidden;
                //SalespersonSplitText.Visibility = Visibility.Hidden;

                Print();
            }
            else
            {


                // ReferralKnockerText.Visibility = Visibility.Visible;
                // OverheadOverride.Visibility = Visibility.Visible;
                // OverheadMultiplierAmountText.Visibility = Visibility.Visible;
                // label1_Copy15.Visibility = Visibility.Visible;
                //  OverheadLabel.Visibility = Visibility.Visible;
                //SplitOverRideGroupbox.Visibility = Visibility.Visible;
                //label1_Copy24.Visibility = Visibility.Visible;
                //RecruiterText.Visibility = Visibility.Visible;
                textBlock.Background = Brushes.Transparent;
                textBlock.Foreground = System.Windows.Media.Brushes.White;

                canvas.Background = System.Windows.Media.Brushes.Transparent;
                // NextButton.Visibility = Visibility.Visible;
                PrintButton.Visibility = Visibility.Visible;
                // SplitOverride.Visibility = Visibility.Visible;
                //   SalespersonSplitText.Visibility = Visibility.Visible;


            }
        }

        private void Print()
        {
            PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
            object clone = Transform.Parse(Transform.Identity.Clone().Value.ToString());
            OrderCanvas.LayoutTransform = new ScaleTransform(1.62, 1.5);
            Size pageSize = new Size(printDlg.PrintableAreaWidth, printDlg.PrintableAreaHeight );
            OrderCanvas.Measure(pageSize);
            OrderCanvas.Arrange(new Rect(20, 20, pageSize.Width+20, pageSize.Height+50));
            printDlg.PrintVisual(OrderCanvas, "Roof Order #" + MRNNumber);
            OrderCanvas.LayoutTransform = (Transform)clone;
            InvalidateVisual();

            PeekABoo(true);
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            PeekABoo();


        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RoofMeasurmentsPage());
        }

        private void On_OK(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new NexusHome());
        }

        private void OrderBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DoMath();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (TotalSQFTOFF > 0) DoMath();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PeekABoo();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RoofMeasurmentsPage());
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RoofMeasurmentsPage());
        }

        private void toggleButton_Checked(object sender, RoutedEventArgs e)
        {


            OrderCanvas.Visibility = Visibility.Collapsed;
            textbox.Visibility = Visibility.Collapsed;
            AppointmentWebView.Visibility = Visibility.Visible;


            AppointmentWebView.Source = JobDataWebViewControl(null, 1);


        }

        private void toggleButton_Click(object sender, RoutedEventArgs e)
        {
            int izoom = 90;
            string strzoom = izoom.ToString();



            Uri URLLink = new Uri("https://www.google.com/maps/@" + latitude + "," + longitude + ",+" + izoom + "m/data=!3m1!1e3?hl=en");//if satdata true 





            AppointmentWebView.Source = URLLink;
        }

        private void toggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            OrderCanvas.Visibility = Visibility.Collapsed;
            textbox.Visibility = Visibility.Collapsed;
            AppointmentWebView.Visibility = Visibility.Visible;
        }

        private void OrderSqShingle_TextChanged(object sender, TextChangedEventArgs e)
        {
            double a = 0;
            if (double.TryParse(OrderSqShingle.Text, out a))
                DoMath();
        }

        private void View_Order(object sender, RoutedEventArgs e)
        {
            OrderCanvas.Visibility = Visibility.Visible;
            textbox.Visibility = Visibility.Collapsed;
            AppointmentWebView.Visibility = Visibility.Collapsed;
        }



        private void SatViewGoogle(object sender, RoutedEventArgs e)
        {
            OrderCanvas.Visibility = Visibility.Collapsed;
            textbox.Visibility = Visibility.Collapsed;
            AppointmentWebView.Visibility = Visibility.Visible;


            AppointmentWebView.Source = JobDataWebViewControl(null, 1);

        }
    }
}
