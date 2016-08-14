using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
//using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Media.Animation;
using System.Media;

using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using MRNUIElements.Models.Structure;
using static MRNUIElements.Models.Structure.Lines;
using static MRNUIElements.Models.Structure.Planes;

using static MRNUIElements.Models.Structure.Point3d;

namespace MRNUIElements
{
    /// <summary>
    /// Interaction logic for ModelMaker.xaml
    /// </summary>
    public partial class ModelMaker : Page
    {
        int q = 0;
        bool goo = false;
        static Lines L1 = Lines.getInstance();
        static Point3d O1 = Point3d.getInstance();
        static Planes P1 = Planes.getInstance();
        static public ObservableCollection<Planes> planes = Planes.lgetInstance();
        static public ObservableCollection<Lines> lines = Lines.lgetInstance();
        static public ObservableCollection<Point3d> points = Point3d.lgetInstance();
        static string textblock = "";
        static List<string> POINTS = new List<string>();
        static List<string> LINES = new List<string>();
        static List<string> POLYGONS = new List<string>();
        public string ALLTEXT = "";
        string Address = "";
        string Zip = "";
        Point3d point = new Point3d();
        Lines line = new Lines();
        Planes plane = new Planes();
        List<string> RAW = new List<string>();
        List<string> FILTER = new List<string>();


        OpenFileDialog ofd = new OpenFileDialog();
        public ModelMaker()
        {
          
       
       
            InitializeComponent();
            FILTER.Add("<LINE");
            FILTER.Add("<POLYGON");
            FILTER.Add("<POINT");
            FILTER.Add("<FACES>");
            FILTER.Add("<LINES>");
            FILTER.Add("<POINTS>");
        }
        private void ChangeTimerStatus(bool go = false)
        {
            goo = go;
            if (goo)
            {

                System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);
                dispatcherTimer.Start();
            }
        }


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (q < lines.Count())
            {
                LineList.SelectedIndex = q;
                q++;
            }
            else
            {
                canvas.Children.Clear();
                q = 0;
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            q = 0;
            ChangeTimerStatus(!goo);

        }



        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {



        }

        private void OpenSave_Click(object sender, RoutedEventArgs e)
        {
            ofd.ShowDialog();

        }

