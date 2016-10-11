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


//Generated on 6/10/2007 10:06:58 PM by brennan

namespace Chapter08.NorthwindDAL{
    /// <summary>
    /// Strongly-typed collection for the Region class.
    /// </summary>
    [Serializable]
    public partial class RegionCollection : ActiveList<Region> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public RegionCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public RegionCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public RegionCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public RegionCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public RegionCollection Where(string columnName, object value) 
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

    	
        public RegionCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public RegionCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public RegionCollection Load() 
        {
            Query qry = new Query(Region.Schema);
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

        
        public RegionCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Region table.
    /// </summary>
    [Serializable]
    public partial class Region : ActiveRecord<Region>
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
				TableSchema.Table schema = new TableSchema.Table("Region", TableType.Table, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarRegionID = new TableSchema.TableColumn(schema);
                colvarRegionID.ColumnName = "RegionID";
                colvarRegionID.DataType = DbType.Int32;
                colvarRegionID.MaxLength = 0;
                colvarRegionID.AutoIncrement = false;
                colvarRegionID.IsNullable = false;
                colvarRegionID.IsPrimaryKey = true;
                colvarRegionID.IsForeignKey = false;
                colvarRegionID.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarRegionID);
                
                TableSchema.TableColumn colvarRegionDescription = new TableSchema.TableColumn(schema);
                colvarRegionDescription.ColumnName = "RegionDescription";
                colvarRegionDescription.DataType = DbType.String;
                colvarRegionDescription.MaxLength = 50;
                colvarRegionDescription.AutoIncrement = false;
                colvarRegionDescription.IsNullable = false;
                colvarRegionDescription.IsPrimaryKey = false;
                colvarRegionDescription.IsForeignKey = false;
                colvarRegionDescription.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarRegionDescription);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Region",schema);
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
	    public Region()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public Region(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public Region(string columnName, object columnValue)
        {
            SetSQLProps();
            SetDefaults();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("RegionID")]
        public int RegionID 
	    {
		    get { return GetColumnValue<int>("RegionID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("RegionID", value);
            }

        }

	      
        [XmlAttribute("RegionDescription")]
        public string RegionDescription 
	    {
		    get { return GetColumnValue<string>("RegionDescription"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("RegionDescription", value);
            }

        }

	    
	    #endregion
	    
	    
	    #region PrimaryKey Methods
	    
		public Chapter08.NorthwindDAL.TerritoryCollection Territories()
		{
			return new Chapter08.NorthwindDAL.TerritoryCollection().Where(Territory.Columns.RegionID, RegionID).Load();
		}

		#endregion
		
	 	
			
	    
	    //no foreign key tables defined (0)
	    
	    
	    
	    //no ManyToMany tables defined (0)
	    
	    #region ObjectDataSource support
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(int varRegionID,string varRegionDescription)
	    {
		    Region item = new Region();
		    
            item.RegionID = varRegionID;
            
            item.RegionDescription = varRegionDescription;
            
	    
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(int varRegionID,string varRegionDescription)
	    {
		    Region item = new Region();
		    
                item.RegionID = varRegionID;
				
                item.RegionDescription = varRegionDescription;
				
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
		    
		    
            public static string RegionID = @"RegionID";
            
            public static string RegionDescription = @"RegionDescription";
            
	    }

	    #endregion
    }

}

