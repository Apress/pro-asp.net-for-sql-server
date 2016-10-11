using System;
using System.Web.UI;
using Chapter07.Website;

public partial class Controls_HeaderNavigation : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Utility.IsUserAuthenticated)
        {
            hlHome.NavigateUrl = SiteConfiguration.HomeUrl;
        }
    }
}
