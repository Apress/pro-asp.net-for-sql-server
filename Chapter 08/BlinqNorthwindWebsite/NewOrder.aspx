<%@ Page  MasterPageFile="~/MasterPage.master" Title="New Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>New Order</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="OrderID" DefaultMode="Insert" EmptyDataText="The requested record was not found." PageIndex="-1" DataSourceID="OrdersDataSource" ID="OrdersDetailsView"><Fields>
<asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
<asp:TemplateField HeaderText="CustomerID" SortExpression="CustomerID"><InsertItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Customer" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllCustomers" TypeName="Chapter08.BlinqNorthwindDAL.Customer" UpdateMethod="Update" ID="Customer_CustomerIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Customer_CustomerIDList" DataTextField="CustomerID" DataValueField="CustomerID" SelectedValue='<%# Bind("CustomerID") %>' DataSourceID="Customer_CustomerIDDataSource" AppendDataBoundItems="true" >
<asp:ListItem Text="<null>" Value="" />
</asp:DropDownList>
</InsertItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EmployeeID" SortExpression="EmployeeID"><InsertItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Employee" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllEmployees" TypeName="Chapter08.BlinqNorthwindDAL.Employee" UpdateMethod="Update" ID="Employee_EmployeeIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Employee_EmployeeIDList" DataTextField="EmployeeID" DataValueField="EmployeeID" SelectedValue='<%# Bind("EmployeeID") %>' DataSourceID="Employee_EmployeeIDDataSource" AppendDataBoundItems="true" >
<asp:ListItem Text="<null>" Value="" />
</asp:DropDownList>
</InsertItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="OrderDate" HeaderText="OrderDate"></asp:BoundField>
<asp:BoundField DataField="RequiredDate" HeaderText="RequiredDate"></asp:BoundField>
<asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate"></asp:BoundField>
<asp:TemplateField HeaderText="ShipVia" SortExpression="ShipVia"><InsertItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Shipper" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllShippers" TypeName="Chapter08.BlinqNorthwindDAL.Shipper" UpdateMethod="Update" ID="Shipper_ShipViaDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Shipper_ShipViaList" DataTextField="ShipperID" DataValueField="ShipperID" SelectedValue='<%# Bind("ShipVia") %>' DataSourceID="Shipper_ShipViaDataSource" AppendDataBoundItems="true" >
<asp:ListItem Text="<null>" Value="" />
</asp:DropDownList>
</InsertItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Freight" HeaderText="Freight"></asp:BoundField>
<asp:BoundField DataField="ShipName" HeaderText="ShipName"></asp:BoundField>
<asp:BoundField DataField="ShipAddress" HeaderText="ShipAddress"></asp:BoundField>
<asp:BoundField DataField="ShipCity" HeaderText="ShipCity"></asp:BoundField>
<asp:BoundField DataField="ShipRegion" HeaderText="ShipRegion"></asp:BoundField>
<asp:BoundField DataField="ShipPostalCode" HeaderText="ShipPostalCode"></asp:BoundField>
<asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="OrderID," DataNavigateUrlFormatString="~/OrderDetails.aspx?Table=Order_OrderDetails&amp;OrderDetails_OrderID={0}" Text="View OrderDetails"></asp:HyperLinkField>
<asp:CommandField CancelText="Clear Values" ShowInsertButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Order" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetOrder" TypeName="Chapter08.BlinqNorthwindDAL.Order" UpdateMethod="Update" ID="OrdersDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="OrderID" Name="OrderID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
