<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DataReaderSortedSubSet.aspx.cs" Inherits="DataReaderSortedSubSet" Title="DataReader Sorted Subset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="PersonId" AllowSorting="True" AllowPaging="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
            <asp:BoundField DataField="BirthDate" HeaderText="Birth Date" SortExpression="BirthDate" />
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
            <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
        </Columns>
    </asp:GridView>  
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}"
        TypeName="Chapter03.PersonDomain" 
        SelectMethod="GetPeopleSubSetSortedReader" 
        SelectCountMethod="GetPeopleRowCount" 
        EnablePaging="True" 
        SortParameterName="sortExpression">
    </asp:ObjectDataSource>
</asp:Content>
