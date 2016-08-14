using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Net;
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
using MRNUIElements.Models;
using Syncfusion.Windows.Shared;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
//using System.Drawing.Imaging;
//using System.Drawing.Drawing2D;
//using System.Drawing.Text;
using MRNUIElements.ImageManipulation;
using MRNNexus_Model;
using MRNUIElements.Controllers;
using System.Diagnostics;
using static Syncfusion.Windows.Gauge.DigitalGauge;
using Syncfusion.Windows.Gauge;

namespace MRNUIElements
{
	/// <summary>
	/// Interaction logic for CompetitionResultsDisplay.xaml
	/// </summary>
	public partial class CompetitionResultsDisplay : Page
	{

		public static Contestant C = Contestant.getInstance();
		public static ObservableCollection<Contestant> contestants = Contestant.cgetInstance();
		public ContestantScore Score { get; set; }

		public static List<string> SALESPERSON = new List<string>();
		System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
		public static List<Syncfusion.UI.Xaml.Gauges.SfDigitalGauge> displayControls = new List<Syncfusion.UI.Xaml.Gauges.SfDigitalGauge>();
		public static List<Syncfusion.UI.Xaml.Gauges.SfDigitalGauge> PlayerScore = new List<Syncfusion.UI.Xaml.Gauges.SfDigitalGauge>();
		int displaycounter = 0;

		public static ImageSource imgsrc = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\Snotacus\\Dropbox\\MRNUIElements\\MRNUIElements\\ResourceFiles\\RoofInspectionWizardBkgnd.png");

		bool okgo = false;


		public CompetitionResultsDisplay()
		{
			InitializeComponent();
			//	initializeTicker();
			C.PopulateDummyData();

			foreach (var item in contestants) // new ObservableCollection<string>() { "Item1", "Item2", "Item3", "Item4", "Item5", "Item6", "Item7", "Item8", "Item9" };
			{
				carousel.Items.Add(new CarouselItem() { Content = item.NamePlate });


				//Display Score Counter

			}
			DrawDisplay();

		}
		public void DrawDisplay()
		{

			ScoreBoardGraph.Children.Clear();
			TickDrawer();
			PopulateLeaderBoard();
			GetLeaderBoard();
		}

		void PopulateLeaderBoard()
		{
			displayControls.Add(_1stName);
			displayControls.Add(_2stName);
			displayControls.Add(_3stName);
			displayControls.Add(_4stName);
			displayControls.Add(_5stName);
			displayControls.Add(_6stName);
			displayControls.Add(_7stName);
			displayControls.Add(_8stName);
			displayControls.Add(_9stName);
			displayControls.Add(_10stName);
			displayControls.Add(_11stName);
			displayControls.Add(_12stName);
			PlayerScore.Add(_1st);
			PlayerScore.Add(_2st);
			PlayerScore.Add(_3st);
			PlayerScore.Add(_4st);
			PlayerScore.Add(_5st);
			PlayerScore.Add(_6st);
			PlayerScore.Add(_7st);
			PlayerScore.Add(_8st);
			PlayerScore.Add(_9st);
			PlayerScore.Add(_10st);
			PlayerScore.Add(_11st);
			PlayerScore.Add(_12st);


			this.DisplayController();
			//			

		}
		private void ChangeTimerStatus()
		{



			if (okgo)
			{
				dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
				dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);

				dispatcherTimer.Start();
			}
			else
			{
				dispatcherTimer.Stop();

			}
		}


		private void dispatcherTimer_Tick(object sender, EventArgs e)
		{
			GetLeaderBoard();
			if (displaycounter == 11)
			{
				dispatcherTimer.Stop();

			}
		}
		StringBuilder sb = new StringBuilder();

		//TODO  Scoreboard and PolePosition data display as well as jumbo Ticker data entry
		List<string> WordsForTheLedDisplays = new List<string>();
		public string TickerString { get; set; }

