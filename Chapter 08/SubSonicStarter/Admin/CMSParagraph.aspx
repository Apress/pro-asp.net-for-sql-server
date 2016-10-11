<%@ Page  validaterequest="false" Language="C#" AutoEventWireup="true" CodeFile="CMSParagraph.aspx.cs" Inherits="CMSParagraph" %>
<%@ OutputCache  NoStore="true" Location="None"%>
<%@ Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>
<html>
<head runat=server></head>
<body>
<form id=elForm runat=server>
    <div style="text-align:center;margin:10px;">
        <div>
        Locale: <asp:DropDownList ID=LocaleList runat=server></asp:DropDownList>
        </div>
        <div>
            <fck:FCKeditor id="txtContent" BasePath="~/FCKeditor/" runat="server"  Height="500" Width="700"/>
        </div>
        <div>	
            <uc1:ResultMessage ID="ResultMessage1" runat="server" />
            <asp:button id="btnSave" runat="server" CausesValidation="False" Text="Save" OnClick="btnSave_Click"></asp:button>&nbsp;
            <input type="button" value="Close" onclick="parent.hidePopWin(false);parent.location.reload();" />
        </div>
    </div> 
</form>
</body>
</html>
