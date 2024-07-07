<%@ Page Language="C#" MasterPageFile="~/Webforms/masterPage.Master" AutoEventWireup="true" CodeBehind="frmReservas.aspx.cs" Inherits="UI.Webforms.frmReservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script>
        $(function () {
            $("#<%= txtFecha.ClientID %>").datepicker({
                dateFormat: 'yy-mm-dd',
                onSelect: function (dateText, inst) {
                    $(this).val(dateText);
                }
            });
        });
    </script>

    <form id="form1" runat="server">
        <h2>Reservar Cancha de Fútbol</h2>
        <asp:DropDownList ID="ddlCanchas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCanchas_SelectedIndexChanged"></asp:DropDownList>
        <asp:DropDownList ID="ddlHorarios" runat="server"></asp:DropDownList>
        <asp:TextBox ID="txtFecha" runat="server" Placeholder="Fecha (YYYY-MM-DD)"></asp:TextBox>
        <asp:Button ID="btnReservar" runat="server" Text="Reservar" OnClick="btnReservar_Click" />
    </form>
</asp:Content>