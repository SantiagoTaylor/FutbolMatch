<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEstablishments.aspx.cs" MasterPageFile="~/Webforms/masterPage.Master" Inherits="UI.Webforms.frmEstablishments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/Styles/style-establishment.css">

    <form runat="server" class="container-establishment">
        <section class="menu">

            <section class="container-btn">
                <asp:Button ID="ButtonRegisterEstablishment" CssClass="btn-register" runat="server" OnClick="ButtonRegisterEstablishment_Click" Text="Registrar Establecimiento" />
            </section>
        </section>
        <section class="container-dataestablishments">
            <asp:Table runat="server" ID="TableEstablishments" CssClass="table-establishments">
                <asp:TableHeaderRow runat="server" CssClass="tableheader">
                    <asp:TableHeaderCell Scope="Column" Text="ID" />
                    <asp:TableHeaderCell Scope="Column" Text="Nombre" />
                    <asp:TableHeaderCell Scope="Column" Text="Direccion" />
                    <asp:TableHeaderCell Scope="Column" Text="Telefono" />
                    <asp:TableHeaderCell Scope="Column" Text="Email" />
                    <asp:TableHeaderCell Scope="Column" Text="Accion" />

                </asp:TableHeaderRow>
              <asp:TableRow CssClass="tablerow">
                   
                </asp:TableRow> 
            </asp:Table>
        </section>
    </form>
</asp:Content>
