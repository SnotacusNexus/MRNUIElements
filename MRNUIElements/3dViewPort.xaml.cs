//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
////using System.Windows.Forms;
//using System.Xml;
//using System.IO;
//using System.Windows.Media.Media3D;
//using System.Windows.Media.TextFormatting;
//using System.Windows.Media.Animation;
//using System.Media;

//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using Microsoft.Win32;
//using MRNUIElements.Models.Structure;
//using static MRNUIElements.Models.Structure.Lines;
//using static MRNUIElements.Models.Structure.Planes;
//using static MRNUIElements.ModelMaker;
//using static MRNUIElements.Models.Structure.Point3d;
//using HelixToolkit.Wpf;
//namespace MRNUIElements
//{

//    /// Interaction logic for _3dViewPort.xaml
//    /// </summary>
//    public partial class _3dViewPort : Page
//    {
//        int q = 0;
//        bool goo = false;
//        bool bFullScreen = false;
//        static Lines L1 = Lines.getInstance();
//        static Point3d O1 = Point3d.getInstance();
//        static Planes P1 = Planes.getInstance();
//        static public ObservableCollection<Planes> planes = Planes.lgetInstance();
//        static public ObservableCollection<Lines> lines = Lines.lgetInstance();
//        static public ObservableCollection<Point3d> points = Point3d.lgetInstance();
//        static string textblock = "";
//        static List<string> POINTS = new List<string>();
//        static List<string> LINES = new List<string>();
//        static List<string> POLYGONS = new List<string>();
//        public string ALLTEXT = "";
//        string Address = "";
//        string Zip = "";
//        Point3d point = new Point3d();
//        Lines line = new Lines();
//        Planes plane = new Planes();
//        List<string> RAW = new List<string>();
//        List<string> FILTER = new List<string>();
//        Viewport2DVisual3D vp = new Viewport2DVisual3D();
//        Point3DCollection p3dCol = new Point3DCollection();
//        Point3DConverter p3dConv = new Point3DConverter();

//        Visual3DCollection p3dcoll;
//        OpenFileDialog ofd = new OpenFileDialog();
//        /// <summary>
//        public _3dViewPort()
//        {
           

//            InitializeComponent();
           
//            FILTER.Add("<LINE");
//            FILTER.Add("<POLYGON");
//            FILTER.Add("<POINT");
//            FILTER.Add("<FACES>");
//            FILTER.Add("<LINES>");
//            FILTER.Add("<POINTS>");
//           // this.DataContext = this.Model1(); 
//            // GoDoIt();
//          PolygonBuilder();
//         //   Model1();

//        }

//        public void Model1()
//        {
//            var modelGroup = new Model3DGroup();

//            // Create a mesh builder and add a box to it
//            var meshBuilder = new MeshBuilder(false, false);
//            meshBuilder.AddBox(new Point3D(0, 0, 1), 1, 2, 0.5);
//            meshBuilder.AddBox(new Rect3D(0, 0, 1.2, 0.5, 1, 0.4));

//            // Create a mesh from the builder (and freeze it)
//            var mesh = meshBuilder.ToMesh(true);

//            // Create some materials
//            var greenMaterial = MaterialHelper.CreateMaterial(Colors.Green);
//            var redMaterial = MaterialHelper.CreateMaterial(Colors.Red);
//            var blueMaterial = MaterialHelper.CreateMaterial(Colors.Blue);
//            var insideMaterial = MaterialHelper.CreateMaterial(Colors.Yellow);

//            // Add 3 models to the group (using the same mesh, that's why we had to freeze it)
//            modelGroup.Children.Add(new GeometryModel3D
//            {
//                Geometry = mesh,
//                Material = greenMaterial,
//                BackMaterial = insideMaterial
//            });
//            modelGroup.Children.Add(new GeometryModel3D
//            {
//                Geometry = mesh,
//                Transform = new TranslateTransform3D(-2, 0, 0),
//                Material = redMaterial,
//                BackMaterial = insideMaterial
//            });
//            modelGroup.Children.Add(new GeometryModel3D { Geometry = mesh, Transform = new TranslateTransform3D(2, 0, 0), Material = blueMaterial, BackMaterial = insideMaterial });

//            // Set the property, which will be bound to the Content property of the ModelVisual3D (see MainWindow.xaml)
//            Model = modelGroup;
//        }

