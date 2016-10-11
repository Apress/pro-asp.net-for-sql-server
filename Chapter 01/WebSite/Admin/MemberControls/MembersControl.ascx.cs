using System;
using System.Web.UI;

public partial class MembersControl : UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MultiView1.SetActiveView(UserManagerView);
            NavDropDownList.SelectedValue = "Manage Users";
        }
    }

    protected void NavDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ("Create User".Equals(NavDropDownList.SelectedValue))
        {
            MultiView1.SetActiveView(UserCreationView);
        }
        else if ("Manage Users".Equals(NavDropDownList.SelectedValue))
        {
            MultiView1.SetActiveView(UserManagerView);
            RefreshUserManager();
        }
        else if ("Manage Roles".Equals(NavDropDownList.SelectedValue))
        {
            MultiView1.SetActiveView(RolesManagerView);
            RefreshRolesManager();
        }
    }
    
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(UserManagerView);
        NavDropDownList.SelectedValue = "Manage Users";
        RefreshUserManager();
    }
    
    private void RefreshUserManager()
    {
        MemberControls_UserManager userManager =
            UserManagerView.FindControl("UserManager1") as MemberControls_UserManager;
        if (userManager != null)
        {
            userManager.Refresh();
        }
    }

    private void RefreshRolesManager()
    {
        MemberControls_RolesManager rolesManager =
            UserManagerView.FindControl("RolesManager1") as MemberControls_RolesManager;
        if (rolesManager != null)
        {
            rolesManager.Refresh();
        }
    }

    protected void UserManagerView_Activate(object sender, EventArgs e)
    {
        UserManager1.Reset();
    }

    protected void UserCreationView_Activate(object sender, EventArgs e)
    {
        CreateUserWizard1.ActiveStepIndex = 0;
    }
}
