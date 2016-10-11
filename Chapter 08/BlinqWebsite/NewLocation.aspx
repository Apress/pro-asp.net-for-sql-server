<%@ Page  MasterPageFile="~/MasterPage.master" Title="New Location" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>New Location</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="ID" DefaultMode="Insert" EmptyDataText="The requested record was not found." PageIndex="-1" DataSourceID="LocationsDataSource" ID="LocationsDetailsView"><Fields>
<asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="City" HeaderText="City"></asp:BoundField>
<asp:BoundField DataField="State" HeaderText="State"></asp:BoundField>
<asp:BoundField DataField="Creation" HeaderText="Creation"></asp:BoundField>
<asp:BoundField DataField="Modified" HeaderText="Modified"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="ID," DataNavigateUrlFormatString="~/Persons.aspx?Table=Location_Persons&amp;Persons_ID={0}" Text="View Persons"></asp:HyperLinkField>
<asp:CommandField CancelText="Clear Values" ShowInsertButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqDAL.Location" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetLocation" TypeName="Chapter08.BlinqDAL.Location" UpdateMethod="Update" ID="LocationsDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="ID" Name="ID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
