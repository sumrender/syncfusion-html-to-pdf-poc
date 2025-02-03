namespace playground.Services
{
    using HandlebarsDotNet;

    public class BetaInvoiceHandlebarsTemplates
    {
        public HandlebarsTemplate<object, object> InvoiceHeader { get; private set; }

        public HandlebarsTemplate<object, object> Invoice { get; private set; }

        public BetaInvoiceHandlebarsTemplates()
        {
            InvoiceHeader = Handlebars.Compile(HeaderHtml);
            Invoice = Handlebars.Compile(BodyHtml);
        }
        
        private string HeaderHtml = @"
        <div style='width: 100%; height: 100%; font-size: 10px;'>
            <h1>1 {{CompanyName}}</h1>
            <h1>2 {{CompanyName}}</h1>
            <h1>3 {{CompanyName}}</h1>
            <h1>4 {{CompanyName}}</h1>
            <h1>5 {{CompanyName}}</h1>
            <h1>6 {{CompanyName}}</h1>
            <h1>7 {{CompanyName}}</h1>
        </div>
        ";

        private string BodyHtml = @"
          <div>
            <h1>Body Item name</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            <h1>{{ItemName}}</h1>
            </div>
        ";
    }
}
