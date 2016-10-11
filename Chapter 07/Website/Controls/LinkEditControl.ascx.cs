using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Chapter07.Domain;
using Chapter07.Website;

public partial class Controls_LinkEditControl : UserControl, IValidator
{

    #region "  Events  "

    [Category("Action")]
    public event CancelEventHandler Saving;

    [Category("Action")]
    public event EventHandler Saved;

    protected virtual void OnSaving(CancelEventArgs e)
    {
        if (Saving != null)
        {
            Saving(this, e);
        }
    }

    protected virtual void OnSaved(EventArgs e)
    {
        if (Saved != null)
        {
            Saved(this, e);
        }
    }

    #endregion

    #region "  Event Handlers  "

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!String.IsNullOrEmpty(Url))
            {
                Profile profile = Utility.GetProfile();
                FavoriteLinkCollection lc = Utility.Domain.GetFavoriteLinkCollectionByUrl(profile.ProfileID, Url);
                // set the controls if a Favorite Link match is found
                if (lc.Count > 0)
                {
                    updateRow.Visible = true;
                    Chapter07.Domain.FavoriteLink lm = lc[0];
                    hdnOldFavoriteLinkId.Value = lc[0].ID.ToString();
                    tbTitle.Text = lm.Title;
                    tbTags.Text = lm.Tags;
                    tbNote.Text = lm.Note;
                    if (lm.Rating > 0)
                    {
                        rblRating.SelectedValue = lm.Rating.ToString();
                    }
                    cbKeeper.Checked = lm.Keeper;
                }
            }
            List<BaseValidator> validators = Utility.GetValidators(Controls);
            foreach (BaseValidator validator in validators)
            {
                validator.ValidationGroup = ValidationGroup;
            }
            ValidationSummary1.ValidationGroup = ValidationGroup;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            CancelEventArgs cea = new CancelEventArgs();
            OnSaving(cea);
            if (!cea.Cancel)
            {
                Profile profile = Utility.GetProfile();
                int rating;
                int.TryParse(rblRating.SelectedValue, out rating);
                long oldFavoriteLinkId;
                long.TryParse(hdnOldFavoriteLinkId.Value, out oldFavoriteLinkId);
                Utility.Domain.SaveFavoriteLink(profile.ProfileID,
                    tbUrl.Text.Trim(), tbTitle.Text.Trim(), cbKeeper.Checked, 
                    rating, tbNote.Text, tbTags.Text, oldFavoriteLinkId);
                OnSaved(EventArgs.Empty);
            }
        }
    }

    #endregion

    #region "  Control Properties  "

    [Bindable(true), Category("Favorite Link"), DefaultValue("")]
    public string Title
    {
        get { return tbTitle.Text; }
        set { tbTitle.Text = value; }
    }

    [Bindable(true), Category("Favorite Link"), DefaultValue("")]
    public string Url
    {
        get { return tbUrl.Text; }
        set { tbUrl.Text = value; }
    }

    [Bindable(true), Category("Favorite Link"), DefaultValue("")]
    public string Tags
    {
        get { return tbTags.Text; }
        set { tbTags.Text = value; }
    }

    [Bindable(true), Category("Favorite Link"), DefaultValue("")]
    public string Note
    {
        get { return tbNote.Text; }
        set { tbNote.Text = value; }
    }

    [Bindable(true), Category("Favorite Link"), DefaultValue(1)]
    public int Rating
    {
        get {
            int rating;
            int.TryParse(rblRating.SelectedValue, out rating);
            return rating;
        }
        set {
            if (value >= 0 && value <= 5)
            {
                rblRating.SelectedValue = value.ToString();
            }
        }
    }
    #endregion

    #region  "  Properties  "

    private string _validationGroup;
    public string ValidationGroup
    {
        get {
            if (String.IsNullOrEmpty(_validationGroup))
            {
                _validationGroup = ClientID;
            }
            return _validationGroup; 
        }
    }

    #endregion

    #region "  IValidator Implementation  "

    public void Validate()
    {
        EnsureChildControls();
        List<BaseValidator> validators = Utility.GetValidators(Controls);
        foreach (BaseValidator validator in validators)
        {
            validator.Validate();
        }
    }

    public bool IsValid
    {
        get
        {
            Validate();
            List<BaseValidator> validators = Utility.GetValidators(Controls);
            foreach (BaseValidator validator in validators)
            {
                if (!validator.IsValid)
                {
                    return false;
                }
            }
            return true;
        }
        set
        {
            // do nothing
        }
    }

    private string _errorMessage = "Form is not valid";
    public string ErrorMessage
    {
        get { return _errorMessage; }
        set { _errorMessage = value; }
    }

    #endregion

}
