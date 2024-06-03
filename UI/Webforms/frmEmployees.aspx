<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEmployees.aspx.cs" Inherits="UI.Webforms.frmEmployees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>FutbolMatch</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
</head>
<body>
    <form runat="server">
        <section class="container-listEmployees">

            <asp:GridView ID="GridView1" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("idEmploye") %>'
                                OnClick="ButtonEdit_Click"><i class="bi bi-pencil-square"></i></asp:LinkButton>
                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("idEmploye") %>' OnClick="ButtonDelete_Click" OnClientClick="return confirm('Desea eliminar?')"><i class="bi bi-trash3-fill"></i></asp:LinkButton>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </section>
        <asp:Button ID="ButtonRegisterEmployee" runat="server" Text="Registrar Empleado" OnClick="ButtonRegisterEmployee_Click" />
    </form>
</body>
</html>
