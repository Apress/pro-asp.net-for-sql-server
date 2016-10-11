using System;
using System.Diagnostics;
using System.Web;
using System.Web.Profile;
using System.Web.Security;

namespace Chapter07.Website
{
    /// <summary>
    /// Summary description for Global
    /// </summary>
    public class Global : HttpApplication
    {

        public Global()
        {
        }

        public void Application_Start(object sender, EventArgs e)
        {
            if (SiteConfiguration.IsSelfHosting)
            {
                DataServiceHost.Instance.StartDataService();
            }
            ReviewUsersAndRoles();
        }

        public void Application_Stop(object sender, EventArgs e)
        {
            if (SiteConfiguration.IsSelfHosting)
            {
                DataServiceHost.Instance.StopDataService();
            }
        }

        public void Application_Error(object sender, EventArgs e)
        {
            if (!HttpContext.Current.Request.Url.ToString().Contains(SiteConfiguration.ErrorUrl))
            {
                Exception lastError = Server.GetLastError();
                if (lastError.InnerException != null)
                {
                    lastError = lastError.InnerException;
                }
                Trace.WriteLine(lastError.Message);
                if (HttpContext.Current.Session != null)
                {
                    HttpContext.Current.Session.Add("LastError", lastError);
                    Debug.WriteLine("Error: " + lastError.Message);
                }

                HttpContext.Current.Response.Redirect(SiteConfiguration.ErrorUrl);
            }
        }

        public void Profile_OnMigrateAnonymous(object sender, ProfileMigrateEventArgs e)
        {
            AnonymousIdentificationModule.ClearAnonymousIdentifier();
        }

        private void ReviewUsersAndRoles()
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
                    Membership.CreateUser("admin", "abc123", "admin@offwhite.net",
                                          "Favorite color?", "offwhite", true, out status);
                    if (!MembershipCreateStatus.Success.Equals(status))
                    {
                        Roles.AddUserToRole("admin", "Admin");
                    }
                    else
                    {
                        //Logger.Warn(("Unable to create admin user"));
                    }
                }
            }
        }
        
    }
}