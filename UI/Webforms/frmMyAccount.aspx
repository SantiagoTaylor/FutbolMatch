<%@ Page Language="C#" MasterPageFile="~/Webforms/masterPage.Master" AutoEventWireup="true" CodeBehind="frmMyAccount.aspx.cs" Inherits="UI.Webforms.frmMyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Styles/style-myaccount.css">
    <main class="container-myaccount">

        <section class="container-accountdata">
            <h4 class="title-container">Mis Datos</h4>
            <div class="form-group">
                <asp:Label ID="LabelUsername" runat="server" Text="Usuario: ">
                    <asp:Label ID="LabelRUsername" runat="server" Text=""></asp:Label>
                </asp:Label>
                <asp:Label ID="LabelName" runat="server" Text="Nombre: ">
                    <asp:Label ID="LabelRName" runat="server" Text="Label"></asp:Label>
                </asp:Label>
                <asp:Label ID="LabelLastName" runat="server" Text="Apellido: ">
                    <asp:Label ID="LabelRLastname" runat="server" Text=""></asp:Label>
                </asp:Label>
                <asp:Label ID="LabelEmail" runat="server" Text="Email: ">
                    <asp:Label ID="LabelREmail" runat="server" Text=""></asp:Label>
                </asp:Label>
                <asp:Label ID="LabelPhone" runat="server" Text="Telefono: ">
                    <asp:Label ID="LabelRPhone" runat="server" Text=""></asp:Label>
                </asp:Label>
            </div>
            <form runat="server">
                <asp:Button ID="ButtonChangeMyData" CssClass="ButtonChangeMyData" runat="server" Text="Modificar Datos" OnClick="ButtonChangeMyData_Click" />
            </form>
        </section>

        <div class="container-extra" runat="server">
            <p>Canchas Frecuentes, Cachas favoritas</p>
        </div>

        <section class="container-bookings">
            <h4 class="title-container">Mis Reservas</h4>
        </section>
    </main>
</asp:Content>
