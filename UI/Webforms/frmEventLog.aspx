<%@ Page Language="C#" MasterPageFile="~/Webforms/masterPage.Master" AutoEventWireup="true" CodeBehind="frmEventLog.aspx.cs" Inherits="UI.Webforms.frmEventLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/Styles/style-structs.css">
    <link rel="stylesheet" href="/Styles/style-gv.css">
    <%@ Import Namespace="System.Data" %>

    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <section class="container-controls">
            <div class="container-filters w-100 h-50 d-flex flex-column justify-content-center">
                <article class="container d-flex flex-column gap-2 mb-1 w-75 h-auto">
                    <div class="d-flex w-100 gap-2">
                        <asp:CheckBox ID="CheckBoxUsername" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxUsername_CheckedChanged" />
                        <asp:Label ID="LabelUsername" runat="server" Text="Usuario"></asp:Label>
                    </div>
                    <asp:TextBox ID="TextBoxUsername" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </article>
                <article class="container d-flex flex-column gap-2 mb-1 w-75 h-auto">
                    <div class="d-flex w-100 gap-2">
                        <asp:CheckBox ID="CheckBoxActivity" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxActivity_CheckedChanged" />
                        <asp:Label ID="LabelActivity" runat="server" Text="Actividad"></asp:Label>
                    </div>
                    <asp:DropDownList ID="DropDownListActivity" runat="server" Enabled="false"></asp:DropDownList>
                </article>
                <article class="container d-flex flex-column gap-2 mb-1 w-75 h-auto">
                    <div class="d-flex w-100 gap-2">
                        <asp:CheckBox ID="CheckBoxActivityLevel" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxActivityLevel_CheckedChanged" />
                        <asp:Label ID="LabelLevel" runat="server" Text="Nivel"></asp:Label>
                    </div>
                    <asp:DropDownList ID="DropDownListActivityLevel" runat="server" Enabled="false"></asp:DropDownList>
                </article>
                <article class="container d-flex flex-column gap-2 mb-1 w-75 h-auto">
                    <div class="d-flex w-100 gap-2">
                        <asp:CheckBox ID="CheckBoxDate" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxDate_CheckedChanged" />
                        <asp:Label ID="LabelDate" runat="server" Text="Fecha"></asp:Label>
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
            <div class="w-100 h-auto overflow-y-auto">
                <asp:UpdatePanel ID="UpdatePanelGridView" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvEventLog" CssClass="table table-striped table-bordered w-100" runat="server">
                            <HeaderStyle CssClass="table-dark sticky-header" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </section>
    </form>
</asp:Content>
