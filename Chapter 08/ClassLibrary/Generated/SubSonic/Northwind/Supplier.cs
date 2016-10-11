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


//Generated on 6/10/2007 10:06:59 PM by brennan

namespace Chapter08.NorthwindDAL{
    /// <summary>
    /// Strongly-typed collection for the Supplier class.
    /// </summary>
    [Serializable]
    public partial class SupplierCollection : ActiveList<Supplier> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public SupplierCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public SupplierCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public SupplierCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public SupplierCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public SupplierCollection Where(string columnName, object value) 
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

    	
        public SupplierCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public SupplierCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public SupplierCollection Load() 
        {
            Query qry = new Query(Supplier.Schema);
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

        
        public SupplierCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Suppliers table.
    /// </summary>
    [Serializable]
    public partial class Supplier : ActiveRecord<Supplier>
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
				TableSchema.Table schema = new TableSchema.Table("Suppliers", TableType.Table, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarSupplierID = new TableSchema.TableColumn(schema);
                colvarSupplierID.ColumnName = "SupplierID";
                colvarSupplierID.DataType = DbType.Int32;
                colvarSupplierID.MaxLength = 0;
                colvarSupplierID.AutoIncrement = true;
                colvarSupplierID.IsNullable = false;
                colvarSupplierID.IsPrimaryKey = true;
                colvarSupplierID.IsForeignKey = false;
                colvarSupplierID.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarSupplierID);
                
                TableSchema.TableColumn colvarCompanyName = new TableSchema.TableColumn(schema);
                colvarCompanyName.ColumnName = "CompanyName";
                colvarCompanyName.DataType = DbType.String;
                colvarCompanyName.MaxLength = 40;
                colvarCompanyName.AutoIncrement = false;
                colvarCompanyName.IsNullable = false;
                colvarCompanyName.IsPrimaryKey = false;
                colvarCompanyName.IsForeignKey = false;
                colvarCompanyName.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarCompanyName);
                
