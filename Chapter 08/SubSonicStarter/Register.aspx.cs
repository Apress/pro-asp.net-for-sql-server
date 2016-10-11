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

public partial class Register : System.Web.UI.Page
{
    string fromPage = string.Empty;
    protected void Page_Load(object sender, EventArgs e) {
        btnRegister.Enabled = chkAgree.Checked;
        fromPage = SubSonic.Utilities.Utility.GetParameter("r");
    }
    protected void btnRegister_Click(object sender, EventArgs e) {
        //register them
        MembershipCreateStatus status;
        Membership.CreateUser(txtLogin.Text, txtPassword.Text, txtEmail.Text, txtQ.Text, txtA.Text, true, out status);

        //add the profile
        if (status == MembershipCreateStatus.Success) {

            Profile.FirstName = txtFirst.Text;
            Profile.LastName = txtLast.Text;
            Profile.Email = txtEmail.Text;


            btnRegister.Enabled = false;
            //set the cookie
            FormsAuthentication.SetAuthCookie(txtLogin.Text, true);



            if (fromPage != string.Empty && !fromPage.ToLower().Contains("register.aspx")) {
                Response.Redirect(fromPage);
            } else {
                Response.Redirect("default.aspx");
            }
        } else {
            if (status == MembershipCreateStatus.DuplicateEmail) {
                ResultMessage1.ShowFail("This email is already in our system");

            }
            if (status == MembershipCreateStatus.DuplicateUserName) {
                ResultMessage2.ShowFail("Need to use another login - this one's taken");

            }
            if (status == MembershipCreateStatus.InvalidEmail) {
                ResultMessage1.ShowFail("Invalid email address");

            }
            if (status == MembershipCreateStatus.InvalidPassword) {
                ResultMessage1.ShowFail("Invalid password. Needs to be 6 or more letters/numbers");

            }
            if (status == MembershipCreateStatus.UserRejected) {
                ResultMessage1.ShowFail("You cannot register at this time");

            }
        }

    }
}
