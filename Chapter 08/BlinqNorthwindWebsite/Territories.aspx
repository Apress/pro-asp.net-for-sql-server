<%@ Page  MasterPageFile="~/MasterPage.master" Title="Territories"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Territories</h1>
<asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="TerritoryID" EmptyDataText="No records were returned." DataSourceID="TerritoriesDataSource" ID="TerritoriesGridView"><Columns>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
<asp:BoundField DataField="TerritoryID" HeaderText="TerritoryID" ReadOnly="True" SortExpression="TerritoryID"></asp:BoundField>
<asp:BoundField DataField="TerritoryDescription" HeaderText="TerritoryDescription" SortExpression="TerritoryDescription"></asp:BoundField>
<asp:TemplateField HeaderText="RegionID" SortExpression="RegionID"><EditItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Region" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllRegions" TypeName="Chapter08.BlinqNorthwindDAL.Region" UpdateMethod="Update" ID="Region_RegionIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Region_RegionIDList" DataTextField="RegionID" DataValueField="RegionID" SelectedValue='<%# Bind("RegionID") %>' DataSourceID="Region_RegionIDDataSource" >
</asp:DropDownList>
</EditItemTemplate>
<ItemTemplate>
<asp:HyperLink ID="RegionIDLink" runat="server" Text='<%# Eval("RegionID") %>' NavigateUrl='<%# Eval("RegionID", "~/RegionDetail.aspx?RegionID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:HyperLinkField DataNavigateUrlFields="TerritoryID," DataNavigateUrlFormatString="~/EmployeeTerritories.aspx?Table=Territory_EmployeeTerritories&amp;EmployeeTerritories_TerritoryID={0}" Text="View EmployeeTerritories"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="TerritoryID" DataNavigateUrlFormatString="~/TerritoryDetail.aspx?TerritoryID={0}" Text="View Details"></asp:HyperLinkField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Territory" DeleteMethod="Delete" EnablePaging="True" OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetTerritoriesCount" SelectMethod="GetTerritories" SortParameterName="sortExpression" TypeName="Chapter08.BlinqNorthwindDAL.Territory" UpdateMethod="Update" ID="TerritoriesDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="Table" Name="tableName"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="Territories_RegionID" Name="Territories_RegionID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

        <div class="link">
        <asp:HyperLink runat="server" NavigateUrl="~/NewTerritory.aspx" CssClass="button" ID="NewRecordLink">Create New Territory</asp:HyperLink>

        </div>    
    </div>
</asp:Content>
