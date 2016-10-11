<%@ Page  MasterPageFile="~/MasterPage.master" Title="Products"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Products</h1>
<asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ProductID" EmptyDataText="No records were returned." DataSourceID="ProductsDataSource" ID="ProductsGridView"><Columns>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
<asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" InsertVisible="False" SortExpression="ProductID"></asp:BoundField>
<asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName"></asp:BoundField>
<asp:TemplateField HeaderText="SupplierID" SortExpression="SupplierID"><EditItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Supplier" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllSuppliers" TypeName="Chapter08.BlinqNorthwindDAL.Supplier" UpdateMethod="Update" ID="Supplier_SupplierIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Supplier_SupplierIDList" DataTextField="SupplierID" DataValueField="SupplierID" SelectedValue='<%# Bind("SupplierID") %>' DataSourceID="Supplier_SupplierIDDataSource" AppendDataBoundItems="true" >
<asp:ListItem Text="<null>" Value="" />
</asp:DropDownList>
</EditItemTemplate>
<ItemTemplate>
<asp:HyperLink ID="SupplierIDLink" runat="server" Text='<%# Eval("SupplierID") %>' NavigateUrl='<%# Eval("SupplierID", "~/SupplierDetail.aspx?SupplierID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="CategoryID" SortExpression="CategoryID"><EditItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Category" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllCategories" TypeName="Chapter08.BlinqNorthwindDAL.Category" UpdateMethod="Update" ID="Category_CategoryIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Category_CategoryIDList" DataTextField="CategoryID" DataValueField="CategoryID" SelectedValue='<%# Bind("CategoryID") %>' DataSourceID="Category_CategoryIDDataSource" AppendDataBoundItems="true" >
<asp:ListItem Text="<null>" Value="" />
</asp:DropDownList>
</EditItemTemplate>
<ItemTemplate>
<asp:HyperLink ID="CategoryIDLink" runat="server" Text='<%# Eval("CategoryID") %>' NavigateUrl='<%# Eval("CategoryID", "~/CategoryDetail.aspx?CategoryID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" SortExpression="QuantityPerUnit"></asp:BoundField>
<asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice"></asp:BoundField>
<asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="UnitsInStock"></asp:BoundField>
<asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" SortExpression="UnitsOnOrder"></asp:BoundField>
<asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" SortExpression="ReorderLevel"></asp:BoundField>
<asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued"></asp:CheckBoxField>
<asp:BoundField DataField="AttributeXML" HeaderText="AttributeXML" SortExpression="AttributeXML"></asp:BoundField>
<asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated"></asp:BoundField>
<asp:BoundField DataField="ProductGUID" HeaderText="ProductGUID" SortExpression="ProductGUID"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="ProductID," DataNavigateUrlFormatString="~/OrderDetails.aspx?Table=Product_OrderDetails&amp;OrderDetails_ProductID={0}" Text="View OrderDetails"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="ProductID," DataNavigateUrlFormatString="~/ProductCategoryMaps.aspx?Table=Product_ProductCategoryMaps&amp;ProductCategoryMaps_ProductID={0}" Text="View ProductCategoryMaps"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="ProductID" DataNavigateUrlFormatString="~/ProductDetail.aspx?ProductID={0}" Text="View Details"></asp:HyperLinkField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Product" DeleteMethod="Delete" EnablePaging="True" OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetProductsCount" SelectMethod="GetProducts" SortParameterName="sortExpression" TypeName="Chapter08.BlinqNorthwindDAL.Product" UpdateMethod="Update" ID="ProductsDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="Table" Name="tableName"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="Products_CategoryID" Name="Products_CategoryID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="Products_SupplierID" Name="Products_SupplierID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

        <div class="link">
        <asp:HyperLink runat="server" NavigateUrl="~/NewProduct.aspx" CssClass="button" ID="NewRecordLink">Create New Product</asp:HyperLink>

        </div>    
    </div>
</asp:Content>
