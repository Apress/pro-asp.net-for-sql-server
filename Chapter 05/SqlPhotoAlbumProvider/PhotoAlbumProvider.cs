using System;
using System.Collections.Generic;
using System.Configuration.Provider;

namespace Chapter05.PhotoAlbumProvider
{
    /// <summary>
    /// Photo Album Provider
    /// </summary>
    public abstract class PhotoAlbumProvider : ProviderBase
    {

        #region "  Abstract Methods  "

        /// <summary>
        /// Gets albums for a user
        /// </summary>
        public abstract List<Album> GetAlbums(string userName);

        /// <summary>
        /// Gets photos for an album
        /// </summary>
        public abstract List<Photo> GetPhotosByAlbum(Album album);

        /// <summary>
        /// Creates an album
        /// </summary>
        public abstract Album AlbumInsert(string userName, string albumName, 
            bool active, bool shared);

        /// <summary>
        /// Creates a photo
        /// </summary>
        public abstract Photo PhotoInsert(Album album, string photoName, 
            DateTime photoDate, String regularUrl, int regularWidth, 
            int regularHeight, String thumbnailUrl, int thumbnailWidth, 
            int thumbnailHeight, bool active, bool shared);

        /// <summary>
        /// Updates an album
        /// </summary>
        public abstract void AlbumUpdate(Album album);

        /// <summary>
        /// Updates a photo
        /// </summary>
        public abstract void PhotoUpdate(Photo photo);

        /// <summary>
        /// Deletes an album
        /// </summary>
        public abstract void AlbumDeletePermanent(Album album);

        /// <summary>
        /// Deletes album permanently
        /// </summary>
        public abstract void PhotoDeletePermanent(Photo photo);

        /// <summary>
        /// Moves an album
        /// </summary>
        public abstract void AlbumMove(Album album, 
            string sourceUserName, string destinationUserName);

        /// <summary>
        /// Moves a photo
        /// </summary>
        public abstract void PhotoMove(Photo photo, Album sourceAlbum, 
            Album destinationAlbum);

        #endregion

    }
}
