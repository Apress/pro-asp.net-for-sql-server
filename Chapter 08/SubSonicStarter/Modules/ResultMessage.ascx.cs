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

/// <summary>
/// This very simple control displays a nicely-formatted result, anywhere on a page
/// </summary>
public partial class ResultMessage : System.Web.UI.UserControl {
    protected void Page_Load(object sender, EventArgs e) {

    }
    public void ShowSuccess(string message) {
        tblResult.Visible = true;
        trSuccess.Visible = true;
        trFail.Visible = false;
				lblSuccess.Text = message + " - " + DateTime.UtcNow.ToString();
    }
    public void ShowFail(string message) {
        tblResult.Visible = true;
        trSuccess.Visible = false;
        trFail.Visible = true;
        lblFail.Text = message + " - " + DateTime.UtcNow.ToString();

    }
    protected string GetPath() {
        string sPath = Request.ApplicationPath;
        if (sPath == "/") {
            sPath = "";
        }
        return sPath;
    }
}