		//  void BuildTickerData(List<string> stringlist, int index=-1)
		//{
		//	if (stringlist.Count > -1 && stringlist != null)
		//		foreach (var item in stringlist)
		//			sb.Append("#" + item + "!");
		//	TickerString = sb.ToString();
		//}
		//void initializeTicker()
		//{
		//	for (int i = 0; i < BigTextBlock.Text.Length;i++)
		//		sb.Append("*");
		//	sb.Append("TESTING");
		//	for (int i = 0; i < BigTextBlock.Text.Length;i++)
		//		sb.Append("*");





		//	WordsForTheLedDisplays.Add("SYSTEM__");
		//	WordsForTheLedDisplays.Add("OVERLOAD");
		//	WordsForTheLedDisplays.Add("LOADING_");
		//	WordsForTheLedDisplays.Add("_TESTING");
		//	WordsForTheLedDisplays.Add("__CHECK_");
		//	WordsForTheLedDisplays.Add("ECHOECHO");
		//	WordsForTheLedDisplays.Add("KNOCK...");
		//	WordsForTheLedDisplays.Add("...KNOCK");
		//	WordsForTheLedDisplays.Add("ARE_YOU_");
		//	WordsForTheLedDisplays.Add("__THAT__");
		//	WordsForTheLedDisplays.Add("_MOTHER_");
		//	WordsForTheLedDisplays.Add("FUCKER!!");


		//	BuildTickerData(WordsForTheLedDisplays);






		//}

		public void DisplayController(bool? DisplayMode = null)
		{


			//if (DisplayMode == true)
			//	GetLeaderBoard();

			//else if (DisplayMode == false)
			//	for (int i = 0; i <=11; i++)

			//	{


			//			displayControls[displaycounter].Value = GetNextScoreboardMessage(i, false)[(int)Random(0, 11, 12)[0]];
			//		displaycounter++;
			//	}
			//else DisplayController(false);







			//UpdateDisplay(false);


		}

		List<string> GetNextScoreboardMessage(int i = -1, bool testing = false, bool scores = true, string injectedmessage = null)
		{
			//List<string> sl = new List<string>();

			//if (injectedmessage != null)
			//{
			//	sl.Add(injectedmessage);
			//	return sl;

			//}

			return WordsForTheLedDisplays;


		}

		//void UpdateDisplay(bool init=true)
		//{

		//	if (TickerString != null)
		//	{


		//		BigTextBlock.Text = tickertext(TickerString);

		//		//await Task.Delay(500);
		//	}
		//}

		//  string tickertext(string strin)
		//{
		//	//string str = TickerString.Length > BigTextBlock.Text.Length ? TickerString : BigTextBlock.Text;
		//	if (TickerString.Length > BigTextBlock.Text.Length)
		//		return TickerString.Substring(0, strin.Length - 1);
		//	else return strin;


		//}
		#region Depreciatedinthisfunction


		//public System.Windows.Controls.Image BuildGraphicLables(string s)
		//{

		//	var text = new FormattedText(
		//	s,
		//	CultureInfo.CurrentCulture,
		//	System.Windows.FlowDirection.LeftToRight,
		//	new Typeface(new System.Windows.Media.FontFamily("Georgia"),
		//	FontStyles.Normal,
		//	FontWeights.Bold,
		//	FontStretches.Expanded,
		//	new System.Windows.Media.FontFamily("Arial")),
		//	36d,
		//	System.Windows.Media.Brushes.Black,
		//	new System.Windows.Media.NumberSubstitution(NumberCultureSource.Override,
		//	CultureInfo.CurrentCulture,
		//	NumberSubstitutionMethod.AsCulture),
		//	System.Windows.Media.TextFormattingMode.Display);


