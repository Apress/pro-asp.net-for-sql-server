using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration.Provider;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Chapter05.PhotoAlbumProvider
{
    public class SqlPhotoAlbumProvider : PhotoAlbumProvider
    {

        #region "  Variables  "
        
        string connStringName = String.Empty;
        private Database db;

        #endregion

        #region "  Implementation Methods  "

        /// <summary>
        /// SQL Implementation
        /// </summary>
        public override void Initialize(string name, 
      NameValueCollection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            if (String.IsNullOrEmpty(name))
            {
                name = "SqlPhotoAlbumProvider";
            }

            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "SQL Photo Album Provider");
            }

            base.Initialize(name, config);

            if (config["connectionStringName"] == null)
            {
                throw new ProviderException(
                    "Required attribute missing: connectionStringName");
            }

            connStringName = config["connectionStringName"].ToString();
            config.Remove("connectionStringName");

            if (WebConfigurationManager.ConnectionStrings[connStringName] == null)
            {
                throw new ProviderException("Missing connection string");
            }

            db = DatabaseFactory.CreateDatabase(connStringName);

            if (config.Count > 0)
            {
                string attr = config.GetKey(0);
                if (!String.IsNullOrEmpty(attr))
                {
                    throw new ProviderException("Unrecognized attribute: " + attr);
                }
            }
        }

        /// <summary>
        /// SQL Implementation
        /// </summary>
        public override List<Album> GetAlbums(string userName)
        {
            // use cache with a 5 second window
            String cacheKey = "PhotoAlbum::" + userName;
            object obj = HttpRuntime.Cache.Get(cacheKey);
            if (obj != null)
            {
                return (List<Album>)obj;
            }
            List<Album> albums = new List<Album>();

            try
            {
                using (DbCommand dbCmd = 
                  db.GetStoredProcCommand("pap_GetAlbumsByUserName"))
                {
                    db.AddInParameter(dbCmd, "@UserName", DbType.String, userName);

                    DataSet ds = db.ExecuteDataSet(dbCmd);

                    // populate the album collection
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            Album album = new Album();
                            album.LoadDataRow(row);
                            albums.Add(album);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError("Exception with pap_GetAlbumsByUserName", ex);
            }

            // cache for 5 seconds
            HttpRuntime.Cache.Insert(cacheKey, albums, null,
                DateTime.Now.AddSeconds(5), TimeSpan.Zero);

            //return the results
            return albums;
        }

        /// <summary>
        /// SQL Implementation
        /// </summary>
        public override List<Photo> GetPhotosByAlbum(Album album)
        {
            List<Photo> photos = new List<Photo>();

            try
            {
                using (DbCommand dbCmd = 
                  db.GetStoredProcCommand("pap_GetPhotosByAlbum"))
                {
                    db.AddInParameter(dbCmd, "@AlbumID", DbType.Int64, album.ID);

                    DataSet ds = db.ExecuteDataSet(dbCmd);

                    // populate the photos collection
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            Photo photo = new Photo();
                            photo.LoadDataRow(row);
                            photo.Album = album;
                            photos.Add(photo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError("Exception with pap_GetPhotosByAlbum", ex);
            }

            //return the results
            return photos;
        }

        /// <summary>
        /// SQL Implementation
        /// </summary>
        public override Album AlbumInsert(
          string userName, string albumName, bool active, bool shared)
        {

            try
            {
                using (DbCommand dbCmd = 
                  db.GetStoredProcCommand("pap_InsertAlbum"))
                {
                    db.AddInParameter(dbCmd, "@UserName", DbType.String, userName);
                    db.AddInParameter(dbCmd, "@Name", DbType.String, albumName);
                    db.AddInParameter(dbCmd, "@IsActive", DbType.Boolean, active);
                    db.AddInParameter(dbCmd, "@IsShared", DbType.Boolean, shared);

                    db.AddOutParameter(dbCmd, "@AlbumID", DbType.Int64, 0);

                    db.ExecuteNonQuery(dbCmd);
                    long albumId = (long)db.GetParameterValue(dbCmd, "@AlbumID");
                    ClearAlbumCache(userName);

                    List<Album> albums = GetAlbums(userName);
                    foreach (Album album in albums)
                    {
                        if (album.ID == albumId)
                        {
                            return album;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError("Exception with pap_InsertAlbum", ex);
            }

            throw new ApplicationException("New album not found");
        }
        /// <summary>
        /// SQL Implementation
        /// </summary>
        public override Photo PhotoInsert(Album album, string photoName, 
          DateTime photoDate,String regularUrl, int regularWidth, 
          int regularHeight, String thumbnailUrl, int thumbnailWidth, 
          int thumbnailHeight, bool active, bool shared)
        {
            try
            {
                using (DbCommand dbCmd = 
                  db.GetStoredProcCommand("pap_InsertPhoto"))
                {
                    if (photoName.Length > 40)
                    {
                        photoName = photoName.Substring(0, 40);
                    }
                    db.AddInParameter(dbCmd, "@AlbumID", 
                      DbType.Int64, album.ID);
                    db.AddInParameter(dbCmd, "@Name", 
                      DbType.String, photoName);
                    db.AddInParameter(dbCmd, "@PhotoDate", 
                      DbType.DateTime, photoDate);
                    db.AddInParameter(dbCmd, "@RegularUrl", 
                      DbType.String, regularUrl);
                    db.AddInParameter(dbCmd, "@RegularWidth", 
                      DbType.Int32, regularWidth);
                    db.AddInParameter(dbCmd, "@RegularHeight", 
                      DbType.Int32, regularHeight);
                    db.AddInParameter(dbCmd, "@ThumbnailUrl", 
                      DbType.String, thumbnailUrl);
                    db.AddInParameter(dbCmd, "@ThumbnailWidth", 
                      DbType.Int32, thumbnailWidth);
                    db.AddInParameter(dbCmd, "@ThumbnailHeight", 
                      DbType.Int32, thumbnailHeight);
                    db.AddInParameter(dbCmd, "@IsActive", 
                      DbType.Boolean, active);
                    db.AddInParameter(dbCmd, "@IsShared", 
                      DbType.Boolean, shared);

                    db.AddOutParameter(dbCmd, "@PhotoID", DbType.Int64, 0);

                    db.ExecuteNonQuery(dbCmd);
                    long photoId = (long)db.GetParameterValue(dbCmd, "@PhotoID");

                    List<Photo> photos = GetPhotosByAlbum(album);
                    foreach (Photo photo in photos)
                    {
                        if (photo.ID == photoId)
                        {
                            return photo;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError("Exception with pap_InsertPhoto", ex);
            }

            throw new ApplicationException("New photo not found");
        }

        /// <summary>
        /// SQL Implementation
        /// </summary>
        public override void AlbumUpdate(Album album)
        {
            try
            {
                using (DbCommand dbCmd = 
                  db.GetStoredProcCommand("pap_UpdateAlbum"))
                {
                    db.AddInParameter(dbCmd, "@AlbumID", 
                      DbType.Int64, album.ID);
                    db.AddInParameter(dbCmd, "@Name", 
                      DbType.String, album.Name);
                    db.AddInParameter(dbCmd, "@IsActive", 
                      DbType.String, album.IsActive);
                    db.AddInParameter(dbCmd, "@IsShared", 
                      DbType.String, album.IsShared);

                    db.ExecuteNonQuery(dbCmd);
                }
            }
            catch (Exception ex)
            {
                HandleError("Exception with pap_UpdateAlbum", ex);
            }
        }

        /// <summary>
        /// SQL Implementation
        /// </summary>
        public override void PhotoUpdate(Photo photo)
        {
            try
            {
                using (DbCommand dbCmd = 
                  db.GetStoredProcCommand("pap_UpdatePhoto"))
                {
                    db.AddInParameter(dbCmd, "@PhotoID", 
                      DbType.Int64, photo.ID);
                    db.AddInParameter(dbCmd, "@Name", 
                      DbType.String,photo.Name);
                    db.AddInParameter(dbCmd, "@PhotoDate", 
                      DbType.DateTime, photo.PhotoDate);
                    db.AddInParameter(dbCmd, "@RegularUrl", 
                      DbType.String, photo.RegularUrl);
                    db.AddInParameter(dbCmd, "@RegularWidth", 
                      DbType.Int32, photo.RegularWidth);
                    db.AddInParameter(dbCmd, "@RegularHeight", 
                      DbType.Int32, photo.RegularHeight);
                    db.AddInParameter(dbCmd, "@ThumbnailUrl", 
                      DbType.String, photo.ThumbnailUrl);
                    db.AddInParameter(dbCmd, "@ThumbnailWidth", 
                      DbType.Int32, photo.ThumbnailWidth);
                    db.AddInParameter(dbCmd, "@ThumbnailHeight", 
                      DbType.Int32, photo.ThumbnailHeight);
                    db.AddInParameter(dbCmd, "@IsActive", 
                      DbType.Boolean, photo.IsActive);
                    db.AddInParameter(dbCmd, "@IsShared", 
                      DbType.Boolean, photo.IsShared);

                    db.ExecuteNonQuery(dbCmd);
                    ClearAlbumCache(photo.Album.UserName);
                }
            }
            catch (Exception ex)
            {
                HandleError("Exception with pap_UpdatePhoto", ex);
            }
        }

        /// <summary>
        /// SQL Implementation
        /// </summary>
        /// <param name="album"></param>
        public override void AlbumDeletePermanent(Album album)
        {
            try
            {
                using (DbCommand dbCmd = 
                  db.GetStoredProcCommand("pap_DeleteAlbum"))
                {
                    db.AddInParameter(dbCmd, "@AlbumID", DbType.Int64, album.ID);

                    db.ExecuteNonQuery(dbCmd);
                    ClearAlbumCache(album.UserName);
                }
            }
            catch (Exception ex)
            {
                HandleError("Exception with pap_DeleteAlbum", ex);
            }
        }

        /// <summary>
        /// SQL Implementation
        /// </summary>
        public override void PhotoDeletePermanent(Photo photo)
        {
            try
            {
                using (DbCommand dbCmd = 
                  db.GetStoredProcCommand("pap_DeletePhoto"))
                {
                    db.AddInParameter(dbCmd, "@PhotoID", DbType.Int64, photo.ID);

                    db.ExecuteNonQuery(dbCmd);
                    ClearAlbumCache(photo.Album.UserName);
                }
            }
            catch (Exception ex)
            {
                HandleError("Exception with pap_DeletePhoto", ex);
            }
        }

        /// <summary>
        /// SQL Implementation
        /// </summary>
        public override void AlbumMove(Album album, string sourceUserName, 
      string destinationUserName)
        {
            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("pap_MoveAlbum"))
                {
                    db.AddInParameter(dbCmd, "@AlbumID", 
                      DbType.Int64, album.ID);
                    db.AddInParameter(dbCmd, "@SourceUserName", 
                      DbType.String, sourceUserName);
                    db.AddInParameter(dbCmd, "@DestinationUserName", 
                      DbType.String, destinationUserName);

                    db.ExecuteNonQuery(dbCmd);
                    ClearAlbumCache(sourceUserName);
                    ClearAlbumCache(destinationUserName);
                }
            }
            catch (Exception ex)
            {
                HandleError("Exception with pap_MoveAlbum", ex);
            }
        }

        /// <summary>
        /// SQL Implementation
        /// </summary>
        public override void PhotoMove(
            Photo photo, Album sourceAlbum, Album destinationAlbum)
        {
            try
            {
                using (DbCommand dbCmd = db.GetStoredProcCommand("pap_MovePhoto"))
                {
                    db.AddInParameter(dbCmd, "@PhotoID", 
                      DbType.Int64, photo.ID);
                    db.AddInParameter(dbCmd, "@SourceAlbumID", 
                      DbType.Int64, sourceAlbum.ID);
                    db.AddInParameter(dbCmd, "@DestinationAlbumID", 
                      DbType.Int64, destinationAlbum.ID);

                    db.ExecuteNonQuery(dbCmd);
                    sourceAlbum.ClearPhotos();
                    ClearAlbumCache(sourceAlbum.UserName);
                    destinationAlbum.ClearPhotos();
                    ClearAlbumCache(destinationAlbum.UserName);
                }
            }
            catch (Exception ex)
            {
                HandleError("Exception with pap_MoveAlbum", ex);
            }
        }

        #endregion

        #region "  Utility Methods  "

        private void HandleError(string message, Exception ex)
        {
            //TODO log the error
            throw new ApplicationException(message, ex);
        }

        /// <summary>
        /// SQL Implementation
        /// </summary>
        public void ClearAlbumCache(String userName)
        {
            String cacheKey = "PhotoAlbum::" + userName;
            if (HttpRuntime.Cache.Get(cacheKey) != null)
            {
                HttpRuntime.Cache.Remove(cacheKey);
            }
        }

        #endregion

    }
}
