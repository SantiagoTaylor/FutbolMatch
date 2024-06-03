<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmRegister.aspx.cs" Inherits="UI.Webforms.frmRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>FutbolMatch</title>
    <link rel="stylesheet" href="../Styles/style-register.css" />

</head>
<body>
    <main>
        <form id="form1" runat="server">
            <div>
                <asp:Label runat="server">Email</asp:Label>
                <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server">Usuario</asp:Label>
                <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" ID="LabelPassword">Contraseña</asp:Label>
                
                <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server">Nombre</asp:Label>
                <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server">Apellido</asp:Label>
                <asp:TextBox ID="TextBoxSurname" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server">Celular</asp:Label>
                <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
            </div>

            <asp:Button ID="ButtonRegister" runat="server" Text="Registrar" OnClick="ButtonRegister_Click" />
        </form>
    </main>


</body>
</html>
