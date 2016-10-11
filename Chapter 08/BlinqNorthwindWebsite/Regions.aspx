<%@ Page  MasterPageFile="~/MasterPage.master" Title="Regions"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Regions</h1>
<asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="RegionID" EmptyDataText="No records were returned." DataSourceID="RegionsDataSource" ID="RegionsGridView"><Columns>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
<asp:BoundField DataField="RegionID" HeaderText="RegionID" ReadOnly="True" SortExpression="RegionID"></asp:BoundField>
<asp:BoundField DataField="RegionDescription" HeaderText="RegionDescription" SortExpression="RegionDescription"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="RegionID," DataNavigateUrlFormatString="~/Territories.aspx?Table=Region_Territories&amp;Territories_RegionID={0}" Text="View Territories"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="RegionID" DataNavigateUrlFormatString="~/RegionDetail.aspx?RegionID={0}" Text="View Details"></asp:HyperLinkField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Region" DeleteMethod="Delete" EnablePaging="True" OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetAllRegionsCount" SelectMethod="GetAllRegions" SortParameterName="sortExpression" TypeName="Chapter08.BlinqNorthwindDAL.Region" UpdateMethod="Update" ID="RegionsDataSource"></asp:ObjectDataSource>

        <div class="link">
        <asp:HyperLink runat="server" NavigateUrl="~/NewRegion.aspx" CssClass="button" ID="NewRecordLink">Create New Region</asp:HyperLink>

        </div>    
    </div>
</asp:Content>
