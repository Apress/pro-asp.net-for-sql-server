<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PersonListingControl.ascx.cs"
    Inherits="Controls_PersonListingControl" %>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
    DataSourceID="ObjectDataSource1">
</asp:GridView>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetPeopleByLastName" TypeName="Chapter04.PersonDomain" OnSelecting="ObjectDataSource1_Selecting">
    <SelectParameters>
        <asp:Parameter Name="lastName" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
