<%@ Page  MasterPageFile="~/MasterPage.master" Title="New Person" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>New Person</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="ID" DefaultMode="Insert" EmptyDataText="The requested record was not found." PageIndex="-1" DataSourceID="PersonsDataSource" ID="PersonsDetailsView"><Fields>
<asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="FirstName" HeaderText="FirstName"></asp:BoundField>
<asp:BoundField DataField="LastName" HeaderText="LastName"></asp:BoundField>
<asp:TemplateField HeaderText="LocationID" SortExpression="LocationID"><InsertItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqDAL.Location" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllLocations" TypeName="Chapter08.BlinqDAL.Location" UpdateMethod="Update" ID="Location_LocationIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Location_LocationIDList" DataTextField="ID" DataValueField="ID" SelectedValue='<%# Bind("LocationID") %>' DataSourceID="Location_LocationIDDataSource" >
</asp:DropDownList>
</InsertItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Creation" HeaderText="Creation"></asp:BoundField>
<asp:BoundField DataField="Modified" HeaderText="Modified"></asp:BoundField>
<asp:CommandField CancelText="Clear Values" ShowInsertButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqDAL.Person" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetPerson" TypeName="Chapter08.BlinqDAL.Person" UpdateMethod="Update" ID="PersonsDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="ID" Name="ID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
