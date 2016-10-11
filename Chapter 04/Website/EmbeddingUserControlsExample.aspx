<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EmbeddingUserControlsExample.aspx.cs"
    Inherits="EmbeddingUserControlsExample" Title="Embedding User Controls Example" %>

<%@ Register Src="Controls/CountryListingControl.ascx" TagName="CountryListingControl"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:CountryListingControl id="CountryListingControl1" runat="server">
    </uc1:CountryListingControl>
</asp:Content>
