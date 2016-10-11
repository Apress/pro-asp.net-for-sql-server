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
    /// Strongly-typed collection for the ProductsbyCategory class.
    /// </summary>
    [Serializable]
    public partial class ProductsbyCategoryCollection : ReadOnlyList<ProductsbyCategory>
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public ProductsbyCategoryCollection OrderByAsc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public ProductsbyCategoryCollection OrderByDesc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

        public ProductsbyCategoryCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
        {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public ProductsbyCategoryCollection Where(Where where) 
        {
            wheres.Add(where);
            return this;
        }

    	
        public ProductsbyCategoryCollection Where(string columnName, object value) 
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

    	
        public ProductsbyCategoryCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public ProductsbyCategoryCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public ProductsbyCategoryCollection Load() 
	    {
            Query qry = new Query(ProductsbyCategory.Schema);
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

        
        public ProductsbyCategoryCollection() 
        {
            
        }

    }

    /// <summary>
    /// This is  Read-only wrapper class for the Products by Category view.
    /// </summary>
    [Serializable]
    public partial class ProductsbyCategory : ReadOnlyRecord<ProductsbyCategory> 
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
                TableSchema.Table schema = new TableSchema.Table("Products by Category", TableType.View, DataService.GetInstance("Northwind"));
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
                
                TableSchema.TableColumn colvarQuantityPerUnit = new TableSchema.TableColumn(schema);
                colvarQuantityPerUnit.ColumnName = "QuantityPerUnit";
                colvarQuantityPerUnit.DataType = DbType.String;
                colvarQuantityPerUnit.MaxLength = 20;
                colvarQuantityPerUnit.AutoIncrement = false;
                colvarQuantityPerUnit.IsNullable = true;
                colvarQuantityPerUnit.IsPrimaryKey = false;
                colvarQuantityPerUnit.IsForeignKey = false;
                colvarQuantityPerUnit.IsReadOnly = false;
                
                schema.Columns.Add(colvarQuantityPerUnit);
                
                TableSchema.TableColumn colvarUnitsInStock = new TableSchema.TableColumn(schema);
                colvarUnitsInStock.ColumnName = "UnitsInStock";
                colvarUnitsInStock.DataType = DbType.Int16;
                colvarUnitsInStock.MaxLength = 0;
                colvarUnitsInStock.AutoIncrement = false;
                colvarUnitsInStock.IsNullable = true;
                colvarUnitsInStock.IsPrimaryKey = false;
                colvarUnitsInStock.IsForeignKey = false;
                colvarUnitsInStock.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnitsInStock);
                
                TableSchema.TableColumn colvarDiscontinued = new TableSchema.TableColumn(schema);
                colvarDiscontinued.ColumnName = "Discontinued";
                colvarDiscontinued.DataType = DbType.Boolean;
                colvarDiscontinued.MaxLength = 0;
                colvarDiscontinued.AutoIncrement = false;
                colvarDiscontinued.IsNullable = false;
                colvarDiscontinued.IsPrimaryKey = false;
                colvarDiscontinued.IsForeignKey = false;
                colvarDiscontinued.IsReadOnly = false;
                
                schema.Columns.Add(colvarDiscontinued);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Products by Category",schema);
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
	    public ProductsbyCategory()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public ProductsbyCategory(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public ProductsbyCategory(string columnName, object columnValue)
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

	      
        [XmlAttribute("QuantityPerUnit")]
        public string QuantityPerUnit 
	    {
		    get
		    {
			    return GetColumnValue<string>("QuantityPerUnit");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("QuantityPerUnit", value);
            }

        }

	      
        [XmlAttribute("UnitsInStock")]
        public short? UnitsInStock 
	    {
		    get
		    {
			    return GetColumnValue<short?>("UnitsInStock");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("UnitsInStock", value);
            }

        }

	      
        [XmlAttribute("Discontinued")]
        public bool Discontinued 
	    {
		    get
		    {
			    return GetColumnValue<bool>("Discontinued");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Discontinued", value);
            }

        }

	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string CategoryName  = @"CategoryName";
            
            public static string ProductName  = @"ProductName";
            
            public static string QuantityPerUnit  = @"QuantityPerUnit";
            
            public static string UnitsInStock  = @"UnitsInStock";
            
            public static string Discontinued  = @"Discontinued";
            
	    }

	    #endregion
    }

}
