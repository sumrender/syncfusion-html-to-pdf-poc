// See https://aka.ms/new-console-template for more information
using playground.Services;
using Syncfusion.HtmlConverter;
using Syncfusion.Licensing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

Main();

void Main()
{
    Console.WriteLine("Generating PDFs...");
    BetaInvoiceHandlebarsTemplates templates = new BetaInvoiceHandlebarsTemplates();
    GeneratePdf("soln", templates.GetSolnHtml());
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
    BlinkConverterSettings settings = new BlinkConverterSettings();
    settings.CommandLineArguments.Add("--no-sandbox");
    settings.CommandLineArguments.Add("--disable-setuid-sandbox");

    settings.Margin.Top = 32;
    settings.Margin.Left = 52;
    settings.Margin.Right = 29;
    settings.EnableAutoScaling = true;
    settings.MediaType = MediaType.Print;
    settings.EnableJavaScript = true;
    settings.AdditionalDelay = 1000;

    return settings;
}