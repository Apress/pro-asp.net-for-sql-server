<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeFile="LinksControl.ascx.cs" 
    Inherits="Controls_LinksControl" %>

<asp:Repeater ID="rptLinks" runat="server" 
    DataSourceID="ObjectDataSource1" 
    OnItemDataBound="rptLinks_ItemDataBound">
<HeaderTemplate>
<div id="divLinks">
<h3 class="Title" id="h3Title" runat="server">
<asp:Literal 
    ID="ltTitle" runat="server" 
    Text="Title"></asp:Literal>
</h3>
<ul class="Links">
</HeaderTemplate>
<ItemTemplate>
<li>
<asp:HyperLink 
    ID="hl1" runat="server" 
    Text='<%# Bind("Title") %>' 
    NavigateUrl='<%# Bind("Url") %>'></asp:HyperLink>
<span class="Rating">
(<asp:Literal 
    ID="lt1" runat="server" 
    Text='<%# Bind("Rating") %>'>1</asp:Literal>)
</span>
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
    SelectMethod="GetRecentFavoriteLinkCollection" 
    OnSelecting="ObjectDataSource1_Selecting">
    <SelectParameters>
        <asp:Parameter DefaultValue="0" Name="profileId" Type="Int32" />
        <asp:Parameter DefaultValue="7" Name="startDaysBack" Type="Int32" />
        <asp:Parameter DefaultValue="0" Name="endDaysBack" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="ObjectDataSource2" runat="server"
    OldValuesParameterFormatString="original_{0}"
    TypeName="Chapter07.Domain.FavoriteLinkDomain"
    SelectMethod="GetRecentFavoriteLinksByProfileID"
    OnSelecting="ObjectDataSource2_Selecting">
    <SelectParameters>
        <asp:Parameter DefaultValue="0" Name="profileId" Type="Int32" />
        <asp:Parameter DefaultValue="7" Name="startDaysBack" Type="Int32" />
        <asp:Parameter DefaultValue="0" Name="endDaysBack" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="ObjectDataSource3" runat="server"
    OldValuesParameterFormatString="original_{0}"
    TypeName="Chapter07.Website.DataServiceClient"
    SelectMethod="GetRecentFavoriteLinkCollection"
    OnSelecting="ObjectDataSource3_Selecting">
    <SelectParameters>
        <asp:Parameter DefaultValue="0" Name="profileId" Type="Int32" />
        <asp:Parameter DefaultValue="7" Name="startDaysBack" Type="Int32" />
        <asp:Parameter DefaultValue="0" Name="endDaysBack" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
