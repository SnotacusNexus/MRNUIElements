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

       public string Extract(Stream stream, bool all = false)
        {
            string extractedText = string.Empty;
			try
			{
				PdfLoadedDocument loadedDocument = new PdfLoadedDocument(stream);

			if (!all) {
					PdfPageBase page = loadedDocument.Pages[0]; extractedText= page.ExtractText();
               
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
            
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.ToString());
			}
            
           
               return extractedText;
                
              
           
        }
    }
}
