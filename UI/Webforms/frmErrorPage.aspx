<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmErrorPage.aspx.cs" Inherits="UI.Webforms.frmErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/Styles/style.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Sitio en mantenimiento</h1>
            <p>Nos disculpamos por las molestias ocasionadas</p>
        </div>
        <asp:TextBox ID="TextBoxUsername" runat="server" Visible="false"></asp:TextBox><br />
        <asp:TextBox ID="TextBoxPassword" runat="server" Visible="false"></asp:TextBox><br />
        <asp:Button ID="ButtonLogin" runat="server" Text="Iniciar sesión" Visible="false" />
    </form>
</body>
</html>
