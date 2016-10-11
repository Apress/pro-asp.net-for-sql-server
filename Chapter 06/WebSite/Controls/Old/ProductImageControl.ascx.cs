using System;
using System.Web.UI;

public partial class Controls_ProductImageControl : UserControl
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        Image1.ImageUrl = String.Format(
            "~/ProductImageHandler.ashx?ProductID={0}&Size={1}", 
            ProductID, Size);
    }

    private int _productId = 0;
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

    private string _size = "T";
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


}
