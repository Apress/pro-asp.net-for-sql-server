<%@ Page  MasterPageFile="~/MasterPage.master" Title="New Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>New Category</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="CategoryID" DefaultMode="Insert" EmptyDataText="The requested record was not found." PageIndex="-1" DataSourceID="CategoriesDataSource" ID="CategoriesDetailsView"><Fields>
<asp:BoundField DataField="CategoryID" HeaderText="CategoryID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="CategoryName" HeaderText="CategoryName"></asp:BoundField>
<asp:BoundField DataField="Description" HeaderText="Description"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="CategoryID," DataNavigateUrlFormatString="~/ProductCategoryMaps.aspx?Table=Category_ProductCategoryMaps&amp;ProductCategoryMaps_CategoryID={0}" Text="View ProductCategoryMaps"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="CategoryID," DataNavigateUrlFormatString="~/Products.aspx?Table=Category_Products&amp;Products_CategoryID={0}" Text="View Products"></asp:HyperLinkField>
<asp:CommandField CancelText="Clear Values" ShowInsertButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Category" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCategory" TypeName="Chapter08.BlinqNorthwindDAL.Category" UpdateMethod="Update" ID="CategoriesDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="CategoryID" Name="CategoryID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
