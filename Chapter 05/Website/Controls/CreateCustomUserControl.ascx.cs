using System;
using System.Web.UI;

public partial class Controls_CreateCustomUserControl : UserControl
{
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        Profile.FontSize = rblFontSize.SelectedValue;
        Profile.ProfileGroup = rblPrimaryInterest.SelectedValue;
    }

    public void Reset()
    {
        CreateUserWizard1.ActiveStepIndex = 0;
    }
}
