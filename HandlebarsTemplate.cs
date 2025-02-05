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
        <div style='width: 100%; height: 100%; font-size: 8px;'>
            <h1>1 {{CompanyName}}</h1>
            <h1>2 {{CompanyName}}</h1>
            <h1>3 {{CompanyName}}</h1>
            <h1>4 {{CompanyName}}</h1>
        </div>
        ";

        private string BodyHtml = @"
          <div>
            <h1>Body Item name</h1>
            <h1>1 {{ItemName}}</h1>
            <h1>2 {{ItemName}}</h1>
            <h1>3 {{ItemName}}</h1>
            <h1>4 {{ItemName}}</h1>
            <h1>5 {{ItemName}}</h1>
            <h1>6 {{ItemName}}</h1>
            <h1>7 {{ItemName}}</h1>
            <h1>8 {{ItemName}}</h1>
            <h1>9 {{ItemName}}</h1>
            <h1>10 {{ItemName}}</h1>
            <h1>11 {{ItemName}}</h1>
            </div>
        ";
    }
}