		//	Rect rect = new Rect(new System.Windows.Size(text.Width, text.Height));
		//	// this nugget is necessary period to create a situation where no mods to the text are necessary to view on any pic background
		//	_textGeometry = text.BuildGeometry(new System.Windows.Point((rect.Width / 2) - (text.Width / 2), (rect.Height / 2) - (text.Height / 2)));
		//	// this nugget is unnecessary and probably should be removed cause it really provides no feature or worth to any thing but is different in a manner of speaking
		//	_textHighlightGeometry = text.BuildHighlightGeometry(new System.Windows.Point((rect.Width / 2) - (text.Width / 2), rect.Height - text.Height));


		//	DrawingVisual drawingVisual = new DrawingVisual();
		//	using (DrawingContext drawingcontext = drawingVisual.RenderOpen())
		//	{
		//		drawingcontext.DrawRoundedRectangle(
		//		System.Windows.Media.Brushes.DarkGoldenrod,
		//		new System.Windows.Media.Pen(System.Windows.Media.Brushes.DarkTurquoise,
		//		2),
		//		rect,
		//		(rect.Width * 3 / 2),
		//		(rect.Height * 3) / 2);

		//		drawingcontext.DrawGeometry(
		//		System.Windows.Media.Brushes.DarkRed,
		//		new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black,
		//		2),
		//		_textGeometry);
		//		//dc.DrawGeometry(System.Windows.Media.Brushes.DarkRed, new System.Windows.Media.Pen(System.Windows.Media.Brushes.Green, rect.Height / 10), _textGeometry);
		//		drawingcontext.Close();
		//	}
		//	System.Windows.Controls.Image img = new System.Windows.Controls.Image();

		//	RenderTargetBitmap target = new RenderTargetBitmap((int)rect.Width, (int)rect.Height, 96, 96, PixelFormats.Default);
		//	target.Render(drawingVisual);

		//	img.Source = target;
		//	img.Stretch = Stretch.Uniform;
		//	img.StretchDirection = StretchDirection.DownOnly;




		//	return img;

		//}
		#endregion

		System.Windows.Media.SolidColorBrush GetBrush(int c, int ln)
		{

			if (((c == 3) && (ln == 4)) || ((c == 8) && (ln == 8)) || ((c == 13 && ln == 13)))
				return System.Windows.Media.Brushes.Red;
			else if (((c == 2) && (ln == 4)) || ((c == 6) && (ln == 8)) || ((c == 10 && ln == 13)))
				return System.Windows.Media.Brushes.Blue;
			else
				return System.Windows.Media.Brushes.LightGray;

		}

		Line drawLine(double pos, System.Windows.Media.Brush clr, bool border = false, bool hor = false, bool rankings = false)
		{
			Line l = new Line();
			if (hor)
			{
				if (!border)
				{ //pos, clr) = interior horizontal line
					l.X1 = 25;
					l.X2 = 925;
					l.Y1 = pos;
					l.Y2 = pos;
					l.StrokeThickness = 1;
				}
				else
				{ //pos, clr, true) = border horizontal line
					l.X1 = 25;
					l.X2 = 1175;
					l.Y1 = pos;
					l.Y2 = pos;
					l.StrokeThickness = 2;
				}
				if (rankings)
				{ //pos, clr, false,true,true) = rankings horizontal line
					l.X1 = 900;
					l.X2 = 1175;
					l.Y1 = pos;
					l.Y2 = pos;
					l.StrokeThickness = 2;
				}
			}
			else
			{
				if (!border)
				{ //pos, clr,false,true) = border verticle line
					l.X1 = pos;
					l.X2 = pos;
					l.Y1 = 25;
					l.Y2 = 675;
					l.StrokeThickness = 1;
				}
				else
				{ //pos, clr,true,true) = interior verticle line
					l.X1 = pos;
					l.X2 = pos;
					l.Y1 = 25;
					l.Y2 = 695;
					l.StrokeThickness = 2;
				}

			}
			if (clr == null)
				l.Stroke = System.Windows.Media.Brushes.Black;
			else
				l.Stroke = (System.Windows.Media.Brush)clr;

			return l;
		}
		void drawChart()
		{
			ScoreBoardGraph.Children.Add(drawLine(25, null, false, true));
			ScoreBoardGraph.Children.Add(drawLine(25, null));
			ScoreBoardGraph.Children.Add(drawLine(675, null, false, true));
			ScoreBoardGraph.Children.Add(drawLine(1175, null));
			ScoreBoardGraph.Children.Add(drawLine(900, null));
			ScoreBoardGraph.Children.Add(drawLine(950, null));
			ScoreBoardGraph.Children.Add(drawLine(25, System.Windows.Media.Brushes.LightBlue));
			ScoreBoardGraph.Children.Add(drawLine(281, System.Windows.Media.Brushes.Orange));
			ScoreBoardGraph.Children.Add(drawLine(537, System.Windows.Media.Brushes.Purple));
			ScoreBoardGraph.Children.Add(drawLine(857, System.Windows.Media.Brushes.ForestGreen));

			double[] weeklines = new double[] { -1, 0, 1, 2, 3, 5, 6, 7, 9, 10, 11, 12, 13 };
			foreach (double item in weeklines)
				ScoreBoardGraph.Children.Add(drawLine((item * 64) + 25, System.Windows.Media.Brushes.LightPink));
			double[] rankings = new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
			foreach (double item in rankings)
			{
				ScoreBoardGraph.Children.Add(drawLine((item * 50) + 25, null, false, true, true));

			}


		}

