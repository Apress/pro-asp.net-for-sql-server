using System;
using System.Web.UI;

public partial class ManagerControl : UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MultiView1.SetActiveView(UserManagerView);
            DropDownList1.SelectedValue = "Manager Users";
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ("Create User".Equals(DropDownList1.SelectedValue))
        {
            MultiView1.SetActiveView(UserCreationView);
        }
        else if ("Manager Users".Equals(DropDownList1.SelectedValue))
        {
            MultiView1.SetActiveView(UserManagerView);
            RefreshUserManager();
        }
        else if ("Manage Roles".Equals(DropDownList1.SelectedValue))
        {
            MultiView1.SetActiveView(RolesManagerView);
            RefreshRolesManager();
        }
    }
    
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(UserManagerView);
        DropDownList1.SelectedValue = "Manager Users";
        RefreshUserManager();
    }
    
    private void RefreshUserManager()
    {
        ManagedControls_UserManager userManager =
            UserManagerView.FindControl("UserManager1") as ManagedControls_UserManager;
        if (userManager != null)
        {
            userManager.Refresh();
        }
    }

    private void RefreshRolesManager()
    {
        ManagedControls_RolesManager rolesManager =
            UserManagerView.FindControl("RolesManager1") as ManagedControls_RolesManager;
        if (rolesManager != null)
        {
            rolesManager.Refresh();
        }
    }
}
