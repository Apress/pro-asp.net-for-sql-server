using System;
using System.Web.UI;
using Chapter07.Website;

public partial class CreateNewAccount : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CreateUserWizard1.FinishDestinationPageUrl = SiteConfiguration.HomeUrl;
        CreateUserWizard1.ContinueDestinationPageUrl = SiteConfiguration.HomeUrl;
    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        Session["IsNewUser"] = true;
    }
}
