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
    /// Strongly-typed collection for the CategorySalesfor1997 class.
    /// </summary>
    [Serializable]
    public partial class CategorySalesfor1997Collection : ReadOnlyList<CategorySalesfor1997>
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public CategorySalesfor1997Collection OrderByAsc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public CategorySalesfor1997Collection OrderByDesc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

        public CategorySalesfor1997Collection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
        {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public CategorySalesfor1997Collection Where(Where where) 
        {
            wheres.Add(where);
            return this;
        }

    	
        public CategorySalesfor1997Collection Where(string columnName, object value) 
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

    	
        public CategorySalesfor1997Collection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public CategorySalesfor1997Collection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public CategorySalesfor1997Collection Load() 
	    {
            Query qry = new Query(CategorySalesfor1997.Schema);
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

        
        public CategorySalesfor1997Collection() 
        {
            
        }

    }

    /// <summary>
    /// This is  Read-only wrapper class for the Category Sales for 1997 view.
    /// </summary>
    [Serializable]
    public partial class CategorySalesfor1997 : ReadOnlyRecord<CategorySalesfor1997> 
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
                TableSchema.Table schema = new TableSchema.Table("Category Sales for 1997", TableType.View, DataService.GetInstance("Northwind"));
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
                
                TableSchema.TableColumn colvarCategorySales = new TableSchema.TableColumn(schema);
                colvarCategorySales.ColumnName = "CategorySales";
                colvarCategorySales.DataType = DbType.Currency;
                colvarCategorySales.MaxLength = 0;
                colvarCategorySales.AutoIncrement = false;
                colvarCategorySales.IsNullable = true;
                colvarCategorySales.IsPrimaryKey = false;
                colvarCategorySales.IsForeignKey = false;
                colvarCategorySales.IsReadOnly = false;
                
                schema.Columns.Add(colvarCategorySales);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Category Sales for 1997",schema);
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
	    public CategorySalesfor1997()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public CategorySalesfor1997(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public CategorySalesfor1997(string columnName, object columnValue)
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

	      
        [XmlAttribute("CategorySales")]
        public decimal? CategorySales 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("CategorySales");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CategorySales", value);
            }

        }

	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string CategoryName  = @"CategoryName";
            
            public static string CategorySales  = @"CategorySales";
            
	    }

	    #endregion
    }

}
