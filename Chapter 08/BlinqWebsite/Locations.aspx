<%@ Page  MasterPageFile="~/MasterPage.master" Title="Locations"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Locations</h1>
<asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" EmptyDataText="No records were returned." DataSourceID="LocationsDataSource" ID="LocationsGridView"><Columns>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
<asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
<asp:BoundField DataField="City" HeaderText="City" SortExpression="City"></asp:BoundField>
<asp:BoundField DataField="State" HeaderText="State" SortExpression="State"></asp:BoundField>
<asp:BoundField DataField="Creation" HeaderText="Creation" SortExpression="Creation"></asp:BoundField>
<asp:BoundField DataField="Modified" HeaderText="Modified" SortExpression="Modified"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="ID," DataNavigateUrlFormatString="~/Persons.aspx?Table=Location_Persons&amp;Persons_ID={0}" Text="View Persons"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/LocationDetail.aspx?ID={0}" Text="View Details"></asp:HyperLinkField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqDAL.Location" DeleteMethod="Delete" EnablePaging="True" OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetAllLocationsCount" SelectMethod="GetAllLocations" SortParameterName="sortExpression" TypeName="Chapter08.BlinqDAL.Location" UpdateMethod="Update" ID="LocationsDataSource"></asp:ObjectDataSource>

        <div class="link">
        <asp:HyperLink runat="server" NavigateUrl="~/NewLocation.aspx" CssClass="button" ID="NewRecordLink">Create New Location</asp:HyperLink>

        </div>    
    </div>
</asp:Content>
