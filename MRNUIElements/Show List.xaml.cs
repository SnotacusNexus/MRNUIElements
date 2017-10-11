using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MRNUIElements.Models;
using static MRNUIElements.ViewModels.ViewModelBase;
using static MRNUIElements.Models.ScopeModel;
//using static MRNUIElements.Models.Calculations;
using static MRNUIElements.Models.TransactionModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics.Tracing;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Data;
using System.ComponentModel;
using static MRNUIElements.MainWindow;
using static MRNUIElements.CompoundDataGridRow;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.Windows.Controls.Grid;
using Microsoft.Windows.Themes;

namespace MRNUIElements.ViewModels
{


    public partial class ShowList : Page
    {

        static public ScopeModel sm = ScopeModel.getInstance();
        static public ObservableCollection<ScopeModel> ScopeList = ScopeModel.lgetInstance();
        static public ObservableCollection<CompoundDataGridRow> cdr = CompoundDataGridRow.lgetInstance();
        static public CompoundDataGridRow CDGR = CompoundDataGridRow.getInstance();

        System.Windows.Forms.PrintPreviewDialog previewDlg = new System.Windows.Forms.PrintPreviewDialog();
        PrintDocument pd = new PrintDocument();
      
        public ShowList()
        {


            InitializeComponent();
            scopeModelDataGrid.Visibility = Visibility.Visible;
            scopeModelDataGrid.Width = 1250;
            if (this.DataContext == null)
                this.DataContext = this;

            this.DataContext = this;
            if (scopeModelDataGrid.DataContext == null)
                scopeModelDataGrid.DataContext = sm;
            if (scopeModelDataGrid1.DataContext == null)
                scopeModelDataGrid1.DataContext = sm;
            if (DesignOnlyAttribute.Yes.IsDesignOnly)
            {
                int j = 0;
                foreach (var s in ScopeModel.lgetInstance())
                    scopeModelDataGrid.Items.Add(new CompoundDataGridRow(j++));
            }
          
            scopeModelDataGrid1.ItemsSource = ScopeList;
            if (!scopeModelDataGrid1.HasItems)
                foreach (var s in ScopeModel.lgetInstance())
                    scopeModelDataGrid1.Items.Add(s);
            //  hdr.Header = "Monthly Oulook " + DateTime.Now.Month.ToString() + " " + DateTime.Now.Year.ToString()"; 








        }
        private void Print()
        {
            // double i = listBox.Height; 
            // VisualContainer vc = new VisualContainer();
            // var fd = new FlowDocument();
            // PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
            // var g = listBox.LayoutTransform.CloneCurrentValue();
            // listBox.Height = 12000;



            // listBox.HorizontalAlignment = HorizontalAlignment.Left;
            // listBox.VerticalAlignment = VerticalAlignment.Top;
            // listBox.LayoutTransform = new ScaleTransform(1, 1);

            //System.Windows.Size pageSize = new System.Windows.Size(950, 1150);
            //listBox.Measure(pageSize);

            // listBox.Arrange(new Rect(20,20, pageSize.Height , pageSize.Width));
            // listBox.Height = i;




            //PrintSettings s = new PrintSettings();
            //s.PrintScaleOption = PrintScaleOptions.FitAllColumnsonOnePage;
            //s.PrintPageOrientation = PrintOrientation.Landscape;

            pd.PrintPage += new PrintPageEventHandler(Pd_PrintPage);
            previewDlg.Document = pd;
            previewDlg.Show();
           

            //    pd.Print();

            return;

        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            System.Windows.Controls.PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
            double scalex = 1;
            double scaley = 1;
            printDlg.PrintTicket.PageOrientation = System.Printing.PageOrientation.Landscape;
         
            double w = scopeModelDataGrid1.Width;

            double h = scopeModelDataGrid1.Height;
            var z = scopeModelDataGrid1.LayoutTransform;
           
            System.Windows.Size gridsize = new System.Windows.Size(w, h);
           

            System.Windows.Size pageSize = new System.Windows.Size(printDlg.PrintableAreaWidth, printDlg.PrintableAreaHeight);
         
            scopeModelDataGrid1.LayoutTransform = new ScaleTransform((pageSize.Width / w) * scalex, (pageSize.Height / h) * scaley);
           scopeModelDataGrid1.Measure(pageSize);
            scopeModelDataGrid1.Arrange(new Rect(15, 10, pageSize.Width + 0, pageSize.Height + 90));
            printDlg.PrintVisual(scopeModelDataGrid1, "Monthly Oulook " + DateTime.Now.Month.ToString() + " " + DateTime.Now.Year.ToString());
            scopeModelDataGrid1.LayoutTransform = z;

	
            return;

            // ypos = 1;
            // float pageheight = e.MarginBounds.Height;
            // //Create a Graphics object
            // Graphics g = e.Graphics;
            // //Get installed fonts
            // InstalledFontCollection ifc =
            // new InstalledFontCollection();
            // //Get font families
            //System.Drawing.FontFamily[] ffs = ifc.Families;
            // //Draw string on the paper
            // while (ypos + 60 < pageheight &&
            // fontposition < ffs.GetLength(0))
            // {
            //     //Get the font name 
            //     Font f =
            //     new Font(ffs[fontposition].GetName(0), 25);
            //     //Draw string
            //     g.DrawString(ffs[fontposition].GetName(0), f,
            //     new SolidBrush(System.Drawing.Color.Black), 1, ypos);
            //     fontposition = fontposition + 1;
            //     ypos = ypos + 60;
            // }
            // if (fontposition < ffs.GetLength(0))
            // {
            //Has more pages??
            //  e.HasMorePages = true;
            //  }
        }

       
        private void scopeModelDataGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            scopeModelDataGrid.Visibility = Visibility.Collapsed;
            scopeModelDataGrid1.Visibility = Visibility.Visible;
            Print();


        }

        private void scopeModelDataGrid1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {	  if (scopeModelDataGrid.Visibility == Visibility.Visible)
				scopeModelDataGrid.Visibility = Visibility.Collapsed;
			else scopeModelDataGrid.Visibility = Visibility.Visible;
			if (scopeModelDataGrid1.Visibility == Visibility.Visible)
				scopeModelDataGrid1.Visibility = Visibility.Collapsed;
			else scopeModelDataGrid1.Visibility = Visibility.Visible;
			//scopeModelDataGrid1.Visibility = Visibility.Visible;
            Print();
        }

        private void scopeModelDataGrid1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Print();
        }
    }



}
