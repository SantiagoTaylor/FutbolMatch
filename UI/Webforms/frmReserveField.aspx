<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Webforms/masterPage.Master" CodeBehind="frmReserveField.aspx.cs" Inherits="UI.Webforms.frmReserveField" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Styles/style-reserves.css">

    <form runat="server">
        <section class="container-registerReserve">
            <div class="container-form">
                <asp:Label ID="Label1" runat="server" Text="Establecimiento"></asp:Label><br />
                <asp:DropDownList CssClass="form-select" ID="DropDownListEstablishment" runat="server" OnSelectedIndexChanged="DropDownListEstablishment_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><br />

                <asp:Label ID="Label2" runat="server" Text="Cancha"></asp:Label><br />
                <asp:DropDownList CssClass="form-select" ID="DropDownListField" runat="server"></asp:DropDownList><br />

                <asp:Label ID="Label4" runat="server" Text="Fecha"></asp:Label><br />
                <asp:TextBox CssClass="form-control" ID="TextBoxDate" runat="server" TextMode="Date" OnTextChanged="TextBoxDate_TextChanged" AutoPostBack="True"></asp:TextBox><br />

                <asp:Label ID="Label3" runat="server" Text="Horario (1 hora)"></asp:Label><br />
                <asp:DropDownList CssClass="form-select" ID="DropDownListStartHour" runat="server"></asp:DropDownList><br />

                <br />
                <article class="container-btn">
                    <asp:Button ID="ButtonReserve" runat="server" CssClass="btn-register" Text="Reservar" OnClick="ButtonReserve_Click" />
                </article>
            </div>
        </section>
        <section class="container-reserves">
            <asp:Table runat="server" ID="TableReserves" CssClass="table-reserves">
                <asp:TableHeaderRow runat="server" CssClass="tableheader">
                    <asp:TableHeaderCell Scope="Column" Text="ID" />
                    <asp:TableHeaderCell Scope="Column" Text="Cancha" />
                    <asp:TableHeaderCell Scope="Column" Text="Cliente" />
                </asp:TableHeaderRow>
            </asp:Table>
        </section>
    </form>
</asp:Content>
