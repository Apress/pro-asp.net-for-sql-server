<%@ Page  MasterPageFile="~/MasterPage.master" Title="Persons"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Persons</h1>
<asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" EmptyDataText="No records were returned." DataSourceID="PersonsDataSource" ID="PersonsGridView"><Columns>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
<asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
<asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName"></asp:BoundField>
<asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName"></asp:BoundField>
<asp:TemplateField HeaderText="LocationID" SortExpression="LocationID"><EditItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqDAL.Location" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllLocations" TypeName="Chapter08.BlinqDAL.Location" UpdateMethod="Update" ID="Location_LocationIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Location_LocationIDList" DataTextField="ID" DataValueField="ID" SelectedValue='<%# Bind("LocationID") %>' DataSourceID="Location_LocationIDDataSource" >
</asp:DropDownList>
</EditItemTemplate>
<ItemTemplate>
<asp:HyperLink ID="LocationIDLink" runat="server" Text='<%# Eval("LocationID") %>' NavigateUrl='<%# Eval("LocationID", "~/LocationDetail.aspx?ID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Creation" HeaderText="Creation" SortExpression="Creation"></asp:BoundField>
<asp:BoundField DataField="Modified" HeaderText="Modified" SortExpression="Modified"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/PersonDetail.aspx?ID={0}" Text="View Details"></asp:HyperLinkField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqDAL.Person" DeleteMethod="Delete" EnablePaging="True" OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetPersonsCount" SelectMethod="GetPersons" SortParameterName="sortExpression" TypeName="Chapter08.BlinqDAL.Person" UpdateMethod="Update" ID="PersonsDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="Table" Name="tableName"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="Persons_ID" Name="Persons_ID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

        <div class="link">
        <asp:HyperLink runat="server" NavigateUrl="~/NewPerson.aspx" CssClass="button" ID="NewRecordLink">Create New Person</asp:HyperLink>

        </div>    
    </div>
</asp:Content>
