using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Chapter05.PhotoAlbumProvider;

public partial class Albums_Album : Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request.QueryString["AlbumID"]))
        {
            // Find the current album
            PhotoAlbumProvider provider = PhotoAlbumService.Instance;
            List<Album> albums = provider.GetAlbums(Utility.GetUserName());
            foreach (Album album in albums)
            {
                if (Request.QueryString["AlbumID"].Equals(album.ID.ToString()))
                {
                    CurrentAlbum = album;
                    break;
                }
            }
        }
    }

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["album"] = CurrentAlbum;
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
        else if (e.Item.ItemType == ListItemType.Header)
        {
            Label label = e.Item.FindControl("Label1") as Label;
            if (label != null)
            {
                label.Text = CurrentAlbum.Name;
            }
        }
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
}