//        /// <summary>
//        /// Gets or sets the model.
//        /// </summary>
//        /// <value>The model.</value>
//        public Model3D Model { get; set; }



//        public void RemoveButton_Click(object sender, RoutedEventArgs e)
//        {


//            MeshGeometry3D meshMain = new MeshGeometry3D();
//            Vector3DCollection mynorms = new Vector3DCollection();
//            mynorms.Add(new Vector3D(0, 0, 1));
//            mynorms.Add(new Vector3D(0, 0, 1));
//            mynorms.Add(new Vector3D(0, 0, 1));
//            mynorms.Add(new Vector3D(0, 0, 1));
//            mynorms.Add(new Vector3D(0, 0, 1));
//            mynorms.Add(new Vector3D(0, 0, 1));
//            meshMain.Normals = mynorms;
//            meshMain.Positions = p3dCol;
//            PointCollection mytextcoord = new PointCollection();
//            mytextcoord.Add(new Point(0, 0));
//            mytextcoord.Add(new Point(1, 0));
//            mytextcoord.Add(new Point(1, 1));
//            mytextcoord.Add(new Point(1, 0));
//            mytextcoord.Add(new Point(0, 1));
//            mytextcoord.Add(new Point(0, 0));
//            meshMain.TextureCoordinates = mytextcoord;
//            Int32Collection myTriangleInd = new Int32Collection();
//            myTriangleInd.Add(0);
//            myTriangleInd.Add(1);
//            myTriangleInd.Add(2);
//            myTriangleInd.Add(3);
//            myTriangleInd.Add(4);
//            myTriangleInd.Add(5);
//            meshMain.TriangleIndices = myTriangleInd;
//            GeometryModel3D mygeomod = new GeometryModel3D();
//            mygeomod.Geometry = meshMain;




//            LinearGradientBrush myHorgrad = new LinearGradientBrush();
//            myHorgrad.StartPoint = new Point(0, 0.5);
//            myHorgrad.EndPoint = new Point(1, 0.5);
//            myHorgrad.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
//            myHorgrad.GradientStops.Add(new GradientStop(Colors.Red, 0.25));
//            myHorgrad.GradientStops.Add(new GradientStop(Colors.Blue, 0.75));
//            myHorgrad.GradientStops.Add(new GradientStop(Colors.LimeGreen, 1.0));








//            DiffuseMaterial mymat = new DiffuseMaterial(myHorgrad);

//            mygeomod.Material = mymat;

//            Model3DGroup mygroup3d = new Model3DGroup();
//            ModelVisual3D modvis3d = new ModelVisual3D();
//            mygroup3d.Children.Add(mygeomod);
//            modvis3d.Content = mygroup3d;
//            viewport3d.Children.Add(modvis3d);
//            ModelVisual3D mv = new ModelVisual3D();
//            HelixToolkit.Wpf.PointsVisual3D pvd = new PointsVisual3D();
//         //   pvd.Children.Add(new PointsVisual3D { Points = p3dCol });
//           // this.Content = viewport3d;

//        }

//        public void OpenSave_Click(object sender, RoutedEventArgs e)
//        {
//         //   var result = ofd.ShowDialog();
//           // if ((bool)result)

//               // GoDoIt();
//        }

//        public void ParseBtn_Click(object sender, RoutedEventArgs e)
//        {

//            PolygonBuilder();
//        }

//        public void GoDoIt()
//        {
//            lines.Clear();
//            points.Clear();
//            planes.Clear();

//            StringBuilder output = new StringBuilder();
//            try
//            {
//                //ofd.FileName;
//                using (StreamReader st = new StreamReader(ofd.FileName))

//                {
//                    string line;
//                    while ((line = st.ReadLine()) != null)
//                    {
//                        RAW.Add(line);
//                        MessageBox.Show(st.ToString());
//                        ALLTEXT = st.ReadToEnd();
                       

//                    }
//                }
//            }

//            catch (Exception ex)
//            {
//                MessageBox.Show("File Couldn't be read! " + ex.Message);

//            }
//            //string fe = "";
//            String xmlString = ALLTEXT;
//            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
//            {


//            }
//            KeyValueModel kvm = new KeyValueModel();

