<%@ Page  MasterPageFile="~/MasterPage.master" Title="New Territory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>New Territory</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="TerritoryID" DefaultMode="Insert" EmptyDataText="The requested record was not found." PageIndex="-1" DataSourceID="TerritoriesDataSource" ID="TerritoriesDetailsView"><Fields>
<asp:BoundField DataField="TerritoryID" HeaderText="TerritoryID" ReadOnly="True"></asp:BoundField>
<asp:BoundField DataField="TerritoryDescription" HeaderText="TerritoryDescription"></asp:BoundField>
<asp:TemplateField HeaderText="RegionID" SortExpression="RegionID"><InsertItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Region" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllRegions" TypeName="Chapter08.BlinqNorthwindDAL.Region" UpdateMethod="Update" ID="Region_RegionIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Region_RegionIDList" DataTextField="RegionID" DataValueField="RegionID" SelectedValue='<%# Bind("RegionID") %>' DataSourceID="Region_RegionIDDataSource" >
</asp:DropDownList>
</InsertItemTemplate>
</asp:TemplateField>
<asp:HyperLinkField DataNavigateUrlFields="TerritoryID," DataNavigateUrlFormatString="~/EmployeeTerritories.aspx?Table=Territory_EmployeeTerritories&amp;EmployeeTerritories_TerritoryID={0}" Text="View EmployeeTerritories"></asp:HyperLinkField>
<asp:CommandField CancelText="Clear Values" ShowInsertButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Territory" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetTerritory" TypeName="Chapter08.BlinqNorthwindDAL.Territory" UpdateMethod="Update" ID="TerritoriesDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="TerritoryID" Name="TerritoryID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
