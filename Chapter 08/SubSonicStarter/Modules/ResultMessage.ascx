<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ResultMessage.ascx.cs" Inherits="ResultMessage" %>
<table width="100%" cellpadding="0" cellspacing="0" id="tblResult" runat="server" visible="false"
	enableviewstate="false">
	<tr id="trSuccess" runat="server">
		<td>
			<table>
				<tr>
					<td rowspan="2"><img src="<%=Page.ResolveUrl("~/images/icons/icon_check.gif")%>" align="absMiddle">
					</td>
				</tr>
				<tr>
					<td>
						<b>
							<asp:Label id="lblSuccess" runat="server"></asp:Label>
						</b>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr id="trFail" runat="server">
		<td>
			<table class=errorbox>
				<tr>
					<td rowspan="2"><img src="<%=Page.ResolveUrl("~/images/icons/icon_error.gif")%>" align="absMiddle">
					</td>
				</tr>
				<tr>
					<td ><asp:Label id="lblFail" runat="server"></asp:Label>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>