//            kvm.GetTagTextBlockText(ALLTEXT, "id", "<LINES>");
//            LINES = ALLTEXT.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList().Where(g => g.Contains(FILTER.ElementAt(0).ToString())).ToList();
//            kvm.GetTagTextBlockText(ALLTEXT, "id", "<FACES>");
//            POLYGONS = ALLTEXT.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList().Where(g => g.Contains(FILTER.ElementAt(1).ToString())).ToList();
//            foreach (string s in LINES.Where(s => s.Contains(',')))
//            {
//                string w = kvm.GetParamValue(s, "id", null);
//                //w = w.Remove(0, 1);
//                string v = kvm.GetParamValue(s, "path", null);

//                string u = v.Remove(v.IndexOf(','));
//                v = v.Remove(0, v.IndexOf(','));

//                if (u.Contains(','))
//                    u = u.Replace(',', ' ');
//                if (u.Contains('\"'))
//                    u = u.Replace('\"', ' ');
//                u = u.Trim();
//                if (v.Contains(','))
//                    v = v.Replace(',', ' ');
//                if (v.Contains('\"'))
//                    v = v.Replace('\"', ' ');
//                v = v.Trim();

//                string t = kvm.GetParamValue(s, "type", null);
//                if (t.Contains('\"'))
//                    t = t.Remove(t.IndexOf('\"'));
//                Lines l = new Lines();
//                l.LineID = w;

//                l.StartingPointID = u;
//                l.EndingPointID = v;
//                l.Type = t;
//                lines.Add(l);
//            }
//            LineList.ItemsSource = lines;
//            KeyValueModel kvm1 = new KeyValueModel();
//            kvm1.GetTagTextBlockText(ALLTEXT, "id", "<POINTS>"); ;
//            POINTS = ALLTEXT.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList().Where(g => g.Contains(FILTER.ElementAt(2).ToString())).ToList();

//            foreach (string b in POINTS.Where(b => b.Contains(',')))
//            {
//                MRNUIElements.Models.Structure.Point3d le = new Models.Structure.Point3d();
//                string w1 = kvm.GetParamValue(b, "id", null);
//                le.PointID = w1;
//                string v1 = kvm.GetParamValue(b, "data", null);
//                char[] a = ",".ToCharArray();


//                List<string> r = new List<string>();
//                r = v1.Split(a, StringSplitOptions.RemoveEmptyEntries).ToList();
//                le.X = decimal.Parse(r[0]);
//                le.Y = decimal.Parse(r[1]);
//                le.Z = decimal.Parse(r[2]);
//                p3dCol.Add(new Point3D((double)le.X, (double)le.Y, (double)le.Z));
//                points.Add(le);
//                //p3dConv.ConvertFrom((Point3d))

//            }
           

//            foreach (string b in POLYGONS.Where(b => b.Contains(',')))
//            {
//                MRNUIElements.Models.Structure.Planes le = new Models.Structure.Planes();
//                string w1 = kvm.GetParamValue(b, "id", null);
//                string v2 = kvm.GetParamValue(b, "orientation", null);
//                string v1 = kvm.GetParamValue(b, "path", null);
//                char[] a = ",".ToCharArray();

//                List<string> linegroup = new List<string>();
//                List<string> r = new List<string>();
//                //   int groupID = 0;
//                int i = 0;
//                string tempPID = "";
//                r = v1.Split(a, StringSplitOptions.RemoveEmptyEntries).ToList();
//                foreach (string s in r)
//                {
//                    le.PlaneID = w1;
//                    le.Lines = r[i].ToString();


//                    le.Orientation = v2;
//                    planes.Add(le);
//                    i++;
//                }

//            }
          
//            System.Windows.Forms.MessageBox.Show(planes.Count.ToString() + " Planes consisting of " + lines.Count.ToString() + " lines added to the structure Consisting of " + points.Count.ToString() + " points.");
//            //PolygonBuilder();
//        }
//        public void PolygonBuilder()
//        {





//            var modelGroup = new Model3DGroup();

//            // Create a mesh builder and add a box to it
//            var meshBuilder = new MeshBuilder(false, false);

//            bool firsttime = true;
//            int i = 1; string v = "";
//            foreach (Planes y in planes)
//            {
//                Point3DCollection pt3D = new Point3DCollection();
//                v = "P" + i.ToString();
//                firsttime = true;
//                Point3D first = new Point3D(0, 0, 0);
//                Point3D last = new Point3D(0, 0, 0);
//                Point3D thispoint = new Point3D(0, 0, 0);
//                Polygon3D poly = new Polygon3D();
//                int j = 0;
//                foreach (Planes x in planes.Where(z => z.PlaneID == v))
//                {



