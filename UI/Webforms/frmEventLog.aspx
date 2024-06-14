<%@ Page Language="C#" MasterPageFile="~/Webforms/masterPage.Master" AutoEventWireup="true" CodeBehind="frmEventLog.aspx.cs" Inherits="UI.Webforms.frmEventLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Styles/style-users.css">
    <%@ Import Namespace="System.Data" %>

    <form runat="server">
        <section class="container-eventLog">
            <asp:GridView ID="gvEventLog" CssClass="gv-users" runat="server" AllowPaging="True" PageSize="10" OnSelectedIndexChanging="gvEventLog_SelectedIndexChanging">
                <PagerSettings Mode="Numeric" PageButtonCount="4" />
            </asp:GridView>
        </section>
    </form>
</asp:Content>
