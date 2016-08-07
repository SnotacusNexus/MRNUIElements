using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Xml;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using MRNNexus_Model;
using MRNUIElements.Controllers;
using MRNUIElements.Planes;
using MRNUIElements.RoofOrder;
using HelixToolkit.Wpf.Input;
using HelixToolkit.Wpf.SharpDX;
using HelixToolkit.Wpf;
using HelixToolkit;
using System.IO;






namespace MRNUIElements.Models
{
    public class Vector3
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Vector3(int X, int Y, int Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }
}
namespace MRNUIElements.TextParsing
{
    public class PGLines
    {

        public int PolygonID { get; set; }
        public int LineID { get; set; }
        public string FaceType { get; set; }
        public float unroundedsize { get; set; }
        public int pitch { get; set; }
        public double orientation { get; set; }

    }
    public class LineEndPoints
    {
        public int StartPointID { get; set; }
        public int EndingPointID { get; set; }
        public int LineID { get; set; }
        public string LineTypeID { get; set; }


    }

    public class EndPoints
    {
        public int PointID { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }




    public class ParseXML
    {

        static ObservableCollection<PGLines> polygons = new ObservableCollection<PGLines>();
        static ObservableCollection<LineEndPoints> lines = new ObservableCollection<LineEndPoints>();
        static ObservableCollection<EndPoints> points = new ObservableCollection<EndPoints>();
        static string textblock = "";
        public string ALLTEXT = "";
        string Address = "";
        string Zip = "";
        PGLines pgs = new PGLines();
        LineEndPoints lep = new LineEndPoints();
        EndPoints epts = new EndPoints();







