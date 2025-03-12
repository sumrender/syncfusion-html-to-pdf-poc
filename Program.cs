// See https://aka.ms/new-console-template for more information
using playground.Services;
using Syncfusion.HtmlConverter;
using Syncfusion.Licensing;
using Syncfusion.Pdf;

Main();

void Main()
{
    Console.WriteLine("Generating PDFs...");
    BetaInvoiceHandlebarsTemplates templates = new BetaInvoiceHandlebarsTemplates();
    GeneratePdf("current", templates.GetCurrentHtml());
    GeneratePdf("want", templates.GetWantHtml());
    Console.WriteLine("PDFs generated successfully");
}

void GeneratePdf(string fileName, string html)
{
    HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
    BlinkConverterSettings settings = ConfigureConverterSettings();
    htmlConverter.ConverterSettings = settings;

    PdfDocument document = htmlConverter.Convert(html, string.Empty);

    MemoryStream stream = new MemoryStream();
    document.Save(stream);
    document.Close(true);
    File.WriteAllBytes($"../../../{fileName}.pdf", stream.ToArray());
    Console.WriteLine($"PDF generated successfully: {fileName}.pdf");
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