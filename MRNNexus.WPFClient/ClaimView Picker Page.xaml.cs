using MRNNexus.WPFClient.Controllers;
using MRNNexusDTOs;

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

namespace MRNNexus.WPFClient
{
    /// <summary>
    /// Interaction logic for ClaimView_Picker_Page.xaml
    /// </summary>
    public partial class ClaimView_Picker_Page : Page
    {
        public DTO_Employee EmployeeToView = new DTO_Employee();
        ServiceLayer s1 = ServiceLayer.getInstance();

      //  public ObservableCollection<ClaimViewLayout> MyClaimView = new ObservableCollection<ClaimViewLayout>(GetEmployeeClaimsForView(EmployeeToView));

       // public ObservableCollection<ClaimViewLayout> GetEmployeeClaimsForView(DTO_Employee employeeToView)
      //  {

       //     Task.Run(async () => { await s1.GetOpenClaimsBySalespersonID(employeeToView); });


    //    }

        public ClaimView_Picker_Page()
        {
            InitializeComponent();
        }
    }

    public class ClaimViewLayout 
    {
        


        public string FullName { get; set; }
        public string Address { get; set; }
        public string CSZ { get; set; }
        public string ContactInfo { get; set; }
        public string InsuranceCompany { get; set; }
        public string ClaimNumber { get; set; }
        public string CurrentStatus { get; set; }



    }
}
