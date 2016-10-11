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


//Generated on 6/10/2007 10:07:01 PM by brennan

namespace Chapter08.SubSonicDAL{
    /// <summary>
    /// Strongly-typed collection for the Location class.
    /// </summary>
    [Serializable]
    public partial class LocationCollection : ActiveList<Location> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public LocationCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public LocationCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public LocationCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public LocationCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public LocationCollection Where(string columnName, object value) 
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

    	
        public LocationCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public LocationCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public LocationCollection Load() 
        {
            Query qry = new Query(Location.Schema);
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

        
        public LocationCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Location table.
    /// </summary>
    [Serializable]
    public partial class Location : ActiveRecord<Location>
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
				TableSchema.Table schema = new TableSchema.Table("Location", TableType.Table, DataService.GetInstance("Chapter08"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarID = new TableSchema.TableColumn(schema);
                colvarID.ColumnName = "ID";
                colvarID.DataType = DbType.Int64;
                colvarID.MaxLength = 0;
                colvarID.AutoIncrement = true;
                colvarID.IsNullable = false;
                colvarID.IsPrimaryKey = true;
                colvarID.IsForeignKey = false;
                colvarID.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarID);
                
                TableSchema.TableColumn colvarCity = new TableSchema.TableColumn(schema);
                colvarCity.ColumnName = "City";
                colvarCity.DataType = DbType.String;
                colvarCity.MaxLength = 50;
                colvarCity.AutoIncrement = false;
                colvarCity.IsNullable = false;
                colvarCity.IsPrimaryKey = false;
                colvarCity.IsForeignKey = false;
                colvarCity.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarCity);
                
                TableSchema.TableColumn colvarState = new TableSchema.TableColumn(schema);
                colvarState.ColumnName = "State";
                colvarState.DataType = DbType.String;
                colvarState.MaxLength = 2;
                colvarState.AutoIncrement = false;
                colvarState.IsNullable = false;
                colvarState.IsPrimaryKey = false;
                colvarState.IsForeignKey = false;
                colvarState.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarState);
                
                TableSchema.TableColumn colvarCreation = new TableSchema.TableColumn(schema);
                colvarCreation.ColumnName = "Creation";
                colvarCreation.DataType = DbType.DateTime;
                colvarCreation.MaxLength = 0;
                colvarCreation.AutoIncrement = false;
                colvarCreation.IsNullable = false;
                colvarCreation.IsPrimaryKey = false;
                colvarCreation.IsForeignKey = false;
                colvarCreation.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarCreation);
                
                TableSchema.TableColumn colvarModified = new TableSchema.TableColumn(schema);
                colvarModified.ColumnName = "Modified";
                colvarModified.DataType = DbType.DateTime;
                colvarModified.MaxLength = 0;
                colvarModified.AutoIncrement = false;
                colvarModified.IsNullable = false;
                colvarModified.IsPrimaryKey = false;
                colvarModified.IsForeignKey = false;
                colvarModified.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarModified);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Chapter08"].AddSchema("Location",schema);
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
	    public Location()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public Location(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public Location(string columnName, object columnValue)
        {
            SetSQLProps();
            SetDefaults();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("ID")]
        public long ID 
	    {
		    get { return GetColumnValue<long>("ID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ID", value);
            }

        }

	      
        [XmlAttribute("City")]
        public string City 
	    {
		    get { return GetColumnValue<string>("City"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("City", value);
            }

        }

	      
        [XmlAttribute("State")]
        public string State 
	    {
		    get { return GetColumnValue<string>("State"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("State", value);
            }

        }

	      
        [XmlAttribute("Creation")]
        public DateTime Creation 
	    {
		    get { return GetColumnValue<DateTime>("Creation"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Creation", value);
            }

        }

	      
        [XmlAttribute("Modified")]
        public DateTime Modified 
	    {
		    get { return GetColumnValue<DateTime>("Modified"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Modified", value);
            }

        }

	    
	    #endregion
	    
	    
	    #region PrimaryKey Methods
	    
		public Chapter08.SubSonicDAL.PersonCollection PersonRecords()
		{
			return new Chapter08.SubSonicDAL.PersonCollection().Where(Person.Columns.LocationID, ID).Load();
		}

		#endregion
		
	 	
			
	    
	    //no foreign key tables defined (0)
	    
	    
	    
	    //no ManyToMany tables defined (0)
	    
	    #region ObjectDataSource support
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(string varCity,string varState,DateTime varCreation,DateTime varModified)
	    {
		    Location item = new Location();
		    
            item.City = varCity;
            
            item.State = varState;
            
            item.Creation = varCreation;
            
            item.Modified = varModified;
            
	    
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(long varID,string varCity,string varState,DateTime varCreation,DateTime varModified)
	    {
		    Location item = new Location();
		    
                item.ID = varID;
				
                item.City = varCity;
				
                item.State = varState;
				
                item.Creation = varCreation;
				
                item.Modified = varModified;
				
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
		    
		    
            public static string ID = @"ID";
            
            public static string City = @"City";
            
            public static string State = @"State";
            
            public static string Creation = @"Creation";
            
            public static string Modified = @"Modified";
            
	    }

	    #endregion
    }

}