//                    string t = lines[j].StartingPointID;
//                    string u = lines[j].EndingPointID;
//                    j++;



//                    if (firsttime)
//                    {
//                        firsttime = false;
//                        first = new Point3D((double)points.Single(b => b.PointID == t).X, (double)points.Single(b => b.PointID == t).Y, (double)points.Single(b => b.PointID == t).Z);
//                        pt3D.Add(new Point3D((double)points.Single(b => b.PointID == t).X, (double)points.Single(b => b.PointID == t).Y, (double)points.Single(b => b.PointID == t).Z));

//                        pt3D.Add(new Point3D((double)points.Single(b => b.PointID == u).X, (double)points.Single(b => b.PointID == u).Y, (double)points.Single(b => b.PointID == u).Z));
//                        //   last = new Point3D((double)points.Single(b => b.PointID == u).X, (double)points.Single(b => b.PointID == u).Y, (double)points.Single(b => b.PointID == u).Z);

//                    }

//                    else
//                    {
//                        last = new Point3D((double)points.Single(b => b.PointID == u).X, (double)points.Single(b => b.PointID == u).Y, (double)points.Single(b => b.PointID == u).Z);
//                        if (last != first)
//                            pt3D.Add(new Point3D((double)points.Single(b => b.PointID == u).X, (double)points.Single(b => b.PointID == u).Y, (double)points.Single(b => b.PointID == u).Z));

//                    }
//                }
//                poly.Points = pt3D;//poly
//                                   //Materials.Orange;
//                                   //(pt3D,Materials.Orange)





//                meshBuilder.AddPolygon(poly.Points);  //new Point3D(0, 0, 1), 1, 2, 0.5);
//               // meshBuilder.AddBox(new Rect3D(0, 0, 1.2, 0.5, 1, 0.4));

//                // Create a mesh from the builder (and freeze it)
                


//                i++;



//            }

//           var mesh = meshBuilder.ToMesh(true);
          

//            // Create some materials
//            var greenMaterial = MaterialHelper.CreateMaterial(Colors.Green);
//            var redMaterial = MaterialHelper.CreateMaterial(Colors.Red);
//            var blueMaterial = MaterialHelper.CreateMaterial(Colors.Blue);
//            var insideMaterial = MaterialHelper.CreateMaterial(Colors.Yellow);

//            // Add 3 models to the group (using the same mesh, that's why we had to freeze it)
//            modelGroup.Children.Add(new GeometryModel3D
//            {
//                Geometry = mesh,
//                Material = greenMaterial,
//                BackMaterial = insideMaterial
//            });
//            modelGroup.Children.Add(new GeometryModel3D
//            {
//                Geometry = mesh,
//                Transform = new TranslateTransform3D(-2, 0, 0),
//                Material = redMaterial,
//                BackMaterial = insideMaterial
//            });
//            modelGroup.Children.Add(new GeometryModel3D { Geometry = mesh, Transform = new TranslateTransform3D(2, 0, 0), Material = blueMaterial, BackMaterial = insideMaterial });

//            // Set the property, which will be bound to the Content property of the ModelVisual3D (see MainWindow.xaml)
//            Model = modelGroup;


//        }
//        private void LineList_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {
//            if (LineList.HasItems)
//            {
//                Line l = new Line();



//                string t = lines[LineList.SelectedIndex].StartingPointID;
//                string u = lines[LineList.SelectedIndex].EndingPointID;



//                //      points.Single(b => b.PointID == t);

//                //      points.Single(b => b.PointID == u);
//               // double Centerx = canvas.ActualWidth / 2;
//               // double Centery = canvas.ActualHeight / 2;

//              //  l.X1 = (double)points.Single(b => b.PointID == t).X + Centerx * .5;
//             //   l.X2 = (double)points.Single(b => b.PointID == u).X + Centerx * .5;
//              //  l.Y1 = (double)points.Single(b => b.PointID == t).Y + Centery * .5;
//             //   l.Y2 = (double)points.Single(b => b.PointID == u).Y + Centery * .5;
//                l.Stroke = Brushes.Black;
//                l.StrokeThickness = 1;
//                l.Fill = Brushes.Black;
//               // canvas.Children.Add(l);

//                // if(Canvas1.Visibility==Visibility.Visible)
//                //  DrawingVisual dv = new DrawingVisual();

//                //  Canvas1.Children.Add(l);
//            }
//        }
//    }
//}