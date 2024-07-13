<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Webforms/masterPage.Master" CodeBehind="frmMyEmployees.aspx.cs" Inherits="UI.Webforms.frmMyEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/Styles/style-users.css">
    <form runat="server">
        <section class="container-eventLog">
            <div class="container-filters">
                <asp:Label ID="Label1" runat="server" Text="Establecimiento"></asp:Label><br />
                <asp:DropDownList ID="DropDownListEstablishment" runat="server" OnSelectedIndexChanged="DropDownListEstablishment_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><br />
            </div>
            <div class="container-table">
                <asp:GridView ID="gvMyEmployees" CssClass="gv-users" runat="server" AllowPaging="True" PageSize="10">
                    <PagerSettings Mode="Numeric" PageButtonCount="4" />
                </asp:GridView>
            </div>
        </section>
    </form>
</asp:Content>
