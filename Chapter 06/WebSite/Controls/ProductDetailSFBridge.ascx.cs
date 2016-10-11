using System.Web;
using System.Web.UI;

public partial class Controls_ProductDetailSFBridge : UserControl
{
    private static string GetProductDetail(HttpContext context)
    {
        SubstitutionFragment substitutionFragment = (new Page()).LoadControl(
            "~/Controls/ProductDetailSF.ascx") as SubstitutionFragment;
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
