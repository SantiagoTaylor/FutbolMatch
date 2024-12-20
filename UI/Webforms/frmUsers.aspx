﻿<%@ Page Language="C#" MasterPageFile="~/Webforms/masterPage.Master" AutoEventWireup="true" CodeBehind="frmUsers.aspx.cs" Inherits="UI.Webforms.frmUsers" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
    <link rel="stylesheet" href="../Styles/style-users.css">
    <link rel="stylesheet" href="../Styles/style-structs.css">
    <link rel="stylesheet" href="/Styles/style-gv.css">
    <%@ Import Namespace="System.Data" %>

    <form runat="server">

        <section class="container-controls d-flex flex-column w-25">
            <asp:Label ID="LabelFilters" Text="Filtros" runat="server" />
            <div class="d-flex flex-column align-items-center justify-content-center">
                <article class="container d-flex align-items-center gap-1 mb-1">
                    <asp:CheckBox ID="CheckBoxUsername" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxUsername_CheckedChanged" />
                    <asp:Label ID="LabelUsername" runat="server" Text="Usuario"></asp:Label>
                    <asp:TextBox ID="TextBoxUsername" runat="server" Enabled="false" CssClass="form-control w-auto"></asp:TextBox>
                </article>
                <article class="container mb-1 d-flex align-items-center gap-1">
                    <asp:CheckBox ID="CheckBoxRole" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxRole_CheckedChanged" />
                    <asp:Label ID="LabelRole" runat="server" Text="Rol" CssClass="label-rol"></asp:Label>

                    <asp:DropDownList ID="DropDownListRole" runat="server" Enabled="false" CssClass="dropdownlist-roles"></asp:DropDownList>

                </article>
                <article class="container mb-1">
                    <asp:CheckBox ID="CheckBoxBlocked" runat="server" AutoPostBack="True" />
                    <asp:Label ID="LabelBlocked" runat="server" Text="Bloqueado"></asp:Label>
                </article>
                <article class="container mb-1">
                    <asp:CheckBox ID="CheckBoxRemoved" runat="server" AutoPostBack="True" />
                    <asp:Label ID="LabelRemoved" runat="server" Text="Borrado"></asp:Label>
                </article>

            </div>
            <article class="container w-100 d-flex justify-content-center align-items-center flex-column">
                <asp:Button ID="ButtonFilter" runat="server" Text="Filtrar" OnClick="ButtonFilter_Click" CssClass="btn btn-light w-50 shadow-sm" />
                <asp:Button ID="ButtonRegisterEmployee" CssClass="btn btn-light w-50 btn-register p-2 rounded-2 border-0 mt-2 shadow-sm" runat="server" Text="Registrar usuario" OnClick="ButtonRegisterEmployee_Click" />
            </article>
        </section>

        <section class="container-content d-flex flex-column h-100 w-100">
            <div class="w-100 h-auto overflow-y-auto">
                <asp:GridView ID="gvUsers" CssClass="table table-striped table-bordered" runat="server">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="d-flex gap-2">
                                    <asp:LinkButton runat="server" CommandArgument='<%#  (((DataRowView)Container.DataItem)[0]) %>'
                                        OnClick="ButtonEdit_Click"><i class="bi bi-pencil-square"></i></asp:LinkButton>
                                    <asp:LinkButton runat="server" CommandArgument='<%#  (((DataRowView)Container.DataItem)[0]) %>' OnClick="ButtonDelete_Click" ForeColor="Red"><i class="bi bi-trash3-fill"></i></asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="table-dark sticky-header bg-black" />
                </asp:GridView>
            </div>
        </section>

    </form>
</asp:Content>
