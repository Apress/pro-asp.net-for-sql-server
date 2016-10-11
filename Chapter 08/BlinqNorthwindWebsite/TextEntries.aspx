<%@ Page  MasterPageFile="~/MasterPage.master" Title="TextEntries"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>TextEntries</h1>
<asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ContentID" EmptyDataText="No records were returned." DataSourceID="TextEntriesDataSource" ID="TextEntriesGridView"><Columns>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
<asp:BoundField DataField="ContentID" HeaderText="ContentID" ReadOnly="True" InsertVisible="False" SortExpression="ContentID"></asp:BoundField>
<asp:BoundField DataField="ContentGUID" HeaderText="ContentGUID" SortExpression="ContentGUID"></asp:BoundField>
<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
<asp:BoundField DataField="ContentName" HeaderText="ContentName" SortExpression="ContentName"></asp:BoundField>
<asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content"></asp:BoundField>
<asp:BoundField DataField="IconPath" HeaderText="IconPath" SortExpression="IconPath"></asp:BoundField>
<asp:BoundField DataField="DateExpires" HeaderText="DateExpires" SortExpression="DateExpires"></asp:BoundField>
<asp:BoundField DataField="LastEditedBy" HeaderText="LastEditedBy" SortExpression="LastEditedBy"></asp:BoundField>
<asp:BoundField DataField="ExternalLink" HeaderText="ExternalLink" SortExpression="ExternalLink"></asp:BoundField>
<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
<asp:BoundField DataField="ListOrder" HeaderText="ListOrder" SortExpression="ListOrder"></asp:BoundField>
<asp:BoundField DataField="CallOut" HeaderText="CallOut" SortExpression="CallOut"></asp:BoundField>
<asp:BoundField DataField="CreatedOn" HeaderText="CreatedOn" SortExpression="CreatedOn"></asp:BoundField>
<asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy"></asp:BoundField>
<asp:BoundField DataField="ModifiedOn" HeaderText="ModifiedOn" SortExpression="ModifiedOn"></asp:BoundField>
<asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy" SortExpression="ModifiedBy"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="ContentID" DataNavigateUrlFormatString="~/TextEntryDetail.aspx?ContentID={0}" Text="View Details"></asp:HyperLinkField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.TextEntry" DeleteMethod="Delete" EnablePaging="True" OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetAllTextEntriesCount" SelectMethod="GetAllTextEntries" SortParameterName="sortExpression" TypeName="Chapter08.BlinqNorthwindDAL.TextEntry" UpdateMethod="Update" ID="TextEntriesDataSource"></asp:ObjectDataSource>

        <div class="link">
        <asp:HyperLink runat="server" NavigateUrl="~/NewTextEntry.aspx" CssClass="button" ID="NewRecordLink">Create New TextEntry</asp:HyperLink>

        </div>    
    </div>
</asp:Content>
