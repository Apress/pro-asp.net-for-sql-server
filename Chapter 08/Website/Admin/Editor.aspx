<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Editor.aspx.cs" Inherits="Admin_Editor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SubSonic Editor</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ss:Scaffold ID="s1" runat="Server" TableName="Person"></ss:Scaffold>
        <ss:Scaffold ID="s2" runat="Server" TableName="Location"></ss:Scaffold>
    </div>
    </form>
</body>
</html>
