<%@ Page Language="C#" MasterPageFile="~/Site.master" 
  AutoEventWireup="true" CodeFile="DetailsViewExample.aspx.cs" 
  Inherits="DetailsViewExample" Title="DetailsView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:DetailsView ID="DetailsView1" runat="server" 
  DataSourceID="ObjectDataSource1" AllowPaging="True" 
  AutoGenerateRows="False" DataKeyNames="PersonId">
    <Fields>
        <asp:BoundField DataField="FirstName" 
          HeaderText="First Name" SortExpression="FirstName" />
        <asp:BoundField DataField="LastName" 
          HeaderText="Last Name" SortExpression="LastName" />
        <asp:BoundField DataField="BirthDate" 
          HeaderText="Birth Date" SortExpression="BirthDate" 
          DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="False" />
        <asp:BoundField DataField="City" 
          HeaderText="City" SortExpression="City" />
        <asp:BoundField DataField="Country" 
          HeaderText="Country" SortExpression="Country" />
        <asp:CommandField ShowDeleteButton="True" 
          ShowEditButton="True" ShowInsertButton="True" />
    </Fields>
</asp:DetailsView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}"
        TypeName="Chapter04.Chapter04DomainTableAdapters.PeopleTableAdapter" 
        SelectMethod="GetPeopleBySortedSubset" EnablePaging="True" 
        SelectCountMethod="GetAllPeopleRowCount" SortParameterName="sortExpression" 
        DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_PersonId" Type="Int64" />
            <asp:Parameter Name="Original_FirstName" Type="String" />
            <asp:Parameter Name="Original_LastName" Type="String" />
            <asp:Parameter Name="Original_BirthDate" Type="DateTime" />
            <asp:Parameter Name="Original_City" Type="String" />
            <asp:Parameter Name="Original_Country" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="BirthDate" Type="DateTime" />
            <asp:Parameter Name="City" Type="String" />
            <asp:Parameter Name="Country" Type="String" />
            <asp:Parameter Name="Original_PersonId" Type="Int64" />
            <asp:Parameter Name="Original_FirstName" Type="String" />
            <asp:Parameter Name="Original_LastName" Type="String" />
            <asp:Parameter Name="Original_BirthDate" Type="DateTime" />
            <asp:Parameter Name="Original_City" Type="String" />
            <asp:Parameter Name="Original_Country" Type="String" />
            <asp:Parameter Name="PersonId" Type="Int64" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="BirthDate" Type="DateTime" />
            <asp:Parameter Name="City" Type="String" />
            <asp:Parameter Name="Country" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
</asp:Content>
