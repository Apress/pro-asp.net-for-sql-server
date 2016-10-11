<%@ Page  MasterPageFile="~/MasterPage.master" Title="New Supplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>New Supplier</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="SupplierID" DefaultMode="Insert" EmptyDataText="The requested record was not found." PageIndex="-1" DataSourceID="SuppliersDataSource" ID="SuppliersDetailsView"><Fields>
<asp:BoundField DataField="SupplierID" HeaderText="SupplierID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="CompanyName" HeaderText="CompanyName"></asp:BoundField>
<asp:BoundField DataField="ContactName" HeaderText="ContactName"></asp:BoundField>
<asp:BoundField DataField="ContactTitle" HeaderText="ContactTitle"></asp:BoundField>
<asp:BoundField DataField="Address" HeaderText="Address"></asp:BoundField>
<asp:BoundField DataField="City" HeaderText="City"></asp:BoundField>
<asp:BoundField DataField="Region" HeaderText="Region"></asp:BoundField>
<asp:BoundField DataField="PostalCode" HeaderText="PostalCode"></asp:BoundField>
<asp:BoundField DataField="Country" HeaderText="Country"></asp:BoundField>
<asp:BoundField DataField="Phone" HeaderText="Phone"></asp:BoundField>
<asp:BoundField DataField="Fax" HeaderText="Fax"></asp:BoundField>
<asp:BoundField DataField="HomePage" HeaderText="HomePage"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="SupplierID," DataNavigateUrlFormatString="~/Products.aspx?Table=Supplier_Products&amp;Products_SupplierID={0}" Text="View Products"></asp:HyperLinkField>
<asp:CommandField CancelText="Clear Values" ShowInsertButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Supplier" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetSupplier" TypeName="Chapter08.BlinqNorthwindDAL.Supplier" UpdateMethod="Update" ID="SuppliersDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="SupplierID" Name="SupplierID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
