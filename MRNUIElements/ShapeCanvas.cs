using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using MRNNexus_Model;

namespace MRNUIElements
{
  
		public partial class ShapeCanvas : Canvas
		{

		 
		private ShapeCanvas( int shape = 0)
		{

			//res gonna be 900x600 75'X50'
			Canvas can = new Canvas();
			Point TL = new Point();
			TL.X = 10;
			TL.Y = 10;
			Point BR = new Point();
			BR.X = 90;
			BR.Y = 140;

			int shift = 25;
			
			
			Line line1 = new Line(), line2 = new Line(), line3 = new Line(), line4 = new Line();
			
		switch (shape) { 
		
				case 0:
				{
					//Shape1 rect
					//Wide
					line1.Visibility = System.Windows.Visibility.Visible;
					line1.StrokeThickness = 4;
					line1.Stroke = System.Windows.Media.Brushes.Black;
					line1.X1 = TL.X;
					line1.X2 = BR.X;
					line1.Y1 = TL.Y;
					line1.Y2 = TL.Y;

					//Bottom Line Width

					line2.Visibility = System.Windows.Visibility.Visible;
					line2.StrokeThickness = 4;
					line2.Stroke = System.Windows.Media.Brushes.Black;
					line2.X1 = TL.X;
					line2.X2 = BR.X ;
					line2.Y1 = BR.Y;
					line2.Y2 = BR.Y;
					break;
				}
				case 1:
				{
					//Shape2 rect
					//Narrow rect tall
					line1.Visibility = System.Windows.Visibility.Visible;
					line1.StrokeThickness = 4;
					line1.Stroke = System.Windows.Media.Brushes.Black;
					line1.X1 = TL.X;
					
					line1.Y1 = TL.Y;
					line1.Y2 = TL.Y;

					//Bottom Line Width

					line2.Visibility = System.Windows.Visibility.Visible;
					line2.StrokeThickness = 4;
					line2.Stroke = System.Windows.Media.Brushes.Black;
					line2.X1 = line1.X1;
					line2.X2 = line1.X2;
					line2.Y1 = BR.Y;
					line2.Y2 = BR.Y;
						break;
					}
				case 2:
				{
					shift = 25;
					//Shape1 rect
					//Top Line Width
					line1.Visibility = System.Windows.Visibility.Visible;
					line1.StrokeThickness = 4;
					line1.Stroke = System.Windows.Media.Brushes.Black;
					line1.X1 =shift-TL.X;
					line1.X2 = BR.X-shift+TL.X ;
					line1.Y1 = TL.Y;
					line1.Y2 = TL.Y;

					//Bottom Line Width

					line2.Visibility = System.Windows.Visibility.Visible;
					line2.StrokeThickness = 4;
					line2.Stroke = System.Windows.Media.Brushes.Black;
					line2.X1 = BR.X + TL.X - shift;
					line2.X2 = shift;
					line2.Y1 = BR.Y;
					line2.Y2 = BR.Y;
						break;
					}
				case 3:
				{
				shift = 25;
					//Shape1 rect
					//Top Line Width
					line1.Visibility = System.Windows.Visibility.Visible;
					line1.StrokeThickness = 4;
					line1.Stroke = System.Windows.Media.Brushes.Black;
					line1.X1 =shift-TL.X;
					line1.X2 = BR.X-shift ;
					line1.Y1 = TL.Y;
					line1.Y2 = TL.Y;

					//Bottom Line Width

					line2.Visibility = System.Windows.Visibility.Visible;
					line2.StrokeThickness = 4;
					line2.Stroke = System.Windows.Media.Brushes.Black;
					line2.X1 = BR.X-shift+TL.X;
					line2.X2 = TL.X+shift;
					line2.Y1 = BR.Y;
					line2.Y2 = BR.Y;
						break;
					}
				case 4:
				{
				shift = 25;
					//Shape1 rect
					//Top Line Width
					line1.Visibility = System.Windows.Visibility.Visible;
					line1.StrokeThickness = 4;
					line1.Stroke = System.Windows.Media.Brushes.Black;
					line1.X1 = TL.X+shift;
				line1.X2 = BR.X - shift;
					line1.Y1 = TL.Y;
					line1.Y2 = TL.Y;

					//Bottom Line Width

					line2.Visibility = System.Windows.Visibility.Visible;
					line2.StrokeThickness = 4;
					line2.Stroke = System.Windows.Media.Brushes.Black;
					line2.X1 =BR.X;
					line2.X2 = TL.X ;
					line2.Y1 = BR.Y;
					line2.Y2 = BR.Y;
						break;
					}
				case 5:
				{
				shift = 25;
					//Shape1 rect
					//Top Line Width
					line1.Visibility = System.Windows.Visibility.Visible;
					line1.StrokeThickness = 4;
					line1.Stroke = System.Windows.Media.Brushes.Black;
					line1.X1 = TL.X;
					line1.X2 = BR.X;
					line1.Y1 = TL.Y;
					line1.Y2 = TL.Y;

					//Bottom Line Width

					line2.Visibility = System.Windows.Visibility.Visible;
					line2.StrokeThickness = 4;
					line2.Stroke = System.Windows.Media.Brushes.Black;
					line2.X1 = BR.X-shift;
					line2.X2 = TL.X+shift;
					line2.Y1 = BR.Y;
					line2.Y2 = BR.Y;
						break;
					}
				case 6:
				{
					//Shape1 rect
					//Top Line Width
					line1.Visibility = System.Windows.Visibility.Visible;
					line1.StrokeThickness = 4;
					line1.Stroke = System.Windows.Media.Brushes.Black;
					line1.X1 = BR.X ;
					line1.X2 = BR.X;
					line1.Y1 = TL.Y;
					line1.Y2 = TL.Y;

					//Bottom Line Width

					line2.Visibility = System.Windows.Visibility.Visible;
					line2.StrokeThickness = 4;
					line2.Stroke = System.Windows.Media.Brushes.Black;
					line2.X1 = BR.X;
					line2.X2 = TL.X;
					line2.Y1 = BR.Y;
					line2.Y2 = BR.Y;
						break;
					}
				case 7:
				{
					//Shape1 rect
					//Top Line Width
					line1.Visibility = System.Windows.Visibility.Visible;
					line1.StrokeThickness = 4;
					line1.Stroke = System.Windows.Media.Brushes.Black;
					line1.X1 = TL.X;
					line1.X2 = TL.X;
					line1.Y1 = TL.Y;
					line1.Y2 = TL.Y;

					//Bottom Line Width

					line2.Visibility = System.Windows.Visibility.Visible;
					line2.StrokeThickness = 4;
					line2.Stroke = System.Windows.Media.Brushes.Black;
					line2.X1 = BR.X;
					line2.X2 = TL.X;
					line2.Y1 = BR.Y;
					line2.Y2 = BR.Y;
						break;
					}
				case 8:
				{
					//Shape1 rect
					//Top Line Width
					line1.Visibility = System.Windows.Visibility.Visible;
					line1.StrokeThickness = 4;
					line1.Stroke = System.Windows.Media.Brushes.Black;
					line1.X1 = BR.X +TL.X/2;
					line1.X2 = BR.X + TL.X / 2;
					line1.Y1 = TL.Y;
					line1.Y2 = TL.Y;

					//Bottom Line Width

					line2.Visibility = System.Windows.Visibility.Visible;
					line2.StrokeThickness = 4;
					line2.Stroke = System.Windows.Media.Brushes.Black;
					line2.X1 = BR.X;
					line2.X2 = TL.X ;
					line2.Y1 = BR.Y;
					line2.Y2 = BR.Y;
						break;
					}
				case 9:
				{
					//Shape1 rect
					//Top Line Width
					line1.Visibility = System.Windows.Visibility.Visible;
					line1.StrokeThickness = 4;
					line1.Stroke = System.Windows.Media.Brushes.Black;
					line1.X1 = TL.X;
					line1.X2 = BR.X;
					line1.Y1 = TL.Y;
					line1.Y2 = TL.Y;

					//Bottom Line Width

					line2.Visibility = System.Windows.Visibility.Visible;
					line2.StrokeThickness = 4;
					line2.Stroke = System.Windows.Media.Brushes.Black;
					line2.X1 = BR.X + TL.X / 2;
					line2.X2 = BR.X +TL.X/2;
					line2.Y1 = BR.Y;
					line2.Y2 = BR.Y;
						break;
					}
			case 10:
			{
				shift = 25;
				//Shape1 rect
				//Top Line Width
				line1.Visibility = System.Windows.Visibility.Visible;
				line1.StrokeThickness = 4;
				line1.Stroke = System.Windows.Media.Brushes.Black;
				line1.X1 = TL.X;
				line1.X2 = BR.X;
				line1.Y1 = TL.Y;
				line1.Y2 = TL.Y;

				//Bottom Line Width

				line2.Visibility = System.Windows.Visibility.Visible;
				line2.StrokeThickness = 4;
				line2.Stroke = System.Windows.Media.Brushes.Black;
				line2.X1 = BR.X;
				line2.X2 = TL.X + shift;
				line2.Y1 = BR.Y;
				line2.Y2 = BR.Y;
						break;
					}

		case 11:
			{
				shift = 25;
				//Shape1 rect
				//Top Line Width
				line1.Visibility = System.Windows.Visibility.Visible;
				line1.StrokeThickness = 4;
				line1.Stroke = System.Windows.Media.Brushes.Black;
				line1.X1 = TL.X;
				line1.X2 = BR.X;
				line1.Y1 = TL.Y;
				line1.Y2 = TL.Y;

				//Bottom Line Width

				line2.Visibility = System.Windows.Visibility.Visible;
				line2.StrokeThickness = 4;
				line2.Stroke = System.Windows.Media.Brushes.Black;
				line2.X1 = BR.X - shift;
				line2.X2 = TL.X;
				line2.Y1 = BR.Y;
				line2.Y2 = BR.Y;
						break;
			}



			}
			//Left line vertical
			line3.Visibility = System.Windows.Visibility.Visible;
				line3.StrokeThickness = 4;
				line3.Stroke = System.Windows.Media.Brushes.Black;
				line3.X1 = line1.X1;
				line3.X2 = line2.X2;//Right shift top
				line3.Y1 = line1.Y1;
				line3.Y2 = line2.Y2;
				//Right Line vertical
				line4.Visibility = System.Windows.Visibility.Visible;
				line4.StrokeThickness = 4;
				line4.Stroke = System.Windows.Media.Brushes.Black;
				line4.X1 = line1.X2;
				line4.X2 = line2.X1;
				line4.Y1 = line1.Y2;
				line4.Y2 = line2.Y1;
				can.Children.Add(line1);
				can.Children.Add(line2);
				can.Children.Add(line3);
				can.Children.Add(line4);
			
			}






	}
}