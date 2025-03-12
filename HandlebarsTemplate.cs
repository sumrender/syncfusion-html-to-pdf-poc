namespace playground.Services
{
    using System.Reflection;
    using HandlebarsDotNet;

    public class BetaInvoiceHandlebarsTemplates
    {
        public HandlebarsTemplate<object, object> CurrentTemplate { get; private set; }

        public HandlebarsTemplate<object, object> WantTemplate { get; private set; }

        public string headerRowOne = "";

        public string headerRowTwo = "";

        public string table = "";

        string GetFileContent(string path)
        {
            string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../.."));
            string templatePath = Path.Combine(projectRoot, path);

            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException($"Template file not found: {templatePath}");
            }

            return File.ReadAllText(templatePath);
        }


        public BetaInvoiceHandlebarsTemplates()
        {
            // set data
            headerRowOne = GetFileContent("hbs/header-row-one.hbs");
            headerRowTwo = GetFileContent("hbs/header-row-two.hbs");
            table = GetFileContent("hbs/table.hbs");

            // set templates
            CurrentTemplate = Handlebars.Compile(GetFileContent("hbs/current.hbs"));
            WantTemplate = Handlebars.Compile(GetFileContent("hbs/want.hbs"));
        }

        public string GetCurrentHtml()
        {
            return CurrentTemplate(new
            {
                HeaderRowOne = headerRowOne,
                HeaderRowTwo = headerRowTwo,
                Table = table
            });
        }

        public string GetWantHtml()
        {
            return WantTemplate(new
            {
                HeaderRowOne = headerRowOne,
                HeaderRowTwo = headerRowTwo,
                Table = table
            });
        }
    }
}
