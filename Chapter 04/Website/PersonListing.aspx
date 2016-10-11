<%@ Page Language="C#" MasterPageFile="~/Site.master" 
    AutoEventWireup="true" CodeFile="PersonListing.aspx.cs" 
    Inherits="PersonListing" Title="Person Listing"
    EnableViewState="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table><tr>
    <td style="vertical-align: top;">
        <chpt04:PersonListingControl 
            ID="plc1" runat="server" 
            DataSourceID="ObjectDataSource1" 
            PersonFormat="SingleLine" 
            EnablePaging="True" 
            PageSize="9" 
            EnableViewState="False" />
    </td>
    <td>&nbsp;</td>
    <td style="vertical-align: top;">
        <chpt04:PersonListingControl 
            ID="plc2" runat="server" 
            DataSourceID="ObjectDataSource1" 
            PersonFormat="MultiLine" 
            EnablePaging="True" 
            PageSize="3" 
            EnableViewState="True" />
    </td>
    </tr></table>
    <br />
    <asp:ObjectDataSource 
        ID="ObjectDataSource1" runat="server" 
        EnablePaging="True" 
        OldValuesParameterFormatString="original_{0}"
        SelectCountMethod="GetPeopleRowCount" 
        SelectMethod="GetAllPeopleDataSet" 
        TypeName="Chapter04.PersonDomain">
    </asp:ObjectDataSource>
    
<br /><br />
<asp:Button ID="btnPrev" runat="server" 
    Text="Previous" OnClick="btnPrev_Click" Visible="True" />
<asp:Button ID="btnNext" runat="server" 
    Text="Next" OnClick="btnNext_Click" Visible="True" />
<asp:Button ID="btnDoNothing" runat="server" 
    Text="Do Nothing" Visible="True" />
<br /><br />
<asp:Label ID="lblMessage" runat="server"></asp:Label>

</asp:Content>

