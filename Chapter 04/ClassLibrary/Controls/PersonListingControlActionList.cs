using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace Chapter04.Controls
{
    internal class PersonListingControlActionList : DesignerActionList
    {
        private PersonListingControl _ctrl = null;

        #region "  Action List Constructor  "

        /// <summary>
        /// Contructor
        /// </summary>
        public PersonListingControlActionList(IComponent component)
            : base(component)
        {
            _ctrl = component as PersonListingControl;
        }

        #endregion

        #region "  Action List Methods  "

        /// <summary>
        /// Launches support website
        /// </summary>
        public void LaunchWebsite()
        {
            Process.Start("http://www.apress.com/book/bookDisplay.html?bID=10300");
        }

        /// <summary>
        /// Override method
        /// </summary>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection actionItems = new DesignerActionItemCollection();

            actionItems.Add(new DesignerActionHeaderItem("Display"));
            actionItems.Add(new DesignerActionHeaderItem("Support"));

            actionItems.Add(new DesignerActionPropertyItem("EnablePaging", "Enable Paging", "Display"));
            actionItems.Add(new DesignerActionPropertyItem("PersonFormat", "Person Format", "Display"));
            actionItems.Add(new DesignerActionMethodItem(this, "LaunchWebsite", "Apress.com", "Support"));

            return actionItems;
        }

        /// <summary>
        /// Override method
        /// </summary>
        private PropertyDescriptor GetControlProperty(string propertyName)
        {
            PropertyDescriptor pd = TypeDescriptor.GetProperties(_ctrl)[propertyName];
            if (pd != null)
            {
                return pd;
            }
            else
            {
                throw new ArgumentException("Invalid property", propertyName);
            }
        }
        
        #endregion

        #region "  Action List Properties  "

        public bool EnablePaging
        {
            get
            {
                return _ctrl.EnablePaging;
            }
            set
            {
                GetControlProperty("EnablePaging").SetValue(_ctrl, value);
            }
        }

        public PersonFormat PersonFormat
        {
            get
            {
                return _ctrl.PersonFormat;
            }
            set
            {
                GetControlProperty("PersonFormat").SetValue(_ctrl, value);
            }
        }
        
        #endregion

    }
}