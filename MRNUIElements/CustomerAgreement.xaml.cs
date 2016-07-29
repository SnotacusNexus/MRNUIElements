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
    /// Interaction logic for CustomerAgreement.xaml
    /// </summary>
    public partial class CustomerAgreement : Page
    { int i = 1;
		Point currentPoint = new Point();
		public CustomerAgreement()
        {
            InitializeComponent();
			
        }

   

		private void Customer_MouseEnter(object sender, MouseEventArgs e)
		{
			((TextBlock)sender).Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
		}
	

		private void Customer_MouseLeave(object sender, MouseEventArgs e)
		{
			((TextBlock)sender).Background = null;
		}

		private void PrevStep(object sender, RoutedEventArgs e)
		{
			//if (i == 0) {
			//	i = 1;
			//	MessageBox.Show("You are at the first step."); }
			//else i--;
			//Navigate(i);
			


			

		}

		private void NextStep(object sender, RoutedEventArgs e)
		{

			//if (i == 0) {
			//	i = 7;
			//	MessageBox.Show("You are at the last step."); }
			//else i++;
			//Navigate(i);




		}

		private void Home(object sender, RoutedEventArgs e)
		{
			NexusHome Page = new NexusHome();
			this.NavigationService.Navigate(Page);

		}


		private void Navigate(int nNavSeq)
		{
		
		
				switch (nNavSeq)
				{

					case 0:
						{
                        Lead_Generation.Focus();
                        break;
						}
					case 1:
						{
                        Customer_Info.Focus();

                        break;
						}
					case 2:
						{
                        Insurance.Focus();
						break;
						}
					case 3:
						{
						Site_Survey.Focus();
						break;
					}
					case 4:
						{
						Damage_Assessment.Focus();
						break;
					}
					case 5:
						{
					    Claim_Process.Focus();
						break;
					}
					case 6:
					{
						Project_At_Hand.Focus();
						break;
					}
					case 7:
					{
						Upgrades.Focus();
						break;
					}
					case 8:
					{
						Finalize_Agreement.Focus();
						break;
					}

                case 9:
                    {
                        //Function to file claim 
                        //on signature success then send welcome email
                        break;

                    }
				}
			}

		private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			if (e.ButtonState == MouseButtonState.Pressed)
				currentPoint = e.GetPosition(this);
		}

		

        private void Roof_Inspection_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Exterior_Inspection_Click(object sender, RoutedEventArgs e)
		{
			RoofInspectionWizard Page = new RoofInspectionWizard();
		}

		private void Edit_Inspection_Click(object sender, RoutedEventArgs e)
		{
			ClaimInspectionWizard Page = new ClaimInspectionWizard(i);

		}

		private void Gutter_Inspection_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Interior_Inspection_Click(object sender, RoutedEventArgs e)
		{

		}


		private void DisplaySignatureBox()
		{
			//

		}

        private void Sign1_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
		
	

	






