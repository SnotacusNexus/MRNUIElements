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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Controls.Primitives;
using MRNUIElements.Models;
using System.ComponentModel;
using MRNUIElements.TextParsing;


namespace MRNUIElements
{
    /// <summary>
    /// Interaction logic for DrawPlanePage.xaml
    /// </summary>
    public partial class DrawPlanePage : Page
    {

        

        int nextplane = 0;
        ObservableCollection<ModelPlane> planes = new ObservableCollection<ModelPlane>();
        public DrawPlanePage()
        {
           // ShapeCanvas1.Points = GetRoofPlaneShape(1);

            // ObservableCollection<ModelPlane> planes = new ObservableCollection<ModelPlane>();
            InitializeComponent();
            DrawPitch((double)Pitch.Value * -1, ((double)RunFeet.Value * 12));
            ShapeCanvas1.Points = GetRoofPlaneShape(1);
            ShapeCanvas1.FillRule = FillRule.EvenOdd;
            ShapeCanvas1.Fill = Brushes.Blue;
            ShapeCanvas1.Stretch = Stretch.Fill;
            ShapeCanvas2.Points = GetRoofPlaneShape(2);
            ShapeCanvas2.FillRule = FillRule.EvenOdd;
            ShapeCanvas2.Fill = Brushes.Red;
            ShapeCanvas2.Stretch = Stretch.Fill;
            ShapeCanvas3.Points = GetRoofPlaneShape(3);
            ShapeCanvas3.FillRule = FillRule.EvenOdd;
            ShapeCanvas3.Fill = Brushes.Green;
            ShapeCanvas3.Stretch = Stretch.Fill;
            ShapeCanvas4.Points = GetRoofPlaneShape(4);
            ShapeCanvas4.FillRule = FillRule.EvenOdd;
            ShapeCanvas4.Fill = Brushes.Yellow;
            ShapeCanvas4.Stretch = Stretch.Fill;
            ShapeCanvas5.Points = GetRoofPlaneShape(5);
            ShapeCanvas5.FillRule = FillRule.EvenOdd;
            ShapeCanvas5.Fill = Brushes.Brown;
            ShapeCanvas5.Stretch = Stretch.Fill;
            ShapeCanvas6.Points = GetRoofPlaneShape(6);
            ShapeCanvas6.FillRule = FillRule.EvenOdd;
            ShapeCanvas6.Fill = Brushes.White;
            ShapeCanvas6.Stretch = Stretch.Fill;
            ShapeCanvas7.Points = GetRoofPlaneShape(7);
            ShapeCanvas7.FillRule = FillRule.EvenOdd;
            ShapeCanvas7.Fill = Brushes.Purple;
            ShapeCanvas7.Stretch = Stretch.Fill;
            ShapeCanvas8.Points = GetRoofPlaneShape(8);
            ShapeCanvas8.FillRule = FillRule.EvenOdd;
            ShapeCanvas8.Fill = Brushes.Pink;
            ShapeCanvas8.Stretch = Stretch.Fill;
            ShapeCanvas9.Points = GetRoofPlaneShape(9);
            ShapeCanvas9.FillRule = FillRule.EvenOdd;
            ShapeCanvas9.Fill = Brushes.Gray;
            ShapeCanvas9.Stretch = Stretch.Fill;
            ShapeCanvas10.Points = GetRoofPlaneShape(10);
            ShapeCanvas10.FillRule = FillRule.EvenOdd;
            ShapeCanvas10.Fill = Brushes.PowderBlue;
            ShapeCanvas10.Stretch = Stretch.Fill;
            //   this.Content = this;
        }
        public void MakeRakeFromWallLength(
            int inches,
            out int ft,
            out int inch,
            int controlset = 0,
            int overhang = 0,
            int ftridgeoffset = 0,
            int otherpitch = 0)
        {

            ft = inch = 0;
            int othertemp = (int)inches - (ftridgeoffset * 12);
            if (inches > 0)
                if (ftridgeoffset == 0)
                    ft = Math.DivRem((int)inches + overhang, 12, out inch);

        }
        public void Calculate(bool bAdd)
        {
            ModelPlane mp = new ModelPlane();
            PlanesListBox.ItemsSource = planes;
            if (CheckBox.IsChecked == false)
            {
                RidgeInch.Value = (double)EaveInch.Value;
                RidgeFeet.Value = EaveFeet.Value;
            }
            double a = 0, b = 0, bi = 0;
            a = (double)Pitch.Value;
            b = (double)RunFeet.Value;
            bi = (double)RunInch.Value;
            double B = 0;
            double A = 0;
            double d = 0;
            B = (b * 12) + bi;
            if (a > 0)
                A = (a * (B / 12));
            int r = 0, s = 0;
            MakeRakeFromWallLength((int)Math.Sqrt((A * A) + (B * B)), out r, out s);
            RakeFeet.Value = r;
            RakeInch.Value = s;
            double TE = 0;
            double BE = 0;
            double LE = 0;
            int inch = 0;

            RiseFeet.Value = Math.DivRem((int)RunFeet.Value * (int)Pitch.Value, 12, out inch);
            TE = (((double)RidgeFeet.Value * 12) + (double)RidgeInch.Value);        //Top Edge

            if (EaveFeet.Value > 0)
                BE = (((double)EaveFeet.Value * 12) + (double)EaveInch.Value);    //Bottom Edge
            LE = (((double)RakeFeet.Value * 12) + (double)RakeInch.Value);      //Left Edge
            RiseInch.Value = inch;
            //Right Edge
            d = (((TE + BE) * LE) / 2);

            int di = 0;
            if (d > 0)
            {

                SQFeet.Value = Math.DivRem((int)d, 144, out di);
                Squares.Value = SQFeet.Value / 100;
            }
            if (bAdd)
            {

                mp.PlaneID = nextplane;
                mp.RidgeFeet = (int)RidgeFeet.Value;
                mp.RidgeInch = (int)RidgeInch.Value;
                mp.EaveFeet = (int)EaveFeet.Value;
                mp.EaveInch = (int)EaveInch.Value;
                mp.RiseInch = (int)RiseInch.Value;
                mp.RiseFeet = (int)RiseFeet.Value;
                mp.RakeInch = (int)RakeInch.Value;
                mp.RakeFeet = (int)RakeFeet.Value;
                mp.RunFeet = (int)RunFeet.Value;
                mp.RunInch = (int)RunInch.Value;
                mp.Pitch = (int)Pitch.Value;
                mp.Sqft = double.Parse(SQFeet.Value.ToString());
                mp.Squares = double.Parse(Squares.Value.ToString());
                planes.Add(mp);
            }
            double newtotalSquares = 0;
            foreach (ModelPlane pm in planes)
            {
                newtotalSquares += pm.Sqft;
            }
            Squares.Value = newtotalSquares;
        }

