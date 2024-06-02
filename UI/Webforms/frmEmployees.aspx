<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEmployees.aspx.cs" Inherits="UI.Webforms.frmEmployees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>FutbolMatch</title>
</head>
<body>
    <section class="container-listEmployees">
        <asp:Table ID="TableEmployees" runat="server" CssClass="table">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                <asp:TableHeaderCell>Apellido</asp:TableHeaderCell>
                <asp:TableHeaderCell>E-mail</asp:TableHeaderCell>
                <asp:TableHeaderCell>Usuario</asp:TableHeaderCell>
                <asp:TableHeaderCell>Celular</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </section>
    <form runat="server">
        <asp:Button ID="ButtonRegisterEmployee" runat="server" Text="Registrar Empleado" OnClick="ButtonRegisterEmployee_Click" />
    </form>
</body>
</html>
