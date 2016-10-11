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

public partial class admin_user_edit : System.Web.UI.Page
{
    bool isEditMode = true;
    string userName = HttpContext.Current.Request["username"];

    protected void Page_Load(object sender, EventArgs e)
    {
        // Is in add mode?
        //
        if (string.IsNullOrEmpty(userName))
        {
            Page.Title = ActionTitle.Text = "Add User";
            isEditMode = false;
            PasswordRow.Visible = true;
            SecretQuestionRow.Visible = Membership.RequiresQuestionAndAnswer ? true : false;
            SecretAnswerRow.Visible = Membership.RequiresQuestionAndAnswer ? true : false;

            if (!Membership.RequiresQuestionAndAnswer)
            {
                ActiveUser.Checked = true;
                ActiveUser.Enabled = false;
            }
        }
        else
        {
            // We are in edit mode
            //
            PasswordRow.Visible = Membership.EnablePasswordRetrieval ? true : false;
            NewPassword.Visible = Membership.EnablePasswordRetrieval ? true : false;

            SecretQuestionRow.Visible = (Membership.RequiresQuestionAndAnswer && Membership.EnablePasswordRetrieval) ? true : false;
            SecretAnswerRow.Visible = (Membership.RequiresQuestionAndAnswer && Membership.EnablePasswordRetrieval) ? true : false;
        }

        if (!IsPostBack)
        {
            PopulateCheckboxes();

            // Is it in edit mode?
            //
            if (isEditMode)
            {
                UserID.Text = userName;
                UserID.Enabled = false;

                MembershipUser mu = Membership.GetUser(userName);
                if (mu == null)
                {
                    return; // Review: scenarios where this happens.
                }

                Email.Text = mu.Email;
                ActiveUser.Checked = mu.IsApproved;

                if (Membership.EnablePasswordRetrieval)
                {
                    // Load old password
                    Password.Text = mu.GetPassword();
                    Password.Enabled = false;

                    // Load old secret question
                    SecretQuestion.Text = mu.PasswordQuestion;
                }
				unlockUser.Enabled = mu.IsLockedOut; 
            }
        }
    }

    private void PopulateCheckboxes()
    {
        if (Roles.Enabled)
        {
            CheckBoxRepeater.DataSource = Roles.GetAllRoles();
            CheckBoxRepeater.DataBind();

            if (CheckBoxRepeater.Items.Count > 0)
                SelectRolesLabel.Text = "Select Roles";
            else
                SelectRolesLabel.Text = "No Roles Defined";
        }
        else
        {
            SelectRolesLabel.Text = "Roles Not Enabled";
        }
    }

    public void SaveClick(object sender, EventArgs e)
    {
        if (isEditMode)
            UpdateUser(sender, e);
        else
            AddUser(sender, e);
    }

    private void UpdateRoleMembership(string u)
    {
        if (string.IsNullOrEmpty(u))
        {
            return;
        }

        foreach (RepeaterItem i in CheckBoxRepeater.Items)
        {
            CheckBox c = (CheckBox)i.FindControl("checkbox1");
            UpdateRoleMembership(u, c);
        }

        // Clear the checkboxes
        PopulateCheckboxes();
    }

    private void UpdateRoleMembership(string u, CheckBox box)
    {
        // Array manipulation because cannot use Roles static method (need different appPath).
        string role = box.Text;

        bool boxChecked = box.Checked;
        bool userInRole = Roles.IsUserInRole(u, role);
        try
        {
            if (boxChecked && !userInRole)
            {
                Roles.AddUserToRoles(u, new string[] { role });
            }
            else if (!boxChecked && userInRole)
            {
                Roles.RemoveUserFromRoles(u, new string[] { role });
            }
        }
        catch (Exception ex)
        {
        }
    }

    public void UpdateUser(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }

        string resultMsg = "";
        string userIDText = UserID.Text;
        string emailText = Email.Text;

