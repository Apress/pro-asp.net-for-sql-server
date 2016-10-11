using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Administration;

public partial class Admin_admin_users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void EnabledChanged(object sender, EventArgs e)
    {
        string userID = null;
        CheckBox checkBox = sender as CheckBox;
        if (checkBox == null)
            return;
                
        if (!string.IsNullOrEmpty(checkBox.Attributes["Value"]))
            userID = checkBox.Attributes["Value"];

        if (userID == null)
            return;

        MembershipUser user = Membership.FindUsersByName(userID)[userID];
        user.IsApproved = checkBox.Checked;

        Membership.UpdateUser(user);
    }

    public void SearchForUsers(object sender, EventArgs e)
    {
        if (TextBox1.Text != "")
        {
            GridView1.DataSourceID = "";
            SearchForUsers(sender, e, GridView1, SearchByDropDown, TextBox1);
        }
    }

    protected void SearchForUsers(object sender, EventArgs e, GridView dataGrid, DropDownList dropDown, TextBox textBox)
    {
        ICollection coll = null;
        string text = textBox.Text;
        text = text.Replace("*", "%");
        text = text.Replace("?", "_");
        int total = 0;

        if (text.Trim().Length != 0)
        {
            if (dropDown.SelectedIndex == 0 /* userID */)
            {
                coll = Membership.FindUsersByName(text); 
            }
            else
            {
                coll = Membership.FindUsersByEmail(text);
            }
        }

        dataGrid.PageIndex = 0;
        dataGrid.DataSource = coll;
        dataGrid.DataBind();

    }

    public void LinkButtonClick(object sender, CommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            string userName = (string)e.CommandArgument;
            
            Membership.DeleteUser(userName);

						Response.Redirect("admin_users.aspx", false);
        }
    }

    protected void allUsersDataSource_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
    }
}
