using System;
using System.Web.Profile;
using System.Web.UI;

public partial class ProfilesExporter : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AddHeader("content-disposition", "attachment; filename=CustomProfiles.csv");
        Response.ContentType = "text/csv";
        ProfileInfoCollection profiles =
            ProfileManager.GetAllProfiles(ProfileAuthenticationOption.Authenticated);
        foreach (ProfileInfo profile in profiles)
        {            
            ProfileCommon pc = Profile.GetProfile(profile.UserName);
            Response.Write(String.Format("{0},{1},{2}\n", 
                pc.UserName, pc.FontSize, pc.ProfileGroup));
        }
        Response.End();
    }
}
