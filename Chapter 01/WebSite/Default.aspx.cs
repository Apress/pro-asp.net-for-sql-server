using System;
using System.Web.Security;
using System.Web.UI;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Roles.Enabled)
            {
                lblRolesStatus.Text = "Roles are enabled";
            }
            else
            {
                lblRolesStatus.Text = "Roles are not enabled";
            }
        }
    }
}
