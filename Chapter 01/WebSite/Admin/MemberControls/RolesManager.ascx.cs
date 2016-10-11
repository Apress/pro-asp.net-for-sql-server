using System;
using System.ComponentModel;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MemberControls_RolesManager : UserControl
{
    #region "  Events  "

    protected void Page_PreRender(object sender, EventArgs e)
    {
        BindRolesGridView();
    }
    protected void RolesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string role = e.Row.DataItem as string;
            foreach (TableCell cell in e.Row.Cells)
            {
                foreach (Control control in cell.Controls)
                {
                    Label label = control as Label;
                    if (label != null)
                    {
                        if ("Role".Equals(label.Text))
                        {
                            label.Text = role;
                        }
                        else if ("Users".Equals(label.Text))
                        {
                            label.Text = Roles.GetUsersInRole(role).Length.ToString();
                        }
                    }
                    else
                    {
                        LinkButton button = control as LinkButton;
                        if (button != null)
                        {
                            button.Enabled = Roles.GetUsersInRole(role).Length == 0;
                            if (button.Enabled)
                            {
                                button.CommandArgument = role;
                                button.Attributes.Add("onclick", 
                                  "return confirm('Are you sure?');");
                            }
                        }
                    }
                }
            }
        }
    }
    protected void RolesGridView_RowCommand(
      object sender, GridViewCommandEventArgs e)
    {
        if ("RemoveRole".Equals(e.CommandName))
        {
            string role = e.CommandArgument as string;
            Roles.DeleteRole(role, true);
            BindRolesGridView();
        }
    }
    protected void AddRoleButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string role = AddRoleTextBox.Text;
            if (!Roles.RoleExists(role))
            {
                Roles.CreateRole(role);
                AddRoleTextBox.Text = String.Empty;
                BindRolesGridView();
            }
        }
    }

    #endregion
    #region "  Methods  "

    public void Refresh()
    {
        BindRolesGridView();
    }
    private void BindRolesGridView()
    {
        RolesGridView.DataSource = Roles.GetAllRoles();
        RolesGridView.DataBind();
    }

    #endregion
    #region "  Properties  "

    [Category("Appearance"), Browsable(true), DefaultValue("Roles Manager")]
    public string Title
    {
        get
        {
            return TitleLabel.Text;
        }
        set
        {
            TitleLabel.Text = value;
        }
    }

    #endregion
}
