using System;
using System.Web.UI;

public partial class _Product : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Product product = Utility.GetProduct(Context);
    }
}
