<%@ Import namespace="System.Web.Configuration"%>
<%@ Import namespace="System.Web.Profile"%>
<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    void Profile_MigrateAnonymous(object sender, ProfileMigrateEventArgs e)
    {
        ProfileCommon anonymousProfile = Profile.GetProfile(e.AnonymousID);
        string defaultFontSize = "10";
        if (defaultFontSize.Equals(Profile.FontSize) &&
            !defaultFontSize.Equals(anonymousProfile.FontSize))
        {
            Profile.FontSize = anonymousProfile.FontSize;
        }

        // remove the anonymous user, profile and cookie
        Membership.DeleteUser(e.AnonymousID, true);
        ProfileManager.DeleteProfile(e.AnonymousID);
        AnonymousIdentificationModule.ClearAnonymousIdentifier();
    }

</script>
