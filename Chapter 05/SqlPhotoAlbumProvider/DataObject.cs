using System;
using System.Data;
using System.Reflection;

namespace Chapter05.PhotoAlbumProvider
{
    /// <summary>
    /// DataObject
    /// </summary>
    public abstract class DataObject : IComparable
    {

        /// <summary>
        /// Default Datetime
        /// </summary>
        public readonly static DateTime DefaultDatetime =
            DateTime.Parse("01/01/1754");

        /// <summary>
        /// Object ID
        /// </summary>
        public abstract long ID { get; set; }

        /// <summary>
        /// Loads the values from the DataRow and works to match up column names
        /// with Property names.  For example <code>row["Name"] = this.Name</code>
        /// and <code>row["IsActive"] = this.IsActive</code> where String typed
        /// properties are treated as strings and other types are treated properly.
        /// Supported types include String, Boolean, Float, Int and DateTime.
        /// The Property must also be set as public, not protected and also be
        /// writeable.
        /// </summary>
        /// <param name="row"></param>
        protected internal void LoadDataRow(DataRow row)
        {
            Type type = GetType();
            foreach (PropertyInfo pi in type.GetProperties())
            {
                if (pi.CanWrite)
                {
                    if (pi.PropertyType.Equals(typeof(DateTime)))
                    {
                        if (row[pi.Name] != null)
                        {
                            pi.SetValue(this, 
                GetNotNullDateTime(row, pi.Name), null);
                        }
                    }
                    else if (pi.PropertyType.Equals(typeof(Boolean)))
                    {
                        if (row[pi.Name] != null)
                        {
                            if ("1".Equals(row[pi.Name]))
                            {
                                pi.SetValue(this, true, null);
                            }
                            else
                            {
                                pi.SetValue(this, false, null);
                            }
                        }
                    }
                    else if (pi.PropertyType.Equals(typeof(float)))
                    {
                        if (row[pi.Name] != null)
                        {
                            pi.SetValue(this, GetNotNullFloat(row, pi.Name), null);
                        }
                    }
                    else if (pi.PropertyType.Equals(typeof(String)))
                    {
                        if (row[pi.Name] != null)
                        {
                            pi.SetValue(this, 
                              GetNotNullString(row, pi.Name), null);
                        }
                    }
                    else if (pi.PropertyType.Equals(typeof(int)))
                    {
                        if (row[pi.Name] != null)
                        {
                            pi.SetValue(this,
                              GetNotNullInteger(row, pi.Name), null);
                        }
                    }
                    else if (pi.PropertyType.Equals(typeof(Int64)))
                    {
                        if (row[pi.Name] != null)
                        {
                            pi.SetValue(this, GetNotNullLong(row, pi.Name), null);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Utility Method
        /// </summary>
        protected internal DateTime GetNotNullDateTime(DataRow row, String name)
        {
            Object obj = row[name];
            if (!DBNull.Value.Equals(obj))
            {
                return (DateTime)obj;
            }
            else
            {
                return DefaultDatetime;
            }
        }

        /// <summary>
        /// Utility Method
        /// </summary>
        protected internal String GetNotNullString(DataRow row, String name)
        {
            Object obj = row[name];
            if (!DBNull.Value.Equals(obj))
            {
                return (String)obj;
            }
            else
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Utility Method
        /// </summary>
        protected internal int GetNotNullInteger(DataRow row, String name)
        {
            Object obj = row[name];
            if (!DBNull.Value.Equals(obj) && obj is Int32)
            {
                return (int)obj;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Utility Method
        /// </summary>
        protected internal long GetNotNullLong(DataRow row, String name)
        {
            Object obj = row[name];
            if (!DBNull.Value.Equals(obj) && obj is Int64)
            {
                return (long)obj;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Utility Method
        /// </summary>
        protected internal float GetNotNullFloat(DataRow row, String name)
        {
            Object obj = row[name];
            if (!DBNull.Value.Equals(obj) && obj is float)
            {
                return (float)obj;
            }
            else
            {
                return 0;
            }
        }

        private DateTime _created = DefaultDatetime;
        /// <summary>
        /// Object creation time
        /// </summary>
        public DateTime Created
        {
            get
            {
                return _created;
            }
            set
            {
                _created = value;
            }
        }

        private DateTime _modified = DefaultDatetime;
        /// <summary>
        /// Object modiefied time
        /// </summary>
        public DateTime Modified
        {
            get
            {
                return _modified;
            }
            set
            {
                _modified = value;
            }
        }

        /// <summary>
        /// Base override
        /// </summary>
        public int CompareTo(Object obj)
        {
            int result = 0;
            if (obj is DataObject)
            {
                DataObject other = (DataObject) obj;
                result = Created.CompareTo(other.Created) * (-1);
            }
            return result;
        }

        /// <summary>
        /// Base override
        /// </summary>
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        /// <summary>
        /// Base override
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is DataObject) {
                if (ID.Equals(((DataObject)obj).ID))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
