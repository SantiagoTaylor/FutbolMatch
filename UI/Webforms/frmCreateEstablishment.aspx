<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Webforms/masterPage.Master" CodeBehind="frmCreateEstablishment.aspx.cs" Inherits="UI.Webforms.frmCreateEstablishment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/Styles/style-establishment-register.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script>
        //Faltaria script para tomar los valores de la localidad y provincia
    </script>
    <form runat="server" class="container-establishment">
        <div class="container-form">
            <article class="item-form">
                <asp:Label runat="server" ID="LabelEstablishmentName" Text="Nombre del establecimiento"></asp:Label>
                <asp:TextBox runat="server" ID="TextBoxName" CssClass="form-control"></asp:TextBox>
            </article>
            <article class="item-form">
                <asp:Label runat="server" ID="LabelEstablishmentEmail" Text="Email"></asp:Label>
                <asp:TextBox runat="server" ID="TextBoxEmail" CssClass="form-control"></asp:TextBox>
            </article>
            <article class="item-form">
                <asp:Label runat="server" ID="LabelEstablishmentPhone" Text="Teléfono"></asp:Label>
                <asp:TextBox runat="server" ID="TextBoxPhone" CssClass="form-control"></asp:TextBox>
            </article>
            <div class="item-form">
                <asp:Label runat="server" ID="LabelProvince" Text="Provincia"></asp:Label>
                <select class="form-select" id="slt-provincia" aria-label="Floating label select example">
                </select>
            </div>
            <div class="item-form">
                <asp:Label runat="server" ID="LabelLocality" Text="Locality"></asp:Label>
                <select class="form-select" id="slt-minu" aria-label="Floating label select example">
                </select>
            </div>
            <article class="item-form">
                <asp:Label runat="server" ID="LabelEstablishmentAddress" Text="Dirección"></asp:Label>
                <asp:TextBox runat="server" ID="TextBoxAdress" CssClass="form-control"></asp:TextBox>
            </article>
            <article class="item-form-btn">
                <asp:Button CssClass="btn-register" runat="server" ID="ButtonRegister" Text="Registrar" OnClick="ButtonRegister_Click" />
            </article>
        </div>
    </form>
    <script src="../Scripts/scripts-forms/data-provinces.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</asp:Content>
