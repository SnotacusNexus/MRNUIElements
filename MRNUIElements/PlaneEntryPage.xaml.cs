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
using MRNUIElements.Controllers;
using MRNUIElements.Models;
using MRNUIElements;

namespace MRNUIElements.Planes
{
    /// <summary>
    /// Interaction logic for PlaneEntryPage.xaml
    /// </summary>
    public partial class PlaneEntryPage : Page
    {
        static ServiceLayer s = ServiceLayer.getInstance();
        DTO_Claim claim = s.Claim;
        public PlaneEntryPage(DTO_Claim claim=null)
        {

            if (claim == null)
                claim = this.claim;

            InitializeComponent();
        }
   
        async public void AddPlane()
        {
            DTO_Plane pl = new DTO_Plane();
            pl.EaveHeight = int.Parse(eaveHeightTextBox.Text);
            pl.EaveLength = int.Parse(eaveLengthTextBox.Text);
            pl.RakeLength = int.Parse(rakeLengthTextBox.Text);
            pl.RidgeLength = int.Parse(ridgeLengthTextBox.Text);
            pl.SquareFootage = int.Parse(squareFootageTextBox.Text);
            pl.ThreeAndOne = int.Parse("0");
            pl.FourAndUp = int.Parse("0");
            pl.HipValley = int.Parse(hipValleyTextBox.Text);
            pl.GroupNumber = int.Parse(groupNumberTextBox.Text);
            pl.ItemSpec = itemSpecTextBox.Text;
            pl.NumberDecking = int.Parse(numberDeckingTextBox.Text);
            pl.NumOfLayers = int.Parse(numOfLayersTextBox.Text);
            pl.Pitch = int.Parse(pitchTextBox.Text);
            pl.PlaneTypeID = int.Parse(pitchTextBox.Text);
            pl.StepFlashing = int.Parse(stepFlashingTextBox.Text);
            if (s.Inspection == null)
            {


            }
            await s.AddPlane(pl);



        }
    }
}
