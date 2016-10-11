using System;
using System.Web;
using System.Web.UI;

public partial class Controls_ProductDetailOC : UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Product product = GetProduct(Context);
        if (product != null)
        {
            lblProductName.Text = product.Name;
            lblProductNumber.Text = product.ProductNumber;
            //lblPrice.Text = product.Price.ToString("C");
            //lblAvailability.Text = product.Availability;
        }
    }

    private static Product GetProduct(HttpContext context)
    {
        return Utility.GetProduct(context);
    }

    private static string GetPrice(HttpContext context)
    {
        Product product = GetProduct(context);
        return product.Price.ToString("C");
    }

    private static string GetAvailability(HttpContext context)
    {
        Product product = GetProduct(context);
        return product.Availability;
    }

}
