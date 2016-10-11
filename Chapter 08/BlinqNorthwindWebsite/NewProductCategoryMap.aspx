<%@ Page  MasterPageFile="~/MasterPage.master" Title="New ProductCategoryMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>New ProductCategoryMap</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="CategoryID,ProductID" DefaultMode="Insert" EmptyDataText="The requested record was not found." PageIndex="-1" DataSourceID="ProductCategoryMapsDataSource" ID="ProductCategoryMapsDetailsView"><Fields>
<asp:TemplateField HeaderText="CategoryID" SortExpression="CategoryID"><InsertItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Category" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllCategories" TypeName="Chapter08.BlinqNorthwindDAL.Category" UpdateMethod="Update" ID="Category_CategoryIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Category_CategoryIDList" DataTextField="CategoryID" DataValueField="CategoryID" SelectedValue='<%# Bind("CategoryID") %>' DataSourceID="Category_CategoryIDDataSource" >
</asp:DropDownList>
</InsertItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ProductID" SortExpression="ProductID"><InsertItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Product" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllProducts" TypeName="Chapter08.BlinqNorthwindDAL.Product" UpdateMethod="Update" ID="Product_ProductIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Product_ProductIDList" DataTextField="ProductID" DataValueField="ProductID" SelectedValue='<%# Bind("ProductID") %>' DataSourceID="Product_ProductIDDataSource" >
</asp:DropDownList>
</InsertItemTemplate>
</asp:TemplateField>
<asp:CommandField CancelText="Clear Values" ShowInsertButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.ProductCategoryMap" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductCategoryMap" TypeName="Chapter08.BlinqNorthwindDAL.ProductCategoryMap" UpdateMethod="Update" ID="ProductCategoryMapsDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="CategoryID" Name="CategoryID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="ProductID" Name="ProductID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
