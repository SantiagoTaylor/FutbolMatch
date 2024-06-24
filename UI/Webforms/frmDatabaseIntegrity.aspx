﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Webforms/masterPage.Master" CodeBehind="frmDatabaseIntegrity.aspx.cs" Inherits="UI.Webforms.frmDatabaseIntegrity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Styles/style-users.css">
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="ButtonRestore" runat="server" Text="Restaurar" OnClick="ButtonRestore_Click" />
            <asp:Button ID="ButtonRecalculate" runat="server" Text="Recalcular" OnClick="ButtonRecalculate_Click" />
            <asp:Button ID="ButtonVerify" runat="server" Text="Verificar" OnClick="ButtonVerify_Click" Style="height: 29px" />
        </div>
    </form>
</asp:Content>