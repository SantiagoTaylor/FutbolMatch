<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Webforms/masterPage.Master" CodeBehind="frmCreateEstablishment.aspx.cs" Inherits="UI.Webforms.frmCreateEstablishment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/Styles/style-establishment.css">

    <form runat="server" class="container-establishment">
        <article class="item-form">
            <asp:Label runat="server" ID="LabelName" Text="Nombre Establecimiento"></asp:Label>
            <asp:TextBox runat="server" ID="TextBoxName"></asp:TextBox>
        </article>
        <article class="item-form">
            <asp:Label runat="server" ID="LabelEmail" Text="Email"></asp:Label>
            <asp:TextBox runat="server" ID="TextBoxEmail"></asp:TextBox>
        </article>
        <article class="item-form">
            <asp:Label runat="server" ID="LabelPhone" Text="Telefono"></asp:Label>
            <asp:TextBox runat="server" ID="TextBoxPhone"></asp:TextBox>
        </article>
        <article class="item-form">
            <asp:Label runat="server" ID="LabelAdress" Text="Direccion"></asp:Label>
            <asp:TextBox runat="server" ID="TextBoxAdress"></asp:TextBox>
        </article>
        <article class="item-form">
            <asp:Button runat="server" ID="ButtonRegister" Text="Registrar" OnClick="ButtonRegister_Click"/>
        </article>
    </form>
</asp:Content>
