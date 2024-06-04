<%@ Page Language="C#" MasterPageFile="~/Webforms/masterPage.Master" AutoEventWireup="true" CodeBehind="frmRegister.aspx.cs" Inherits="UI.Webforms.frmRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
</asp:Content>