		List<double> Random(int r1, int r2, int ra)
		{

			List<double> rdbl = new List<double>();
			var rn = new Random(DateTime.Now.Millisecond);
			int ticks = rn.Next(r1, r2);




			Random r = new Random();
			int rInt = r.Next(0, 100); //for ints
			int range = 100;
			double rDouble = r.NextDouble() * range; //for doubles

			double rDouble2 = (r.NextDouble() * 2) - 1.0;
			rdbl.Add(ticks);
			rdbl.Add(rInt);
			rdbl.Add(rDouble);
			rdbl.Add(rDouble2);

			return rdbl;



		}


		List<int> RandomGameNumbers()
		{
			List<int> rn = new List<int>();

			Random rnd = new Random();
			int month = rnd.Next(1, 13); // creates a number between 1 and 12
			int dice = rnd.Next(1, 7); // creates a number between 1 and 6
			int card = rnd.Next(52); // creates a number between 0 and 51
			rn.Add(month);
			rn.Add(dice);
			rn.Add(card);

			return rn;
		}

		async void GetLeaderBoard()
		{

			int i = 0;
			foreach (var item in contestants.OrderByDescending(w => w.GetScore(w)))
			{

				displayControls[i].Value = item.ContestantName;

				scoreorder(item, i);
				PlayerScore[i++].Value = item.GetScore(item).ToString();
				await Task.Delay(500);
			}

			dispatcherTimer.Stop();
		}

		PointCollection plotScoreLine(List<int> so, System.Windows.Media.Brush brush)
		{
			PointCollection pc = new PointCollection();

			double t = 25;
			double u = 670;
			int q = 0;
			pc.Add(new System.Windows.Point(t, u));
			foreach (var item in so)
			{
				Line l = ChartArt(t, u, item, q, brush);
				ScoreBoardGraph.Children.Add(l);
				t = l.X2;
				u = l.Y2;
				pc.Add(new System.Windows.Point(t, u));
				q++;
			}
			return pc;
		}
		Line ChartArt(double x2, double y2, int item, int weeknumber, System.Windows.Media.Brush brush)
		{

			Line l = new Line();

			l.X1 = x2;
			l.Y1 = y2;
			l.Y2 = 670 - ((item * 25));
			l.X2 = (weeknumber * 64) + 25;
			l.Stroke = brush;
			l.StrokeThickness = 2;
			return l;
		}

