using System;
using System.Web.UI;
using Chapter07.Website;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Utility.IsUserAuthenticated)
        {
            Response.Redirect(SiteConfiguration.HomeUrl);
        }
    }
}
