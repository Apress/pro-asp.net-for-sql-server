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


//Generated on 6/10/2007 10:07:02 PM by brennan

namespace Chapter08.SubSonicDAL{
    /// <summary>
    /// Strongly-typed collection for the Person class.
    /// </summary>
    [Serializable]
    public partial class PersonCollection : ActiveList<Person> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public PersonCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public PersonCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public PersonCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public PersonCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public PersonCollection Where(string columnName, object value) 
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

    	
        public PersonCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public PersonCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public PersonCollection Load() 
        {
            Query qry = new Query(Person.Schema);
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

        
        public PersonCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Person table.
    /// </summary>
    [Serializable]
    public partial class Person : ActiveRecord<Person>
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
				TableSchema.Table schema = new TableSchema.Table("Person", TableType.Table, DataService.GetInstance("Chapter08"));
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
                
                TableSchema.TableColumn colvarFirstName = new TableSchema.TableColumn(schema);
                colvarFirstName.ColumnName = "FirstName";
                colvarFirstName.DataType = DbType.String;
                colvarFirstName.MaxLength = 50;
                colvarFirstName.AutoIncrement = false;
                colvarFirstName.IsNullable = false;
                colvarFirstName.IsPrimaryKey = false;
                colvarFirstName.IsForeignKey = false;
                colvarFirstName.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarFirstName);
                
                TableSchema.TableColumn colvarLastName = new TableSchema.TableColumn(schema);
                colvarLastName.ColumnName = "LastName";
                colvarLastName.DataType = DbType.String;
                colvarLastName.MaxLength = 50;
                colvarLastName.AutoIncrement = false;
                colvarLastName.IsNullable = false;
                colvarLastName.IsPrimaryKey = false;
                colvarLastName.IsForeignKey = false;
                colvarLastName.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarLastName);
                
                TableSchema.TableColumn colvarLocationID = new TableSchema.TableColumn(schema);
                colvarLocationID.ColumnName = "LocationID";
                colvarLocationID.DataType = DbType.Int64;
                colvarLocationID.MaxLength = 0;
                colvarLocationID.AutoIncrement = false;
                colvarLocationID.IsNullable = false;
                colvarLocationID.IsPrimaryKey = false;
                colvarLocationID.IsForeignKey = true;
                colvarLocationID.IsReadOnly = false;
                
                
				colvarLocationID.ForeignKeyTableName = "Location";
                
                schema.Columns.Add(colvarLocationID);
                
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
                DataService.Providers["Chapter08"].AddSchema("Person",schema);
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
	    public Person()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public Person(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public Person(string columnName, object columnValue)
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

	      
        [XmlAttribute("FirstName")]
        public string FirstName 
	    {
		    get { return GetColumnValue<string>("FirstName"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("FirstName", value);
            }

        }

	      
        [XmlAttribute("LastName")]
        public string LastName 
	    {
		    get { return GetColumnValue<string>("LastName"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("LastName", value);
            }

        }

	      
        [XmlAttribute("LocationID")]
        public long LocationID 
	    {
		    get { return GetColumnValue<long>("LocationID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("LocationID", value);
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
	    
	    
	 	
			
	    
	    
	    
	    #region ForeignKey Properties
	    
        /// <summary>
        /// Returns a Location ActiveRecord object related to this Person
        /// </summary>
	    public Chapter08.SubSonicDAL.Location Location
        {
	        get { return Chapter08.SubSonicDAL.Location.FetchByID(this.LocationID); }

	        set
	        {
		        MarkDirty();
		        SetColumnValue("LocationID", value.ID);
	        }

        }

	    
	    
	    #endregion
	    
	    
	    
	    //no ManyToMany tables defined (0)
	    
	    #region ObjectDataSource support
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(string varFirstName,string varLastName,long varLocationID,DateTime varCreation,DateTime varModified)
	    {
		    Person item = new Person();
		    
            item.FirstName = varFirstName;
            
            item.LastName = varLastName;
            
            item.LocationID = varLocationID;
            
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
	    public static void Update(long varID,string varFirstName,string varLastName,long varLocationID,DateTime varCreation,DateTime varModified)
	    {
		    Person item = new Person();
		    
                item.ID = varID;
				
                item.FirstName = varFirstName;
				
                item.LastName = varLastName;
				
                item.LocationID = varLocationID;
				
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
            
            public static string FirstName = @"FirstName";
            
            public static string LastName = @"LastName";
            
            public static string LocationID = @"LocationID";
            
            public static string Creation = @"Creation";
            
            public static string Modified = @"Modified";
            
	    }

	    #endregion
    }

}

