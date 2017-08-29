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
using System.Globalization;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using MRNUIElements.Models.Structure;
using static MRNUIElements.Models.Structure.Lines;
using static MRNUIElements.Models.Structure.Planes;
using static MRNUIElements._3dViewPort;
using static MRNUIElements.Models.Structure.Point3d;

using static MRNUIElements.ModelMaker;
using HelixToolkit.Wpf;

namespace MRNUIElements
{
    /// <summary>
    /// Interaction logic for ModelMaker.xaml
    /// </summary>
    public partial class ModelMaker : Page
    {
        int rrr = 0;
        int q = 0;
        bool goo = false;
        bool bFullScreen = false;
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
        LinesVisual3D LineMesh = new LinesVisual3D();
        Point3d point = new Point3d(0, 0, 0);
        Lines line = new Lines();
        Planes plane = new Planes();
      
        List<string> RAW = new List<string>();
        List<string> FILTER = new List<string>();
        Viewport2DVisual3D vp = new Viewport2DVisual3D();
        Point3DCollection p3dCol = new Point3DCollection();
        Point3DConverter p3dConv = new Point3DConverter();
        int mm = 1;
        Visual3DCollection p3dcoll;
        OpenFileDialog ofd = new OpenFileDialog();
        public ModelMaker()
        {

            this.DataContext = this;

            InitializeComponent();
            FILTER.Add("<LINE");
            FILTER.Add("<POLYGON");
            FILTER.Add("<POINT");
            FILTER.Add("<FACES>");
            FILTER.Add("<LINES>");
            FILTER.Add("<POINTS>");

            // viewframe.Children.Add(new Frame { HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, Name = "View", Content = viewport3d, Background = Brushes.Transparent, Width = 700, Height = 700 });

            viewport3d.Visibility = Visibility.Hidden;


        }
        private void ChangeTimerStatus(bool go = false)
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

            goo = go;
            if (goo)
            {
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);

