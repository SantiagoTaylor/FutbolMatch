<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="UI.Webforms.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Inicio Sesion | FutbolMatch</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../Styles/style-login.css" />
    <link rel="shortcut icon" href="../Images/favicon_io/favicon.ico" type="image/x-icon">
    <link rel='stylesheet' href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' />
</head>
<body>
    <div class="login__container">
        <form id="form1" runat="server">
            <h1>BIENVENIDO</h1>
            <div class="input__box">
                <i class='bx bxs-user'></i>
                <asp:TextBox ID="txtUser" runat="server" placeholder="USUARIO"></asp:TextBox>
            </div>
            <div class="input__box">
                <i class='bx bxs-lock-alt'></i>
                <asp:TextBox ID="txtPassword" runat="server" placeholder="CONTRASEÑA" TextMode="Password"></asp:TextBox>
            </div>
            <div class="forgot__password">
                <a href="https://www.google.com.ar/">Olvide mi contraseña</a>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:Button ID="btnLogin" class="login__button" runat="server" Text="INICIAR SESIÓN" OnClick="btnLogin_Click" />
        </form>
    </div>
</body>
</html>
