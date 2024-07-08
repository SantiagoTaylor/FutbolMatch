<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Webforms/masterPage.Master" CodeBehind="frmCreateField.aspx.cs" Inherits="UI.Webforms.frmCreateField" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Styles/style-users.css">

    <form runat="server">
        <section>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Establecimiento"></asp:Label><br />
                <asp:DropDownList ID="DropDownListEstablishment" runat="server">
                </asp:DropDownList><br />

                <asp:Label ID="Label4" runat="server" Text="Nombre de la cancha"></asp:Label><br />
                <asp:TextBox ID="TextBoxFieldName" runat="server"></asp:TextBox><br />

                <asp:Label ID="Label2" runat="server" Text="Tamaño"></asp:Label><br />
                <asp:DropDownList ID="DropDownListSize" runat="server">
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="Label3" runat="server" Text="Tipo de piso"></asp:Label><br />
                <asp:DropDownList ID="DropDownListFloorType" runat="server">
                    <asp:ListItem>PISO</asp:ListItem>
                    <asp:ListItem>SINTETICO</asp:ListItem>
                    <asp:ListItem>NATURAL</asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="Label5" runat="server" Text="Disponibilidad"></asp:Label><br />
                <asp:DropDownList ID="DropDownListStartHour" runat="server"></asp:DropDownList>
                <asp:Label ID="Label6" runat="server" Text="hasta"></asp:Label>
                <asp:DropDownList ID="DropDownListEndHour" runat="server"></asp:DropDownList><br />

                <br />
                <asp:Button ID="ButtonCreate" runat="server" Text="Crear" CssClass="btn-register" OnClick="ButtonCreate_Click" />
            </div>
        </section>
    </form>
</asp:Content>
