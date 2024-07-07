<%@ Page Language="C#" MasterPageFile="~/Webforms/masterPage.Master" AutoEventWireup="true" CodeBehind="frmRegister.aspx.cs" Inherits="UI.Webforms.frmRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="../Styles/style-register.css">
    <form id="form1" runat="server">
        <div class="mb-2">
            <label for="TextBoxEmail" class="form-label">Email</label>
            <asp:TextBox ID="TextBoxEmail" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
        </div>
        <div class="mb-2">
            <label for="TextBoxUsername" class="form-label">Usuario</label>
            <asp:TextBox ID="TextBoxUsername" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-2">
            <asp:Label ID="LabelPassword" CssClass="form-label" runat="server" Text="Label">Contraseña</asp:Label>
            <asp:TextBox ID="TextBoxPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <asp:Panel ID="SectionPasswordMod" runat="server" Visible="false">
            <div class="mb-2">
                <asp:Label ID="Label5" CssClass="form-label" runat="server" Text="Modificar contraseña:"></asp:Label>
                <asp:CheckBox ID="CheckBoxModPass" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBoxModPass_CheckedChanged"/>
            </div>

            <asp:Panel ID="PanelReqModPass" runat="server" Visible="false">

                <div class="mb-2">
                    <asp:Label ID="Label4" CssClass="form-label" runat="server" Text="Label">Contraseña actual</asp:Label>
                    <asp:TextBox ID="TextBoxCurrentPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="mb-2">
                    <asp:Label ID="Label1" CssClass="form-label" runat="server" Text="Label">Nueva contraseña</asp:Label>
                    <asp:TextBox ID="TextBoxNwPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="mb-2">
                    <asp:Label ID="Label2" CssClass="form-label" runat="server" Text="Label">Confirmar Contraseña</asp:Label>
                    <asp:TextBox ID="TextBoxConfirmPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                </div>

            </asp:Panel>

        </asp:Panel>
        <div class="mb-2">
            <label for="TextBoxName" class="form-label">Nombre</label>
            <asp:TextBox ID="TextBoxName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-2">
            <label for="TextBoxLastname" class="form-label">Apellido</label>
            <asp:TextBox ID="TextBoxLastname" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-2">
            <label for="TextBoxPhone" class="form-label">Teléfono</label>
            <asp:TextBox ID="TextBoxPhone" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="item-input">
            <asp:Label ID="LabelRoles" runat="server" Text="Rol"></asp:Label>
            <asp:DropDownList ID="DropDownListRoles" AutoPostBack="true" runat="server">
            </asp:DropDownList>
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

        <div class="mb-2">
            <asp:Label ID="LabelRemoved" runat="server" Text="Borrado" Visible="False"></asp:Label>
            <asp:CheckBox ID="CheckBoxRemoved" runat="server" Visible="False" />
        </div>

        <asp:Button ID="ButtonRegister" CssClass="btn-register" runat="server" Text="Registrar" OnClick="ButtonRegister_Click" />
    </form>
</asp:Content>
