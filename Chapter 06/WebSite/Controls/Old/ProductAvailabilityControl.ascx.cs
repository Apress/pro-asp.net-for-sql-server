using System;

public partial class Controls_ProductAvailabilityControl : SubstitutionFragment
{

    public override void BindToContext()
    {
        Product currentProduct = Utility.GetProduct(CurrentContext);
        if (currentProduct != null)
        {
            Label1.Text = currentProduct.Availability + 
                " as of " + DateTime.Now;
        }
        else
        {
            Label1.Text = "Unknown";
        }
    }

}
