<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Paragraph.ascx.cs" Inherits="Modules_Content_Paragraph" %>
<%if(SiteUtility.UserCanEdit()){%>
    <div class=contentbox id=divHolder 
    style="border:1px dashed white"
    ondblclick="showPopWin('admin/CMSParagraph.aspx?id=<%=ContentName%>', 800, 650, null);"
    onmouseover="this.style.cursor='hand'; this.style.backgroundColor='AliceBlue'; this.style.border='1px dashed gainsboro';"
    onmouseout="this.style.backgroundColor='White'; this.style.border='1px dashed white';"
    title="Double Click to Edit">
    <%if (ContentText.Trim() == string.Empty) { %>
    Double click to add text...
    <%} %>
<%}else{ %>
    <div style="border:1px solid white;">
<%}%>
    <%=ContentText %>
</div>

