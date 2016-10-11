using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Profile : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            lblStatus.Visible = false;
            if (!String.IsNullOrEmpty(Profile.FirstName))
            {
                tbFirstName.Text = Profile.FirstName;
            }
            if (!String.IsNullOrEmpty(Profile.LastName))
            {
                tbLastName.Text = Profile.LastName;
            }
            int counter = 1;
            while (counter <= 12)
            {
                lbBirthMonth.Items.Add(new ListItem(counter.ToString()));
                counter++;
            }
            counter = 1;
            while (counter <= 31)
            {
                lbBirthDay.Items.Add(new ListItem(counter.ToString()));
                counter++;
            }
            counter = DateTime.Now.Year - 60;
            while (counter <= DateTime.Now.Year)
            {
                lbBirthYear.Items.Add(new ListItem(counter.ToString()));
                counter++;
            }
            if (!DateTime.MinValue.Equals(Profile.BirthDate))
            {
                lbBirthMonth.SelectedValue = Profile.BirthDate.Month.ToString();
                lbBirthDay.SelectedValue = Profile.BirthDate.Day.ToString();
                lbBirthYear.SelectedValue = Profile.BirthDate.Year.ToString();
            }
            else
            {
                lbBirthYear.SelectedValue = (DateTime.Now.Year - 30).ToString();
            }
        }
    }

    protected void cvBirthDate_ServerValidate(object source, ServerValidateEventArgs args)
    {
        DateTime tmpDate;
        if (!DateTime.TryParse(GetBirthDateAsString(), out tmpDate))
        {
            args.IsValid = false;
        }
    }

    protected void btnSaveProfile_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Profile.FirstName = tbFirstName.Text;
            Profile.LastName = tbLastName.Text;

            DateTime tmpDate;
            if (DateTime.TryParse(GetBirthDateAsString(), out tmpDate))
            {
                Profile.BirthDate = tmpDate;
            }

            lblStatus.Text = "Profile Saved!";
            lblStatus.Visible = true;
        }
        else
        {
            lblStatus.Visible = false;
        }
    }

    private string GetBirthDateAsString()
    {
        String tmpDateStr = String.Format("{0}/{1}/{2}",
            lbBirthMonth.SelectedValue, lbBirthDay.SelectedValue, lbBirthYear.SelectedValue);
        return tmpDateStr;
    }
    
}
