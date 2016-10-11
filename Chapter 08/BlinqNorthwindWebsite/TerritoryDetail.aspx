<%@ Page  MasterPageFile="~/MasterPage.master" Title="Territory Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Territory Detail</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="TerritoryID" EmptyDataText="The requested record was not found." DataSourceID="TerritoriesDataSource" ID="TerritoriesDetailsView"><Fields>
<asp:BoundField DataField="TerritoryID" HeaderText="TerritoryID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="TerritoryDescription" HeaderText="TerritoryDescription" InsertVisible="False"></asp:BoundField>
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
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Territory" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetTerritory" TypeName="Chapter08.BlinqNorthwindDAL.Territory" UpdateMethod="Update" ID="TerritoriesDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="TerritoryID" Name="TerritoryID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
