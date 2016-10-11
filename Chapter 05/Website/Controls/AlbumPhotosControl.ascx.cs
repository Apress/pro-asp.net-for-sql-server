using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Chapter05.PhotoAlbumProvider;

public partial class Controls_AlbumPhotosControl : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["album"] = CurrentAlbum;
    }

    private Album _album = null;
    public Album CurrentAlbum
    {
        get
        {
            return _album;
        }
        set
        {
            _album = value;
        }
    }

    protected void rptAlbums_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem ||
            e.Item.ItemType == ListItemType.Item)
        {
            HyperLink hyperLink = e.Item.FindControl("HyperLink1") as HyperLink;
            if (hyperLink != null)
            {
                Photo photo = e.Item.DataItem as Photo;
                Image image = hyperLink.FindControl("Image1") as Image;
                if (photo != null && image != null)
                {
                    image.Width = photo.ThumbnailWidth;
                    image.Height = photo.ThumbnailHeight;
                    hyperLink.Attributes["title"] = photo.Name;
                    hyperLink.Attributes["rel"] = CurrentAlbum.Name.Replace(" ", "_");
                }                
            }
        }
    }
}
