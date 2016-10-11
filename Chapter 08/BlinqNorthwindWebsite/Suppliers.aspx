<%@ Page  MasterPageFile="~/MasterPage.master" Title="Suppliers"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Suppliers</h1>
<asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="SupplierID" EmptyDataText="No records were returned." DataSourceID="SuppliersDataSource" ID="SuppliersGridView"><Columns>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
<asp:BoundField DataField="SupplierID" HeaderText="SupplierID" ReadOnly="True" InsertVisible="False" SortExpression="SupplierID"></asp:BoundField>
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
<asp:BoundField DataField="HomePage" HeaderText="HomePage" SortExpression="HomePage"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="SupplierID," DataNavigateUrlFormatString="~/Products.aspx?Table=Supplier_Products&amp;Products_SupplierID={0}" Text="View Products"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="SupplierID" DataNavigateUrlFormatString="~/SupplierDetail.aspx?SupplierID={0}" Text="View Details"></asp:HyperLinkField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Supplier" DeleteMethod="Delete" EnablePaging="True" OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetAllSuppliersCount" SelectMethod="GetAllSuppliers" SortParameterName="sortExpression" TypeName="Chapter08.BlinqNorthwindDAL.Supplier" UpdateMethod="Update" ID="SuppliersDataSource"></asp:ObjectDataSource>

        <div class="link">
        <asp:HyperLink runat="server" NavigateUrl="~/NewSupplier.aspx" CssClass="button" ID="NewRecordLink">Create New Supplier</asp:HyperLink>

        </div>    
    </div>
</asp:Content>
