<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CityListingControl.ascx.cs" Inherits="Controls_CityListingControl" %>
<asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <asp:Label ID="Label1" runat="server" 
                Text='<%# Bind("City") %>'></asp:Label><br />
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetCitiesByCountry" 
    TypeName="Chapter04.PersonDomain" 
    OnSelecting="ObjectDataSource1_Selecting">
    <SelectParameters>
        <asp:Parameter Name="country" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
