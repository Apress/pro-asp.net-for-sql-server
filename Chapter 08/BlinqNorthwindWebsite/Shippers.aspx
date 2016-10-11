<%@ Page  MasterPageFile="~/MasterPage.master" Title="Shippers"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Shippers</h1>
<asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ShipperID" EmptyDataText="No records were returned." DataSourceID="ShippersDataSource" ID="ShippersGridView"><Columns>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
<asp:BoundField DataField="ShipperID" HeaderText="ShipperID" ReadOnly="True" InsertVisible="False" SortExpression="ShipperID"></asp:BoundField>
<asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName"></asp:BoundField>
<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="ShipperID," DataNavigateUrlFormatString="~/Orders.aspx?Table=Shipper_Orders&amp;Orders_ShipperID={0}" Text="View Orders"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="ShipperID" DataNavigateUrlFormatString="~/ShipperDetail.aspx?ShipperID={0}" Text="View Details"></asp:HyperLinkField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Shipper" DeleteMethod="Delete" EnablePaging="True" OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetAllShippersCount" SelectMethod="GetAllShippers" SortParameterName="sortExpression" TypeName="Chapter08.BlinqNorthwindDAL.Shipper" UpdateMethod="Update" ID="ShippersDataSource"></asp:ObjectDataSource>

        <div class="link">
        <asp:HyperLink runat="server" NavigateUrl="~/NewShipper.aspx" CssClass="button" ID="NewRecordLink">Create New Shipper</asp:HyperLink>

        </div>    
    </div>
</asp:Content>
