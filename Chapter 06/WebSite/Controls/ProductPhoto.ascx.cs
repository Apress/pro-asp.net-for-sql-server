using System;

public partial class Controls_ProductPhoto : SubstitutionFragment
{

    #region "  Events  "

    protected void Page_PreRender(object sender, EventArgs e)
    {
        //DataBind();
    }

    public override void DataBind()
    {
        base.DataBind();
        Image1.ImageUrl = String.Format(
            "~/ProductImageHandler.ashx?ProductID={0}&Size={1}",
            ProductID, Size);
    }

    /// <summary>
    /// Support for Substitution Fragment
    /// </summary>
    public override void BindToContext()
    {
        if (ProductID == -1)
        {
            string productIdStr = CurrentContext.Request.QueryString["ProductID"];
            int productId = 0;
            int.TryParse(productIdStr, out productId);
            ProductID = productId;
        }
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
