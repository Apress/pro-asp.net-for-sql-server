<%@ Page  MasterPageFile="~/MasterPage.master" Title="Person Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Person Detail</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="ID" EmptyDataText="The requested record was not found." DataSourceID="PersonsDataSource" ID="PersonsDetailsView"><Fields>
<asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="FirstName" HeaderText="FirstName" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="LastName" HeaderText="LastName" InsertVisible="False"></asp:BoundField>
<asp:TemplateField HeaderText="LocationID" SortExpression="LocationID"><EditItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqDAL.Location" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllLocations" TypeName="Chapter08.BlinqDAL.Location" UpdateMethod="Update" ID="Location_LocationIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Location_LocationIDList" DataTextField="ID" DataValueField="ID" SelectedValue='<%# Bind("LocationID") %>' DataSourceID="Location_LocationIDDataSource" >
</asp:DropDownList>
</EditItemTemplate>
<ItemTemplate>
<asp:HyperLink ID="LocationIDLink" runat="server" Text='<%# Eval("LocationID") %>' NavigateUrl='<%# Eval("LocationID", "~/LocationDetail.aspx?ID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Creation" HeaderText="Creation" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Modified" HeaderText="Modified" InsertVisible="False"></asp:BoundField>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqDAL.Person" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetPerson" TypeName="Chapter08.BlinqDAL.Person" UpdateMethod="Update" ID="PersonsDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="ID" Name="ID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
