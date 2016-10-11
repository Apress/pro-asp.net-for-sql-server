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
    /// Strongly-typed collection for the ProductSalesfor1997 class.
    /// </summary>
    [Serializable]
    public partial class ProductSalesfor1997Collection : ReadOnlyList<ProductSalesfor1997>
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public ProductSalesfor1997Collection OrderByAsc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public ProductSalesfor1997Collection OrderByDesc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

        public ProductSalesfor1997Collection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
        {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public ProductSalesfor1997Collection Where(Where where) 
        {
            wheres.Add(where);
            return this;
        }

    	
        public ProductSalesfor1997Collection Where(string columnName, object value) 
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

    	
        public ProductSalesfor1997Collection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public ProductSalesfor1997Collection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public ProductSalesfor1997Collection Load() 
	    {
            Query qry = new Query(ProductSalesfor1997.Schema);
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

        
        public ProductSalesfor1997Collection() 
        {
            
        }

    }

    /// <summary>
    /// This is  Read-only wrapper class for the Product Sales for 1997 view.
    /// </summary>
    [Serializable]
    public partial class ProductSalesfor1997 : ReadOnlyRecord<ProductSalesfor1997> 
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
                TableSchema.Table schema = new TableSchema.Table("Product Sales for 1997", TableType.View, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarCategoryName = new TableSchema.TableColumn(schema);
                colvarCategoryName.ColumnName = "CategoryName";
                colvarCategoryName.DataType = DbType.String;
                colvarCategoryName.MaxLength = 15;
                colvarCategoryName.AutoIncrement = false;
                colvarCategoryName.IsNullable = false;
                colvarCategoryName.IsPrimaryKey = false;
                colvarCategoryName.IsForeignKey = false;
                colvarCategoryName.IsReadOnly = false;
                
                schema.Columns.Add(colvarCategoryName);
                
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
                
                TableSchema.TableColumn colvarProductSales = new TableSchema.TableColumn(schema);
                colvarProductSales.ColumnName = "ProductSales";
                colvarProductSales.DataType = DbType.Currency;
                colvarProductSales.MaxLength = 0;
                colvarProductSales.AutoIncrement = false;
                colvarProductSales.IsNullable = true;
                colvarProductSales.IsPrimaryKey = false;
                colvarProductSales.IsForeignKey = false;
                colvarProductSales.IsReadOnly = false;
                
                schema.Columns.Add(colvarProductSales);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Product Sales for 1997",schema);
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
	    public ProductSalesfor1997()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public ProductSalesfor1997(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public ProductSalesfor1997(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("CategoryName")]
        public string CategoryName 
	    {
		    get
		    {
			    return GetColumnValue<string>("CategoryName");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CategoryName", value);
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

	      
        [XmlAttribute("ProductSales")]
        public decimal? ProductSales 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("ProductSales");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ProductSales", value);
            }

        }

	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string CategoryName  = @"CategoryName";
            
            public static string ProductName  = @"ProductName";
            
            public static string ProductSales  = @"ProductSales";
            
	    }

	    #endregion
    }

}
