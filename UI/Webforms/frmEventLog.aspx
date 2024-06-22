<%@ Page Language="C#" MasterPageFile="~/Webforms/masterPage.Master" AutoEventWireup="true" CodeBehind="frmEventLog.aspx.cs" Inherits="UI.Webforms.frmEventLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Styles/style-users.css">
    <%@ Import Namespace="System.Data" %>

    <form runat="server">
        <section class="container-eventLog">
            <div class="container-filters">
                <asp:CheckBox ID="CheckBoxUsername" runat="server" />
                <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
                <asp:CheckBox ID="CheckBoxActivity" runat="server" />
                <asp:DropDownList ID="DropDownListActivity" runat="server"></asp:DropDownList>
                <asp:CheckBox ID="CheckBoxActivityLevel" runat="server" />
                <asp:DropDownList ID="DropDownListActivityLevels" runat="server"></asp:DropDownList>
                <asp:CheckBox ID="CheckBoxDate" runat="server" />
                <asp:TextBox ID="DateTimeStart" TextMode="Date" runat="server"></asp:TextBox>
                <asp:TextBox ID="DateTimeEnd" TextMode="Date" runat="server"></asp:TextBox>
            </div>
            <asp:GridView ID="gvEventLog" CssClass="gv-users" runat="server" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvEventLog_PageIndexChanging">
                <PagerSettings Mode="Numeric" PageButtonCount="4" />
            </asp:GridView>
        </section>
    </form>
</asp:Content>
