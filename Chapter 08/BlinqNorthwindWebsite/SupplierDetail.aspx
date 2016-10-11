<%@ Page  MasterPageFile="~/MasterPage.master" Title="Supplier Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Supplier Detail</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="SupplierID" EmptyDataText="The requested record was not found." DataSourceID="SuppliersDataSource" ID="SuppliersDetailsView"><Fields>
<asp:BoundField DataField="SupplierID" HeaderText="SupplierID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
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
<asp:BoundField DataField="HomePage" HeaderText="HomePage" InsertVisible="False"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="SupplierID," DataNavigateUrlFormatString="~/Products.aspx?Table=Supplier_Products&amp;Products_SupplierID={0}" Text="View Products"></asp:HyperLinkField>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Supplier" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetSupplier" TypeName="Chapter08.BlinqNorthwindDAL.Supplier" UpdateMethod="Update" ID="SuppliersDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="SupplierID" Name="SupplierID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
