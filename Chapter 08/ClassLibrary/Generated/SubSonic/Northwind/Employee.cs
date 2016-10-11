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


//Generated on 6/10/2007 10:06:54 PM by brennan

namespace Chapter08.NorthwindDAL{
    /// <summary>
    /// Strongly-typed collection for the Employee class.
    /// </summary>
    [Serializable]
    public partial class EmployeeCollection : ActiveList<Employee> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public EmployeeCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public EmployeeCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public EmployeeCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public EmployeeCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public EmployeeCollection Where(string columnName, object value) 
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

    	
        public EmployeeCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public EmployeeCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public EmployeeCollection Load() 
        {
            Query qry = new Query(Employee.Schema);
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

        
        public EmployeeCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Employees table.
    /// </summary>
    [Serializable]
    public partial class Employee : ActiveRecord<Employee>
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
				TableSchema.Table schema = new TableSchema.Table("Employees", TableType.Table, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarEmployeeID = new TableSchema.TableColumn(schema);
                colvarEmployeeID.ColumnName = "EmployeeID";
                colvarEmployeeID.DataType = DbType.Int32;
                colvarEmployeeID.MaxLength = 0;
                colvarEmployeeID.AutoIncrement = true;
                colvarEmployeeID.IsNullable = false;
                colvarEmployeeID.IsPrimaryKey = true;
                colvarEmployeeID.IsForeignKey = false;
                colvarEmployeeID.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarEmployeeID);
                
                TableSchema.TableColumn colvarLastName = new TableSchema.TableColumn(schema);
                colvarLastName.ColumnName = "LastName";
                colvarLastName.DataType = DbType.String;
                colvarLastName.MaxLength = 20;
                colvarLastName.AutoIncrement = false;
                colvarLastName.IsNullable = false;
                colvarLastName.IsPrimaryKey = false;
                colvarLastName.IsForeignKey = false;
                colvarLastName.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarLastName);
                
