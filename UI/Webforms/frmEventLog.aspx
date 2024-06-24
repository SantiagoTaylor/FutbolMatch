<%@ Page Language="C#" MasterPageFile="~/Webforms/masterPage.Master" AutoEventWireup="true" CodeBehind="frmEventLog.aspx.cs" Inherits="UI.Webforms.frmEventLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Styles/style-users.css">
    <%@ Import Namespace="System.Data" %>

    <form runat="server">
        <section class="container-eventLog">
            <div class="container-filters">
                <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label><br />
                <asp:CheckBox ID="CheckBoxUsername" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxUsername_CheckedChanged" />
                <asp:TextBox ID="TextBoxUsername" runat="server" Enabled="false"></asp:TextBox><br />

                <asp:Label ID="Label2" runat="server" Text="Actividad"></asp:Label><br />
                <asp:CheckBox ID="CheckBoxActivity" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxActivity_CheckedChanged" />
                <asp:DropDownList ID="DropDownListActivity" runat="server" Enabled="false"></asp:DropDownList><br />

                <asp:Label ID="Label3" runat="server" Text="Nivel"></asp:Label><br />
                <asp:CheckBox ID="CheckBoxActivityLevel" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxActivityLevel_CheckedChanged" />
                <asp:DropDownList ID="DropDownListActivityLevel" runat="server" Enabled="false"></asp:DropDownList><br />

                <asp:Label ID="Label4" runat="server" Text="Fecha"></asp:Label><br />
                <asp:CheckBox ID="CheckBoxDate" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxDate_CheckedChanged" />
                <asp:TextBox ID="DateTimeStart" TextMode="Date" runat="server" Enabled="false"></asp:TextBox>
                <asp:TextBox ID="DateTimeEnd" TextMode="Date" runat="server" Enabled="false"></asp:TextBox><br />

                <asp:Button ID="ButtonFilter" runat="server" Text="Filtrar" OnClick="ButtonFilter_Click" />
            </div>

            <div class="container-table">
                <asp:GridView ID="gvEventLog" CssClass="gv-users" runat="server" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvEventLog_PageIndexChanging">
                    <PagerSettings Mode="Numeric" PageButtonCount="4" />
                </asp:GridView>
            </div>
        </section>
    </form>
</asp:Content>
