<%@ Page  MasterPageFile="~/MasterPage.master" Title="Region Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Region Detail</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="RegionID" EmptyDataText="The requested record was not found." DataSourceID="RegionsDataSource" ID="RegionsDetailsView"><Fields>
<asp:BoundField DataField="RegionID" HeaderText="RegionID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="RegionDescription" HeaderText="RegionDescription" InsertVisible="False"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="RegionID," DataNavigateUrlFormatString="~/Territories.aspx?Table=Region_Territories&amp;Territories_RegionID={0}" Text="View Territories"></asp:HyperLinkField>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Region" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetRegion" TypeName="Chapter08.BlinqNorthwindDAL.Region" UpdateMethod="Update" ID="RegionsDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="RegionID" Name="RegionID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