        public void DrawPitch(double Pitch, double? Run, bool bAdd = false)
        {

            ScaleTransform st = new ScaleTransform();
            st.ScaleY = Pitch * .08;
            RoofPitch.RenderTransform = st;

            Calculate(bAdd);


        }


        private void RunFeet_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((double)Pitch.Value < 0) Pitch.Value = 0;
            if ((double)RunFeet.Value < 0) RunFeet.Value = 0;
            DrawPitch((double)Pitch.Value, ((double)RunFeet.Value * 12 + RunInch.Value));
        }

        private void RunInch_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            if ((double)Pitch.Value <= 0) Pitch.Value = 1;
            if ((double)RunInch.Value < 0)
            {
                RunInch.Value = 11; RunFeet.Value--;
            }
            if ((double)RunInch.Value > 11)
            {
                RunInch.Value = 0; RunFeet.Value++;
            }
            DrawPitch((double)Pitch.Value, ((double)RunFeet.Value * 12 + RunInch.Value));
        }

        private void RakeInch_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScaleTransform st = new ScaleTransform();
            st.ScaleX = (((double)EaveFeet.Value * 12) + (double)EaveInch.Value) / 120;
            st.ScaleY = (((double)RakeFeet.Value * 12) + (double)RakeInch.Value) / 120;
            PlaneShape.RenderTransform = st;

        }

        private void RakeFeet_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScaleTransform st = new ScaleTransform();
            st.ScaleX = (((double)EaveFeet.Value * 12) + (double)EaveInch.Value) / 120;
            st.ScaleY = (((double)RakeFeet.Value * 12) + (double)RakeInch.Value) / 120;
            PlaneShape.RenderTransform = st;

            //Calculate(bAdd);

        }

        private void Pitch_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            if ((double)Pitch.Value <= 0) Pitch.Value = 1;
            if ((double)RunFeet.Value < 0) RunFeet.Value = 0;
            DrawPitch((double)Pitch.Value, ((double)RunFeet.Value * 12));

        }




        private void RidgeFeet_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScaleTransform st = new ScaleTransform();
            st.ScaleX = (((double)EaveFeet.Value * 12) + (double)EaveInch.Value) / 120;
            st.ScaleY = (((double)RakeFeet.Value * 12) + (double)RakeInch.Value) / 120;
            PlaneShape.RenderTransform = st;


            if ((double)Pitch.Value <= 0) Pitch.Value = 1;
            if ((double)RidgeFeet.Value < 0) RidgeFeet.Value = 0;

            DrawPitch((double)Pitch.Value, ((double)RunFeet.Value * 12 + RunInch.Value));
            //double a = 0;
            //double b = ((double)RakeFeet.Value * 12) + (double)RakeInch.Value;
            //double c = ((double)RidgeFeet.Value * 12) + (double)RidgeInch.Value;
            //double di = ((double)EaveFeet.Value * 12) + (double)EaveInch.Value;
            //double ei = 72;//vOffset
            //double f = 72;//hTOffset
            //double g = 72;//hLOffset
            //double h = 72;//hROffset

            //PlaneShape.Points.Add(new Point(a, a));
            //PlaneShape.Points.Add(new Point(a, b));
            //PlaneShape.Points.Add(new Point(di, b));
            //PlaneShape.Points.Add(new Point(c, a));
        }

        private void RidgeInch_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScaleTransform st = new ScaleTransform();
            st.ScaleX = (((double)EaveFeet.Value * 12) + (double)EaveInch.Value) / 120;
            st.ScaleY = (((double)RakeFeet.Value * 12) + (double)RakeInch.Value) / 120;
            PlaneShape.RenderTransform = st;

            if ((double)Pitch.Value <= 0) Pitch.Value = 1;
            if ((double)RidgeInch.Value < 0)
            {
                RidgeInch.Value = 11; RidgeFeet.Value--;
            }
            if ((double)RidgeInch.Value > 11)
            {
                RidgeInch.Value = 0; RidgeFeet.Value++;
            }
            DrawPitch((double)Pitch.Value, ((double)RunFeet.Value * 12 + RunInch.Value));
            //double a = 0;
            //double b = ((double)RakeFeet.Value * 12) + (double)RakeInch.Value;
            //double c = ((double)RidgeFeet.Value * 12) + (double)RidgeInch.Value;
            //double di = ((double)EaveFeet.Value * 12) + (double)EaveInch.Value;
            //double ei = 72;//vOffset
            //double f = 72;//hTOffset
            //double g = 72;//hLOffset
            //double h = 72;//hROffset

            //PlaneShape.Points.Add(new Point(a, a));
            //PlaneShape.Points.Add(new Point(a, b));
            //PlaneShape.Points.Add(new Point(di, b));
            //PlaneShape.Points.Add(new Point(c, a));
        }

        private void EaveFeet_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScaleTransform st = new ScaleTransform();
            st.ScaleX = (((double)EaveFeet.Value * 12) + (double)EaveInch.Value) / 120;
            st.ScaleY = (((double)RakeFeet.Value * 12) + (double)RakeInch.Value) / 120;
            PlaneShape.RenderTransform = st;
            if ((double)Pitch.Value <= 0) Pitch.Value = 1;
            if ((double)EaveFeet.Value < 0) EaveFeet.Value = 0;
            DrawPitch((double)Pitch.Value, ((double)RunFeet.Value * 12 + RunInch.Value)); double a = 0;
            //double b = ((double)RakeFeet.Value * 12) + (double)RakeInch.Value;
            //double c = ((double)RidgeFeet.Value * 12) + (double)RidgeInch.Value;
            //double di = ((double)EaveFeet.Value * 12) + (double)EaveInch.Value;
            //double ei = 72;//vOffset
            //double f = 72;//hTOffset
            //double g = 72;//hLOffset
            //double h = 72;//hROffset

            //PlaneShape.Points.Add(new Point(a, a));
            //PlaneShape.Points.Add(new Point(a, b));
            //PlaneShape.Points.Add(new Point(di, b));
            //PlaneShape.Points.Add(new Point(c, a));
        }

        private void EaveInch_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScaleTransform st = new ScaleTransform();
            st.ScaleX = (((double)EaveFeet.Value*12)+(double)EaveInch.Value)/120 ;
            st.ScaleY = (((double)RakeFeet.Value*12)+(double)RakeInch.Value)/120;
            PlaneShape.RenderTransform = st;
            if ((double)Pitch.Value <= 0) Pitch.Value = 1;
            if ((double)EaveInch.Value < 0)
            {
                EaveInch.Value = 11; EaveFeet.Value--;
            }
            if ((double)EaveInch.Value > 11)
            {
                EaveInch.Value = 0; EaveFeet.Value++;
            }
            DrawPitch((double)Pitch.Value, ((double)RunFeet.Value * 12 + RunInch.Value));
            //double a = 0;
            //double b = ((double)RakeFeet.Value * 12) + (double)RakeInch.Value;
            //double c = ((double)RidgeFeet.Value * 12) + (double)RidgeInch.Value;
            //double di = ((double)EaveFeet.Value * 12) + (double)EaveInch.Value;
            //double ei = 72;//vOffset
            //double f = 72;//hTOffset
            //double g = 72;//hLOffset
            //double h = 72;//hROffset

            //PlaneShape.Points.Add(new Point(a, a));
            //PlaneShape.Points.Add(new Point(a, b));
            //PlaneShape.Points.Add(new Point(di, b));
            //PlaneShape.Points.Add(new Point(c, a));
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
           
           
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            nextplane++;
            Calculate(true);
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(planes.Count>0)
            planes.RemoveAt(PlanesListBox.SelectedIndex);
            Calculate(false);
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            nextplane = 0;
            planes.Clear();
            Calculate(false);
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            Login Page = new Login();
            this.NavigationService.Navigate(Page);
        }
        public PointCollection GetRoofPlaneShape(int PlaneShapeID)
        {
             double a = 0;
            double b = 100;
            double c = 25;
            double d = 50;
            double e = 75;
            PointCollection Rhomboid = new PointCollection();
            Rhomboid.Add(new Point(a, a));
            Rhomboid.Add(new Point(a, b));
            Rhomboid.Add(new Point(c,b ));
            Rhomboid.Add(new Point(d, d));
            Rhomboid.Add(new Point(e, b));
            Rhomboid.Add(new Point(b, b));
            Rhomboid.Add(new Point(b, a));
            PointCollection LeftLean = new PointCollection();
            LeftLean.Add(new Point(a, a));
            LeftLean.Add(new Point(a, b));
            LeftLean.Add(new Point(b, b));
            LeftLean.Add(new Point(b, a));

            PointCollection RightLean = new PointCollection();
            RightLean.Add(new Point(c, a));
            RightLean.Add(new Point(a,b));
            RightLean.Add(new Point(e, b));
            RightLean.Add(new Point(b,a));
            PointCollection Triangle = new PointCollection();
            Triangle.Add(new Point(d,a));
            Triangle.Add(new Point(a, b));
            Triangle.Add(new Point(b, b));
            PointCollection Rectangle = new PointCollection();
            Rectangle.Add(new Point(c, a));
            Rectangle.Add(new Point(a, b));
            Rectangle.Add(new Point(b, b));
            Rectangle.Add(new Point(e, a));

            PointCollection UpSideLeft = new PointCollection();
            UpSideLeft.Add(new Point(a, a));
            UpSideLeft.Add(new Point(a, b));
            UpSideLeft.Add(new Point(e, b));
            UpSideLeft.Add(new Point(b, d));
            UpSideLeft.Add(new Point(b, a));
            PointCollection UpSideRight = new PointCollection();
            UpSideRight.Add(new Point(e, a));
            UpSideRight.Add(new Point(a, a));
            UpSideRight.Add(new Point(a, b));
            UpSideRight.Add(new Point(b, b));
            UpSideRight.Add(new Point(b,c));
            PointCollection UpSideLeftChop = new PointCollection();
            UpSideLeftChop.Add(new Point(a, a));
            UpSideLeftChop.Add(new Point(a, b));
            UpSideLeftChop.Add(new Point(c, b));
            UpSideLeftChop.Add(new Point(d, d));
            UpSideLeftChop.Add(new Point(b, d));
            UpSideLeftChop.Add(new Point(b, a));
            //UpSideLeftChop.Add(new Point(a, a));

            PointCollection UpSideRightChop = new PointCollection();
            UpSideRightChop.Add(new Point(a, a));
            UpSideRightChop.Add(new Point(b, a));
            UpSideRightChop.Add(new Point(b, d));
            UpSideRightChop.Add(new Point(c,d));
            UpSideRightChop.Add(new Point(c, b));
            UpSideRightChop.Add(new Point(a, b));
            //UpSideRightChop.Add(new Point(a, a));
            PointCollection Paralellogram = new PointCollection();
            Paralellogram.Add(new Point(c, a));
            Paralellogram.Add(new Point(c, b));
            Paralellogram.Add(new Point(e, b));
            Paralellogram.Add(new Point(e, a));
     


            switch (PlaneShapeID)
            {
                case 1:
                    return Rhomboid;
                case 2:
                    return LeftLean;
                case 3:
                    return RightLean;
                case 4:
                    return Triangle;
                case 5:
                    return Rectangle;
                case 6:
                    return UpSideLeft;
                case 7:
                    return UpSideRight;
                case 8:
                    return UpSideLeftChop;
                case 9:
                    return UpSideRightChop;
                case 10:
                    return Paralellogram;
                default:
                    return Rectangle;
            }

        }
        public class ElementCollection<T> : ObservableCollection<T>
        {
            public void UpdateCollection()
            {
                OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
            }
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            PlaneShape.Points = ShapeCanvas1.Points;
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            PlaneShape.Points = ShapeCanvas7.Points;
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            PlaneShape.Points = ShapeCanvas2.Points;
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            PlaneShape.Points = ShapeCanvas8.Points;
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            PlaneShape.Points = ShapeCanvas3.Points;
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            PlaneShape.Points = ShapeCanvas9.Points;
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            PlaneShape.Points = ShapeCanvas4.Points;
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            PlaneShape.Points = ShapeCanvas10.Points;
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            PlaneShape.Points = ShapeCanvas5.Points;
        }

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            PlaneShape.Points = ShapeCanvas6.Points;
        }
            #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string Points)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(Points));
            }
        }

        #endregion

        private void OK_Btn(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            ParseXML px = new ParseXML();
            px.DoIT();
            GetText gt = new GetText();
            gt.Sorting();
        }
    }
}

namespace MRNUIElements.Models
{
    public class ModelPlane
    {
        public int PlaneID { get; set; }
        public int Pitch { get; set; }
        public double Squares { get; set; }
        public int RidgeFeet { get; set; }
        public int RidgeInch { get; set; }
        public int EaveFeet { get; set; }
        public int EaveInch { get; set; }
        public int RakeFeet { get; set; }
        public int RakeInch { get; set; }
        public int RiseFeet { get; set; }
        public int RiseInch { get; set; }
        public double Sqft { get; set; }
        public int RunFeet { get; set; }
        public int RunInch { get; set; }
        public int ShapeID { get; set; }
        // public List<ShapeSegments> ShapeShape { get; set; }

    }

    public class ShapeSegments
    {
        public int ShapeID { get; set; }
        public string ShapeName { get; set; }
        public int NumberOfSegments { get; set; }
        public int SegmentID { get; set; }
        public bool IsEndpoint { get; set; }
        public bool IsStartEndpoint { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public double Value { get; set; }
        public int ParentConnectionID { get; set; }
        public int ChildConnectionID { get; set; }
        public int ConnectingShapeID { get; set; }  //shapeID where Value and SegmentType are equal
        public int ConnectingSegmentID { get; set; }
    }





}

