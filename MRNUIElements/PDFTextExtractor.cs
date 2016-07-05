using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Functions;
using Syncfusion.Pdf.Exporting;
using Syncfusion.Compression.Zip;
using Syncfusion.Pdf.Native;
using Syncfusion.PdfViewer;
using System.Windows.Forms;
using System.IO;



namespace MRNUIElements
{

    public partial class PDFTextExtractor
    {

       public string Extract(string filename, bool all = false)
        {
            string extractedText = string.Empty;
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(filename);
            if (!all)
            {
               
                PdfPageBase page = loadedDocument.Pages[0];
              
               extractedText= page.ExtractText();
               
            }
            else
            {
                PdfLoadedPageCollection loadedPages = loadedDocument.Pages;
                foreach (PdfLoadedPage lpage in loadedPages)
                {
                    extractedText += lpage.ExtractText();
                }

            }
            loadedDocument.Close(true);
            return extractedText;
        }
    }
}
