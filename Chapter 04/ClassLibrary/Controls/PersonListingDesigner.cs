using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI.Design.WebControls;

namespace Chapter04.Controls
{
    public class PersonListingDesigner : DataBoundControlDesigner
    {
        DesignerActionListCollection actionLists = null;
        private PersonListingControl _ctrl;

        public override void Initialize(IComponent component)
        {
            _ctrl = component as PersonListingControl;
            base.Initialize(component);
        }

        public override string GetDesignTimeHtml()
        {
            string markup;

            string style = "style='background: LightSteelBlue; padding: 3px; border: 1px solid #999;'";
            string template = "<div " + style + ">{0}: {1}</div>{2}";

            try
            {
                string name = _ctrl.GetType().Name;
                string siteName = _ctrl.Site.Name;
                string content;
                if (_ctrl.PersonFormat == PersonFormat.SingleLine)
                {
                    content = "<p>Joe Smith, 10/11/1981, Chicago, USA</p>\n" +
                              "<p>Jane Smith, 10/11/1952, Tokyo, Japan</p>\n" +
                              "<p>Mike Johnson, 10/11/1962, Barcelona, Spain</p>\n";
                }
                else
                {
                    content = "<p>Joe Smith<br />\n10/11/1981<br />\nChicago, USA</p>\n" +
                              "<p>Jane Smith<br />\n10/11/1952<br />\nTokyo, Japan</p>\n" +
                              "<p>Mike Johnson<br />\n10/11/1962<br />\nBarcelona, Spain</p>\n";
                }
                markup = String.Format(template, name, siteName, content);
            }
            catch (Exception ex)
            {
                markup = "<p style='background: #ccc; color: #900; font-weight: bold;'>Error: " +
                         ex.Message + "</p>\n<div>" +
                         ex.StackTrace + "</div>";
            }

            return markup;
        }

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    foreach (DesignerActionList actionListItems in base.ActionLists)
                    {
                        actionLists.Add(actionListItems);
                    }
                    PersonListingControl ctrl = Component as PersonListingControl;
                    if (ctrl != null)
                    {
                        actionLists.Add(new PersonListingControlActionList(ctrl));
                    }
                }
                return actionLists;
            }
        }
    }
}