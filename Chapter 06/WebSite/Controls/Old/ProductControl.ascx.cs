using System;
using System.Web;
using System.Web.UI;

public partial class Controls_ProductControl : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Cache.SetCacheability(HttpCacheability.Public);
        //if (IsPeakLoadTime())
        //{
        //    // cache for 10 minutes during peak load time
        //    Response.Cache.SetExpires(DateTime.Now.AddMinutes(10));
        //}
        //else
        //{
        //    // cache for 2 minutes during normal traffic periods
        //    Response.Cache.SetExpires(DateTime.Now.AddMinutes(2));
        //}
        //Response.Cache.SetValidUntilExpires(true);

        Product currentProduct = Context.Items["CurrentProduct"] as Product;
        if (currentProduct != null)
        {
            Label1.Text = currentProduct.Name + " " + DateTime.Now;
        }
        else
        {
            // hide the control when there is nothing to display
            Visible = false;
        }
    }

    private bool IsPeakLoadTime()
    {
        return false;
    }

    private static string GetAvailability(HttpContext context)
    {
        SubstitutionFragment substitutionFragment = (new Page()).LoadControl(
            "~/Controls/ProductAvailabilityControl.ascx") as SubstitutionFragment;
        if (substitutionFragment != null)
        {
            return substitutionFragment.RenderToString(context);
        }
        else
        {
            return "Unable to load control: control is null";
        }
    }
}
