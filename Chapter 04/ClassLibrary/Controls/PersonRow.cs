using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chapter04.Controls
{
    public class PersonRow : WebControl, IDataItemContainer, INamingContainer
    {

        #region "  Variables  "

        private object _data;
        private int _itemIndex;

        // default settings
        private PersonFormat personFormat = PersonFormat.SingleLine;
        private string firstNameField = "FirstName";
        private string lastNameField = "LastName";
        private string birthDateField = "BirthDate";
        private string birthDateFormat = "d";
        private string cityField = "City";
        private string countryField = "Country";

        // controls
        private LiteralControl ltFirstName;
        private LiteralControl ltLastName;
        private LiteralControl ltBirthDate;
        private LiteralControl ltCity;
        private LiteralControl ltCountry;

        #endregion

        #region "  Events  "

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (String.IsNullOrEmpty(CssClass))
            {
                CssClass = "personRow";
            }

            ltFirstName.Text = FirstName;
            ltLastName.Text = LastName;
            ltBirthDate.Text = BirthDate.ToString(birthDateFormat);
            ltCity.Text = City;
            ltCountry.Text = Country;
        }

        #endregion

        #region "  Methods  "

        public PersonRow(int itemIndex, object o)
            : base(HtmlTextWriterTag.Div)
        {
            _data = o;
            _itemIndex = itemIndex;
        }

        public virtual object Data
        {
            get
            {
                return _data;
            }
        }

        protected override void CreateChildControls()
        {
            CaptureSettings();

            ltFirstName = new LiteralControl();
            ltLastName = new LiteralControl();
            ltBirthDate = new LiteralControl();
            ltCity = new LiteralControl();
            ltCountry = new LiteralControl();

            if (Data != null)
            {
                DateTime dateValue;
                DateTime.TryParse(DataBinder.GetPropertyValue(Data, birthDateField, ""), out dateValue);

                FirstName = DataBinder.GetPropertyValue(Data, firstNameField, null);
                LastName = DataBinder.GetPropertyValue(Data, lastNameField, null);
                BirthDate = dateValue;
                City = DataBinder.GetPropertyValue(Data, cityField, null);
                Country = DataBinder.GetPropertyValue(Data, countryField, null);
            }

            if (personFormat == PersonFormat.SingleLine)
            {
                Controls.Add(new LiteralControl("\n<p>\n"));
                //Controls.Add(new LiteralControl((DataItemIndex + 1) + ". "));
                Controls.Add(ltFirstName);
                Controls.Add(new LiteralControl(" "));
                Controls.Add(ltLastName);
                Controls.Add(new LiteralControl(", "));
                Controls.Add(ltBirthDate);
                Controls.Add(new LiteralControl(", "));
                Controls.Add(ltCity);
                Controls.Add(new LiteralControl(", "));
                Controls.Add(ltCountry);
                Controls.Add(new LiteralControl("\n</p>\n"));
            }
            else
            {
                Controls.Add(new LiteralControl("\n<p>\n"));
                //Controls.Add(new LiteralControl((DataItemIndex + 1) + ". "));
                Controls.Add(ltFirstName);
                Controls.Add(new LiteralControl(" "));
                Controls.Add(ltLastName);
                Controls.Add(new LiteralControl("<br />\n"));
                Controls.Add(ltBirthDate);
                Controls.Add(new LiteralControl("<br />\n"));
                Controls.Add(ltCity);
                Controls.Add(new LiteralControl(", "));
                Controls.Add(ltCountry);
                Controls.Add(new LiteralControl("\n</p>\n"));
            }

        }

        /// <summary>
        /// Gets from the parent if the parent is the PersonListingControl
        /// </summary>
        private void CaptureSettings()
        {
            PersonListingControl parent = Parent as PersonListingControl;
            if (parent != null)
            {
                personFormat = parent.PersonFormat;
                firstNameField = parent.DataFirstNameField;
                lastNameField = parent.DataLastNameField;
                birthDateField = parent.DataBirthDateField;
                birthDateFormat = parent.DataBirthDateFormat;
                cityField = parent.DataCityField;
                countryField = parent.DataCountryField;
            }
        }

        #endregion

        #region "  Properties  "

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }

        private string _firstName = String.Empty;

        public string FirstName
        {
            get
            {
                EnsureChildControls();
                return _firstName;
            }
            set
            {
                EnsureChildControls();
                _firstName = value;
            }
        }

        private string _lastName = String.Empty;

        public string LastName
        {
            get
            {
                EnsureChildControls();
                return _lastName;
            }
            set
            {
                EnsureChildControls();
                _lastName = value;
            }
        }

        private DateTime _birthDate = DateTime.MinValue;

        public DateTime BirthDate
        {
            get
            {
                EnsureChildControls();
                return _birthDate;
            }
            set
            {
                EnsureChildControls();
                _birthDate = value;
            }
        }

        private string _city = String.Empty;

        public string City
        {
            get
            {
                EnsureChildControls();
                return _city;
            }
            set
            {
                EnsureChildControls();
                _city = value;
            }
        }

        private string _country = String.Empty;

        public string Country
        {
            get
            {
                EnsureChildControls();
                return _country;
            }
            set
            {
                EnsureChildControls();
                _country = value;
            }
        }

        #endregion

        #region "  IDataItemContainer Members  "

        public object DataItem
        {
            get
            {
                return Data;
            }
        }

        public int DataItemIndex
        {
            get
            {
                return _itemIndex;
            }
        }

        public int DisplayIndex
        {
            get
            {
                return _itemIndex;
            }
        }

        #endregion

        #region "  ViewState Management  "

        protected override void LoadViewState(object state)
        {
            if (state != null && state is Pair)
            {
                Pair pair = (Pair)state;
                base.LoadViewState(pair.First);

                object[] objArray = (object[])pair.Second;

                if (objArray[0] != null)
                {
                    _firstName = (string)objArray[0];
                }
                if (objArray[1] != null)
                {
                    _lastName = (string)objArray[1];
                }
                if (objArray[2] != null)
                {
                    _birthDate = (DateTime)objArray[2];
                }
                if (objArray[3] != null)
                {
                    _city = (string)objArray[3];
                }
                if (objArray[4] != null)
                {
                    _country = (string)objArray[4];
                }
            }
            else
            {
                base.LoadViewState(null);
            }
        }

        protected override object SaveViewState()
        {
            Pair state = new Pair();
            object baseState = base.SaveViewState();

            object[] objArray = new object[5];
            objArray[0] = _firstName;
            objArray[1] = _lastName;
            objArray[2] = _birthDate;
            objArray[3] = _city;
            objArray[4] = _country;

            state.First = baseState;
            state.Second = objArray;
            return state;
        }

        #endregion

    }
}