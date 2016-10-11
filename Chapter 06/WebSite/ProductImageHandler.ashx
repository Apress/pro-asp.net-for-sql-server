<%@ WebHandler Language="C#" Class="ProductImageHandler" %>

using System;
using System.Data;
using System.Web;
using Chapter05.ClassLibrary;

public class ProductImageHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string type = "image/gif";
        string filename  = String.Empty;
        byte[] data = null;

        try
        {
            int productId = 0;
            if (!int.TryParse(context.Request.QueryString["ProductID"], out productId))
            {
                productId = 1;
            }
            string size = context.Request.QueryString["Size"];
            Domain domain = new Domain();
            DataSet photosDs = domain.GetProductPhotos(productId);
            if (photosDs != null && photosDs.Tables.Count > 0 &&
                photosDs.Tables[0].Rows.Count > 0)
            {
                DataRow photoRow = photosDs.Tables[0].Rows[0];
                if ("L".Equals(size))
                {
                    filename = photoRow["LargePhotoFileName"] as string;
                    data = photoRow["LargePhoto"] as byte[];
                }
                else
                {
                    filename = photoRow["ThumbnailPhotoFileName"] as string;
                    data = photoRow["ThumbNailPhoto"] as byte[];
                }
            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Product not found");
                return;
            }
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(ex.Message);
        }

        if (filename.EndsWith(".gif"))
        {
            type = "image/gif";
        }
        context.Response.ContentType = type;
        context.Response.BinaryWrite(data);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}