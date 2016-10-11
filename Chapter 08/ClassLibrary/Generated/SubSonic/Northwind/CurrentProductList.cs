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



namespace Chapter08.NorthwindDAL{
    /// <summary>
    /// Strongly-typed collection for the CurrentProductList class.
    /// </summary>
    [Serializable]
    public partial class CurrentProductListCollection : ReadOnlyList<CurrentProductList>
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public CurrentProductListCollection OrderByAsc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public CurrentProductListCollection OrderByDesc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

        public CurrentProductListCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
        {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public CurrentProductListCollection Where(Where where) 
        {
            wheres.Add(where);
            return this;
        }

    	
        public CurrentProductListCollection Where(string columnName, object value) 
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

    	
        public CurrentProductListCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public CurrentProductListCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public CurrentProductListCollection Load() 
	    {
            Query qry = new Query(CurrentProductList.Schema);
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

        
        public CurrentProductListCollection() 
        {
            
        }

    }

    /// <summary>
    /// This is  Read-only wrapper class for the Current Product List view.
    /// </summary>
    [Serializable]
    public partial class CurrentProductList : ReadOnlyRecord<CurrentProductList> 
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
                TableSchema.Table schema = new TableSchema.Table("Current Product List", TableType.View, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarProductID = new TableSchema.TableColumn(schema);
                colvarProductID.ColumnName = "ProductID";
                colvarProductID.DataType = DbType.Int32;
                colvarProductID.MaxLength = 0;
                colvarProductID.AutoIncrement = false;
                colvarProductID.IsNullable = false;
                colvarProductID.IsPrimaryKey = false;
                colvarProductID.IsForeignKey = false;
                colvarProductID.IsReadOnly = false;
                
                schema.Columns.Add(colvarProductID);
                
                TableSchema.TableColumn colvarProductName = new TableSchema.TableColumn(schema);
                colvarProductName.ColumnName = "ProductName";
                colvarProductName.DataType = DbType.String;
                colvarProductName.MaxLength = 40;
                colvarProductName.AutoIncrement = false;
                colvarProductName.IsNullable = false;
                colvarProductName.IsPrimaryKey = false;
                colvarProductName.IsForeignKey = false;
                colvarProductName.IsReadOnly = false;
                
                schema.Columns.Add(colvarProductName);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Current Product List",schema);
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
	    public CurrentProductList()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public CurrentProductList(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public CurrentProductList(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("ProductID")]
        public int ProductID 
	    {
		    get
		    {
			    return GetColumnValue<int>("ProductID");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ProductID", value);
            }

        }

	      
        [XmlAttribute("ProductName")]
        public string ProductName 
	    {
		    get
		    {
			    return GetColumnValue<string>("ProductName");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ProductName", value);
            }

        }

	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string ProductID  = @"ProductID";
            
            public static string ProductName  = @"ProductName";
            
	    }

	    #endregion
    }

}
