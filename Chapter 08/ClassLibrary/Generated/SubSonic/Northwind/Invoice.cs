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
    /// Strongly-typed collection for the Invoice class.
    /// </summary>
    [Serializable]
    public partial class InvoiceCollection : ReadOnlyList<Invoice>
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public InvoiceCollection OrderByAsc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public InvoiceCollection OrderByDesc(string columnName) 
        {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

        public InvoiceCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
        {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public InvoiceCollection Where(Where where) 
        {
            wheres.Add(where);
            return this;
        }

    	
        public InvoiceCollection Where(string columnName, object value) 
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

    	
        public InvoiceCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public InvoiceCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public InvoiceCollection Load() 
	    {
            Query qry = new Query(Invoice.Schema);
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

        
        public InvoiceCollection() 
        {
            
        }

    }

    /// <summary>
    /// This is  Read-only wrapper class for the Invoices view.
    /// </summary>
    [Serializable]
    public partial class Invoice : ReadOnlyRecord<Invoice> 
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
                TableSchema.Table schema = new TableSchema.Table("Invoices", TableType.View, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarShipName = new TableSchema.TableColumn(schema);
                colvarShipName.ColumnName = "ShipName";
                colvarShipName.DataType = DbType.String;
                colvarShipName.MaxLength = 40;
                colvarShipName.AutoIncrement = false;
                colvarShipName.IsNullable = true;
                colvarShipName.IsPrimaryKey = false;
                colvarShipName.IsForeignKey = false;
                colvarShipName.IsReadOnly = false;
                
                schema.Columns.Add(colvarShipName);
                
                TableSchema.TableColumn colvarShipAddress = new TableSchema.TableColumn(schema);
                colvarShipAddress.ColumnName = "ShipAddress";
                colvarShipAddress.DataType = DbType.String;
                colvarShipAddress.MaxLength = 60;
                colvarShipAddress.AutoIncrement = false;
                colvarShipAddress.IsNullable = true;
                colvarShipAddress.IsPrimaryKey = false;
                colvarShipAddress.IsForeignKey = false;
                colvarShipAddress.IsReadOnly = false;
                
                schema.Columns.Add(colvarShipAddress);
                
                TableSchema.TableColumn colvarShipCity = new TableSchema.TableColumn(schema);
                colvarShipCity.ColumnName = "ShipCity";
                colvarShipCity.DataType = DbType.String;
                colvarShipCity.MaxLength = 15;
                colvarShipCity.AutoIncrement = false;
                colvarShipCity.IsNullable = true;
                colvarShipCity.IsPrimaryKey = false;
                colvarShipCity.IsForeignKey = false;
                colvarShipCity.IsReadOnly = false;
                
                schema.Columns.Add(colvarShipCity);
                
                TableSchema.TableColumn colvarShipRegion = new TableSchema.TableColumn(schema);
                colvarShipRegion.ColumnName = "ShipRegion";
                colvarShipRegion.DataType = DbType.String;
                colvarShipRegion.MaxLength = 15;
                colvarShipRegion.AutoIncrement = false;
                colvarShipRegion.IsNullable = true;
                colvarShipRegion.IsPrimaryKey = false;
                colvarShipRegion.IsForeignKey = false;
                colvarShipRegion.IsReadOnly = false;
                
                schema.Columns.Add(colvarShipRegion);
                
                TableSchema.TableColumn colvarShipPostalCode = new TableSchema.TableColumn(schema);
                colvarShipPostalCode.ColumnName = "ShipPostalCode";
                colvarShipPostalCode.DataType = DbType.String;
                colvarShipPostalCode.MaxLength = 10;
                colvarShipPostalCode.AutoIncrement = false;
                colvarShipPostalCode.IsNullable = true;
                colvarShipPostalCode.IsPrimaryKey = false;
                colvarShipPostalCode.IsForeignKey = false;
                colvarShipPostalCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarShipPostalCode);
                
                TableSchema.TableColumn colvarShipCountry = new TableSchema.TableColumn(schema);
                colvarShipCountry.ColumnName = "ShipCountry";
                colvarShipCountry.DataType = DbType.String;
                colvarShipCountry.MaxLength = 15;
                colvarShipCountry.AutoIncrement = false;
                colvarShipCountry.IsNullable = true;
                colvarShipCountry.IsPrimaryKey = false;
                colvarShipCountry.IsForeignKey = false;
                colvarShipCountry.IsReadOnly = false;
                
                schema.Columns.Add(colvarShipCountry);
                
                TableSchema.TableColumn colvarCustomerID = new TableSchema.TableColumn(schema);
                colvarCustomerID.ColumnName = "CustomerID";
                colvarCustomerID.DataType = DbType.String;
                colvarCustomerID.MaxLength = 5;
                colvarCustomerID.AutoIncrement = false;
                colvarCustomerID.IsNullable = true;
                colvarCustomerID.IsPrimaryKey = false;
                colvarCustomerID.IsForeignKey = false;
                colvarCustomerID.IsReadOnly = false;
                
                schema.Columns.Add(colvarCustomerID);
                
                TableSchema.TableColumn colvarCustomerName = new TableSchema.TableColumn(schema);
                colvarCustomerName.ColumnName = "CustomerName";
                colvarCustomerName.DataType = DbType.String;
                colvarCustomerName.MaxLength = 40;
                colvarCustomerName.AutoIncrement = false;
                colvarCustomerName.IsNullable = false;
                colvarCustomerName.IsPrimaryKey = false;
                colvarCustomerName.IsForeignKey = false;
                colvarCustomerName.IsReadOnly = false;
                
                schema.Columns.Add(colvarCustomerName);
                
                TableSchema.TableColumn colvarAddress = new TableSchema.TableColumn(schema);
                colvarAddress.ColumnName = "Address";
                colvarAddress.DataType = DbType.String;
                colvarAddress.MaxLength = 60;
                colvarAddress.AutoIncrement = false;
                colvarAddress.IsNullable = true;
                colvarAddress.IsPrimaryKey = false;
                colvarAddress.IsForeignKey = false;
                colvarAddress.IsReadOnly = false;
                
                schema.Columns.Add(colvarAddress);
                
                TableSchema.TableColumn colvarCity = new TableSchema.TableColumn(schema);
                colvarCity.ColumnName = "City";
                colvarCity.DataType = DbType.String;
                colvarCity.MaxLength = 15;
                colvarCity.AutoIncrement = false;
                colvarCity.IsNullable = true;
                colvarCity.IsPrimaryKey = false;
                colvarCity.IsForeignKey = false;
                colvarCity.IsReadOnly = false;
                
                schema.Columns.Add(colvarCity);
                
                TableSchema.TableColumn colvarRegion = new TableSchema.TableColumn(schema);
                colvarRegion.ColumnName = "Region";
                colvarRegion.DataType = DbType.String;
                colvarRegion.MaxLength = 15;
                colvarRegion.AutoIncrement = false;
                colvarRegion.IsNullable = true;
                colvarRegion.IsPrimaryKey = false;
                colvarRegion.IsForeignKey = false;
                colvarRegion.IsReadOnly = false;
                
                schema.Columns.Add(colvarRegion);
                
                TableSchema.TableColumn colvarPostalCode = new TableSchema.TableColumn(schema);
                colvarPostalCode.ColumnName = "PostalCode";
                colvarPostalCode.DataType = DbType.String;
                colvarPostalCode.MaxLength = 10;
                colvarPostalCode.AutoIncrement = false;
                colvarPostalCode.IsNullable = true;
                colvarPostalCode.IsPrimaryKey = false;
                colvarPostalCode.IsForeignKey = false;
                colvarPostalCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarPostalCode);
                
                TableSchema.TableColumn colvarCountry = new TableSchema.TableColumn(schema);
                colvarCountry.ColumnName = "Country";
                colvarCountry.DataType = DbType.String;
                colvarCountry.MaxLength = 15;
                colvarCountry.AutoIncrement = false;
                colvarCountry.IsNullable = true;
                colvarCountry.IsPrimaryKey = false;
                colvarCountry.IsForeignKey = false;
                colvarCountry.IsReadOnly = false;
                
                schema.Columns.Add(colvarCountry);
                
                TableSchema.TableColumn colvarSalesperson = new TableSchema.TableColumn(schema);
                colvarSalesperson.ColumnName = "Salesperson";
                colvarSalesperson.DataType = DbType.String;
                colvarSalesperson.MaxLength = 31;
                colvarSalesperson.AutoIncrement = false;
                colvarSalesperson.IsNullable = false;
                colvarSalesperson.IsPrimaryKey = false;
                colvarSalesperson.IsForeignKey = false;
                colvarSalesperson.IsReadOnly = false;
                
                schema.Columns.Add(colvarSalesperson);
                
                TableSchema.TableColumn colvarOrderID = new TableSchema.TableColumn(schema);
                colvarOrderID.ColumnName = "OrderID";
                colvarOrderID.DataType = DbType.Int32;
                colvarOrderID.MaxLength = 0;
                colvarOrderID.AutoIncrement = false;
                colvarOrderID.IsNullable = false;
                colvarOrderID.IsPrimaryKey = false;
                colvarOrderID.IsForeignKey = false;
                colvarOrderID.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrderID);
                
                TableSchema.TableColumn colvarOrderDate = new TableSchema.TableColumn(schema);
                colvarOrderDate.ColumnName = "OrderDate";
                colvarOrderDate.DataType = DbType.DateTime;
                colvarOrderDate.MaxLength = 0;
                colvarOrderDate.AutoIncrement = false;
                colvarOrderDate.IsNullable = true;
                colvarOrderDate.IsPrimaryKey = false;
                colvarOrderDate.IsForeignKey = false;
                colvarOrderDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrderDate);
                
                TableSchema.TableColumn colvarRequiredDate = new TableSchema.TableColumn(schema);
                colvarRequiredDate.ColumnName = "RequiredDate";
                colvarRequiredDate.DataType = DbType.DateTime;
                colvarRequiredDate.MaxLength = 0;
                colvarRequiredDate.AutoIncrement = false;
                colvarRequiredDate.IsNullable = true;
                colvarRequiredDate.IsPrimaryKey = false;
                colvarRequiredDate.IsForeignKey = false;
                colvarRequiredDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarRequiredDate);
                
                TableSchema.TableColumn colvarShippedDate = new TableSchema.TableColumn(schema);
                colvarShippedDate.ColumnName = "ShippedDate";
                colvarShippedDate.DataType = DbType.DateTime;
                colvarShippedDate.MaxLength = 0;
                colvarShippedDate.AutoIncrement = false;
                colvarShippedDate.IsNullable = true;
                colvarShippedDate.IsPrimaryKey = false;
                colvarShippedDate.IsForeignKey = false;
                colvarShippedDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarShippedDate);
                
                TableSchema.TableColumn colvarShipperName = new TableSchema.TableColumn(schema);
                colvarShipperName.ColumnName = "ShipperName";
                colvarShipperName.DataType = DbType.String;
                colvarShipperName.MaxLength = 40;
                colvarShipperName.AutoIncrement = false;
                colvarShipperName.IsNullable = false;
                colvarShipperName.IsPrimaryKey = false;
                colvarShipperName.IsForeignKey = false;
                colvarShipperName.IsReadOnly = false;
                
                schema.Columns.Add(colvarShipperName);
                
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
                
                TableSchema.TableColumn colvarUnitPrice = new TableSchema.TableColumn(schema);
                colvarUnitPrice.ColumnName = "UnitPrice";
                colvarUnitPrice.DataType = DbType.Currency;
                colvarUnitPrice.MaxLength = 0;
                colvarUnitPrice.AutoIncrement = false;
                colvarUnitPrice.IsNullable = false;
                colvarUnitPrice.IsPrimaryKey = false;
                colvarUnitPrice.IsForeignKey = false;
                colvarUnitPrice.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnitPrice);
                
                TableSchema.TableColumn colvarQuantity = new TableSchema.TableColumn(schema);
                colvarQuantity.ColumnName = "Quantity";
                colvarQuantity.DataType = DbType.Int16;
                colvarQuantity.MaxLength = 0;
                colvarQuantity.AutoIncrement = false;
                colvarQuantity.IsNullable = false;
                colvarQuantity.IsPrimaryKey = false;
                colvarQuantity.IsForeignKey = false;
                colvarQuantity.IsReadOnly = false;
                
                schema.Columns.Add(colvarQuantity);
                
                TableSchema.TableColumn colvarDiscount = new TableSchema.TableColumn(schema);
                colvarDiscount.ColumnName = "Discount";
                colvarDiscount.DataType = DbType.Decimal;
                colvarDiscount.MaxLength = 0;
                colvarDiscount.AutoIncrement = false;
                colvarDiscount.IsNullable = false;
                colvarDiscount.IsPrimaryKey = false;
                colvarDiscount.IsForeignKey = false;
                colvarDiscount.IsReadOnly = false;
                
                schema.Columns.Add(colvarDiscount);
                
                TableSchema.TableColumn colvarExtendedPrice = new TableSchema.TableColumn(schema);
                colvarExtendedPrice.ColumnName = "ExtendedPrice";
                colvarExtendedPrice.DataType = DbType.Currency;
                colvarExtendedPrice.MaxLength = 0;
                colvarExtendedPrice.AutoIncrement = false;
                colvarExtendedPrice.IsNullable = true;
                colvarExtendedPrice.IsPrimaryKey = false;
                colvarExtendedPrice.IsForeignKey = false;
                colvarExtendedPrice.IsReadOnly = false;
                
                schema.Columns.Add(colvarExtendedPrice);
                
                TableSchema.TableColumn colvarFreight = new TableSchema.TableColumn(schema);
                colvarFreight.ColumnName = "Freight";
                colvarFreight.DataType = DbType.Currency;
                colvarFreight.MaxLength = 0;
                colvarFreight.AutoIncrement = false;
                colvarFreight.IsNullable = true;
                colvarFreight.IsPrimaryKey = false;
                colvarFreight.IsForeignKey = false;
                colvarFreight.IsReadOnly = false;
                
                schema.Columns.Add(colvarFreight);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Invoices",schema);
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
	    public Invoice()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public Invoice(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public Invoice(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("ShipName")]
        public string ShipName 
	    {
		    get
		    {
			    return GetColumnValue<string>("ShipName");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShipName", value);
            }

        }

	      
        [XmlAttribute("ShipAddress")]
        public string ShipAddress 
	    {
		    get
		    {
			    return GetColumnValue<string>("ShipAddress");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShipAddress", value);
            }

        }

	      
        [XmlAttribute("ShipCity")]
        public string ShipCity 
	    {
		    get
		    {
			    return GetColumnValue<string>("ShipCity");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShipCity", value);
            }

        }

	      
        [XmlAttribute("ShipRegion")]
        public string ShipRegion 
	    {
		    get
		    {
			    return GetColumnValue<string>("ShipRegion");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShipRegion", value);
            }

        }

	      
        [XmlAttribute("ShipPostalCode")]
        public string ShipPostalCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("ShipPostalCode");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShipPostalCode", value);
            }

        }

	      
        [XmlAttribute("ShipCountry")]
        public string ShipCountry 
	    {
		    get
		    {
			    return GetColumnValue<string>("ShipCountry");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShipCountry", value);
            }

        }

	      
        [XmlAttribute("CustomerID")]
        public string CustomerID 
	    {
		    get
		    {
			    return GetColumnValue<string>("CustomerID");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CustomerID", value);
            }

        }

	      
        [XmlAttribute("CustomerName")]
        public string CustomerName 
	    {
		    get
		    {
			    return GetColumnValue<string>("CustomerName");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CustomerName", value);
            }

        }

	      
        [XmlAttribute("Address")]
        public string Address 
	    {
		    get
		    {
			    return GetColumnValue<string>("Address");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Address", value);
            }

        }

	      
        [XmlAttribute("City")]
        public string City 
	    {
		    get
		    {
			    return GetColumnValue<string>("City");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("City", value);
            }

        }

	      
        [XmlAttribute("Region")]
        public string Region 
	    {
		    get
		    {
			    return GetColumnValue<string>("Region");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Region", value);
            }

        }

	      
        [XmlAttribute("PostalCode")]
        public string PostalCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("PostalCode");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("PostalCode", value);
            }

        }

	      
        [XmlAttribute("Country")]
        public string Country 
	    {
		    get
		    {
			    return GetColumnValue<string>("Country");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Country", value);
            }

        }

	      
        [XmlAttribute("Salesperson")]
        public string Salesperson 
	    {
		    get
		    {
			    return GetColumnValue<string>("Salesperson");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Salesperson", value);
            }

        }

	      
        [XmlAttribute("OrderID")]
        public int OrderID 
	    {
		    get
		    {
			    return GetColumnValue<int>("OrderID");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("OrderID", value);
            }

        }

	      
        [XmlAttribute("OrderDate")]
        public DateTime? OrderDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("OrderDate");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("OrderDate", value);
            }

        }

	      
        [XmlAttribute("RequiredDate")]
        public DateTime? RequiredDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("RequiredDate");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("RequiredDate", value);
            }

        }

	      
        [XmlAttribute("ShippedDate")]
        public DateTime? ShippedDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("ShippedDate");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShippedDate", value);
            }

        }

	      
        [XmlAttribute("ShipperName")]
        public string ShipperName 
	    {
		    get
		    {
			    return GetColumnValue<string>("ShipperName");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShipperName", value);
            }

        }

	      
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

	      
        [XmlAttribute("UnitPrice")]
        public decimal UnitPrice 
	    {
		    get
		    {
			    return GetColumnValue<decimal>("UnitPrice");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("UnitPrice", value);
            }

        }

	      
        [XmlAttribute("Quantity")]
        public short Quantity 
	    {
		    get
		    {
			    return GetColumnValue<short>("Quantity");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Quantity", value);
            }

        }

	      
        [XmlAttribute("Discount")]
        public decimal Discount 
	    {
		    get
		    {
			    return GetColumnValue<decimal>("Discount");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Discount", value);
            }

        }

	      
        [XmlAttribute("ExtendedPrice")]
        public decimal? ExtendedPrice 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("ExtendedPrice");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ExtendedPrice", value);
            }

        }

	      
        [XmlAttribute("Freight")]
        public decimal? Freight 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("Freight");
		    }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Freight", value);
            }

        }

	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string ShipName  = @"ShipName";
            
            public static string ShipAddress  = @"ShipAddress";
            
            public static string ShipCity  = @"ShipCity";
            
            public static string ShipRegion  = @"ShipRegion";
            
            public static string ShipPostalCode  = @"ShipPostalCode";
            
            public static string ShipCountry  = @"ShipCountry";
            
            public static string CustomerID  = @"CustomerID";
            
            public static string CustomerName  = @"CustomerName";
            
            public static string Address  = @"Address";
            
            public static string City  = @"City";
            
            public static string Region  = @"Region";
            
            public static string PostalCode  = @"PostalCode";
            
            public static string Country  = @"Country";
            
            public static string Salesperson  = @"Salesperson";
            
            public static string OrderID  = @"OrderID";
            
            public static string OrderDate  = @"OrderDate";
            
            public static string RequiredDate  = @"RequiredDate";
            
            public static string ShippedDate  = @"ShippedDate";
            
            public static string ShipperName  = @"ShipperName";
            
            public static string ProductID  = @"ProductID";
            
            public static string ProductName  = @"ProductName";
            
            public static string UnitPrice  = @"UnitPrice";
            
            public static string Quantity  = @"Quantity";
            
            public static string Discount  = @"Discount";
            
            public static string ExtendedPrice  = @"ExtendedPrice";
            
            public static string Freight  = @"Freight";
            
	    }

	    #endregion
    }

}
