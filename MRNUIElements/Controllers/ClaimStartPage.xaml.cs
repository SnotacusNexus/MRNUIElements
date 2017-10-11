using MRNNexus_Model;
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

namespace MRNUIElements.Controllers
{
    /// <summary>
    /// Interaction logic for ClaimStartPage.xaml
    /// </summary>
    public partial class ClaimStartPage : Page
    {
        static ServiceLayer s1 = ServiceLayer.getInstance();
        public DTO_Claim Claim { get; set; }

        public static MRNClaim MRNClaim;

        public ClaimStartPage()
        {
            InitializeComponent();
           

        }
        

        private void NewClaimBtn_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new AddPropertyAddress());

        }





        private void AddClaimInsuranceCarrier_Return(object sender, ReturnEventArgs<Object> e)
        {


        }


        private void AddInspection_Return(object sender, ReturnEventArgs<Object> e)
        {



            var inspectionImages = (ObservableCollection<InspectionImage>)e.Result;
            foreach (var inspectionimage in inspectionImages)
                MRNClaim.claimDocs.Add(inspectionimage);

        }

        //private void AddClaim_Return(object sender, ReturnEventArgs<Object> e)
        //{
        //	var inspection = new AddClaimInspection();
        //	inspection.Return += new ReturnEventHandler<object>(AddInspection_Return);
        //	NavigationService.Navigate(inspection);
        //}
        private void AddClaimAdjustment_Return(object sender, ReturnEventArgs<Object> e)
        {
        }


        private void AddInspectionImages_Return(object sender, ReturnEventArgs<Object> e)
        {



            var inspectionImages = (ObservableCollection<InspectionImage>)e.Result;
            foreach (var inspectionimage in inspectionImages)
                MRNClaim.claimDocs.Add(inspectionimage);

        }

        private void OpenEditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CPD = new ClaimPickerPopUp();
                if ((bool)CPD.ShowDialog())

                    //	var claim = s1.ClaimsList.Single(x => x.ClaimID == 37);
                    NavigationService.Navigate(new Controllers.ClaimView(CPD.Claim));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void OptionsBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("They ain't no options fool!");
        }

        private MRNClaim BuildMRNClaim()
        {



            return new MRNClaim();
        }
    }
}
