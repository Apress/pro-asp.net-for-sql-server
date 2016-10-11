using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Chapter07.Domain
{
    public enum CastingMode
    {
        DirectCasting,
        ReflectionCasting
    }

    public class FavoriteLink : DomainObject
    {
        internal FavoriteLink(DataRow row)
        {
            if (SelectedCastingMode == CastingMode.ReflectionCasting)
            {
                Load(row);
            }
            else
            {
                LoadWithDirectCasting(row);
            }
        }

        internal FavoriteLink(IDataReader dr)
        {
            Load(dr);
        }

        public static CastingMode _castingMode = CastingMode.ReflectionCasting;

        public static CastingMode SelectedCastingMode
        {
            get
            {
                return _castingMode;
            }
            set
            {
                _castingMode = value;
            }
        }

        private long _id;
        public override long ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _url;
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private bool _keeper;
        public bool Keeper
        {
            get { return _keeper; }
            set { _keeper = value; }
        }

        private short _rating;
        public short Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        private string _note;
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        private string _tags;
        public string Tags
        {
            get {
                if (String.IsNullOrEmpty(_tags))
                {
                    DataSet ds = Domain.GetLinkTagsByFavoriteLinkID(ID);
                    StringBuilder sb = new StringBuilder();
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            sb.Append(row["Token"]);
                            sb.Append(" ");
                        }
                        _tags = sb.ToString().Trim();
                    }
                }
                return _tags; 
            }
        }

        protected void LoadWithDirectCasting(DataRow row)
        {
            try
            {
                ID = (long)row["ID"];
                Url = (string)row["Url"];
                Title = (string)row["Title"];
                Keeper = (bool)row["Keeper"];
                Rating = (short)row["Rating"];
                Note = (string)row["Note"];
                Created = (DateTime)row["Created"];
                Modified = (DateTime)row["Modified"];
            }
            catch (Exception ex)
            {
                // TODO log the exception
                throw new DomainException("Failure loading data");
            }
        }

        private static FavoriteLinkDomain _domain = null;
        public static FavoriteLinkDomain Domain
        {
            get
            {
                if (_domain == null)
                {
                    _domain = new FavoriteLinkDomain();
                }
                return _domain;
            }
        }
    }
}
