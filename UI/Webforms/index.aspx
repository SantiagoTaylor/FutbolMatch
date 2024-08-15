<%@ Page Language="C#" MasterPageFile="~/Webforms/masterPage.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UI.Webforms.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="prueba" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="LabelOnlineUsers" runat="server" Text=""></asp:Label>
<<<<<<< HEAD
    <form id="form1" runat="server">
        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Cerrar sesión" />
    </form>
</asp:Content>
=======
    <div id="form1" runat="server">
        <form runat="server">
            <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Cerrar sesión" />
        </form>
    </div>
</asp:Content>
>>>>>>> f74eaef5fdff7dcd4f11abe211b2a729f6ab4db0
