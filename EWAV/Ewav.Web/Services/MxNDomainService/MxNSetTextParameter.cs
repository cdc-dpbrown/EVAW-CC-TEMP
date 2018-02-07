namespace EWAV.Web.Services
{
    public class MxNSetTextParameter
    {
        private string fontWeight1;
        private string strataValue1;
        private TwoByTwoDomainService.TextBlockConfig textBlockConfig1;
        public string fontWeight
        {
            get
            {
                return this.fontWeight1;
            }
            set
            {
                this.fontWeight1 = value;
            }
        }
        public string strataValue
        {
            get
            {
                return this.strataValue1;
            }
            set
            {
                this.strataValue1 = value;
            }
        }
        public EWAV.Web.Services.TwoByTwoDomainService.TextBlockConfig textBlockConfig
        {
            get
            {
                return this.textBlockConfig1;
            }
            set
            {
                this.textBlockConfig1 = value;
            }
        }
    }
}