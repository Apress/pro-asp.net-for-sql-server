<%@ Page  MasterPageFile="~/MasterPage.master" Title="New OrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>New OrderDetail</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="OrderID,ProductID" DefaultMode="Insert" EmptyDataText="The requested record was not found." PageIndex="-1" DataSourceID="OrderDetailsDataSource" ID="OrderDetailsDetailsView"><Fields>
<asp:TemplateField HeaderText="OrderID" SortExpression="OrderID"><InsertItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Order" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllOrders" TypeName="Chapter08.BlinqNorthwindDAL.Order" UpdateMethod="Update" ID="Order_OrderIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Order_OrderIDList" DataTextField="OrderID" DataValueField="OrderID" SelectedValue='<%# Bind("OrderID") %>' DataSourceID="Order_OrderIDDataSource" >
</asp:DropDownList>
</InsertItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ProductID" SortExpression="ProductID"><InsertItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Product" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllProducts" TypeName="Chapter08.BlinqNorthwindDAL.Product" UpdateMethod="Update" ID="Product_ProductIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Product_ProductIDList" DataTextField="ProductID" DataValueField="ProductID" SelectedValue='<%# Bind("ProductID") %>' DataSourceID="Product_ProductIDDataSource" >
</asp:DropDownList>
</InsertItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice"></asp:BoundField>
<asp:BoundField DataField="Quantity" HeaderText="Quantity"></asp:BoundField>
<asp:BoundField DataField="Discount" HeaderText="Discount"></asp:BoundField>
<asp:CommandField CancelText="Clear Values" ShowInsertButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.OrderDetail" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetOrderDetail" TypeName="Chapter08.BlinqNorthwindDAL.OrderDetail" UpdateMethod="Update" ID="OrderDetailsDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="OrderID" Name="OrderID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="ProductID" Name="ProductID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
