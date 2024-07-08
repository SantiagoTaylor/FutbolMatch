<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Webforms/masterPage.Master" CodeBehind="frmReserveField.aspx.cs" Inherits="UI.Webforms.frmReserveField" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Styles/style-users.css">

    <form runat="server">
        <asp:Label ID="Label1" runat="server" Text="Establecimiento"></asp:Label><br />
        <asp:DropDownList ID="DropDownListEstablishment" runat="server" OnSelectedIndexChanged="DropDownListEstablishment_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><br />

        <asp:Label ID="Label2" runat="server" Text="Cancha"></asp:Label><br />
        <asp:DropDownList ID="DropDownListField" runat="server"></asp:DropDownList><br />
        
        <asp:Label ID="Label4" runat="server" Text="Fecha"></asp:Label><br />
        <asp:TextBox ID="TextBoxDate" runat="server" TextMode="Date" OnTextChanged="TextBoxDate_TextChanged" AutoPostBack="True"></asp:TextBox><br />

        <asp:Label ID="Label3" runat="server" Text="Horario (1 hora)"></asp:Label><br />
        <asp:DropDownList ID="DropDownListStartHour" runat="server"></asp:DropDownList><br />

        <br />
        <asp:Button ID="ButtonReserve" runat="server" cssClass="btn-register" Text="Reservar" OnClick="ButtonReserve_Click" />
    </form>
</asp:Content>