		void scoreorder(Contestant c, int z)
		{
			List<int> scoreOrder = new List<int>();
			DateTime wk0, wk1, wk2, wk3, wk4, wk5, wk6, wk7, wk8, wk9, wk10, wk11, wk12, wk13, wk14 = new DateTime();
			wk0 = new DateTime(2016, 8, 24);
			wk1 = new DateTime(2016, 9, 1);
			wk2 = new DateTime(2016, 9, 8);
			wk3 = new DateTime(2016, 9, 15);
			wk4 = new DateTime(2016, 9, 22);
			wk5 = new DateTime(2016, 9, 29);
			wk6 = new DateTime(2016, 10, 6);
			wk7 = new DateTime(2016, 10, 13);
			wk8 = new DateTime(2016, 10, 20);
			wk9 = new DateTime(2016, 9, 27);
			wk10 = new DateTime(2016, 11, 3);
			wk11 = new DateTime(2016, 11, 10);
			wk12 = new DateTime(2016, 11, 17);
			wk13 = new DateTime(2016, 11, 24);
			wk14 = new DateTime(2016, 12, 1);

			int aa = 0, a = 0, b = 0, d = 0, e = 0, f = 0, g = 0, h = 0, i = 0, j = 0, k = 0, l = 0, m = 0, n = 0;
			foreach (var item in c.ContestantScore)
				if (item != null)
				{
					if (item.PointScore.DayOfYear > wk1.DayOfYear)
					{
						if (wk1.Subtract(item.PointScore).TotalDays <= 6 && wk1.Subtract(item.PointScore).TotalDays >= 0)
							aa++;
						else if (wk2.Subtract(item.PointScore).TotalDays <= 6 && wk2.Subtract(item.PointScore).TotalDays >= 0)
							a++;
						else if (wk3.Subtract(item.PointScore).TotalDays <= 6 && wk3.Subtract(item.PointScore).TotalDays >= 0)
							b++;
						else if (wk4.Subtract(item.PointScore).TotalDays <= 6 && wk4.Subtract(item.PointScore).TotalDays >= 0)
							d++;
						else if (wk5.Subtract(item.PointScore).TotalDays <= 6 && wk5.Subtract(item.PointScore).TotalDays >= 0)
							e++;
						else if (wk6.Subtract(item.PointScore).TotalDays <= 6 && wk6.Subtract(item.PointScore).TotalDays >= 0)
							f++;
						else if (wk7.Subtract(item.PointScore).TotalDays <= 6 && wk7.Subtract(item.PointScore).TotalDays >= 0)
							g++;
						else if (wk8.Subtract(item.PointScore).TotalDays <= 6 && wk8.Subtract(item.PointScore).TotalDays >= 0)
							h++;
						else if (wk9.Subtract(item.PointScore).TotalDays <= 6 && wk9.Subtract(item.PointScore).TotalDays >= 0)
							i++;
						else if (wk10.Subtract(item.PointScore).TotalDays <= 6 && wk10.Subtract(item.PointScore).TotalDays >= 0)
							j++;
						else if (wk11.Subtract(item.PointScore).TotalDays <= 6 && wk11.Subtract(item.PointScore).TotalDays >= 0)
							k++;
						else if (wk12.Subtract(item.PointScore).TotalDays <= 6 && wk12.Subtract(item.PointScore).TotalDays >= 0)
							l++;
						else if (wk13.Subtract(item.PointScore).TotalDays <= 6 && wk13.Subtract(item.PointScore).TotalDays >= 0)
							m++;
						else if (wk14.Subtract(item.PointScore).TotalDays < 6 && wk14.Subtract(item.PointScore).TotalDays >= 0)
							n++;

					}
				}
			scoreOrder.Add(aa);
			scoreOrder.Add(aa + a);
			scoreOrder.Add(aa + a + b);
			scoreOrder.Add(aa + a + b + d);
			scoreOrder.Add(aa + a + b + d + e);
			scoreOrder.Add(aa + a + b + d + e + f);
			scoreOrder.Add(aa + a + b + d + e + f + g);
			scoreOrder.Add(aa + a + b + d + e + f + g + h);
			scoreOrder.Add(aa + a + b + d + e + f + g + h + i);
			scoreOrder.Add(aa + a + b + d + e + f + g + h + i + j);
			scoreOrder.Add(aa + a + b + d + e + f + g + h + i + j + k);
			scoreOrder.Add(aa + a + b + d + e + f + g + h + i + j + k + l);
			scoreOrder.Add(aa + a + b + d + e + f + g + h + i + j + k + l + m);
			scoreOrder.Add(aa + a + b + d + e + f + g + h + i + j + k + l + m + n);



			carousel.TopItemPosition = SALESPERSON.IndexOf(c.ContestantName);
			c.Points = plotScoreLine(scoreOrder, ColorSelector(z));

		}


