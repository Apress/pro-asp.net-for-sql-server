<%@ Page  MasterPageFile="~/MasterPage.master" Title="Employees"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Employees</h1>
<asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="EmployeeID" EmptyDataText="No records were returned." DataSourceID="EmployeesDataSource" ID="EmployeesGridView"><Columns>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
<asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ReadOnly="True" InsertVisible="False" SortExpression="EmployeeID"></asp:BoundField>
<asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName"></asp:BoundField>
<asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName"></asp:BoundField>
<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
<asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy"></asp:BoundField>
<asp:BoundField DataField="BirthDate" HeaderText="BirthDate" SortExpression="BirthDate"></asp:BoundField>
<asp:BoundField DataField="HireDate" HeaderText="HireDate" SortExpression="HireDate"></asp:BoundField>
<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address"></asp:BoundField>
<asp:BoundField DataField="City" HeaderText="City" SortExpression="City"></asp:BoundField>
<asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region"></asp:BoundField>
<asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode"></asp:BoundField>
<asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country"></asp:BoundField>
<asp:BoundField DataField="HomePhone" HeaderText="HomePhone" SortExpression="HomePhone"></asp:BoundField>
<asp:BoundField DataField="Extension" HeaderText="Extension" SortExpression="Extension"></asp:BoundField>
<asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes"></asp:BoundField>
<asp:TemplateField HeaderText="ReportsTo" SortExpression="ReportsTo"><EditItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Employee" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllEmployees" TypeName="Chapter08.BlinqNorthwindDAL.Employee" UpdateMethod="Update" ID="ReportsToEmployee_ReportsToDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="ReportsToEmployee_ReportsToList" DataTextField="EmployeeID" DataValueField="EmployeeID" SelectedValue='<%# Bind("ReportsTo") %>' DataSourceID="ReportsToEmployee_ReportsToDataSource" AppendDataBoundItems="true" >
<asp:ListItem Text="<null>" Value="" />
</asp:DropDownList>
</EditItemTemplate>
<ItemTemplate>
<asp:HyperLink ID="ReportsToLink" runat="server" Text='<%# Eval("ReportsTo") %>' NavigateUrl='<%# Eval("ReportsTo", "~/EmployeeDetail.aspx?EmployeeID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="PhotoPath" HeaderText="PhotoPath" SortExpression="PhotoPath"></asp:BoundField>
<asp:CheckBoxField DataField="Deleted" HeaderText="Deleted" SortExpression="Deleted"></asp:CheckBoxField>
<asp:HyperLinkField DataNavigateUrlFields="EmployeeID," DataNavigateUrlFormatString="~/Employees.aspx?Table=Employee_Employees&amp;Employees_EmployeeID={0}" Text="View Employees"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="EmployeeID," DataNavigateUrlFormatString="~/EmployeeTerritories.aspx?Table=Employee_EmployeeTerritories&amp;EmployeeTerritories_EmployeeID={0}" Text="View EmployeeTerritories"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="EmployeeID," DataNavigateUrlFormatString="~/Orders.aspx?Table=Employee_Orders&amp;Orders_EmployeeID={0}" Text="View Orders"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmployeeDetail.aspx?EmployeeID={0}" Text="View Details"></asp:HyperLinkField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Employee" DeleteMethod="Delete" EnablePaging="True" OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetEmployeesCount" SelectMethod="GetEmployees" SortParameterName="sortExpression" TypeName="Chapter08.BlinqNorthwindDAL.Employee" UpdateMethod="Update" ID="EmployeesDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="Table" Name="tableName"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="Employees_EmployeeID" Name="Employees_EmployeeID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

        <div class="link">
        <asp:HyperLink runat="server" NavigateUrl="~/NewEmployee.aspx" CssClass="button" ID="NewRecordLink">Create New Employee</asp:HyperLink>

        </div>    
    </div>
</asp:Content>
