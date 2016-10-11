using System;
using System.Web.UI;

public partial class Site : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Utility.IsUserAuthenticated)
        {
            if (!Page.ClientScript.IsClientScriptIncludeRegistered("jquery.js"))
            {
                Page.ClientScript.RegisterClientScriptInclude("jquery.js",
                  Utility.GetRelativeSiteUrl("~/Thickbox/jquery.js"));
            }
            if (!Page.ClientScript.IsClientScriptIncludeRegistered("thickbox.js"))
            {
                Page.ClientScript.RegisterClientScriptInclude("thickbox.js",
                  Utility.GetRelativeSiteUrl("~/Thickbox/thickbox.js"));
            }
            if (!Page.ClientScript.IsClientScriptBlockRegistered("loadingUrl"))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "loadingUrl", "loadingUrl = '" +
                 Utility.GetRelativeSiteUrl("~/ThickBox/loadingAnimation.gif") + "';", true);
            }
        }
    }
}