		System.Windows.Media.Brush ColorSelector(int i)
		{
			switch (i)
			{
				case 0:
					return System.Windows.Media.Brushes.Lime;
				case 1:
					return System.Windows.Media.Brushes.Lime;
				case 2:
					return System.Windows.Media.Brushes.GreenYellow;
				case 3:
					return System.Windows.Media.Brushes.GreenYellow;
				case 4:
					return System.Windows.Media.Brushes.Yellow;
				case 5:
					return System.Windows.Media.Brushes.Yellow;
				case 6:
					return System.Windows.Media.Brushes.Orange;
				case 7:
					return System.Windows.Media.Brushes.Orange;
				case 8:
					return System.Windows.Media.Brushes.OrangeRed;
				case 9:
					return System.Windows.Media.Brushes.OrangeRed;
				case 10:
					return System.Windows.Media.Brushes.Red;
				case 11:
					return System.Windows.Media.Brushes.Red;


				default:
					return System.Windows.Media.Brushes.White;
			}

		}

		void shorttick(int c, int ln)
		{
			Line l = new Line();
			l.X1 = (ln) * 64 - 5 + 25;
			l.X2 = (ln) * 64 + 5 + 25;
			l.Y1 = l.Y2 = 625 - (c * 25);
			l.Stroke = GetBrush(c, ln);
			l.StrokeThickness = 1;
			ScoreBoardGraph.Children.Add(l);
		}

		void longtick(int c, int ln)
		{
			Line l = new Line();
			l.X1 = (ln) * 64 - 10 + 25;
			l.X2 = (ln) * 64 + 10 + 25;
			l.Y1 = l.Y2 = 625 - (c * 25);
			l.Stroke = GetBrush(c, ln);
			l.StrokeThickness = 1;
			ScoreBoardGraph.Children.Add(l);
		}



		protected void TickDrawer()
		{
			drawChart();


			int h = -1;

			int[] timestorun = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
			foreach (int linenum in timestorun)
			{

				for (h = -1; h < 25; h++)
				{

					if (h == 3 || h == 8 || h == 13 || h == 18 || h == 23)
						longtick(h, linenum);
					else shorttick(h, linenum);

				}
			}
		}

		private void AddRoofButtonPicbutton_Click(object sender, RoutedEventArgs e)
		{
			if (carousel.SelectedIndex == -1)
				return;

			C.Addpoint((Contestant)contestants.Single(i => i.ContestantName == C.SALESPERSON[carousel.SelectedIndex]));
			DrawDisplay();
		}
	}
}
namespace MRNUIElements.Models
{
	public class Contestant
	{

		public List<string> SALESPERSON = new List<string>();
		public static Contestant contestant;
		public static ObservableCollection<Contestant> contestants;
		public int ContestantNumber { get; set; }
		public string ContestantName { get; set; }
		// public ObservableCollection<GamePoint> _Score { get {
		protected static GamePoint _Score { get; set; }
		public ContestantScore ContestantScore { get; set; }
		public int Score { get; set; }
		public System.Windows.Controls.Image NamePlate { get; set; }
		public int Tier { get; set; }
		public int Rank { get; set; }
		public PointCollection Points { get; set; }

		Geometry _textGeometry = null;
		Geometry _textHighlightGeometry = null;



		public Contestant()
		{

			//	PopulateDummyData();


		}

