<%@ Page  MasterPageFile="~/MasterPage.master" Title="Categories"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Categories</h1>
<asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="CategoryID" EmptyDataText="No records were returned." DataSourceID="CategoriesDataSource" ID="CategoriesGridView"><Columns>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
<asp:BoundField DataField="CategoryID" HeaderText="CategoryID" ReadOnly="True" InsertVisible="False" SortExpression="CategoryID"></asp:BoundField>
<asp:BoundField DataField="CategoryName" HeaderText="CategoryName" SortExpression="CategoryName"></asp:BoundField>
<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="CategoryID," DataNavigateUrlFormatString="~/ProductCategoryMaps.aspx?Table=Category_ProductCategoryMaps&amp;ProductCategoryMaps_CategoryID={0}" Text="View ProductCategoryMaps"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="CategoryID," DataNavigateUrlFormatString="~/Products.aspx?Table=Category_Products&amp;Products_CategoryID={0}" Text="View Products"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="CategoryID" DataNavigateUrlFormatString="~/CategoryDetail.aspx?CategoryID={0}" Text="View Details"></asp:HyperLinkField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Category" DeleteMethod="Delete" EnablePaging="True" OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetAllCategoriesCount" SelectMethod="GetAllCategories" SortParameterName="sortExpression" TypeName="Chapter08.BlinqNorthwindDAL.Category" UpdateMethod="Update" ID="CategoriesDataSource"></asp:ObjectDataSource>

        <div class="link">
        <asp:HyperLink runat="server" NavigateUrl="~/NewCategory.aspx" CssClass="button" ID="NewRecordLink">Create New Category</asp:HyperLink>

        </div>    
    </div>
</asp:Content>