                TableSchema.TableColumn colvarFirstName = new TableSchema.TableColumn(schema);
                colvarFirstName.ColumnName = "FirstName";
                colvarFirstName.DataType = DbType.String;
                colvarFirstName.MaxLength = 10;
                colvarFirstName.AutoIncrement = false;
                colvarFirstName.IsNullable = false;
                colvarFirstName.IsPrimaryKey = false;
                colvarFirstName.IsForeignKey = false;
                colvarFirstName.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarFirstName);
                
                TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
                colvarTitle.ColumnName = "Title";
                colvarTitle.DataType = DbType.String;
                colvarTitle.MaxLength = 30;
                colvarTitle.AutoIncrement = false;
                colvarTitle.IsNullable = true;
                colvarTitle.IsPrimaryKey = false;
                colvarTitle.IsForeignKey = false;
                colvarTitle.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarTitle);
                
                TableSchema.TableColumn colvarTitleOfCourtesy = new TableSchema.TableColumn(schema);
                colvarTitleOfCourtesy.ColumnName = "TitleOfCourtesy";
                colvarTitleOfCourtesy.DataType = DbType.String;
                colvarTitleOfCourtesy.MaxLength = 25;
                colvarTitleOfCourtesy.AutoIncrement = false;
                colvarTitleOfCourtesy.IsNullable = true;
                colvarTitleOfCourtesy.IsPrimaryKey = false;
                colvarTitleOfCourtesy.IsForeignKey = false;
                colvarTitleOfCourtesy.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarTitleOfCourtesy);
                
                TableSchema.TableColumn colvarBirthDate = new TableSchema.TableColumn(schema);
                colvarBirthDate.ColumnName = "BirthDate";
                colvarBirthDate.DataType = DbType.DateTime;
                colvarBirthDate.MaxLength = 0;
                colvarBirthDate.AutoIncrement = false;
                colvarBirthDate.IsNullable = true;
                colvarBirthDate.IsPrimaryKey = false;
                colvarBirthDate.IsForeignKey = false;
                colvarBirthDate.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarBirthDate);
                
                TableSchema.TableColumn colvarHireDate = new TableSchema.TableColumn(schema);
                colvarHireDate.ColumnName = "HireDate";
                colvarHireDate.DataType = DbType.DateTime;
                colvarHireDate.MaxLength = 0;
                colvarHireDate.AutoIncrement = false;
                colvarHireDate.IsNullable = true;
                colvarHireDate.IsPrimaryKey = false;
                colvarHireDate.IsForeignKey = false;
                colvarHireDate.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarHireDate);
                
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
                
                TableSchema.TableColumn colvarHomePhone = new TableSchema.TableColumn(schema);
                colvarHomePhone.ColumnName = "HomePhone";
                colvarHomePhone.DataType = DbType.String;
                colvarHomePhone.MaxLength = 24;
                colvarHomePhone.AutoIncrement = false;
                colvarHomePhone.IsNullable = true;
                colvarHomePhone.IsPrimaryKey = false;
                colvarHomePhone.IsForeignKey = false;
                colvarHomePhone.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarHomePhone);
                
                TableSchema.TableColumn colvarExtension = new TableSchema.TableColumn(schema);
                colvarExtension.ColumnName = "Extension";
                colvarExtension.DataType = DbType.String;
                colvarExtension.MaxLength = 4;
                colvarExtension.AutoIncrement = false;
                colvarExtension.IsNullable = true;
                colvarExtension.IsPrimaryKey = false;
                colvarExtension.IsForeignKey = false;
                colvarExtension.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarExtension);
                
                TableSchema.TableColumn colvarPhoto = new TableSchema.TableColumn(schema);
                colvarPhoto.ColumnName = "Photo";
                colvarPhoto.DataType = DbType.Binary;
                colvarPhoto.MaxLength = 2147483647;
                colvarPhoto.AutoIncrement = false;
                colvarPhoto.IsNullable = true;
                colvarPhoto.IsPrimaryKey = false;
                colvarPhoto.IsForeignKey = false;
                colvarPhoto.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarPhoto);
                
                TableSchema.TableColumn colvarNotes = new TableSchema.TableColumn(schema);
                colvarNotes.ColumnName = "Notes";
                colvarNotes.DataType = DbType.String;
                colvarNotes.MaxLength = 1073741823;
                colvarNotes.AutoIncrement = false;
                colvarNotes.IsNullable = true;
                colvarNotes.IsPrimaryKey = false;
                colvarNotes.IsForeignKey = false;
                colvarNotes.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarNotes);
                
                TableSchema.TableColumn colvarReportsTo = new TableSchema.TableColumn(schema);
                colvarReportsTo.ColumnName = "ReportsTo";
                colvarReportsTo.DataType = DbType.Int32;
                colvarReportsTo.MaxLength = 0;
                colvarReportsTo.AutoIncrement = false;
                colvarReportsTo.IsNullable = true;
                colvarReportsTo.IsPrimaryKey = false;
                colvarReportsTo.IsForeignKey = true;
                colvarReportsTo.IsReadOnly = false;
                
                
				colvarReportsTo.ForeignKeyTableName = "Employees";
                
                schema.Columns.Add(colvarReportsTo);
                
                TableSchema.TableColumn colvarPhotoPath = new TableSchema.TableColumn(schema);
                colvarPhotoPath.ColumnName = "PhotoPath";
                colvarPhotoPath.DataType = DbType.String;
                colvarPhotoPath.MaxLength = 255;
                colvarPhotoPath.AutoIncrement = false;
                colvarPhotoPath.IsNullable = true;
                colvarPhotoPath.IsPrimaryKey = false;
                colvarPhotoPath.IsForeignKey = false;
                colvarPhotoPath.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarPhotoPath);
                
                TableSchema.TableColumn colvarDeleted = new TableSchema.TableColumn(schema);
                colvarDeleted.ColumnName = "Deleted";
                colvarDeleted.DataType = DbType.Boolean;
                colvarDeleted.MaxLength = 0;
                colvarDeleted.AutoIncrement = false;
                colvarDeleted.IsNullable = false;
                colvarDeleted.IsPrimaryKey = false;
                colvarDeleted.IsForeignKey = false;
                colvarDeleted.IsReadOnly = false;
                
						colvarDeleted.DefaultSetting = @"((0))";
				
                
                schema.Columns.Add(colvarDeleted);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Employees",schema);
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
	    public Employee()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public Employee(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public Employee(string columnName, object columnValue)
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

	      
        [XmlAttribute("LastName")]
        public string LastName 
	    {
		    get { return GetColumnValue<string>("LastName"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("LastName", value);
            }

        }

	      
        [XmlAttribute("FirstName")]
        public string FirstName 
	    {
		    get { return GetColumnValue<string>("FirstName"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("FirstName", value);
            }

        }

	      
        [XmlAttribute("Title")]
        public string Title 
	    {
		    get { return GetColumnValue<string>("Title"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Title", value);
            }

        }

	      
        [XmlAttribute("TitleOfCourtesy")]
        public string TitleOfCourtesy 
	    {
		    get { return GetColumnValue<string>("TitleOfCourtesy"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("TitleOfCourtesy", value);
            }

        }

	      
        [XmlAttribute("BirthDate")]
        public DateTime? BirthDate 
	    {
		    get { return GetColumnValue<DateTime?>("BirthDate"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("BirthDate", value);
            }

        }

	      
        [XmlAttribute("HireDate")]
        public DateTime? HireDate 
	    {
		    get { return GetColumnValue<DateTime?>("HireDate"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("HireDate", value);
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

	      
        [XmlAttribute("HomePhone")]
        public string HomePhone 
	    {
		    get { return GetColumnValue<string>("HomePhone"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("HomePhone", value);
            }

        }

	      
        [XmlAttribute("Extension")]
        public string Extension 
	    {
		    get { return GetColumnValue<string>("Extension"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Extension", value);
            }

        }

	      
        [XmlAttribute("Photo")]
        public byte[] Photo 
	    {
		    get { return GetColumnValue<byte[]>("Photo"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Photo", value);
            }

        }

	      
        [XmlAttribute("Notes")]
        public string Notes 
	    {
		    get { return GetColumnValue<string>("Notes"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Notes", value);
            }

        }

	      
        [XmlAttribute("ReportsTo")]
        public int? ReportsTo 
	    {
		    get { return GetColumnValue<int?>("ReportsTo"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ReportsTo", value);
            }

        }

	      
        [XmlAttribute("PhotoPath")]
        public string PhotoPath 
	    {
		    get { return GetColumnValue<string>("PhotoPath"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("PhotoPath", value);
            }

        }

	      
        [XmlAttribute("Deleted")]
        public bool Deleted 
	    {
		    get { return GetColumnValue<bool>("Deleted"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Deleted", value);
            }

        }

	    
	    #endregion
	    
	    
	    #region PrimaryKey Methods
	    
		public Chapter08.NorthwindDAL.EmployeeCollection ChildEmployees()
		{
			return new Chapter08.NorthwindDAL.EmployeeCollection().Where(Employee.Columns.ReportsTo, EmployeeID).Load();
		}

		public Chapter08.NorthwindDAL.EmployeeTerritoryCollection EmployeeTerritories()
		{
			return new Chapter08.NorthwindDAL.EmployeeTerritoryCollection().Where(EmployeeTerritory.Columns.EmployeeID, EmployeeID).Load();
		}

		public Chapter08.NorthwindDAL.OrderCollection Orders()
		{
			return new Chapter08.NorthwindDAL.OrderCollection().Where(Order.Columns.EmployeeID, EmployeeID).Load();
		}

		#endregion
		
	 	
			
	    
	    
	    
	    #region ForeignKey Properties
	    
        /// <summary>
        /// Returns a Employee ActiveRecord object related to this Employee
        /// </summary>
	    public Chapter08.NorthwindDAL.Employee ParentEmployee
        {
	        get { return Chapter08.NorthwindDAL.Employee.FetchByID(this.ReportsTo); }

	        set
	        {
		        MarkDirty();
		        SetColumnValue("ReportsTo", value.EmployeeID);
	        }

        }

	    
	    
	    #endregion
	    
	    
	    
	    #region Many To Many Helpers
	    
	     
        public Chapter08.NorthwindDAL.TerritoryCollection GetTerritoryCollection() {
            return Employee.GetTerritoryCollection(this.EmployeeID);
        }

        public static Chapter08.NorthwindDAL.TerritoryCollection GetTerritoryCollection(int varEmployeeID) {
            SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
                "SELECT * FROM Territories INNER JOIN EmployeeTerritories ON "+
                "Territories.TerritoryID=EmployeeTerritories.TerritoryID WHERE EmployeeTerritories.EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
            
            cmd.AddParameter("@EmployeeID", varEmployeeID);
            
            IDataReader rdr = SubSonic.DataService.GetReader(cmd);
            TerritoryCollection coll = new TerritoryCollection();
            coll.LoadAndCloseReader(rdr);
            return coll;
        }

        public static void SaveTerritoryMap(int varEmployeeID, TerritoryCollection items) {
            
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
            QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeTerritories WHERE EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
            cmdDel.AddParameter("@EmployeeID", varEmployeeID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (Territory item in items)
            {
				EmployeeTerritory varEmployeeTerritory = new EmployeeTerritory();
				varEmployeeTerritory.SetColumnValue("EmployeeID", varEmployeeID);
				varEmployeeTerritory.SetColumnValue("TerritoryID", item.GetPrimaryKeyValue());
				varEmployeeTerritory.Save();
            }

        }

        public static void SaveTerritoryMap(int varEmployeeID, System.Web.UI.WebControls.ListItemCollection itemList) 
        {
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
             QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeTerritories WHERE EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
            cmdDel.AddParameter("@EmployeeID", varEmployeeID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (System.Web.UI.WebControls.ListItem l in itemList) 
            {
                if (l.Selected) 
                {
					EmployeeTerritory varEmployeeTerritory = new EmployeeTerritory();
					varEmployeeTerritory.SetColumnValue("EmployeeID", varEmployeeID);
					varEmployeeTerritory.SetColumnValue("TerritoryID", l.Value);
					varEmployeeTerritory.Save();
                }

            }

        }

        public static void SaveTerritoryMap(int varEmployeeID , int[] itemList) 
        {
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
             QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeTerritories WHERE EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
            cmdDel.AddParameter("@EmployeeID", varEmployeeID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (int item in itemList) 
            {
            	EmployeeTerritory varEmployeeTerritory = new EmployeeTerritory();
				varEmployeeTerritory.SetColumnValue("EmployeeID", varEmployeeID);
				varEmployeeTerritory.SetColumnValue("TerritoryID", item);
				varEmployeeTerritory.Save();
            }

        }

        
        public static void DeleteTerritoryMap(int varEmployeeID) 
        {
            QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeTerritories WHERE EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
            cmdDel.AddParameter("@EmployeeID", varEmployeeID);
            DataService.ExecuteQuery(cmdDel);
		}

	    
	    #endregion
	    
	    #region ObjectDataSource support
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(string varLastName,string varFirstName,string varTitle,string varTitleOfCourtesy,DateTime? varBirthDate,DateTime? varHireDate,string varAddress,string varCity,string varRegion,string varPostalCode,string varCountry,string varHomePhone,string varExtension,byte[] varPhoto,string varNotes,int? varReportsTo,string varPhotoPath,bool varDeleted)
	    {
		    Employee item = new Employee();
		    
            item.LastName = varLastName;
            
            item.FirstName = varFirstName;
            
            item.Title = varTitle;
            
            item.TitleOfCourtesy = varTitleOfCourtesy;
            
            item.BirthDate = varBirthDate;
            
            item.HireDate = varHireDate;
            
            item.Address = varAddress;
            
            item.City = varCity;
            
            item.Region = varRegion;
            
            item.PostalCode = varPostalCode;
            
            item.Country = varCountry;
            
            item.HomePhone = varHomePhone;
            
            item.Extension = varExtension;
            
            item.Photo = varPhoto;
            
            item.Notes = varNotes;
            
            item.ReportsTo = varReportsTo;
            
            item.PhotoPath = varPhotoPath;
            
            item.Deleted = varDeleted;
            
	    
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(int varEmployeeID,string varLastName,string varFirstName,string varTitle,string varTitleOfCourtesy,DateTime? varBirthDate,DateTime? varHireDate,string varAddress,string varCity,string varRegion,string varPostalCode,string varCountry,string varHomePhone,string varExtension,byte[] varPhoto,string varNotes,int? varReportsTo,string varPhotoPath,bool varDeleted)
	    {
		    Employee item = new Employee();
		    
                item.EmployeeID = varEmployeeID;
				
                item.LastName = varLastName;
				
                item.FirstName = varFirstName;
				
                item.Title = varTitle;
				
                item.TitleOfCourtesy = varTitleOfCourtesy;
				
                item.BirthDate = varBirthDate;
				
                item.HireDate = varHireDate;
				
                item.Address = varAddress;
				
                item.City = varCity;
				
                item.Region = varRegion;
				
                item.PostalCode = varPostalCode;
				
                item.Country = varCountry;
				
                item.HomePhone = varHomePhone;
				
                item.Extension = varExtension;
				
                item.Photo = varPhoto;
				
                item.Notes = varNotes;
				
                item.ReportsTo = varReportsTo;
				
                item.PhotoPath = varPhotoPath;
				
                item.Deleted = varDeleted;
				
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
            
            public static string LastName = @"LastName";
            
            public static string FirstName = @"FirstName";
            
            public static string Title = @"Title";
            
            public static string TitleOfCourtesy = @"TitleOfCourtesy";
            
            public static string BirthDate = @"BirthDate";
            
            public static string HireDate = @"HireDate";
            
            public static string Address = @"Address";
            
            public static string City = @"City";
            
            public static string Region = @"Region";
            
            public static string PostalCode = @"PostalCode";
            
            public static string Country = @"Country";
            
            public static string HomePhone = @"HomePhone";
            
            public static string Extension = @"Extension";
            
            public static string Photo = @"Photo";
            
            public static string Notes = @"Notes";
            
            public static string ReportsTo = @"ReportsTo";
            
            public static string PhotoPath = @"PhotoPath";
            
            public static string Deleted = @"Deleted";
            
	    }

	    #endregion
    }

}

