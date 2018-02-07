namespace EWAV.Web.Services
{
    public class MxNGridRow
    {
        private string strataValue1;
        private int width1;
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
        public int width
        {
            get
            {
                return this.width1;
            }
            set
            {
                this.width1 = value;
            }
        }
    }
}