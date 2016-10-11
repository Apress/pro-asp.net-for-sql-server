<%@ Page  MasterPageFile="~/MasterPage.master" Title="Location Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Location Detail</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="ID" EmptyDataText="The requested record was not found." DataSourceID="LocationsDataSource" ID="LocationsDetailsView"><Fields>
<asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="City" HeaderText="City" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="State" HeaderText="State" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Creation" HeaderText="Creation" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Modified" HeaderText="Modified" InsertVisible="False"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="ID," DataNavigateUrlFormatString="~/Persons.aspx?Table=Location_Persons&amp;Persons_ID={0}" Text="View Persons"></asp:HyperLinkField>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqDAL.Location" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetLocation" TypeName="Chapter08.BlinqDAL.Location" UpdateMethod="Update" ID="LocationsDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="ID" Name="ID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