        public ParseXML()
        { }
        public void DoIT()
        {

            LetsGo();
            StringBuilder output = new StringBuilder();
            try
            {
                //ofd.FileName;
                using (StreamReader st = new StreamReader("15343758.xml"))

                {
                    string line;
                    while ((line = st.ReadLine()) != null)
                    {
                        MessageBox.Show(st.ToString());
                        ALLTEXT = st.ReadToEnd();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("File Couldn't be read! " + ex.Message);

            }
            string e = "";
            String xmlString = ALLTEXT;
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {


            }
        }
        public void LetsGo()
        {
            try
            {
                StreamWriter str = new StreamWriter("newFile.xml");
                
              
                XDocument doc = XDocument.Load("newxmlfile.xml");
                
                
               using(XmlWriter writer = XmlWriter.Create("FuckingStupidGord.xml"))
                {
                    doc.ToString();
                    writer.ToString();
                    doc.Save("newxmlfile.xml");
                    writer.Dispose();
                }
       
            

                var data = from item in doc.Descendants("EAGLEVIEW_EXPORT")
               
                       select new{
                           PolygonID = item.Element("id").Value,
                           ori = item.Element("orientatiion").Value,
                           LineIDs = item.Element("path").Value,
                           pitch = item.Element("pitch").Value,
                           unroundedsize = item.Element("unroundedsize").Value
                       };
                       
              
                foreach (var p in data)
                {

                    MessageBox.Show(p.PolygonID);
                    MessageBox.Show(p.pitch);
                    MessageBox.Show(p.ori);
                    MessageBox.Show(p.unroundedsize);


                    pgs.PolygonID =(int)StringCleaning(p.PolygonID.Remove(0, 1).ToString());
                    pgs.orientation = (double)StringCleaning(p.ori.ToString());
                    pgs.pitch = (int)StringCleaning(p.pitch.ToString());
                    pgs.unroundedsize = (float)StringCleaning(p.unroundedsize.ToString());

                    char[] dd = {  } ;
                  
                string[] sa = p.LineIDs.Split(dd,  StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach (string r in sa)
                {
                    pgs.LineID = (int)StringCleaning(r.Remove(0, 1).ToString());
                    polygons.Add(pgs);



                }




            }

            MessageBox.Show(data.ToString());

 }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
              //  throw;
            }

    }
        
    //          //  reader.ReadStartElement();
    //            reader.MoveToContent();
    //            if (reader.MoveToElement()) {

    //                reader.MoveToFirstAttribute();

    //                while (reader.Value != null)
    //                {
    //                    e += reader.Value;
    //                    if (!reader.MoveToNextAttribute()) ;
    //                    if (reader.MoveToElement() && !reader.IsEmptyElement) ;
    //                    output.Append(reader.ReadContentAsString());
    //                }

    //            }
              
    //           Address = reader.ReadAttributeValue().ToString();
    ////            Zip = reader.GetAttribute(4);

    //                reader.ReadToFollowing("<FACE");
    //         while(reader.ReadToFollowing("<POLYGON"))
    //           CollectData(reader.ReadElementContentAsString());


    //            reader.ReadToFollowing("book");
    //            reader.MoveToFirstAttribute();
    //            string genre = reader.Value;
    //            output.AppendLine("The genre value: " + genre);

    //            reader.ReadToFollowing("title");
    //            output.AppendLine("Content of the title element: " + reader.ReadElementContentAsString());
    //        }

    //        //  OutputTextBlock.Text = output.ToString();

        

        public object StringCleaning (string stringtoclean)
        {
            char[] loveSomeNumbers = "0123456789.-,".ToCharArray();

            stringtoclean.TakeWhile(b => char.IsNumber(b));
            
           return stringtoclean;
        }



        public void CollectData(string element)
        {
            string[] oreo = { } ;
            string ggg = "";
            string backup = element;
            char[] goodthings = "1234567890.-.,".ToCharArray();
            if (element.Contains("POLYGON"))
            {
                // this is a polygon element and we need to get our polygon object populate and send it to motherland
                char[] h = { '\"' };
                char[] k = { ',' };
                string[] utilitylist = element.Split(h, StringSplitOptions.RemoveEmptyEntries).ToArray();
                List<string> stringlist = utilitylist.ToList<string>();
                foreach(string s in stringlist) {
                    if (s.Contains('P'))
                        pgs.PolygonID = (int)StringCleaning(s);
                    if (s.Contains('L')) {
                        oreo.Initialize();
                        ggg = s.Substring(s.IndexOf("L"), (s.Length - s.LastIndexOf(" ")) + (s.LastIndexOf('L')) + 1).ToString();
                        oreo = ggg.Split(k);
                    }
                    if (s.Contains("\""))
                        pgs.pitch = (int)StringCleaning(s.Remove(0, s.IndexOf('\"')).ToString());
                    else pgs.pitch = (int)StringCleaning(s.ToString());

                    pgs.unroundedsize = (int)StringCleaning(s.ToString());
                    if (oreo.Count()>0)
                    foreach (string b in oreo)
                        {

                            pgs.LineID = (int)StringCleaning(b.Remove(0, 1).ToString());
                            polygons.Add(pgs);

                        }

                } 
              
            }
           




        }
    }
        

    
    public class GetText
    {
        static ObservableCollection<PGLines> polygons = new ObservableCollection<PGLines>();
        static ObservableCollection<LineEndPoints> lines = new ObservableCollection<LineEndPoints>();
        static ObservableCollection<EndPoints> points = new ObservableCollection<EndPoints>();
        static string textblock = "";
        double d = 0;

        static string LinesSection = "", FacesSection = "", PointsSection = "", ALLTEXT = "";


        public GetText()
        {

        }

        public void Sorting()
        {
            try
            {
                //ofd.FileName;
                using (StreamReader st = new StreamReader("15343758.xml"))

                {
                    string line;
                    while ((line = st.ReadLine()) != null)
                    {
                        MessageBox.Show(st.ToString());
                        ALLTEXT = st.ReadToEnd();
                    }
                }
            }

            catch (Exception e)
            {
                MessageBox.Show("File Couldn't be read! " + e.Message);

            }
            textblock = ALLTEXT;

            List<string> stringlist = new List<string>();
            char[] c = { ' ' };
            //   string r = textblock.Substring(textblock.IndexOf(startTag, startTag.Length), textblock.IndexOf(stringEndTag, 0)).ToString();
            string sLineType = "";
            string[] stringarray = textblock.Split(c, StringSplitOptions.RemoveEmptyEntries);
            stringlist = stringarray.ToList<string>();
            string sFaceType = "";
            int iPitch = 0;
            float funroundedsize = 0;
            string temphold = "";
            List<int> iList = new List<int>();
            List<int[]> pList = new List<int[]>();
            PGLines pgs = new PGLines();
            LineEndPoints lpts = new LineEndPoints();
            EndPoints epts = new EndPoints();
            int pgidt = 0;
            int lidt = 0;
            double dOrientation = 0;
            string g = "";
            foreach (string s in stringlist.Where(s => s.Contains("=")))
            {
                bool hero = false;
                bool villian = false;
                if (s.Contains("id="))
                {
                    if (s.Contains("P"))
                    {
                        g = s.Substring(s.IndexOf("P"), s.LastIndexOf("\"") - s.IndexOf("P"));
                        g = g.Remove(0, 1);
                        pgidt = pgs.PolygonID = int.Parse(g);

                    }
                    if (s.Contains("L"))
                    {
                        g = s.Substring(s.IndexOf("L"), s.LastIndexOf("\"") - s.IndexOf("L"));
                        g = g.Remove(0, 1);
                        lpts.LineID = pgs.LineID = int.Parse(g);
                        hero = true;
                    }
                    if (s.Contains("C"))
                    {
                        g = s.Substring(s.IndexOf("C"), s.LastIndexOf("\"") - s.IndexOf("C"));
                        g = g.Remove(0, 1);
                        epts.PointID = int.Parse(g);

                    }
                }

                if (s.Contains("orientation="))
                {
                    g = s.Substring(s.IndexOf("\""), s.LastIndexOf("\"") - s.IndexOf("\""));
                    g = g.Remove(0, 1);
                    dOrientation = 0;
                    double.TryParse(g, out d);
                }
                if (s.Contains("type=\""))
                {
                    if (!hero)
                    {
                        s.Remove(0, 1);
                        sFaceType = s.Substring(s.IndexOf("\""), s.LastIndexOf("\"") - s.IndexOf("\""));
                    }
                    else
                        sLineType = s.Substring(s.IndexOf("\""), s.LastIndexOf("\"") - s.IndexOf("\""));


                }

                if (s.Contains("data="))
                {
                    char[] a = { '\"', ',' };

                    string[] l = s.Split(a, StringSplitOptions.RemoveEmptyEntries);
                    List<string> b = new List<string>();
                    b = l.ToList<string>();
                    char[] gh = "1234567890.,".ToArray(); ;
                    char[] lh = "abcderghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\"/r/n\\".ToArray();
                    foreach (string st in b.Where(u => u.IndexOfAny(lh)>0))
                    {
                        char[] iu = st.ToCharArray();
                        //for (int gi =0; gi < iu.Count(); gi++)

                        string newset = iu.TakeWhile(j => char.IsNumber(j)).ToString();
                                   

                                    
                            
                        
                                                    
                            
                        epts.X = float.Parse(b[0].ToString());
                        epts.Y = float.Parse(b[1].ToString());
                        epts.Z = float.Parse(b[2].ToString());
                        points.Add(epts);
                    }

                }
                if (s.Contains("path="))
                {
                    char[] a = { '\"', ',' };

                    string[] l = s.Split(a, StringSplitOptions.RemoveEmptyEntries);
                    List<string> b = new List<string>();
                    b = l.ToList<string>();
                    foreach (string w in b.Where(e => e.Contains('L') || e.Contains('C')))
                    {
                        bool llll = true;
                        if (b.Contains("L"))
                            iList.Add(int.Parse(b.Remove("L").ToString()));
                        else if (b.Contains("C"))
                        {
                            int[] o = new int[2];
                            if (llll)
                            {
                                o[0] = int.Parse(b.Remove("C").ToString());
                                llll = false;
                            }
                            else
                            {
                                o[1] = int.Parse(b.Remove("C").ToString());
                                pList.Add(o);
                            }

                        }

                    }


                    if (s.Contains("pitch="))
                    {

                        g = s.Substring(s.IndexOf("\""), s.LastIndexOf("\"") - s.IndexOf("\""));
                        g = g.Remove(0, 1);
                        iPitch = int.Parse(g);




                    }
                    if (s.Contains("unroundedsize="))
                    {
                        g = s.Substring(s.IndexOf("\""), s.LastIndexOf("\"") - s.IndexOf("\""));
                        g = g.Remove(0, 1);
                        // g.Remove(0, 1);
                        funroundedsize = float.Parse(g);


                    }

                }

                foreach (int[] q in pList)
                {

                    lpts.LineTypeID = sLineType;
                    lpts.StartPointID = pList.ElementAt(0)[0];
                    lpts.EndingPointID = pList.ElementAt(0)[1];
                    pList.Clear();

                    lines.Add(lpts);

                }

                foreach (int i in iList)
                {
                    pgs.orientation = dOrientation;
                    pgs.PolygonID = pgidt;
                    pgs.LineID = lidt;
                    pgs.pitch = iPitch;
                    pgs.FaceType = sFaceType;
                    pgs.unroundedsize = funroundedsize;
                    pgs.LineID = i;
                    polygons.Add(pgs);
                }
                iList.Clear();

            }


        }


    }


}








//    class RoofPlanes
//    {
//        public List<Vector3> PointsList = new List<Vector3>();
//        public List<RoofPlaneTypes> ConnectionPointList = new List<RoofPlaneTypes>();

//        public void AddPlane(RoofPlaneTypes v, int RoofPlaneID, int Direction = 0)
//        {
            
            
//                ConnectionPointList.Add(v);
            
            
//        }

//        public Vector3[] GetPoints(int planeid)
//        {
//            Vector3[] v3a = new Vector3[10];
//            int i = 0;
//            foreach (var r in ConnectionPointList)
//            {
//                Vector3 v = new Vector3();
//                v.X= r.GetType().GetProperty("X").GetValue(typeof Vector3)                    
                    

//                }
//            }
//        }
//    }

//    class rprect : RoofPlaneTypes
//    {
//        RoofPlaneTypes rptl = new RoofPlaneTypes();
//        public Vector3 p1 = new Vector3(0,0,0);
//        public Vector3 p2 = new Vector3(0,10,0);
//        public Vector3 p3 = new Vector3(10,10,0);
//        public Vector3 p4 = new Vector3(10,0,0);
//        public Vector3 cp1;
//        public Vector3 cp2;


//        public void rprectadd(rprect rpr)
//        {
           
         
//            rptl.Add(rpr.p1);
//            rptl.Add(rpr.p2);
//            rptl.Add(rpr.p3);
//            rptl.Add(rpr.p4);
           
//    }
//        public RoofPlaneTypes GetrprectConnectionPoints(rprect rpr, int d = 0)
//        {
            
//            switch (d)
//            {
//                case 1:
//                    {
//                        cp1 = p2;
//                        cp2 = p3;
//                        break;
//                    }
//                case 2:
//                    {
//                        cp1 = p3;
//                        cp2 = p4;
//                        break;
//                    }
//                case 3:
//                    {
//                        cp1 = p4;
//                        cp2 = p1;
//                        break;
//                    }
//                default:
//                    {
//                        cp1 = p1;
//                        cp2 = p2;
//                        break;
//                    }
//            }
//            rptl.Add(cp1);
//            rptl.Add(cp2);
//            return rptl;
//        }
//    }

//    class rptri : RoofPlaneTypes
//    {
//        RoofPlaneTypes rptl = new RoofPlaneTypes();
//        public Vector3 p1 = new Vector3(5,0,0);
//        public Vector3 p2 = new Vector3(0,10,0);
//        public Vector3 p3 = new Vector3(10,10,0);
//        public Vector3 cp1;
//        public Vector3 cp2;
//        public void rprectadd(rprect rpr)
//        {

           
//            rptl.Add(rpr.p1);
//            rptl.Add(rpr.p2);
//            rptl.Add(rpr.p3);
           

//        }
//        public RoofPlaneTypes GetrprectConnectionPoints(rptri rpr, int d = 0)
//        {

//            switch (d)
//            {
//                case 1:
//                    {
//                        cp1 = p2;
//                        cp2 = p3;
//                        break;
//                    }
//                case 2:
//                    {
//                        cp1 = p3;
//                        cp2 = p1;
//                        break;
//                    }
//                default:
//                    {
//                        cp1 = p1;
//                        cp2 = p2;
//                        break;
//                    }
//            }
//            rptl.Add(cp1);
//            rptl.Add(cp2);
//            return rptl;
//        }
//    }
//    class rpPoly5 : RoofPlaneTypes
//    {
//        public Vector3 p1 = new Vector3(0,0,0);
//        public Vector3 p2 = new Vector3(0,10,0);
//        public Vector3 p3 = new Vector3(7.5,10,0);
//        public Vector3 p4 = new Vector3(10,7.5,0);
//        public Vector3 p5 = new Vector3(10,0,0);
//        public Vector3 cp1;
//        public Vector3 cp2;

//        public void Poly5add(rpPoly5 rpr)
//        {

//            RoofPlaneTypes rptl = new rpPoly5();
//            rptl.Add(rpr.p1);
//            rptl.Add(rpr.p2);
//            rptl.Add(rpr.p3);
//            rptl.Add(rpr.p4);
//            rptl.Add(rpr.p5);

//        }
//        public RoofPlaneTypes GetPoly5ConnectionPoints(rpPoly5 rpr, int d = 0)
//        {

//            switch (d)
//            {
//                case 1:
//                    {
//                        cp1 = p2;
//                        cp2 = p3;
//                        break;
//                    }
//                case 2:
//                    {
//                        cp1 = p3;
//                        cp2 = p4;
//                        break;
//                    }
//                case 3:
//                    {
//                        cp1 = p4;
//                        cp2 = p5;
//                        break;
//                    }
//                case 4:
//                    {
//                        cp1 = p5;
//                        cp2 = p1;
//                        break;
//                    }
//                default:
//                    {
//                        cp1 = p1;
//                        cp2 = p2;
//                        break;
//                    }
//            }

//            return new rpPoly5 { p1, p2, p3, p4, p5, cp1, cp2 };
//        }
//    }
//    class rpPoly6 : RoofPlaneTypes
//    {
//        public Vector3 p1 = new Vector3(0,0,0);
//        public Vector3 p2 = new Vector3(0,10,0);
//        public Vector3 p3 = new Vector3(5,10,0);
//        public Vector3 p4 = new Vector3(5,5,0);
//        public Vector3 p5 = new Vector3(10,5,0);
//        public Vector3 p6 = new Vector3(10,0,0);
//        public Vector3 cp1;
//        public Vector3 cp2;
//        public void Poly6add(rpPoly6 rpr)
//        {

//            RoofPlaneTypes rptl = new rpPoly6();
//            rptl.Add(rpr.p1);
//            rptl.Add(rpr.p2);
//            rptl.Add(rpr.p3);
//            rptl.Add(rpr.p4);
//            rptl.Add(rpr.p5);
//        }
//        public RoofPlaneTypes GetrprectConnectionPoints(rpPoly6 rpr, int d = 0)
//        {

//            switch (d)
//            {
//                case 1:
//                    {
//                        cp1 = p2;
//                        cp2 = p3;
//                        break;
//                    }
//                case 2:
//                    {
//                        cp1 = p3;
//                        cp2 = p4;
//                        break;
//                    }
//                case 3:
//                    {
//                        cp1 = p4;
//                        cp2 = p5;
//                        break;
//                    }
//                case 4:
//                    {
//                        cp1 = p5;
//                        cp2 = p6;
//                        break;
//                    }
//                case 5:
//                    {
//                        cp1 = p6;
//                        cp2 = p1;
//                        break;
//                    }
//                default:
//                    {
//                        cp1 = p1;
//                        cp2 = p2;
//                        break;
//                    }
//            }

//            return new rprect { p1, p2, p3, p4,p5,p6, cp1, cp2 };
//        }
//    }
//    class rpMorph : RoofPlaneTypes
//    {
//        Vector3 p1 = new Vector3(2.5,0,0);
//        Vector3 p2 = new Vector3(0,2.5,0);
//        Vector3 p3 = new Vector3(0,7.5,0);
//        Vector3 p4 = new Vector3(2.5,10,0);
//        Vector3 p5 = new Vector3(7.5,10,0);
//        Vector3 p6 = new Vector3(10,7.5,0);
//        Vector3 p7 = new Vector3(10,2.5,0);
//        Vector3 p8 = new Vector3(7.5,0,0);
//        Vector3 cp1;
//        Vector3 cp2;
//        public rpMorph(int d=0)
//        {
         
//           Add(p1);
//           Add(p2);
//           Add(p3);
//           Add(p4);
//           Add(p5);
//           Add(p6);
//           Add(p7);
//           Add(p8);
//           Add(GetrpMorphConnectionPoints(this, d)[8]);
//           Add(GetrpMorphConnectionPoints(this, d)[9]);
//        }
//        public void Add(rpMorph rpr, int d)
//        {
//            this.Add(this.p1)
           
//;        }
//        public Vector3[] GetrpMorphConnectionPoints(rpMorph rpr, int d = 0)
//        {

//            switch (d)
//            {
//                case 1:
//                    {
//                        cp1 = p2;
//                        cp2 = p3;
//                        break;
//                    }
//                case 2:
//                    {
//                        cp1 = p3;
//                        cp2 = p4;
//                        break;
//                    }
//                case 3:
//                    {
//                        cp1 = p4;
//                        cp2 = p5;
//                        break;
//                    }
//                case 4:
//                    {
//                        cp1 = p5;
//                        cp2 = p6;
//                        break;
//                    }
//                case 5:
//                    {
//                        cp1 = p6;
//                        cp2 = p7;
//                        break;
//                    }
//                case 6:
//                    {
//                        cp1 = p7;
//                        cp2 = p8;
//                        break;
//                    }
//                case 7:
//                    {
//                        cp1 = p8;
//                        cp2 = p1;
//                        break;
//                    }
               
//                default:
//                    {
//                        cp1 = p1;
//                        cp2 = p2;
//                        break;
//                    }
//            }
//            return new Vector3[] { p1,p2,p3,p4,p5,p6,p7,p8,cp1, cp2 };
//        }
//    }

//    class RoofPlaneTypes : List<Vector3>
//    {
        
//        public rprect RPRect = new rprect();
//        public rptri RPTri = new rptri(); 
//        public rpPoly5 RPPoly5 = new rpPoly5();
//        public rpPoly6 RPPoly6 = new rpPoly6();
//        public rpMorph RPMorph = new rpMorph();
        