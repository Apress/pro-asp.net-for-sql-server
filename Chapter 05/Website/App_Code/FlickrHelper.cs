using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.Configuration;
using System.Xml;
using Chapter05.CustomSiteMapProvider;
using Chapter05.PhotoAlbumProvider;

/// <summary>
/// Summary description for FlickrHelper
/// </summary>
public class FlickrHelper
{

    public static void ImportFlickrPhotosToAlbum(Album album, string tag)
    {
        WebClient client = new WebClient();
        string url = String.Format(
      SiteConfiguration.FlickFeedUrlFormat, tag, "rss2");
        byte[] data = client.DownloadData(url);
        MemoryStream stream = new MemoryStream(data);

        XmlDocument document = new XmlDocument();
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(document.NameTable);
        nsmgr.AddNamespace("media", "http://search.yahoo.com/mrss/");
        nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");

        document.Load(stream);
        document.Normalize();

        int max = 10;
        int count = 1;

        XmlNode channelNode = document.SelectSingleNode("/rss/channel");
        if (channelNode != null)
        {
            XmlNodeList itemNodes = channelNode.SelectNodes("item");
            foreach (XmlNode itemNode in itemNodes)
            {
                XmlNode titleNode = itemNode.SelectSingleNode("title");
                XmlNode dateTakenNode = itemNode.SelectSingleNode(
                  "dc:date.Taken", nsmgr);

                XmlNode regularUrlNode = itemNode.SelectSingleNode(
                  "media:content/@url", nsmgr);
                XmlNode regularWidthNode = itemNode.SelectSingleNode(
                  "media:content/@width", nsmgr);
                XmlNode regularHeightNode = itemNode.SelectSingleNode(
                  "media:content/@height", nsmgr);

                XmlNode thumbnailUrlNode = itemNode.SelectSingleNode(
                  "media:thumbnail/@url", nsmgr);
                XmlNode thumbnailWidthNode = itemNode.SelectSingleNode(
                  "media:thumbnail/@width", nsmgr);
                XmlNode thumbnailHeightNode = itemNode.SelectSingleNode(
                  "media:thumbnail/@height", nsmgr);

                try
                {
                    string title = "No Title";
                    DateTime dateTaken;
                    string regularUrl;
                    string thumbnailUrl;
                    int regularWidth, regularHeight, 
                      thumbnailWidth, thumbnailHeight;

                    if (titleNode != null && titleNode.FirstChild != null)
                    {
                        title = titleNode.FirstChild.Value;
                    }
                    DateTime.TryParse(dateTakenNode.FirstChild.Value, 
                      out dateTaken);
                    regularUrl = regularUrlNode.Value;
                    int.TryParse(regularWidthNode.Value, 
                      out regularWidth);
                    int.TryParse(regularHeightNode.Value, 
                      out regularHeight);

                    thumbnailUrl = thumbnailUrlNode.Value;
                    int.TryParse(thumbnailWidthNode.Value, 
                      out thumbnailWidth);
                    int.TryParse(thumbnailHeightNode.Value, 
                      out thumbnailHeight);

                    PhotoAlbumProvider provider =
                        PhotoAlbumService.Instance;
                    provider.PhotoInsert(album, title, 
                      dateTaken, regularUrl, regularWidth, 
                      regularHeight, thumbnailUrl, 
                      thumbnailWidth, thumbnailHeight,
                      true, true);                  
                }
                catch (Exception ex)
                {
                  Utility.LogError("Error reading RSS item", ex);
                }
                count++;
                if (count > max) {
                    break;
                }
            }
        }
    }

