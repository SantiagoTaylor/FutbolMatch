<%@ Page Language="C#" MasterPageFile="~/Webforms/masterPage.Master" AutoEventWireup="true" CodeBehind="frmRegister.aspx.cs" Inherits="UI.Webforms.frmRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="../Styles/style-register.css">
    <form id="form1" runat="server">
        <div class="mb-2">
            <label for="TextBoxEmail" class="form-label">Email</label>
            <asp:TextBox ID="TextBoxEmail" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-2">
            <label for="TextBoxUsername" class="form-label">Username</label>
            <asp:TextBox ID="TextBoxUsername" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-2">
            <asp:Label ID="LabelPassword" CssClass="form-label" runat="server" Text="Label">Password</asp:Label>
            <asp:TextBox ID="TextBoxPassword" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-2">
            <label for="TextBoxName" class="form-label">Name</label>
            <asp:TextBox ID="TextBoxName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-2">
            <label for="TextBoxLastname" class="form-label">Lastname</label>
            <asp:TextBox ID="TextBoxLastname" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-2">
            <label for="TextBoxPhone" class="form-label">Phone</label>
            <asp:TextBox ID="TextBoxPhone" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="item-input">
            <asp:Label ID="Label1" runat="server" Text="Rol"></asp:Label>
            <asp:DropDownList ID="DropDownListRoles" AutoPostBack="true" runat="server">
            </asp:DropDownList>
        </div>

        <div class="item-input">
            <asp:Label ID="Label2" runat="server" Text="Idioma"></asp:Label>
            <asp:DropDownList ID="DropDownListLanguage" AutoPostBack="true" runat="server">
            </asp:DropDownList>
        </div>

        <asp:Button ID="ButtonRegister" CssClass="btn-register" runat="server" Text="Registrar" OnClick="ButtonRegister_Click" />
    </form>
</asp:Content>
