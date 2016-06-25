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
						TabItem Page = new TabItem();
						this.NavigationService.Navigate(Page.Name = "Lead_Generation");
						break;
						}
					case 1:
						{
						TabItem Page = new TabItem();
						this.NavigationService.Navigate(Page.Name = "Customer_Info");
						break;
						}
					case 2:
						{
						TabItem Page = new TabItem();
						this.NavigationService.Navigate(Page.Name= "Insurance");
						break;
						}
					case 3:
						{
						TabItem Page = new TabItem();
						this.NavigationService.Navigate(Page.Name = "Site_Survey");
						break;
					}
					case 4:
						{
						TabItem Page = new TabItem();
						this.NavigationService.Navigate(Page.Name = "Damage_Assessment");
						break;
					}
					case 5:
						{
						TabItem Page = new TabItem();
						this.NavigationService.Navigate(Page.Name = "Claim_Process");
						break;
					}
					case 6:
					{
						TabItem Page = new TabItem();
						this.NavigationService.Navigate(Page.Name = "Project_At_Hand");
						break;
					}
					case 7:
					{
						TabItem Page = new TabItem();
						this.NavigationService.Navigate(Page.Name = "Upgrades");
						break;
					}
					case 8:
					{
						TabItem Page = new TabItem();
						this.NavigationService.Navigate(Page.Name = "Finalize_Agreement");
						break;
					}
				}
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
	}
}
		
	

	






