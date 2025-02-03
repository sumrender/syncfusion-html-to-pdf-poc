// See https://aka.ms/new-console-template for more information
using playground.Services;
using Syncfusion.HtmlConverter;
using Syncfusion.Licensing;
using Syncfusion.Pdf;

GeneratePdf();

void GeneratePdf()
{
    Console.WriteLine("Generating Pdf...");
    BetaInvoiceHandlebarsTemplates templates = new BetaInvoiceHandlebarsTemplates();
    string body = templates.Invoice(new {
        ItemName = "Item 1",
    });
    string header = templates.InvoiceHeader(new {
        CompanyName = "Syncfusion",
    });

    HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
    BlinkConverterSettings settings = ConfigureConverterSettings();
    settings.Margin.Top = htmlConverter.GetHtmlBounds(header, string.Empty).Height - 380;
    settings.HtmlHeader = header;
    htmlConverter.ConverterSettings = settings;

    PdfDocument document = htmlConverter.Convert(body, string.Empty);

    MemoryStream stream = new MemoryStream();
    document.Save(stream);
    document.Close(true);
    File.WriteAllBytes("../../../Output.pdf", stream.ToArray());

    Console.WriteLine("PDF generated successfully");
}


BlinkConverterSettings ConfigureConverterSettings()
{
    //Set command line arguments to run without sandbox.
    // https://help.syncfusion.com/document-processing/pdf/conversions/html-to-pdf/net/troubleshooting#failed-to-launch-chromium-running-as-root-without-no-sandbox-is-not-supported
    BlinkConverterSettings settings = new BlinkConverterSettings();
    settings.CommandLineArguments.Add("--no-sandbox");
    settings.CommandLineArguments.Add("--disable-setuid-sandbox");
    settings.EnableAutoScaling = true;
    settings.MediaType = MediaType.Print;

    return settings;
}