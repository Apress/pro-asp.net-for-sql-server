<%@ Page  MasterPageFile="~/MasterPage.master" Title="Product Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Product Detail</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="ProductID" EmptyDataText="The requested record was not found." DataSourceID="ProductsDataSource" ID="ProductsDetailsView"><Fields>
<asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ProductName" HeaderText="ProductName" InsertVisible="False"></asp:BoundField>
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
<asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" InsertVisible="False"></asp:BoundField>
<asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued"></asp:CheckBoxField>
<asp:BoundField DataField="AttributeXML" HeaderText="AttributeXML" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="DateCreated" HeaderText="DateCreated" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ProductGUID" HeaderText="ProductGUID" InsertVisible="False"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="ProductID," DataNavigateUrlFormatString="~/OrderDetails.aspx?Table=Product_OrderDetails&amp;OrderDetails_ProductID={0}" Text="View OrderDetails"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="ProductID," DataNavigateUrlFormatString="~/ProductCategoryMaps.aspx?Table=Product_ProductCategoryMaps&amp;ProductCategoryMaps_ProductID={0}" Text="View ProductCategoryMaps"></asp:HyperLinkField>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Product" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProduct" TypeName="Chapter08.BlinqNorthwindDAL.Product" UpdateMethod="Update" ID="ProductsDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="ProductID" Name="ProductID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
