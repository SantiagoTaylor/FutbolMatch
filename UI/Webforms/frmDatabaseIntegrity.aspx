<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Webforms/masterPage.Master" CodeBehind="frmDatabaseIntegrity.aspx.cs" Inherits="UI.Webforms.frmDatabaseIntegrity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/Styles/style-structs.css">
    <form id="form1" runat="server">
        <div class="container-controls d-flex flex-column">

            <section class="container-db">
                <article>
                    <asp:Label ID="Label1" runat="server" Text="Dirección del Backup"></asp:Label><br />
                    <div class="d-flex align-items-center w-auto g-3">
                        <asp:TextBox ID="TextBoxBackup" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Button ID="ButtonBackup" runat="server" Text="Backup" OnClick="ButtonBackup_Click" CssClass="btn btn-success" />
                    </div>
                    <br />
                </article>

                <article>
                    <asp:Label ID="Label2" runat="server" Text="Dirección del archivo"></asp:Label><br />
                    <div class="d-flex align-items-center w-auto g-3">
                        <asp:FileUpload ID="FileUploadRestore" runat="server" CssClass="fileUploadRestore"/>
                    </div>
                    <br />
                </article>
            </section>

            <section class="btn-group rounded-3 border border-dark-subtle overflow-hidden"role="group">
                <asp:Button cssClass="btn btn-light" ID="ButtonRestore" runat="server" Text="Restaurar" OnClick="ButtonRestore_Click" /><br />
                <asp:Button cssClass="btn btn-light" ID="ButtonRecalculate" runat="server" Text="Recalcular" OnClick="ButtonRecalculate_Click" />
                <asp:Button cssClass="btn btn-light" ID="ButtonVerify" runat="server" Text="Verificar" OnClick="ButtonVerify_Click" /><br />
            </section>

        </div>
        <div class="container-content d-flex justify-content-center align-items-center">
            <asp:TextBox ID="TextBoxMessage" ReadOnly="true" TextMode="MultiLine" CssClass="txtErrors bg-opacity-50 w-75 h-75" runat="server"></asp:TextBox>
        </div>
    </form>
</asp:Content>
