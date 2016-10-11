<%@ Page  MasterPageFile="~/MasterPage.master" Title="TextEntry Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>TextEntry Detail</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="ContentID" EmptyDataText="The requested record was not found." DataSourceID="TextEntriesDataSource" ID="TextEntriesDetailsView"><Fields>
<asp:BoundField DataField="ContentID" HeaderText="ContentID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ContentGUID" HeaderText="ContentGUID" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Title" HeaderText="Title" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ContentName" HeaderText="ContentName" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Content" HeaderText="Content" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="IconPath" HeaderText="IconPath" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="DateExpires" HeaderText="DateExpires" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="LastEditedBy" HeaderText="LastEditedBy" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ExternalLink" HeaderText="ExternalLink" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Status" HeaderText="Status" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ListOrder" HeaderText="ListOrder" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="CallOut" HeaderText="CallOut" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="CreatedOn" HeaderText="CreatedOn" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ModifiedOn" HeaderText="ModifiedOn" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy" InsertVisible="False"></asp:BoundField>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.TextEntry" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetTextEntry" TypeName="Chapter08.BlinqNorthwindDAL.TextEntry" UpdateMethod="Update" ID="TextEntriesDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="ContentID" Name="ContentID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
