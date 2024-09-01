<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Webforms/masterPage.Master" CodeBehind="frmRegisterEmployee.aspx.cs" Inherits="UI.Webforms.frmRegisterEmployee" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/Styles/style-register.css">

    <form id="form1" runat="server">
        <div class="mb-2">
            <label for="TextBoxEmail" class="form-label">Email</label>
            <asp:TextBox ID="TextBoxEmail" CssClass="form-control" runat="server" TextMode="Email" AutoComplete="Off"></asp:TextBox>
        </div>
        <div class="mb-2">
            <label for="TextBoxUsername" class="form-label">Usuario</label>
            <asp:TextBox ID="TextBoxUsername" CssClass="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
        </div>
        <div class="mb-2">
            <asp:Label ID="LabelPassword" CssClass="form-label" runat="server" Text="Label">Contraseña</asp:Label>
            <asp:TextBox ID="TextBoxPassword" CssClass="form-control" runat="server" TextMode="Password" AutoComplete="Off"></asp:TextBox>
        </div>
        <div class="mb-2">
            <label for="TextBoxName" class="form-label">Nombre</label>
            <asp:TextBox ID="TextBoxName" CssClass="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
        </div>
        <div class="mb-2">
            <label for="TextBoxLastname" class="form-label">Apellido</label>
            <asp:TextBox ID="TextBoxLastname" CssClass="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
        </div>
        <div class="mb-2">
            <label for="TextBoxPhone" class="form-label">Teléfono</label>
            <asp:TextBox ID="TextBoxPhone" CssClass="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
        </div>

        <div class="item-input">
            <asp:Label ID="LabelLanguage" runat="server" Text="Idioma"></asp:Label>
            <asp:DropDownList ID="DropDownListLanguage" AutoPostBack="true" runat="server">
            </asp:DropDownList>
        </div>

        <div class="mb-2">
            <asp:Label ID="LabelBlocked" runat="server" Text="Bloqueado" Visible="False"></asp:Label>
            <asp:CheckBox ID="CheckBoxBlocked" runat="server" Visible="False" />
        </div>

        <asp:Button ID="ButtonRegister" CssClass="btn-register" runat="server" Text="Registrar" OnClick="ButtonRegister_Click" />
    </form>
</asp:Content>
