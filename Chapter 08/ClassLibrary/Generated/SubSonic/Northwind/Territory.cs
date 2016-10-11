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
    /// Strongly-typed collection for the Territory class.
    /// </summary>
    [Serializable]
    public partial class TerritoryCollection : ActiveList<Territory> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public TerritoryCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public TerritoryCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public TerritoryCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public TerritoryCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public TerritoryCollection Where(string columnName, object value) 
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

    	
        public TerritoryCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public TerritoryCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public TerritoryCollection Load() 
        {
            Query qry = new Query(Territory.Schema);
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

        
        public TerritoryCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Territories table.
    /// </summary>
    [Serializable]
    public partial class Territory : ActiveRecord<Territory>
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
				TableSchema.Table schema = new TableSchema.Table("Territories", TableType.Table, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarTerritoryID = new TableSchema.TableColumn(schema);
                colvarTerritoryID.ColumnName = "TerritoryID";
                colvarTerritoryID.DataType = DbType.String;
                colvarTerritoryID.MaxLength = 20;
                colvarTerritoryID.AutoIncrement = false;
                colvarTerritoryID.IsNullable = false;
                colvarTerritoryID.IsPrimaryKey = true;
                colvarTerritoryID.IsForeignKey = false;
                colvarTerritoryID.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarTerritoryID);
                
                TableSchema.TableColumn colvarTerritoryDescription = new TableSchema.TableColumn(schema);
                colvarTerritoryDescription.ColumnName = "TerritoryDescription";
                colvarTerritoryDescription.DataType = DbType.String;
                colvarTerritoryDescription.MaxLength = 50;
                colvarTerritoryDescription.AutoIncrement = false;
                colvarTerritoryDescription.IsNullable = false;
                colvarTerritoryDescription.IsPrimaryKey = false;
                colvarTerritoryDescription.IsForeignKey = false;
                colvarTerritoryDescription.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarTerritoryDescription);
                
                TableSchema.TableColumn colvarRegionID = new TableSchema.TableColumn(schema);
                colvarRegionID.ColumnName = "RegionID";
                colvarRegionID.DataType = DbType.Int32;
                colvarRegionID.MaxLength = 0;
                colvarRegionID.AutoIncrement = false;
                colvarRegionID.IsNullable = false;
                colvarRegionID.IsPrimaryKey = false;
                colvarRegionID.IsForeignKey = true;
                colvarRegionID.IsReadOnly = false;
                
                
				colvarRegionID.ForeignKeyTableName = "Region";
                
                schema.Columns.Add(colvarRegionID);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Territories",schema);
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
	    public Territory()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public Territory(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public Territory(string columnName, object columnValue)
        {
            SetSQLProps();
            SetDefaults();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
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

	      
        [XmlAttribute("TerritoryDescription")]
        public string TerritoryDescription 
	    {
		    get { return GetColumnValue<string>("TerritoryDescription"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("TerritoryDescription", value);
            }

        }

	      
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

	    
	    #endregion
	    
	    
	    #region PrimaryKey Methods
	    
		public Chapter08.NorthwindDAL.EmployeeTerritoryCollection EmployeeTerritories()
		{
			return new Chapter08.NorthwindDAL.EmployeeTerritoryCollection().Where(EmployeeTerritory.Columns.TerritoryID, TerritoryID).Load();
		}

		#endregion
		
	 	
			
	    
	    
	    
	    #region ForeignKey Properties
	    
        /// <summary>
        /// Returns a Region ActiveRecord object related to this Territory
        /// </summary>
	    public Chapter08.NorthwindDAL.Region Region
        {
	        get { return Chapter08.NorthwindDAL.Region.FetchByID(this.RegionID); }

	        set
	        {
		        MarkDirty();
		        SetColumnValue("RegionID", value.RegionID);
	        }

        }

	    
	    
	    #endregion
	    
	    
	    
	    #region Many To Many Helpers
	    
	     
        public Chapter08.NorthwindDAL.EmployeeCollection GetEmployeeCollection() {
            return Territory.GetEmployeeCollection(this.TerritoryID);
        }

        public static Chapter08.NorthwindDAL.EmployeeCollection GetEmployeeCollection(string varTerritoryID) {
            SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
                "SELECT * FROM Employees INNER JOIN EmployeeTerritories ON "+
                "Employees.EmployeeID=EmployeeTerritories.EmployeeID WHERE EmployeeTerritories.TerritoryID=@TerritoryID", Territory.Schema.Provider.Name);
            
            cmd.AddParameter("@TerritoryID", varTerritoryID);
            
            IDataReader rdr = SubSonic.DataService.GetReader(cmd);
            EmployeeCollection coll = new EmployeeCollection();
            coll.LoadAndCloseReader(rdr);
            return coll;
        }

        public static void SaveEmployeeMap(string varTerritoryID, EmployeeCollection items) {
            
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
            QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeTerritories WHERE TerritoryID=@TerritoryID", Territory.Schema.Provider.Name);
            cmdDel.AddParameter("@TerritoryID", varTerritoryID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (Employee item in items)
            {
				EmployeeTerritory varEmployeeTerritory = new EmployeeTerritory();
				varEmployeeTerritory.SetColumnValue("TerritoryID", varTerritoryID);
				varEmployeeTerritory.SetColumnValue("EmployeeID", item.GetPrimaryKeyValue());
				varEmployeeTerritory.Save();
            }

        }

        public static void SaveEmployeeMap(string varTerritoryID, System.Web.UI.WebControls.ListItemCollection itemList) 
        {
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
             QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeTerritories WHERE TerritoryID=@TerritoryID", Territory.Schema.Provider.Name);
            cmdDel.AddParameter("@TerritoryID", varTerritoryID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (System.Web.UI.WebControls.ListItem l in itemList) 
            {
                if (l.Selected) 
                {
					EmployeeTerritory varEmployeeTerritory = new EmployeeTerritory();
					varEmployeeTerritory.SetColumnValue("TerritoryID", varTerritoryID);
					varEmployeeTerritory.SetColumnValue("EmployeeID", l.Value);
					varEmployeeTerritory.Save();
                }

            }

        }

        public static void SaveEmployeeMap(string varTerritoryID , string[] itemList) 
        {
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
             QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeTerritories WHERE TerritoryID=@TerritoryID", Territory.Schema.Provider.Name);
            cmdDel.AddParameter("@TerritoryID", varTerritoryID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (string item in itemList) 
            {
            	EmployeeTerritory varEmployeeTerritory = new EmployeeTerritory();
				varEmployeeTerritory.SetColumnValue("TerritoryID", varTerritoryID);
				varEmployeeTerritory.SetColumnValue("EmployeeID", item);
				varEmployeeTerritory.Save();
            }

        }

        
        public static void DeleteEmployeeMap(string varTerritoryID) 
        {
            QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeTerritories WHERE TerritoryID=@TerritoryID", Territory.Schema.Provider.Name);
            cmdDel.AddParameter("@TerritoryID", varTerritoryID);
            DataService.ExecuteQuery(cmdDel);
		}

	    
	    #endregion
	    
	    #region ObjectDataSource support
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(string varTerritoryID,string varTerritoryDescription,int varRegionID)
	    {
		    Territory item = new Territory();
		    
            item.TerritoryID = varTerritoryID;
            
            item.TerritoryDescription = varTerritoryDescription;
            
            item.RegionID = varRegionID;
            
	    
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(string varTerritoryID,string varTerritoryDescription,int varRegionID)
	    {
		    Territory item = new Territory();
		    
                item.TerritoryID = varTerritoryID;
				
                item.TerritoryDescription = varTerritoryDescription;
				
                item.RegionID = varRegionID;
				
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
		    
		    
            public static string TerritoryID = @"TerritoryID";
            
            public static string TerritoryDescription = @"TerritoryDescription";
            
            public static string RegionID = @"RegionID";
            
	    }

	    #endregion
    }

}

