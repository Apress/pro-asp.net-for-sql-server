<%@ Page  MasterPageFile="~/MasterPage.master" Title="New TextEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>New TextEntry</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="ContentID" DefaultMode="Insert" EmptyDataText="The requested record was not found." PageIndex="-1" DataSourceID="TextEntriesDataSource" ID="TextEntriesDetailsView"><Fields>
<asp:BoundField DataField="ContentID" HeaderText="ContentID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="ContentGUID" HeaderText="ContentGUID"></asp:BoundField>
<asp:BoundField DataField="Title" HeaderText="Title"></asp:BoundField>
<asp:BoundField DataField="ContentName" HeaderText="ContentName"></asp:BoundField>
<asp:BoundField DataField="Content" HeaderText="Content"></asp:BoundField>
<asp:BoundField DataField="IconPath" HeaderText="IconPath"></asp:BoundField>
<asp:BoundField DataField="DateExpires" HeaderText="DateExpires"></asp:BoundField>
<asp:BoundField DataField="LastEditedBy" HeaderText="LastEditedBy"></asp:BoundField>
<asp:BoundField DataField="ExternalLink" HeaderText="ExternalLink"></asp:BoundField>
<asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
<asp:BoundField DataField="ListOrder" HeaderText="ListOrder"></asp:BoundField>
<asp:BoundField DataField="CallOut" HeaderText="CallOut"></asp:BoundField>
<asp:BoundField DataField="CreatedOn" HeaderText="CreatedOn"></asp:BoundField>
<asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy"></asp:BoundField>
<asp:BoundField DataField="ModifiedOn" HeaderText="ModifiedOn"></asp:BoundField>
<asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy"></asp:BoundField>
<asp:CommandField CancelText="Clear Values" ShowInsertButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.TextEntry" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetTextEntry" TypeName="Chapter08.BlinqNorthwindDAL.TextEntry" UpdateMethod="Update" ID="TextEntriesDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="ContentID" Name="ContentID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
