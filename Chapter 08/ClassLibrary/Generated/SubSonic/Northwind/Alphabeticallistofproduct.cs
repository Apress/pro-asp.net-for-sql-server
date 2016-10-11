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
    /// Strongly-typed collection for the Alphabeticallistofproduct class.
    /// </summary>
    [Serializable]
    public partial class AlphabeticallistofproductCollection : ReadOnlyList<Alphabeticallistofproduct>
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public AlphabeticallistofproductCollection OrderByAsc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public AlphabeticallistofproductCollection OrderByDesc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

        public AlphabeticallistofproductCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
        {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public AlphabeticallistofproductCollection Where(Where where) 
        {
            wheres.Add(where);
            return this;
        }

    	
        public AlphabeticallistofproductCollection Where(string columnName, object value) 
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

    	
        public AlphabeticallistofproductCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public AlphabeticallistofproductCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public AlphabeticallistofproductCollection Load() 
	    {
            Query qry = new Query(Alphabeticallistofproduct.Schema);
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

        
        public AlphabeticallistofproductCollection() 
        {
            
        }

    }

    /// <summary>
    /// This is  Read-only wrapper class for the Alphabetical list of products view.
    /// </summary>
    [Serializable]
    public partial class Alphabeticallistofproduct : ReadOnlyRecord<Alphabeticallistofproduct> 
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
                TableSchema.Table schema = new TableSchema.Table("Alphabetical list of products", TableType.View, DataService.GetInstance("Northwind"));
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
                
                TableSchema.TableColumn colvarSupplierID = new TableSchema.TableColumn(schema);
                colvarSupplierID.ColumnName = "SupplierID";
                colvarSupplierID.DataType = DbType.Int32;
                colvarSupplierID.MaxLength = 0;
                colvarSupplierID.AutoIncrement = false;
                colvarSupplierID.IsNullable = true;
                colvarSupplierID.IsPrimaryKey = false;
                colvarSupplierID.IsForeignKey = false;
                colvarSupplierID.IsReadOnly = false;
                
                schema.Columns.Add(colvarSupplierID);
                
                TableSchema.TableColumn colvarCategoryID = new TableSchema.TableColumn(schema);
                colvarCategoryID.ColumnName = "CategoryID";
                colvarCategoryID.DataType = DbType.Int32;
                colvarCategoryID.MaxLength = 0;
                colvarCategoryID.AutoIncrement = false;
                colvarCategoryID.IsNullable = true;
                colvarCategoryID.IsPrimaryKey = false;
                colvarCategoryID.IsForeignKey = false;
                colvarCategoryID.IsReadOnly = false;
                
                schema.Columns.Add(colvarCategoryID);
                
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
                
                TableSchema.TableColumn colvarUnitPrice = new TableSchema.TableColumn(schema);
                colvarUnitPrice.ColumnName = "UnitPrice";
                colvarUnitPrice.DataType = DbType.Currency;
                colvarUnitPrice.MaxLength = 0;
                colvarUnitPrice.AutoIncrement = false;
                colvarUnitPrice.IsNullable = true;
                colvarUnitPrice.IsPrimaryKey = false;
                colvarUnitPrice.IsForeignKey = false;
                colvarUnitPrice.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnitPrice);
                
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
                
                TableSchema.TableColumn colvarUnitsOnOrder = new TableSchema.TableColumn(schema);
                colvarUnitsOnOrder.ColumnName = "UnitsOnOrder";
                colvarUnitsOnOrder.DataType = DbType.Int16;
                colvarUnitsOnOrder.MaxLength = 0;
                colvarUnitsOnOrder.AutoIncrement = false;
                colvarUnitsOnOrder.IsNullable = true;
                colvarUnitsOnOrder.IsPrimaryKey = false;
                colvarUnitsOnOrder.IsForeignKey = false;
                colvarUnitsOnOrder.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnitsOnOrder);
                
                TableSchema.TableColumn colvarReorderLevel = new TableSchema.TableColumn(schema);
                colvarReorderLevel.ColumnName = "ReorderLevel";
                colvarReorderLevel.DataType = DbType.Int16;
                colvarReorderLevel.MaxLength = 0;
                colvarReorderLevel.AutoIncrement = false;
                colvarReorderLevel.IsNullable = true;
                colvarReorderLevel.IsPrimaryKey = false;
                colvarReorderLevel.IsForeignKey = false;
                colvarReorderLevel.IsReadOnly = false;
                
                schema.Columns.Add(colvarReorderLevel);
                
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
                
                TableSchema.TableColumn colvarAttributeXML = new TableSchema.TableColumn(schema);
                colvarAttributeXML.ColumnName = "AttributeXML";
                colvarAttributeXML.DataType = DbType.String;
                colvarAttributeXML.MaxLength = -1;
                colvarAttributeXML.AutoIncrement = false;
                colvarAttributeXML.IsNullable = true;
                colvarAttributeXML.IsPrimaryKey = false;
                colvarAttributeXML.IsForeignKey = false;
                colvarAttributeXML.IsReadOnly = false;
                
                schema.Columns.Add(colvarAttributeXML);
                
                TableSchema.TableColumn colvarDateCreated = new TableSchema.TableColumn(schema);
                colvarDateCreated.ColumnName = "DateCreated";
                colvarDateCreated.DataType = DbType.DateTime;
                colvarDateCreated.MaxLength = 0;
                colvarDateCreated.AutoIncrement = false;
                colvarDateCreated.IsNullable = true;
                colvarDateCreated.IsPrimaryKey = false;
                colvarDateCreated.IsForeignKey = false;
                colvarDateCreated.IsReadOnly = false;
                
                schema.Columns.Add(colvarDateCreated);
                
                TableSchema.TableColumn colvarProductGUID = new TableSchema.TableColumn(schema);
                colvarProductGUID.ColumnName = "ProductGUID";
                colvarProductGUID.DataType = DbType.Guid;
                colvarProductGUID.MaxLength = 0;
                colvarProductGUID.AutoIncrement = false;
                colvarProductGUID.IsNullable = true;
                colvarProductGUID.IsPrimaryKey = false;
                colvarProductGUID.IsForeignKey = false;
                colvarProductGUID.IsReadOnly = false;
                
                schema.Columns.Add(colvarProductGUID);
                
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
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Alphabetical list of products",schema);
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
	    public Alphabeticallistofproduct()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public Alphabeticallistofproduct(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public Alphabeticallistofproduct(string columnName, object columnValue)
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

	      
        [XmlAttribute("SupplierID")]
        public int? SupplierID 
	    {
		    get
		    {
			    return GetColumnValue<int?>("SupplierID");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("SupplierID", value);
            }

        }

	      
        [XmlAttribute("CategoryID")]
        public int? CategoryID 
	    {
		    get
		    {
			    return GetColumnValue<int?>("CategoryID");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CategoryID", value);
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

	      
        [XmlAttribute("UnitPrice")]
        public decimal? UnitPrice 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("UnitPrice");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("UnitPrice", value);
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

	      
        [XmlAttribute("UnitsOnOrder")]
        public short? UnitsOnOrder 
	    {
		    get
		    {
			    return GetColumnValue<short?>("UnitsOnOrder");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("UnitsOnOrder", value);
            }

        }

	      
        [XmlAttribute("ReorderLevel")]
        public short? ReorderLevel 
	    {
		    get
		    {
			    return GetColumnValue<short?>("ReorderLevel");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ReorderLevel", value);
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

	      
        [XmlAttribute("AttributeXML")]
        public string AttributeXML 
	    {
		    get
		    {
			    return GetColumnValue<string>("AttributeXML");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("AttributeXML", value);
            }

        }

	      
        [XmlAttribute("DateCreated")]
        public DateTime? DateCreated 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("DateCreated");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("DateCreated", value);
            }

        }

	      
        [XmlAttribute("ProductGUID")]
        public Guid? ProductGUID 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("ProductGUID");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ProductGUID", value);
            }

        }

	      
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

	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string ProductID  = @"ProductID";
            
            public static string ProductName  = @"ProductName";
            
            public static string SupplierID  = @"SupplierID";
            
            public static string CategoryID  = @"CategoryID";
            
            public static string QuantityPerUnit  = @"QuantityPerUnit";
            
            public static string UnitPrice  = @"UnitPrice";
            
            public static string UnitsInStock  = @"UnitsInStock";
            
            public static string UnitsOnOrder  = @"UnitsOnOrder";
            
            public static string ReorderLevel  = @"ReorderLevel";
            
            public static string Discontinued  = @"Discontinued";
            
            public static string AttributeXML  = @"AttributeXML";
            
            public static string DateCreated  = @"DateCreated";
            
            public static string ProductGUID  = @"ProductGUID";
            
            public static string CategoryName  = @"CategoryName";
            
	    }

	    #endregion
    }

}
