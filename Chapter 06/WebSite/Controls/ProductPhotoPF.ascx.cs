using System;
using System.Web.UI;

public partial class Controls_ProductPhotoPF : UserControl
{

    #region "  Events  "

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (ProductID == -1)
        {
            string productIdStr =
                Context.Request.QueryString["ProductID"];
            int productId = 0;
            int.TryParse(productIdStr, out productId);
            ProductID = productId;
        }
        Image1.ImageUrl = String.Format(
            "~/ProductImageHandler.ashx?ProductID={0}&Size={1}",
            ProductID, Size);
    }

    #endregion

    #region "  Properties  "

    private int _productId = -1;
    /// <summary>
    /// Product ID
    /// </summary>
    public int ProductID
    {
        get
        {
            return _productId;
        }
        set
        {
            _productId = value;
        }
    }

    private string _size = "L";
    /// <summary>
    /// Photo Size (T or L)
    /// </summary>
    public string Size
    {
        get
        {
            return _size;
        }
        set
        {
            _size = value;
        }
    }

    #endregion

}
