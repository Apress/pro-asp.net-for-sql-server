using System;
using System.Collections;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chapter04.Controls
{

    public enum PersonFormat
    {
        SingleLine,
        MultiLine
    };

    [
        AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal),
        AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal), 
        ToolboxData("<{0}:PersonListingControl runat=server></{0}:PersonListingControl>"),
        Designer(typeof(PersonListingDesigner))
    ]
    public class PersonListingControl : CompositeDataBoundControl, INamingContainer
    {

        #region "  Variables  "

        private const string SetPageIndexCommandName = "SetPageIndex";

        private LinkButton _previousLinkButton;
        private LinkButton _nextLinkButton;
        private bool _controlsInitialized = false;
        private int _itemCount = 0;

        #endregion

        #region "  Events  "

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }

        protected override void OnPagePreLoad(object sender, EventArgs e)
        {
            base.OnPagePreLoad(sender, e);
            if (Page.IsPostBack)
            {
                CreateChildControls(null, false);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            _previousLinkButton.Text = PreviousPageText;
            _nextLinkButton.Text = NextPageText;

            _previousLinkButton.CommandArgument = (PageIndex - 1).ToString();
            _previousLinkButton.Visible = EnablePaging && PageIndex > 0;

            _nextLinkButton.CommandArgument = (PageIndex + 1).ToString();
            _nextLinkButton.Visible = EnablePaging && PageIndex < MaxIndex;
        }

        protected void PagerButton_Click(object sender, EventArgs e)
        {
            LinkButton lb = sender as LinkButton;
            if (lb != null && SetPageIndexCommandName.Equals(lb.CommandName))
            {
                int pageIndex;
                int.TryParse(lb.CommandArgument, out pageIndex);
                PageIndex = pageIndex;
            }
        }

        #endregion

        #region "  Methods  "

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
        }

        protected override int CreateChildControls(
            IEnumerable dataSource, bool dataBinding)
        {
            Controls.Clear();
            int count = 0;

            if (dataBinding && dataSource != null)
            {
                IEnumerator e = dataSource.GetEnumerator();

                while (e.MoveNext())
                {
                    object datarow = e.Current;
                    PersonRow row = new PersonRow(count, datarow);
                    Rows.Add(row);
                    Controls.Add(row);
                    count++;
                }
                _itemCount = count;
            }
            else
            {
                if (_itemCount > 0)
                {
                    for (count = 0; count < _itemCount; count++)
                    {
                        PersonRow row = new PersonRow(count, null);
                        Rows.Add(row);
                        Controls.Add(row);
                    }
                }
            }

            CreatePagerControls();
            AttachStyle();

            ClearChildViewState();
            ChildControlsCreated = true;

            return count;
        }

        private void CreatePagerControls()
        {
            InitializePagerControls();

            Controls.Add(_previousLinkButton);
            Controls.Add(new LiteralControl(" "));
            Controls.Add(_nextLinkButton);
            Controls.Add(new LiteralControl(" "));
        }

        private void AttachStyle()
        {
            if (String.IsNullOrEmpty(CssClass))
            {
                CssClass = "personListing";
            }
        }

        private void InitializePagerControls()
        {
            if (_controlsInitialized)
            {
                return;
            }
            if (_nextLinkButton == null)
            {
                _nextLinkButton = new LinkButton();
                _nextLinkButton.ID = "lbNext";
                _nextLinkButton.Text = "Next";
                _nextLinkButton.CssClass = "btn";
                _nextLinkButton.CommandName = SetPageIndexCommandName;
                _nextLinkButton.Click += new EventHandler(PagerButton_Click);
            }
            if (_previousLinkButton == null)
            {
                _previousLinkButton = new LinkButton();
                _previousLinkButton.ID = "lbPrev";
                _previousLinkButton.Text = "Previous";
                _previousLinkButton.CssClass = "btn";
                _previousLinkButton.CommandName = SetPageIndexCommandName;
                _previousLinkButton.Click += new EventHandler(PagerButton_Click);
            }
            _controlsInitialized = true;
        }

        protected override void PerformSelect()
        {
            if (!IsBoundUsingDataSourceID)
            {
                OnDataBinding(EventArgs.Empty);
            }

            DataSourceView dataSourceView = GetData();

            DataSourceViewSelectCallback callback =
                delegate(IEnumerable data)
                {
                    if (IsBoundUsingDataSourceID)
                    {
                        OnDataBinding(EventArgs.Empty);
                    }
                    PerformDataBinding(data);
                };

            if (EnablePaging && dataSourceView.CanPage)
            {
                DataSourceSelectArguments selectArguments = CreateDataSourceSelectArguments();
                selectArguments.StartRowIndex = PageSize * PageIndex;
                selectArguments.MaximumRows = PageSize;
                dataSourceView.Select(selectArguments, callback);
            }
            else
            {
                DataSourceSelectArguments selectArguments = CreateDataSourceSelectArguments();
                if (dataSourceView.CanPage)
                {
                    selectArguments.AddSupportedCapabilities(DataSourceCapabilities.None);
                    selectArguments.StartRowIndex = 0;
                    selectArguments.MaximumRows = Int16.MaxValue;
                }
                dataSourceView.Select(selectArguments, callback);
            }

            RequiresDataBinding = false;
            MarkAsDataBound();

            OnDataBound(EventArgs.Empty);
        }

        private int GetTotalRowCount()
        {
            int totalRowCount = 0;
            DataSourceView dataSourceView = GetData();
            if (dataSourceView.CanRetrieveTotalRowCount)
            {
                DataSourceSelectArguments selectArguments = CreateDataSourceSelectArguments();
                selectArguments.AddSupportedCapabilities(DataSourceCapabilities.RetrieveTotalRowCount);
                selectArguments.RetrieveTotalRowCount = true;
                DataSourceViewSelectCallback callback =
                    delegate
                    {
                        totalRowCount = selectArguments.TotalRowCount;
                    };
                dataSourceView.Select(selectArguments, callback);
            }
            return totalRowCount;
        }

        #endregion

        #region "  Control State  "

        protected override object SaveControlState()
        {
            object[] state = new object[6];
            state[0] = base.SaveControlState();
            state[1] = _pageIndex;
            state[2] = _totalRowsCount;
            state[3] = _itemCount;
            state[4] = _previousLinkButton.CommandArgument;
            state[5] = _nextLinkButton.CommandArgument;

            return state;
        }

        protected override void LoadControlState(object savedState)
        {
            _pageIndex = 0;
            object[] objArray = savedState as object[];
            if (objArray != null)
            {
                InitializePagerControls();
                base.LoadControlState(objArray[0]);
                if (objArray[1] != null)
                {
                    _pageIndex = (int) objArray[1];
                }
                if (objArray[2] != null)
                {
                    _totalRowsCount = (int)objArray[2];
                }
                if (objArray[3] != null)
                {
                    _itemCount = (int)objArray[3];
                }
                if (objArray[4] != null)
                {
                    _previousLinkButton.CommandArgument = (string)objArray[4];
                }
                if (objArray[5] != null)
                {
                    _nextLinkButton.CommandArgument = (string)objArray[5];
                }
            }
            else
            {
                base.LoadControlState(null);
            }
        }

        #endregion

        #region "  Control Properties  "

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }

        #endregion

        #region "  Paging Properties  "

        [Category("Paging"), DefaultValue(false)]
        public virtual bool EnablePaging
        {
            get
            {
                EnsureChildControls();
                object allowPaging = ViewState["EnablePaging"];
                if (allowPaging != null)
                {
                    return (bool)allowPaging;
                }
                return false;
            }
            set
            {
                EnsureChildControls();
                bool allowPaging = EnablePaging;
                if (value != allowPaging)
                {
                    ViewState["EnablePaging"] = value;
                    if (Initialized)
                    {
                        RequiresDataBinding = true;
                    }
                }
            }
        }

        private int _pageSize = 10;

        [Category("Paging"), DefaultValue(10)]
        public virtual int PageSize
        {
            get
            {
                EnsureChildControls();
                return _pageSize;
            }
            set
            {
                EnsureChildControls();
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                if (PageSize != value)
                {
                    _pageSize = value;
                    if (Initialized)
                    {
                        RequiresDataBinding = true;
                    }
                }
            }
        }

        private int _pageIndex = 0;

        [Browsable(false)]
        public virtual int PageIndex
        {
            get
            {
                EnsureChildControls();
                return _pageIndex;
            }
            set
            {
                EnsureChildControls();
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                if (_pageIndex != value)
                {
                    _pageIndex = value;
                    if (Initialized)
                    {
                        RequiresDataBinding = true;
                    }
                }
            }
        }

        private int _maxIndex = 0;

        [Browsable(false)]
        public virtual int MaxIndex
        {
            get
            {
                if (_maxIndex == 0)
                {
                    double maxIndexDbl = (TotalRowsCount/PageSize) - 1;
                    _maxIndex = (int)maxIndexDbl;
                    if (maxIndexDbl > _maxIndex)
                    {
                        _maxIndex++;
                    }
                }
                return _maxIndex;
            }
        }

        private int _totalRowsCount = 0;

        [Browsable(false)]
        public virtual int TotalRowsCount
        {
            get
            {
                if (_totalRowsCount == 0)
                {
                    _totalRowsCount = GetTotalRowCount();
                }
                return _totalRowsCount;
            }
        }

        private string _previousPageText = "Previous";

        [Category("Paging"), DefaultValue("Previous")]
        public virtual string PreviousPageText
        {
            get
            {
                return _previousPageText;
            }
            set
            {
                _previousPageText = value;
            }
        }

        private string _nextPageText = "Next";

        [Category("Paging"), DefaultValue("Next")]
        public virtual string NextPageText
        {
            get
            {
                return _nextPageText;
            }
            set
            {
                _nextPageText = value;
            }
        }

        #endregion

        #region "  Child Properties  "

        private PersonRowsCollection _personRows;

        [Browsable(false)]
        public PersonRowsCollection Rows
        {
            get
            {
                if (_personRows == null)
                {
                    _personRows = new PersonRowsCollection();
                }
                return _personRows;
            }
        }

        #endregion

        #region "  Display Properties  "

        private PersonFormat _personFormat = PersonFormat.SingleLine;
        
        [Browsable(true), Category("Appearance"), Description("Person Format"), DefaultValue("SingleLine")]
        public PersonFormat PersonFormat
        {
            get
            {
                EnsureChildControls();
                return _personFormat;
            }
            set
            {
                EnsureChildControls();
                _personFormat = value;
            }
        }

        private string _dataFirstNameField = "FirstName";
        [Browsable(true), Category("Data"), Description("First Name Data Field"), DefaultValue("FirstName")]
        public string DataFirstNameField
        {
            get
            {
                EnsureChildControls();
                return _dataFirstNameField;
            }
            set
            {
                EnsureChildControls();
                _dataFirstNameField = value;
            }
        }

        private string _dataLastNameField = "LastName";
        [Browsable(true), Category("Data"), Description("Last Name Data Field"), DefaultValue("LastName")]
        public string DataLastNameField
        {
            get
            {
                EnsureChildControls();
                return _dataLastNameField;
            }
            set
            {
                EnsureChildControls();
                _dataLastNameField = value;
            }
        }

        private string _dataBirthDateNameField = "BirthDate";
        [Browsable(true), Category("Data"), Description("Birth Date Data Field"), DefaultValue("BirthDate")]
        public string DataBirthDateField
        {
            get
            {
                EnsureChildControls();
                return _dataBirthDateNameField;
            }
            set
            {
                EnsureChildControls();
                _dataBirthDateNameField = value;
            }
        }

        private string _dataBirthDateFormat = "d";
        [Browsable(true), Category("Data"), Description("Birth Date Format"), DefaultValue("d")]
        public string DataBirthDateFormat
        {
            get
            {
                EnsureChildControls();
                return _dataBirthDateFormat;
            }
            set
            {
                EnsureChildControls();
                _dataBirthDateFormat = value;
            }
        }

        private string _dataCityField = "City";
        [Browsable(true), Category("Data"), Description("City Data Field"), DefaultValue("City")]
        public string DataCityField
        {
            get
            {
                EnsureChildControls();
                return _dataCityField;
            }
            set
            {
                EnsureChildControls();
                _dataCityField = value;
            }
        }

        private string _dataCountryField = "Country";
        [Browsable(true), Category("Data"), Description("Country Data Field"), DefaultValue("Country")]
        public string DataCountryField
        {
            get
            {
                EnsureChildControls();
                return _dataCountryField;
            }
            set
            {
                EnsureChildControls();
                _dataCountryField = value;
            }
        }

        #endregion
    }

}
