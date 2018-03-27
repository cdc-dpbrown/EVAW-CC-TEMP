using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CDC.ISB.EIDEV.BAL;
using System.IO;

namespace CDC.ISB.EIDEV.Web
{
    public partial class GetSnapshot : System.Web.UI.Page
    {

        private string snapshotGuid;    

        protected void Page_Load(object sender, EventArgs e)
        {

            snapshotGuid = Request.QueryString["snapshotGuid"];

    
            EntityManager em = new EntityManager();

            string CanvasAs64 = em.GetCanvasSnapshot(snapshotGuid);


            // to jpeg         
            byte[] out_Bytes = Convert.FromBase64String(CanvasAs64);


            MemoryStream outStreamJPEG = new MemoryStream(out_Bytes);


            Response.ContentType = "image/jpeg";

            Response.BinaryWrite(out_Bytes);    




        }
    }
}