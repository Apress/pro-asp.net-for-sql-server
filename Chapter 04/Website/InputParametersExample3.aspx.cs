using System;
using System.Web.UI;

public partial class InputParametersExample3 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        PersonListingControl1.LastName = DropDownList1.SelectedValue;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        PersonListingControl1.LastName = DropDownList1.SelectedValue;
    }
}
