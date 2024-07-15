<%@ Page Language="C#" MasterPageFile="~/Webforms/masterPage.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UI.Webforms.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="prueba" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="LabelOnlineUsers" runat="server" Text=""></asp:Label>
    <div id="form1" runat="server">
        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Cerrar sesión" />
    </div>
</asp:Content>