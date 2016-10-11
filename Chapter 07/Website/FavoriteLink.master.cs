using System;
using System.Web.Security;
using System.Web.UI;
using Chapter07.Website;

public partial class FavoriteLink_master : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hlAdmin.Visible = Roles.IsUserInRole("Admin");
        //string key = "updateLinks";
        //if (!Page.ClientScript.IsClientScriptIncludeRegistered(key))
        //{
        //    string url = Utility.GetRelativeSiteUrl("~/FavoriteLink.js");
        //    Page.ClientScript.RegisterClientScriptInclude(GetType(), key, url);
        //}
    }
}
