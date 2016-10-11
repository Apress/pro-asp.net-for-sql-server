<%@ Page Language="C#" MasterPageFile="~/Site.master" 
  AutoEventWireup="true" CodeFile="FormViewExample.aspx.cs" 
  Inherits="FormViewExample" Title="FormView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:FormView ID="FormView1" runat="server" 
      AllowPaging="True" DataKeyNames="PersonId"
        DataSourceID="ObjectDataSource1">
        <EditItemTemplate>
            PersonId:
            <asp:Label ID="PersonIdLabel1" runat="server" 
              Text='<%# Eval("PersonId") %>'></asp:Label><br />
            FirstName:
            <asp:TextBox ID="FirstNameTextBox" runat="server" 
              Text='<%# Bind("FirstName") %>'>
            </asp:TextBox><br />
            LastName:
            <asp:TextBox ID="LastNameTextBox" runat="server" 
              Text='<%# Bind("LastName") %>'>
            </asp:TextBox><br />
            BirthDate:
            <asp:TextBox ID="BirthDateTextBox" runat="server" 
              Text='<%# Bind("BirthDate") %>'>
            </asp:TextBox><br />
            City:
            <asp:TextBox ID="CityTextBox" runat="server" 
              Text='<%# Bind("City") %>'>
            </asp:TextBox><br />
            Country:
            <asp:TextBox ID="CountryTextBox" runat="server" 
              Text='<%# Bind("Country") %>'>
            </asp:TextBox><br />
            <asp:LinkButton ID="UpdateButton" runat="server" 
              CausesValidation="True" CommandName="Update" Text="Update">
            </asp:LinkButton>
            <asp:LinkButton ID="UpdateCancelButton" runat="server" 
              CausesValidation="False" CommandName="Cancel" Text="Cancel">
            </asp:LinkButton>
        </EditItemTemplate>
        <InsertItemTemplate>
            FirstName:
            <asp:TextBox ID="FirstNameTextBox" runat="server" 
              Text='<%# Bind("FirstName") %>'>
            </asp:TextBox><br />
            LastName:
            <asp:TextBox ID="LastNameTextBox" runat="server" 
              Text='<%# Bind("LastName") %>'>
            </asp:TextBox><br />
            BirthDate:
            <asp:TextBox ID="BirthDateTextBox" runat="server" 
              Text='<%# Bind("BirthDate") %>'>
            </asp:TextBox><br />
            City:
            <asp:TextBox ID="CityTextBox" runat="server" 
              Text='<%# Bind("City") %>'>
            </asp:TextBox><br />
            Country:
            <asp:TextBox ID="CountryTextBox" runat="server" 
              Text='<%# Bind("Country") %>'>
            </asp:TextBox><br />
            <asp:LinkButton ID="InsertButton" runat="server" 
              CausesValidation="True" CommandName="Insert" Text="Insert">
            </asp:LinkButton>
            <asp:LinkButton ID="InsertCancelButton" runat="server" 
              CausesValidation="False" CommandName="Cancel" Text="Cancel">
            </asp:LinkButton>
        </InsertItemTemplate>
        <ItemTemplate>
            FirstName:
            <asp:Label ID="FirstNameLabel" runat="server" 
              Text='<%# Bind("FirstName") %>'></asp:Label><br />
            LastName:
            <asp:Label ID="LastNameLabel" runat="server" 
              Text='<%# Bind("LastName") %>'></asp:Label><br />
            BirthDate:
            <asp:Label ID="BirthDateLabel" runat="server" 
              Text='<%# Bind("BirthDate") %>'></asp:Label><br />
            City:
            <asp:Label ID="CityLabel" runat="server" 
              Text='<%# Bind("City") %>'></asp:Label><br />
            Country:
            <asp:Label ID="CountryLabel" runat="server" 
              Text='<%# Bind("Country") %>'></asp:Label><br />
            <asp:LinkButton ID="EditButton" runat="server" 
              CausesValidation="False" CommandName="Edit" Text="Edit">
            </asp:LinkButton>
            <asp:LinkButton ID="DeleteButton" runat="server" 
              CausesValidation="False" CommandName="Delete" Text="Delete">
            </asp:LinkButton>
            <asp:LinkButton ID="NewButton" runat="server" 
              CausesValidation="False" CommandName="New" Text="New">
            </asp:LinkButton>
        </ItemTemplate>
    </asp:FormView>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        TypeName="Chapter04.Chapter04DomainTableAdapters.PeopleTableAdapter" SelectMethod="GetPeopleBySortedSubset" EnablePaging="True" 
        SelectCountMethod="GetAllPeopleRowCount" SortParameterName="sortExpression" DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
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
    <asp:FormView ID="FormView2" runat="server">
    </asp:FormView>
</asp:Content>

