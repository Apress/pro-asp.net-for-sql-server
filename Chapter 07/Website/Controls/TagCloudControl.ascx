<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeFile="TagCloudControl.ascx.cs" 
    Inherits="Controls_TagCloudControl" %>
   
<asp:Repeater ID="rptLinkTags" runat="server" 
    DataSourceID="ObjectDataSource1" 
    OnItemDataBound="rptLinkTags_ItemDataBound" 
    OnItemCommand="rptLinkTags_ItemCommand">
<HeaderTemplate><div class="Tags"></HeaderTemplate>
<ItemTemplate>
<asp:LinkButton 
    ID="lbLinkTag" runat="Server" 
    Text='<%# Bind("Token") %>' 
    CommandArgument='<%# Bind("Token") %>'></asp:LinkButton>
</ItemTemplate>
<FooterTemplate></div></FooterTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    OldValuesParameterFormatString="original_{0}"
    OnSelecting="ObjectDataSource1_Selecting" 
    SelectMethod="GetLinkTagsWithCountByProfileID"
    TypeName="Chapter07.Domain.FavoriteLinkDomain">
    <SelectParameters>
        <asp:Parameter Name="profileId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
