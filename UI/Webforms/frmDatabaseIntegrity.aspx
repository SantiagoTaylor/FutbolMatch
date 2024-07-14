<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Webforms/masterPage.Master" CodeBehind="frmDatabaseIntegrity.aspx.cs" Inherits="UI.Webforms.frmDatabaseIntegrity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/Styles/style-users.css">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Dirección del Backup"></asp:Label><br />
            <asp:TextBox ID="TextBoxBackup" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonBackup" runat="server" Text="Backup" OnClick="ButtonBackup_Click" /><br />
            <asp:Label ID="Label2" runat="server" Text="Dirección del archivo"></asp:Label><br />
            <asp:FileUpload ID="FileUploadRestore" runat="server" />
            <asp:Button ID="ButtonRestore" runat="server" Text="Restaurar" OnClick="ButtonRestore_Click" /><br />
            <asp:Button ID="ButtonRecalculate" runat="server" Text="Recalcular" OnClick="ButtonRecalculate_Click" />
            <asp:Button ID="ButtonVerify" runat="server" Text="Verificar" OnClick="ButtonVerify_Click" /><br />
        </div>
        <asp:TextBox ID="TextBoxMessage" ReadOnly="true" TextMode="MultiLine" CssClass="txtErrors" runat="server"></asp:TextBox>
    </form>
</asp:Content>
