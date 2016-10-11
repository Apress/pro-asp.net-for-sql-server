using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using SubSonic;
using SubSonic.Utilities;


//Generated on 6/10/2007 10:07:00 PM by brennan

namespace Chapter08.NorthwindDAL{
    /// <summary>
    /// Strongly-typed collection for the TextEntry class.
    /// </summary>
    [Serializable]
    public partial class TextEntryCollection : ActiveList<TextEntry> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public TextEntryCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public TextEntryCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public TextEntryCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public TextEntryCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public TextEntryCollection Where(string columnName, object value) 
	    {
		    if(value != DBNull.Value && value != null)
		    {	
			    return Where(columnName, Comparison.Equals, value);
		    }

		    else
		    {
			    return Where(columnName, Comparison.Is, DBNull.Value);
		    }

        }

    	
        public TextEntryCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public TextEntryCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            BetweenAnd between = new BetweenAnd();
            between.ColumnName = columnName;
            between.StartDate = dateStart;
            between.EndDate = dateEnd;
            between.StartParameterName = "start" + columnName; 
            between.EndParameterName = "end" + columnName; 
            betweens.Add(between);
            return this;
        }

    	
        public TextEntryCollection Load() 
        {
            Query qry = new Query(TextEntry.Schema);
            CheckLogicalDelete(qry);
            foreach (Where where in wheres) 
            {
                qry.AddWhere(where);
            }

             
            foreach (BetweenAnd between in betweens)
            {
                qry.AddBetweenAnd(between);
            }

            if (orderBy != null)
            {
                qry.OrderBy = orderBy;
            }

            IDataReader rdr = qry.ExecuteReader();
            this.Load(rdr);
            rdr.Close();
            return this;
        }

        
        public TextEntryCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the TextEntry table.
    /// </summary>
    [Serializable]
    public partial class TextEntry : ActiveRecord<TextEntry>
    {
    
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }

	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }

                return BaseSchema;
            }

        }

    	
        private static void GetTableSchema() 
	    {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
				TableSchema.Table schema = new TableSchema.Table("TextEntry", TableType.Table, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarContentID = new TableSchema.TableColumn(schema);
                colvarContentID.ColumnName = "contentID";
                colvarContentID.DataType = DbType.Int32;
                colvarContentID.MaxLength = 0;
                colvarContentID.AutoIncrement = true;
                colvarContentID.IsNullable = false;
                colvarContentID.IsPrimaryKey = true;
                colvarContentID.IsForeignKey = false;
                colvarContentID.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarContentID);
                
                TableSchema.TableColumn colvarContentGUID = new TableSchema.TableColumn(schema);
                colvarContentGUID.ColumnName = "contentGUID";
                colvarContentGUID.DataType = DbType.Guid;
                colvarContentGUID.MaxLength = 0;
                colvarContentGUID.AutoIncrement = false;
                colvarContentGUID.IsNullable = false;
                colvarContentGUID.IsPrimaryKey = false;
                colvarContentGUID.IsForeignKey = false;
                colvarContentGUID.IsReadOnly = false;
                
						colvarContentGUID.DefaultSetting = @"(newid())";
				
                
                schema.Columns.Add(colvarContentGUID);
                
                TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
                colvarTitle.ColumnName = "title";
                colvarTitle.DataType = DbType.String;
                colvarTitle.MaxLength = 500;
                colvarTitle.AutoIncrement = false;
                colvarTitle.IsNullable = true;
                colvarTitle.IsPrimaryKey = false;
                colvarTitle.IsForeignKey = false;
                colvarTitle.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarTitle);
                
                TableSchema.TableColumn colvarContentName = new TableSchema.TableColumn(schema);
                colvarContentName.ColumnName = "contentName";
                colvarContentName.DataType = DbType.String;
                colvarContentName.MaxLength = 50;
                colvarContentName.AutoIncrement = false;
                colvarContentName.IsNullable = false;
                colvarContentName.IsPrimaryKey = false;
                colvarContentName.IsForeignKey = false;
                colvarContentName.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarContentName);
                
                TableSchema.TableColumn colvarContent = new TableSchema.TableColumn(schema);
                colvarContent.ColumnName = "content";
                colvarContent.DataType = DbType.String;
                colvarContent.MaxLength = 3000;
                colvarContent.AutoIncrement = false;
                colvarContent.IsNullable = true;
                colvarContent.IsPrimaryKey = false;
                colvarContent.IsForeignKey = false;
                colvarContent.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarContent);
                
                TableSchema.TableColumn colvarIconPath = new TableSchema.TableColumn(schema);
                colvarIconPath.ColumnName = "iconPath";
                colvarIconPath.DataType = DbType.String;
                colvarIconPath.MaxLength = 250;
                colvarIconPath.AutoIncrement = false;
                colvarIconPath.IsNullable = true;
                colvarIconPath.IsPrimaryKey = false;
                colvarIconPath.IsForeignKey = false;
                colvarIconPath.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarIconPath);
                
                TableSchema.TableColumn colvarDateExpires = new TableSchema.TableColumn(schema);
                colvarDateExpires.ColumnName = "dateExpires";
                colvarDateExpires.DataType = DbType.DateTime;
                colvarDateExpires.MaxLength = 0;
                colvarDateExpires.AutoIncrement = false;
                colvarDateExpires.IsNullable = true;
                colvarDateExpires.IsPrimaryKey = false;
                colvarDateExpires.IsForeignKey = false;
                colvarDateExpires.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarDateExpires);
                
                TableSchema.TableColumn colvarLastEditedBy = new TableSchema.TableColumn(schema);
                colvarLastEditedBy.ColumnName = "lastEditedBy";
                colvarLastEditedBy.DataType = DbType.String;
                colvarLastEditedBy.MaxLength = 100;
                colvarLastEditedBy.AutoIncrement = false;
                colvarLastEditedBy.IsNullable = true;
                colvarLastEditedBy.IsPrimaryKey = false;
                colvarLastEditedBy.IsForeignKey = false;
                colvarLastEditedBy.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarLastEditedBy);
                
                TableSchema.TableColumn colvarExternalLink = new TableSchema.TableColumn(schema);
                colvarExternalLink.ColumnName = "externalLink";
                colvarExternalLink.DataType = DbType.String;
                colvarExternalLink.MaxLength = 250;
                colvarExternalLink.AutoIncrement = false;
                colvarExternalLink.IsNullable = true;
                colvarExternalLink.IsPrimaryKey = false;
                colvarExternalLink.IsForeignKey = false;
                colvarExternalLink.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarExternalLink);
                
                TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
                colvarStatus.ColumnName = "status";
                colvarStatus.DataType = DbType.String;
                colvarStatus.MaxLength = 50;
                colvarStatus.AutoIncrement = false;
                colvarStatus.IsNullable = true;
                colvarStatus.IsPrimaryKey = false;
                colvarStatus.IsForeignKey = false;
                colvarStatus.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarStatus);
                
                TableSchema.TableColumn colvarListOrder = new TableSchema.TableColumn(schema);
                colvarListOrder.ColumnName = "listOrder";
                colvarListOrder.DataType = DbType.Int32;
                colvarListOrder.MaxLength = 0;
                colvarListOrder.AutoIncrement = false;
                colvarListOrder.IsNullable = false;
                colvarListOrder.IsPrimaryKey = false;
                colvarListOrder.IsForeignKey = false;
                colvarListOrder.IsReadOnly = false;
                
						colvarListOrder.DefaultSetting = @"((1))";
				
                
                schema.Columns.Add(colvarListOrder);
                
                TableSchema.TableColumn colvarCallOut = new TableSchema.TableColumn(schema);
                colvarCallOut.ColumnName = "callOut";
                colvarCallOut.DataType = DbType.String;
                colvarCallOut.MaxLength = 250;
                colvarCallOut.AutoIncrement = false;
                colvarCallOut.IsNullable = true;
                colvarCallOut.IsPrimaryKey = false;
                colvarCallOut.IsForeignKey = false;
                colvarCallOut.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarCallOut);
                
                TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
                colvarCreatedOn.ColumnName = "createdOn";
                colvarCreatedOn.DataType = DbType.DateTime;
                colvarCreatedOn.MaxLength = 0;
                colvarCreatedOn.AutoIncrement = false;
                colvarCreatedOn.IsNullable = true;
                colvarCreatedOn.IsPrimaryKey = false;
                colvarCreatedOn.IsForeignKey = false;
                colvarCreatedOn.IsReadOnly = false;
                
						colvarCreatedOn.DefaultSetting = @"(getdate())";
				
                
                schema.Columns.Add(colvarCreatedOn);
                
                TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
                colvarCreatedBy.ColumnName = "createdBy";
                colvarCreatedBy.DataType = DbType.String;
                colvarCreatedBy.MaxLength = 50;
                colvarCreatedBy.AutoIncrement = false;
                colvarCreatedBy.IsNullable = true;
                colvarCreatedBy.IsPrimaryKey = false;
                colvarCreatedBy.IsForeignKey = false;
                colvarCreatedBy.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarCreatedBy);
                
                TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
                colvarModifiedOn.ColumnName = "modifiedOn";
                colvarModifiedOn.DataType = DbType.DateTime;
                colvarModifiedOn.MaxLength = 0;
                colvarModifiedOn.AutoIncrement = false;
                colvarModifiedOn.IsNullable = true;
                colvarModifiedOn.IsPrimaryKey = false;
                colvarModifiedOn.IsForeignKey = false;
                colvarModifiedOn.IsReadOnly = false;
                
						colvarModifiedOn.DefaultSetting = @"(getdate())";
				
                
                schema.Columns.Add(colvarModifiedOn);
                
                TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
                colvarModifiedBy.ColumnName = "modifiedBy";
                colvarModifiedBy.DataType = DbType.String;
                colvarModifiedBy.MaxLength = 50;
                colvarModifiedBy.AutoIncrement = false;
                colvarModifiedBy.IsNullable = true;
                colvarModifiedBy.IsPrimaryKey = false;
                colvarModifiedBy.IsForeignKey = false;
                colvarModifiedBy.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarModifiedBy);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("TextEntry",schema);
            }

        }

        #endregion
        
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }

	    #endregion
	    
	    #region .ctors
	    public TextEntry()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public TextEntry(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public TextEntry(string columnName, object columnValue)
        {
            SetSQLProps();
            SetDefaults();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("ContentID")]
        public int ContentID 
	    {
		    get { return GetColumnValue<int>("contentID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("contentID", value);
            }

        }

	      
        [XmlAttribute("ContentGUID")]
        public Guid ContentGUID 
	    {
		    get { return GetColumnValue<Guid>("contentGUID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("contentGUID", value);
            }

        }

	      
        [XmlAttribute("Title")]
        public string Title 
	    {
		    get { return GetColumnValue<string>("title"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("title", value);
            }

        }

	      
        [XmlAttribute("ContentName")]
        public string ContentName 
	    {
		    get { return GetColumnValue<string>("contentName"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("contentName", value);
            }

        }

	      
        [XmlAttribute("Content")]
        public string Content 
	    {
		    get { return GetColumnValue<string>("content"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("content", value);
            }

        }

	      
        [XmlAttribute("IconPath")]
        public string IconPath 
	    {
		    get { return GetColumnValue<string>("iconPath"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("iconPath", value);
            }

        }

	      
        [XmlAttribute("DateExpires")]
        public DateTime? DateExpires 
	    {
		    get { return GetColumnValue<DateTime?>("dateExpires"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("dateExpires", value);
            }

        }

	      
        [XmlAttribute("LastEditedBy")]
        public string LastEditedBy 
	    {
		    get { return GetColumnValue<string>("lastEditedBy"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("lastEditedBy", value);
            }

        }

	      
        [XmlAttribute("ExternalLink")]
        public string ExternalLink 
	    {
		    get { return GetColumnValue<string>("externalLink"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("externalLink", value);
            }

        }

	      
        [XmlAttribute("Status")]
        public string Status 
	    {
		    get { return GetColumnValue<string>("status"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("status", value);
            }

        }

	      
        [XmlAttribute("ListOrder")]
        public int ListOrder 
	    {
		    get { return GetColumnValue<int>("listOrder"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("listOrder", value);
            }

        }

	      
        [XmlAttribute("CallOut")]
        public string CallOut 
	    {
		    get { return GetColumnValue<string>("callOut"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("callOut", value);
            }

        }

	      
        [XmlAttribute("CreatedOn")]
        public DateTime? CreatedOn 
	    {
		    get { return GetColumnValue<DateTime?>("createdOn"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("createdOn", value);
            }

        }

	      
        [XmlAttribute("CreatedBy")]
        public string CreatedBy 
	    {
		    get { return GetColumnValue<string>("createdBy"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("createdBy", value);
            }

        }

	      
        [XmlAttribute("ModifiedOn")]
        public DateTime? ModifiedOn 
	    {
		    get { return GetColumnValue<DateTime?>("modifiedOn"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("modifiedOn", value);
            }

        }

	      
        [XmlAttribute("ModifiedBy")]
        public string ModifiedBy 
	    {
		    get { return GetColumnValue<string>("modifiedBy"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("modifiedBy", value);
            }

        }

	    
	    #endregion
	    
	    
	 	
			
	    
	    //no foreign key tables defined (0)
	    
	    
	    
	    //no ManyToMany tables defined (0)
	    
	    #region ObjectDataSource support
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(Guid varContentGUID,string varTitle,string varContentName,string varContent,string varIconPath,DateTime? varDateExpires,string varLastEditedBy,string varExternalLink,string varStatus,int varListOrder,string varCallOut,DateTime? varCreatedOn,string varCreatedBy,DateTime? varModifiedOn,string varModifiedBy)
	    {
		    TextEntry item = new TextEntry();
		    
            item.ContentGUID = varContentGUID;
            
            item.Title = varTitle;
            
            item.ContentName = varContentName;
            
            item.Content = varContent;
            
            item.IconPath = varIconPath;
            
            item.DateExpires = varDateExpires;
            
            item.LastEditedBy = varLastEditedBy;
            
            item.ExternalLink = varExternalLink;
            
            item.Status = varStatus;
            
            item.ListOrder = varListOrder;
            
            item.CallOut = varCallOut;
            
            item.CreatedOn = varCreatedOn;
            
            item.CreatedBy = varCreatedBy;
            
            item.ModifiedOn = varModifiedOn;
            
            item.ModifiedBy = varModifiedBy;
            
	    
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(int varContentID,Guid varContentGUID,string varTitle,string varContentName,string varContent,string varIconPath,DateTime? varDateExpires,string varLastEditedBy,string varExternalLink,string varStatus,int varListOrder,string varCallOut,DateTime? varCreatedOn,string varCreatedBy,DateTime? varModifiedOn,string varModifiedBy)
	    {
		    TextEntry item = new TextEntry();
		    
                item.ContentID = varContentID;
				
                item.ContentGUID = varContentGUID;
				
                item.Title = varTitle;
				
                item.ContentName = varContentName;
				
                item.Content = varContent;
				
                item.IconPath = varIconPath;
				
                item.DateExpires = varDateExpires;
				
                item.LastEditedBy = varLastEditedBy;
				
                item.ExternalLink = varExternalLink;
				
                item.Status = varStatus;
				
                item.ListOrder = varListOrder;
				
                item.CallOut = varCallOut;
				
                item.CreatedOn = varCreatedOn;
				
                item.CreatedBy = varCreatedBy;
				
                item.ModifiedOn = varModifiedOn;
				
                item.ModifiedBy = varModifiedBy;
				
		    item.IsNew = false;
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

	    #endregion
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string ContentID = @"contentID";
            
            public static string ContentGUID = @"contentGUID";
            
            public static string Title = @"title";
            
            public static string ContentName = @"contentName";
            
            public static string Content = @"content";
            
            public static string IconPath = @"iconPath";
            
            public static string DateExpires = @"dateExpires";
            
            public static string LastEditedBy = @"lastEditedBy";
            
            public static string ExternalLink = @"externalLink";
            
            public static string Status = @"status";
            
            public static string ListOrder = @"listOrder";
            
            public static string CallOut = @"callOut";
            
            public static string CreatedOn = @"createdOn";
            
            public static string CreatedBy = @"createdBy";
            
            public static string ModifiedOn = @"modifiedOn";
            
            public static string ModifiedBy = @"modifiedBy";
            
	    }

	    #endregion
    }

}