        string password = null;
        string newPassword = null;
        string question = null;
        string answer = null;
        if (Membership.EnablePasswordRetrieval)
        {
            password = Password.Text.Trim();
            newPassword = NewPassword.Text.Trim();

            if (Membership.RequiresQuestionAndAnswer)
            {
                question = SecretQuestion.Text;
                answer = SecretAnswer.Text;
            }
        }                

        try
        {
            MembershipUser mu = Membership.GetUser(userIDText);

            mu.Email = Email.Text;
            mu.IsApproved = ActiveUser.Checked;

            Membership.UpdateUser(mu);

            UpdateRoleMembership(userIDText);

            // Are we allowed to change secret question & answer?
            // We will need old password for this.
            //
            if (Membership.EnablePasswordRetrieval &&
                Membership.RequiresQuestionAndAnswer &&
                password != null && 
                question != null && answer != null)
            {
                mu.ChangePasswordQuestionAndAnswer(password, question, answer);
            }

            // Are we allowed to change the password?
            // We will need old password for this.
            //
            if (Membership.EnablePasswordRetrieval &&
                !string.IsNullOrEmpty(password) &&
                !string.IsNullOrEmpty(newPassword))
            {
                mu.ChangePassword(password, newPassword);
            }

            resultMsg = "User details has been successfully updated.";
        }
        catch (Exception ex)
        {
            resultMsg = "Failed to update user details. Error message: " + ex.Message;
        }
		SetResultMessage(resultMsg); 
    }

    public void AddUser(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }

        MembershipCreateStatus createStatus = MembershipCreateStatus.Success;
        string resultMsg = "";

        string userIDText = UserID.Text;
        string emailText = Email.Text;
        bool isActive = ActiveUser.Checked;
        string password = Password.Text;
        string question = "";
        string answer = "";
        if (Membership.RequiresQuestionAndAnswer)
        {
            question = SecretQuestion.Text;
            answer = SecretAnswer.Text;
        }

        try
        {
            MembershipUser mu = null;

            if (Membership.RequiresQuestionAndAnswer)
            {
                mu = Membership.CreateUser(userIDText, password, emailText, question, answer, isActive, out createStatus);
            }
            else
            {
                mu = Membership.CreateUser(userIDText, password, emailText);
            }

            if (createStatus == MembershipCreateStatus.Success && 
                (mu != null && !string.IsNullOrEmpty(mu.UserName)))
            {
                UpdateRoleMembership(mu.UserName);
            }

            SaveButton.Enabled = false;

            resultMsg = "User has been successfully created.";
        }
        catch (Exception ex)
        {
            resultMsg = "Failed to create new user. Error message: " + ex.Message;
        }

		SetResultMessage(resultMsg);
    }

	private void SetResultMessage(string resultMsg)
	{
		trResultRow.Visible = !String.IsNullOrEmpty(resultMsg);
		lblMessage.Text = resultMsg;		
	}

    public bool IsUserInRole(string roleName)
    {
        if (string.IsNullOrEmpty(userName) ||
            string.IsNullOrEmpty(roleName))
        {
            return false;
        }

        return Roles.IsUserInRole(userName, roleName);  
    }
	protected void ResetPassword_Click(object sender, EventArgs e)
	{
		string resultMsg; 
		try
		{
			MembershipUser mu = Membership.GetUser(UserID.Text);
			mu.ResetPassword();
			resultMsg = "User password has been reset. User will receive an email with the new password"; 
		}
		catch(Exception ex)
		{
			resultMsg = "Could not reset user password. " + ex.Message; 
		}
		SetResultMessage(resultMsg); 
	}
	protected void unlockAccount_Click(object sender, EventArgs e)
	{
		try
		{
			MembershipUser mu = Membership.GetUser(UserID.Text);
			if(mu.UnlockUser())
			{
				Membership.UpdateUser(mu); 
				SetResultMessage("User account unlocked"); 
			}
			else
			{
				SetResultMessage("Could not unlock user account."); 
			}
		}
		catch (Exception ex)
		{
			SetResultMessage("Could not unlock user account. " + ex.Message ); 	
		}
	}
}
