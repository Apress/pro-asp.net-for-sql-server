using System;
using System.Web.UI;
using Apress.Chapter04;

public partial class AjaxExample : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.ClientScript.IsClientScriptIncludeRegistered("prototype"))
        {
            Page.ClientScript.RegisterClientScriptInclude("prototype", Utility.GetRelativeSiteUrl("~/Scripts/prototype-1.5.0rc0.js"));
        }
        if (!Page.ClientScript.IsClientScriptIncludeRegistered("scriptaculous"))
        {
            Page.ClientScript.RegisterClientScriptInclude("scriptaculous", Utility.GetRelativeSiteUrl("~/Scripts/scriptaculous-1.6.2.js"));
        }
    }
}
