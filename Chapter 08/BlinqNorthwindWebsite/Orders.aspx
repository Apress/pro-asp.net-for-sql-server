<%@ Page  MasterPageFile="~/MasterPage.master" Title="Orders"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Orders</h1>
<asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="OrderID" EmptyDataText="No records were returned." DataSourceID="OrdersDataSource" ID="OrdersGridView"><Columns>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
<asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" InsertVisible="False" SortExpression="OrderID"></asp:BoundField>
<asp:TemplateField HeaderText="CustomerID" SortExpression="CustomerID"><EditItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Customer" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllCustomers" TypeName="Chapter08.BlinqNorthwindDAL.Customer" UpdateMethod="Update" ID="Customer_CustomerIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Customer_CustomerIDList" DataTextField="CustomerID" DataValueField="CustomerID" SelectedValue='<%# Bind("CustomerID") %>' DataSourceID="Customer_CustomerIDDataSource" AppendDataBoundItems="true" >
<asp:ListItem Text="<null>" Value="" />
</asp:DropDownList>
</EditItemTemplate>
<ItemTemplate>
<asp:HyperLink ID="CustomerIDLink" runat="server" Text='<%# Eval("CustomerID") %>' NavigateUrl='<%# Eval("CustomerID", "~/CustomerDetail.aspx?CustomerID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EmployeeID" SortExpression="EmployeeID"><EditItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Employee" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllEmployees" TypeName="Chapter08.BlinqNorthwindDAL.Employee" UpdateMethod="Update" ID="Employee_EmployeeIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Employee_EmployeeIDList" DataTextField="EmployeeID" DataValueField="EmployeeID" SelectedValue='<%# Bind("EmployeeID") %>' DataSourceID="Employee_EmployeeIDDataSource" AppendDataBoundItems="true" >
<asp:ListItem Text="<null>" Value="" />
</asp:DropDownList>
</EditItemTemplate>
<ItemTemplate>
<asp:HyperLink ID="EmployeeIDLink" runat="server" Text='<%# Eval("EmployeeID") %>' NavigateUrl='<%# Eval("EmployeeID", "~/EmployeeDetail.aspx?EmployeeID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate"></asp:BoundField>
<asp:BoundField DataField="RequiredDate" HeaderText="RequiredDate" SortExpression="RequiredDate"></asp:BoundField>
<asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate" SortExpression="ShippedDate"></asp:BoundField>
<asp:TemplateField HeaderText="ShipVia" SortExpression="ShipVia"><EditItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Shipper" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllShippers" TypeName="Chapter08.BlinqNorthwindDAL.Shipper" UpdateMethod="Update" ID="Shipper_ShipViaDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Shipper_ShipViaList" DataTextField="ShipperID" DataValueField="ShipperID" SelectedValue='<%# Bind("ShipVia") %>' DataSourceID="Shipper_ShipViaDataSource" AppendDataBoundItems="true" >
<asp:ListItem Text="<null>" Value="" />
</asp:DropDownList>
</EditItemTemplate>
<ItemTemplate>
<asp:HyperLink ID="ShipViaLink" runat="server" Text='<%# Eval("ShipVia") %>' NavigateUrl='<%# Eval("ShipVia", "~/ShipperDetail.aspx?ShipperID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Freight" HeaderText="Freight" SortExpression="Freight"></asp:BoundField>
<asp:BoundField DataField="ShipName" HeaderText="ShipName" SortExpression="ShipName"></asp:BoundField>
<asp:BoundField DataField="ShipAddress" HeaderText="ShipAddress" SortExpression="ShipAddress"></asp:BoundField>
<asp:BoundField DataField="ShipCity" HeaderText="ShipCity" SortExpression="ShipCity"></asp:BoundField>
<asp:BoundField DataField="ShipRegion" HeaderText="ShipRegion" SortExpression="ShipRegion"></asp:BoundField>
<asp:BoundField DataField="ShipPostalCode" HeaderText="ShipPostalCode" SortExpression="ShipPostalCode"></asp:BoundField>
<asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry" SortExpression="ShipCountry"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="OrderID," DataNavigateUrlFormatString="~/OrderDetails.aspx?Table=Order_OrderDetails&amp;OrderDetails_OrderID={0}" Text="View OrderDetails"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="OrderID" DataNavigateUrlFormatString="~/OrderDetail.aspx?OrderID={0}" Text="View Details"></asp:HyperLinkField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Order" DeleteMethod="Delete" EnablePaging="True" OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetOrdersCount" SelectMethod="GetOrders" SortParameterName="sortExpression" TypeName="Chapter08.BlinqNorthwindDAL.Order" UpdateMethod="Update" ID="OrdersDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="Table" Name="tableName"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="Orders_ShipperID" Name="Orders_ShipperID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="Orders_EmployeeID" Name="Orders_EmployeeID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="Orders_CustomerID" Name="Orders_CustomerID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

        <div class="link">
        <asp:HyperLink runat="server" NavigateUrl="~/NewOrder.aspx" CssClass="button" ID="NewRecordLink">Create New Order</asp:HyperLink>

        </div>    
    </div>
</asp:Content>
