using System.Web;

public partial class Controls_ProductDetailSF : SubstitutionFragment
{
    public override void BindToContext()
    {
        Product product = GetProduct(CurrentContext);
        if (product != null)
        {
            lblProductName.Text = product.Name;
            lblProductNumber.Text = product.ProductNumber;
            lblPrice.Text = product.Price.ToString("C");
            lblAvailability.Text = product.Availability;
        }
    }

    private static Product GetProduct(HttpContext context)
    {
        return Utility.GetProduct(context);
    }
}
