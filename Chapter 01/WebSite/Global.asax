<%@ Import namespace="System.Web.Profile"%>
<%@ Import namespace="System.Diagnostics"%>
<%@ Application Language="C#" %>

<script Language="C#" RunAt="server">
    
    public void Application_Start(object sender, EventArgs e)
    {
        if (Roles.Enabled)
        {
            String[] requiredRoles = { "Admin", "Users", "Editors" };
            foreach (String role in requiredRoles)
            {
                if (!Roles.RoleExists(role))
                {
                    Roles.CreateRole(role);
                }
            }
            string[] users = Roles.GetUsersInRole("Admin");
            if (users.Length == 0)
            {
                // create admin user
                MembershipCreateStatus status;
                Membership.CreateUser("admin", "easy12guess", "admin@localhost",
                                      "Favorite color?", "offwhite", true, out status);
                if (MembershipCreateStatus.Success.Equals(status))
                {
                    Roles.AddUserToRole("admin", "Admin");
                }
                else
                {
                    LogMessage("Unable to create admin user: " + status, true);
                }
            }
        }
    }

    public void Profile_OnMigrateAnonymous(object sender, ProfileMigrateEventArgs args)
    {
        ProfileCommon anonProfile = Profile.GetProfile(args.AnonymousID);

        // migrate anonymous user properties to the authenticated user
        if (String.IsNullOrEmpty(Profile.FirstName))
        {
            Profile.FirstName = anonProfile.FirstName;
        }
        if (String.IsNullOrEmpty(Profile.LastName))
        {
            Profile.LastName = anonProfile.LastName;
        }
        if (DateTime.MinValue.Equals(Profile.BirthDate))
        {
            Profile.BirthDate = anonProfile.BirthDate;
        }

        // remove the anonymous user.
        Membership.DeleteUser(args.AnonymousID, true);
    }

    private void LogMessage(string message, bool isError)
    {
        if (!EventLog.SourceExists(EventSource))
        {
            EventLog.CreateEventSource(EventSource, "Application");
        }
        if (isError)
        {
            EventLog.WriteEntry(EventSource, message, EventLogEntryType.Error);
        }
        else
        {
            EventLog.WriteEntry(EventSource, message, EventLogEntryType.Information);
        }
    }

    public string EventSource
    {
        get
        {
            return "Chapter01Website";
        }
    }

</script>