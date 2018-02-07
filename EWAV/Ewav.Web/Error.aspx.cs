using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EWAV.Web
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString["AdminEmail"];
            HyperLink hyp = new HyperLink();
            hyp.ID = "hypEmailAdd";
            hyp.NavigateUrl = "mailto:" + email + "&subject=User Authorization Inquiry!";
            hyp.Text = email;
            MainDiv.Controls.Add(hyp);
        }
    }
}