


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

namespace MRNUIElements.Controllers
{
    /// <summary>
    /// Interaction logic for WebBrowser.xaml
    /// </summary>
    public partial class WebBrowser : Page
    {
      
        static ServiceLayer s1 = ServiceLayer.getInstance();
        static WebBrowser wb;
        public DTO_Claim Claim { get; set; }
        public WebBrowser()
        {
            InitializeComponent();

          

          
          

        }

        public static WebBrowser GetPageInstance()
        {
            if (wb == null)
                wb = new WebBrowser();
            return wb;

        }

      async private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var cpp = new ClaimPickerPopUp();
            if (Claim == null)
                if ((bool)cpp.ShowDialog())
                    Claim = cpp.Claim;

            await s1.GetAllScopes();
            Claim = s1.ClaimsList.First(x => x.ClaimID == s1.ScopesList.First(y => y.ScopeTypeID == 2).ClaimID);
            var a = new ScopeViewer(Claim);

            var b = new MenuPage();

            try
            {
                if(Claim != null)
                this.MailBox.Navigate(await GetUrlForEV(Claim));
            }
            catch(Exception ex)
            {
                this.MailBox.Navigate("https://www.gmail.com");
            }
            this.FileBox.Navigate("file://c:\\");
            this.DropBox.Navigate("http://www.dropbox.com");
           
            this.DataSet.Navigate( a);
        
            this.xactimateBrowser.Navigate("https://xactimate.com/xo/");
         
        }
        async private Task<bool> IsDataContext(string addresstosearch)
        {
            await s1.GetAllAddresses();
            return (bool)s1.AddressesList.Exists(x => x.Address == addresstosearch) ? true : false;
            /**/
        }

        async private Task<string> GetUrlForEV(object addresstosearch)
        {
            if ((Type)addresstosearch == typeof(string))
            {
                await s1.GetAllAddresses();


                if (!await IsDataContext((string)addresstosearch)) return "https://mail.google.com/mail/u/0/#search/" + ((string)addresstosearch).Replace(' ', '+');
                else
                {
                    try
                    {
                        var b = s1.ClaimDocumentsList.Find(z => z.DocTypeID == 3 && z.ClaimID == s1.ClaimsList.Find(x => x.BillingID == s1.AddressesList.Find(y => y.Address == ((string)addresstosearch)).AddressID).ClaimID);
                        return b.FilePath + b.FileName + b.FileName + b.FileExt;
                    }
                    catch (NullReferenceException nre)
                    {
                        return "./ResourceFiles/MRN CONTRACTING LOGO.png";
                    }



                }
            }
            else
            {
                try
                {
                    var b = s1.ClaimDocumentsList.Find(z => z.DocTypeID == 3 && z.ClaimID == ((DTO_Claim)addresstosearch).ClaimID);
                    return b.FilePath + b.FileName + b.FileName + b.FileExt;
                }
                catch (NullReferenceException nre)
                {
                    return "./ResourceFiles/MRN CONTRACTING LOGO.png";
                }
            }
        }
    }
}

