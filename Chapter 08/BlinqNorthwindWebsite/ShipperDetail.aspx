<%@ Page  MasterPageFile="~/MasterPage.master" Title="Shipper Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Shipper Detail</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="ShipperID" EmptyDataText="The requested record was not found." DataSourceID="ShippersDataSource" ID="ShippersDetailsView"><Fields>
<asp:BoundField DataField="ShipperID" HeaderText="ShipperID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="CompanyName" HeaderText="CompanyName" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Phone" HeaderText="Phone" InsertVisible="False"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="ShipperID," DataNavigateUrlFormatString="~/Orders.aspx?Table=Shipper_Orders&amp;Orders_ShipperID={0}" Text="View Orders"></asp:HyperLinkField>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Shipper" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetShipper" TypeName="Chapter08.BlinqNorthwindDAL.Shipper" UpdateMethod="Update" ID="ShippersDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="ShipperID" Name="ShipperID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
