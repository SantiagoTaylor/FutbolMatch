<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Webforms/masterPage.Master" CodeBehind="frmMyEstablishment.aspx.cs" Inherits="UI.Webforms.frmMyEstablishment" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Styles/style-establishment.css">

    <form runat="server" class="container-establishment">
        <article class="item-form">
            <asp:Button ID="ButtonRegister" runat="server" Text="Registrar empleado" OnClick="ButtonRegister_Click"/>
        </article>
        <section class="container-fields">
            
        </section>
    </form>
</asp:Content>
