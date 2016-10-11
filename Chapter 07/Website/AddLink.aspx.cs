using System;
using System.Web.UI;
using Chapter07.Website;

public partial class AddLink_aspx : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["url"]))
            {
                LinkEditControl1.Url = Request.QueryString["url"];
            }
            if (!String.IsNullOrEmpty(Request.QueryString["title"]))
            {
                LinkEditControl1.Title = Request.QueryString["title"];
            }
        }
    }

    protected void LinkEditControl1_Saved(object sender, EventArgs e)
    {
        Response.Redirect(SiteConfiguration.HomeUrl, true);
    }
}