        private void ParseBtn_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder output = new StringBuilder();
            try
            {
                //ofd.FileName;
                using (StreamReader st = new StreamReader(ofd.FileName))

                {
                    string line;
                    while ((line = st.ReadLine()) != null)
                    {
                        RAW.Add(line);
                        MessageBox.Show(st.ToString());
                        ALLTEXT = st.ReadToEnd();
                        textBox.Text = ALLTEXT;

                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("File Couldn't be read! " + ex.Message);

            }
            //string fe = "";
            String xmlString = ALLTEXT;
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {


            }
            KeyValueModel kvm = new KeyValueModel();

            kvm.GetTagTextBlockText(ALLTEXT, "id", "<LINES>");
            LINES = ALLTEXT.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList().Where(g => g.Contains(FILTER.ElementAt(0).ToString())).ToList();
            kvm.GetTagTextBlockText(ALLTEXT, "id", "<FACES>");
            POLYGONS = ALLTEXT.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList().Where(g => g.Contains(FILTER.ElementAt(1).ToString())).ToList();
            foreach (string s in LINES.Where(s => s.Contains(',')))
            {
                string w = kvm.GetParamValue(s, "id", null);
                //w = w.Remove(0, 1);
                string v = kvm.GetParamValue(s, "path", null);

                string u = v.Remove(v.IndexOf(','));
                v = v.Remove(0, v.IndexOf(','));

                if (u.Contains(','))
                    u = u.Replace(',', ' ');
                if (u.Contains('\"'))
                    u = u.Replace('\"', ' ');
                u = u.Trim();
                if (v.Contains(','))
                    v = v.Replace(',', ' ');
                if (v.Contains('\"'))
                    v = v.Replace('\"', ' ');
                v = v.Trim();

                string t = kvm.GetParamValue(s, "type", null);
                if (t.Contains('\"'))
                    t = t.Remove(t.IndexOf('\"'));
                Lines l = new Lines();
                l.LineID = w;

                l.StartingPointID = u;
                l.EndingPointID = v;
                l.Type = t;
                lines.Add(l);
            }
            LineList.ItemsSource = lines;
            KeyValueModel kvm1 = new KeyValueModel();
            kvm1.GetTagTextBlockText(ALLTEXT, "id", "<POINTS>"); ;
            POINTS = ALLTEXT.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList().Where(g => g.Contains(FILTER.ElementAt(2).ToString())).ToList();

            foreach (string b in POINTS.Where(b => b.Contains(',')))
            {
                MRNUIElements.Models.Structure.Point3d le = new Models.Structure.Point3d();
                string w1 = kvm.GetParamValue(b, "id", null);
                le.PointID = w1;
                string v1 = kvm.GetParamValue(b, "data", null);
                char[] a = ",".ToCharArray();


                List<string> r = new List<string>();
                r = v1.Split(a, StringSplitOptions.RemoveEmptyEntries).ToList();
                le.X = decimal.Parse(r[0]);
                le.Y = decimal.Parse(r[1]);
                le.Z = decimal.Parse(r[2]);

                points.Add(le);

            }
            PointsList.ItemsSource = points;

            foreach (string b in POLYGONS.Where(b => b.Contains(',')))
            {
                MRNUIElements.Models.Structure.Planes le = new Models.Structure.Planes();
                string w1 = kvm.GetParamValue(b, "id", null);
                string v2 = kvm.GetParamValue(b, "orientation", null);
                string v1 = kvm.GetParamValue(b, "path", null);
                char[] a = ",".ToCharArray();


                List<string> r = new List<string>();
                //   int groupID = 0;
                int i = 0;
                r = v1.Split(a, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (string s in r)
                {
                    le.PlaneID = w1;
                    le.Lines = r[i].ToString();

                    le.Orientation = v2;
                    planes.Add(le);
                    i++;
                }

            }
            PolygonList.ItemsSource = planes;
            System.Windows.Forms.MessageBox.Show(planes.Count.ToString() + " Planes consisting of " + lines.Count.ToString() + " lines added to the structure Consisting of " + points.Count.ToString() + " points.");

        }

        private void OKbtn_Click(object sender, RoutedEventArgs e)
        {
            Panel.SetZIndex(OKbtn, 50); FullScreen();
        }

        private void RevertBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DynamicallyPopulateckbx_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void DynamicallyPopulateckbx_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Polygonsrad_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void linesrad_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Pointsrad_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void StausTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tags_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StartTagCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EndTagCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PointsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PolygonList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LineList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Line l = new Line();



            string t = lines[LineList.SelectedIndex].StartingPointID;
            string u = lines[LineList.SelectedIndex].EndingPointID;



            //      points.Single(b => b.PointID == t);

            //      points.Single(b => b.PointID == u);
            double Centerx = canvas.ActualWidth / 2;
            double Centery = canvas.ActualHeight / 2;

            l.X1 = (double)points.Single(b => b.PointID == t).X + Centerx / 2;
            l.X2 = (double)points.Single(b => b.PointID == u).X + Centerx / 2;
            l.Y1 = (double)points.Single(b => b.PointID == t).Y + Centery / 2;
            l.Y2 = (double)points.Single(b => b.PointID == u).Y + Centery / 2;
            l.Stroke = Brushes.Black;
            l.StrokeThickness = 1;
            l.Fill = Brushes.Black;
            canvas.Children.Add(l);


        }

        private void canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Transform st = new ScaleTransform(e.Delta, e.Delta, e.GetPosition(canvas).X, e.GetPosition(canvas).Y);


        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void canvas_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void FullScreen()
        {
            Panel.SetZIndex(canvas, 10);
            canvas.Width = MainGrid.Width;
            canvas.Height = MainGrid.Height;
        }
    }
}
