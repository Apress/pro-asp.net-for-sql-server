<%@ Page  MasterPageFile="~/MasterPage.master" Title="Customer Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Customer Detail</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="CustomerID" EmptyDataText="The requested record was not found." DataSourceID="CustomersDataSource" ID="CustomersDetailsView"><Fields>
<asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="CompanyName" HeaderText="CompanyName" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ContactName" HeaderText="ContactName" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ContactTitle" HeaderText="ContactTitle" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Address" HeaderText="Address" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="City" HeaderText="City" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Region" HeaderText="Region" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="PostalCode" HeaderText="PostalCode" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Country" HeaderText="Country" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Phone" HeaderText="Phone" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Fax" HeaderText="Fax" InsertVisible="False"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="CustomerID," DataNavigateUrlFormatString="~/CustomerCustomerDemos.aspx?Table=Customer_CustomerCustomerDemos&amp;CustomerCustomerDemos_CustomerID={0}" Text="View CustomerCustomerDemos"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="CustomerID," DataNavigateUrlFormatString="~/Orders.aspx?Table=Customer_Orders&amp;Orders_CustomerID={0}" Text="View Orders"></asp:HyperLinkField>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Customer" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCustomer" TypeName="Chapter08.BlinqNorthwindDAL.Customer" UpdateMethod="Update" ID="CustomersDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="CustomerID" Name="CustomerID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