		public List<string> PopulateDummyData()
		{



			if (SALESPERSON.Count() != 0)
				SALESPERSON.Clear();
			{
				SALESPERSON.Add("Jay");
			   	SALESPERSON.Add("Silent Bob");
			   	SALESPERSON.Add("Harvard");
			  	SALESPERSON.Add("Matt");
				SALESPERSON.Add("Craig");
				SALESPERSON.Add("Richard");
				SALESPERSON.Add("Lee/Logan");
				SALESPERSON.Add("Josh");
				SALESPERSON.Add("Foy");
				SALESPERSON.Add("Tony");
				SALESPERSON.Add("Taylor/BJ");
				SALESPERSON.Add("Preston");
			}

			int i = 0;
			foreach (var l in SALESPERSON)
				BuildDummyData(l, i++, 1, i * 2);
			return SALESPERSON;
		}
		public static Contestant getInstance()
		{
			if (contestant == null)
			{
				contestant = new Contestant();
			}
			return contestant;
		}






		public static ObservableCollection<Contestant> cgetInstance()
		{
			if (contestants == null)
				contestants = new ObservableCollection<Contestant>();
			return contestants;
		}
		public int GetScore(Contestant c)
		{

			//return ContestantScore.getInstance().Count();

			if (c != null)
				return c.ContestantScore.Count;
			else return -1;

		}


		public void BuildDummyData(string name, int number, int tier, int rank)
		{
			if (contestant.ContestantScore == null)
				contestant.ContestantScore = new ContestantScore();
			contestant = new Models.Contestant();

			contestant.ContestantName = name;
			contestant.ContestantNumber = number;
			contestant.Tier = tier;
			contestant.NamePlate = BuildGraphicLables(name);
			contestant.ContestantScore = contestant.ContestantScore;
			contestants.Add(contestant);

			for (int i = 0; i < rank; i++)
			{



				contestant.Score = Addpoint(contestant, true);


			}



		}
		public System.Windows.Controls.Image BuildGraphicLables(string s)
		{

			var text = new FormattedText(
			s,
			CultureInfo.CurrentCulture,
			System.Windows.FlowDirection.LeftToRight,
			new Typeface(new System.Windows.Media.FontFamily("Georgia"),
			FontStyles.Normal,
			FontWeights.Bold,
			FontStretches.Expanded,
			new System.Windows.Media.FontFamily("Arial")),
			36d,
			System.Windows.Media.Brushes.Black,
			new System.Windows.Media.NumberSubstitution(NumberCultureSource.Override,
			CultureInfo.CurrentCulture,
			NumberSubstitutionMethod.AsCulture),
			System.Windows.Media.TextFormattingMode.Display);


			Rect rect = new Rect(new System.Windows.Size(text.Width, text.Height));
			// this nugget is necessary period to create a situation where no mods to the text are necessary to view on any pic background
			_textGeometry = text.BuildGeometry(new System.Windows.Point((rect.Width / 2) - (text.Width / 2), (rect.Height / 2) - (text.Height / 2)));
			// this nugget is unnecessary and probably should be removed cause it really provides no feature or worth to any thing but is different in a manner of speaking
			_textHighlightGeometry = text.BuildHighlightGeometry(new System.Windows.Point((rect.Width / 2) - (text.Width / 2), rect.Height - text.Height));


			DrawingVisual drawingVisual = new DrawingVisual();
			using (DrawingContext drawingcontext = drawingVisual.RenderOpen())
			{
				drawingcontext.DrawRoundedRectangle(
				System.Windows.Media.Brushes.DarkGoldenrod,
				new System.Windows.Media.Pen(System.Windows.Media.Brushes.DarkTurquoise,
				2),
				rect,
				(rect.Width * 3 / 2),
				(rect.Height * 3) / 2);

				drawingcontext.DrawGeometry(
				System.Windows.Media.Brushes.DarkRed,
				new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black,
				2),
				_textGeometry);
				//dc.DrawGeometry(System.Windows.Media.Brushes.DarkRed, new System.Windows.Media.Pen(System.Windows.Media.Brushes.Green, rect.Height / 10), _textGeometry);
				drawingcontext.Close();
			}
			System.Windows.Controls.Image img = new System.Windows.Controls.Image();

