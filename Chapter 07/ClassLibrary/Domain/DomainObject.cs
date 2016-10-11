using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;

namespace Chapter07.Domain
{

    /// <summary>
    /// DataObject
    /// </summary>
    public abstract class DomainObject : IComparable
    {

        #region "  Variables  "

        public static readonly DateTime DefaultDateTime = DateTime.Parse("01/01/1754");

        private static List<string> _mappings = null;

        #endregion

        #region "  Protected and Overridable Load Methods  "

        /// <summary>
        /// Loads the values from the DataRow and works to match up column names
        /// with Property names.  For example <code>row["Name"] = this.Name</code>
        /// and <code>row["IsActive"] = this.IsActive</code>. The Property must 
        /// also be set as public, not protected and also be writeable.
        /// </summary>
        /// <param name="row"></param>
        protected virtual internal void Load(DataRow row)
        {
            List<string> mappings = GetMappings(row.Table);

            foreach (string name in mappings) 
            {
                SetValue(this, name, row);
            }
        }

        protected virtual internal void Load(IDataReader dr)
        {
            List<string> mappings = GetMappings(dr);

            foreach (string name in mappings)
            {
                SetValue(this, name, dr);
            }

        }

        #endregion

        #region "  Private Load Methods  "

        private List<string> GetMappings(DataTable dataTable)
        {
            if (_mappings == null)
            {
                _mappings = CreateMappings(dataTable);
            }
            return _mappings;
        }

        private List<string> GetMappings(IDataReader dr)
        {
            if (_mappings == null)
            {
                _mappings = CreateMappings(dr);
            }
            return _mappings;
        }

        private List<string> CreateMappings(DataTable dataTable)
        {
            List<string> mappings = new List<string>();
            Type type = GetType();

            foreach (PropertyInfo pi in type.GetProperties())
            {
                if (pi.CanWrite && 
                    dataTable.Columns.Contains(pi.Name) && 
                    dataTable.Columns[pi.Name].DataType.Equals(pi.PropertyType))
                {
                    mappings.Add(pi.Name);
                    GetProperty(pi.Name);
                }
            }
            return mappings;
        }

        private List<string> CreateMappings(IDataReader dr)
        {
            List<string> mappings = new List<string>();
            Type type = GetType();

            for (int i=0;i<dr.FieldCount;i++)
            {
                PropertyInfo pi = GetProperty(dr.GetName(i));
                if (pi != null &&
                    pi.CanWrite &&
                    pi.PropertyType.Equals(dr.GetFieldType(i)))
                {
                    mappings.Add(dr.GetName(i));
                }
            }

            return mappings;
        }

        private void SetValue(DomainObject domainObject, string name, DataRow row)
        {
            PropertyInfo pi = GetProperty(name);
            if (!DBNull.Value.Equals(row[name]))
            {
                pi.SetValue(domainObject, row[name], null);
            }
        }

        private void SetValue(DomainObject domainObject, string name, IDataReader dr)
        {
            PropertyInfo pi = GetProperty(name);
            if (!DBNull.Value.Equals(dr[name]))
            {
                pi.SetValue(domainObject, dr[name], null);
            }
        }

        private static Dictionary<string,PropertyInfo> _properties = new Dictionary<string,PropertyInfo>();

        private PropertyInfo GetProperty(string name)
        {
            if (!_properties.ContainsKey(name))
            {
                _properties[name] = GetType().GetProperty(name);
            }
            return _properties[name];
        }

        #endregion

        #region "  Properties  "

        /// <summary>
        /// Object ID
        /// </summary>
        public abstract long ID { get; set; }

        private DateTime _created = DefaultDateTime;
        /// <summary>
        /// Object created time
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

        private DateTime _modified = DefaultDateTime;
        /// <summary>
        /// Object modified time
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

        #endregion

        #region "  IComparable Implementation  "

        /// <summary>
        /// Base override
        /// </summary>
        public int CompareTo(Object obj)
        {
            int result = 0;
            DomainObject otherDomainObject = obj as DomainObject;
            if (otherDomainObject != null)
            {
                result = Created.CompareTo(otherDomainObject.Created) * (-1);
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
            DomainObject domainObject = obj as DomainObject;
            if (domainObject != null)
            {
                if (ID.Equals(domainObject.ID))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

    }
}
