using System;

namespace Chapter05.PhotoAlbumProvider
{
    /// <summary>
    /// Photo
    /// </summary>
    public class Photo : DataObject
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

        private string _name;
        /// <summary>
        /// Name of photo
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

        private DateTime _photoDate = DefaultDatetime;
        /// <summary>
        /// Date photo was taken
        /// </summary>
        public DateTime PhotoDate
        {
            get
            {
                return _photoDate;
            }
            set
            {
                _photoDate = value;
            }
        }

        private bool _active = true;
        /// <summary>
        /// Indicates if photo is active
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
        /// Indicates if photo is shared
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

        private string _regularUrl = String.Empty;
        /// <summary>
        /// Url for photo
        /// </summary>
        public string RegularUrl
        {
            get
            {
                return _regularUrl;
            }
            set
            {
                _regularUrl = value;
            }
        }

        private int _regularWidth = 0;
        /// <summary>
        /// Width for photo
        /// </summary>
        public int RegularWidth
        {
            get
            {
                return _regularWidth;
            }
            set
            {
                _regularWidth = value;
            }
        }

        private int _regularHeight = 0;
        /// <summary>
        /// Height for photo
        /// </summary>
        public int RegularHeight
        {
            get
            {
                return _regularHeight;
            }
            set
            {
                _regularHeight = value;
            }
        }

        private string _thumbnailUrl = String.Empty;
        /// <summary>
        /// Thumbnail url for photo
        /// </summary>
        public string ThumbnailUrl
        {
            get
            {
                return _thumbnailUrl;
            }
            set
            {
                _thumbnailUrl = value;
            }
        }

        private int _thumbnailWidth = 0;
        /// <summary>
        /// Thumbnail width for photo
        /// </summary>
        public int ThumbnailWidth
        {
            get
            {
                return _thumbnailWidth;
            }
            set
            {
                _thumbnailWidth = value;
            }
        }

        private int _thumbnailHeight = 0;
        /// <summary>
        /// Thumbnail height for photo
        /// </summary>
        public int ThumbnailHeight
        {
            get
            {
                return _thumbnailHeight;
            }
            set
            {
                _thumbnailHeight = value;
            }
        }

        private Album _album = null;
        /// <summary>
        /// Album which holds this photo
        /// </summary>
        public Album Album
        {
            get
            {
                return _album;
            }
            set
            {
                // should be set when pulled by album
                _album = value;
            }
        }

        #endregion

    }
}
