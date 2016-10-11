<%@ Page  MasterPageFile="~/MasterPage.master" Title="Order Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Order Detail</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="OrderID" EmptyDataText="The requested record was not found." DataSourceID="OrdersDataSource" ID="OrdersDetailsView"><Fields>
<asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
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
<asp:BoundField DataField="OrderDate" HeaderText="OrderDate" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="RequiredDate" HeaderText="RequiredDate" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate" InsertVisible="False"></asp:BoundField>
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
<asp:BoundField DataField="Freight" HeaderText="Freight" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ShipName" HeaderText="ShipName" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ShipAddress" HeaderText="ShipAddress" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ShipCity" HeaderText="ShipCity" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ShipRegion" HeaderText="ShipRegion" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ShipPostalCode" HeaderText="ShipPostalCode" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry" InsertVisible="False"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="OrderID," DataNavigateUrlFormatString="~/OrderDetails.aspx?Table=Order_OrderDetails&amp;OrderDetails_OrderID={0}" Text="View OrderDetails"></asp:HyperLinkField>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Order" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetOrder" TypeName="Chapter08.BlinqNorthwindDAL.Order" UpdateMethod="Update" ID="OrdersDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="OrderID" Name="OrderID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
