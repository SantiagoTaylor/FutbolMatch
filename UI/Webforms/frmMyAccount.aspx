<%@ Page Language="C#" MasterPageFile="~/Webforms/masterPage.Master" AutoEventWireup="true" CodeBehind="frmMyAccount.aspx.cs" Inherits="UI.Webforms.frmMyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Styles/style-users.css">
    <div>
        <asp:Label runat="server" Text="Mis datos"></asp:Label>
    </div>
    <form runat="server">
        <asp:Button runat="server" Text="Cambiar contraseña" />
    </form>
    <div>
        <asp:Label runat="server" Text="Mis reservas"></asp:Label>
    </div>
</asp:Content>
