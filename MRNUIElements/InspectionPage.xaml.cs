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
using System.Collections.ObjectModel;

namespace MRNUIElements
{
    /// <summary>
    /// Interaction logic for InspectionPage.xaml
    /// </summary>
    public partial class InspectionPage : Page
    {
        static ServiceLayer s = ServiceLayer.getInstance();
        DTO_Claim claim = s.Claim;
        public ObservableCollection<DTO_Claim> claims = new ObservableCollection<DTO_Claim>();
        public ObservableCollection<DTO_LU_RidgeMaterialType> ridgematerialtypes  = new ObservableCollection<DTO_LU_RidgeMaterialType>();
        public ObservableCollection<DTO_LU_ShingleType> shingletypes = new ObservableCollection<DTO_LU_ShingleType>();

        public InspectionPage(DTO_Claim claim = null)
        {
            if (claim == null)
                claim = this.claim;
            InitializeComponent();
            Init();
            foreach (DTO_Claim c in s.ClaimsList)
            {
                claims.Add(c);

            }
            foreach (DTO_LU_RidgeMaterialType t in s.RidgeMaterialTypes)
            {
                ridgematerialtypes.Add(t);

            }
            foreach (DTO_LU_ShingleType r in s.ShingleTypes)
            {
                shingletypes.Add(r);

            }
            ClaimID.ItemsSource = claims;
            ShingleType.ItemsSource = shingletypes;
            RidgeMaterialTypeCombo.ItemsSource = ridgematerialtypes;


            AddInspection((DTO_Claim)ClaimID.SelectedItem, 1, 1, DateTime.Now, true, true, true, true, true, true, true, 0, true, true, true, true, true, true, true, true, true, true, true, 5, "");
        }
         
      async  public void AddInspection(DTO_Claim claim, int ridgeMatType, int ShingleType, DateTime datetime, bool Skylights, bool leaks, bool gutteramage, bool DrivewayDamage, bool magneticrollers, bool IceWaterShield, bool EmergencyRepair, double EmergRepAmt, bool QAQC, bool protectLS, bool RemoveTrash, bool FurnishPermit, bool CoverPool, bool InteriorDamage, bool ExteriorDamage, bool LightningProtection, bool TearOff, bool Satelite, bool SolarPanels, int RoofAge, string comments)
        {
           
        
            await s.GetInspectionsByClaimID(this.claim);
            if (s.Inspection == null)
            {
                await s.AddInspection(new DTO_Inspection
                {
                    ClaimID=10,
                    CoverPool = false,
                    MagneticRollers = true,
                    InspectionDate = DateTime.Now,
                    ShingleTypeID = 1,
                    SkyLights = true,
                    Leaks = false,
                    GutterDamage = false,
                    DrivewayDamage = false,
                    IceWaterShield = true,
                    EmergencyRepair = false,
                    EmergencyRepairAmount = 0,
                    QualityControl = true,
                    ProtectLandscaping = true,
                    RemoveTrash = true,
                    FurnishPermit = true,
                    InteriorDamage = false,
                    ExteriorDamage = false,
                    RoofAge = 10,
                    Satellite = false,
                    TearOff = true,
                    SolarPanels = false,
                    RidgeMaterialTypeID = 1,
                    LightningProtection = false,
                    Comments = "none"


                });

            }

           DTO_Plane p = new DTO_Plane();


            p.SquareFootage = 2500;
            p.RidgeLength = 65;
            p.RakeLength = 80;
            p.Pitch = 12;
            p.Hip = 45;
			p.Valley = 45;
			p.GroupNumber = 1;
            p.ItemSpec = "EV ";
            p.EaveLength = 95;
            p.InspectionID = s.InspectionsList[0].InspectionID;
            p.NumberDecking = int.Parse("2");
            p.NumOfLayers = int.Parse("1");
            p.PlaneTypeID = 15;
            p.StepFlashing = 20;

            await s.AddPlane(p);
        }
    
       async public void Init()
        {
            await s.GetAllClaims();
        }

        private void ShingleType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void claimIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RidgeMaterialTypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    }
