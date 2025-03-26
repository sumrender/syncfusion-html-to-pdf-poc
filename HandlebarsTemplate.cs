namespace playground.Services
{
    using HandlebarsDotNet;

    public class BetaInvoiceHandlebarsTemplates
    {
        public HandlebarsTemplate<object, object> SolnTemplate { get; private set; }

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
            SolnTemplate = Handlebars.Compile(GetFileContent("hbs/soln.hbs"));
        }


        public string GetSolnHtml()
        {
            return SolnTemplate(new{});
        }
    }
}
