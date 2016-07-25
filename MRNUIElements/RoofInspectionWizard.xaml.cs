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
namespace MRNUIElements
{
	/// <summary>
	/// Interaction logic for RoofInspectionWizard.xaml
	/// </summary>
	public partial class RoofInspectionWizard : Page
	{
		public bool b = true;
		public RoofInspectionWizard()
		{
			InitializeComponent();

			//	FillSelectionIndex()

		}
		private double FigureSqFt(int Ridge = 0, int Eave = 0, int Rake = 0)
		{

			return (((Ridge + Eave) * Rake) / 144) / 2;


		}
		private Canvas ShapeCanvas(int shape = 0, double dRidge = 0, double dRake = 0, double dEave = 0)
		{

			double.TryParse(RidgeLengthTextBox.Text, out dRidge);
			double.TryParse(RakeLengthTextBox.Text, out dRake);
			double.TryParse(EaveLengthTextBox.Text, out dEave);
			//res gonna be 900x600 75'X50'
			double HCenter = 0;
			double VCenter = 0;
			double Offset = 0;
			Canvas can = new Canvas();
			//Check for shape type
			bool isTriangle = false;
			if (dRidge == 0 || dEave == 0)//yes isTriangle
				isTriangle = true;
			//Get Orientation
			bool isHorizontal = true;
			if (!isTriangle)
			{
				if ((dRidge > dRake) || (dEave > dRake))
				{
                    isHorizontal=true;
				}
				else isHorizontal = false;
			}

			//Determine offset
			bool isOffset = false;
			bool isline1 = false;
			if (!isTriangle && (dRidge != dEave))
				isOffset = true;



		
			//if (dRidge > dEave)
			//	{
			//		isline1 = true; // line one is closest
					
			//	}
			//	else
			//	{
					

			//	}

				//FindVerticalCenter
		//		if (isOffset)
				//{
					//if (isHorizontal)
					//{
					//	if (isline1)
					//	{
					if (dRidge < dEave) { 
							HCenter = dEave / 2;Offset = dEave - dRidge;
						}
						else
						{
							HCenter = dRidge / 2;Offset = dRidge - dEave;
						}

						VCenter = dRake / 2;
				//	}
					//else return can;

					//FindHorizontalCenter

				//}

	
				//Set Top Line Coords
				Point TL = new Point();
				Point BL = new Point();
				Point BR = new Point();
				Point TR = new Point();
				TL.X = 0;
				TL.Y = 0;
				TR.X = 0;
				TR.Y = 0;
				BL.X = 0;
				BL.Y = 0;
				BR.X = 0;
				BR.Y = 0;
				//if ((dx + dz) > DrawingCanvas.Width)
				//{
				//	BR.X = dx - ((TL.X + dx + dz) - DrawingCanvas.Width) - 10;
				//	BR.Y = dy - ((TL.Y + dy) - DrawingCanvas.Height) - 10;
				//}
				//else {
				//	BR.X = TL.X + dx + dz;
				//	BR.Y = TL.Y + dy;
				//}
				double shift = Offset;

				//Create and initialize lines
				Line line1 = new Line(), line2 = new Line(), line3 = new Line(), line4 = new Line();

				switch (shape)
				{

					case 0:
						{
							//Shape1 rect
							//Wide

							TL.X = (DrawingCanvas.Width / 2) - HCenter;			TR.X = (DrawingCanvas.Width / 2) + HCenter;
							TL.Y = (DrawingCanvas.Height / 2) - VCenter;		TR.Y = (DrawingCanvas.Height / 2) - VCenter;
						
							BL.X = (DrawingCanvas.Width / 2) - HCenter;			BR.X = (DrawingCanvas.Width / 2) + HCenter;
							BL.Y = (DrawingCanvas.Height / 2) + VCenter; ;		BR.Y = (DrawingCanvas.Height / 2) + VCenter;


						break;
						}


					case 1:
						{
							TL.X = (DrawingCanvas.Width / 2) - HCenter;			TR.X = (DrawingCanvas.Width / 2) + HCenter;
							TL.Y = (DrawingCanvas.Height / 2) - VCenter;		TR.Y = (DrawingCanvas.Height / 2) - VCenter;
							
							
							BL.X = (DrawingCanvas.Width / 2) - HCenter;			BR.X = (DrawingCanvas.Width / 2) + HCenter;
							BL.Y = (DrawingCanvas.Height / 2) + VCenter;		BR.Y = (DrawingCanvas.Height / 2) + VCenter;
						
							
							break;

						}
					case 2: //TopShiftRight
						{

							TL.X = (DrawingCanvas.Width / 2) - HCenter - (Offset / 2);	TR.X = (DrawingCanvas.Width / 2) + HCenter - (Offset / 2);
							TL.Y = (DrawingCanvas.Height / 2) - VCenter;				TR.Y = (DrawingCanvas.Height / 2) - VCenter;
							
							BL.X = (DrawingCanvas.Width / 2) - HCenter + (Offset / 2);	BR.X = (DrawingCanvas.Width / 2) + HCenter + (Offset / 2);
							BL.Y = (DrawingCanvas.Height / 2) + VCenter;				BR.Y = (DrawingCanvas.Height / 2) + VCenter;
						
							break;


						}
					case 3: //TopShiftLeft
						{
							TL.X = (DrawingCanvas.Width / 2) - HCenter + (Offset / 2);	TR.X = (DrawingCanvas.Width / 2) + HCenter + (Offset / 2);
							TL.Y = (DrawingCanvas.Height / 2) - VCenter;				TR.Y = (DrawingCanvas.Height / 2) - VCenter;


							BL.X = (DrawingCanvas.Width / 2) - HCenter - (Offset / 2);	BR.X = (DrawingCanvas.Width / 2) + HCenter - (Offset / 2);
							BL.Y = (DrawingCanvas.Height / 2) + VCenter;				BR.Y = (DrawingCanvas.Height / 2) + VCenter;



						break;
						}
					case 4:
						{

							TL.X = (DrawingCanvas.Width / 2) - HCenter + (Offset / 2);	TR.X = (DrawingCanvas.Width / 2) + HCenter - (Offset / 2);
							TL.Y = (DrawingCanvas.Height / 2) - VCenter;				TR.Y = (DrawingCanvas.Height / 2) - VCenter;
							
							
							BL.X = (DrawingCanvas.Width / 2) - HCenter;					BR.X = (DrawingCanvas.Width / 2) + HCenter;
							BL.Y = (DrawingCanvas.Height / 2) + VCenter;				BR.Y = (DrawingCanvas.Height / 2) + VCenter;			
							
							
							break;
						}
					case 5:
						{
							TL.X = (DrawingCanvas.Width / 2) - HCenter;					TR.X = (DrawingCanvas.Width / 2) + HCenter;
							TL.Y =  (DrawingCanvas.Height / 2) - VCenter;				TR.Y = (DrawingCanvas.Height / 2) - VCenter;


							BL.X = (DrawingCanvas.Width / 2) - HCenter + (Offset / 2);	BR.X = (DrawingCanvas.Width / 2) + HCenter - (Offset / 2);
							BL.Y = (DrawingCanvas.Height / 2) + VCenter;				BR.Y = (DrawingCanvas.Height / 2) + VCenter;
						
						
							break;

						}
					case 6:
						{
							isTriangle = true;
							TL.X = (DrawingCanvas.Width / 2) + HCenter;					TR.X = (DrawingCanvas.Width / 2) + HCenter;// looks like   /_|
							TL.Y = (DrawingCanvas.Height / 2) - VCenter;				TR.Y = (DrawingCanvas.Height / 2) - VCenter;//   

							BL.X = (DrawingCanvas.Width / 2) - HCenter;					BR.X = (DrawingCanvas.Width / 2) + HCenter;
							BL.Y = (DrawingCanvas.Height / 2) + VCenter;				BR.Y = (DrawingCanvas.Height / 2) + VCenter;				


					
							break;
						}
					case 7:
						{
						isTriangle = true;
							TL.X = (DrawingCanvas.Width / 2) - HCenter;					TR.X = (DrawingCanvas.Width / 2) - HCenter;// looks like  |_\
							TL.Y = (DrawingCanvas.Height / 2) - VCenter;				TR.Y = (DrawingCanvas.Height / 2) - VCenter;//   

							BL.X = (DrawingCanvas.Width / 2) - HCenter;					BR.X = (DrawingCanvas.Width / 2) + HCenter;
							BL.Y = (DrawingCanvas.Height / 2) + VCenter;				BR.Y = (DrawingCanvas.Height / 2) + VCenter;
						break;
						}
					case 8:
						{
							isTriangle = true;
							TL.X = (DrawingCanvas.Width / 2);							TR.X = (DrawingCanvas.Width / 2);
							TL.Y = (DrawingCanvas.Height / 2) - VCenter;				TR.Y = (DrawingCanvas.Height / 2) - VCenter;//    
						
							          
							BL.X = (DrawingCanvas.Width / 2) - HCenter;					BR.X = (DrawingCanvas.Width / 2) + HCenter;
							BL.Y = (DrawingCanvas.Height / 2) + VCenter;				BR.Y = (DrawingCanvas.Height / 2) + VCenter;							
												
							break;
						}
					case 9:
						{
							isTriangle = true;
							TL.X = (DrawingCanvas.Width / 2) - HCenter;					TR.X = (DrawingCanvas.Width / 2) + HCenter;
							TL.Y = (DrawingCanvas.Height / 2) - VCenter;				TR.Y = (DrawingCanvas.Height / 2) - VCenter;// 


							BL.X = (DrawingCanvas.Width / 2);							BR.X = (DrawingCanvas.Width / 2);
							BL.Y = (DrawingCanvas.Height / 2) + VCenter;				BR.Y = (DrawingCanvas.Height / 2) + VCenter;
							
							
							break;

						}
					case 10:
						{

							TL.X = (DrawingCanvas.Width / 2) - HCenter;					TR.X = (DrawingCanvas.Width / 2) + HCenter;
							TL.Y = (DrawingCanvas.Height / 2) - VCenter;				TR.Y = (DrawingCanvas.Height / 2) - VCenter;
							
							
							BL.X = (DrawingCanvas.Width / 2) - HCenter + Offset;		BR.X = (DrawingCanvas.Width / 2) + HCenter;
							BL.Y = (DrawingCanvas.Height / 2) + VCenter;				BR.Y = (DrawingCanvas.Height / 2) + VCenter;

							
							
							break;
						}

					case 11:
						{
							TL.X = (DrawingCanvas.Width / 2) - HCenter;					TR.X = (DrawingCanvas.Width / 2) + HCenter;
							TL.Y = (DrawingCanvas.Height / 2) - VCenter;				TR.Y = (DrawingCanvas.Height / 2) - VCenter;
						
							
							BL.X = (DrawingCanvas.Width / 2) - HCenter;					BR.X = (DrawingCanvas.Width / 2) + HCenter - Offset;
							BL.Y = (DrawingCanvas.Height / 2) + VCenter;				BR.Y = (DrawingCanvas.Height / 2) + VCenter;

							
							
							break;
						}



				}


				//TopLine
				line1.Visibility = System.Windows.Visibility.Visible;
				line1.StrokeThickness = 4;
				line1.Stroke = System.Windows.Media.Brushes.White;
			line1.X1 = TL.X;	line1.X2 = TR.X;
			line1.Y1 = TL.Y;	line1.Y2 = TR.Y;
				//Bottom Line Width
				line2.Visibility = System.Windows.Visibility.Visible;
				line2.StrokeThickness = 4;
				line2.Stroke = System.Windows.Media.Brushes.White;
				
			line2.X2 = BR.X;line2.X1 = BL.X;
			line2.Y2 = BR.Y;line2.Y1 = BL.Y;
				//Left line vertical
				line3.Visibility = System.Windows.Visibility.Visible;
				line3.StrokeThickness = 4;
				line3.Stroke = System.Windows.Media.Brushes.White;
			line3.X1 =   line2.X1;line3.X2 = line1.X1;
			line3.Y1 =   line2.Y1;line3.Y2 = line1.Y1;
				//Right Line vertical
				line4.Visibility = System.Windows.Visibility.Visible;
				line4.StrokeThickness = 4;
				line4.Stroke = System.Windows.Media.Brushes.White;

			line4.X1 = line2.X2;line4.X2 = line1.X2;
			line4.Y1 = line2.Y2;line4.Y2 = line1.Y2;
				
				
				can.Children.Add(line1);
				can.Children.Add(line2);
				can.Children.Add(line3);
				can.Children.Add(line4);



			return can;
		}
			
		

