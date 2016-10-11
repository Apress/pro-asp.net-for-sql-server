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


//Generated on 6/10/2007 10:06:55 PM by brennan

namespace Chapter08.NorthwindDAL{
    /// <summary>
    /// Strongly-typed collection for the EmployeeTerritory class.
    /// </summary>
    [Serializable]
    public partial class EmployeeTerritoryCollection : ActiveList<EmployeeTerritory> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public EmployeeTerritoryCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public EmployeeTerritoryCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public EmployeeTerritoryCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public EmployeeTerritoryCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public EmployeeTerritoryCollection Where(string columnName, object value) 
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

    	
        public EmployeeTerritoryCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public EmployeeTerritoryCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public EmployeeTerritoryCollection Load() 
        {
            Query qry = new Query(EmployeeTerritory.Schema);
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

        
        public EmployeeTerritoryCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the EmployeeTerritories table.
    /// </summary>
    [Serializable]
    public partial class EmployeeTerritory : ActiveRecord<EmployeeTerritory>
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
				TableSchema.Table schema = new TableSchema.Table("EmployeeTerritories", TableType.Table, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarEmployeeID = new TableSchema.TableColumn(schema);
                colvarEmployeeID.ColumnName = "EmployeeID";
                colvarEmployeeID.DataType = DbType.Int32;
                colvarEmployeeID.MaxLength = 0;
                colvarEmployeeID.AutoIncrement = false;
                colvarEmployeeID.IsNullable = false;
                colvarEmployeeID.IsPrimaryKey = true;
                colvarEmployeeID.IsForeignKey = true;
                colvarEmployeeID.IsReadOnly = false;
                
                
				colvarEmployeeID.ForeignKeyTableName = "Employees";
                
                schema.Columns.Add(colvarEmployeeID);
                
                TableSchema.TableColumn colvarTerritoryID = new TableSchema.TableColumn(schema);
                colvarTerritoryID.ColumnName = "TerritoryID";
                colvarTerritoryID.DataType = DbType.String;
                colvarTerritoryID.MaxLength = 20;
                colvarTerritoryID.AutoIncrement = false;
                colvarTerritoryID.IsNullable = false;
                colvarTerritoryID.IsPrimaryKey = true;
                colvarTerritoryID.IsForeignKey = true;
                colvarTerritoryID.IsReadOnly = false;
                
                
				colvarTerritoryID.ForeignKeyTableName = "Territories";
                
                schema.Columns.Add(colvarTerritoryID);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("EmployeeTerritories",schema);
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
	    public EmployeeTerritory()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public EmployeeTerritory(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public EmployeeTerritory(string columnName, object columnValue)
        {
            SetSQLProps();
            SetDefaults();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("EmployeeID")]
        public int EmployeeID 
	    {
		    get { return GetColumnValue<int>("EmployeeID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("EmployeeID", value);
            }

        }

	      
        [XmlAttribute("TerritoryID")]
        public string TerritoryID 
	    {
		    get { return GetColumnValue<string>("TerritoryID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("TerritoryID", value);
            }

        }

	    
	    #endregion
	    
	    
	 	
			
	    
	    
	    
	    #region ForeignKey Properties
	    
        /// <summary>
        /// Returns a Employee ActiveRecord object related to this EmployeeTerritory
        /// </summary>
	    public Chapter08.NorthwindDAL.Employee Employee
        {
	        get { return Chapter08.NorthwindDAL.Employee.FetchByID(this.EmployeeID); }

	        set
	        {
		        MarkDirty();
		        SetColumnValue("EmployeeID", value.EmployeeID);
	        }

        }

	    
	    
        /// <summary>
        /// Returns a Territory ActiveRecord object related to this EmployeeTerritory
        /// </summary>
	    public Chapter08.NorthwindDAL.Territory Territory
        {
	        get { return Chapter08.NorthwindDAL.Territory.FetchByID(this.TerritoryID); }

	        set
	        {
		        MarkDirty();
		        SetColumnValue("TerritoryID", value.TerritoryID);
	        }

        }

	    
	    
	    #endregion
	    
	    
	    
	    //no ManyToMany tables defined (0)
	    
	    #region ObjectDataSource support
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(int varEmployeeID,string varTerritoryID)
	    {
		    EmployeeTerritory item = new EmployeeTerritory();
		    
            item.EmployeeID = varEmployeeID;
            
            item.TerritoryID = varTerritoryID;
            
	    
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(int varEmployeeID,string varTerritoryID)
	    {
		    EmployeeTerritory item = new EmployeeTerritory();
		    
                item.EmployeeID = varEmployeeID;
				
                item.TerritoryID = varTerritoryID;
				
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
		    
		    
            public static string EmployeeID = @"EmployeeID";
            
            public static string TerritoryID = @"TerritoryID";
            
	    }

	    #endregion
    }

}

