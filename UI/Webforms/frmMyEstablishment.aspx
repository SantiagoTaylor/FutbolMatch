<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Webforms/masterPage.Master" CodeBehind="frmMyEstablishment.aspx.cs" Inherits="UI.Webforms.frmMyEstablishment" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="../Styles/style-establishment.css">
    <link rel="stylesheet" href="../Styles/style-users.css">
    <form runat="server" class="container-establishment">
        <section class="container-fields">
            <asp:GridView ID="gvEmployees" CssClass="gv-users" runat="server" AllowPaging="True" PageSize="10">
                </asp:GridView>
        </section>
        <article class="item-form">
            <asp:Button ID="ButtonRegister" runat="server" Text="Registrar empleado" OnClick="ButtonRegister_Click"/>
        </article>

        <section class="container-fields">
            
        </section>
    </form>
</asp:Content>
