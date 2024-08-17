<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Webforms/masterPage.Master" CodeBehind="frmCreateEstablishment.aspx.cs" Inherits="UI.Webforms.frmCreateEstablishment"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/Styles/style-establishment-register.css">

    <form runat="server" class="container-establishment">
        <div class="container-form">
            <article class="item-form">
                <asp:Label runat="server" ID="LabelName" Text="Nombre Establecimiento"></asp:Label>
                <asp:TextBox runat="server" ID="TextBoxName" CssClass="form-control"></asp:TextBox>
            </article>
            <article class="item-form">
                <asp:Label runat="server" ID="LabelEmail" Text="Email"></asp:Label>
                <asp:TextBox runat="server" ID="TextBoxEmail" CssClass="form-control"></asp:TextBox>
            </article>
            <article class="item-form">
                <asp:Label runat="server" ID="LabelPhone" Text="Telefono"></asp:Label>
                <asp:TextBox runat="server" ID="TextBoxPhone" CssClass="form-control"></asp:TextBox>
            </article>
            <article class="item-form">
                <asp:Label runat="server" ID="LabelAdress" Text="Direccion"></asp:Label>
                <asp:TextBox runat="server" ID="TextBoxAdress" CssClass="form-control"></asp:TextBox>
            </article>
            <article class="item-form-btn">
                <asp:Button CssClass="btn-register" runat="server" ID="ButtonRegister" Text="Registrar" OnClick="ButtonRegister_Click" />
            </article>
        </div>
    </form>
</asp:Content>
