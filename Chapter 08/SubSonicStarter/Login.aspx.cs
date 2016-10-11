using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SubSonic.Utilities;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void NewRegistration(object sender, EventArgs e) {
        string redir = Utility.GetParameter("ReturnUrl");
        if (redir != string.Empty) {
			Response.Redirect(redir, false);
        } else {
			Response.Redirect("default.aspx", false);
        }
    }
}
