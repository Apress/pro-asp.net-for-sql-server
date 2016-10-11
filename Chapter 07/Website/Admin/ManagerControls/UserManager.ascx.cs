using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagedControls_UserManager : UserControl
{
    #region "  Events  "
    protected void Page_Init(object sender, EventArgs e)
    {
    }
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        //AddAttributesToRender(writer);
		//writer.AddAttribute("onclick", "return confirm('"+ ConfirmText +"');", false);
    }
    protected void FilterUsersButton_Click(object sender, EventArgs e)
    {
        BindUsersGridView();
    }
    protected void EditUserButton_Click(object sender, EventArgs e)
    {
        UsersMultiView.SetActiveView(EditorView);
    }
    protected void UnlockUserButton_Click(object sender, EventArgs e)
    {
        MembershipUser user = CurrentUser;
        if (user != null)
        {
            user.UnlockUser();
            Membership.UpdateUser(user);
            BindUserView();
        }
    }
    protected void ResetPasswordButton_Click(object sender, EventArgs e)
    {
        MembershipUser user = CurrentUser;
        if (user != null)
        {
            user.ResetPassword();
        }
        UsersMultiView.SetActiveView(UserView);
    }
    protected void CancelViewUserButton_Click(object sender, EventArgs e)
    {
        UsersMultiView.SetActiveView(SelectUserView);
    }
    protected void UpdateUserButton_Click(object sender, EventArgs e)
    {
        if (CurrentUser != null)
        {
            MembershipUser user = CurrentUser;
            user.Email = EmailTextBox.Text;
            user.Comment = CommentTextBox.Text;
            user.IsApproved = ApprovedCheckBox.Checked;
            Membership.UpdateUser(user);

            foreach (ListItem listItem in RolesCheckBoxList.Items)
            {
                string role = listItem.Value;
                if (Roles.RoleExists(role))
                {
                    if (!listItem.Selected &&
                        Roles.IsUserInRole(user.UserName, role))
                    {
                        Roles.RemoveUserFromRole(user.UserName, role);
                    }
                    else if (listItem.Selected &&
                        !Roles.IsUserInRole(user.UserName, role))
                    {
                        Roles.AddUserToRole(user.UserName, role);
                    }
                }
            }
            
            UsersMultiView.SetActiveView(UserView);
        }
    }
    protected void CancelEditUserButton_Click(object sender, EventArgs e)
    {
        UsersMultiView.SetActiveView(UserView);
    }
    protected void CancelRolesButton_Click(object sender, EventArgs e)
    {
        UsersMultiView.SetActiveView(UserView);
    }
    protected void SelectUserView_Activate(object sender, EventArgs e)
    {
        BindUsersGridView();
    }
    protected void UserView_Activate(object sender, EventArgs e)
    {
        BindUserView();
    }
    protected void EditorView_Activate(object sender, EventArgs e)
    {
        BindEditorView();
    }
    protected void UsersGridView_Init(object sender, EventArgs e)
    {
    }

    protected void UsersGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        UsersGridView.PageIndex = e.NewPageIndex;
        BindUsersGridView();
    }
    protected void UsersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if ("ViewUser".Equals(e.CommandName))
        {
            CurrentUser = GetUser(e.CommandArgument.ToString());
            UsersMultiView.SetActiveView(UserView);
        }
        else if ("DeleteUser".Equals(e.CommandName))
        {
            MembershipUser user = GetUser(e.CommandArgument.ToString());
            Membership.DeleteUser(user.UserName, true);
            ProfileManager.DeleteProfile(user.UserName);
            BindUsersGridView();

            UsersMultiView.SetActiveView(SelectUserView);
        }
    }
    #endregion

    #region "  Methods  "
    private void BindUsersGridView()
    {
        //if (String.Empty.Equals(FilterUsersTextBox.Text.Trim()))
        //{
        //    UsersGridView.DataSource = Membership.GetAllUsers();
        //}
        //else
        //{
        //    List<MembershipUser> filteredUsers = new List<MembershipUser>();
        //    string filterText = FilterUsersTextBox.Text.Trim();
        //    foreach (MembershipUser user in Membership.GetAllUsers())
        //    {
        //        if (user.UserName.Contains(filterText) ||
        //            user.Email.Contains(filterText))
        //        {
        //            filteredUsers.Add(user);
        //        }
        //    }
        //    UsersGridView.DataSource = filteredUsers;
        //}
        UsersGridView.DataBind();
    }
    private void BindUserView()
    {
        MembershipUser user = CurrentUser;
        if (user != null)
        {
            UserNameValueLabel.Text = user.UserName;
            ApprovedValueLabel.Text = user.IsApproved.ToString();
            LockedOutValueLabel.Text = user.IsLockedOut.ToString();
            OnlineValueLabel.Text = user.IsOnline.ToString();
            CreationValueLabel.Text = user.CreationDate.ToString("d");
            LastActivityValueLabel.Text = user.LastActivityDate.ToString("d");
            LastLoginValueLabel.Text = user.LastLoginDate.ToString("d");
            UserCommentValueLabel.Text = user.Comment;

            UnlockUserButton.Visible = user.IsLockedOut;
            ResetPasswordButton.Attributes.Add("onclick", "return confirm('Are you sure?');");
        }
    }
    private void BindEditorView()
    {
        MembershipUser user = CurrentUser;
        if (user != null)
        {
            UserNameValue2Label.Text = user.UserName;
            EmailTextBox.Text = user.Email;
            CommentTextBox.Text = user.Comment;
            ApprovedCheckBox.Checked = user.IsApproved;
            
            RolesCheckBoxList.Items.Clear();
            foreach (string role in Roles.GetAllRoles())
            {
                ListItem listItem = new ListItem(role);
                listItem.Selected = Roles.IsUserInRole(user.UserName, role);
                RolesCheckBoxList.Items.Add(listItem);
            }
        }
    }
    
    public void Refresh()
    {
        BindUsersGridView();
    }
    
    public bool IsUserAuthenticated
    {
        get
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
    public string GetUserName()
    {
        if (IsUserAuthenticated)
        {
            return HttpContext.Current.User.Identity.Name;
        }
        return String.Empty;
    }
    public MembershipUser GetUser(string username)
    {
        return Membership.GetUser(username);
    }
    
    #endregion

    #region "  Properties  "
    [Category("Appearance"), Browsable(true), DefaultValue("User Manager")]
    public string Title
    {
        get
        {
            return TitleLabel.Text;
        }
        set
        {
            TitleLabel.Text = value;
            EnsureChildControls();
        }
    }
    [Category("Appearance"), Browsable(true), DefaultValue(false)]
    public bool TitleBold
    {
        get
        {
            return TitleLabel.Font.Bold;
        }
        set
        {
            TitleLabel.Font.Bold = value;
            EnsureChildControls();
        }
    }
    
    [Browsable(false)]
    public CssStyleCollection TitleStyle
    {
        get
        {
            return TitleLabel.Style;
        }
    }
    private MembershipUser CurrentUser
    {
        get
        {
            return ViewState["CurrentUser"] as MembershipUser;
        }
        set
        {
            ViewState["CurrentUser"] = value;
        }
    }
    #endregion
}
