using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Chapter05.PhotoAlbumProvider;

public partial class Albums_Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnImportPhotos_Click(object sender, EventArgs e)
    {
        FlickrHelper.CreateFlickrAlbums(Utility.GetUserName());
        Response.Redirect("~/Albums/Default.aspx", true);
    }

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["userName"] = Utility.GetUserName();
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
                e.Item.ItemType == ListItemType.Item)
            {
                Album album = e.Item.DataItem as Album;
                HyperLink HyperLink1 = e.Item.FindControl("HyperLink1") as HyperLink;
                if (album != null && HyperLink1 != null)
                {
                    HyperLink1.NavigateUrl = Utility.GetRelativeSiteUrl(
                        String.Format("~/Albums/Album.aspx?AlbumID={0}&UserName={1}",
                        album.ID, Utility.GetUserName()));
                }
            }
        }
    }

    protected void btnAddAlbum_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            FlickrHelper.AddFlickrAlbum(Utility.GetUserName(), tbAlbumName.Text, tbFlickrTag.Text);
            Response.Redirect("~/Albums/Default.aspx", true);
        }
    }
    protected void btnRemoveAlbum_Click(object sender, EventArgs e)
    {
        FlickrHelper.RemoveFlickAlbum(Utility.GetUserName(), ddlAlbums.SelectedValue);
        Response.Redirect("~/Albums/Default.aspx", true);
    }
}
