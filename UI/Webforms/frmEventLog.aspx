<%@ Page Language="C#" MasterPageFile="~/Webforms/masterPage.Master" AutoEventWireup="true" CodeBehind="frmEventLog.aspx.cs" Inherits="UI.Webforms.frmEventLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Styles/style-users.css">
    <%@ Import Namespace="System.Data" %>

    <form runat="server">
        <section class="container-eventLog">
            <div class="container-filters">
<<<<<<< HEAD
                <asp:Label ID="LabelDL" runat="server" Text="Filtras">
                    <asp:DropDownList ID="DropDownListFilters" runat="server" OnSelectedIndexChanged="DropDownListFilters_SelectedIndexChanged">
                        <asp:ListItem>Actividad</asp:ListItem>
                        <asp:ListItem>Usuario</asp:ListItem>
                        <asp:ListItem>Fecha</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>Inicio de Sesión</asp:ListItem>
                        <asp:ListItem>Cierre de Sesión</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="TextBoxUser" runat="server" OnTextChanged="TextBoxUser_TextChanged"></asp:TextBox>
                    <asp:TextBox ID="TextBoxDate" TextMode="Date" runat="server" OnTextChanged="TextBoxDate_TextChanged"></asp:TextBox>
                    <asp:DropDownList ID="DropDownListActivityLevels" runat="server"></asp:DropDownList>
                </asp:Label>
=======
                <asp:CheckBox ID="CheckBoxUsername" runat="server" />
                <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
                <asp:CheckBox ID="CheckBoxActivity" runat="server" />
                <asp:DropDownList ID="DropDownListActivity" runat="server"></asp:DropDownList>
                <asp:CheckBox ID="CheckBoxActivityLevel" runat="server" />
                <asp:DropDownList ID="DropDownListActivityLevels" runat="server"></asp:DropDownList>
                <asp:CheckBox ID="CheckBoxDate" runat="server" />
                <asp:TextBox ID="DateTimeStart" TextMode="Date" runat="server"></asp:TextBox>
                <asp:TextBox ID="DateTimeEnd" TextMode="Date" runat="server"></asp:TextBox>
>>>>>>> master
            </div>
            <asp:GridView ID="gvEventLog" CssClass="gv-users" runat="server" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvEventLog_PageIndexChanging">
                <PagerSettings Mode="Numeric" PageButtonCount="4" />
            </asp:GridView>
        </section>
    </form>
</asp:Content>
