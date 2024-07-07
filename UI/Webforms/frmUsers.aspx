<%@ Page Language="C#" MasterPageFile="~/Webforms/masterPage.Master" AutoEventWireup="true" CodeBehind="frmUsers.aspx.cs" Inherits="UI.Webforms.frmUsers" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
    <link rel="stylesheet" href="../Styles/style-users.css">
    <%@ Import Namespace="System.Data" %>

    <form runat="server">
        <section class="container-listUsers">
            <div class="container-filters">
                <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label><br />
                <asp:CheckBox ID="CheckBoxUsername" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxUsername_CheckedChanged" />
                <asp:TextBox ID="TextBoxUsername" runat="server" Enabled="false"></asp:TextBox><br />

                <asp:Label ID="Label4" runat="server" Text="Rol"></asp:Label><br />
                <asp:CheckBox ID="CheckBoxRole" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxRole_CheckedChanged" />
                <asp:DropDownList ID="DropDownListRole" runat="server" Enabled="false"></asp:DropDownList><br />

                <asp:Label ID="Label2" runat="server" Text="Bloqueado"></asp:Label>
                <asp:CheckBox ID="CheckBoxBlocked" runat="server" AutoPostBack="True" /><br />

                <asp:Label ID="Label3" runat="server" Text="Borrado"></asp:Label>
                <asp:CheckBox ID="CheckBoxRemoved" runat="server" AutoPostBack="True" /><br />

                <br />
                <asp:Button ID="ButtonFilter" runat="server" Text="Filtrar" OnClick="ButtonFilter_Click" />
            </div>
            <div class="container-table">
                <asp:GridView ID="gvUsers" CssClass="gv-users" runat="server" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvUsers_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" CommandArgument='<%#  (((DataRowView)Container.DataItem)[0]) %>'
                                    OnClick="ButtonEdit_Click"><i class="bi bi-pencil-square"></i></asp:LinkButton>
                                <asp:LinkButton runat="server" CommandArgument='<%#  (((DataRowView)Container.DataItem)[0]) %>' OnClick="ButtonDelete_Click" ForeColor="Red"><i class="bi bi-trash3-fill"></i></asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings Mode="Numeric" PageButtonCount="4" />
                    <PagerStyle BorderStyle="Groove" />
                </asp:GridView>
            </div>
        </section>
        <asp:Button ID="ButtonRegisterEmployee" CssClass="btn-register" runat="server" Text="Registrar Empleado" OnClick="ButtonRegisterEmployee_Click" />
    </form>
</asp:Content>
