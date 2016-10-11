using System;
using System.Collections.Generic;

namespace Chapter05.PhotoAlbumProvider
{
    /// <summary>
    /// Album
    /// </summary>
    public class Album : DataObject
    {

        #region "  Properties  "

        private long _id = 0;
        /// <summary>
        /// Object ID
        /// </summary>
        public override long ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private string _username;
        /// <summary>
        /// Owner's username
        /// </summary>
        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        private string _name;
        /// <summary>
        /// Album Name
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private bool _active = true;
        /// <summary>
        /// Indicates if an album is active
        /// </summary>
        public bool IsActive
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }

        private bool _shared = true;
        /// <summary>
        /// Indicates if an album is shared
        /// </summary>
        public bool IsShared
        {
            get
            {
                return _shared;
            }
            set
            {
                _shared = value;
            }
        }

        private List<Photo> _photos = null;
        /// <summary>
        /// Photos in album
        /// </summary>
        public List<Photo> Photos
        {
            get
            {
                if (_photos == null)
                {
                    _photos = PhotoAlbumService.Instance.GetPhotosByAlbum(this);
                }
                return _photos;
            }
        }

        #endregion

        #region "  Methods  "

        /// <summary>
        /// Clear Photos
        /// </summary>
        protected internal void ClearPhotos()
        {
            _photos = null;
        }

        /// <summary>
        /// Base override
        /// </summary>
        public override String ToString()
        {
            return Name;
        }

        #endregion

    }
}
