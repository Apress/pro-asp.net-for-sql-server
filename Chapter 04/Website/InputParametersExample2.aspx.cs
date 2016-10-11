using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InputParametersExample2 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

protected void ObjectDataSource2_Selecting(object sender, 
    ObjectDataSourceSelectingEventArgs e)
{
    e.InputParameters["lastName"] = DropDownList1.SelectedValue;
}
}
