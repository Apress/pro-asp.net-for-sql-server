<%@ Import namespace="Chapter07.Website"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TaggedLinksControl.ascx.cs" Inherits="Controls_TaggedLinksControl"  %>

<asp:Repeater ID="rptLinks" runat="server" DataSourceID="ObjectDataSource3" OnItemDataBound="rptLinks_ItemDataBound">
<HeaderTemplate>
<div id="divLinks">
<h3 class="Title"><asp:Literal ID="ltTitle" runat="server" Text="Title"></asp:Literal></h3>
<ul class="Links">
</HeaderTemplate>
<ItemTemplate>
<li>
<asp:HyperLink ID="hl1" runat="server" Text='<%# Bind("Title") %>' NavigateUrl='<%# Bind("Url") %>'></asp:HyperLink>
<span class="Rating">(<asp:Literal ID="lt1" runat="server">1</asp:Literal>)</span>
</li>
</ItemTemplate>
<FooterTemplate>
</ul>
<br style="clear: left;" />
</div>
</FooterTemplate>
</asp:Repeater>

<asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
    OldValuesParameterFormatString="original_{0}"
    TypeName="Chapter07.Domain.FavoriteLinkDomain"
    SelectMethod="GetFavoriteLinksByTag"
    OnSelecting="ObjectDataSource_Selecting">
    <SelectParameters>
        <asp:Parameter Name="profileId" Type="int32" />
        <asp:Parameter Name="token" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
    OldValuesParameterFormatString="original_{0}"
    TypeName="Chapter07.Domain.FavoriteLinkDomain" 
    SelectMethod="GetFavoriteLinkCollectionByTag" 
    OnSelecting="ObjectDataSource_Selecting">
    <SelectParameters>
        <asp:Parameter Name="profileId" Type="int32" />
        <asp:Parameter Name="token" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="ObjectDataSource3" runat="server"
    OldValuesParameterFormatString="original_{0}"
    TypeName="Chapter07.Website.DataServiceClient"
    SelectMethod="GetFavoriteLinkCollectionByTag"
    OnSelecting="ObjectDataSource_Selecting">
    <SelectParameters>
        <asp:Parameter Name="profileId" Type="int32" />
        <asp:Parameter Name="token" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

