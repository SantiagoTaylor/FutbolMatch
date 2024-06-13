<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDatabaseIntegrity.aspx.cs" Inherits="UI.Webforms.frmDatabaseIntegrity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="ButtonRestore" runat="server" Text="Restaurar" OnClick="ButtonRestore_Click" />
            <asp:Button ID="ButtonRecalculate" runat="server" Text="Recalcular" OnClick="ButtonRecalculate_Click" />
        </div>
    </form>
</body>
</html>