		private void SetRoofPlaneShapes()
		{

			DrawingCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Visible);
			MainCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Hidden);

		}

		private void Shape0btn_Click(object sender, RoutedEventArgs e)
		{
			DrawingCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Visible);
			MainCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Hidden);


			DrawingCanvas.Children.Clear();
			DrawingCanvas.Children.Add(ShapeCanvas(0));
		}

		private void Shape1btn_Click(object sender, RoutedEventArgs e)
		{
			DrawingCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Visible);
			MainCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Hidden);
			DrawingCanvas.Children.Clear();
			DrawingCanvas.Children.Add(ShapeCanvas(1));
		}

		private void Shape2btn_Click(object sender, RoutedEventArgs e)
		{
			DrawingCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Visible);
			MainCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Hidden);
			DrawingCanvas.Children.Clear();
			DrawingCanvas.Children.Add(ShapeCanvas(2));
		}

		private void Shape3btn_Click(object sender, RoutedEventArgs e)
		{
			DrawingCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Visible);
			MainCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Hidden);
			DrawingCanvas.Children.Clear();
			DrawingCanvas.Children.Add(ShapeCanvas(3));
		}

		private void Shape4btn_Click(object sender, RoutedEventArgs e)
		{
			DrawingCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Visible);
			MainCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Hidden);
			DrawingCanvas.Children.Clear();
			DrawingCanvas.Children.Add(ShapeCanvas(4));
		}

		private void Shape5btn_Click(object sender, RoutedEventArgs e)
		{
			DrawingCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Visible);
			MainCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Hidden);
			DrawingCanvas.Children.Clear();
			DrawingCanvas.Children.Add(ShapeCanvas(5));
		}

		private void Shape6btn_Click(object sender, RoutedEventArgs e)
		{
			DrawingCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Visible);
			MainCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Hidden);
			DrawingCanvas.Children.Clear();
			DrawingCanvas.Children.Add(ShapeCanvas(6));
		}

		private void Shape7btn_Click(object sender, RoutedEventArgs e)
		{
			DrawingCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Visible);
			MainCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Hidden);
			DrawingCanvas.Children.Clear();
			DrawingCanvas.Children.Add(ShapeCanvas(7));

		}

		private void Shape9btn_Click(object sender, RoutedEventArgs e)
		{
			DrawingCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Visible);
			MainCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Hidden);
			DrawingCanvas.Children.Clear();
			DrawingCanvas.Children.Add(ShapeCanvas(8));
		}

		private void Shape8btn_Click(object sender, RoutedEventArgs e)
		{

			DrawingCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Visible);
			MainCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Hidden);
			DrawingCanvas.Children.Clear();
			DrawingCanvas.Children.Add(ShapeCanvas(9));
		}

		private void Shape10btn_Click(object sender, RoutedEventArgs e)
		{
			DrawingCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Visible);
			MainCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Hidden);
			DrawingCanvas.Children.Clear();
			DrawingCanvas.Children.Add(ShapeCanvas(10));
		}

		private void Shape11btn_Click(object sender, RoutedEventArgs e)
		{
			DrawingCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Visible);
			MainCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Hidden);
			DrawingCanvas.Children.Clear();
			DrawingCanvas.Children.Add(ShapeCanvas(11));
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{if (DrawingCanvas.IsVisible)
			{
				DrawingCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Hidden);
				MainCanvas.SetValue(VisibilityProperty, System.Windows.Visibility.Visible);
			}
		else { ScopeViewer Page = new ScopeViewer();
				this.NavigationService.Navigate(Page);
			}
		}

		private void RidgeLengthTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			if (RidgeLengthTextBox.Text == string.Empty) RidgeLengthTextBox.Text = "0";
			RidgeLengthTextBox.SelectAll(); b = false;
		}

		private void RakeLengthTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			if (RakeLengthTextBox.Text == string.Empty) RakeLengthTextBox.Text = "0";
			RakeLengthTextBox.SelectAll(); b = false;
		}

		private void EaveLengthTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			if (EaveLengthTextBox.Text == string.Empty) EaveLengthTextBox.Text = "0";
			EaveLengthTextBox.SelectAll();b = false;
		}

		private void RidgeLengthTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			int c = 0;
			
			
			if (!int.TryParse(RidgeLengthTextBox.Text, out c)) MessageBox.Show("Enter length to nearest inch","Invalid Entry");
			if (RidgeLengthTextBox.Text == string.Empty) { RidgeLengthTextBox.Text = "0"; RidgeLengthTextBox.SelectAll(); }
			if (b == false) SqFtTotal.Text = FigureSqFt(int.Parse(EaveLengthTextBox.Text), int.Parse(RakeLengthTextBox.Text), int.Parse(RidgeLengthTextBox.Text)).ToString();
		}

		private void RakeLengthTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			int c = 0;
			if (!int.TryParse(RakeLengthTextBox.Text, out c)) MessageBox.Show("Enter length to nearest inch", "Invalid Entry");
			if (RakeLengthTextBox.Text == string.Empty) { RakeLengthTextBox.Text = "0"; RakeLengthTextBox.SelectAll(); }

			if (b == false) SqFtTotal.Text = FigureSqFt(int.Parse(EaveLengthTextBox.Text), int.Parse(RakeLengthTextBox.Text), int.Parse(RidgeLengthTextBox.Text)).ToString();
		}

		private void EaveLengthTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			int c = 0;
			if (EaveLengthTextBox.Text == string.Empty) { EaveLengthTextBox.Text = "0"; EaveLengthTextBox.SelectAll(); }
			if (!int.TryParse(EaveLengthTextBox.Text, out c)) MessageBox.Show("Enter length to nearest inch", "Invalid Entry");

			if (b == false) SqFtTotal.Text = FigureSqFt(int.Parse(EaveLengthTextBox.Text), int.Parse(RakeLengthTextBox.Text), int.Parse(RidgeLengthTextBox.Text)).ToString();
		}

		private void RidgeLengthTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			 SqFtTotal.Text = FigureSqFt(int.Parse(EaveLengthTextBox.Text), int.Parse(RakeLengthTextBox.Text), int.Parse(RidgeLengthTextBox.Text)).ToString();
		}

		private void RakeLengthTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
		 SqFtTotal.Text = FigureSqFt(int.Parse(EaveLengthTextBox.Text), int.Parse(RakeLengthTextBox.Text), int.Parse(RidgeLengthTextBox.Text)).ToString();
		}

		private void EaveLengthTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			SqFtTotal.Text = FigureSqFt(int.Parse(EaveLengthTextBox.Text), int.Parse(RakeLengthTextBox.Text), int.Parse(RidgeLengthTextBox.Text)).ToString();
		}
	}
}
