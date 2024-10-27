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
                    <asp:DropDownList ID="DropDownListFromLanguage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListFromLanguage_SelectedIndexChanged"></asp:DropDownList>
                </article>

                <article class="container d-flex flex-column gap-2 mb-1 w-75 h-auto">
                    <div class="d-flex w-100 gap-2">
                        <asp:Label ID="LabelLanguage2" runat="server" Text="Hacia"></asp:Label>
                    </div>
                    <asp:DropDownList ID="DropDownListToLanguage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListToLanguage_SelectedIndexChanged">
                        <asp:ListItem Text="Mango" Value="1" />
                    </asp:DropDownList>
                </article>

                <article class="container d-flex flex-column gap-2 mb-1 w-75 h-auto justify-content-center align-items-center mt-4">
                    <asp:Button ID="ButtonSave" runat="server" Text="Guardar" CssClass="btn btn-light w-75" />
                </article>

            </div>
        </section>

        <section class="container-content">
            <asp:GridView ID="gvLanguage" CssClass="gridview" runat="server" AllowPaging="True" PageSize="35"
                OnRowEditing="gvLanguage_RowEditing"
                OnRowCancelingEdit="gvLanguage_RowCancelingEdit"
                OnRowUpdating="gvLanguage_RowUpdating"
                DataKeyNames="controlName,webformName"
                AutoGenerateEditButton="True">
                <HeaderStyle
                    BackColor="white"
                    ForeColor="black"
                    Font-Bold="True"
                    CssClass="gv-header" />
                <PagerStyle
                    BackColor="white"
                    ForeColor="blue"
                    HorizontalAlign="Center" />
                <PagerSettings Mode="Numeric" PageButtonCount="10" />
            </asp:GridView>
        </section>

    </form>
</asp:Content>
