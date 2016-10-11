using System;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using Chapter05.PhotoAlbumProvider;

public partial class Controls_GalleryControl : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["userName"] = Utility.GetUserName();
    }
    protected void rptAlbums_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //if (e.Item.ItemType == ListItemType.AlternatingItem ||
        //    e.Item.ItemType == ListItemType.Item)
        //{
        //    Control ctrl = e.Item.FindControl("AlbumPhotosControl1");
        //}
    }
    protected void rptAlbums_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
                e.Item.ItemType == ListItemType.Item)
            {
                Control ctrl = e.Item.FindControl("AlbumPhotosControl1");
                Album album = e.Item.DataItem as Album;
                if (ctrl != null)
                {
                    Type type = ctrl.GetType();
                    foreach (PropertyInfo pi in type.GetProperties())
                    {
                        if ("CurrentAlbum".Equals(pi.Name))
                        {
                            pi.SetValue(ctrl, album, null);
                        }
                    }
                }
            } 
        }
       
    }
}
