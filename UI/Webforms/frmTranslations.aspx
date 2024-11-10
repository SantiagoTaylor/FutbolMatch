<%@ Page Language="C#" MasterPageFile="~/Webforms/masterPage.Master" AutoEventWireup="true" CodeBehind="frmTranslations.aspx.cs" Inherits="UI.Webforms.frmTranslations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/Styles/style-structs.css">
    <link rel="stylesheet" href="/Styles/style-gv.css">

    <form runat="server">

        <section class="container-controls">
            <div class="container-filters w-100 h-50 d-flex flex-column justify-content-center">
                <article class="container d-flex flex-column gap-2 mb-1 w-75 h-auto">
                    <div class="d-flex w-100 gap-2">
                        <asp:Label ID="LabelLanguage" runat="server" Text="Desde"></asp:Label>
                    </div>
                    <asp:DropDownList ID="DropDownListFromLanguage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListFromLanguage_SelectedIndexChanged" CssClass="droplist"></asp:DropDownList>
                </article>

                <article class="container d-flex flex-column gap-2 mb-1 w-75 h-auto">
                    <div class="d-flex w-100 gap-2">
                        <asp:Label ID="LabelLanguage2" runat="server" Text="Hacia"></asp:Label>
                    </div>
                    <asp:DropDownList ID="DropDownListToLanguage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListToLanguage_SelectedIndexChanged" CssClass="droplist">
                        <asp:ListItem Text="Mango" Value="1" />
                    </asp:DropDownList>
                </article>

                <article class="container d-flex flex-column gap-2 mb-1 w-75 h-auto">
                    <div class="d-flex gap-2">
                        <asp:CheckBox ID="CheckBoxNull" AutoPostBack="True" runat="server" />
                        <asp:Label ID="LabelNull" runat="server" Text="Solo campos vacíos"></asp:Label>
                    </div>
                    <div class="d-flex gap-2">
                        <asp:CheckBox ID="CheckBoxWebform" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxWebform_CheckedChanged" />
                        <asp:Label ID="LabelWebform" runat="server" Text="Webform"></asp:Label>
                    </div>
                    <asp:DropDownList ID="DropDownListWebform" runat="server" Enabled="false" CssClass="droplist"></asp:DropDownList>
                </article>

                <article class="container d-flex flex-column gap-2 mb-1 w-75 h-auto justify-content-center align-items-center mt-4">
                    <asp:Button ID="ButtonFilter" runat="server" Text="Filtrar" CssClass="btn btn-light w-75" OnClick="ButtonFilter_Click" />
                    <asp:Button ID="ButtonSave" runat="server" Text="Guardar" CssClass="btn btn-light w-75" OnClick="ButtonSave_Click" />
                </article>

            </div>
        </section>

        <section class="container-content">
            <div class="w-100 h-auto overflow-y-auto">
                <asp:GridView ID="gvLanguage" CssClass="table table-striped table-bordered" runat="server"
                    OnRowEditing="gvLanguage_RowEditing"
                    OnRowCancelingEdit="gvLanguage_RowCancelingEdit"
                    OnRowUpdating="gvLanguage_RowUpdating"
                    DataKeyNames="controlName,webformName"
                    AutoGenerateEditButton="True">
                    <HeaderStyle CssClass="table-dark sticky-header bg-black" />
                    <PagerSettings Mode="Numeric" PageButtonCount="10" />
                </asp:GridView>
            </div>
        </section>

    </form>
</asp:Content>
