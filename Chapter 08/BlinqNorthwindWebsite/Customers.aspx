<%@ Page  MasterPageFile="~/MasterPage.master" Title="Customers"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Customers</h1>
<asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="CustomerID" EmptyDataText="No records were returned." DataSourceID="CustomersDataSource" ID="CustomersGridView"><Columns>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
<asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ReadOnly="True" SortExpression="CustomerID"></asp:BoundField>
<asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName"></asp:BoundField>
<asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName"></asp:BoundField>
<asp:BoundField DataField="ContactTitle" HeaderText="ContactTitle" SortExpression="ContactTitle"></asp:BoundField>
<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address"></asp:BoundField>
<asp:BoundField DataField="City" HeaderText="City" SortExpression="City"></asp:BoundField>
<asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region"></asp:BoundField>
<asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode"></asp:BoundField>
<asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country"></asp:BoundField>
<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone"></asp:BoundField>
<asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="CustomerID," DataNavigateUrlFormatString="~/CustomerCustomerDemos.aspx?Table=Customer_CustomerCustomerDemos&amp;CustomerCustomerDemos_CustomerID={0}" Text="View CustomerCustomerDemos"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="CustomerID," DataNavigateUrlFormatString="~/Orders.aspx?Table=Customer_Orders&amp;Orders_CustomerID={0}" Text="View Orders"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="CustomerID" DataNavigateUrlFormatString="~/CustomerDetail.aspx?CustomerID={0}" Text="View Details"></asp:HyperLinkField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Customer" DeleteMethod="Delete" EnablePaging="True" OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetAllCustomersCount" SelectMethod="GetAllCustomers" SortParameterName="sortExpression" TypeName="Chapter08.BlinqNorthwindDAL.Customer" UpdateMethod="Update" ID="CustomersDataSource"></asp:ObjectDataSource>

        <div class="link">
        <asp:HyperLink runat="server" NavigateUrl="~/NewCustomer.aspx" CssClass="button" ID="NewRecordLink">Create New Customer</asp:HyperLink>

        </div>    
    </div>
</asp:Content>
