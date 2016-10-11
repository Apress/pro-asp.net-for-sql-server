using System;
using System.Web.UI;

public partial class Controls_CityListingControl : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ObjectDataSource1_Selecting(object sender, System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["country"] = Country;
    }

    private string _country;
    public string Country
    {
        get {
            return _country;
        }
        set {
            _country = value;
            ObjectDataSource1.DataBind();
        }
    }
}