                dispatcherTimer.Start();
            }
            else dispatcherTimer.Stop();
        }


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (q < lines.Count())
            {
                LineList.SelectedIndex = q;
                if (q < PolygonList.Items.Count)
                PolygonList.SelectedIndex = q;
                q++;
               
            }
            else
            {
                if (DynamicallyPopulateckbx.IsChecked == true)
                {
                    canvas.Children.Clear();
                    q = 0;
                }
                else
                    ChangeTimerStatus();
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
          

            
            Model3DGroup mygroup3d = new Model3DGroup();
            
            
            ModelVisual3D modvis3d = new ModelVisual3D();
            GeometryModel3D mygeomod = new GeometryModel3D();
            
            LinearGradientBrush myHorgrad = new LinearGradientBrush();
            myHorgrad.StartPoint = new Point(0, 0.5);
            myHorgrad.EndPoint = new Point(1, 0.5);
            myHorgrad.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myHorgrad.GradientStops.Add(new GradientStop(Colors.Red, 0.25));
            myHorgrad.GradientStops.Add(new GradientStop(Colors.Blue, 0.75));
            myHorgrad.GradientStops.Add(new GradientStop(Colors.LimeGreen, 1.0));
            DiffuseMaterial mymat = new DiffuseMaterial(myHorgrad);

            mygeomod.Material = mymat;

            var mat = Materials.Hue;

         //   new MeshGeometryVisual3D().Children.Add(LineMesh);

            MeshGeometryVisual3D w = new MeshGeometryVisual3D();
            Mesh3D h = new Mesh3D();
            foreach (Point3d p in points)
            {
                h.Vertices.Add(new Point3D((double)p.X, (double)p.Y, (double)p.Z));
               
            }

          
           
           
            mygroup3d.Children.Add(new GeometryModel3D(h.ToMeshGeometry3D(), mymat));



            mygroup3d.Children.Add(mygeomod);
            modvis3d.Content = mygroup3d;
            viewport3d.Children.Add(modvis3d);
            //viewport3d.Children.Add(LineMesh);
            // var myV3d = new LineGeometryBuilder(LineMesh);
           
           
          
           
        }


        public void MakeMeshShell(MeshGeometry3D mesh)
        {

            GeometryModel3D mygeomod = new GeometryModel3D();
            LinearGradientBrush myHorgrad = new LinearGradientBrush();
            myHorgrad.StartPoint = new Point(0, 0.5);
            myHorgrad.EndPoint = new Point(1, 0.5);
            myHorgrad.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myHorgrad.GradientStops.Add(new GradientStop(Colors.Red, 0.25));
            myHorgrad.GradientStops.Add(new GradientStop(Colors.Blue, 0.75));
            myHorgrad.GradientStops.Add(new GradientStop(Colors.LimeGreen, 1.0));
            DiffuseMaterial mymat = new DiffuseMaterial(myHorgrad);

            mygeomod.Material = mymat;

            var mat = Materials.Hue;

            Model3DGroup mygroup3d = new Model3DGroup();
            ModelVisual3D modvis3d = new ModelVisual3D();

            mygroup3d.Children.Add(new GeometryModel3D(mesh, mat));
         

            mygroup3d.Children.Add(mygeomod);
            modvis3d.Content = mygroup3d;
            viewport3d.Children.Add(modvis3d);
            ModelMaker.Model = mygroup3d;
        }


        public void BuildRoof(int n, double rotation=0)
        {

            if (rotation > 359) rotation = 0;

            Point3D p0 = new Point3D(0, 0, 0);
            Point3D p1 = new Point3D(0, 0, 0);
            Point3D p2 = new Point3D(0, 0, 0);
            Point3D p3 = new Point3D(0, 0, 0);

            Point3DCollection pc = new Point3DCollection();
            MeshGeometry3D mymeshg3d = new MeshGeometry3D();

            switch (n)
            {
                case 0:
                    {
                        p0 = new Point3D(0, 48, 0);
                        p1 = new Point3D(72, 48, 0);
                        p2 = new Point3D(72, 32, 10);
                        p3 = new Point3D(0, 32, 10);
                        break;
                    }
                case 1:
                    {

                        p3 = new Point3D(20, 48, 0);
                        p0 = new Point3D(20, 52, 0);
                        p1 = new Point3D(30, 52, 7);
                        p2 = new Point3D(30, 40, 7);


                        break;
                    }
                case 2:
                    {

                        p3 = new Point3D(30, 40, 7);
                        p0 = new Point3D(30, 52, 7);
                        p1 = new Point3D(40, 52, 0);
                        p2 = new Point3D(40, 48, 0);


                        break;
                    }
                case 3:
                    {
                        p0 = new Point3D(72, 48, 0);
                        p1 = new Point3D(80, 48, 0);
                        p2 = new Point3D(80, 28, 7);
                        p3 = new Point3D(72, 28, 7);


                        break;
                    }
                case 4:
                    {

                        p0 = new Point3D(80, 44, 0);
                        p1 = new Point3D(84, 44, 0);
                        p2 = new Point3D(84, 32, 6);
                        p3 = new Point3D(80, 32, 6);



                        break;
                    }
                case 5:
                    {

                        p3 = new Point3D(0, 16, 0);
                        p0 = new Point3D(0, 32, 10);
                        p1 = new Point3D(72, 32, 10);
                        p2 = new Point3D(72, 16, 0);

                        break;
                    }
                case 6:
                    {
                        break;
                    }
                case 7:
                    {
                        break;
                    }
                case 8:
                    {
                        break;
                    }
                case 9:
                    {
                        break;
                    }

                case 10:
                    {




                        break;
                    }

                default:
                    break;
            }


            pc.Add(p0);
            pc.Add(p1);
            pc.Add(p2);
            pc.Add(p3);
            Rotation3D transform = new AxisAngleRotation3D(new Vector3D(0, 0, 1), (double)rotation);

            RotateTransform3D rotate = new RotateTransform3D(transform, p1);

            GeometryModel3D mygeomod = new GeometryModel3D();
            LinearGradientBrush myHorgrad = new LinearGradientBrush();
            myHorgrad.StartPoint = new Point(0, 0.5);
            myHorgrad.EndPoint = new Point(1, 0.5);
            myHorgrad.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myHorgrad.GradientStops.Add(new GradientStop(Colors.Red, 0.25));
            myHorgrad.GradientStops.Add(new GradientStop(Colors.Blue, 0.75));
            myHorgrad.GradientStops.Add(new GradientStop(Colors.LimeGreen, 1.0));
            DiffuseMaterial mymat = new DiffuseMaterial(myHorgrad);

            mygeomod.Material = mymat;

            var mat = Materials.Hue;

            Model3DGroup mygroup3d = new Model3DGroup();
            ModelVisual3D modvis3d = new ModelVisual3D();
            
            mygroup3d.Children.Add(new GeometryModel3D((MeshGeometry3D)MakeAShape(Math.Abs(p0.X - p1.X), Math.Abs(p1.Y - p2.Y), Math.Abs(2), p0, p2), mat))  ;


            mygroup3d.Children.Add(mygeomod);
            modvis3d.Content = mygroup3d;
            viewport3d.Children.Add(modvis3d);
            ModelMaker.Model = mygroup3d;


        }
        public Point3DCollection GetLinePoints(List<string> LineList)
        {
            Point3DCollection p3dcol = new Point3DCollection();

            foreach (string s in LineList.Where(s => (L1.LineID == s) && (O1.PointID == L1.StartingPointID) || O1.PointID == L1.EndingPointID))
            {

               p3dcol.Add(new Point3D((double)O1.X, (double)O1.Y, (double)O1.Z));
            }

            return p3dcol;
        }

       
         public List<string> GetPlaneLineIDs (string PlaneID)
        {

            List<string> LineList = new List<string>();

            foreach(Planes p in planes.Where(p => P1.PlaneID == PlaneID))
            {
                LineList.Add(p.LineId);
            }

            return LineList;

        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            BuildRoof(rrr);
            rrr++;
        }

        private void OpenSave_Click(object sender, RoutedEventArgs e)
        {
            ChangeTimerStatus();
            var result = ofd.ShowDialog();
            if ((bool)result)

                GoDoIt();

        }

        private void ParseBtn_Click(object sender, RoutedEventArgs e)
        {




            var modelGroup = new Model3DGroup();

            // Create a mesh builder and add a box to it
            var meshBuilder = new MeshBuilder(false, false);
            meshBuilder.AddBox(new Point3D(0, 0, 1), 1, 2, 0.5);
            meshBuilder.AddBox(new Rect3D(0, 0, 1.2, 0.5, 1, 0.4));

            // Create a mesh from the builder (and freeze it)
            var mesh = meshBuilder.ToMesh(true);

            // Create some materials
            var greenMaterial = MaterialHelper.CreateMaterial(Colors.Green);
            var redMaterial = MaterialHelper.CreateMaterial(Colors.Red);
            var blueMaterial = MaterialHelper.CreateMaterial(Colors.Blue);
            var insideMaterial = MaterialHelper.CreateMaterial(Colors.Yellow);

            // Add 3 models to the group (using the same mesh, that's why we had to freeze it)
            modelGroup.Children.Add(new GeometryModel3D
            {
                Geometry = mesh,
                Material = greenMaterial,
                BackMaterial = insideMaterial
            });
            modelGroup.Children.Add(new GeometryModel3D
            {
                Geometry = mesh,
                Transform = new TranslateTransform3D(-2, 0, 0),
                Material = redMaterial,
                BackMaterial = insideMaterial
            });
            modelGroup.Children.Add(new GeometryModel3D { Geometry = mesh, Transform = new TranslateTransform3D(2, 0, 0), Material = blueMaterial, BackMaterial = insideMaterial });

            // Set the property, which will be bound to the Content property of the ModelVisual3D (see MainWindow.xaml)
            Model = modelGroup;
        }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>
        public static Model3D Model { get; set; }


        private void GoDoIt()
        {
            viewport3d.Children.Clear();
            lines.Clear();
            points.Clear();
            planes.Clear();

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
                       // MessageBox.Show(st.ToString());
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
                if (t!="FLASHING"|| t!="STEPFLASH")
                lines.Add(l);
            }
            LineList.ItemsSource = Lines.lines;
            KeyValueModel kvm1 = new KeyValueModel();
            kvm1.GetTagTextBlockText(ALLTEXT, "id", "<POINTS>"); ;
            POINTS = ALLTEXT.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList().Where(g => g.Contains(FILTER.ElementAt(2).ToString())).ToList();

            foreach (string b in POINTS.Where(b => b.Contains(',')))
            {
                MRNUIElements.Models.Structure.Point3d le = new Models.Structure.Point3d(0, 0, 0);
                string w1 = kvm.GetParamValue(b, "id", null);
                le.PointID = w1;
                string v1 = kvm.GetParamValue(b, "data", null);
                char[] a = ",".ToCharArray();


                List<string> r = new List<string>();
                r = v1.Split(a, StringSplitOptions.RemoveEmptyEntries).ToList();
                le.X = decimal.Parse(r[0]);
                le.Y = decimal.Parse(r[1]);
                le.Z = decimal.Parse(r[2]);
                p3dCol.Add(new Point3D((double)le.X, (double)le.Y, (double)le.Z));
                points.Add(le);
                //p3dConv.ConvertFrom((Point3d))

            }
            PointsList.ItemsSource = Point3d.points;

            foreach (string c in POLYGONS.Where(c => c.Contains(',')))
            {

                string w1 = kvm.GetParamValue(c, "id", null);
                string v2 = kvm.GetParamValue(c, "orientation", null);
                string v1 = kvm.GetParamValue(c, "path", null);
                string v3 = kvm.GetParamValue(c, "pitch", null);
                char[] a = ",".ToCharArray();

                List<string> linegroup = new List<string>();


                linegroup = v1.Split(a, StringSplitOptions.RemoveEmptyEntries).ToList();
                //  int i = 0;
                foreach (string s in v1.Split(a, StringSplitOptions.RemoveEmptyEntries).ToList())
                {
                    Planes lf = new Models.Structure.Planes();
                    lf.PlaneID = w1;
                    lf.LineId = s;
                    lf.Pitch = v3;

                    lf.Orientation = v2;
                    planes.Add(lf);
                    //   i++;
                }

            }
            PolygonList.ItemsSource = Planes.planes;
            System.Windows.Forms.MessageBox.Show(planes.Count.ToString() + " Planes consisting of " + lines.Count.ToString() + " lines added to the structure Consisting of " + points.Count.ToString() + " points.");
           
            //  this.DataContext = new MainViewModel();
        }


        private void PolygonBuilder(string PlaneId)
        {
            var mesh3d = new Mesh3D();
            var modelGroup = new Model3DGroup();
            var meshBuilder = new MeshBuilder(true, false);
            var g3d = new MeshGeometry3D();
            int a = 0;
            foreach (Planes p in planes.Where(p => p.LineId == L1.LineID))
            {
                if (a < 4)
                    g3d.Positions.Add(new Point3D((double)O1.X, (double)O1.Y, (double)O1.Z));
                else
                {
                    g3d.Normals = MeshGeometryHelper.CalculateNormals(g3d);
                    g3d.TriangleIndices = MeshGeometryHelper.FindEdges(g3d);
                    var mat = Materials.Rainbow;
                    //mesh3d.UpdateEdges();
                    //mesh3d.Triangulate(false);
                    modelGroup.Children.Add(new GeometryModel3D(g3d, mat));
                    ModelMaker.Model = modelGroup;
                }
            }
           

            
            //foreach (Point3d p in points)
            //{

            //    Point3DCollection pc = new Point3DCollection();
            //    Point3D p3d = new Point3D();
            //    p3d.X = (double)p.X;
            //    p3d.Y = (double)p.Y;
            //    p3d.Z = (double)p.Z;
            //    pc.Add(p3d);
            //    Vector3D v3d = new Vector3D(p3d.ToVector3D().X, p3d.ToVector3D().Y, p3d.ToVector3D().Z);
            //    System.Windows.Shapes.Polygon pg = new System.Windows.Shapes.Polygon();
            //    Point pt = new Point();
            //    pt.X = p3d.X;
            //    pt.Y = p3d.Y;
            //    pg.Points.Add(pt);
            //    var pl = new Polyline();
            //    pl.Points.Add(pt);
            //    var pls = new PolyLineSegment();
            //    pls.Points.Add(pt);
            //    pls.IsStroked = true;
            //    g3d.Positions.Add(p3d);
            //    g3d.Normals.Add(v3d);
            //    mesh3d.Vertices.Add(p3d);



            //}

            //mesh3d.AddFace(mesh3d.Faces.Count);
            //mesh3d.UpdateEdges();
            //var mesh = meshBuilder.ToMesh();
          

               





            // Set the property, which will be bound to the Content property of the ModelVisual3D (see MainWindow.xaml)
            //      Model = modelGroup;
            //       this.DataContext = Model;


        }

        public void DrawLines3D(Point3D p0, Point3D p1)
        {

          

         //   Point3DCollection pc = new Point3DCollection();
         //   MeshGeometry3D mymeshg3d = new MeshGeometry3D();
            var Line = new LinesVisual3D();
            if (p0 == null || p1 == null)
            {
                foreach (Point3d p in points)
                {
                    Line.Points.Add(new Point3D((double)p.X, (double)p.Y, (double)p.Z));
                    Line.Thickness = 2;
                    Line.Color = Colors.White;
                    LineMesh.Children.Add(Line);
                }

            }
            else
            {
                Line.Points.Add(p0);
                LineMesh.Points.Add(p0);
                Line.Points.Add(p1);
                LineMesh.Points.Add(p1);
            }
            var mymeshg3d = new MeshGeometry3D();
           
            viewport3d.Children.Add(Line);

           
           

           
           


        }
        private void OKbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NexusHome());
        }

        private void RevertBtn_Click(object sender, RoutedEventArgs e)
        {
            Panel.SetZIndex(OKbtn, 50);
            FullScreen();
        }

        private void DynamicallyPopulateckbx_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void DynamicallyPopulateckbx_Click(object sender, RoutedEventArgs e)
        { 
            if (DynamicallyPopulateckbx.IsChecked==true)
            {
                canvas.Children.Clear();
                q = 0;
                ChangeTimerStatus(true);
            }
            else
            ChangeTimerStatus();
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
            if (PolygonList.HasItems)
            {
              //  string pp = ((Planes)PolygonList.SelectedItem).PlaneID;
                PolygonBuilder(((Planes)PolygonList.SelectedItem).PlaneID);

              //  this.DataContext = new MainViewModel(pp);
            }
        }

        private void LineList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LineList.HasItems)
            {
                Line l = new Line();



                string t = lines[LineList.SelectedIndex].StartingPointID;
                string u = lines[LineList.SelectedIndex].EndingPointID;



                //      points.Single(b => b.PointID == t);

                //      points.Single(b => b.PointID == u);
                double Centerx = canvas.ActualWidth / 2;
                double Centery = canvas.ActualHeight / 2;

                l.X1 = (double)points.Single(b => b.PointID == t).X + Centerx * .5;
                l.X2 = (double)points.Single(b => b.PointID == u).X + Centerx * .5;
                l.Y1 = (double)points.Single(b => b.PointID == t).Y + Centery * .5;
                l.Y2 = (double)points.Single(b => b.PointID == u).Y + Centery * .5;
                l.Stroke = Brushes.Black;
                l.StrokeThickness = 1;
                l.Fill = Brushes.Black;
                canvas.Children.Add(l);
                DrawLines3D(new Point3D((double)points.Single(b => b.PointID == t).X, (double)points.Single(b => b.PointID == t).Y, (double)points.Single(b => b.PointID == t).Z), new Point3D((double)points.Single(b => b.PointID == u).X, (double)points.Single(b => b.PointID == u).Y, (double)points.Single(b => b.PointID == u).Z));
                // if(Canvas1.Visibility==Visibility.Visible)
                //  DrawingVisual dv = new DrawingVisual();

                //  Canvas1.Children.Add(l);
            }
        }

        private void canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Transform st = new ScaleTransform(e.Delta, e.Delta, e.GetPosition(canvas).X, e.GetPosition(canvas).Y);


        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        public object MakeAShape(double width, double height, double thickness, Point3D Offset1, Point3D Offset2, bool LR = true, ScottSpecialSauce ss = null)
        {
            double X = 0;
            double Y = 0;
            double Z = 0;
            Point3D t = Offset1;
            Point3D u = Offset2;

            double Width = width;
            double Height = height;
            double Thickness = thickness;

            //closest set of points

            Point3D pt0 = new Point3D(Offset1.X, Offset1.Y, Offset1.Z);
            Point3D pt1 = new Point3D(Offset1.X + Width, Offset1.Y, Offset1.Z);
            Point3D pt2 = new Point3D(Offset1.X + Width, Offset1.Y + Height, Offset2.Z);
            Point3D pt3 = new Point3D(Offset1.X, Offset1.Y + Height, Offset2.Z);
            //farthest set of points
            Point3D pt4 = new Point3D(Offset1.X, Offset1.Y, Offset1.Z+Thickness);
            Point3D pt5 = new Point3D(Offset1.X + Width, Offset1.Y, Offset1.Z + Thickness);
            Point3D pt6 = new Point3D(Offset1.X + Width, Offset1.Y + Height, Offset2.Z + Thickness);
            Point3D pt7 = new Point3D(Offset1.X, Offset1.Y + Height, Offset2.Z + Thickness);

            Point3DCollection pc = new Point3DCollection();
            MeshGeometry3D mesh = new MeshGeometry3D();
            Mesh3D m3D = new Mesh3D();
            MeshVisual3D mv3D = new MeshVisual3D();
            MeshGeometryVisual3D mgv3D = new MeshGeometryVisual3D();
            pc.Add(pt0);
            pc.Add(pt2);
            pc.Add(pt1);
            pc.Add(pt3);
            pc.Add(pt4);
            pc.Add(pt5);
            pc.Add(pt6);
            pc.Add(pt7);
            mesh.Positions.Add(pt0);
            mesh.Positions.Add(pt1);
            mesh.Positions.Add(pt2);
            mesh.Positions.Add(pt3);

            mesh.Positions.Add(pt4);
            mesh.Positions.Add(pt5);
            mesh.Positions.Add(pt6);
            mesh.Positions.Add(pt7);
            //mesh.TriangleIndices= MeshGeometryHelper.FindEdges(mesh);
            
            var v3dc = new Vector3DCollection(MeshGeometryHelper.CalculateNormals(mesh)) ;
            v3dc.Add(pc[0].ToVector3D());
            v3dc.Add(pc[1].ToVector3D());
            v3dc.Add(pc[2].ToVector3D());
            v3dc.Add(pc[3].ToVector3D());
            v3dc.Add(pc[4].ToVector3D());
            v3dc.Add(pc[5].ToVector3D());
            v3dc.Add(pc[6].ToVector3D());
            v3dc.Add(pc[7].ToVector3D());

            v3dc[0].Normalize();
            v3dc[1].Normalize();
            v3dc[2].Normalize();
            v3dc[3].Normalize();
            v3dc[4].Normalize();
            v3dc[5].Normalize();
            v3dc[6].Normalize();
            v3dc[7].Normalize();

            mesh.Normals.Add(v3dc[0]);
            mesh.Normals.Add(v3dc[1]);
            mesh.Normals.Add(v3dc[2]);
            mesh.Normals.Add(v3dc[3]);
            mesh.Normals.Add(v3dc[4]);
            mesh.Normals.Add(v3dc[5]);
            mesh.Normals.Add(v3dc[6]);
            mesh.Normals.Add(v3dc[7]);

            // Front face
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(3);

            // Back face
            mesh.TriangleIndices.Add(6);
            mesh.TriangleIndices.Add(5);
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(6);
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(7);

            // Right face
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(5);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(5);
            mesh.TriangleIndices.Add(6);

            // Top face
            mesh.TriangleIndices.Add(7);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(7);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(6);

            // Bottom face
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(5);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(5);
            mesh.TriangleIndices.Add(1);

            // Right face
            mesh.TriangleIndices.Add(7);
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(7);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(3);
            
            



            mesh.TextureCoordinates.Add(new Point(pt0.X, pt0.Y));
            mesh.TextureCoordinates.Add(new Point(pt1.X, pt1.Y));
            mesh.TextureCoordinates.Add(new Point(pt2.X, pt2.Y));
            mesh.TextureCoordinates.Add(new Point(pt3.X, pt3.Y));
            mesh.TextureCoordinates.Add(new Point(pt4.X, pt4.Y));
            mesh.TextureCoordinates.Add(new Point(pt5.X, pt5.Y));
            mesh.TextureCoordinates.Add(new Point(pt6.X, pt6.Y));
            mesh.TextureCoordinates.Add(new Point(pt7.X, pt7.Y));











            return mesh;





        }
        private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void canvas_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void FullScreen()
        {
            //   Content = canvas;
            //  Canvas1.Visibility = Visibility.Visible;

            bFullScreen = true;
            if (bFullScreen)
            {
                //             Panel.SetZIndex(canvas, 10);
                //           canvas.Width = MainGrid.Width;
                //            canvas.Height = MainGrid.Height;
            }
            else
            {
                //             canvas.Width = 675;
                //             canvas.Height = 270;
            }
        }

        private void TimerCtrl_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        private void EnableViewPort_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void EnableViewPort_Click(object sender, RoutedEventArgs e)
        {
            if (EnableViewPort.IsChecked == true)
            {
                viewport3d.Visibility = Visibility.Visible;
            }
            else
                viewport3d.Visibility = Visibility.Hidden;
        }
    }

    public class MainViewModel
    {

        public static Model3D Model { get; set; }
        static Lines L1 = Lines.getInstance();
        static Point3d O1 = Point3d.getInstance();
        static Planes P1 = Planes.getInstance();
        static public ObservableCollection<Planes> planes = Planes.lgetInstance();
        static public ObservableCollection<Lines> lines = Lines.lgetInstance();
        static public ObservableCollection<Point3d> points = Point3d.lgetInstance();
        static HalfEdgeMesh HE = new HalfEdgeMesh();
        public string v { get; set; }
        public MainViewModel(string v)
        {
            var modelGroup = new Model3DGroup();

            // Create a mesh builder and add a box to it
            var meshBuilder = new MeshBuilder(true, false);
            
            var mat = Materials.Rainbow;

            
            
            Model3DGroup mygroup3d = new Model3DGroup();
           mygroup3d.Children.Add(new GeometryModel3D((MeshGeometry3D)MakeAShape(72,24,2,new Point3D(0,0,10),new Point3D(0,24,0)),mat));
            Model = mygroup3d;



            //   modelGroup.Children.Add(new GeometryModel3D(hem.ToMeshGeometry3D(), mat));

            //     mesh3d.UpdateEdges();
            //     mesh3d.Triangulate(false);
            //      modelGroup.Children.Add(new GeometryModel3D(mesh3d.ToMeshGeometry3D(), mat));


            // var greenMaterial = MaterialHelper.CreateMaterial(Colors.Green);
            //   var redMaterial = MaterialHelper.CreateMaterial(Colors.Red);
            //  var blueMaterial = MaterialHelper.CreateMaterial(Colors.Blue);
            //  var insideMaterial = MaterialHelper.CreateMaterial(Colors.Yellow);

            // Add 3 models to the group (using the same mesh, that's why we had to freeze it)


            //  modelGroup.Children.Add(new GeometryModel3D { Geometry = mesh, Material = greenMaterial, BackMaterial = insideMaterial });
            //    modelGroup.Children.Add(new GeometryModel3D { Geometry = mesh, Transform = new TranslateTransform3D(-2, 0, 0), Material = redMaterial, BackMaterial = insideMaterial });
            //    modelGroup.Children.Add(new GeometryModel3D { Geometry = mesh, Transform = new TranslateTransform3D(2, 0, 0), Material = blueMaterial, BackMaterial = insideMaterial });

            // Set the property, which will be bound to the Content property of the ModelVisual3D (see MainWindow.xaml)
            //Model = modelGroup;
        }
        public object MakeAShape(double width, double height, double thickness, Point3D Offset1, Point3D Offset2, bool LR = true, ScottSpecialSauce ss= null)
        {
            double X = 0;
            double Y = 0;
            double Z = 0;
            double Width = width;
            double Height = height;
            double Thickness = thickness;
            Point3D pt0 = new Point3D(Offset2.X, Offset2.Y, Offset2.Z);
            Point3D pt1 = new Point3D(Offset2.X + Width, Offset2.Y, Offset2.Z);
            Point3D pt2 = new Point3D(Offset1.X + Width, Offset1.Y + Height, Offset1.Z);
            Point3D pt3 = new Point3D(Offset1.X, Offset1.Y+Height, Offset1.Z);

            Point3D pt4 = new Point3D(Offset2.X, Offset2.Y, Offset2.Z-Thickness);
            Point3D pt5 = new Point3D(Offset2.X + Width, Offset2.Y, Offset2.Z - Thickness);
            Point3D pt6 = new Point3D(Offset1.X + Width, Offset1.Y + Height, Offset1.Z - Thickness);
            Point3D pt7 = new Point3D(Offset1.X, Offset1.Y + Height, Offset1.Z - Thickness);

            Point3DCollection pc = new Point3DCollection();
            MeshGeometry3D mG3D = new MeshGeometry3D();
            Mesh3D m3D = new Mesh3D();
            MeshVisual3D mv3D = new MeshVisual3D();
            MeshGeometryVisual3D mgv3D = new MeshGeometryVisual3D();
            pc.Add(pt0);
            pc.Add(pt1);
            pc.Add(pt2);
            pc.Add(pt3);
            pc.Add(pt4);
            pc.Add(pt5);
            pc.Add(pt6);
            pc.Add(pt7);
            mG3D.Positions.Add(pt0);
            mG3D.Positions.Add(pt1);
            mG3D.Positions.Add(pt2);
            mG3D.Positions.Add(pt3);
            mG3D.Positions.Add(pt4);
            mG3D.Positions.Add(pt5);
            mG3D.Positions.Add(pt6);
            mG3D.Positions.Add(pt7);

            Vector3DCollection v3dc = new Vector3DCollection();
            v3dc.Add(pc[0].ToVector3D());
            v3dc.Add(pc[1].ToVector3D());
            v3dc.Add(pc[2].ToVector3D());
            v3dc.Add(pc[3].ToVector3D());
            v3dc.Add(pc[4].ToVector3D());
            v3dc.Add(pc[5].ToVector3D());
            v3dc.Add(pc[6].ToVector3D());
            v3dc.Add(pc[7].ToVector3D());
            v3dc[0].Normalize();
            v3dc[1].Normalize();
            v3dc[2].Normalize();
            v3dc[3].Normalize();
            v3dc[4].Normalize();
            v3dc[5].Normalize();
            v3dc[6].Normalize();
            v3dc[7].Normalize();
            mG3D.Normals.Add(v3dc[0]);
            mG3D.Normals.Add(v3dc[1]);
            mG3D.Normals.Add(v3dc[2]);
            mG3D.Normals.Add(v3dc[3]);
            mG3D.Normals.Add(v3dc[4]);
            mG3D.Normals.Add(v3dc[5]);
            mG3D.Normals.Add(v3dc[6]);
            mG3D.Normals.Add(v3dc[7]);
            mG3D.TriangleIndices.Add(0);
            mG3D.TriangleIndices.Add(1);
            mG3D.TriangleIndices.Add(2);
            mG3D.TriangleIndices.Add(0);
            mG3D.TriangleIndices.Add(2);
            mG3D.TriangleIndices.Add(3);
            mG3D.TriangleIndices.Add(1);
            mG3D.TriangleIndices.Add(5);
            mG3D.TriangleIndices.Add(6);
            mG3D.TriangleIndices.Add(1);
            mG3D.TriangleIndices.Add(6);
            mG3D.TriangleIndices.Add(2);
            mG3D.TriangleIndices.Add(4);
            mG3D.TriangleIndices.Add(5);
            mG3D.TriangleIndices.Add(1);
            mG3D.TriangleIndices.Add(4);
            mG3D.TriangleIndices.Add(1);
            mG3D.TriangleIndices.Add(0);
            mG3D.TriangleIndices.Add(3);
            mG3D.TriangleIndices.Add(4);
            mG3D.TriangleIndices.Add(7);
            mG3D.TriangleIndices.Add(3);
            mG3D.TriangleIndices.Add(7);
            mG3D.TriangleIndices.Add(6);
            mG3D.TriangleIndices.Add(4);
            mG3D.TriangleIndices.Add(0);
            mG3D.TriangleIndices.Add(3);
            mG3D.TriangleIndices.Add(4);
            mG3D.TriangleIndices.Add(3);
            mG3D.TriangleIndices.Add(7);
            mG3D.TriangleIndices.Add(3);
            mG3D.TriangleIndices.Add(2);
            mG3D.TriangleIndices.Add(6);
            mG3D.TriangleIndices.Add(3);
            mG3D.TriangleIndices.Add(6);
            mG3D.TriangleIndices.Add(7);
            mG3D.TextureCoordinates.Add(new Point(pt0.X, pt0.Y));
            mG3D.TextureCoordinates.Add(new Point(pt1.X, pt1.Y));
            mG3D.TextureCoordinates.Add(new Point(pt2.X, pt2.Y));
            mG3D.TextureCoordinates.Add(new Point(pt3.X, pt3.Y));
            mG3D.TextureCoordinates.Add(new Point(pt4.X, pt4.Y));
            mG3D.TextureCoordinates.Add(new Point(pt5.X, pt5.Y));
            mG3D.TextureCoordinates.Add(new Point(pt6.X, pt6.Y));
            mG3D.TextureCoordinates.Add(new Point(pt7.X, pt7.Y));

            MeshGeometryHelper.FindEdges(mG3D);










            return mG3D;





        }


        public object MakeAShape(Point3DCollection pc, Point3D Offset1, Point3D Offset2, ScottSpecialSauce sauce = null)
        {

            var meshBuilder = new MeshBuilder();
            var mesh3D = new Mesh3D();



            int verticecount = pc.Count;
            switch (verticecount)
            {
                case 1:
                    return this;
                case 2: return this;
                case 3:
                    meshBuilder.AddTriangle(pc[0], pc[1], pc[2]);
                    return meshBuilder;
                case 4:
                    meshBuilder.AddQuad(pc[0], pc[1], pc[2], pc[3]);
                    return meshBuilder;

                default:
                    return this;
            }


        }


        //  bool firsttime = true;
        ////  int i = 1; //string v = "";
        //  foreach (Planes y in planes)
        //  {

        //      Point3DCollection pt3D = new Point3DCollection();
        //     // v = "P" + i.ToString();
        //      firsttime = true;
        //      Point3D first = new Point3D(0, 0, 0);
        //      Point3D last = new Point3D(0, 0, 0);
        //      Point3D thispoint = new Point3D(0, 0, 0);
        //      Polygon3D poly = new Polygon3D();
        //      int j = 0;
        //      //if (v == null) return;
        //      foreach (Planes x in planes.Where(z => z.PlaneID == v))
        //      {



        //          string t = lines[j].StartingPointID;
        //          string u = lines[j].EndingPointID;
        //          j++;



        //         if(j<=1)
        //             pt3D.Add(new Point3D((double)points.Single(b => b.PointID == t).X, (double)points.Single(b => b.PointID == t).Y, (double)points.Single(b => b.PointID == t).Z));

        //              pt3D.Add(new Point3D((double)points.Single(b => b.PointID == u).X, (double)points.Single(b => b.PointID == u).Y, (double)points.Single(b => b.PointID == u).Z));
        //              //   last = new Point3D((double)points.Single(b => b.PointID == u).X, (double)points.Single(b => b.PointID == u).Y, (double)points.Single(b => b.PointID == u).Z);



        //      }
        //      poly.Points = pt3D;//poly
        //                         //Materials.Orange;
        //                         //(pt3D,Materials.Orange)
        //      if (pt3D.Count == 3)
        //          meshBuilder.AddTriangle(pt3D[0], pt3D[1], pt3D[2]);
        //      if (pt3D.Count == 4)
        //         meshBuilder.AddQuad(pt3D[0], pt3D[1], pt3D[2], pt3D[3]);
        //      if (pt3D.Count > 4)
        //         meshBuilder.AddRectangularMesh(pt3D.ToList(), 3);
        //      //foreach (Point3d p in points) {

        //      //    Point3D e = new Point3D();
        //      //    e.X = (double)p.X;
        //      //    e.Y = (double)p.Y;
        //      //    e.Z = (double)p.Z;

        //      //        meshBuilder.Positions.Add(e);
        //      //meshBuilder.Normals.Add(e.ToVector3D());
        //      // meshBuilder.TextureCoordinates.Add(new Point((double)p.X, (double)p.Y));
        //   //   i++;
        //  }



        //   // meshBuilder.CreateNormals = true;
        //  // meshBuilder.CreateTextureCoordinates = true;
        //   //  var Tri= meshBuilder.TriangleIndices;
        //      //   new Vector3D(10, 0, 0), new Vector3D(0, 10, 0), new Point3D(0, 0, 0)

        //      //  var m = new List<Point3D>(meshBuilder.Positions).ToList() as IList<Point3D>;

        //      var triInd = meshBuilder.TriangleIndices;
        //      var Norm = meshBuilder.Normals;
        //  meshBuilder.AddPolygon(triInd);
        //  meshBuilder.AddBox(new Point3D(0, 0, 1), 1, 2, 0.5);
        //   meshBuilder.AddBox(new Rect3D(0, 0, 1.2, 0.5, 1, 0.4));


        //var mesh = meshBuilder.ToMesh();
        // var greenMateriala = MaterialHelper.CreateMaterial(Colors.Green);
        //  modelGroup.Children.Add(new GeometryModel3D(mesh, greenMateriala));
        // if (pt3D.Count>2)


        //    meshBuilder.Append(mesha);

        // }



        // Create a mesh from the builder (and freeze it)




        //  var mesh = meshBuilder.ToMesh(true);


        // Create some materials
        //var greenMaterial = MaterialHelper.CreateMaterial(Colors.Green);
        //var redMaterial = MaterialHelper.CreateMaterial(Colors.Red);
        //var blueMaterial = MaterialHelper.CreateMaterial(Colors.Blue);
        //var insideMaterial = MaterialHelper.CreateMaterial(Colors.Yellow);

        //// Add 3 models to the group (using the same mesh, that's why we had to freeze it)
        //modelGroup.Children.Add(new GeometryModel3D
        //{
        //    Geometry = mesh,
        //    Material = greenMaterial,
        //    BackMaterial = insideMaterial
        //});
        //modelGroup.Children.Add(new GeometryModel3D
        //{
        //    Geometry = mesh,
        //    Transform = new TranslateTransform3D(-2, 0, 0),
        //    Material = redMaterial,
        //    BackMaterial = insideMaterial
        //});
        //modelGroup.Children.Add(new GeometryModel3D { Geometry = mesh, Transform = new TranslateTransform3D(2, 0, 0), Material = blueMaterial, BackMaterial = insideMaterial });

        //// Set the property, which will be bound to the Content property of the ModelVisual3D (see MainWindow.xaml)
        //  Model = modelGroup;
        //  var modelGroup = new Model3DGroup();

        // Create a mesh builder and add a box to it
        //  var meshBuildera = new MeshBuilder(false, false);
        //meshBuildera.AddBox(new Point3D(0, 0, 1), 1, 2, 0.5);
        //meshBuildera.AddBox(new Rect3D(0, 0, 1.2, 0.5, 1, 0.4));

        ////var n = meshBuilder.CreateNormals;

        ////// Create a mesh from the builder (and freeze it)
        //// var mesh = meshBuilder.ToMesh(true);

        //// Create some materials
        //var greenMaterial = MaterialHelper.CreateMaterial(Colors.Green);
        //    var redMaterial = MaterialHelper.CreateMaterial(Colors.Red);
        //    var blueMaterial = MaterialHelper.CreateMaterial(Colors.Blue);
        //    var insideMaterial = MaterialHelper.CreateMaterial(Colors.Yellow);

        //    // Add 3 models to the group (using the same mesh, that's why we had to freeze it)
        //    modelGroup.Children.Add(new GeometryModel3D { Geometry = mesh, Material = greenMaterial, BackMaterial = insideMaterial });
        //    //    modelGroup.Children.Add(new GeometryModel3D { Geometry = mesh, Transform = new TranslateTransform3D(-2, 0, 0), Material = redMaterial, BackMaterial = insideMaterial });
        //    //    modelGroup.Children.Add(new GeometryModel3D { Geometry = mesh, Transform = new TranslateTransform3D(2, 0, 0), Material = blueMaterial, BackMaterial = insideMaterial });

        //    // Set the property, which will be bound to the Content property of the ModelVisual3D (see MainWindow.xaml)
        //    this.Model = modelGroup;

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>


        // Set the property, which will be bound to the Content property of the ModelVisual3D (see MainWindow.xaml)
        //   Model = modelGroup;
        //    this.Model = modelGroup;
    }
    public class ScottSpecialSauce
    {

        public ScottSpecialSauce()
        {

        }
    }

    /// <summary>
    /// Represent a manifold mesh by a halfedge data structure.
    /// </summary>
    /// <remarks>
    /// See http://en.wikipedia.org/wiki/Polygon_mesh http://www.dgp.toronto.edu/~alexk/lydos.html http://openmesh.org http://sharp3d.codeplex.com http://www.cs.sunysb.edu/~gu/software/MeshLib/index.html http://www.flipcode.com/archives/The_Half-Edge_Data_Structure.shtml http://www.cgal.org/Manual/latest/doc_html/cgal_manual/HalfedgeDS/Chapter_main.html http://algorithmicbotany.org/papers/smithco.dis2006.pdf http://www.cs.mtu.edu/~shene/COURSES/cs3621/SLIDES/Mesh.pdf http://mrl.nyu.edu/~dzorin/ig04/lecture24/meshes.pdf http://www.hao-li.com/teaching/surfaceRepresentationAndGeometricModeling/OpenMeshTutorial.pdf http://www.cs.rpi.edu/~cutler/classes/advancedgraphics/S09/lectures/02_Adjacency_Data_Structures.pdf
    /// </remarks>
    public class HalfEdgeMesh
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HalfEdgeMesh" /> class.
        /// </summary>
        public HalfEdgeMesh()
        {
            this.Vertices = new List<Vertex>();
            this.Edges = new List<HalfEdge>();
            this.Faces = new List<Face>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HalfEdgeMesh"/> class.
        /// </summary>
        /// <param name="vertices">
        /// The vertices.
        /// </param>
        /// <param name="triangleIndices">
        /// The triangle indices.
        /// </param>
        public HalfEdgeMesh(IList<Point3D> vertices, IList<int> triangleIndices = null)
            : this()
        {
            // Add each vertex to the Vertices collection
            for (int i = 0; i < vertices.Count; i++)
            {
                this.Vertices.Add(new Vertex { Position = vertices[i], Index = i });
            }

            if (triangleIndices != null)
            {
                // Add each triangle face and update the halfedge structures
                for (int i = 0; i < triangleIndices.Count; i += 3)
                {
                    this.AddFace(triangleIndices[i], triangleIndices[i + 1], triangleIndices[i + 2]);
                }
            }
        }

        /// <summary>
        /// Gets or sets the edges.
        /// </summary>
        /// <value> The edges. </value>
        public IList<HalfEdge> Edges { get; set; }

        /// <summary>
        /// Gets or sets the faces.
        /// </summary>
        /// <value> The faces. </value>
        public IList<Face> Faces { get; set; }

        /// <summary>
        /// Gets or sets the vertices.
        /// </summary>
        /// <value> The vertices. </value>
        public IList<Vertex> Vertices { get; set; }

        /// <summary>
        /// Adds the face.
        /// </summary>
        /// <param name="indices">
        /// The indices.
        /// </param>
        /// <returns>
        /// The face.
        /// </returns>
        public Face AddFace(params int[] indices)
        {
            int n = indices.Length;
            var faceVertices = indices.Select(i => this.Vertices[i]).ToList();
            var face = new Face { Index = this.Faces.Count };
            var faceEdges = new HalfEdge[n];

            // Create the halfedges for the face
            for (int j = 0; j < n; j++)
            {
                faceEdges[j] = new HalfEdge
                {
                    StartVertex = faceVertices[j],
                    EndVertex = faceVertices[(j + 1) % n],
                    Face = face,
                    Index = this.Edges.Count
                };
                this.Edges.Add(faceEdges[j]);
            }

            // Set the NextEdge properties
            for (int j = 0; j < n; j++)
            {
                faceEdges[j].NextEdge = faceEdges[(j + 1) % n];
            }

            for (int j = 0; j < n; j++)
            {
                var startVertex = faceVertices[j];
                var endVertex = faceVertices[(j + 1) % n];
                if (endVertex.FirstIncomingEdge == null)
                {
                    // This is the first incoming edge to this vertex
                    endVertex.FirstIncomingEdge = faceEdges[j];
                }
                else
                {
                    // todo: this needs to be fixed - I have just been trying to get the right structure in this first prototype
                    // The vertex has been used by before, check if any of the edges are adjacent
                    foreach (var e in this.Edges)
                    {
                        if (e == faceEdges[j])
                        {
                            continue;
                        }

                        if (e.StartVertex == startVertex && e.EndVertex == endVertex)
                        {
                            throw new InvalidOperationException("Edge already used.");
                        }

                        if (e.StartVertex == endVertex && e.EndVertex == startVertex)
                        {
                            e.AdjacentEdge = faceEdges[j];
                            faceEdges[j].AdjacentEdge = e;
                            break;
                        }
                    }

                    // for (int k = 0; k < n; k++)
                    // {
                    // var v0 = faceVertices[(j + k) % n];
                    // var v1 = faceVertices[(j + k + 1) % n];
                    // if (startVertex == v0 && endVertex == v1)
                    // {
                    // throw new InvalidOperationException("Edge already defined.");
                    // }

                    // if (endVertex == v0 && startVertex == v1)
                    // {
                    // // Set the AdjacentEdge property
                    // endVertex.FirstIncomingEdge.AdjacentEdge = faceEdges[(j + k) % n];
                    // faceEdges[(j + k) % n].AdjacentEdge = endVertex.FirstIncomingEdge;
                    // }
                    // }
                }
            }

            // Add the first edge to the face
            face.Edge = faceEdges[0];

            // Add the face to the faces collection
            this.Faces.Add(face);

            return face;
        }

        /// <summary>
        /// Gets the faces.
        /// </summary>
        /// <returns>
        /// The faces.
        /// </returns>
        public IEnumerable<HalfEdge> GetFaces()
        {
            var isEdgeVisited = new bool[this.Edges.Count];
            for (int i = 0; i < this.Edges.Count; i++)
            {
                if (!isEdgeVisited[i])
                {
                    yield return this.Edges[i];
                }

                foreach (var e in this.Edges[i].Face.Edges)
                {
                    int j = this.Edges.IndexOf(e);
                    isEdgeVisited[j] = true;
                }
            }
        }

        /// <summary>
        /// Create a MeshGeometry3D.
        /// </summary>
        /// <returns>
        /// A MeshGeometry3D.
        /// </returns>
        public MeshGeometry3D ToMeshGeometry3D()
        {
            return new MeshGeometry3D
            {
                Positions = new Point3DCollection(this.Vertices.Select(v => v.Position)),
                TriangleIndices = new Int32Collection(this.Triangulate())
            };
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            this.Vertices.Select((v, i) => v.Index = i).ToList();
            this.Edges.Select((e, i) => e.Index = i).ToList();
            this.Faces.Select((f, i) => f.Index = i).ToList();
            var builder = new StringBuilder();
            foreach (var v in this.Vertices)
            {
                builder.AppendLine(v.ToString());
            }

            foreach (var v in this.Edges)
            {
                builder.AppendLine(v.ToString());
            }

            foreach (var v in this.Faces)
            {
                builder.AppendLine(v.ToString());
            }

            return builder.ToString();
        }

        /// <summary>
        /// Gets the triangle indices.
        /// </summary>
        /// <returns>
        /// The triangle indices.
        /// </returns>
        public IEnumerable<int> Triangulate()
        {
            return from face in this.Faces from v in face.Triangulate() select v.Index;
        }

        /// <summary>
        /// Represents a face.
        /// </summary>
        public class Face
        {
            /// <summary>
            /// Gets the adjacent faces.
            /// </summary>
            /// <value> The adjacent faces. </value>
            public IEnumerable<Face> AdjacentFaces
            {
                get
                {
                    return this.Edges.Select(edge => edge.AdjacentFace).Where(adjacentFace => adjacentFace != null);
                }
            }

            /// <summary>
            /// Gets or sets the first edge of the face.
            /// </summary>
            /// <value> The edge. </value>
            public HalfEdge Edge { get; set; }

            /// <summary>
            /// Gets the edges.
            /// </summary>
            /// <value> The edges. </value>
            public IEnumerable<HalfEdge> Edges
            {
                get
                {
                    var edge = this.Edge;
                    do
                    {
                        yield return edge;
                        edge = edge.NextEdge;
                    }
                    while (edge != this.Edge);
                }
            }

            /// <summary>
            /// Gets or sets the index.
            /// </summary>
            /// <value> The index. </value>
            public int Index { get; set; }

            /// <summary>
            /// Gets or sets the tag.
            /// </summary>
            /// <value> The tag. </value>
            public object Tag { get; set; }

            /// <summary>
            /// Gets the vertices.
            /// </summary>
            /// <value> The vertices. </value>
            public IEnumerable<Vertex> Vertices
            {
                get
                {
                    return this.Edges.Select(e => e.EndVertex);
                }
            }

            /// <summary>
            /// Returns a <see cref="System.String"/> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String"/> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return string.Format(
                    "f{0}: {1} | {2}",
                    this.Index,
                    this.Vertices.Select(v => v.Index).EnumerateToString("v"),
                    this.Edges.Select(e => e.Index).EnumerateToString("e"));
            }

            /// <summary>
            /// Triangulates this face.
            /// </summary>
            /// <returns>
            /// Triangulated vertices.
            /// </returns>
            public IEnumerable<Vertex> Triangulate()
            {
                var v = this.Vertices.ToList();
                for (int i = 1; i + 1 < v.Count; i++)
                {
                    yield return v[0];
                    yield return v[i];
                    yield return v[i + 1];
                }
            }

        }

        /// <summary>
        /// Represents a half edge.
        /// </summary>
        public class HalfEdge
        {
            /// <summary>
            /// Gets or sets the adjacent edge.
            /// </summary>
            /// <value> The adjacent edge. </value>
            public HalfEdge AdjacentEdge { get; set; }

            /// <summary>
            /// Gets the adjacent face.
            /// </summary>
            /// <value> The adjacent face. </value>
            public Face AdjacentFace
            {
                get
                {
                    return this.AdjacentEdge != null ? this.AdjacentEdge.Face : null;
                }
            }

            /// <summary>
            /// Gets or sets the end vertex.
            /// </summary>
            /// <value> The end vertex. </value>
            public Vertex EndVertex { get; set; }

            /// <summary>
            /// Gets or sets the face.
            /// </summary>
            /// <value> The face. </value>
            public Face Face { get; set; }

            /// <summary>
            /// Gets or sets the index.
            /// </summary>
            /// <value> The index. </value>
            public int Index { get; set; }

            /// <summary>
            /// Gets or sets the next edge.
            /// </summary>
            /// <value> The next edge. </value>
            public HalfEdge NextEdge { get; set; }

            /// <summary>
            /// Gets or sets the start vertex.
            /// </summary>
            /// <value> The start vertex. </value>
            public Vertex StartVertex { get; set; }

            /// <summary>
            /// Gets or sets the tag.
            /// </summary>
            /// <value> The tag. </value>
            public object Tag { get; set; }

            // public Vertex StartVertex
            // {
            // get
            // {
            // if (AdjacentEdge != null) return AdjacentEdge.EndVertex;

            // var edge = this;
            // do
            // {
            // if (edge.NextEdge == this) return edge.EndVertex;
            // edge = edge.NextEdge;
            // } while (edge != this);

            // return null;
            // }
            // }
            /// <summary>
            /// Checks if the halfedge is on the boundary of the mesh.
            /// </summary>
            /// <returns>
            /// <c>true</c> if the halfedge is on the boundary; otherwise, <c>false</c> .
            /// </returns>
            public bool IsOnBoundary()
            {
                return this.AdjacentEdge == null;
            }

            /// <summary>
            /// Returns a <see cref="System.String"/> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String"/> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return string.Format(
                    "e{0}: v{1}->v{2} ae{3} f{4} af{5}",
                    this.Index,
                    this.StartVertex.Index,
                    this.EndVertex.Index,
                    this.AdjacentEdge != null ? this.AdjacentEdge.Index.ToString(CultureInfo.InvariantCulture) : "-",
                    this.Face.Index,
                    this.AdjacentFace != null ? this.AdjacentFace.Index.ToString(CultureInfo.InvariantCulture) : "-");
            }

        }

        /// <summary>
        /// Represents a vertex.
        /// </summary>
        public class Vertex
        {
            /// <summary>
            /// Gets the adjacent faces.
            /// </summary>
            /// <value> The adjacent faces. </value>
            public IEnumerable<Face> AdjacentFaces
            {
                get
                {
                    return this.OutgoingEdges.Select(e => e.Face);
                }
            }

            /// <summary>
            /// Gets or sets the first incoming edge.
            /// </summary>
            /// <value> The first incoming edge. </value>
            public HalfEdge FirstIncomingEdge { get; set; }

            /// <summary>
            /// Gets the incoming halfedges.
            /// </summary>
            /// <value> The incoming edges. </value>
            public IEnumerable<HalfEdge> IncomingEdges
            {
                get
                {
                    var edge = this.FirstIncomingEdge;
                    do
                    {
                        yield return edge;
                        edge = edge.NextEdge.AdjacentEdge;
                    }
                    while (edge != this.FirstIncomingEdge && edge != null);
                }
            }

            /// <summary>
            /// Gets or sets the index.
            /// </summary>
            /// <value> The index. </value>
            public int Index { get; set; }

            /// <summary>
            /// Gets the halfedges originating from the vertex.
            /// </summary>
            public IEnumerable<HalfEdge> OutgoingEdges
            {
                get
                {
                    return this.IncomingEdges.Where(e => e.AdjacentEdge != null).Select(e => e.AdjacentEdge);
                }
            }

            /// <summary>
            /// Gets or sets the position.
            /// </summary>
            /// <value> The position. </value>
            public Point3D Position { get; set; }

            /// <summary>
            /// Gets or sets the tag.
            /// </summary>
            /// <value> The tag. </value>
            public object Tag { get; set; }

            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value> The value. </value>
            public double Value { get; set; }

            /// <summary>
            /// Gets the vertices in the one ring neighborhood.
            /// </summary>
            public IEnumerable<Vertex> Vertices
            {
                get
                {
                    return this.OutgoingEdges.Select(h => h.EndVertex);
                }
            }

            /// <summary>
            /// Determines whether the vertex is on the boundary.
            /// </summary>
            /// <returns>
            /// <c>true</c> if the vertex is on the boundary; otherwise, <c>false</c> .
            /// </returns>
            public bool IsOnBoundary()
            {
                if (this.FirstIncomingEdge == null)
                {
                    return true;
                }

                return this.OutgoingEdges.Any(edge => edge.IsOnBoundary());
            }

            /// <summary>
            /// Returns a <see cref="System.String"/> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String"/> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return string.Format(
                    "v{0}: {1} | {2} | {3} | {4}",
                    this.Index,
                    this.FirstIncomingEdge.Face.Edges.Select(e => e.Index).EnumerateToString("e"),
                    this.IncomingEdges.Select(e => e.Index).EnumerateToString("ie"),
                    this.OutgoingEdges.Select(e => e.Index).EnumerateToString("oe"),
                    this.AdjacentFaces.Select(f => f.Index).EnumerateToString("af"));
            }

        }
    }
}

