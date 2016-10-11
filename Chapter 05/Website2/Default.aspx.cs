using System;
using System.Configuration;
using System.Security.Principal;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;

public partial class _Default : Page 
{

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminHyperLink.Visible = Roles.IsUserInRole(User.Identity.Name, "Admin");
        
        if (!IsPostBack)
        {
            Profile.FontSize = "10";
        }
        if (User.Identity.IsAuthenticated)
        {
            //MembershipUser user = Membership.GetUser(User.Identity.Name);
            //Label1.Text = user.LastActivityDate.ToString();

            FormsIdentity identity = User.Identity as FormsIdentity;
            IIdentity id = User.Identity as IIdentity;
            if (identity != null)
            {
                Label2.Text = identity.Ticket.UserData;
            }
            Label3.Text = IsRemoteAddressMatched().ToString();
            //Profile.UserAgent = Request.UserAgent;
            Label4.Text = Profile.FontSize;
        }
        else
        {
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
        }
    }

    protected void Login1_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
    {
        if (FormsAuthentication.Authenticate(Login1.UserName, Login1.Password))
        //if (Membership.ValidateUser(Login1.UserName, Login1.Password))
        {
            e.Authenticated = true;
            string username = Login1.UserName;
            bool persist = Login1.RememberMeSet;
            int timeout = GetLoginTimeout();
            string userData = "remoteAddress=" + Request.UserHostAddress;

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                username, DateTime.Now, DateTime.Now.AddMinutes(timeout),
                persist, userData);
            string encTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            cookie.Expires = ticket.Expiration;
            Response.Cookies.Add(cookie);
            Response.Redirect(FormsAuthentication.GetRedirectUrl(username, persist), true);
        }
        else
        {
            e.Authenticated = false;
        }
    }

    private int GetLoginTimeout()
    {
        AuthenticationSection authSection =
            ConfigurationManager.GetSection("system.web/authentication") as AuthenticationSection;
        if (authSection != null && authSection.Forms != null)
        {
            return authSection.Forms.Timeout.Minutes;
        }
        // return the default
        return 30;
    }

    private bool IsRemoteAddressMatched()
    {
        if (User.Identity.IsAuthenticated)
        {
            FormsIdentity identity = User.Identity as FormsIdentity;
            if (identity != null)
            {
                string prefix = "remoteAddress=";
                if (!String.IsNullOrEmpty(identity.Ticket.UserData) &&
                    identity.Ticket.UserData.IndexOf(prefix) == 0)
                {
                    string remoteAddress = identity.Ticket.UserData.Substring(prefix.Length);
                    return Request.UserHostAddress.Equals(remoteAddress);
                }
            }
        }
        return false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ProfileManager.DeleteInactiveProfiles(
            ProfileAuthenticationOption.Anonymous,
            DateTime.Now.AddMonths(-1));

        //Profile.U
        //Profile.

        ProfileInfoCollection profiles = ProfileManager.GetAllProfiles(
            ProfileAuthenticationOption.All);
        foreach (ProfileInfo profile in profiles)
        {
            // filter to inactive for 7 days
            if (profile.IsAnonymous &&
                profile.LastActivityDate < DateTime.Now.AddDays(-7))
            {
                ProfileCommon pc = Profile.GetProfile(profile.UserName);
                //if (!pc.UserAgent.Contains("Mozilla"))
                //{
                //    ProfileManager.DeleteProfile(profile.UserName);
                //}
            }
        }
    }
}
