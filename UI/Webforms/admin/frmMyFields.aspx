<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Webforms/masterPage.Master" CodeBehind="frmMyFields.aspx.cs" Inherits="UI.Webforms.frmMyFields" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
    <link rel="stylesheet" href="../Styles/style-users.css">
    <%@ Import Namespace="System.Data" %>

    <form runat="server">
        <section class="container-listUsers">
            <div>
                <asp:Label ID="Label1" runat="server" Text="Establecimiento"></asp:Label>
                <asp:DropDownList ID="DropDownListEstablishment" runat="server"></asp:DropDownList>
            </div>
            <div class="container-table">
                <asp:GridView ID="gvFields" CssClass="gv-users" runat="server" AllowPaging="True" PageSize="10" OnSelectedIndexChanged="gvFields_SelectedIndexChanged">
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
        <asp:Button ID="ButtonCreateField" CssClass="btn-register" runat="server" Text="Crear cancha" OnClick="ButtonCreateField_Click"/>
    </form>
</asp:Content>

