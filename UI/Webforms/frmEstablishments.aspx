<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEstablishments.aspx.cs" MasterPageFile="~/Webforms/masterPage.Master" Inherits="UI.Webforms.frmEstablishments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/Styles/style-establishment.css">

    <form runat="server" class="container-establishment">
        <section class="container-btn">
           <asp:Button ID="ButtonRegisterEstablishment"  CssClass="btn-register" runat="server" OnClick="ButtonRegisterEstablishment_Click" Text="Registrar Establecimiento"/>
        </section>
    </form>
</asp:Content>
