<%@ Page Language="C#" MasterPageFile="~/Webforms/masterPage.Master" AutoEventWireup="true" CodeBehind="frmEventLog.aspx.cs" Inherits="UI.Webforms.frmEventLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/Styles/style-structs.css">
    <link rel="stylesheet" href="/Styles/style-gv.css">
    <%@ Import Namespace="System.Data" %>

    <form runat="server">
        <section class="container-controls">
            <div class="container-filters w-100 h-50 d-flex flex-column justify-content-center">
                <article class="container d-flex flex-column gap-2 mb-1 w-75 h-auto">

                    <div class="d-flex w-100 gap-2">
                        <asp:CheckBox ID="CheckBoxUsername" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxUsername_CheckedChanged" />
                        <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
                    </div>

                    <asp:TextBox ID="TextBoxUsername" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </article>

                <article class="container d-flex flex-column gap-2 mb-1 w-75 h-auto">
                    <div class="d-flex w-100 gap-2">
                        <asp:CheckBox ID="CheckBoxActivity" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxActivity_CheckedChanged" />
                        <asp:Label ID="Label2" runat="server" Text="Actividad"></asp:Label>
                    </div>
                    <asp:DropDownList ID="DropDownListActivity" runat="server" Enabled="false"></asp:DropDownList>
                </article>

                <article class="container d-flex flex-column gap-2 mb-1 w-75 h-auto">
                    <div class="d-flex w-100 gap-2">
                        <asp:CheckBox ID="CheckBoxActivityLevel" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxActivityLevel_CheckedChanged" />
                        <asp:Label ID="Label3" runat="server" Text="Nivel"></asp:Label>
                    </div>
                    <asp:DropDownList ID="DropDownListActivityLevel" runat="server" Enabled="false"></asp:DropDownList>
                </article>

                <article class="container d-flex flex-column gap-2 mb-1 w-75 h-auto">
                    <div class="d-flex w-100 gap-2">
                        <asp:CheckBox ID="CheckBoxDate" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxDate_CheckedChanged" />
                        <asp:Label ID="Label4" runat="server" Text="Fecha"></asp:Label>
                    </div>
                    <asp:TextBox ID="DateTimeStart" TextMode="Date" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                    <asp:TextBox ID="DateTimeEnd" TextMode="Date" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </article>

                <article class="container d-flex flex-column gap-2 mb-1 w-75 h-auto justify-content-center align-items-center mt-4">
                    <asp:Button ID="ButtonFilter" runat="server" Text="Filtrar" OnClick="ButtonFilter_Click" CssClass="btn btn-light w-75" />
                </article>

            </div>

        </section>
        <section class="container-content">
            <asp:GridView ID="gvEventLog" CssClass="gridview" runat="server" AllowPaging="True" PageSize="35" OnPageIndexChanging="gvEventLog_PageIndexChanging">
                <HeaderStyle
                    BackColor="white"
                    ForeColor="black"
                    Font-Bold="True"
                    CssClass="gv-header" />
                <PagerStyle
                    BackColor="white"
                    ForeColor="blue"
                    HorizontalAlign="Center"
                    />
                <PagerSettings Mode="Numeric" PageButtonCount="10" />
            </asp:GridView>
        </section>
    </form>
</asp:Content>
