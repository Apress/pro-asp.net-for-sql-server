using System.Collections.Generic;
using System.ComponentModel;
using Chapter05.PhotoAlbumProvider;

/// <summary>
/// Summary description for Domain
/// </summary>
[DataObject()]
public class Domain
{

    [DataObjectMethod(DataObjectMethodType.Select)]
    public List<Album> GetAlbums(string userName)
    {
        return PhotoAlbumService.Instance.GetAlbums(userName);
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    public List<Photo> GetPhotosByAlbum(Album album)
    {
        return PhotoAlbumService.Instance.GetPhotosByAlbum(album);
    }

}
