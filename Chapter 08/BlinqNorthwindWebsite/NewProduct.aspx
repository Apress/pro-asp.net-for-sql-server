<%@ Page  MasterPageFile="~/MasterPage.master" Title="New Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>New Product</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="ProductID" DefaultMode="Insert" EmptyDataText="The requested record was not found." PageIndex="-1" DataSourceID="ProductsDataSource" ID="ProductsDetailsView"><Fields>
<asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ProductName" HeaderText="ProductName"></asp:BoundField>
<asp:TemplateField HeaderText="SupplierID" SortExpression="SupplierID"><InsertItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Supplier" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllSuppliers" TypeName="Chapter08.BlinqNorthwindDAL.Supplier" UpdateMethod="Update" ID="Supplier_SupplierIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Supplier_SupplierIDList" DataTextField="SupplierID" DataValueField="SupplierID" SelectedValue='<%# Bind("SupplierID") %>' DataSourceID="Supplier_SupplierIDDataSource" AppendDataBoundItems="true" >
<asp:ListItem Text="<null>" Value="" />
</asp:DropDownList>
</InsertItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="CategoryID" SortExpression="CategoryID"><InsertItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Category" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllCategories" TypeName="Chapter08.BlinqNorthwindDAL.Category" UpdateMethod="Update" ID="Category_CategoryIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Category_CategoryIDList" DataTextField="CategoryID" DataValueField="CategoryID" SelectedValue='<%# Bind("CategoryID") %>' DataSourceID="Category_CategoryIDDataSource" AppendDataBoundItems="true" >
<asp:ListItem Text="<null>" Value="" />
</asp:DropDownList>
</InsertItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit"></asp:BoundField>
<asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice"></asp:BoundField>
<asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock"></asp:BoundField>
<asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder"></asp:BoundField>
<asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel"></asp:BoundField>
<asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued"></asp:CheckBoxField>
<asp:BoundField DataField="AttributeXML" HeaderText="AttributeXML"></asp:BoundField>
<asp:BoundField DataField="DateCreated" HeaderText="DateCreated"></asp:BoundField>
<asp:BoundField DataField="ProductGUID" HeaderText="ProductGUID"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="ProductID," DataNavigateUrlFormatString="~/OrderDetails.aspx?Table=Product_OrderDetails&amp;OrderDetails_ProductID={0}" Text="View OrderDetails"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="ProductID," DataNavigateUrlFormatString="~/ProductCategoryMaps.aspx?Table=Product_ProductCategoryMaps&amp;ProductCategoryMaps_ProductID={0}" Text="View ProductCategoryMaps"></asp:HyperLinkField>
<asp:CommandField CancelText="Clear Values" ShowInsertButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Product" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProduct" TypeName="Chapter08.BlinqNorthwindDAL.Product" UpdateMethod="Update" ID="ProductsDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="ProductID" Name="ProductID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
