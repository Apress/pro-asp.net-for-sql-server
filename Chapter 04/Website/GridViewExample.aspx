<%@ Page Language="C#" MasterPageFile="~/Site.master" 
  AutoEventWireup="true" CodeFile="GridViewExample.aspx.cs" 
  Inherits="GridViewExample" Title="GridView" %>
<asp:Content ID="Content1" 
  ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:GridView ID="GridView1" runat="server" 
        AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataKeyNames="PersonId" 
        DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:BoundField DataField="FirstName" 
              HeaderText="First Name" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" 
              HeaderText="Last Name" SortExpression="LastName" />
            <asp:TemplateField HeaderText="Birth Date" 
              SortExpression="BirthDate">
                <EditItemTemplate>
                    <chpt04:DateEditor 
                      ID="DateEditor1" runat="server" 
                      Date='<%# Bind("BirthDate") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" 
                      Text='<%# Bind("BirthDate", "{0:MM/dd/yyyy}") %>'>
                      </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="City" 
              HeaderText="City" SortExpression="City" />
            <asp:BoundField DataField="Country" 
              HeaderText="Country" SortExpression="Country" />
            <asp:CommandField 
              ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
       OldValuesParameterFormatString="original_{0}"
       TypeName="Chapter04.Chapter04DomainTableAdapters.PeopleTableAdapter" 
       SelectMethod="GetPeopleBySortedSubset" EnablePaging="True" 
       SelectCountMethod="GetAllPeopleRowCount" 
       SortParameterName="sortExpression" 
       DeleteMethod="Delete" 
       InsertMethod="Insert" 
       UpdateMethod="Update">
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

