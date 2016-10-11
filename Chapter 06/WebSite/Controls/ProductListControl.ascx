<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductListControl.ascx.cs" Inherits="Controls_ProductListControl" %>
<%@ Register Src="ProductPhoto.ascx" TagName="ProductPhoto" TagPrefix="uc1" %>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" 
    AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" PageSize="10">
    <Columns>
        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
        <asp:BoundField DataField="ProductNumber" HeaderText="Number" SortExpression="ProductNumber" />
        <asp:BoundField DataField="Color" HeaderText="Color" SortExpression="Color" />
        <asp:TemplateField>
        <HeaderTemplate>
        Image
        </HeaderTemplate>
        <ItemTemplate>
            <uc1:ProductPhoto ID="ProductPhoto1" runat="server" 
                Size="T" ProductID='<%# Bind("ProductID") %>' />
        </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAllProductsWithPhotos" 
    TypeName="Chapter05.ClassLibrary.Domain"></asp:ObjectDataSource>