			RenderTargetBitmap target = new RenderTargetBitmap((int)rect.Width, (int)rect.Height, 96, 96, PixelFormats.Default);
			target.Render(drawingVisual);

			img.Source = target;
			img.Stretch = Stretch.Uniform;
			img.StretchDirection = StretchDirection.DownOnly;




			return img;

		}
		public int Addpoint(Contestant c, bool dummy = false)
		{


			if (c == null)
				return -1;
			if (c.ContestantScore == null)
				c.ContestantScore = new Models.ContestantScore();

			if (c.ContestantScore != null)
			{
				if (dummy)
					c.ContestantScore.PointScored(c.ContestantScore, new Models.GamePoint(contestant, DateTime.Today.AddDays(contestant.ContestantScore.Count)));
				else
					c.ContestantScore.PointScored(c.ContestantScore, new Models.GamePoint(contestant, DateTime.Today));

				return c.ContestantScore._ContestantScore;
			}
			else return -2;


		}




		public bool removePoint(Contestant c)
		{
			if (c == null)
				return false;
			if (c.Score > 0)
			{
				c.Score--;
				return true;
			}
			else c.Score = 0;
			return true;

		}
	}

	public class ContestantScore : ObservableCollection<GamePoint>
	{

		public static ContestantScore GPC;
		public Contestant contestant { get; set; }// = Contestant.getInstance();
		public GamePoint Score { get; set; }
		public int _ContestantScore { get; set; }
		public ContestantScore _contestantScore { get; set; }

		public ContestantScore()
		{

		}

		public static ContestantScore getInstance()
		{
			if (GPC == null)
				GPC = new ContestantScore();
			return GPC;
		}
		public void PointScored(ContestantScore cs, GamePoint gp)
		{
			_contestantScore = cs;


			if (_contestantScore == null)
				_contestantScore = new ContestantScore();

			DateTime dt = DateTime.Today;

			_contestantScore.Add(gp);


			//if (gp != null)
			// cs.Add(gp);

			//else if (Score != null)
			// this.Add(Score);

			_ContestantScore = this.Count();

		}
	}
	public class GamePoint
	{


		public DateTime PointScore { get; set; }

		public Contestant Contestant { get; set; }
		public DateTime Point { get; set; }

		public GamePoint(Contestant Contestant, DateTime PointScore)
		{


			if (Contestant != null && PointScore != null)
				if (Contestant != this.Contestant)
				{
					this.Contestant = Contestant;
					this.PointScore = PointScore;
				}
				else return;



		}



	}

	class PostitionDisplay : ObservableCollection<PolePosition>
	{
		public int Position { get; set; }
		public System.Windows.Media.Brush Foreground { get; set; }
		public int Height { get; set; }
		public System.Windows.Media.Brush Background { get; set; }
		public PolePosition PolePosition { get; set; }

		public PostitionDisplay()
		{

		}

	}
	class PolePositionScore : Syncfusion.UI.Xaml.Gauges.SfDigitalGauge
	{

		public int Score { get; set; }

		public Syncfusion.UI.Xaml.Gauges.SfDigitalGauge ScoreValue { get; set; }



		public PolePositionScore()
		{

		}
	}
	class PolePositionLabel : Syncfusion.UI.Xaml.Gauges.SfDigitalGauge
	{

		public string Label { get; set; }

		public Syncfusion.UI.Xaml.Gauges.SfDigitalGauge PositionLabel { get; set; }



		public PolePositionLabel()
		{

		}
	}
	class PolePosition
	{



		public PolePositionScore ScoreValue { get; set; }
		public PolePositionLabel Position { get; set; }



		public PolePosition()
		{

		}
	}
}
