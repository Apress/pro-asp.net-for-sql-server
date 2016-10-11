using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Chapter07.Website;

public partial class Home : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (! Utility.IsUserAuthenticated)
        {
            Response.Redirect(SiteConfiguration.RootUrl);
        }

        // give the user use a few links
        if (Session["IsNewUser"] != null)
        {
            Session.Remove("IsNewUser");
            long profileId = Utility.GetProfile().ProfileID;
            Utility.Domain.SaveFavoriteLink(profileId, "http://news.google.com/", "Google News", false, 5, String.Empty, "news google", -1);
            Utility.Domain.SaveFavoriteLink(profileId, "http://weather.yahoo.com/", "Yahoo Weather", false, 5, String.Empty, "weather yahoo", -1);
            Utility.Domain.SaveFavoriteLink(profileId, "http://www.youtube.com/", "YouTube", false, 5, String.Empty, "video", -1);
        }
    }

    protected void tagCloud_OnTagSelected(object sender, TagCloudEventArgs e)
    {
        lcToday.Visible = false;
        lcThisWeek.Visible = false;
        lcThisMonth.Visible = false;
        taggedLinks.Visible = true;
        taggedLinks.Title = "Tagged with " + e.Token;
        taggedLinks.Token = e.Token;
    }

    protected override PageStatePersister PageStatePersister
    {
        get
        {
            return new SessionPageStatePersister(this);
        }
    }

}
