using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_PersonListingControl : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["lastName"] = LastName;
    }

    private string _lastName = String.Empty;
    public string LastName
    {
        get
        {
            return _lastName;
        }
        set
        {
            _lastName = value;
            ObjectDataSource1.DataBind();
        }
    }
}
