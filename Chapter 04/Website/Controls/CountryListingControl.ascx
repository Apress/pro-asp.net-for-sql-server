<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CountryListingControl.ascx.cs"
    Inherits="Controls_CountryListingControl" %>
<%@ Register Src="CityListingControl.ascx" TagName="CityListingControl" TagPrefix="uc1" %>
<asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <asp:Label ID="Label1" runat="server" 
                Text='<%# Bind("Country") %>'></asp:Label>
            <uc1:CityListingControl ID="CityListingControl1" runat="server" 
                Country='<%# Bind("Country") %>' />
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAllCountries" 
    TypeName="Chapter04.PersonDomain"></asp:ObjectDataSource>
