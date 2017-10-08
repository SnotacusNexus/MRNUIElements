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
using System.Net.Http;

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

                if (!all)
                {
                    PdfPageBase page = loadedDocument.Pages[0]; extractedText = page.ExtractText();

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

        public string Extract(string file, bool all = false)
        {
            string extractedText = string.Empty;
            try
            {
                PdfLoadedDocument loadedDocument = new PdfLoadedDocument(file);

                if (!all)
                {
                    PdfPageBase page = loadedDocument.Pages[0]; extractedText = page.ExtractText();

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

        async public Task<Stream> DownloadFile(string url)
        {
            using (var client = new HttpClient())
            {
                var stream = await client.GetStreamAsync(url);

                // OR to get the content of the file as you do now
                var data = await client.GetByteArrayAsync(url);


                return stream;
                // do whatever you need to do with your file here
            }
        }
    }
}
//// Load an existing PDF document.

//PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileName);

//// Loading page collections

//PdfLoadedPageCollection loadedPages = loadedDocument.Pages;

//string extractedText = string.Empty;

//// Extract text from existing PDF document pages

//foreach (PdfLoadedPage loadedPage in loadedPages)

//{

//extractedText += loadedPage.ExtractText();

//}

//// Close the document.

//loadedDocument.Close(true);

    