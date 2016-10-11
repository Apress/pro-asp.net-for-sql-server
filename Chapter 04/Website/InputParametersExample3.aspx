<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="InputParametersExample3.aspx.cs"
    Inherits="InputParametersExample3" Title="Input Parameter Example 3" %>

<%@ Register Src="Controls/PersonListingControl.ascx" TagName="PersonListingControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <b>Select Last Name: </b>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
        DataTextField="LastName" OnDataBound="DropDownList1_DataBound" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList><br />
    <uc1:PersonListingControl ID="PersonListingControl1" runat="server" />
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetLastNames" TypeName="Chapter04.PersonDomain"></asp:ObjectDataSource>
</asp:Content>
