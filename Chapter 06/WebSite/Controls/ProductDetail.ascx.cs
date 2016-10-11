using System;
using System.Web;
using System.Web.UI;

public partial class Controls_ProductDetail : UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Product product = GetProduct(Context);
        if (product != null)
        {
            lblProductName.Text = product.Name;
        }
    }

    private static Product _product = null;
    private static Product GetProduct(HttpContext context)
    {
        if (_product == null)
        {
            _product = Utility.GetProduct(context);
        }
        return _product;
    }

    private static string GetPrice(HttpContext context)
    {
        Product product = GetProduct(context);
        if (product != null)
        {
            return product.Price.ToString();
        }
        else
        {
            return "0.0";
        }
    }

    private static string GetAvailability(HttpContext context)
    {
        Product product = GetProduct(context);
        if (product != null)
        {
            return product.Availability;
        }
        else
        {
            return "Out Of Stock";
        }
    }

}
