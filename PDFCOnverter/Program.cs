using IronPdf;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCOnverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var Renderer = new IronPdf.HtmlToPdf();
            string id = "SOL-7745";
            var PDF = Renderer.RenderUrlAsPdf("https://lumberjack.mashsoft.co.za/policy-details.php?id=" + id);

           
           // PDFs.Add(PdfDocument.FromFile("B.pdf"));
            Renderer.PrintOptions.Footer.DrawDividerLine = true;
            Renderer.PrintOptions.Footer.FontFamily = "Arial";
            Renderer.PrintOptions.Footer.FontSize = 10;          
            Renderer.PrintOptions.Footer.CenterText = "New National Assurance Company is an authorised financial services provider (FSP:2603) and registered short-term insurance company.";
            
            PDF.SaveAs("PolicyDetails.pdf");
            var PDFs = new List<PdfDocument>();
            PDFs.Add(PdfDocument.FromFile("Page1.pdf"));
            PDFs.Add(PdfDocument.FromFile("PolicyDetails.pdf"));
            PdfDocument pdf = PdfDocument.Merge(PDFs);
            pdf.SaveAs("merged.pdf");

            // This neat trick opens our PDF file so we can see the result
            System.Diagnostics.Process.Start("merged.pdf");
        }
    }
}
