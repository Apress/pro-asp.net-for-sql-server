<%@ Page Language="C#" MasterPageFile="~/Site.master" 
  AutoEventWireup="true" CodeFile="TrivialExample.aspx.cs" 
  Inherits="TrivialExample" Title="Trivial Example" %>
<asp:Content 
  ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView 
      ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
        EmptyDataText="There are no data records to display.">
        <EmptyDataTemplate>
            <strong>No Data</strong>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:chpt02 %>"
        ProviderName="<%$ ConnectionStrings:chpt02.ProviderName %>" 
        DeleteCommand="DELETE FROM [chpt02_Person] WHERE [PersonId] = @PersonId" 
        InsertCommand="INSERT INTO [chpt02_Person] ([FirstName], [LastName], [BirthDate], [LocationId]) VALUES (@FirstName, @LastName, @BirthDate, @LocationId)"
        SelectCommand="SELECT [PersonId], [FirstName], [LastName], [BirthDate], [LocationId] FROM [chpt02_Person]"
        UpdateCommand="UPDATE [chpt02_Person] SET [FirstName] = @FirstName, [LastName] = @LastName, [BirthDate] = @BirthDate, [LocationId] = @LocationId WHERE [PersonId] = @PersonId">
        <InsertParameters>
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="BirthDate" Type="DateTime" />
            <asp:Parameter Name="LocationId" Type="Int64" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="BirthDate" Type="DateTime" />
            <asp:Parameter Name="LocationId" Type="Int64" />
            <asp:Parameter Name="PersonId" Type="Int64" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="PersonId" Type="Int64" />
        </DeleteParameters>
    </asp:SqlDataSource>
</asp:Content>

