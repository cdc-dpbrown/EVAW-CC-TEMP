using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EWAV;
using EWAV.BAL;

namespace EWAV.Web
{
    public partial class CheckXml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            EntityManager em = new EntityManager();
            CanvasDto dto = em.LoadCanvas(Convert.ToInt32(TextBox1.Text));
             
                
            TextArea1.InnerText = "";
            TextArea1.InnerText = dto.XmlData.ToString();

             //     Response.Write(  dto.XmlData.ToString()      )    ;


        }
    }
}