    public static void ExportFlickrPhotos(string tag)
    {
        WebClient client = new WebClient();
        string feedUrlFormat = "http://api.flickr.com/services/feeds/" +
           "photos_public.gne?tags={0}&amp;format={1}";
        string url = String.Format(feedUrlFormat, tag, "rss2");
        byte[] data = client.DownloadData(url);
        MemoryStream stream = new MemoryStream(data);

        XmlDocument document = new XmlDocument();
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(document.NameTable);
        nsmgr.AddNamespace("media", "http://search.yahoo.com/mrss/");
        nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");

        document.Load(stream);
        document.Normalize();

        XmlNode channelNode = document.SelectSingleNode("/rss/channel");
        if (channelNode != null)
        {
            XmlNodeList itemNodes = channelNode.SelectNodes("item");
            foreach (XmlNode itemNode in itemNodes)
            {
                XmlNode titleNode = 
                  itemNode.SelectSingleNode("title");
                XmlNode dateTakenNode = 
                  itemNode.SelectSingleNode(
                  "dc:date.Taken", nsmgr);
                XmlNode urlNode = itemNode.SelectSingleNode(
                  "media:content/@url", nsmgr);
                XmlNode heightNode = itemNode.SelectSingleNode(
                  "media:content/@height", nsmgr);
                XmlNode widthNode = itemNode.SelectSingleNode(
                  "media:content/@width", nsmgr);
                XmlNode tagsNode = itemNode.SelectSingleNode(
                  "media:category", nsmgr);

                string title = titleNode.FirstChild.Value;
                DateTime dateTaken;
                DateTime.TryParse(dateTakenNode.FirstChild.Value, out dateTaken);
                int width;
                int height;
                string photoUrl = urlNode.Value;
                string tags = tagsNode.InnerText;
                int.TryParse(widthNode.Value, out width);
                int.TryParse(heightNode.Value, out height);

                Console.WriteLine("title: " + title);
                Console.WriteLine("dateTaken: " + dateTaken);
                Console.WriteLine("photoUrl: " + photoUrl);
                Console.WriteLine("tags: " + tags);
                Console.WriteLine("width: " + width);
                Console.WriteLine("height: " + height);
                Console.WriteLine("title: " + title);

                //TODO use these values to download and save the file
                
            }
        }
    }

    public static void CreateFlickrAlbums(string username)
    {
        PhotoAlbumProvider provider = PhotoAlbumService.Instance;

        Dictionary<String, String> defaultAlbums = 
          new Dictionary<string, string>();
        defaultAlbums.Add("Forest Album", "forest");
        defaultAlbums.Add("Summer Album", "summer");
        defaultAlbums.Add("Water Album", "water");

        List<Album> albums = provider.GetAlbums(username);
        foreach (Album album in albums)
        {
            // start from scratch
            if (defaultAlbums.ContainsKey(album.Name))
            {
                // delete photos first
                foreach (Photo photo in album.Photos)
                {
                    provider.PhotoDeletePermanent(photo);
                }
                provider.AlbumDeletePermanent(album);
            }
        }

        foreach (string albumName in defaultAlbums.Keys)
        {
            CreateFlickrAlbums(username, albumName, defaultAlbums[albumName]);
        }

        RepopulateSiteMap();
    }

    private static void CreateFlickrAlbums(string username, 
        string albumName, string flickrTag)
    {
        PhotoAlbumProvider provider = PhotoAlbumService.Instance;
        Album album = provider.AlbumInsert(username, albumName, true, true);
        ImportFlickrPhotosToAlbum(album, flickrTag);        
    }

    private static void DeleteFlickAlbum(string username, 
        string albumName)
    {
        PhotoAlbumProvider provider = PhotoAlbumService.Instance;
        List<Album> albums = provider.GetAlbums(username);
        foreach (Album album in albums)
        {
            // start from scratch
            if (album.Name.Equals(albumName))
            {
                // delete photos first
                foreach (Photo photo in album.Photos)
                {
                    provider.PhotoDeletePermanent(photo);
                }
                provider.AlbumDeletePermanent(album);
            }
        }
    }

    public static void RemoveFlickAlbum(string username,
        string albumName)
    {
        DeleteFlickAlbum(username, albumName);
        RepopulateSiteMap();
    }

    public static void AddFlickrAlbum(string username,
        string albumName, string flickrTag)
    {
        CreateFlickrAlbums(username, albumName, flickrTag);
        RepopulateSiteMap();
    }

    private static void RepopulateSiteMap()
    {
        string connStringName = GetSqlSiteMapConnectionString();
        SqlSiteMapHelper helper = new SqlSiteMapHelper(connStringName);
        helper.RepopulateSiteMapNodes();
    }

    public static string GetSqlSiteMapConnectionString()
    {
        string connStringName = String.Empty;
         SiteMapSection siteMapSection =
            ConfigurationManager.GetSection("system.web/siteMap") 
              as SiteMapSection;
         if (siteMapSection != null)
         {
             string defaultProvider = siteMapSection.DefaultProvider;
             connStringName =
                siteMapSection.Providers[defaultProvider].
                Parameters["connectionStringName"];
         }
        return connStringName;
    }
}
