using System.ServiceModel.DomainServices.Server;

namespace EWAV.Web.Services
{
  
    public partial class TwoByTwoDomainService : DomainService
    {
        public class TextBlockConfig
        {
            public int ColumnNumber;
            public string DisplayValue;
            public int RowNumber;
            public TextBlockConfig(string displayValue, int rowNumber, int columnNumber)
            {
                this.DisplayValue = displayValue;
                this.RowNumber = rowNumber;
                this.ColumnNumber = columnNumber;
            }
        }
    }
}