                TableSchema.TableColumn colvarContactName = new TableSchema.TableColumn(schema);
                colvarContactName.ColumnName = "ContactName";
                colvarContactName.DataType = DbType.String;
                colvarContactName.MaxLength = 30;
                colvarContactName.AutoIncrement = false;
                colvarContactName.IsNullable = true;
                colvarContactName.IsPrimaryKey = false;
                colvarContactName.IsForeignKey = false;
                colvarContactName.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarContactName);
                
                TableSchema.TableColumn colvarContactTitle = new TableSchema.TableColumn(schema);
                colvarContactTitle.ColumnName = "ContactTitle";
                colvarContactTitle.DataType = DbType.String;
                colvarContactTitle.MaxLength = 30;
                colvarContactTitle.AutoIncrement = false;
                colvarContactTitle.IsNullable = true;
                colvarContactTitle.IsPrimaryKey = false;
                colvarContactTitle.IsForeignKey = false;
                colvarContactTitle.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarContactTitle);
                
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
                
                TableSchema.TableColumn colvarPhone = new TableSchema.TableColumn(schema);
                colvarPhone.ColumnName = "Phone";
                colvarPhone.DataType = DbType.String;
                colvarPhone.MaxLength = 24;
                colvarPhone.AutoIncrement = false;
                colvarPhone.IsNullable = true;
                colvarPhone.IsPrimaryKey = false;
                colvarPhone.IsForeignKey = false;
                colvarPhone.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarPhone);
                
                TableSchema.TableColumn colvarFax = new TableSchema.TableColumn(schema);
                colvarFax.ColumnName = "Fax";
                colvarFax.DataType = DbType.String;
                colvarFax.MaxLength = 24;
                colvarFax.AutoIncrement = false;
                colvarFax.IsNullable = true;
                colvarFax.IsPrimaryKey = false;
                colvarFax.IsForeignKey = false;
                colvarFax.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarFax);
                
                TableSchema.TableColumn colvarHomePage = new TableSchema.TableColumn(schema);
                colvarHomePage.ColumnName = "HomePage";
                colvarHomePage.DataType = DbType.String;
                colvarHomePage.MaxLength = 1073741823;
                colvarHomePage.AutoIncrement = false;
                colvarHomePage.IsNullable = true;
                colvarHomePage.IsPrimaryKey = false;
                colvarHomePage.IsForeignKey = false;
                colvarHomePage.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarHomePage);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Suppliers",schema);
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
	    public Supplier()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public Supplier(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public Supplier(string columnName, object columnValue)
        {
            SetSQLProps();
            SetDefaults();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("SupplierID")]
        public int SupplierID 
	    {
		    get { return GetColumnValue<int>("SupplierID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("SupplierID", value);
            }

        }

	      
        [XmlAttribute("CompanyName")]
        public string CompanyName 
	    {
		    get { return GetColumnValue<string>("CompanyName"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CompanyName", value);
            }

        }

	      
        [XmlAttribute("ContactName")]
        public string ContactName 
	    {
		    get { return GetColumnValue<string>("ContactName"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ContactName", value);
            }

        }

	      
        [XmlAttribute("ContactTitle")]
        public string ContactTitle 
	    {
		    get { return GetColumnValue<string>("ContactTitle"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ContactTitle", value);
            }

        }

	      
        [XmlAttribute("Address")]
        public string Address 
	    {
		    get { return GetColumnValue<string>("Address"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Address", value);
            }

        }

	      
        [XmlAttribute("City")]
        public string City 
	    {
		    get { return GetColumnValue<string>("City"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("City", value);
            }

        }

	      
        [XmlAttribute("Region")]
        public string Region 
	    {
		    get { return GetColumnValue<string>("Region"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Region", value);
            }

        }

	      
        [XmlAttribute("PostalCode")]
        public string PostalCode 
	    {
		    get { return GetColumnValue<string>("PostalCode"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("PostalCode", value);
            }

        }

	      
        [XmlAttribute("Country")]
        public string Country 
	    {
		    get { return GetColumnValue<string>("Country"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Country", value);
            }

        }

	      
        [XmlAttribute("Phone")]
        public string Phone 
	    {
		    get { return GetColumnValue<string>("Phone"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Phone", value);
            }

        }

	      
        [XmlAttribute("Fax")]
        public string Fax 
	    {
		    get { return GetColumnValue<string>("Fax"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Fax", value);
            }

        }

	      
        [XmlAttribute("HomePage")]
        public string HomePage 
	    {
		    get { return GetColumnValue<string>("HomePage"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("HomePage", value);
            }

        }

	    
	    #endregion
	    
	    
	    #region PrimaryKey Methods
	    
		public Chapter08.NorthwindDAL.ProductCollection Products()
		{
			return new Chapter08.NorthwindDAL.ProductCollection().Where(Product.Columns.SupplierID, SupplierID).Load();
		}

		#endregion
		
	 	
			
	    
	    //no foreign key tables defined (0)
	    
	    
	    
	    //no ManyToMany tables defined (0)
	    
	    #region ObjectDataSource support
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(string varCompanyName,string varContactName,string varContactTitle,string varAddress,string varCity,string varRegion,string varPostalCode,string varCountry,string varPhone,string varFax,string varHomePage)
	    {
		    Supplier item = new Supplier();
		    
            item.CompanyName = varCompanyName;
            
            item.ContactName = varContactName;
            
            item.ContactTitle = varContactTitle;
            
            item.Address = varAddress;
            
            item.City = varCity;
            
            item.Region = varRegion;
            
            item.PostalCode = varPostalCode;
            
            item.Country = varCountry;
            
            item.Phone = varPhone;
            
            item.Fax = varFax;
            
            item.HomePage = varHomePage;
            
	    
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(int varSupplierID,string varCompanyName,string varContactName,string varContactTitle,string varAddress,string varCity,string varRegion,string varPostalCode,string varCountry,string varPhone,string varFax,string varHomePage)
	    {
		    Supplier item = new Supplier();
		    
                item.SupplierID = varSupplierID;
				
                item.CompanyName = varCompanyName;
				
                item.ContactName = varContactName;
				
                item.ContactTitle = varContactTitle;
				
                item.Address = varAddress;
				
                item.City = varCity;
				
                item.Region = varRegion;
				
                item.PostalCode = varPostalCode;
				
                item.Country = varCountry;
				
                item.Phone = varPhone;
				
                item.Fax = varFax;
				
                item.HomePage = varHomePage;
				
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
		    
		    
            public static string SupplierID = @"SupplierID";
            
            public static string CompanyName = @"CompanyName";
            
            public static string ContactName = @"ContactName";
            
            public static string ContactTitle = @"ContactTitle";
            
            public static string Address = @"Address";
            
            public static string City = @"City";
            
            public static string Region = @"Region";
            
            public static string PostalCode = @"PostalCode";
            
            public static string Country = @"Country";
            
            public static string Phone = @"Phone";
            
            public static string Fax = @"Fax";
            
            public static string HomePage = @"HomePage";
            
	    }

	    #endregion
    }

}

